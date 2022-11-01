// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function unSubscribe() {
    $.ajax({
        url: 'Unsubscribe/Unsubscribe',
        type: 'POST',
        data: { 'email': $('#emailField').val() },
        success: function (result) {
            if (result) {
                window.location.href = "Unsubscribe/Successful";
            } else {
                alert('invalid email');
            }
        },
        error: function () {
            alert('error');
        }
    });
}

function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}