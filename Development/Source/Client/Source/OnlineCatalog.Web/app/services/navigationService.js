'use strict';
myApp.factory('navigationService', ['$location', '$timeout', function ($location, $timeout) {
    var navigationServicefactory = {};

    var _navigate = function (url, delay) {
        var timer = $timeout(function () {
            $timeout.cancel(timer);
            $location.path(url);
        }, delay);
    };

    navigationServicefactory.navigate = _navigate;
    return navigationServicefactory;
}]);