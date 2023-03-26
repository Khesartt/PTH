using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PTH.domain.models;
using PTH.domain.modelsDomain;


namespace PTH.infraestructure.EF.Configs
{
    public class HotelConfig : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.ToTable("Hotel");

            builder.HasKey(e => e.id).HasName("PK_idHotel");

            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(e => e.idUser)
                   .HasConstraintName("FK_idHotelUser");

            builder.HasOne<City>()
                   .WithMany()
                   .HasForeignKey(e => e.idCity)
                   .HasConstraintName("FK_idHotelCity");


            builder.Property(x => x.checkIn).HasColumnType("time");
            builder.Property(x => x.checkOut).HasColumnType("time");
            builder.Property(x => x.name).HasColumnType("varchar(100)");
            builder.Property(x => x.description).HasColumnType("varchar(100)");
            builder.Property(x => x.image).HasColumnType("text");
            builder.Property(x => x.address).HasColumnType("varchar(100)");
            builder.Property(x => x.services).HasColumnType("varchar(100)");
            builder.Property(x => x.creationDate).HasColumnType("datetime");
            builder.Property(x => x.active).HasColumnType("bit");
        }
    }
}
