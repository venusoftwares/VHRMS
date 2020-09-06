namespace VSHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoryMaster")]
    public partial class CategoryMaster
    {
        

        public int id { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        public string WagesType { get; set; }

        public bool IntimeOutTimePunch { get; set; }

        public bool PresentHour { get; set; }

        public bool OTHour { get; set; }

        public int ConCode { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

 
    }
}
