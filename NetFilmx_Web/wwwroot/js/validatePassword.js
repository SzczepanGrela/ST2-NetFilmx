// validatePassword.js

var isPasswordValid = false;

function validatePassword() {
    var password = $('#Password').val();
    var error = '';

    if (password.length < 8) {
        error = 'Password must be at least 8 characters long.';
    } else if (!/[A-Z]/.test(password)) {
        error = 'Password must contain at least one uppercase letter.';
    } else if (!/[a-z]/.test(password)) {
        error = 'Password must contain at least one lowercase letter.';
    } else if (!/[0-9]/.test(password)) {
        error = 'Password must contain at least one number.';
    } 

    if (error) {
        isPasswordValid = false;
    } else {
        isPasswordValid = true;
    }

    $('#password-error').text(error);
}
