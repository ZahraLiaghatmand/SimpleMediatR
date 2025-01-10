
using SimpleMediatR.Application;
using SimpleMediatR.MediatR;

SimplMediatR mediator = new();
var createOrderHandler = new CreateOrderCommandHandler();

mediator.RegisterHandlers<CreateOrderCommand, int>(createOrderHandler);

var command = new CreateOrderCommand { ProductName = "Laptop", Quantity = 1 };
int orderId = await mediator.Send<CreateOrderCommand, int>(command);