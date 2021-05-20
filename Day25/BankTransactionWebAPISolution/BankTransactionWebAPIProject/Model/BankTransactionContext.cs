using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankTransactionWebAPIProject.Model
{
    public class BankTransactionContext:DbContext
    {
        public BankTransactionContext()
        {}
        public BankTransactionContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<SBTransaction> SBTransactions { get; set; }
    }
}
