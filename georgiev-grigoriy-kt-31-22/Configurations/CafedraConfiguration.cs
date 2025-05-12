using georgiev_grigoriy_kt_31_22.Helpers;
using georgiev_grigoriy_kt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace georgiev_grigoriy_kt_31_22.Database.Configurations
{
    public class CafedraConfiguration : IEntityTypeConfiguration<Cafedra>
    {

        public const string tableName = "cd_cafedra";
        public void Configure(EntityTypeBuilder<Cafedra> builder)
        {
            builder
                .HasKey(p => p.CafedraId)
                .HasName($"pk_{tableName}_cafedra_id");

            builder.Property(p => p.CafedraId)
                .ValueGeneratedOnAdd()
                .HasColumnName("cafedra_id")
                .HasComment("Id Кафедры");

            builder.Property(p => p.CafedraName)
                .IsRequired()
                .HasColumnName("cafedra_name")
                .HasColumnType(ColumnType.String).HasMaxLength(150)
                .HasComment("Название кафедры");

            builder.Property(p => p.totalPrerods)
                .IsRequired()
                .HasColumnName("total")
                .HasColumnType(ColumnType.Int)
                .HasComment("Количество преподавателей");

            builder.Property(p => p.dataosnovania)
                .HasColumnName("date_Osnovania")
                .HasColumnType(ColumnType.Date)
                .HasComment("Дата основания");

            builder.Property(c => c.AdminId)
                .IsRequired()
                .HasColumnName("c_admin_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор администратора(заведующего) кафедры");

            builder.ToTable(tableName).HasOne(c => c.Admin)
                .WithOne()
                .HasForeignKey<Cafedra>(c => c.AdminId)
                .HasConstraintName("fk_admin_id_prepod_id")
                .OnDelete(DeleteBehavior.Restrict);


            builder.ToTable(tableName)
                .HasIndex(p => p.CafedraId, $"idx_{tableName}_fk_admin_id_prepod_id");

            //builder.Navigation(p => p.Admin).AutoInclude();

        }

    }
}