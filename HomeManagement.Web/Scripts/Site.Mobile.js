(function () {

    function openMenu(e) {
        $(".ui-hm-mainmenu:last").panel("open");
    }

    $("body").on("swiperight", openMenu);

} ());