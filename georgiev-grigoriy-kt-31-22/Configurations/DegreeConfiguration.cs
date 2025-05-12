using georgiev_grigoriy_kt_31_22.Helpers;
using georgiev_grigoriy_kt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace georgiev_grigoriy_kt_31_22.Database.Configurations
{
    public class DegreeConfiguration : IEntityTypeConfiguration<Degrees>
    {

        public const string tableName = "cd_degree";
        public void Configure(EntityTypeBuilder<Degrees> builder)
        {
            builder
                .HasKey(p => p.DegreeId)
                .HasName($"pk_{tableName}_degree_id");

            builder.Property(p => p.DegreeId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.DegreeId)
                .HasColumnName("Degree_id")
                .HasComment("Id Степени");

            builder.Property(p => p.DegreeName)
                .IsRequired()
                .HasColumnName("Degree_name")
                .HasColumnType(ColumnType.String).HasMaxLength(150)
                .HasComment("Название степени");

        }

    }
}
