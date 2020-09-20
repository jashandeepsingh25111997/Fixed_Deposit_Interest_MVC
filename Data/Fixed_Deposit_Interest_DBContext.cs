using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fixed_Deposit_Interest_MVC.Models;

namespace Fixed_Deposit_Interest_MVC.Data
{
    public class Fixed_Deposit_Interest_DBContext : DbContext
    {
        public Fixed_Deposit_Interest_DBContext (DbContextOptions<Fixed_Deposit_Interest_DBContext> options)
            : base(options)
        {
        }

        public DbSet<Fixed_Deposit_Interest_MVC.Models.Account> Account { get; set; }

        public DbSet<Fixed_Deposit_Interest_MVC.Models.Bank> Bank { get; set; }

        public DbSet<Fixed_Deposit_Interest_MVC.Models.CalculatedBalance> CalculatedBalance { get; set; }

        public DbSet<Fixed_Deposit_Interest_MVC.Models.Customer> Customer { get; set; }
    }
}
