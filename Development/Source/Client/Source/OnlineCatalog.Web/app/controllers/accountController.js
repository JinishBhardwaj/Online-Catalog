'use strict';
myApp.controller('accountController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {
    $scope.authData = {
        username: "",
        password: ""
    };

    $scope.message = "";

    $scope.authenticate = function () {
        authService.login($scope.authData).then(function (response) {
            $location.path('/index');
        },
         function (err) {
             $scope.message = err.error_description;
         });
    };
}]);