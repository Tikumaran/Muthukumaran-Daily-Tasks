using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPIMVCProject.Models
{
    public class SBAccount
    {
        [Key]
        public int AccountNumber { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Address { get; set; }
        public float CurrentBalance { get; set; }
    }
}
