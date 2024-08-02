// validateEmail.js

var isEmailValid = false;

function validateEmail() {
    var email = $('#Email').val();
    var error = '';

    var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;

    if (!emailPattern.test(email)) {
        error = 'Please enter a valid email address.';
        isEmailValid = false;
    } else {
        isEmailValid = true;
    }

    $('#email-error').text(error);
}
