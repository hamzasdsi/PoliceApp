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
    
    public partial class mutation
    {
        public int id { get; set; }
        public Nullable<int> agence { get; set; }
        public Nullable<int> idPolicier { get; set; }
        public string motif { get; set; }
        public string numdec { get; set; }
        public Nullable<System.DateTime> datedec { get; set; }
        public Nullable<int> typedec { get; set; }
    
        public virtual detach_agence detach_agence { get; set; }
        public virtual Policier Policier { get; set; }
        public virtual type_dec type_dec { get; set; }
    }
}
