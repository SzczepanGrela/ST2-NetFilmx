// validateUsername.js

var isUsernameValid = false;

function validateUsername() {
    var username = $('#Username').val();
    var error = '';

    
    if (username.length < 5) {
        error = 'Username must be at least 5 characters long.';
    } else if (username.length > 50) {
        error = 'Username must be less than 50 characters long.';
    }

    if (error) {
        $('#username-error').text(error);
        isUsernameValid = false;
        return;
    }

    $.get('/User/IsUsernameAvailable', { username: username }, function (isAvailable) {
        if (isAvailable) {
            $('#username-error').text('');
            isUsernameValid = true;
        } else {
            $('#username-error').text('Username is not available');
            isUsernameValid = false;
        }
    });
}
