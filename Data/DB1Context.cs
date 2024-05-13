using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ПРОЕКТ2.Models;

namespace ПРОЕКТ2.Data
{
    public class DB1Context : DbContext
    {
        public DB1Context()
        {
        }

        public DB1Context(DbContextOptions<DB1Context> options)
            : base(options)
        {
        }

        public DbSet<Manager> Managers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Проекты VS\\ПРОЕКТ2\\ПРОЕКТ2\\DB1.mdf\";Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>().HasNoKey();
            // другие конфигурации
        }

    }
}
