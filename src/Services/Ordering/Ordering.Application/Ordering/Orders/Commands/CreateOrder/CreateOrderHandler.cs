
namespace Ordering.Application.Ordering.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler :
    ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
