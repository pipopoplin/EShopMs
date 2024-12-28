namespace Basket.API.Models;

public class ShopingCart
{
    public string UserName { get; set; } = default!;
    public List<ShopingCartItem> Items { get; set; } = default!;

    public decimal TotalPrice => Items.Sum(i => i.Price * i.Quantity);

    public ShopingCart(string userName)
    {
        UserName = userName;
    }

    // required for mapping
    public ShopingCart()
    {
        
    }
}
