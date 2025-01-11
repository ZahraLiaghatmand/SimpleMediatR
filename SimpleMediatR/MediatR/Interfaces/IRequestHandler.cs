namespace SimpleMediatR.MediatR.Interfaces
{
    //TRequest: This is a placeholder for the type of request that the handler will process.It must implement the IRequest<TResult> interface.
    //TResult: This represents the type of result that will be returned after handling the request.
    public interface IRequestHandler<TRequest, TResult> where TRequest : IRequest<TResult>
    {
        Task<TResult> Handle(TRequest request, CancellationToken cancellationToken);
    }
}