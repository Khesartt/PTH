using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PTH.domain.modelsDomain;
using PTH.domain.models;

namespace PTH.infraestructure.EF.Configs
{
    public class ReservationInfoConfig : IEntityTypeConfiguration<ReservationInfo>
    {
        public void Configure(EntityTypeBuilder<ReservationInfo> builder)
        {
            builder.ToTable("ReservationInfo");

            builder.HasKey(e => e.id).HasName("PK_idReservationInfo");

            builder.HasOne<Reservation>()
                  .WithMany()
                  .HasForeignKey(e => e.idReservation)
                  .HasConstraintName("FK_idReservationInfoByReservation");

            builder.HasOne<Gender>()
                  .WithMany()
                  .HasForeignKey(e => e.idGender)
                  .HasConstraintName("FK_idReservationInfoGender");

            builder.HasOne<TypeDocument>()
                  .WithMany()
                  .HasForeignKey(e => e.idTypeDocument)
                  .HasConstraintName("FK_idReservationInfoTypeDocument");


            builder.Property(x => x.names).HasColumnType("varchar(100)");
            builder.Property(x => x.lastNames).HasColumnType("varchar(100)");
            builder.Property(x => x.identification).HasColumnType("varchar(30)");
            builder.Property(x => x.phone).HasColumnType("varchar(20)");
            builder.Property(x => x.birthDate).HasColumnType("datetime");
            builder.Property(x => x.email).HasColumnType("varchar(100)");
            builder.Property(x => x.namesEContact).HasColumnType("varchar(100)");
            builder.Property(x => x.lastNamesEContact).HasColumnType("varchar(100)");
            builder.Property(x => x.phoneEContact).HasColumnType("varchar(20)");
        }
    }
}
