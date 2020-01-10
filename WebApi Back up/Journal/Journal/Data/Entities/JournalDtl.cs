using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Journal.Data
{
    [Table("journal_dtl")]
    public class JournalDtl
    {
        [Key]
        [Column("journaldtl_no")]
        public int JournaldtlNo { get; set; }
        [Required]
        [Column("fund_code")]
        [StringLength(5)]
        public string FundCode { get; set; }
        [Column("acct_code")]
        public int AcctCode { get; set; }
        [Required]
        [Column("acct_name")]
        [StringLength(50)]
        public string AcctName { get; set; }
        [Column("debit", TypeName = "decimal(18, 0)")]
        public decimal Debit { get; set; }
        [Column("credit", TypeName = "decimal(18, 0)")]
        public decimal Credit { get; set; }
        [Column("journal_no")]
        public int JournalNo { get; set; }

       
    }
}
