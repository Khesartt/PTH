using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PTH.domain.models;

namespace PTH.infraestructure.EF.Configs
{
    internal class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");

            builder.HasKey(e => e.id).HasName("PK_idRole");

            builder.Property(x => x.name).HasColumnType("varchar(100)");
            builder.Property(e => e.active).HasColumnType("bit");
        }
    }
}
