using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using Projekt_ASP_NET.Enums;

namespace Projekt_ASP_NET.Models
{
    public class Travel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwe!")]
        [StringLength(maximumLength: 100, ErrorMessage = "Zbyt długia nazwa")]
        [Display(Name="Nazwa")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Proszę podać date rozpoczęcia!")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Proszę podać miejsce rozpoczęcia!")]
        public string StartPlace { get; set; }

        public string EndPlace { get; set; }

        [Required]
        [StringLength(maximumLength:200)]
        public string Participants { get; set; }

        [Required]
        [Display(Name = "Przewodnik")]
        public Guides Guide { get; set; }

        [HiddenInput]
        public DateTime Created { get; set; }
    }
}
