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
    
    public partial class semesterinfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public semesterinfo()
        {
            this.reserveandtransfers = new HashSet<reserveandtransfer>();
            this.schedules = new HashSet<schedule>();
            this.scheduleoriginals = new HashSet<scheduleoriginal>();
            this.schedulereserves = new HashSet<schedulereserve>();
            this.sectionsinfoes = new HashSet<sectionsinfo>();
        }
    
        public string SemesterName { get; set; }
        public System.DateTime StartDate { get; set; }
        public int TotalWeeks { get; set; }
        public sbyte Sunday { get; set; }
        public sbyte Monday { get; set; }
        public sbyte Tuesday { get; set; }
        public sbyte Wednesday { get; set; }
        public sbyte Thursday { get; set; }
        public sbyte Friday { get; set; }
        public sbyte Saturday { get; set; }
        public int SemNo { get; set; }
        public sbyte AutoHoliday { get; set; }
        public int id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reserveandtransfer> reserveandtransfers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<schedule> schedules { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<scheduleoriginal> scheduleoriginals { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<schedulereserve> schedulereserves { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sectionsinfo> sectionsinfoes { get; set; }
    }
}