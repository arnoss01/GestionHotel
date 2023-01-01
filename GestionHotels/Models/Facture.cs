using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionHotels.Models
{
    public class Facture

    { 
        [Key]
        private int idFac { get; set; }
        private DateTime dateFact { get; set; } = DateTime.Now;
    }
}