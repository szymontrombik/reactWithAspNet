using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using reactWithAspNet.Backend.Models;
using reactWithAspNet.Backend.Services;

namespace reactWithAspNet.Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReactPolicy")]
    public class UsersController : Controller
    {
        private readonly UserService userService;

        public UsersController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return userService.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(userService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] User newUser)
        {
            return CreatedAtAction("Get", new { id = newUser.Id }, userService.Create(newUser));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User updatedUser)
        {
            userService.Update(id, updatedUser);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            userService.Delete(id);
            return NoContent();
        }
    }
}
