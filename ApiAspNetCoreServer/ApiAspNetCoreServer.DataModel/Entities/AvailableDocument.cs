using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiAspNetCoreServer.DataModel.Entities
{
    public class AvailableDocument
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
        /// Список книг
        /// </summary> 
        public virtual ICollection<Client> Clients { get; set; }
    }
}