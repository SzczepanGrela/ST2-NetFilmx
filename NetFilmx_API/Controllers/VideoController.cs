using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetFilmx_Service.Dtos.Video;
using NetFilmx_Service.Query.Video;
using NetFilmx_Service.Command.Video;
using NetFilmx_Service.Result;

namespace NetFilmx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class VideoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VideoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all videos
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoListDto>>> GetAllVideos()
        {
            var query = new GetAllVideosQuery<VideoListDto>();
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
        /// Get video by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<VideoDetailsDto>> GetVideoById(int id)
        {
            var query = new GetVideoByIdQuery<VideoDetailsDto>(id);
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
        /// Get videos by category ID
        /// </summary>
        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<VideoListDto>>> GetVideosByCategory(int categoryId)
        {
            var query = new GetVideosByCategoryIdQuery<VideoListDto>(categoryId);
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
        /// Get videos by series ID
        /// </summary>
        [HttpGet("series/{seriesId}")]
        public async Task<ActionResult<IEnumerable<VideoListDto>>> GetVideosBySeries(int seriesId)
        {
            var query = new GetVideosBySeriesIdQuery<VideoListDto>(seriesId);
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
        /// Get videos by tag ID
        /// </summary>
        [HttpGet("tag/{tagId}")]
        public async Task<ActionResult<IEnumerable<VideoListDto>>> GetVideosByTag(int tagId)
        {
            var query = new GetVideosByTagIdQuery<VideoListDto>(tagId);
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
        /// Create new video
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<int>> CreateVideo([FromBody] CreateVideoRequest request)
        {
            var command = new AddVideoCommand(
                request.Title,
                request.Description,
                request.Price,
                request.VideoUrl,
                request.ThumbnailUrl
            );
            
            var result = await _mediator.Send(command);
            
            if (result.IsFailure)
            {
                return BadRequest(new { 
                    Message = result.Message, 
                    Errors = result.Errors 
                });
            }

            return CreatedAtAction(nameof(GetVideoById), new { id = ((CResultWithData)result).Data }, ((CResultWithData)result).Data);
        }

        /// <summary>
        /// Update existing video
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVideo(int id, [FromBody] UpdateVideoRequest request)
        {
            var command = new EditVideoCommand(
                id,
                request.Title,
                request.Description,
                request.Price,
                request.VideoUrl,
                request.ThumbnailUrl
            );
            
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
        /// Delete video
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVideo(int id)
        {
            var command = new DeleteVideoCommand(id);
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

    public class CreateVideoRequest
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string VideoUrl { get; set; } = string.Empty;
        public string? ThumbnailUrl { get; set; }
    }

    public class UpdateVideoRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string VideoUrl { get; set; } = string.Empty;
        public string ThumbnailUrl { get; set; } = string.Empty;
    }
}