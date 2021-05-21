using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPIMVCProject.Models
{
    public class SBTransaction
    {
        [Key]
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Account_Number { get; set; }
        public double Amount { get; set; }
        public string TransactionType { get; set; }
    }
}
