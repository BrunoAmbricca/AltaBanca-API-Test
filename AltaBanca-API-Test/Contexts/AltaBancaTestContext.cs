using AltaBanca_API_Test.Logs;
using AltaBanca_API_Test.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltaBanca_API_Test.Contexts
{
    public class AltaBancaTestContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerLogError> CustomerLogErrors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer("data source=DESKTOP-PVBSGPE\\MSSQLSERVER02;initial catalog=AltaBancaTest;integrated security=True");
            }
        }
    }
}
