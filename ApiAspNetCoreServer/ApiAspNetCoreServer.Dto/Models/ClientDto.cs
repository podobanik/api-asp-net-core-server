using ApiAspNetCoreServer.DataModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiAspNetCoreServer.DataModel.Entities
{
    public class ClientDto
    {
        /// <summary>
        /// Id
        /// </summary> 
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>    
        [Required]
        public string Name { get; set; }
                
        /// <summary>
        /// ISBN
        /// </summary>  
        [Required]
        public string Surname { get; set; }

        /// <summary>
        /// Год издания книги
        /// </summary>  
        public int Age { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>  
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Тип валюты
        /// </summary> 
        public List<CitizenshipDto> Citizenships { get; set; }

        /// <summary>
        /// Дата создания записи
        /// </summary> 
        public Gender Gender { get; set; }

        /// <summary>
        /// Жанр
        /// </summary> 
        public List<ClientTypeDto> ClientTypes { get; set; }

        /// <summary>
        /// Архивная запись
        /// </summary>  
        public bool IsArchive { get; set; }

        /// <summary>
        /// Описание
        /// </summary>    
        [Required]
        public string Reviews { get; set; }

        /// <summary>
        /// Авторы
        /// </summary> 
        public List<OrderDto> Orders { get; set; }

        /// <summary>
        /// Языки
        /// </summary> 
        public List<AvailableDocumentDto> AvailableDocuments { get; set; }      

        
    }
}