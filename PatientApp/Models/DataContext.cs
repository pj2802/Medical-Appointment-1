using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PatientApp.Models
{
    public class DataContext: DbContext 
    {
        public DataContext() : base("DataContext")
        {

        }

        public DbSet<Patients> Patients { get; set; }
        public DbSet<Appointments> Appointments { get; set; }

      /*  protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
      */

    }
}