function AddToBasket($itemId) {
    $.ajax({
        type: "post",
        url: '/Basket/AddToBasket',
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
        url: '/Basket/RemoveFromBasket',
        data: { itemId: $itemId },
        success: function (data) {
            $("#basket").html(data);
        },
        error: function (error) {
            console.log(error)
        }
    });
}

function EditOrder($orderId, $name) {
    $.post({
        type: "post",
        url: '/Order/EditOrder',
        data: { orderId: $orderId, name: $name },
        success: function (data) {
            $(window.document.body).html(data)
        },
    });
}

function SaveOrder() {
    $.post({
        type: "post",
        url: '/Order/SaveEditOrder',
        success: function (data) {
            $(window.document.body).html(data)
        },
    });
}

function CancelOrder($orderId, $name) {
    $.post({
        type: "post",
        url: '/Order/CancelOrder',
        data: { orderId: $orderId, name: $name },
        success: function (data) {
            $(window.document.body).html(data)
        },
    });
}

