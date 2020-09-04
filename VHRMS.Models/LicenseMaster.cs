namespace VHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LicenseMaster")]
    public partial class LicenseMaster
    {
        public int id { get; set; }

        public string EncryptA { get; set; }

        public string EncryptB { get; set; }

        public int? ConCode { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
       
        [ForeignKey("ConCode")]
        public  ConcernMaster ConcernMaster { get; set; }
    }
}
