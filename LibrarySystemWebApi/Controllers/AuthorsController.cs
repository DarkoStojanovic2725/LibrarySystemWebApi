using System.Collections.Generic;
using System.Threading.Tasks;
using LibrarySystem.CQRS.Commands;
using LibrarySystem.CQRS.Queries;
using LibrarySystem.CQRS.Responses;
using LibrarySystemWebApi.Models;
using LibrarySystemWebApi.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ILibraryRepository _repository;
        private readonly IMediator _mediator;

        public AuthorsController(ILibraryRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return await _repository.GetListAsync<Author>();
        }

        [HttpGet("GetAuthor")]
        public async Task<ActionResult<GetAuthorResponse>> GetAuthor([FromQuery] GetAuthorQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("UpdateAuthor")]
        public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Author>> AddAuthor(Author author)
        {
            await _repository.AddAsync(author);

            return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
        }
    }
}
