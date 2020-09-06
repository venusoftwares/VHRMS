namespace VSHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConcernMaster")]
    public partial class ConcernMaster
    {
     

        public int id { get; set; }

        [StringLength(50)]
        public string ConcernName { get; set; }

        [StringLength(50)]
        public string Address1 { get; set; }

        [StringLength(50)]
        public string Address2 { get; set; }

        [StringLength(50)]
        public string WebSite { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string MobileNo { get; set; }

        [StringLength(50)]
        public string PhoneNo { get; set; }

        [StringLength(50)]
        public string GST { get; set; }

        [StringLength(50)]
        public string MailJetPublicKey { get; set; }

        [StringLength(50)]
        public string MailJetPrivateKey { get; set; }

        [StringLength(50)]
        public string MailJetEmail { get; set; }

        [StringLength(50)]
        public string MailJetName { get; set; }

        public string SmsApi { get; set; }

        public bool? Status { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

 
    }
}
