using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using TodoApi.Data;

namespace TodoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly TodoApiContext _context;

        public BlogController(TodoApiContext context)
        {
            _context = context;
        }

        // GET: api/Blog
        /// <summary>
        /// Gebe mir eine Liste von Blogs zurück
        /// </summary>
        /// <returns>IEnumerable Blog </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlog()
        {
            return await _context.Blog.ToListAsync();
        }

        // GET: api/Blog/5

        /// <summary>
        /// Lese Blog-Entity aus
        /// </summary>
        /// <param name="id">Blog.Id</param>
        /// <returns>Blog</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(int id)
        {
            var blog = await _context.Blog.FindAsync(id);

            if (blog == null)
            {
                return NotFound();
            }

            return blog;
        }

        // PUT: api/Blog/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// LaLeLu
        /// </summary>
        /// <param name="id">Blog Id</param>
        /// <param name="blog">asdasdfasdf</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlog(int id, Blog blog)
        {
            if (id != blog.Id)
            {
                return BadRequest();
            }

            _context.Entry(blog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(id))
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





        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Blog
        ///     {
        ///        "id": 1,
        ///        "name": "Blog1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>

        // POST: api/Blog
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Blog>> PostBlog(Blog blog)
        {
            _context.Blog.Add(blog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlog", new { id = blog.Id }, blog);
        }

        // DELETE: api/Blog/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Blog>> DeleteBlog(int id)
        {
            var blog = await _context.Blog.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            _context.Blog.Remove(blog);
            await _context.SaveChangesAsync();

            return blog;
        }

        private bool BlogExists(int id)
        {
            return _context.Blog.Any(e => e.Id == id);
        }
    }
}
