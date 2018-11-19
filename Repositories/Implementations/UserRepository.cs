using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMeAjuda.Models;
using ApiMeAjuda.Models.Context;

namespace ApiMeAjuda.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationContext;

        public UserRepository(ApplicationDbContext context)
        {
            _applicationContext = context;    
        }

        public void Add(User user)
        {
            _applicationContext.Users.Add(user);
            _applicationContext.SaveChanges();
        }

        public User Find(int id)
        {
            var user = _applicationContext.Users.FirstOrDefault(usr => usr.Id == id);
            user.Posts = _applicationContext.Posts.Where(post => post.CreatorId == user.Id).ToList();
            user.Comments = _applicationContext.Comments.Where(comment => comment.CreatorId == user.Id).ToList();
            return user;
        }

        public IEnumerable<User> getAll()
        {
            var user = _applicationContext.Users.ToList();
            return user;
        }

        public IEnumerable<Comment> GetAllCommentsFromUser(int userId)
        {
            return _applicationContext.Comments.Where(comment => comment.CreatorId == userId).ToList();
        }

        public IEnumerable<Post> GetAllPostsFromUser(int id)
        {
            return _applicationContext.Posts.Where(post => post.CreatorId == id).ToList();
        }

        public void Remove(int id)
        {
            var userToBeRemoved = _applicationContext.Users.First(usr => usr.Id == id);
            _applicationContext.Users.Remove(userToBeRemoved);
            _applicationContext.SaveChanges();
        }

        public void Update(User user)
        {
            _applicationContext.Users.Update(user);
            _applicationContext.SaveChanges();
        }
    }
}
