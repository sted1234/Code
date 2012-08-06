/// <reference path="../jquery-1.5.1-vsdoc.js"/>


$(function () {

    $("input.homepagetextbox").focus();

    $("#txtSearchBox").bind({
        mouseover: function () {
            $(this).removeClass('searchbuttonmouseout');
            $(this).addClass('searchbuttonmouseover');
        },
        mouseout: function () {
            $(this).removeClass('searchbuttonmouseover');
            $(this).addClass('searchbuttonmouseout');
        }
    })
});


function OnloadWork() {
    
    // Focus the search box
    $("input.homepagetextbox").focus();

    // Attach mouseover and mouseout events
    $("#txtSearchBox").bind({
        mouseover: function () {
            $(this).removeClass('searchbuttonmouseout');
            $(this).addClass('searchbuttonmouseover');
        },
        mouseout: function () {
            $(this).removeClass('searchbuttonmouseover');
            $(this).addClass('searchbuttonmouseout');
        }
    })

}