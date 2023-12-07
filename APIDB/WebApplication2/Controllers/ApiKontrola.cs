using Microsoft.AspNetCore.Mvc;
using YourNamespace.Models;
using YourNamespace.Data;

namespace YourNamespace
{
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("users")]
        public ActionResult<List<User>> GetAllUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpGet("users/{userID}")]
        public ActionResult<User> GetUserByID(int userID)
        {
            var user = _context.Users.Find(userID);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("users")]
        public ActionResult<User> AddUser(User newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Users.Add(newUser);
            _context.SaveChanges(); 

            return CreatedAtAction(nameof(GetUserByID), new { userID = newUser.ID }, newUser);
        }

        [HttpDelete("users/{userID}")]
        public ActionResult<User> DeleteUser(int userID)
        {
            var user = _context.Users.Find(userID);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return Ok(user);
        }
    }
}
