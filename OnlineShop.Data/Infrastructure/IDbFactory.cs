namespace OnlineShop.Data.Infrastructure
{
    public interface IDbFactory
    {
        OnlineShopDbContext Init();
    }
}