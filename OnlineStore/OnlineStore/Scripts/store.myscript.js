var updateCartValue = function () {
    var url = "/Cart/CountItemsInCart";
    $.get(url, null, function (data) {
        $('.count-items').html(data);
    });
}

$(document).ready(function () {
    var id = $("#product-id").attr('value');
    $(".shop-cart").on('click', function (e) {
        var url = "/Cart/AddItemToCartAsync";
        e.preventDefault();
        $.get(url, { productID: id }, function (data) {            
                $('#dialogcontent').html(data);
                $('#mod-dialog').modal('show');
                updateCartValue();                        
        });        
    });    
});