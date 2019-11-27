




function UpdateBasket($itemId) {
    $.ajax({
        type: "post",
        url: '/Home/UpdateOrder',
        data: { itemId: $itemId },
        success: function (data) {
            $("#basket").html(data);
        },
        error: function (error) {
            console.log(error)
        }
    });
}

function Logout() {
    $.post({
        type: "post",
        url: '/Account/Logout',
        success: function() {
            window.location.reload()
        },
    });
}

