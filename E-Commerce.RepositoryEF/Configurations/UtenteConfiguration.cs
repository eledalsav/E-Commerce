using E_Commerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.RepositoryEF.Configurations
{
    class UtenteConfiguration : IEntityTypeConfiguration<Utente>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Utente> modelBuilder)
        {
            modelBuilder.ToTable("Utente");
            modelBuilder.HasKey(s => s.Id);
            modelBuilder.Property(s => s.Nome).IsRequired();
            modelBuilder.Property(s => s.Username).IsRequired();
            modelBuilder.Property(s => s.Password).IsRequired();
            modelBuilder.Property(s => s.Ruolo).IsRequired();
        }
    }
}
