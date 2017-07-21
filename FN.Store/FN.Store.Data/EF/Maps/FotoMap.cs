using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Data.EF.Maps
{
    public class FotoMap : EntityTypeConfiguration<Foto>
    {
        public FotoMap()
        {
            ToTable("Foto");
            HasKey(k=>k.Id);

            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Caminho).HasColumnType("varchar").HasMaxLength(200).IsRequired();
            Property(c => c.Descricao).HasColumnType("varchar").HasMaxLength(200);

        }

    }
}
