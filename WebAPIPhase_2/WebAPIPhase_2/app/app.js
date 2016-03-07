'use strict';

var eventsApp = angular.module('eventsApp', ['ngRoute', 'angular-loading-bar']);
eventsApp.config(function($routeProvider) {
    $routeProvider

        // route for the home page
        .when('/', {
            templateUrl: 'app/views/store.htm',
            controller  : 'storeController'
        })

        // route for the about page
        .when('/products/:productId', {
            templateUrl : 'app/views/product.htm',
            controller  : 'storeController'
        })

        // route for the contact page
        .when('/cart', {
            templateUrl: 'app/views/shoppingCart.htm',
            controller  : 'storeController'
        });
});
eventsApp.factory("DataService", function () {

    // create store
    var myStore = new store;

    // create shopping cart
    var myCart = new shoppingCart("eventsApp");

    myCart.addCheckoutParameters("Purchase");

    

    // return data object with store and cart
    return {
        store: myStore,
        cart: myCart
    };

});