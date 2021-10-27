using E_Commerce.Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace E_Commerce.RepositoryEF
{
        public class MasterContext : DbContext
        {

            public DbSet<Prodotto> Prodotti { get; set; }


            public MasterContext()
            {

            }

            public MasterContext(DbContextOptions<MasterContext> options) : base(options) { }



            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=ProdottiMaster; Trusted_Connection=True;");
            }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Prodotto>(new ProdottoConfigurations());

        }
    }
    }

