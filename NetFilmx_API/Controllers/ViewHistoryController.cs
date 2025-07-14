using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using NetFilmx_Service.Command.ViewHistory;
using NetFilmx_Service.Query.ViewHistory;
using NetFilmx_Service.Dtos.ViewHistory;
using NetFilmx_Service.Result;
using System.ComponentModel.DataAnnotations;

namespace NetFilmx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ViewHistoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ViewHistoryController> _logger;

        public ViewHistoryController(IMediator mediator, ILogger<ViewHistoryController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Get user's viewing history
        /// </summary>
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<ViewHistoryDetailsDto>>> GetUserViewHistory(int userId)
        {
            try
            {
                var query = new GetViewHistoryByUserIdQuery<ViewHistoryDetailsDto>(userId);
                var result = await _mediator.Send(query);

                if (result.IsFailure)
                {
                    return NotFound(new
                    {
                        Message = result.Message,
                        Errors = result.Errors
                    });
                }

                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting view history for user {UserId}", userId);
                return StatusCode(500, new { Message = "Internal server error" });
            }
        }

        /// <summary>
        /// Get continue watching list for user
        /// </summary>
        [HttpGet("user/{userId}/continue-watching")]
        public async Task<ActionResult<IEnumerable<ViewHistoryDetailsDto>>> GetContinueWatching(int userId)
        {
            try
            {
                var query = new GetContinueWatchingQuery<ViewHistoryDetailsDto>(userId);
                var result = await _mediator.Send(query);

                if (result.IsFailure)
                {
                    return NotFound(new
                    {
                        Message = result.Message,
                        Errors = result.Errors
                    });
                }

                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting continue watching for user {UserId}", userId);
                return StatusCode(500, new { Message = "Internal server error" });
            }
        }

        /// <summary>
        /// Record or update viewing progress
        /// </summary>
        [HttpPost("record")]
        public async Task<ActionResult> RecordViewingProgress([FromBody] RecordViewingProgressRequest request)
        {
            try
            {
                var command = new RecordViewingProgressCommand(
                    request.UserId, 
                    request.VideoId, 
                    request.ProgressSeconds, 
                    request.DurationSeconds);
                var result = await _mediator.Send(command);

                if (result.IsFailure)
                {
                    return BadRequest(new
                    {
                        Message = result.Message,
                        Errors = result.Errors
                    });
                }

                return Ok(new { Message = "Viewing progress recorded successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error recording viewing progress for user {UserId}, video {VideoId}", 
                    request.UserId, request.VideoId);
                return StatusCode(500, new { Message = "Internal server error" });
            }
        }

        /// <summary>
        /// Mark video as completed
        /// </summary>
        [HttpPost("complete")]
        public async Task<ActionResult> MarkAsCompleted([FromBody] MarkCompletedRequest request)
        {
            try
            {
                var command = new MarkVideoCompletedCommand(request.UserId, request.VideoId);
                var result = await _mediator.Send(command);

                if (result.IsFailure)
                {
                    return BadRequest(new
                    {
                        Message = result.Message,
                        Errors = result.Errors
                    });
                }

                return Ok(new { Message = "Video marked as completed" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error marking video {VideoId} as completed for user {UserId}", 
                    request.VideoId, request.UserId);
                return StatusCode(500, new { Message = "Internal server error" });
            }
        }

        /// <summary>
        /// Remove item from viewing history
        /// </summary>
        [HttpDelete("{viewHistoryId}")]
        public async Task<ActionResult> RemoveFromHistory(int viewHistoryId)
        {
            try
            {
                var command = new RemoveFromViewHistoryCommand(viewHistoryId);
                var result = await _mediator.Send(command);

                if (result.IsFailure)
                {
                    return BadRequest(new
                    {
                        Message = result.Message,
                        Errors = result.Errors
                    });
                }

                return Ok(new { Message = "Item removed from view history" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing view history item {ViewHistoryId}", viewHistoryId);
                return StatusCode(500, new { Message = "Internal server error" });
            }
        }

        /// <summary>
        /// Clear entire viewing history for user
        /// </summary>
        [HttpDelete("user/{userId}/clear")]
        public async Task<ActionResult> ClearViewHistory(int userId)
        {
            try
            {
                var command = new ClearViewHistoryCommand(userId);
                var result = await _mediator.Send(command);

                if (result.IsFailure)
                {
                    return BadRequest(new
                    {
                        Message = result.Message,
                        Errors = result.Errors
                    });
                }

                return Ok(new { Message = "View history cleared successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error clearing view history for user {UserId}", userId);
                return StatusCode(500, new { Message = "Internal server error" });
            }
        }
    }

    public class RecordViewingProgressRequest
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int VideoId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int ProgressSeconds { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int DurationSeconds { get; set; }
    }

    public class MarkCompletedRequest
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int VideoId { get; set; }
    }
}