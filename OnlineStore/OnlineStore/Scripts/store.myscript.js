
function updateCartValue() {
    var url = "/Cart/CountItemsInCart";
    $.get(url, null, function (data) {
        $('.count-items').html(data);
    });
}

function getCartFromServer() {
    var id = $("#product-id").attr('value');
    $.ajaxSetup({ cache: false });
    $(".shop-cart").on('click', function (e) {
        var url = "/Cart/AddItemToCartAsync";
        e.preventDefault();
        $.get(url, { productID: id }, function (data) {
            $('#dialogcontent').html(data);
            $('#mod-dialog').modal('show');
        });
    });
    updateCartValue();
}






