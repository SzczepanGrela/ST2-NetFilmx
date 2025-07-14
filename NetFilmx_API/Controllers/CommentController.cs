using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetFilmx_Service.Dtos.Comment;
using NetFilmx_Service.Query.Comment;
using NetFilmx_Service.Command.Comment;
using NetFilmx_Service.Result;

namespace NetFilmx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all comments
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentListDto>>> GetAllComments()
        {
            var query = new GetAllCommentsQuery<CommentListDto>();
            var result = await _mediator.Send(query);
            
            if (result.IsFailure)
            {
                return BadRequest(new { 
                    Message = result.Message, 
                    Errors = result.Errors 
                });
            }

            return Ok(result.Data);
        }

        /// <summary>
        /// Get comment by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDetailsDto>> GetCommentById(int id)
        {
            var query = new GetCommentByIdQuery<CommentDetailsDto>(id);
            var result = await _mediator.Send(query);
            
            if (result.IsFailure)
            {
                return NotFound(new { 
                    Message = result.Message, 
                    Errors = result.Errors 
                });
            }

            return Ok(result.Data);
        }

        /// <summary>
        /// Get comments by video ID
        /// </summary>
        [HttpGet("video/{videoId}")]
        public async Task<ActionResult<IEnumerable<CommentListDto>>> GetCommentsByVideo(int videoId)
        {
            var query = new GetCommentsByVideoIdQuery<CommentListDto>(videoId);
            var result = await _mediator.Send(query);
            
            if (result.IsFailure)
            {
                return BadRequest(new { 
                    Message = result.Message, 
                    Errors = result.Errors 
                });
            }

            return Ok(result.Data);
        }

        /// <summary>
        /// Get comments by user ID
        /// </summary>
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<CommentListDto>>> GetCommentsByUser(int userId)
        {
            var query = new GetCommentsByUserIdQuery<CommentListDto>(userId);
            var result = await _mediator.Send(query);
            
            if (result.IsFailure)
            {
                return BadRequest(new { 
                    Message = result.Message, 
                    Errors = result.Errors 
                });
            }

            return Ok(result.Data);
        }

        /// <summary>
        /// Create new comment
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<int>> CreateComment([FromBody] CreateCommentRequest request)
        {
            var command = new AddCommentCommand(request.UserId, request.VideoId, request.Content);
            var result = await _mediator.Send(command);
            
            if (result.IsFailure)
            {
                return BadRequest(new { 
                    Message = result.Message, 
                    Errors = result.Errors 
                });
            }

            return CreatedAtAction(nameof(GetCommentById), new { id = ((CResultWithData)result).Data }, ((CResultWithData)result).Data);
        }

        /// <summary>
        /// Update existing comment
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateComment(int id, [FromBody] UpdateCommentRequest request)
        {
            var command = new EditCommentCommand(id, request.Content);
            var result = await _mediator.Send(command);
            
            if (result.IsFailure)
            {
                return BadRequest(new { 
                    Message = result.Message, 
                    Errors = result.Errors 
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Delete comment
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            var command = new DeleteCommentCommand(id);
            var result = await _mediator.Send(command);
            
            if (result.IsFailure)
            {
                return BadRequest(new { 
                    Message = result.Message, 
                    Errors = result.Errors 
                });
            }

            return NoContent();
        }
    }

    public class CreateCommentRequest
    {
        public int UserId { get; set; }
        public int VideoId { get; set; }
        public string Content { get; set; } = string.Empty;
    }

    public class UpdateCommentRequest
    {
        public string Content { get; set; } = string.Empty;
    }
}