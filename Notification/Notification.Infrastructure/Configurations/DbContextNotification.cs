using Microservice.Core.Persistence;
using Microsoft.EntityFrameworkCore;
namespace Notification.Infrastructure.Configurations;

public class DbContextNotification : BaseDbContext
{
    public DbContextNotification(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Domain.Entities.Notification> Notifications { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new NotificationConfiguration());
    }
}
