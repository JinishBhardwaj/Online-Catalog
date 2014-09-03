'use strict';
myApp.controller('indexController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {
    $scope.authentication = authService.authentication;

    $scope.logout = function () {
        authService.logout();
        $location.path = "/index";
    };
}]);