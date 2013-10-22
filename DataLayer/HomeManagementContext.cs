using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using HomeManagement.Domain;

namespace HomeManagement.DataLayer
{
    public class HomeManagementContext : DbContext
    {
        public DbSet<Pumping> Pumpings { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}