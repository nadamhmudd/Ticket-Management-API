using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketManagement.DataPersistence
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50)
                ;
        }
    }
}
