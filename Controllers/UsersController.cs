using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloAspNetCore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloAspNetCore.Controllers
{
    [Route("[controller]")]
    //[Route("MyApp/MyUsers/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IEnumerable<User> users;

        public UsersController()
        {
            users = GenerateDemoList().ToList();
        }

        private IEnumerable<User> GenerateDemoList()
        {
            List<User> users = new List<User>();
            users.Add(new User() { Id = 1001, Name = "Alfred", Grade = 80 });
            users.Add(new User() { Id = 1002, Name = "Batty", Grade = 85 });
            users.Add(new User() { Id = 1003, Name = "Charls", Grade = 90 });
            users.Add(new User() { Id = 1004, Name = "Anton", Grade = 95 });
            users.Add(new User() { Id = 1005, Name = "Bob", Grade = 100 });
            return users;
        }



        [HttpGet]
        public IEnumerable<User> Get()
        {
            //return new string[] { "value1", "value2" };
            return users;
        }

        [HttpGet]
        [Route("{id}")]
        public User GetUser(int id)
        {
            //return new string[] { "value1", "value2" };
            return users.FirstOrDefault(u=> u.Id == id);
        }

        [HttpGet]
        [Route("findByName/{name}")]
        public List<User> GetUsersByName(string name)
        {
            return users.Where(u => u.Name.StartsWith(name)).ToList();
        }


       [HttpGet]
       [Route("hello")]
        public string SayHello()
        {
            return "hello world";
        }

        [HttpPost]
        public IEnumerable<User> AddUser([FromBody] User user)
        {
            // just for stupid demo ...
            // do not use as is...
            // please... 
            var newUser = new User() { Id = user.Id, Name = user.Name, Grade = user.Grade };
            var newList = users.ToList();
            newList.Add(newUser); 
            
            //
            //
            //
            // just for demo....
            return newList;
        }

        [HttpPut("{id}")]
        public User Put(int id, [FromBody] User user)
        {
            if (id != user.Id)
                throw new ArgumentException("mishmash user....");
            return user;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
