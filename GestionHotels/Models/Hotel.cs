using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionHotels.Models
{
    public class Hotel
    {
        [Key]
        private int idHotel { get; set; }
        [Required]
        private string adresse { get; set; }

        [Required]
        private string ville { get; set; }
        [Required]
        private string tel { get; set; }
        public virtual ICollection<Chambre> Chambres { get; set; }
            
            }
}