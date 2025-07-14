using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using NetFilmx_Service.Query.UserSettings;
using NetFilmx_Service.Command.UserSettings;
using NetFilmx_Service.Dtos.UserSettings;

namespace NetFilmx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserSettingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserSettingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Get user settings by user ID
        /// </summary>
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<UserSettingsDetailsDto>> GetUserSettings(int userId)
        {
            var query = new GetUserSettingsByUserIdQuery<UserSettingsDetailsDto>(userId);
            var result = await _mediator.Send(query);
            
            if (result.IsFailure)
            {
                // If settings don't exist, create default ones
                var createCommand = new AddUserSettingsCommand(userId);
                var createResult = await _mediator.Send(createCommand);
                
                if (createResult.IsFailure)
                {
                    return BadRequest(new { 
                        Message = createResult.Message, 
                        Errors = createResult.Errors 
                    });
                }
                
                // Get the newly created settings
                var newResult = await _mediator.Send(query);
                if (newResult.IsFailure)
                {
                    return BadRequest(new { 
                        Message = newResult.Message, 
                        Errors = newResult.Errors 
                    });
                }
                
                return Ok(newResult.Data);
            }

            return Ok(result.Data);
        }

        /// <summary>
        /// Update user settings
        /// </summary>
        [HttpPut("user/{userId}")]
        public async Task<ActionResult> UpdateUserSettings(int userId, [FromBody] UpdateUserSettingsRequest request)
        {
            var command = new EditUserSettingsCommand(
                userId,
                request.EmailNotifications,
                request.AutoplayEnabled,
                request.Theme,
                request.Language
            );
            
            var result = await _mediator.Send(command);
            
            if (result.IsFailure)
            {
                return BadRequest(new { 
                    Message = result.Message, 
                    Errors = result.Errors 
                });
            }

            return Ok(new { message = "Settings updated successfully" });
        }
    }

    public class UpdateUserSettingsRequest
    {
        public bool EmailNotifications { get; set; }
        public bool AutoplayEnabled { get; set; }
        public string Theme { get; set; } = "light";
        public string Language { get; set; } = "en";
    }
}