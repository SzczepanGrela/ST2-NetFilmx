using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using NetFilmx_Service.Dtos.Video;
using NetFilmx_Service.Dtos.Series;
using NetFilmx_Service.Query.Video;
using NetFilmx_Service.Query.Series;
using NetFilmx_User.Models.ViewModels;
using NetFilmx_User.Models;
using NetFilmx_User.Services;

namespace NetFilmx_User.Controllers
{
    public class CartController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ICartService _cartService;
        private readonly IUserSyncService _userSyncService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(IMediator mediator, ICartService cartService, IUserSyncService userSyncService, UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _cartService = cartService;
            _userSyncService = userSyncService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Login", "Account", new { area = "Identity" });
                }

                // Get current user and sync
                var applicationUser = await _userManager.GetUserAsync(User);
                if (applicationUser == null)
                {
                    return RedirectToAction("Login", "Account", new { area = "Identity" });
                }

                var netFilmxUserId = await _userSyncService.SyncUserAsync(applicationUser);

                // Get cart from database
                var cart = await _cartService.GetCartAsync(netFilmxUserId);
                var viewModel = new CartViewModel
                {
                    Items = new List<CartItemViewModel>()
                };

                if (cart != null)
                {
                    foreach (var item in cart.CartItems)
                    {
                        viewModel.Items.Add(new CartItemViewModel
                        {
                            Id = item.Id.ToString(),
                            VideoId = item.VideoId,
                            SeriesId = item.SeriesId,
                            Title = item.Title,
                            Price = item.Price,
                            ThumbnailUrl = item.ThumbnailUrl ?? "/images/placeholder.jpg",
                            ItemType = item.ItemType
                        });
                    }
                }

                viewModel.CalculateTotals();
                return View(viewModel);
            }
            catch (Exception ex)
            {
                // Log the error and redirect to error page
                Console.WriteLine($"Error in Cart Index: {ex.Message}");
                return RedirectToAction("Error", "Home", new { 
                    errorMessage = "There was an error loading your cart. Please try again.",
                    errors = new List<string> { ex.Message }
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddVideo(int videoId)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return Json(new { success = false, message = "Please login first" });
                }

                var applicationUser = await _userManager.GetUserAsync(User);
                if (applicationUser == null)
                {
                    return Json(new { success = false, message = "User not found" });
                }

                var netFilmxUserId = await _userSyncService.SyncUserAsync(applicationUser);
                var result = await _cartService.AddVideoAsync(netFilmxUserId, videoId);

                return Json(new { success = result, message = result ? "Video added to cart" : "Failed to add video to cart" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSeries(int seriesId)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return Json(new { success = false, message = "Please login first" });
                }

                var applicationUser = await _userManager.GetUserAsync(User);
                if (applicationUser == null)
                {
                    return Json(new { success = false, message = "User not found" });
                }

                var netFilmxUserId = await _userSyncService.SyncUserAsync(applicationUser);
                var result = await _cartService.AddSeriesAsync(netFilmxUserId, seriesId);

                return Json(new { success = result, message = result ? "Series added to cart" : "Failed to add series to cart" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveItem(int itemId)
        {
            try
            {
                var result = await _cartService.RemoveItemAsync(itemId);
                return Json(new { success = result, message = result ? "Item removed from cart" : "Failed to remove item from cart" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Clear()
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return Json(new { success = false, message = "Please login first" });
                }

                var applicationUser = await _userManager.GetUserAsync(User);
                if (applicationUser == null)
                {
                    return Json(new { success = false, message = "User not found" });
                }

                var netFilmxUserId = await _userSyncService.SyncUserAsync(applicationUser);
                var result = await _cartService.ClearCartAsync(netFilmxUserId);

                return Json(new { success = result, message = result ? "Cart cleared" : "Failed to clear cart" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error: {ex.Message}" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCartCount()
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return Json(new { count = 0 });
                }

                var applicationUser = await _userManager.GetUserAsync(User);
                if (applicationUser == null)
                {
                    return Json(new { count = 0 });
                }

                var netFilmxUserId = await _userSyncService.SyncUserAsync(applicationUser);
                var count = await _cartService.GetItemCountAsync(netFilmxUserId);

                return Json(new { count });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting cart count: {ex.Message}");
                return Json(new { count = 0 });
            }
        }
    }
}