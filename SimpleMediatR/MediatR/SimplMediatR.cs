using SimpleMediatR.MediatR.Interfaces;

namespace SimpleMediatR.MediatR
{
    public class SimplMediatR
    {
        private readonly Dictionary<Type, Object> _handlers = new();
        public void RegisterHandlers<TRequest, TResult>(IRequestHandler<TRequest, TResult> handler)
            where TRequest : IRequest<TResult>
        {
            _handlers[typeof(TRequest)] = handler;
        }
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
