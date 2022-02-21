using OnlineShop.Data.Infrastructure;
using OnlineShop.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Data.Repository
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetAllPagingByIdPostTag(out int totalRow, string tag, int pageIndex = 0 , int pageSize = 20);
    }

    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<Post> GetAllPagingByIdPostTag(out int totalRow, string tag, int pageIndex = 0, int pageSize = 20)
        {
            var skipCount = pageIndex * pageSize;
            IQueryable<Post> query = from p in DbContext.Posts
                        join pt in DbContext.PostTags
                        on p.ID equals pt.PostID
                        where pt.TagID == tag && p.Status
                        select p;
            query = query.OrderByDescending(x => x.CreatedDate);
            query = skipCount != 0 ?  query.Skip(skipCount).Take(pageSize) : query.Take(pageSize);
            totalRow = query.Count();
            return query;
        }
    }
}