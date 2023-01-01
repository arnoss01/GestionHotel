using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionHotels.Models
{
    public class Service
    {
        [Key]
        private int id { get; set; }
        [Required]
        private string description { get; set; }
        [Required]
        private double prix { get; set; }

    }
}