namespace VHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EbiometricLogs
    {
        public long id { get; set; }

        public int? EbioCode { get; set; }

        public DateTime? PunchDate { get; set; }

        public DateTime? PunchDateTime { get; set; }

        [StringLength(50)]
        public string Mcid { get; set; }

        [StringLength(50)]
        public string TicketNo { get; set; }

        [StringLength(50)]
        public string Direction { get; set; }

        [StringLength(50)]
        public string Flag { get; set; }

        [StringLength(50)]
        public string IPAddress { get; set; }

        public int? LevelCode { get; set; }

        public int? ConCode { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
         
  
    }
}
