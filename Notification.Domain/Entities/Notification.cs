using Notification.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities;

public class Notification 
{
    public long Id { get; private set; }
    public Guid UserId { get; private set; }

    public string Title { get; private set; }

    public string Message { get; private set; }

    public NotificationType Type { get; private set; }

    public NotificationStatus Status { get; private set; }

    public DateTime? SentAt { get; private set; }

    public DateTime? ReadAt { get; private set; }

    public string? Metadata { get; private set; }
}

