using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PTH.domain.models;


namespace PTH.infraestructure.EF.Configs
{
    public class ReservationConfig : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservation");

            builder.HasKey(e => e.id).HasName("PK_idReservation");

            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(e => e.idUser)
                   .HasConstraintName("FK_idReservationUser");

            builder.HasOne<Room>()
                   .WithMany()
                   .HasForeignKey(e => e.idRoom)
                   .HasConstraintName("FK_idReservationRoom");

            builder.Property(e => e.active).HasColumnType("bit");
            builder.Property(e => e.creationDate).HasColumnType("datetime");
            builder.Property(e => e.inDate).HasColumnType("datetime");
            builder.Property(e => e.outDate).HasColumnType("datetime");
            builder.Property(e => e.amount).HasColumnType("int");

        }
    }
}
