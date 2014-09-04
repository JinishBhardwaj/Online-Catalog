'use strict';
myApp.controller('indexController', ['$scope', 'navigationService', 'authService', function ($scope, navigationService, authService) {
    $scope.authentication = authService.authentication;

    $scope.logout = function () {
        authService.logout();
        navigationService.navigate('/index', 0);
    };
}]);