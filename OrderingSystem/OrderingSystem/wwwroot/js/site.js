function Logout() {
    $.post({
        type: "post",
        url: '/Account/Logout',
        success: function() {
            window.location.reload()
        },
    });
}

