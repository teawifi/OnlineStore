
var transition;

function showModalDialog() {
    $('#shop-cart-dialog')[0].showModal();
    transition = window.setTimeout(function () {
        $($('#shop-cart-dialog')[0].parentNode).addClass('dialog-scale');
    }, 0.5);
}

//function getCartFromServer() {

//    var url = "/Cart/AddItemToCart";
//    var id = $("#product-id").attr('value');

//    $.getJSON(url, { productID: id }, function (data) {
//        var items = data;

//        var goods = "<ol>";

//        for (p in items) {
//            goods += "<li> <div class='goods-name'>" + items[p].ProductName + "</div>" +
//                "<input type='text' value='" + items[p].Quantity + "' class='goods-quantity'/></li>";
//        }
//        goods += "</ol>"

//        $(".dialog-content").html(goods);
//    });
        
//    showModalDialog();
//}


function closeDialog() {   
        $('#shop-cart-dialog')[0].close();
        $($('#shop-cart-dialog')[0].parentNode).removeClass('dialog-scale');
        clearTimeout(transition);    
}

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
        var url = "/Cart/AddItemToCart";
        e.preventDefault();
        $.get(url, { productID: id }, function (data) {
            $('#dialogcontent').html(data);
            $('#mod-dialog').modal('show');
        });
    });
    updateCartValue();
}

//function clearcart() {
//    $(".clear-cart").on('click', function (e) {
//        var url = "/cart/clearshoppingcart";
//        e.preventdefault();
//        $.get(url, null, function (data) { });
//    });
//}





