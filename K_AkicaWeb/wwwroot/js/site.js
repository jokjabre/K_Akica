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

function populateFromControllerAction(route, obj, selector, funcPre, funcPost, prepand) {
    if (funcPre) { funcPre(); }

    $.get(route, obj, function (data) {
        if (prepand) {
            $(selector).prepend(data);
        }
        else {
            $(selector).html(data);
        }

        if (funcPost) { funcPost(); }
    });
}

function scrollToNewFeedItem() {
    //document.getElementById(idMap.endItem).scrollIntoView(false);
    var div = $(selectorMap.feedTimelineId);
    div.scrollTop(div[0].scrollHeight);

    $(selectorMap.textAreaId).focus();
}

function attachToKeyPress(selector) {

    $(selector).keydown(function (e) {
        if (e.keyCode === 13 && e.altKey) {
            refreshFeed();
        }
    });
}

function pooperHolderClickFuncPost() {
    makeKnobs();
    scrollToNewFeedItem();
    attachToScrollEvent();
    attachToKeyPress(selectorMap.textAreaId);
}

function onPooperHolderClick(pId, elem) {
    valMap.pageNum = 1;

    populateFromControllerAction(
        linkMap.feed + "?pageNum=" + valMap.pageNum,
        { id: pId, pageNum: valMap.pageNum },
        selectorMap.pooperFeedId,
        setClass(elem, classMap.clicked, true),
        pooperHolderClickFuncPost);
}


