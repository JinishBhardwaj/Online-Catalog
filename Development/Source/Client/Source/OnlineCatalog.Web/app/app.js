'use strict';
var myApp = angular.module('onlineCatalogApp', ['ngRoute', 'angular-loading-bar', 'LocalStorageModule']);

myApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/login', {
            templateUrl: "/app/views/login.html",
            controller: "accountController"
        });
    $routeProvider.otherwise({ redirectTo: "/index" });
}]);

myApp.run(['authService', function (authService) {
    authService.loadAuthData();
}]);