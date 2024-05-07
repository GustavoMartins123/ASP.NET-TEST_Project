using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewTestDB.Models;

namespace NewTestDB.Mapping
{
    public class CarMapping : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(c => c.Name).HasMaxLength(30);
            builder.Property(c => c.Description).HasMaxLength(200);
            builder.Property(c => c.LicensePlate).HasMaxLength(8);
            builder.Property(c => c.PersonId);
        }
    }
}
