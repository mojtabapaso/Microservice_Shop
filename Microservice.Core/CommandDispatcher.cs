//using MediatR;
//using Order.Infrastructure.MarkerInterfaces;

//namespace Order.Application.MediatR;

//public class CommandDispatcher(IMediator mediator) : ICommandDispatcher
//{
//    public Task<TResponse> Dispatch<TResponse>(ICommand<TResponse> command)
//    {
//        return mediator.Send(command);
//    }
//}