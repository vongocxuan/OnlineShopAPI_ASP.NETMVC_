using OnlineShop.Data.Infrastructure;
using OnlineShop.Data.Repository;
using OnlineShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnlineShop.Service
{
    public interface IPostSErvice
    {
        Post Add(Post post);
        void Update(Post post);
        Post Delete(int id);
        Post Delete(Post post);
        void DeleteMulti(Expression<Func<Post, bool>> where);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetMulti(Expression<Func<Post, bool>> predicate = null);
        IEnumerable<Post> GetAllPaging(out int total, int index = 0, int size =20);
        IEnumerable<Post> GetAllPagingByIdPostTag(out int total, string tag, int index = 0, int size = 20);
        IEnumerable<Post> GetAllPagingByIdPostCategory(out int total, int id, int index = 0, int size = 20);
        Post GetSingleById(int id);
        void SaveChanges();
    }
    public class PostService : IPostSErvice
    {
        IPostRepository _postRepository;
        IUnitOfWork _unitOfWork;
        public PostService(IPostRepository postRepository,  IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
        }
        public Post Add(Post post)
        {
            return _postRepository.Add(post);
        }

        public Post Delete(int id)
        {
            return _postRepository.Delete(id);
        }

        public Post Delete(Post post)
        {
            return _postRepository.Delete(post);
        }

        public void DeleteMulti(Expression<Func<Post, bool>> where)
        {
            _postRepository.DeleteMulti(where);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll();
        }

        public IEnumerable<Post> GetMulti(Expression<Func<Post, bool>> predicate = null)
        {
            return _postRepository.GetMulti(predicate, new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllPaging( out int total, int index = 0, int size = 20)
        {
            return _postRepository.GetMultiPaging(x => x.Status, out total, index, size);
        }

        public Post GetSingleById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }

        public IEnumerable<Post> GetAllPagingByIdPostTag(out int total, string tag, int index = 0, int size = 20)
        {
            return _postRepository.GetAllPagingByIdPostTag(out total, tag, index, size);
        }

        public IEnumerable<Post> GetAllPagingByIdPostCategory(out int total, int id, int index = 0, int size = 20 )
        {
            return _postRepository.GetMultiPaging(x => x.Status && x.PostCategory.ID == id, out total, index, size, new string[] { "PostCategory" });
        }
    }
}