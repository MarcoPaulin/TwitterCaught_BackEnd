namespace BackEnd
{
    using BackEnd.Model;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Xml;

    [ApiController]
    [Route("[controller]")]
    public class DBController : ControllerBase
    {
        private readonly ConnectionDB _context;

        public DBController(ConnectionDB context)
        {
            _context = context;
        }
         /*
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> Get()
        {
            return await _context.users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> Get(int id)
        {
            var myEntity = await _context.users.FindAsync(id);

            if (myEntity == null)
            {
                return NotFound();
            }

            return myEntity;
        }

        [HttpPost]
        public async Task<ActionResult<Users>> Post(Users newuser)
        {
            _context.users.Add(newuser);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), newuser);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteuser = await _context.users.FindAsync(id);

            if (deleteuser == null)
            {
                return NotFound();
            }

            _context.users.Remove(deleteuser);
            await _context.SaveChangesAsync();

            return NoContent();
        }*/
    }
}
