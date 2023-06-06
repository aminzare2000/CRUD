using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISC_Sample.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISC_Sample.EntityFrameworkCore.OnConfigure
{
    public class OrganizationConfigure : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasKey(it => it.Id);
            builder.Property(it => it.OrganizationName).IsRequired().HasMaxLength(50);
            builder.Property(it => it.Depart1).HasMaxLength(30);
            builder.Property(it => it.Depart2).HasMaxLength(30);
            builder.Property(it => it.Depart3).IsRequired().HasMaxLength(30);
            builder.ToTable("Organization");
        }
    }
}