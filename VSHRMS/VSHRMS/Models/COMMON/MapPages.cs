namespace VSHRMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MapPages
    {
        public int id { get; set; }

        [StringLength(50)]
        public string MainMenu { get; set; }

        [StringLength(50)]
        public string ControllerName { get; set; }
        [StringLength(50)]
        public string SubMenu { get; set; }

        
        public long? UpdatedBy { get; set; }

        public long CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? ConCode { get; set; }
    }
}
