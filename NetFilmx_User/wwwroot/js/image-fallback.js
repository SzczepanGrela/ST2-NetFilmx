/* NetFilmx Image Fallback System */

document.addEventListener('DOMContentLoaded', function() {
    // Handle image loading errors with placeholders
    const images = document.querySelectorAll('img');
    
    images.forEach(function(img) {
        img.addEventListener('error', function() {
            handleImageError(this);
        });
        
        // Check if image is already broken
        if (img.complete && img.naturalHeight === 0) {
            handleImageError(img);
        }
    });
});

function handleImageError(img) {
    const src = img.src;
    
    // Don't replace if already replaced
    if (img.classList.contains('placeholder-replaced')) {
        return;
    }
    
    // Create placeholder based on original src
    let placeholderContent = '';
    let placeholderClass = 'placeholder';
    
    if (src.includes('video-placeholder') || src.includes('video')) {
        placeholderContent = '🎬';
        placeholderClass = 'video-placeholder';
    } else if (src.includes('series-placeholder') || src.includes('series')) {
        placeholderContent = '📺';
        placeholderClass = 'series-placeholder';
    } else if (src.includes('category-placeholder') || src.includes('category')) {
        placeholderContent = '📁';
        placeholderClass = 'category-placeholder';
    } else if (src.includes('avatar') || src.includes('profile')) {
        placeholderContent = '👤';
        placeholderClass = 'avatar-placeholder';
    } else {
        placeholderContent = '🖼️';
        placeholderClass = 'placeholder';
    }
    
    // Create placeholder div
    const placeholder = document.createElement('div');
    placeholder.className = placeholderClass + ' placeholder-replaced';
    placeholder.textContent = placeholderContent;
    placeholder.style.width = img.offsetWidth || img.style.width || '100%';
    placeholder.style.height = img.offsetHeight || img.style.height || '200px';
    placeholder.style.display = 'flex';
    placeholder.style.alignItems = 'center';
    placeholder.style.justifyContent = 'center';
    placeholder.style.fontSize = '3rem';
    placeholder.style.color = '#666';
    placeholder.style.borderRadius = img.style.borderRadius || '0';
    
    // Copy any classes from the original image
    if (img.className) {
        placeholder.className += ' ' + img.className;
    }
    
    // Replace the image with placeholder
    img.parentNode.replaceChild(placeholder, img);
}

// Function to create placeholder for specific types
function createPlaceholder(type, width = '100%', height = '200px') {
    const placeholder = document.createElement('div');
    
    switch(type) {
        case 'video':
            placeholder.className = 'video-placeholder';
            placeholder.textContent = '🎬';
            break;
        case 'series':
            placeholder.className = 'series-placeholder';
            placeholder.textContent = '📺';
            break;
        case 'category':
            placeholder.className = 'category-placeholder';
            placeholder.textContent = '📁';
            break;
        case 'avatar':
            placeholder.className = 'avatar-placeholder';
            placeholder.textContent = '👤';
            break;
        default:
            placeholder.className = 'placeholder';
            placeholder.textContent = '🖼️';
    }
    
    placeholder.style.width = width;
    placeholder.style.height = height;
    placeholder.style.display = 'flex';
    placeholder.style.alignItems = 'center';
    placeholder.style.justifyContent = 'center';
    placeholder.style.fontSize = '3rem';
    placeholder.style.color = '#666';
    
    return placeholder;
}

// Utility function to preload critical placeholders
function preloadPlaceholders() {
    const placeholderTypes = ['video', 'series', 'category', 'avatar'];
    
    placeholderTypes.forEach(type => {
        const placeholder = createPlaceholder(type, '1px', '1px');
        placeholder.style.position = 'absolute';
        placeholder.style.top = '-9999px';
        placeholder.style.left = '-9999px';
        document.body.appendChild(placeholder);
        
        // Remove after a short delay
        setTimeout(() => {
            if (placeholder.parentNode) {
                placeholder.parentNode.removeChild(placeholder);
            }
        }, 100);
    });
}

// Initialize placeholders
preloadPlaceholders();

// Export functions for global use
window.NetFilmxImageFallback = {
    handleImageError: handleImageError,
    createPlaceholder: createPlaceholder
};