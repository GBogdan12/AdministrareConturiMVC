//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Licenta.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DU
    {
        public int id { get; set; }
        public Nullable<int> DosarId { get; set; }
        public string UserId { get; set; }
    
        public virtual Dosar Dosar { get; set; }
        public virtual UserD UserD { get; set; }
    }
}
