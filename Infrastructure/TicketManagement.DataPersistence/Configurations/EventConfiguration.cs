using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketManagement.DataPersistence
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                ;
        }
    }
}
