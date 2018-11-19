using ApiMeAjuda.Models;
using ApiMeAjuda.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMeAjuda.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.getAll();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetUserById(int id)
        {
            var user = _userRepository.Find(id);
            if(user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpGet("{id}/posts")]
        public IActionResult GetUserPosts(int id)
        {
            var userPosts = _userRepository.GetAllPostsFromUser(id);
            if(userPosts == null)
            {
                return NotFound();
            }
            return new ObjectResult(userPosts);
        }

        [HttpGet("{id}/comments")]
        public IActionResult GetUserComments(int id)
        {
            var userComments = _userRepository.GetAllCommentsFromUser(id);
            if(userComments == null)
            {
                return NotFound();
            }
            return new ObjectResult(userComments);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            _userRepository.Add(user);

            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }
    }
}
