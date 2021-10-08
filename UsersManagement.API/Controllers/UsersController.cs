using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersManagement.API.Fake;
using UsersManagement.API.Models;

namespace UsersManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private List<User> _users = FakeData.GetUsers(100);
        [HttpGet]
        public List<User> Get()
        {
            return _users;
        }
        [HttpGet("{id}")]
        public User GetUser(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            return user;
        }
        [HttpPost]
        public User Post([FromBody] User user)
        {
            _users.Add(user);
            return user;

        }
        [HttpPut]
        public User Put([FromBody] User user)
        {
            var editUser = _users.FirstOrDefault(x => x.Id == user.Id);
            editUser.FirstName = user.FirstName;
            editUser.LastName= user.LastName;
            editUser.Address = user.Address;
            return user;
        }
        [HttpDelete]
        public void Delete(int id)
        {
            var deleteUser = _users.FirstOrDefault(x => x.Id == id);
            _users.Remove(deleteUser);

        }

    }
}
