(function () {
    $.event.special.swipe.horizontalDistanceThreshold = 100;

    function openMenu(e) {
        $(".ui-hm-mainmenu:last").panel("open");
    }

    $("body").on("swiperight", openMenu);

} ());