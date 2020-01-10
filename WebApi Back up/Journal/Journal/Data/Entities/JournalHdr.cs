using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Journal.Data
{
    [Table("journal_hdr")]
    public class JournalHdr
    {
        [Key]
        [Column("journal_no")]
        public int JournalNo { get; set; }

        [Column("journal_date", TypeName = "datetime")]
       
        public DateTime JournalDate { get; set; }
        [Required]
        [Column("payee_name")]
        [StringLength(50)]
        public string PayeeName { get; set; }
        [Required]
        [Column("fund_code")]
        [StringLength(5)]
        public string FundCode { get; set; }
        [Required]
        [Column("description")]
       
        public string Description { get; set; }
        [Column("amount", TypeName = "decimal(18, 0)")]
        public decimal Amount { get; set; }

        public ICollection<JournalDtl> JournalDetail { get; set; }


    }
}
