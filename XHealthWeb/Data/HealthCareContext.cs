using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XHealthWeb.Models;

namespace XHealthWeb.Data
{
    public class HealthCareContext : DbContext
    {
        public HealthCareContext(DbContextOptions<HealthCareContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountInsurance> AccountInsurances { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<ExportHistory> ExportHistories { get; set; }
    } 
}
