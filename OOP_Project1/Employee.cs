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
    
    public partial class Employee
    {
        public int emp_id { get; set; }
        public string emp_name { get; set; }
        public string designation { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string cnic { get; set; }
        public Nullable<int> age { get; set; }
        public string contact_no { get; set; }
        public string religion { get; set; }
        public string DOB { get; set; }
    
        public virtual user user { get; set; }
    }
}