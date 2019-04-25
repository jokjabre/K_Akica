// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function getPooperId() {
    return $(selectorMap.pooperHolderClickedSelector).data(dataMap.pooperId);
}

function setClass(elem, className, removeFromSiblings) {
    if (removeFromSiblings) {
        $(elem).siblings().removeClass(className);
    }
    $(elem).addClass(className);
}

function populateFromControllerAction(route, obj, selector, funcPre, funcPost) {
    if (funcPre) { funcPre(); }

    $.get(route, obj, function (data) {
        $(selector).html(data);
        if (funcPost) { funcPost(); }
    });
}

function scrollToNewFeedItem() {
    document.getElementById(idMap.newFeedItem).scrollIntoView(true);
}

function onPooperHolderClick(pId, elem) {
    populateFromControllerAction(
        linkMap.feed,
        { id: pId },
        selectorMap.pooperFeedId,
        setClass(elem, classMap.clicked, true),
        scrollToNewFeedItem);
}

var refreshFeed = function (form, url) {
    event.preventDefault();
    var elem = $(selectorMap.pooperHolderClickedSelector);
    var pId = elem.data(dataMap.pooperId);
    var dt = form.serializeArray().concat({ name: "PooperId", value: pId });
    
    $.ajax({
        type: "POST",
        url: url,
        data: dt, // serializes the form's elements.
        success: function (data) {
           
            

            populateFromControllerAction(
                linkMap.feed,
                { id: pId },
                selectorMap.pooperFeedId,
                null,
                scrollToNewFeedItem);
        }
    });

};