namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryRequest(GetProductByCategoryQuery Query);

public record GetProductByCategoryResponce(IEnumerable<Product> Products);

public class GetProductByCategoryEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByCategoryQuery(category));

            var responce = result.Adapt<GetProductByCategoryResponce>();

            return Results.Ok(responce);
        })
        .WithName(nameof(GetProductByCategoryEndPoint))
        .Produces<GetProductByCategoryResponce>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get product by Category")
        .WithDescription("Get product by Category");
    }
}