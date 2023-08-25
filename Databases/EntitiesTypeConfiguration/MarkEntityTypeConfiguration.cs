using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pdf6b2.Models;

namespace pdf6b3.Databases.EntitiesTypeConfiguration
{
    public class MarkEntityTypeConfiguration : IEntityTypeConfiguration<Mark>
    {
        public void Configure(EntityTypeBuilder<Mark> builder)
        {
            builder.ToTable("Marks");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.StudentId).HasColumnName("StudentId");
            builder.Property(x => x.SubjectId).HasColumnName("SubjectId");
            builder.Property(b => b.CreateDate).HasColumnName("CreateDate");
        }
    }
}
