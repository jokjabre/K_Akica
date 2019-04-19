// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function addListener(selector, func) {
    $(document).on('click', selector, function (e) {
        $(this).addClass('selected').siblings().removeClass('selected');
        var value = $(this).find('td:first').html();
        func(value);

    });
}




function refreshLink(route, obj, selector) {
    $.get(route, obj, function (data) {
        $(selector).replaceWith(data);
    });
}