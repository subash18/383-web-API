function shoppingCart(cartName) {
    this.cartName = cartName;
    this.clearCart = false;
    this.checkoutParameters = {};
    this.items = [];
    var jsonFile = this.createJSON;

    this.loadItems();

    var self = this;
    $(window).unload(function () {
        if (self.clearCart) {
            self.clearItems();
        }
        self.saveItems();
        self.clearCart = false;
    });
}

shoppingCart.prototype.loadItems = function () {
    var items = localStorage != null ? localStorage[this.cartName + "_items"] : null;
    if (items != null && JSON != null) {
        try {
            var items = JSON.parse(items);
            for (var i = 0; i < items.length; i++) {
                var item = items[i];
                if (item.ProductId != null && item.Name != null && item.Price != null && item.InventoryCount != null) {
                    item = new cartItem(item.ProductId, item.Name, item.Price, item.InventoryCount);
                    this.items.push(item);
                }
            }
        }
        catch (err) {
            // ignore errors while loading...
        }
    }
}

// save items to local storage
shoppingCart.prototype.saveItems = function () {
    if (localStorage != null && JSON != null) {
        localStorage[this.cartName + "_items"] = JSON.stringify(this.items);
    }
}


// adds an item to the cart
shoppingCart.prototype.addItem = function (ProductId, Name, Price, quantity) {
    quantity = this.toNumber(quantity);
    if (quantity != 0) {

        // update quantity for existing item
        var found = false;
        for (var i = 0; i < this.items.length && !found; i++) {
            var item = this.items[i];
            if (item.ProductId == ProductId) {
                found = true;
                item.InventoryCount = this.toNumber(item.InventoryCount + quantity);
                if (item.InventoryCount <= 0) {
                    this.items.splice(i, 1);
                }
            }
        }

        // new item, add now
        if (!found) {
            var item = new cartItem(ProductId, Name, Price, quantity);
            this.items.push(item);
        }

        // save changes
        this.saveItems();
    }
}

// get the total price for all items currently in the cart
shoppingCart.prototype.getTotalPrice = function (ProductId) {
    var total = 0;
    for (var i = 0; i < this.items.length; i++) {
        var item = this.items[i];
        if (ProductId == null || item.ProductId == ProductId) {
            total += this.toNumber(item.InventoryCount * item.Price);
        }
    }
    return total;
}

// get the total price for all items currently in the cart
shoppingCart.prototype.getTotalCount = function (ProductId) {
    var count = 0;
    for (var i = 0; i < this.items.length; i++) {
        var item = this.items[i];
        if (ProductId == null || item.ProductId == ProductId) {
            count += this.toNumber(item.InventoryCount);
        }
    }
    return count;
}

// clear the cart
shoppingCart.prototype.clearItems = function () {
    this.items = [];
    this.saveItems();
}

// define checkout parameters
shoppingCart.prototype.addCheckoutParameters = function (serviceName, options) {

    // save parameters
    this.checkoutParameters[serviceName] = new checkoutParameters(serviceName, options);
}

// check out
shoppingCart.prototype.checkout = function (serviceName, clearCart, quantity) {

    // select serviceName if we have to
    if (serviceName == null) {
        var p = this.checkoutParameters[Object.keys(this.checkoutParameters)[0]];
        serviceName = p.serviceName;
    }

    // go to work
    var parms = this.checkoutParameters[serviceName];
    this.checkoutPurchase(parms, clearCart);
}

shoppingCart.prototype.checkoutPurchase = function (parms, clearCart) {
    
    //$http.put("http://localhost:58198/api/Products/", this.items)
    this.clearItems();
    //$scope.store.products = data.data;
    
}
shoppingCart.prototype.toNumber = function (value) {
    value = value * 1;
    return isNaN(value) ? 0 : value;
}

//----------------------------------------------------------------
// checkout parameters (one per supported payment service)
//
function checkoutParameters(serviceName, options) {
    this.serviceName = serviceName;
    this.options = options;
}

//----------------------------------------------------------------
// items in the cart
//
function cartItem(ProductId, Name, Price, quantity) {
    this.ProductId = ProductId;
    this.Name = Name;
    this.Price = Price * 1;
    this.InventoryCount = quantity * 1;
}

