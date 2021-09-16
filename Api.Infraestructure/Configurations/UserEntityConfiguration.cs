using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infraestructure.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("User");

            builder.Property(p => p.Name)
               .HasMaxLength(64)
               .IsRequired();

            builder.Property(p => p.Email)
               .HasMaxLength(254)
               .IsRequired();

            builder.Property(p => p.Adress)
               .HasMaxLength(255)
               .IsRequired();

            builder.Property(p => p.PayerId)
               .HasMaxLength(30)
               .IsRequired();

        }
    }
}
