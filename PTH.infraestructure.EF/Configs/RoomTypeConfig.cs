using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PTH.domain.models;

namespace PTH.infraestructure.EF.Configs
{
    public class RoomTypeConfig : IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
            builder.ToTable("RoomType");

            builder.HasKey(e => e.id).HasName("PK_idRoomType");

            builder.Property(x => x.name).HasColumnType("varchar(100)");
            builder.Property(x => x.description).HasColumnType("varchar(500)");
        }
    }
}