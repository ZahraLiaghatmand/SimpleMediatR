using SimpleMediatR.MediatR.Interfaces;

namespace SimpleMediatR.Application
{
    public class CreateOrderCommand : IRequest<int>
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
