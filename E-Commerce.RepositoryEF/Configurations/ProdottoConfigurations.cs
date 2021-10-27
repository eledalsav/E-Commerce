using E_Commerce.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.RepositoryEF
{
   internal class ProdottoConfigurations: IEntityTypeConfiguration<Prodotto>
    {
        public void Configure(EntityTypeBuilder<Prodotto> modelBuilder)
        {
            modelBuilder.ToTable("Prodotto"); //specifico il nome della tabella
            modelBuilder.HasKey(p => p.Codice); //specifico qual è la pk
            modelBuilder.Property(p=>p.Descrizione).IsRequired();
            modelBuilder.Property(p=>p.Tipologia).IsRequired();
            modelBuilder.Property(p => p.PrezzoPubblico).IsRequired();
            modelBuilder.Property(p => p.PrezzoFornitore).IsRequired();

        }
    }
}
