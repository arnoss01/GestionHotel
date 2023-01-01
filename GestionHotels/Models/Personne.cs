using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionHotels.Models
{
    public class Personne
    {
        [Key]
        private int id { get; set; }
        private string nom { get; set; }
        private string prenom { get; set; }
        private string email { get; set; }
        private string cin { get; set; }
        private string tel { get; set; }
        private string mdp { get; set; }

    }
}