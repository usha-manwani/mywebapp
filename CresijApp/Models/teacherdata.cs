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
    
    public partial class teacherdata
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public teacherdata()
        {
            this.scheduletransfers = new HashSet<scheduletransfer>();
        }
    
        public string TeacherID { get; set; }
        public string TeacherName { get; set; }
        public string gender { get; set; }
        public Nullable<System.DateTime> dateofbirth { get; set; }
        public string faculty { get; set; }
        public string phone { get; set; }
        public string idcard { get; set; }
        public string onecard { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<scheduletransfer> scheduletransfers { get; set; }
    }
}
