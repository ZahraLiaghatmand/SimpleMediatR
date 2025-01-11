using SimpleMediatR.MediatR.Interfaces;

namespace SimpleMediatR.MediatR
{
    public class SimplMediatR
    {
        //Dictionary<Type, object> represents a key-value pair collection:
        //Type: The key is the type of the request or command(TRequest). This allows the mediator to look up handlers dynamically based on the type of request being sent.
        //object: The value is a generic object representing the registered handler.Since the handlers are of various types(IRequestHandler<TRequest, TResult>), they are stored as object to maintain flexibility.
        //Why Use This Design?
        //Flexibility: The mediator doesn't need to know the exact types at compile time, enabling it to manage any command or request type dynamically.
        //Generic Lookup: The Send method uses typeof(TRequest) as a key to retrieve and cast the corresponding handler from _handlers.
        //This approach encapsulates the core of the Mediator pattern, decoupling requests from their handling logic by using type-based routing.
        private readonly Dictionary<Type, Object> _handlers = new();
        ////TRequest: Represents the type of request or command being handled. It must implement the IRequest<TResult> interface.
        //TResult: Represents the type of result returned by processing the request.
        //The method RegisterHandler allows registering any handler that processes a request of type TRequest and returns a result of type TResult. Using generics enables:
        //Type safety: Ensuring only handlers compatible with a specific request type are registered.
        //Flexibility: The same method can be used for various request and response types without needing separate methods for each combination.
        public void RegisterHandlers<TRequest, TResult>(IRequestHandler<TRequest, TResult> handler)
            where TRequest : IRequest<TResult>
        {
            _handlers[typeof(TRequest)] = handler;
        }
        //default: The keyword default initializes CancellationToken with its default value,
        //which is an empty, non-cancelable token (CancellationToken.None).
        public async Task<TResult> Send<TRequest, TResult>(TRequest request, CancellationToken cancellationToken = default)
            where TRequest : IRequest<TResult>
        {
            if (_handlers.TryGetValue(typeof(TRequest), out var handlerObj)
                && handlerObj is IRequestHandler<TRequest, TResult> handler)
            {
                return await handler.Handle(request, cancellationToken);
            }
            throw new InvalidOperationException("No handler registered for this request.");

        }
    }
}
