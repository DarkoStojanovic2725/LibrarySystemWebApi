using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using LibrarySystem.CQRS.Commands;
using LibrarySystem.CQRS.Queries;
using LibrarySystem.CQRS.Responses.Author;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetAuthorResponse>>> GetAuthors([FromQuery] GetAuthorsQuery request) => await _mediator.Send(request);

        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetAuthorResponse>> GetAuthor([FromQuery] GetAuthorQuery request) => await _mediator.Send(request);

        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<UpdateAuthorResponse> UpdateAuthor([FromBody] UpdateAuthorCommand command) => await _mediator.Send(command);

        [HttpPost("Insert")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AddAuthorResponse>> AddAuthor([FromBody] AddAuthorCommand request) => await _mediator.Send(request);

        [HttpDelete("DeleteById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DeleteAuthorResponse>> DeleteAuthor([FromQuery] DeleteAuthorQuery query) => await _mediator.Send(query);
    }
}
