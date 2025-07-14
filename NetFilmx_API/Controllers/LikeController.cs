using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetFilmx_Service.Query.Like;
using NetFilmx_Service.Command.Like;

namespace NetFilmx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LikeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LikeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get likes count by video ID
        /// </summary>
        [HttpGet("video/{videoId}/count")]
        public async Task<ActionResult<int>> GetLikesCountByVideo(int videoId)
        {
            var query = new GetLikesCountByVideoIdQuery(videoId);
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
        /// Add like to video
        /// </summary>
        [HttpPost("video/{videoId}/user/{userId}")]
        public async Task<ActionResult> AddLike(int videoId, int userId)
        {
            var command = new AddLikeCommand(userId, videoId);
            var result = await _mediator.Send(command);
            
            if (result.IsFailure)
            {
                return BadRequest(new { 
                    Message = result.Message, 
                    Errors = result.Errors 
                });
            }

            return Ok(new { message = "Like added successfully" });
        }

        /// <summary>
        /// Remove like from video
        /// </summary>
        [HttpDelete("video/{videoId}/user/{userId}")]
        public async Task<ActionResult> RemoveLike(int videoId, int userId)
        {
            var command = new DeleteLikeCommand(userId, videoId);
            var result = await _mediator.Send(command);
            
            if (result.IsFailure)
            {
                return BadRequest(new { 
                    Message = result.Message, 
                    Errors = result.Errors 
                });
            }

            return Ok(new { message = "Like removed successfully" });
        }
    }
}