﻿namespace Basket.API.Data;

public interface IBasketRepository
{
    Task<ShopingCart> GetBasket(string userName, CancellationToken cancellationToken = default);
    Task<ShopingCart> StoreBasket(ShopingCart basket, CancellationToken cancellationToken = default);
    Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default);
}
