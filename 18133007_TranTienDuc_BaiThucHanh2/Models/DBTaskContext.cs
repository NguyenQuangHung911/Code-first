using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskmanagement.Models
{
    public class DBTaskContext : DbContext
    {
        public DBTaskContext() : base("name=DBEntityTaskWork")
        {

        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
        public DbSet<User> tbUsers { get; set; }
        public DbSet<TaskWork> tbTaskWorks { get; set; }
    }
}
