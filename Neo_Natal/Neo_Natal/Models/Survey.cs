namespace Neo_Natal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Survey")]
    public partial class Survey
    {
        public int? risk_score { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int client_id { get; set; }

        public int? Q1_address { get; set; }

        public int? Q2_zip_code { get; set; }

        public int? Q3_race { get; set; }

        public int? Q4_ward { get; set; }

        public int? Q5_first_child { get; set; }

        public int? Q6_prem_birth { get; set; }

        public int? Q7_obgyn { get; set; }

        public int? Q8_age { get; set; }

        public int? Q9_stress { get; set; }

        public int? Q10_smoker { get; set; }

        public int? Q11_fam_smoker { get; set; }

        public int? Q12_alcohol { get; set; }

        public int? Q13_fam_alcohol { get; set; }

        public int? Q14_fam_drug { get; set; }

        public int? Q15_drug { get; set; }

        public int? Q16_safe_nbhood { get; set; }

        public int? Q17_safe_home { get; set; }

        public int? Q18_illness { get; set; }

        public int? Q19_transport { get; set; }

        public int? Q20_internet { get; set; }

        public int? Q21_mob_internet { get; set; }

        public int? Q22_diet { get; set; }

        public int? Q23_gov_assist { get; set; }

        public int? Q24_rel_income { get; set; }

        public int? Q25_education { get; set; }

        public virtual Client Client { get; set; }
    }
}
