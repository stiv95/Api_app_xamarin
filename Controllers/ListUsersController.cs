using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Estiven_API_Xamarin.Data;
using Estiven_API_Xamarin.Data.Models;
using Estiven_API_Xamarin.Data.Dto;
using Estiven_API_Xamarin.Services;

namespace Estiven_API_Xamarin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListUsersController : ControllerBase
    {
        private readonly Db_API_XamarinContext _context;

        private readonly IListUserService _listMastter;

        public ListUsersController(Db_API_XamarinContext context, IListUserService mastter)
        {
            _context = context;
            _listMastter = mastter;
        }

        // GET: api/ListUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListUser>>> GetListUser()
        {
          if (_context.ListUser == null)
          {
              return NotFound();
          }
            return await _context.ListUser.Include(x=>x.User).ToListAsync();
        }

        // GET: api/ListUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListUser>> GetListUser(long id)
        {
          if (_context.ListUser == null)
          {
              return NotFound();
          }
            var listUser = await _context.ListUser.FindAsync(id);

            if (listUser == null)
            {
                return NotFound();
            }

            return listUser;
        }

        // PUT: api/ListUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListUser(long id, ListUser listUser)
        {
            if (id != listUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(listUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ListUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("listUser")]
        public async Task<ActionResult<ListUser>> PostListUser(ListUserDto listUser)
        {
           ListUser listUserConv = this._listMastter.listmarket(listUser);

          if (_context.ListUser == null)
          {
              return Problem("Entity set 'Db_API_XamarinContext.ListUser'  is null.");
          }
            _context.ListUser.Add(listUserConv);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetListUser", new { id = listUserConv.Id }, listUserConv);
        }

        // DELETE: api/ListUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListUser(long id)
        {
            if (_context.ListUser == null)
            {
                return NotFound();
            }
            var listUser = await _context.ListUser.FindAsync(id);
            if (listUser == null)
            {
                return NotFound();
            }

            _context.ListUser.Remove(listUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListUserExists(long id)
        {
            return (_context.ListUser?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
