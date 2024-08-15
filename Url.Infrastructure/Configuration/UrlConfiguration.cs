using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using  Url.Domain.Entities;
namespace Url.Infrastructure.Configuration
{
    internal sealed class UrlConfiguration : IEntityTypeConfiguration<UrlEntity>
    {
        public void Configure(EntityTypeBuilder<UrlEntity> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.LongUrl)
                .IsRequired();

            builder.Property(u => u.ShortUrl)
                .IsRequired();
        }
    }
}