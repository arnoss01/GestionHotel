using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionHotels.Models
{
    public class Reservation
    {
        [Key]
        private int idRes { get; set; }
  
        private DateTime dateRes { get; set; } = DateTime.Now;
        [Required]
        private DateTime dateDebutRes { get; set; }
        [Required]
        private DateTime dateFinRes { get; set; }




    }
}