using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace ApiFragrantWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly FragrantWorldContext _context;
        private static List<User> Users = new List<User>();
        public UserController(FragrantWorldContext context)
        {
            _context = context;
            Users = _context.Users.ToList();
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return Ok(Users);
        }

        // GET: api/User/{id}
        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            var user = Users.FirstOrDefault(i => i.UserId == id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> Create(User newUser)
        {
            try
            {
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = newUser.UserId }, newUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // PUT: api/User/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, User newUser)
        {
            var user = Users.FirstOrDefault(i => i.UserId == id);
            if (user == null)
                return NotFound();

            user.UserSurname = newUser.UserSurname;
            user.UserFirstName = newUser.UserFirstName;
            user.UserPatronymic = newUser.UserPatronymic;
            user.UserLogin = newUser.UserLogin;
            user.UserPassword = newUser.UserPassword;
            user.UserRole = newUser.UserRole;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = Users.FirstOrDefault(i => i.UserId == id);
            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
