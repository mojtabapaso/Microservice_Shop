using Microservice.Core.Interfaces;
using Microservice.Core.Repository;
using Notification.Infrastructure.Configurations;

namespace Notification.Infrastructure.Repositories;

public class NotificationRepositoriy : GenericRepository<Domain.Entities.Notification, DbContextNotification>, IScopedDependency, INotificationRepositoriy
{
    public NotificationRepositoriy(DbContextNotification context) : base(context)
    {
    }
}
