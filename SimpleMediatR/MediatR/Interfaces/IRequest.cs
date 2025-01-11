namespace SimpleMediatR.MediatR.Interfaces
{
    //TResult is a placeholder for the type that the request will return when processed.
    //This design allows flexibility, enabling the IRequest interface to handle various return types without knowing them in advance.
    public interface IRequest<TResult>
    {
    }
}
