//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OOP_Project1
{
    using System;
    using System.Collections.Generic;
    
    public partial class purchase1
    {
        public int order_id { get; set; }
        public int prod_Id { get; set; }
        public Nullable<int> OrderQuantity { get; set; }
        public Nullable<double> TotalAmount { get; set; }
    
        public virtual C_Order C_Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
