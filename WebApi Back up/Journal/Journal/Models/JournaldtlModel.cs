using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Models
{
    public class JournaldtlModel
    {

       
        public int JournaldtlNo { get; set; }

        [Required]
        [StringLength(5)]
        public string FundCode { get; set; }

        public int AcctCode { get; set; }
        [Required]

        [StringLength(50)]
        public string AcctName { get; set; }

        public decimal Debit { get; set; }

        public decimal Credit { get; set; }

        public int JournalNo { get; set; }
        
    }
}
