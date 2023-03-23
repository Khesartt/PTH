using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PTH.domain.models;

namespace PTH.infraestructure.EF.Configs
{
    public class ParametricConfig : IEntityTypeConfiguration<Parametric>
    {
        public void Configure(EntityTypeBuilder<Parametric> builder)
        {
            builder.ToTable("Parametric");

            builder.HasKey(e => e.id).HasName("PK_idParametric");

            builder.Property(x => x.key).HasColumnType("varchar(200)");
            builder.Property(e => e.value).HasColumnType("varchar(200)");
            builder.Property(e => e.description).HasColumnType("varchar(500)");
        }
    }
}
