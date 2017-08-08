
//---------------------數字、日期類型的input禁用滾輪------------------------
$('form').on('focus', 'input[type=number],input[type=date]', function (e) {
    $(this).on('mousewheel.disableScroll', function (e) {
        e.preventDefault()
    })
})
$('form').on('blur', 'input[type=number],input[type=date]', function (e) {
    $(this).off('mousewheel.disableScroll')
})
//-------------------------------------------------------------------------