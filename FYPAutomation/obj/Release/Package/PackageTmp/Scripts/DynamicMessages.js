
$(document.body).append('<div id="dialog" style="display:none"></div>');
function ShowPopup(header, message) {
        $(function () {
            $("#dialog").html(message);
            $("#dialog").dialog({
                title: header,
                buttons: {
                    Close: function () {
                        $(this).dialog('close');
                    }
                },
                modal: true
            });
            $('#dialog').parent('div').addClass("MakeFixed");
        });
    }
