'use strict';
myApp.factory('authService', ['$http', '$q', 'localStorageService', function ($http, $q, localStorgeService) {
    
    var authServiceFactory = {};
    var endpoint = "http://localhost:9810/";

    var _authentication = {
        isAuthenticated: false,
        username: ""
    };

    var _login = function (authData) {
        var data = "grant_type=password&username=" + authData.username + "&password=" + authData.password;
        var deferred = $q.defer();

        $http.post(endpoint + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
             .success(function (response) {

                 localStorgeService.set('authorizationData', { token: response.access_token, username: authData.username });
                 _authentication.isAuthenticated = true;
                 _authentication.username = authData.username;

                 deferred.resolve(response);
             })
             .error(function (err, status) {
                 deferred.reject(err);
             });

        return deferred.promise;
    };

    var _logout = function () {
        localStorgeService.remove('authorizationData');
        _authentication.isAuthenticated = false;
        _authentication.username = "";
    };

    var _loadAuthData = function () {
        var aData = localStorgeService.get('authorizationData');
        if (aData) {
            _authentication.isAuthenticated = true;
            _authentication.username = aData.username;
        }
    }

    // user registration functions
    var _registerUser = function (signupData) {
        _logout();
        return $http.post(endpoint + 'api/account/signup', signupData).success(function (response) {
            return response;
        })
        .error(function (response) {
            return response;
        })
    };

    authServiceFactory.login = _login;
    authServiceFactory.logout = _logout;
    authServiceFactory.authentication = _authentication;
    authServiceFactory.loadAuthData = _loadAuthData;
    authServiceFactory.registerUser = _registerUser;
    return authServiceFactory;
}]);