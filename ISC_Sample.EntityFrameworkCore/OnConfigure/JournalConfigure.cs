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
            builder.Property(it => it.Title);
            builder.Property(it => it.Issn);
            builder.Property(it => it.WebSite);
            builder.Property(it => it.Email);
            builder.ToTable("Journal");
        }
    }
}