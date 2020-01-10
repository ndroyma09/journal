using Journal.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Models
{
    public class JournalModel
    {
        public int JournalNo { get; set; }
        [Required]
        public DateTime JournalDate { get; set; }
        [Required]
        public string PayeeName { get; set; }
        [Required]
        public string FundCode { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 20)]
        public string Description { get; set; }
        [Required]
        public decimal? Amount { get; set; }

        /*public JournalDtl JournalDtl { get; set; }

        [Required]
        [StringLength(5)]
        public string JournalDtlFundCode { get; set; }

        public int JournalDtlAcctCode { get; set; }
        [Required]

        [StringLength(50)]
        public string JournalDtlAcctName { get; set; }

        public decimal JournalDtlDebit { get; set; }

        public decimal JournalDtlCredit { get; set; }

        public int JournalDtlJournalNo { get; set; }*/

        public ICollection<JournaldtlModel> JournalDetail { get; set; }
    }
}
