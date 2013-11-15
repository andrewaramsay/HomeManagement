/// <reference path="jquery-2.0.3-vsdoc.js" />
/// <reference path="jquery-ui-1.10.3.js" />
/// <reference path="jquery-ui-timepicker-addon.js" />

$(document).ready(function () {
    // Set all datetime inputs to use the datetime picker, and use the theme's color scheme
    $('input[type=datetime]').datetimepicker().addClass("ui-widget-header ui-state-default");

    // Set all submit buttons to be JQuery-UI buttons
    $('input[type=submit]').button();

    // Set other forms of text box to use the theme's color scheme
    $('input[type=number]').addClass("ui-widget-header ui-state-default");
    $('input[type=text]').addClass("ui-widget-header ui-state-default");
    $('textarea').addClass("ui-widget-header ui-state-default");

    // Set any div's with class radioset to use the JQuery-UI button set
    $("div.radioset").buttonset();
});