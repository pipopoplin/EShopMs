namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShopingCart Cart) : ICommand<StoreBasketResult>;
public record StoreBasketResult(string UserName);

public class StoreBasketCommandValidiator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidiator()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null");
        RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("Cart.UserName is required");
    }
}

public class StoreBasketCommandHandler() : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        ShopingCart cart = command.Cart;

        return new StoreBasketResult("Test");
    }
}
