namespace Neo_Natal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        public int id { get; set; }

        public int healthworker_id { get; set; }

        [Required]
        [StringLength(50)]
        public string first_name { get; set; }

        [Required]
        [StringLength(50)]
        public string last_name { get; set; }

        [Column(TypeName = "date")]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(50)]
        public string ethnicity { get; set; }

        public int street_number { get; set; }

        [Required]
        [StringLength(50)]
        public string street_name { get; set; }

        [Required]
        [StringLength(50)]
        public string city { get; set; }

        [Required]
        [StringLength(50)]
        public string zip_code { get; set; }

        [Required]
        [StringLength(50)]
        public string county { get; set; }

        public int ward { get; set; }

        public long? phone { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        public virtual HealthWorker HealthWorker { get; set; }

        public virtual Survey Survey { get; set; }
    }
}
