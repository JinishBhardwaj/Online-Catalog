'use strict';

myApp.controller('signupController', ['$scope', 'navigationService', 'authService', function ($scope, navigationService, authService) {
    
    $scope.registrationData = {
        firstname: "",
        lastname: "",
        email: "",
        address: "",
        city: "",
        pincode: "",
        password: "",
        provinceId: 0
    };

    $scope.provinces = [
            { id: 1, name: "West Yorkshire" },
            { id: 2, name: "Lancashire" },
            { id: 3, name: "North Wales" },
            { id: 4, name: "West Midlands" }
    ];

    $scope.message = "";
    $scope.success = false;

    $scope.register = function () {
        authService.registerUser($scope.registrationData).then(function (response) {
            $scope.success = true;
            $scope.message = "User has been registered successfully. You will automatically be redirected to the login page in 5 seconds";
            navigationService.navigate('/login', 5000);
        },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.success = false;
             $scope.message = "User registration was unsuccessful:" + errors.join(' ');
         });
    };
}]);