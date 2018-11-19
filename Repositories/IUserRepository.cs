using ApiMeAjuda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMeAjuda.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        IEnumerable<User> getAll();
        User Find(int userId);
        void Remove(int userId);
        void Update(User user);
        IEnumerable<Post> GetAllPostsFromUser(int userId);
        IEnumerable<Comment> GetAllCommentsFromUser(int userId);
    }
}
