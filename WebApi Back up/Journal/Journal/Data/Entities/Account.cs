using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Journal.Data
{
    [Table("account")]
    public class Account
    {
        [Key]
        [Column("acct_code")]
        [StringLength(10)]
        public string AcctCode { get; set; }
        [Required]
        [Column("acct_name")]
        [StringLength(50)]
        public string AcctName { get; set; }
        [Column("status")]
        public bool Status { get; set; }
    }
}
