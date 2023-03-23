using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PTH.domain.modelsDomain;

namespace PTH.infraestructure.EF.Configs
{
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");

            builder.HasKey(e => e.id).HasName("PK_idCity");

            builder.Property(x => x.name)
                   .HasColumnType("varchar(100)");
        }
    }
}
