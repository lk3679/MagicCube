$(document).ready(function () {
    var _e = $('span.numberprice input[type=number]');
    for (var i = 0; i < _e.length; i++) {
        $(_e[i]).parent().find('input[type=text]').val($(_e[i]).val().replace(/(\d{1,3})(?=(\d{3})+$)/g, "$1,"));
    }
});
$('span.numberprice input[type=text]').focus(function () {
    //var _id = $(this).attr(id);
    //$(this).css('opacity', '1').css('top', '-19px').css('position', 'relative').focus();
    $(this).parent().find('input[type=number]').css('z-index', '2').focus();
})
$('span.numberprice input[type=number]').blur(function () {
    //$(this).css('opacity', '0').css('top', '0px').css('position', 'absolute');
    $(this).css('z-index', '-1');
}).change(function () {
    $(this).parent().find('input[type=text]').val($(this).val().replace(/(\d{1,3})(?=(\d{3})+$)/g, "$1,"));
});