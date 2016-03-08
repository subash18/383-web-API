

function store() {
    this.products = [];
    //        new product(1, "RAM", 56, 100),
    //        new product(2, "CPU", 325, 100),
    //        new product(3, "Graphics Card", 756, 100),
    //        new product(4, "Tower", 127, 100),
    //        new product(5, "Power Supply", 230, 100),
    //        new product(6, "Hard drive", 69, 100)


    //}
}
store.prototype.getProduct = function (productId) {
    for (var i = 0; i < this.products.length; i++) {
        if (this.products[i].productId == productId)
            return this.products[i];
    }
    return null;
}
store.prototype.updateQuantity = function (productId) {
    var prod = store.prototype.getProduct(productId);
}


