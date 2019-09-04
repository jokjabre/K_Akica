
function GetDataFromNewFeed() {

    var poop = $(selectorMap.newItemPoop).prop("checked");
    var wizz = $(selectorMap.newItemWizz).prop("checked");

    var minutes = $(selectorMap.newItemDuration).val();
    var duration = minutes < 60 ? "00:" + minutes + ":00" : "01:00:00";

    var description = $(selectorMap.newItemDescription).val();
    var pooperId = getPooperId();

    return {
        Poop: poop,
        Wizz: wizz,

        Duration: duration,
        Description: description,
        PooperId: pooperId
    };
}

function refreshFeed() {
    event.preventDefault();

    var dt = GetDataFromNewFeed();

    $.ajax({
        type: "POST",
        url: './Home/AddFeed',
        data: dt,
        success: function () {

            populateFromControllerAction(
                linkMap.feed,
                { id: dt.PooperId },
                selectorMap.pooperFeedId,
                null,
                pooperHolderClickFuncPost);
        }
    });
}

function attachToScrollEvent() {
    var div = $(selectorMap.feedTimelineId);
    div.scroll(function () {
        if ($(this).scrollTop() === 0) {
            valMap.pageNum++;
            loadNewPage(selectorMap.feedTimelineId);
        }
    });
}

function loadNewPage(elemSelector) {

    var div = $(elemSelector);
    var scroll = div[0].scrollHeight;

    var funcPost = function () {
        div.scrollTop(div[0].scrollHeight - scroll);
    };

    populateFromControllerAction(
        linkMap.feed + "?pageNum=" + valMap.pageNum,
        { id: getPooperId() },
        selectorMap.feedHolderId,
        null,
        funcPost,
        true);
}