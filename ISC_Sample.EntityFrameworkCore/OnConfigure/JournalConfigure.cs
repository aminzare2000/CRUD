using ISC_Sample.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISC_Sample.EntityFrameworkCore.OnConfigure
{
    public class JournalConfigure : IEntityTypeConfiguration<Journal>
    {
        public void Configure(EntityTypeBuilder<Journal> builder)
        {
            builder.HasKey(it => it.Id);
            builder.Property(it => it.Title).IsRequired().HasMaxLength(30);
            builder.Property(it => it.Issn).HasMaxLength(10);
            builder.Property(it => it.WebSite).HasMaxLength(50);
            builder.Property(it => it.Email).IsRequired().HasMaxLength(50);
            builder.ToTable("Journal");
        }
    }
}