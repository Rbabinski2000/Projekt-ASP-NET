using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data.Entities
{
    [Table("Travels")]
    public class TravelEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string StartPlace { get; set; }

        public string EndPlace { get; set; }

        [Required]
        [StringLength(maximumLength: 200)]
        public string Participants { get; set; }

        
        public GuideEntity Guide { get; set; }
        [Required]
        public int GuideId {  get; set; }

        public DateTime Created { get; set; }
    }
}
