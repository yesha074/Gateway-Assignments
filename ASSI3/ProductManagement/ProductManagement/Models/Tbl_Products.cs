//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Products
    {
        public int P_Id { get; set; }
        public string P_Name { get; set; }
        public string P_Price { get; set; }
        public string P_Qty { get; set; }
        public string P_Short_Description { get; set; }
        public string P_Long_Description { get; set; }
        public string P_SImage { get; set; }
        public string P_LImage { get; set; }
        public Nullable<int> P_Fkey_Cid { get; set; }
    
        public virtual Tbl_Category Tbl_Category { get; set; }
    }
}