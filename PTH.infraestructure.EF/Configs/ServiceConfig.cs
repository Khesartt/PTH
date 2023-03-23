using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PTH.domain.models;

namespace PTH.infraestructure.EF.Configs
{
    public class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Service");

            builder.HasKey(e => e.id).HasName("PK_idService");

            builder.Property(x => x.name).HasColumnType("varchar(100)");
            builder.Property(x => x.description).HasColumnType("varchar(500)");
            builder.Property(x => x.icon).HasColumnType("varchar(500)");

        }
    }
}
