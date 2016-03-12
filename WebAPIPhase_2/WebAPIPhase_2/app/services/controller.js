'use strict';
eventsApp.controller('storeController',
function storeController($scope, $routeParams, DataService, $http) {
    $scope.store = DataService.store;
    $scope.cart = DataService.cart;
    $scope.waitMessage = "";
    $scope.emailInfo = {
        text: ''
    }
    $scope.emailPattern = /^[a-z]+[a-z0-9._]+@[a-z0-9]+\.[a-z.]{2,5}$/;
    $scope.buy = true;

    if ($routeParams.ProductId != null) {
        $scope.product = $scope.store.getProduct($routeParams.ProductId);
    }
    $scope.updateBuy = function () {
        $scope.buy = false;
    }
    $scope.httpget = function () {
        $scope.buy = true;
        $scope.waitMessage = "Please wait while we grab a list of our products.....";
        $http.get("http://localhost:58198/api/Products").then(function (data) {
            $scope.store.products = data.data;
            $scope.waitMessage = "";
            $scope.buy = false;
        })
    }
    $scope.httpgetCategory = function () {
        $http.get("http://localhost:58198/api/Categories").then(function (data) {
            $scope.Categories = data.data
        })
    }
    $scope.httpgetManufacturers = function () {
        $http.get("http://localhost:58198/api/Manufacturers").then(function (data) {
            $scope.Manufacturers = data.data
        })
    }
    $scope.update = function (updateproduct, email) {
        $scope.buy = true;
        $scope.waitMessage = "Please wait while we proccess your order.....";
        $http.post("http://localhost:58198/api/Products/UpdateProducts?email=" + email, updateproduct).then(function (response) {
            $scope.cart.clearItems();
            $scope.waitMessage = "";
            $scope.buy = false;
        })
    }
});
