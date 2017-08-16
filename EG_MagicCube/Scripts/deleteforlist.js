$("input#checkall").click(function () {
    $("input.delcheck").prop("checked", $(this).prop("checked"));
    setdelbutton();
});
$("input.delcheck").click(function () {
    $("input#checkall").prop("checked", false);
    setdelbutton();
});

$('input#delete-btn').click(function () {
    var d = $('input.delcheck:checked');

    var data = [];
    if (d.length == 0) {
        alert('請選取刪除項目');
        return;
    }
    for (var i = 0; i < d.length; i++) {
        data[i] = $(d[i]).attr('id');
    }

    $('div.container').css("cursor", "wait");
    $('#delete-btn').css('visibility', 'hidden');
    var url = $(this).data("url");
    $("#loadingeffect").show();
    $.ajax({
        type: "Post",
        url: url,
        data: { id: data },
        async: true,
        cache: false,
        dataType: "json",
        success: function (data) {
            //alert(data);

            location.reload();
        },
        error: function (viewHTML) {
            $("#loadingeffect").hide();
            alert("刪除失敗....");
            $('#delete-btn').css('visibility', 'visible');
        }
    });
});

function setdelbutton() {
    var s = $('input.delcheck:checked').length;
    if (s > 0) {
        $('#delete-btn').css('visibility', 'visible');
    } else {
        $('#delete-btn').css('visibility', 'hidden');
    }
}