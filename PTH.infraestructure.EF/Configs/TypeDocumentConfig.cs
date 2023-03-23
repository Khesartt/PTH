using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PTH.domain.models;

namespace PTH.infraestructure.EF.Configs
{
    internal class TypeDocumentConfig : IEntityTypeConfiguration<TypeDocument>
    {
        public void Configure(EntityTypeBuilder<TypeDocument> builder)
        {
            builder.ToTable("TypeDocument");

            builder.HasKey(e => e.id).HasName("PK_idTypeDocument");

            builder.Property(x => x.name).HasColumnType("varchar(100)");
            builder.Property(x => x.active).HasColumnType("bit");
            builder.Property(x => x.Abbreviation).HasColumnType("varchar(10)");

        }
    }
}
