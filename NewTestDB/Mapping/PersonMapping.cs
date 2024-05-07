using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewTestDB.Models;

namespace NewTestDB.Mapping
{
    public class PersonMapping : IEntityTypeConfiguration<PersonModel>
    {
        public void Configure(EntityTypeBuilder<PersonModel> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasMaxLength(30);
            builder.Property(p => p.LastName).HasMaxLength(30);
            builder.Property(p => p.Age).HasMaxLength(3);
            builder.Property(p => p.CarId);

            builder.HasMany(p => p.Cars)
                .WithOne()
                .HasForeignKey(c => c.PersonId);
        }
    }
}
