function AddToBasket($itemId) {
    $.ajax({
        type: "post",
        url: '/Home/AddToBasket',
        data: { itemId: $itemId },
        success: function (data) {
            $("#basket").html(data);
        },
        error: function (error) {
            console.log(error)
        }
    });
}

function RemoveFromBasket($itemId) {
    $.ajax({
        type: "post",
        url: '/Home/RemoveFromBasket',
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

