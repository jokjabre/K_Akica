
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
                scrollToNewFeedItem);
        }
    });
}