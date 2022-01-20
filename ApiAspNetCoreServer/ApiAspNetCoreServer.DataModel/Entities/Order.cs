using ApiAspNetCoreServer.DataModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiAspNetCoreServer.DataModel.Entities
{
    public class Order
    {
        /// <summary>
        /// Id
        /// </summary> 
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>    
        [Required]
        public string Procedure { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>    
        
        public string Description { get; set; }

        

        /// <summary>
        /// Книги
        /// </summary> 
        public virtual ICollection<Client> Clients { get; set; }
    }
}