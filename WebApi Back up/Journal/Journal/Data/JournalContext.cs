using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Data
{
    public partial class JournalContext : DbContext
    {
        //public JournalContext()
        //{
        //}

        private readonly IConfiguration _config;

        public JournalContext(DbContextOptions options, IConfiguration config) 
        {
            _config = config;
        }

        public DbSet<Account> Account { get; set; }
        public DbSet<Fund> Fund { get; set; }
        public DbSet<JournalDtl> JournalDtl { get; set; }
        public DbSet<JournalHdr> JournalHdr { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_config.GetConnectionString("Journal"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AcctCode).ValueGeneratedNever();
            });

            modelBuilder.Entity<Fund>(entity =>
            {
                entity.Property(e => e.FundCode).ValueGeneratedNever();
            });

            modelBuilder.Entity<JournalDtl>(entity =>
            {
                entity.Property(e => e.JournaldtlNo).ValueGeneratedNever();
            });*/
        }
    }
}
