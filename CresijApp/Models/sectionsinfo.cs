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
    
    public partial class sectionsinfo
    {
        public int SemesterNo { get; set; }
        public string Section { get; set; }
        public System.TimeSpan StartTime { get; set; }
        public System.TimeSpan StopTime { get; set; }
        public int id { get; set; }
        public sbyte Checked { get; set; }
    
        public virtual semesterinfo semesterinfo { get; set; }
    }
}
