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
        IEnumerable<Post> GetMulti(Expression<Func<Post, bool>> predicate = null, string[] includes = null);
        IEnumerable<Post> GetAllPaging(out int total, int index = 0, int size =20);
        Post GetSingleById(int id);
        Post GetSingleByCondition(Expression<Func<Post, bool>> where = null, string[] includes = null);
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
            return _postRepository.GetAll(new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetMulti(Expression<Func<Post, bool>> predicate = null, string[] includes = null)
        {
            return _postRepository.GetMulti(predicate, includes);
        }

        public IEnumerable<Post> GetAllPaging( out int total, int index = 0, int size = 20)
        {
            return _postRepository.GetMultiPaging(x => x.Status, out total, index, size);
        }

        public Post GetSingleByCondition(Expression<Func<Post, bool>> where = null, string[] includes = null)
        {
            throw new NotImplementedException();
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
    }
}