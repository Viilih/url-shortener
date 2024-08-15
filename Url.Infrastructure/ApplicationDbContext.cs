using Microsoft.EntityFrameworkCore;
using Url.Infrastructure.Common.Interfaces;
using Url.Domain.Entities;

namespace Url.Infrastructure;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
        
    }
    public DbSet<UrlEntity> Urls { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}