using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pdf6b2.Models;

namespace pdf6b3.Databases.EntitiesTypeConfiguration
{
    public class SubjectEntityTypeConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subjects");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(a => a.Name).HasColumnName("Name");
            builder.Property(s => s.Status).HasColumnName("Status").HasDefaultValue(true);
        }
    }
}
