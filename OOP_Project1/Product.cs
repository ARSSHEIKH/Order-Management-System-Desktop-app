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
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.purchase1 = new HashSet<purchase1>();
        }
    
        public int prod_id { get; set; }
        public string prod_type { get; set; }
        public string prod_name { get; set; }
        public string brand { get; set; }
        public Nullable<double> prod_price { get; set; }
        public Nullable<int> total_stock_purch { get; set; }
        public Nullable<int> available_stock { get; set; }
        public string supply_by { get; set; }
        public Nullable<double> purchasing_price { get; set; }
        public Nullable<System.DateTime> date_of_purchase { get; set; }
        public Nullable<System.DateTime> datetime_of_AddingProd { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<purchase1> purchase1 { get; set; }
    }
}
