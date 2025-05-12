using georgiev_grigoriy_kt_31_22.Helpers;
using georgiev_grigoriy_kt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace georgiev_grigoriy_kt_31_22.Database.Configurations
{
    public class PositionsConfiguration : IEntityTypeConfiguration<Positions>
    {
        private const string tableName = "Positions";
        public void Configure(EntityTypeBuilder<Positions> builder)
        {
            builder
                .HasKey(p => p.PositionId)
                .HasName($"pk_{tableName}_posinion_id");

            builder.Property(p => p.PositionId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.PositionId)
                .HasColumnName("id_position")
                .HasComment("Айдишник должности");

            builder.Property(p => p.PositionName)
                .IsRequired()
                .HasColumnName("positionName")
                .HasColumnType(ColumnType.String).HasMaxLength(150)
                .HasComment("Название должности");
        }

    }
}
