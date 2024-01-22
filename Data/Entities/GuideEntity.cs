using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("Guides")]
    public class GuideEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        //[MaxLength(11)]
        //[MinLength(11)]
        public string Pesel { get; set; }
        public ISet<TravelEntity>? Travels { get; set; }
        public AddressEntity? Address { get; set; }
        public int AddressId { get; set; }

    }
}
