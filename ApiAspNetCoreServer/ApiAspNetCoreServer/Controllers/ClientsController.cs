using ApiAspNetCoreServer.DataModel;
using ApiAspNetCoreServer.DataModel.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAspNetCoreServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly GosuslugiContext _gosuslugiContext;

        public ClientsController(ILogger<ClientsController> logger, 
            GosuslugiContext gosuslugiContext)
        {
            _logger = logger;
            _gosuslugiContext = gosuslugiContext;
        }

        [HttpGet]
        public IEnumerable<ClientDto> Get()
        {
            return _gosuslugiContext.Clients
                .Include(x=> x.AvailableDocuments)
                .Include(x => x.Orders)
                .Include(x => x.ClientTypes)
                .Include(x => x.Citizenships)
                .Select(x=> new ClientDto() { 
                Id = x.Id,
                Reviews = x.Reviews,
                Gender = x.Gender,
                Age = x.Age,
                Birthday = x.Birthday,
                Name = x.Name,
                Surname = x.Surname,
                IsArchive = x.IsArchive,
                ClientTypes = x.ClientTypes.Select(y=> new ClientTypeDto() { 
                    Id = y.Id,
                    Name = y.Name,                  
                }).ToList(),
                Citizenships = x.Citizenships.Select(y=> new CitizenshipDto() { 
                    Id = y.Id,
                    Name = y.Name,                  
                }).ToList(),
                Orders = x.Orders.Select(y=> new OrderDto() { 
                    Id = y.Id,
                    Procedure = y.Procedure,
                    Description = y.Description,                   
                }).ToList(),
                AvailableDocuments = x.AvailableDocuments.Select(y=> new AvailableDocumentDto() { 
                    Name = y.Name,
                    Id = y.Id                
                }).ToList()
            
            });
        }

        [HttpPost]
        public int Post(ClientDto dto)
        {
            var citizenships = new List<Citizenship>();

            foreach (var citizenshipDto in dto.Citizenships)
            {
                var citizenship = _gosuslugiContext.Citizenships.FirstOrDefault(x => x.Name == citizenshipDto.Name);
                if (citizenship == null)
                    throw new Exception("Citizenship not found");

                citizenships.Add(citizenship);
            }

            var clientTypes = new List<ClientType>();

            foreach (var clientTypeDto in dto.ClientTypes)
            {
                var clientType = _gosuslugiContext.ClientTypes.FirstOrDefault(x => x.Name == clientTypeDto.Name);
                if (clientType == null)
                    throw new Exception("ClientType not found");

                clientTypes.Add(clientType);
            }

            var availableDocuments = new List<AvailableDocument>();

            foreach (var availableDocumentDto in dto.AvailableDocuments)
            {
                var availableDocument = _gosuslugiContext.AvailableDocuments.FirstOrDefault(x => x.Name == availableDocumentDto.Name);
                if (availableDocument == null)
                    throw new Exception("AvailableDocument not found");

                availableDocuments.Add(availableDocument);
            }
            var orders = new List<Order>();

            foreach (var orderDto in dto.Orders)
            {
                var order = _gosuslugiContext.Orders.FirstOrDefault(x=> x.Procedure == orderDto.Procedure && x.Description == orderDto.Description);
                if (order == null)
                    throw new Exception("Order not found");

                orders.Add(order);
            }

            var client = new Client() { 
                Reviews = dto.Reviews,
                Birthday = dto.Birthday,
                Gender = dto.Gender,
                Surname = dto.Surname,
                IsArchive = dto.IsArchive,
                Name = dto.Name,
                Age = dto.Age,
                Citizenships = citizenships,
                ClientTypes = clientTypes,
                AvailableDocuments = availableDocuments,                
                Orders = orders
            };

            _gosuslugiContext.Add(client);
            _gosuslugiContext.SaveChanges();

            return client.Id;
        }

        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public void Delete(int id)
        {
            var client = _gosuslugiContext.Clients.FirstOrDefault(x => x.Id == id);
            if (client == null)
                throw new Exception("Client not found");          

            _gosuslugiContext.Remove(client);
            _gosuslugiContext.SaveChanges();
        }
    }
}
