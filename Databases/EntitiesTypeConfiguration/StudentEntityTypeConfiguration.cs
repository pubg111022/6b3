using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pdf6b2.Models;

namespace pdf6b3.Databases.EnitityTypeConfiguration
{
    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(a => a.Name).HasColumnName("Name");
            builder.Property(b => b.Birthday).HasColumnName("Birthday");
            builder.Property(g => g.Gender).HasColumnName("Gender").HasDefaultValue("0");
            builder.Property(s => s.Status).HasColumnName("Status").HasDefaultValue(true);
        }
    }
}
