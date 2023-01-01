using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionHotels.Models
{
    public class Chambre
    {
        [Required]
        private int numChamb { get; set; }
        [Required]
        private string etat { get; set; }  

        public virtual Hotel Hotel { get; set; }
    }
}