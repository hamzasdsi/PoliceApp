//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PoliceApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Enfants
    {
        public int Enfant_ID { get; set; }
        public string Nom_enfant { get; set; }
        public Nullable<System.DateTime> Date_naissance { get; set; }
        public string lieu { get; set; }
        public Nullable<int> Epouse_ID { get; set; }
        public Nullable<int> Matricule_ID { get; set; }
    
        public virtual Epouses Epouses { get; set; }
        public virtual Policier Policier { get; set; }
    }
}
