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
    
    public partial class congeMaladie
    {
        public int id { get; set; }
        public string nomfichier { get; set; }
        public string comment { get; set; }
        public byte[] document { get; set; }
        public Nullable<int> idpolicier { get; set; }
        public Nullable<System.DateTime> datecreate { get; set; }
        public string createby { get; set; }
        public Nullable<System.DateTime> dated { get; set; }
        public Nullable<System.DateTime> datef { get; set; }
        public Nullable<int> duree { get; set; }
    
        public virtual Policier Policier { get; set; }
    }
}
