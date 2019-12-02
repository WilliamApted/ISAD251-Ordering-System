﻿function ViewOrderDetail($orderId) {
    $("#showHide" + $orderId).attr("onclick", "CloseOrderDetail(" + $orderId + ")");

    $.ajax({
        type: "post",
        url: '/Admin/ViewOrderDetails',
        data: { orderId: $orderId },
        success: function (data) {
            $("#orderDetails" + $orderId).html(data);
        },
        error: function (error) {
            console.log(error)
        }
    });
}

function CloseOrderDetail($orderId)
{
    $("#showHide" + $orderId).attr("onclick", "ViewOrderDetail(" + $orderId + ")");
    $("#orderDetails" + $orderId).empty();
}

function EditItem($itemId) {
    $.post({
        type: "post",
        url: '/Admin/EditItemRequest',
        data: { itemId: $itemId },
        success: function (data) {
            $(window.document.body).html(data)
        },
    });
}

function Logout() {
    $.post({
        type: "post",
        url: '/Admin/Logout',
        success: function() {
            window.location.reload()
        },
    });
}

