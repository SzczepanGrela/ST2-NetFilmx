using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetFilmx_Service.Command.VideoPurchase;
using NetFilmx_Service.Command.SeriesPurchase;
using NetFilmx_User.Models.ViewModels;
using NetFilmx_User.Models;
using NetFilmx_User.Services;
using System.Security.Claims;

namespace NetFilmx_User.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ICartService _cartService;
        private readonly IUserSyncService _userSyncService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CheckoutController(IMediator mediator, ICartService cartService, IUserSyncService userSyncService, UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _cartService = cartService;
            _userSyncService = userSyncService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var applicationUser = await _userManager.GetUserAsync(User);
            if (applicationUser == null)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }

            var netFilmxUserId = await _userSyncService.SyncUserAsync(applicationUser);
            var cart = await _cartService.GetCartAsync(netFilmxUserId);
            
            if (cart == null || !cart.CartItems.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            var viewModel = new CheckoutViewModel
            {
                CartItems = cart.CartItems.Select(item => new CartItemViewModel
                {
                    Id = item.Id.ToString(),
                    VideoId = item.VideoId,
                    SeriesId = item.SeriesId,
                    Title = item.Title,
                    Price = item.Price,
                    ThumbnailUrl = item.ThumbnailUrl ?? "/images/placeholder.jpg",
                    ItemType = item.ItemType
                }).ToList()
            };

            viewModel.CalculateTotals();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment(CheckoutViewModel model)
        {
            var applicationUser = await _userManager.GetUserAsync(User);
            if (applicationUser == null)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }

            var netFilmxUserId = await _userSyncService.SyncUserAsync(applicationUser);

            if (!ModelState.IsValid)
            {
                var cart = await _cartService.GetCartAsync(netFilmxUserId);
                if (cart != null)
                {
                    model.CartItems = cart.CartItems.Select(item => new CartItemViewModel
                    {
                        Id = item.Id.ToString(),
                        VideoId = item.VideoId,
                        SeriesId = item.SeriesId,
                        Title = item.Title,
                        Price = item.Price,
                        ThumbnailUrl = item.ThumbnailUrl ?? "/images/placeholder.jpg",
                        ItemType = item.ItemType
                    }).ToList();
                }
                model.CalculateTotals();
                return View("Index", model);
            }

            var userCart = await _cartService.GetCartAsync(netFilmxUserId);
            if (userCart == null || !userCart.CartItems.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            var purchaseResults = new List<bool>();

            // Process each cart item as a purchase
            foreach (var item in userCart.CartItems)
            {
                if (item.VideoId.HasValue)
                {
                    var command = new AddVideoPurchaseCommand(netFilmxUserId, item.VideoId.Value);
                    var result = await _mediator.Send(command);
                    purchaseResults.Add(result.IsSuccess);
                }
                else if (item.SeriesId.HasValue)
                {
                    var command = new AddSeriesPurchaseCommand(netFilmxUserId, item.SeriesId.Value);
                    var result = await _mediator.Send(command);
                    purchaseResults.Add(result.IsSuccess);
                }
            }

            if (purchaseResults.All(r => r))
            {
                await _cartService.ClearCartAsync(netFilmxUserId);
                return RedirectToAction("Confirmation");
            }
            else
            {
                ModelState.AddModelError("", "There was an error processing your payment. Please try again.");
                model.CartItems = userCart.CartItems.Select(item => new CartItemViewModel
                {
                    Id = item.Id.ToString(),
                    VideoId = item.VideoId,
                    SeriesId = item.SeriesId,
                    Title = item.Title,
                    Price = item.Price,
                    ThumbnailUrl = item.ThumbnailUrl ?? "/images/placeholder.jpg",
                    ItemType = item.ItemType
                }).ToList();
                model.CalculateTotals();
                return View("Index", model);
            }
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}