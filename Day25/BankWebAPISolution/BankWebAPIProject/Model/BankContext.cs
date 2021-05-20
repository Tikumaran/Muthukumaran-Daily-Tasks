using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPIProject.Model
{
    public class BankContext:DbContext
    {
        public BankContext()
        {

        }
        public BankContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<SBAccount> SBAccounts { get; set; }
    }
}
