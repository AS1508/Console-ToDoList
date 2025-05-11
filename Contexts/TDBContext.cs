using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using objTask = ToDoDB.Objects.Task;

namespace ToDoDB.Contexts
{
    public class TDBContext : DbContext
    {
        public DbSet<objTask> Tasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder) => optionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TodoListDB;Trusted_Connection=True;");
    }
}
