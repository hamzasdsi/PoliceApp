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
    
    public partial class recompense
    {
        public int id { get; set; }
        public Nullable<System.DateTime> datedec { get; set; }
        public string numdec { get; set; }
        public Nullable<int> typeRecomp { get; set; }
        public Nullable<int> idPolicier { get; set; }
        public string autorite { get; set; }
        public Nullable<System.DateTime> dateS { get; set; }
    
        public virtual Policier Policier { get; set; }
        public virtual Type_recompense Type_recompense { get; set; }
    }
}
