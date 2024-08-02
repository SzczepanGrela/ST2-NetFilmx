// refresh.js
window.onpageshow = function (event) {
    console.log("Page show event detected");

    // is loaded from chache
    if (event.persisted) {
        console.log("Page loaded from cache, reloading...");
        if (!sessionStorage.getItem('reloadOnce')) {
            sessionStorage.setItem('reloadOnce', 'true');
            window.location.reload();
        } else {
            sessionStorage.removeItem('reloadOnce');
        }
    } else if (performance.navigation.type === 2) {
        // Check if the page was load via bck/frwd arrow or goback method
        console.log("Page accessed via back/forward navigation, reloading...");
        if (!sessionStorage.getItem('reloadOnce')) {
            sessionStorage.setItem('reloadOnce', 'true');
            window.location.reload();
        } else {
            sessionStorage.removeItem('reloadOnce');
        }
    } else {
        console.log("Page loaded normally, no reload needed.");
    }
};

// Optionally, use sessionStorage to track state
window.onbeforeunload = function () {
    sessionStorage.setItem('needReload', 'true');
};


// thanks to realoadOnce it's easier to control page and prevent it loading infinitely
window.onload = function () {
    if (sessionStorage.getItem('needReload') === 'true') {
        sessionStorage.removeItem('needReload');
        if (!sessionStorage.getItem('reloadOnce')) {
            sessionStorage.setItem('reloadOnce', 'true');
            window.location.reload();
        } else {
            sessionStorage.removeItem('reloadOnce');
        }
    }
};
