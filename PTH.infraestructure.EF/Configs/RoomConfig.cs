using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PTH.domain.models;


namespace PTH.infraestructure.EF.Configs
{
    public class RoomConfig : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Room");

            builder.HasKey(e => e.id).HasName("PK_idRoom");

            builder.HasOne<RoomType>()
                   .WithMany()
                   .HasForeignKey(e => e.idRoomType)
                   .HasConstraintName("FK_idRoomByRoomType");

            builder.HasOne<Hotel>()
                   .WithMany()
                   .HasForeignKey(e => e.idHotel)
                   .HasConstraintName("FK_idRoomHotel");

            builder.Property(e => e.image).HasColumnType("text");
            builder.Property(e => e.baseCost).HasColumnType("decimal(20, 2)");
            builder.Property(e => e.taxes).HasColumnType("decimal(20, 2)");

            builder.Property(e => e.name).HasColumnType("varchar(100)");
            builder.Property(e => e.descripcion).HasColumnType("varchar(500)");
            builder.Property(e => e.creationDate).HasColumnType("datetime");
            builder.Property(e => e.location).HasColumnType("varchar(200)");
            builder.Property(e => e.quota).HasColumnType("int");
            builder.Property(e => e.active).HasColumnType("bit");
            builder.Property(e => e.occupied).HasColumnType("bit");
        }
    }
}
