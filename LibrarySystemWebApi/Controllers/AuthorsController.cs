using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using LibrarySystemWebApi.Models;
using LibrarySystemWebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ILibraryRepository _repository;

        public AuthorsController(ILibraryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return await _repository.GetListAsync<Author>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _repository.GetFirstAsync<Author>(t => t.Id == id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            try
            {
                await _repository.UpdateAsync(author);
            }
            catch (DbUpdateException exception)
            {
                if (!await _repository.AnyAsync<Author>(t => t.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    Debug.WriteLine(exception);
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Author>> AddAuthor(Author author)
        {
            await _repository.AddAsync(author);

            return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
        }
    }
}
