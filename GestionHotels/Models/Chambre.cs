//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionHotels.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class chambre
    {
        public int numChamb { get; set; }
        public string etat { get; set; }
        public Nullable<int> idHot { get; set; }
        public Nullable<int> idRes { get; set; }
    
        public virtual Hotel Hotel { get; set; }
        public virtual reservation reservation { get; set; }
    }
}
