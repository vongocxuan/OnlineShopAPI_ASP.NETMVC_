using OnlineShop.Data.Infrastructure;
using OnlineShop.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Data.Repository
{
    public interface IPostTagRepository : IRepository<PostTag>
    {
    }

    public class PostTagRepository : RepositoryBase<PostTag>, IPostTagRepository
    {
        public PostTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}