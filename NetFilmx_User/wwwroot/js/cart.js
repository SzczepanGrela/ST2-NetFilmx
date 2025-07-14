// Shopping Cart JavaScript for NetFilmx

$(document).ready(function() {
    updateCartDisplay();
    
    // Update cart display every 30 seconds
    setInterval(updateCartDisplay, 30000);
});

// Add item to cart
function addToCart(itemId, itemType) {
    const url = itemType === 'video' ? '/Cart/AddVideo' : '/Cart/AddSeries';
    
    $.ajax({
        url: url,
        type: 'POST',
        data: itemType === 'video' ? { videoId: itemId } : { seriesId: itemId },
        headers: {
            'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()
        },
        success: function(response) {
            if (response.success) {
                showNotification(response.message, 'success');
                updateCartDisplay();
            } else {
                showNotification('Failed to add item to cart', 'error');
            }
        },
        error: function() {
            showNotification('Error adding item to cart', 'error');
        }
    });
}

// Remove item from cart
function removeFromCart(itemId) {
    $.ajax({
        url: '/Cart/RemoveItem',
        type: 'POST',
        data: { itemId: itemId },
        headers: {
            'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()
        },
        success: function(response) {
            if (response.success) {
                showNotification(response.message, 'success');
                updateCartDisplay();
                // If on cart page, refresh the page
                if (window.location.pathname.includes('/Cart')) {
                    window.location.reload();
                }
            } else {
                showNotification('Failed to remove item from cart', 'error');
            }
        },
        error: function() {
            showNotification('Error removing item from cart', 'error');
        }
    });
}

// Update cart display in header
function updateCartDisplay() {
    $.ajax({
        url: '/Cart/GetCartCount',
        type: 'GET',
        success: function(response) {
            const cartBadge = $('.cart-count');
            if (response.count > 0) {
                cartBadge.text(response.count).show();
            } else {
                cartBadge.hide();
            }
        },
        error: function() {
            console.error('Failed to update cart display');
        }
    });
}

// Show notification
function showNotification(message, type) {
    const alertClass = type === 'success' ? 'alert-success' : 'alert-danger';
    const icon = type === 'success' ? 'fa-check-circle' : 'fa-exclamation-circle';
    
    const notification = `
        <div class="alert ${alertClass} alert-dismissible fade show position-fixed" 
             style="top: 90px; right: 20px; z-index: 9999; min-width: 300px;" role="alert">
            <i class="fas ${icon} me-2"></i>${message}
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    `;
    
    $('body').append(notification);
    
    // Auto-hide after 3 seconds
    setTimeout(function() {
        $('.alert').fadeOut(function() {
            $(this).remove();
        });
    }, 3000);
}

// Cart dropdown functionality
$('#cartDropdown').on('click', function(e) {
    e.preventDefault();
    loadCartPreview();
});

// Load cart preview for dropdown
function loadCartPreview() {
    // This would load a simplified cart view for the dropdown
    // For now, just show a message
    const cartItems = $('#cartItems');
    cartItems.html('<div class="text-center"><i class="fas fa-spinner fa-spin"></i> Loading...</div>');
    
    // Simulate loading cart items
    setTimeout(function() {
        cartItems.html(`
            <div class="d-flex justify-content-between align-items-center mb-2">
                <small class="text-muted">Cart items will appear here</small>
            </div>
        `);
    }, 500);
}

// Add to favorites (placeholder)
function addToFavorites(itemId, itemType) {
    showNotification(`Added to favorites (${itemType}: ${itemId})`, 'success');
}

// Like/unlike functionality (placeholder)
function toggleLike(itemId, itemType) {
    showNotification(`Liked ${itemType}: ${itemId}`, 'success');
}

// Search autocomplete
function initializeSearchAutocomplete() {
    $('#searchInput').on('input', function() {
        const term = $(this).val();
        if (term.length >= 2) {
            $.ajax({
                url: '/Search/Autocomplete',
                type: 'GET',
                data: { term: term },
                success: function(suggestions) {
                    displaySearchSuggestions(suggestions);
                }
            });
        } else {
            hideSearchSuggestions();
        }
    });
}

function displaySearchSuggestions(suggestions) {
    let suggestionsHtml = '';
    suggestions.forEach(function(suggestion) {
        suggestionsHtml += `<div class="search-suggestion">${suggestion}</div>`;
    });
    
    if (!$('#searchSuggestions').length) {
        $('#searchInput').after('<div id="searchSuggestions" class="search-suggestions"></div>');
    }
    
    $('#searchSuggestions').html(suggestionsHtml).show();
}

function hideSearchSuggestions() {
    $('#searchSuggestions').hide();
}

// Video player controls (for video detail pages)
function initializeVideoPlayer() {
    // This would initialize YouTube or custom video player
    console.log('Video player initialized');
}

// Smooth scrolling for video carousels
function initializeCarouselScrolling() {
    $('.carousel-scroll-left').on('click', function() {
        const carousel = $(this).siblings('.video-carousel');
        carousel.animate({ scrollLeft: '-=300' }, 300);
    });
    
    $('.carousel-scroll-right').on('click', function() {
        const carousel = $(this).siblings('.video-carousel');
        carousel.animate({ scrollLeft: '+=300' }, 300);
    });
}

// Initialize all functionality when document is ready
$(document).ready(function() {
    initializeSearchAutocomplete();
    initializeCarouselScrolling();
    
    // Add smooth scrolling to all anchor links
    $('a[href^="#"]').on('click', function(event) {
        var target = $(this.getAttribute('href'));
        if (target.length) {
            event.preventDefault();
            $('html, body').stop().animate({
                scrollTop: target.offset().top - 80
            }, 1000);
        }
    });
});