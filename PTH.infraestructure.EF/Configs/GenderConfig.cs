using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PTH.domain.models;

namespace PTH.infraestructure.EF.Configs
{
    internal class GenderConfig : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.ToTable("Gender");

            builder.HasKey(e => e.id).HasName("PK_idGender");

            builder.Property(x => x.name)
                   .HasColumnType("varchar(100)");

            builder.Property(e => e.active)
                   .HasColumnType("bit");

            builder.Property(e => e.Abbreviation)
                   .HasColumnType("varchar(10)");
        }
    }
}
