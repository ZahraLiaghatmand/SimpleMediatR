using SimpleMediatR.MediatR.Interfaces;

namespace SimpleMediatR.Application
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        public Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            int orderId = new Random().Next(1, 1000);
            Console.WriteLine($"Order Created: {request.ProductName}, Quantity: {request.Quantity}, OrderId: {orderId}");
            return Task.FromResult(orderId);
        }
    }
}
