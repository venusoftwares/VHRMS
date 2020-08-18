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
        [Key]
        public int Lid { get; set; }

        public string A { get; set; }

        public string B { get; set; }

        public int ConCode { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int UserId { get; set; }

        public DateTime? ModifyDate { get; set; }

        [ForeignKey("ConCode")]
        public  ConcernMaster ConcernMaster { get; set; }
    }
}
