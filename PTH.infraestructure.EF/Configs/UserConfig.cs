using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PTH.domain.models;

namespace PTH.infraestructure.EF.Configs
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(e => e.id).HasName("PK_idUser");

            builder.HasOne<Role>()
                   .WithMany()
                   .HasForeignKey(e => e.idRole)
                   .HasConstraintName("FK_idUserRol");

            builder.Property(e => e.userLogin).HasColumnType("varchar(20)");
            builder.Property(e => e.password).HasColumnType("varchar(20)");
            builder.Property(e => e.email).HasColumnType("varchar(100)");
            builder.Property(e => e.activo).HasColumnType("bit");
            builder.Property(e => e.creationDate).HasColumnType("datetime");
            builder.Property(e => e.token).HasColumnType("uniqueidentifier");
            builder.Property(e => e.tokenDate).HasColumnType("datetime");


        }
    }
}
