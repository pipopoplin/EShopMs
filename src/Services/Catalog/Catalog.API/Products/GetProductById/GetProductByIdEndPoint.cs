namespace Catalog.API.Products.GetProductById;

public record GetProductByIdRequest(GetProductByIdQuery Query);

public record GetProductByIdResponce(Product Product);

public class GetProductByIdEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByIdQuery(id));

            var responce = result.Adapt<GetProductByIdResponce>();

            return Results.Ok(responce);
        })
        .WithName(nameof(GetProductByIdEndPoint))
        .Produces<GetProductByIdResponce>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get product by Id")
        .WithDescription("Get product by Id");
    }
}