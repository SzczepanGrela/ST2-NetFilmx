var isUsernameValid = false;

function validateUsername(userId) {
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

    var requestData = { username: username };
    if (userId) {
        requestData.userId = userId;
    }

    $.get('/User/IsUsernameAvailable', requestData, function (isAvailable) {
        if (isAvailable) {
            $('#username-error').text('');
            isUsernameValid = true;
        } else {
            $('#username-error').text('Username is not available');
            isUsernameValid = false;
        }
    });
}
