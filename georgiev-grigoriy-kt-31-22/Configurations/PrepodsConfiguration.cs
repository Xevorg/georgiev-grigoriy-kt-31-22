using georgiev_grigoriy_kt_31_22.Helpers;
using georgiev_grigoriy_kt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace georgiev_grigoriy_kt_31_22.Database.Configurations
{
    public class PrepodsConfiguration : IEntityTypeConfiguration<Prepods>
    {
        private const string tableName = "Prepods";

        public void Configure(EntityTypeBuilder<Prepods> builder)
        {
            builder
                .HasKey(p => p.IdPrepod)
                .HasName($"pk_{tableName}_prepods_id");

            builder.Property(p => p.IdPrepod)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.IdPrepod)
                .HasColumnName("id_prepod")
                .HasComment("Айдишник преподавателей");

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("prepod_firstname")
                .HasColumnType(ColumnType.String).HasMaxLength(150)
                .HasComment("Имя преподавателя");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("prepod_lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(150)
                .HasComment("Отчество преподавателя");

            builder.Property(p => p.MidName)
                .IsRequired()
                .HasColumnName("prepod_midname")
                .HasColumnType(ColumnType.String).HasMaxLength(150)
                .HasComment("Фамилия преподавателя");

            builder.Property(p => p.DegreeId)
                .HasColumnName("prepod_degreeId")
                .HasColumnType(ColumnType.Int)
                .HasComment("Степень преподавателя");


            builder.ToTable(tableName)
                .HasOne(p => p.Degrees)
                .WithMany()
                .HasForeignKey(p => p.DegreeId)
                .HasConstraintName("fk_degree_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(tableName)
                .HasIndex(p => p.DegreeId, $"idx_{tableName}_fk_degree_id");

            builder.Property(p => p.PositionId)
                .HasColumnName("prepod_positionId")
                .HasColumnType(ColumnType.Int)
                .HasComment("Должность преподавателя");


            builder.ToTable(tableName)
                .HasOne(p => p.Positions)
                .WithMany()
                .HasForeignKey(p => p.PositionId)
                .HasConstraintName("fk_position_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(tableName)
                .HasIndex(p => p.PositionId, $"idx_{tableName}_fk_position_id");


            //builder.Property(p => p.CafedraId)
            //    .IsRequired()
            //    .HasColumnName("prepod_cafedraId")
            //    .HasColumnType(ColumnType.Int)
            //    .HasComment("Кафедра преподавателя");


            //builder.ToTable(tableName)
            //    .HasOne(p => p.Cafedra)
            //    .WithMany()
            //    .HasForeignKey(p => p.CafedraId)
            //    .HasConstraintName("fk_cafedra_id")
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.ToTable(tableName)
            //    .HasIndex(p => p.CafedraId, $"idx_{tableName}_fk_cafedra_id");

            //builder.Navigation(p => p.Cafedra).AutoInclude();
        }

    }
}
