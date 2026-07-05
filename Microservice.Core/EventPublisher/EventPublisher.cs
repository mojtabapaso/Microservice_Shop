using MassTransit;
using Microservice.Core.Interfaces;

namespace Microservice.Core.EventPublisher;

public class EventPublisher(IPublishEndpoint publishEndpoint) : IScopedDependency, IEventPublisher
{
    public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : IEvent
    {
        await publishEndpoint.Publish(@event, cancellationToken);
    }
}
public interface IEventContext
{
    void Add(IEvent @event);

    IReadOnlyCollection<IEvent> Events { get; }

    void Clear();
}
public sealed class EventContext : IScopedDependency, IEventContext
{
    private readonly List<IEvent> _events = [];

    public IReadOnlyCollection<IEvent> Events => _events;

    public void Add(IEvent @event)
        => _events.Add(@event);

    public void Clear()
        => _events.Clear();
}