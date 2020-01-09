function FilterMenu($category) {
    $.ajax({
        type: "post",
        url: '/ISAD251/wapted/Order/FilterMenu',
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
        url: '/ISAD251/wapted/Basket/AddToBasket',
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
        url: '/ISAD251/wapted/Basket/RemoveFromBasket',
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
        url: '/ISAD251/wapted/Order/EditOrder',
        data: { __RequestVerificationToken: gettoken(), orderId: $orderId, name: $name },
        success: function (data) {
            $(window.document.body).html(data)
        },
    });
}

function SaveOrder() {
    $.post({
        type: "post",
        url: '/ISAD251/wapted/Order/SaveEditOrder',
        data: { __RequestVerificationToken: gettoken() },
        success: function (data) {
            $(window.document.body).html(data)
        },
    });
}

function CancelOrder($orderId, $name) {
    $.post({
        type: "post",
        url: '/ISAD251/wapted/Order/CancelOrder',
        data: { __RequestVerificationToken: gettoken(), orderId: $orderId, name: $name },
        success: function (data) {
            $(window.document.body).html(data)
        },
    });
}

