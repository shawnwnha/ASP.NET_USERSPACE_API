using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private MainContext _context;
        public UserController(MainContext context)
        {
            _context = context;
        }
        // GET api/user
        [HttpGet] 
        public IEnumerable<User> GetAll()
        {
            List<User> AllUsers = _context.users.Include(data => data.Posts).ThenInclude(data => data.Comments).ToList();
            return AllUsers;
        }
        // GET api/user/5
        [HttpGet("{id}", Name="GetById")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            User ThisUser = _context.users.SingleOrDefault(data => data.UserId == id);
            if(ThisUser == null){
                return NotFound();
            }
            return Ok(ThisUser);
        }
        // POST api/user
        [HttpPost]
        public IActionResult PostUser([FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            _context.users.Add(user);
            _context.SaveChanges();
            return CreatedAtRoute("GetById", new { id = user.UserId }, user);
        }
        // PUT api/user/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody]User user)
        {
            if (user == null || user.UserId != id)
            {
                return BadRequest();
            }

            var ThisUser = _context.users.SingleOrDefault(data => data.UserId == id);
            if (ThisUser == null)
            {
                return NotFound();
            }

            ThisUser.Name = user.Name;
            ThisUser.Email = user.Email;
            ThisUser.PhoneNumber = user.PhoneNumber;
            _context.SaveChanges();
            return NoContent();
        }
        // DELETE api/user/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ThisUser = _context.users.Find(id);
            if (ThisUser == null)
            {
                return NotFound();
            }
            _context.users.Remove(ThisUser);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
