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
    
    public partial class presences
    {
        public int id { get; set; }
        public Nullable<int> present { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> idPolicier { get; set; }
    
        public virtual Policier Policier { get; set; }
    }
}