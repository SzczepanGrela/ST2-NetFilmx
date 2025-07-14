using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetFilmx_Service.Dtos.Series;
using NetFilmx_Service.Query.Series;
using NetFilmx_Service.Command.Series;
using NetFilmx_Service.Result;

namespace NetFilmx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SeriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SeriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all series
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeriesListDto>>> GetAllSeries()
        {
            var query = new GetAllSeriesQuery<SeriesListDto>();
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
        /// Get series by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<SeriesDetailsDto>> GetSeriesById(int id)
        {
            var query = new GetSeriesByIdQuery<SeriesDetailsDto>(id);
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
        /// Get series by name
        /// </summary>
        [HttpGet("name/{name}")]
        public async Task<ActionResult<SeriesDetailsDto>> GetSeriesByName(string name)
        {
            var query = new GetSeriesByNameQuery<SeriesDetailsDto>(name);
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
        /// Get series by video ID
        /// </summary>
        [HttpGet("video/{videoId}")]
        public async Task<ActionResult<IEnumerable<SeriesListDto>>> GetSeriesByVideo(int videoId)
        {
            var query = new GetSeriesByVideoIdQuery<SeriesListDto>(videoId);
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
        /// Create new series
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<int>> CreateSeries([FromBody] CreateSeriesRequest request)
        {
            var command = new AddSeriesCommand(request.Name, request.Description, request.Price);
            var result = await _mediator.Send(command);
            
            if (result.IsFailure)
            {
                return BadRequest(new { 
                    Message = result.Message, 
                    Errors = result.Errors 
                });
            }

            return CreatedAtAction(nameof(GetSeriesById), new { id = ((CResultWithData)result).Data }, ((CResultWithData)result).Data);
        }

        /// <summary>
        /// Update existing series
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSeries(int id, [FromBody] UpdateSeriesRequest request)
        {
            var command = new EditSeriesCommand(id, request.Name, request.Description, request.Price);
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
        /// Delete series
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSeries(int id)
        {
            var command = new DeleteSeriesCommand(id);
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

    public class CreateSeriesRequest
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }

    public class UpdateSeriesRequest
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}