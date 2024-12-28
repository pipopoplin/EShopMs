namespace Basket.API.Basket.StoreBasket;

public record StoreBasketRequest(ShopingCart Cart);

public record StoreBasketResponse(string UserName);

public class StoreBasketEndPoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket", async (StoreBasketRequest request, ISender sender) =>
        {
            var command = request.Adapt<StoreBasketCommand>();

            var result = await sender.Send(command);

            var responce = result.Adapt<StoreBasketResponse>();

            return Results.Created($"/basket/{responce.UserName}", responce);
        })
        .WithName("StoreBasket")
        .Produces<StoreBasketEndPoints>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Store Basket")
        .WithDescription("Store Basket");
    }
}