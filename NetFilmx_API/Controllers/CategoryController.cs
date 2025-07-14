using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetFilmx_Service.Dtos.Category;
using NetFilmx_Service.Query.Category;
using NetFilmx_Service.Command.Category;
using NetFilmx_Service.Result;

namespace NetFilmx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryListDto>>> GetAllCategories()
        {
            var query = new GetAllCategoriesQuery<CategoryListDto>();
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
        /// Get category by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDetailsDto>> GetCategoryById(int id)
        {
            var query = new GetCategoryByIdQuery<CategoryDetailsDto>(id);
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
        /// Get category by name
        /// </summary>
        [HttpGet("name/{name}")]
        public async Task<ActionResult<CategoryDetailsDto>> GetCategoryByName(string name)
        {
            var query = new GetCategoryByNameQuery<CategoryDetailsDto>(name);
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
        /// Get categories by video ID
        /// </summary>
        [HttpGet("video/{videoId}")]
        public async Task<ActionResult<IEnumerable<CategoryListDto>>> GetCategoriesByVideo(int videoId)
        {
            var query = new GetCategoriesByVideoIdQuery<CategoryListDto>(videoId);
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
        /// Create new category
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<int>> CreateCategory([FromBody] CreateCategoryRequest request)
        {
            var command = new AddCategoryCommand(request.Name, request.Description);
            var result = await _mediator.Send(command);
            
            if (result.IsFailure)
            {
                return BadRequest(new { 
                    Message = result.Message, 
                    Errors = result.Errors 
                });
            }

            return CreatedAtAction(nameof(GetCategoryById), new { id = ((CResultWithData)result).Data }, ((CResultWithData)result).Data);
        }

        /// <summary>
        /// Update existing category
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryRequest request)
        {
            var command = new EditCategoryCommand(id, request.Name, request.Description);
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
        /// Delete category
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var command = new DeleteCategoryCommand(id);
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

    public class CreateCategoryRequest
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    public class UpdateCategoryRequest
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}