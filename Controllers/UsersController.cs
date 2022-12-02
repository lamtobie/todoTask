using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todoTask.Models;
using todoTask.BLL;

namespace todoTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _userService;

        public UsersController(TodoContext context)
        {
            _userService = new UserRepository();
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            return _userService.GetUsers();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<UserDTO> GetUser(long id)
        {
            return await _userService.GetUser(id);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<int> PutUser(long id, UserDTO user)
        {
            return await _userService.UpdateUser(id, user);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<int> PostUser(UserDTO user)
        {
           return await _userService.CreateUser(user);
         
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<int> DeleteUser(long id)
        {
            return await _userService.DeleteUser(id);
        }

   
    }
}
