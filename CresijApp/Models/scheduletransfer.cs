//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CresijApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class scheduletransfer
    {
        public string classname { get; set; }
        public string courseid { get; set; }
        public int newclass { get; set; }
        public string newweek { get; set; }
        public string newteacherid { get; set; }
        public int newsection { get; set; }
        public int newday { get; set; }
        public int newbuilding { get; set; }
        public int idref { get; set; }
        public string reason { get; set; }
        public string currentstatus { get; set; }
        public int id { get; set; }
    
        public virtual buildingdetail buildingdetail { get; set; }
        public virtual classdetail classdetail { get; set; }
        public virtual schedule schedule { get; set; }
    }
}
