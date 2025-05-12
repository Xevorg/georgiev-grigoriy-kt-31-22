using georgiev_grigoriy_kt_31_22.Helpers;
using georgiev_grigoriy_kt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace georgiev_grigoriy_kt_31_22.Database.Configurations
{
    public class NagruzkaConfiguration : IEntityTypeConfiguration<Nagruzka>

    {
        private const string TableName = "cd_Nagruzka";

        public void Configure(EntityTypeBuilder<Nagruzka> builder)
        {
            builder.HasKey(s => s.Id).HasName($"pk_{TableName}_Id");

            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("para_id")
                .HasComment("Идентификатор занятия");

            builder.Property(s => s.DisciplineId)
                .HasColumnName("c_discipline_id")
                .HasComment("Идентификатор предмета");

            builder.ToTable(TableName).HasOne(s => s.Disciplines)
                .WithMany()
                .HasForeignKey(s => s.DisciplineId)
                .HasConstraintName($"fk_discipline_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(TableName)
                .HasIndex(p => p.DisciplineId, $"idx_{TableName}_fk_subject_id");

            builder.Property(s => s.PrepodId)
                .HasColumnName("c_prepod_id")
                .HasComment("Идентификатор преподавателя");

            builder.ToTable(TableName).HasOne(s => s.Prepod)
                .WithMany()
                .HasForeignKey(s => s.PrepodId)
                .HasConstraintName($"fk_prepod_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(TableName)
                .HasIndex(p => p.PrepodId, $"idx_{TableName}_fk_prepod_id");

            builder.Property(s => s.totalHours)
                .IsRequired()
                .HasColumnName("c_nagruzka_hours")
                .HasColumnType(ColumnType.Int)
                .HasComment("Нагрузка в часах");

        }

    }
}

