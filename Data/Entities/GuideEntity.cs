using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data.Entities
{
    [Table("Guides")]
    public class GuideEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
        public ISet<TravelEntity>? Travels { get; set; }
        public Address? Address { get; set; }

    }
}
