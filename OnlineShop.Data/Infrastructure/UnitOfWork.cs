namespace OnlineShop.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private OnlineShopDbContext dbContext;
        private readonly IDbFactory dbFactory;
        protected OnlineShopDbContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}