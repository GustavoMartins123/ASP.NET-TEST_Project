using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewTestDB.Models;

namespace NewTestDB.Mapping
{
    public class JobPersonMapping : IEntityTypeConfiguration<JobPersonModel>
    {
        public void Configure(EntityTypeBuilder<JobPersonModel> builder)
        {
            builder.HasKey(j => j.Id);

            builder.Property(j => j.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(j => j.Company).HasMaxLength(30);
            builder.Property(j => j.Title).HasMaxLength(30);
            builder.Property(j => j.Description).HasMaxLength(200);
            builder.Property(j => j.Salary).HasMaxLength(30);
            builder.Property(j => j.Status).IsRequired();
            builder.Property(j => j.PersonId).IsRequired();

        }
    }
}
