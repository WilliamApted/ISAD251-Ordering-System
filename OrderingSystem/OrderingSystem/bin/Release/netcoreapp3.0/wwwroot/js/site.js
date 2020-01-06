function FilterMenu($category) {
    $.ajax({
        type: "post",
        url: '/Order/FilterMenu',
        data: { __RequestVerificationToken: gettoken(), category: $category },
        success: function (data) {
            $("#menu").html(data);
        },
        error: function (error) {
            console.log(error)
        }
    });
}

function AddToBasket($itemId) {
    $.ajax({
        type: "post",
        url: '/Basket/AddToBasket',
        data: { __RequestVerificationToken: gettoken(), itemId: $itemId },
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
        data: { __RequestVerificationToken: gettoken(), itemId: $itemId },
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
        data: { __RequestVerificationToken: gettoken(), orderId: $orderId, name: $name },
        success: function (data) {
            $(window.document.body).html(data)
        },
    });
}

function SaveOrder() {
    $.post({
        type: "post",
        url: '/Order/SaveEditOrder',
        data: { __RequestVerificationToken: gettoken() },
        success: function (data) {
            $(window.document.body).html(data)
        },
    });
}

function CancelOrder($orderId, $name) {
    $.post({
        type: "post",
        url: '/Order/CancelOrder',
        data: { __RequestVerificationToken: gettoken(), orderId: $orderId, name: $name },
        success: function (data) {
            $(window.document.body).html(data)
        },
    });
}

