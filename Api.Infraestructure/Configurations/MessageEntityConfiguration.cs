using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infraestructure.Configurations
{
    public class MessageEntityConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Messages");

            builder.Property(p => p.OrderId)
               .HasMaxLength(64)
               .IsRequired();

            builder.Property(p => p.Ammount)
               .HasColumnType("decimal")
               .HasPrecision(30,9)
               .IsRequired();

            builder.Property(p => p.Currency)
               .HasMaxLength(16)
               .IsRequired();

            builder.Property(p => p.Date)
                .HasColumnType("date");

            builder.Property(p => p.MessageText)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne(p => p.User)
               .WithOne(u => u.Message)
               .HasForeignKey<Message>(p => p.UserId)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired();

        }
    }
}
