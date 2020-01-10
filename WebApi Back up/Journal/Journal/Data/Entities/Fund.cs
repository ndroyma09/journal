using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Journal.Data
{
   [Table("fund")]
    public class Fund
    {
        [Key]
        [Column("fund_code")]
        [StringLength(5)]
        public string FundCode { get; set; }
        [Required]
        [Column("fund_name")]
        [StringLength(100)]
        public string FundName { get; set; }
        [Column("status")]
        public bool Status { get; set; }
    }
}
