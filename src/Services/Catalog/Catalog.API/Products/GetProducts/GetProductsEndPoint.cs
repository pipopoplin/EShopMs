namespace Catalog.API.Products.GetProducts;

// public record CreateProductRequest();

public record GetProductResponce(IEnumerable<Product> Products);

public class GetProductsEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
        {
           var result = await sender.Send(new GetProductsQuery());

            var responce = result.Adapt<GetProductResponce>();

            return Results.Ok(responce);
        })
        .WithName("GetProduct")
        .Produces<GetProductResponce>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product")
        .WithDescription("Get Product");
    }
}
