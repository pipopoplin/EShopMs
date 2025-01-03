﻿namespace Basket.API.Basket.GetBasket;

// public record GetBasketRequest(string UserName);
public record GetBasketResponse(ShopingCart Cart);

public class GetBasketEndPoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{userName}", async (string userName, ISender sender) =>
        {
            var result = await sender.Send(new GetBasketQuery(userName));

            var response = result.Adapt<GetBasketResponse>();

            return Results.Ok(response);
        })
        .WithName(nameof(GetBasketEndPoints))
        .Produces<GetBasketEndPoints>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get basket by username")
        .WithDescription("Get basket by username");
    }
}
