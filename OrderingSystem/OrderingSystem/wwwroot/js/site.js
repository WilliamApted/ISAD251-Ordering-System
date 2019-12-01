﻿function AddToBasket($itemId) {
    $.ajax({
        type: "post",
        url: '/Order/AddToBasket',
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
        url: '/Order/RemoveFromBasket',
        data: { itemId: $itemId },
        success: function (data) {
            $("#basket").html(data);
        },
        error: function (error) {
            console.log(error)
        }
    });
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

