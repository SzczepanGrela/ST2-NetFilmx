using Microsoft.AspNetCore.Mvc;
using MediatR;
using NetFilmx_API.Services;
using NetFilmx_Service.Command.User;
using NetFilmx_Service.Query.User;
using NetFilmx_Service.Dtos.User;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;
using System.ComponentModel.DataAnnotations;

namespace NetFilmx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AuthController> _logger;
        private readonly IJwtService _jwtService;
        private readonly IUserRepository _userRepository;

        public AuthController(IMediator mediator, ILogger<AuthController> logger, IJwtService jwtService, IUserRepository userRepository)
        {
            _mediator = mediator;
            _logger = logger;
            _jwtService = jwtService;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                var command = new AddUserCommand(request.Username, request.Email, request.Password);
                var result = await _mediator.Send(command);

                if (result.IsFailure)
                {
                    return BadRequest(new
                    {
                        Message = result.Message,
                        Errors = result.Errors
                    });
                }

                return Ok(new
                {
                    Message = "User registered successfully",
                    UserId = ((CResultWithData)result).Data
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during user registration");
                return StatusCode(500, new { Message = "Internal server error during registration" });
            }
        }

        /// <summary>
        /// Authenticate user credentials
        /// </summary>
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                // Get user by username
                var userQuery = new GetUserByUsernameQuery<UserDetailsDto>(request.Username);
                var userResult = await _mediator.Send(userQuery);

                if (userResult.IsFailure)
                {
                    return Unauthorized(new { Message = "Invalid username or password" });
                }

                var user = userResult.Data;
                if (user == null)
                {
                    return Unauthorized(new { Message = "Invalid username or password" });
                }

                // Get full user entity for password verification
                var userEntity = await _userRepository.GetUserByUsernameAsync(request.Username);
                if (userEntity == null || !userEntity.VerifyPassword(request.Password))
                {
                    return Unauthorized(new { Message = "Invalid username or password" });
                }

                // Generate JWT token
                var token = _jwtService.GenerateToken(user);
                
                return Ok(new
                {
                    Message = "Login successful",
                    User = new
                    {
                        user.Id,
                        user.Username,
                        user.Email
                    },
                    Token = token,
                    ExpiresIn = DateTime.UtcNow.AddMinutes(60)
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during user login");
                return StatusCode(500, new { Message = "Internal server error during login" });
            }
        }

        /// <summary>
        /// Check if username is available
        /// </summary>
        [HttpGet("check-username/{username}")]
        public async Task<ActionResult> CheckUsername(string username)
        {
            try
            {
                var query = new IsUsernameAvailableQuery(username);
                var result = await _mediator.Send(query);

                if (result.IsFailure)
                {
                    return BadRequest(new
                    {
                        Message = result.Message,
                        Errors = result.Errors
                    });
                }

                return Ok(new
                {
                    Username = username,
                    IsAvailable = result.Data
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking username availability");
                return StatusCode(500, new { Message = "Internal server error" });
            }
        }

        /// <summary>
        /// Get current user profile
        /// </summary>
        [HttpGet("profile/{userId}")]
        public async Task<ActionResult<UserDetailsDto>> GetProfile(int userId)
        {
            try
            {
                var query = new GetUserByIdQuery<UserDetailsDto>(userId);
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
                _logger.LogError(ex, "Error getting user profile");
                return StatusCode(500, new { Message = "Internal server error" });
            }
        }

        /// <summary>
        /// Update user profile
        /// </summary>
        [HttpPut("profile/{userId}")]
        public async Task<ActionResult> UpdateProfile(int userId, [FromBody] UpdateProfileRequest request)
        {
            try
            {
                var command = new EditUserCommand(userId, request.Username, request.Email);
                var result = await _mediator.Send(command);

                if (result.IsFailure)
                {
                    return BadRequest(new
                    {
                        Message = result.Message,
                        Errors = result.Errors
                    });
                }

                return Ok(new { Message = "Profile updated successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user profile");
                return StatusCode(500, new { Message = "Internal server error" });
            }
        }
    }

    public class RegisterRequest
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;
    }

    public class LoginRequest
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }

    public class UpdateProfileRequest
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
    }
}