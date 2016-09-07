var search = angular.module('search', []);

search.controller('MealSearchController', function SearchController($scope, $http) {
    $http({
        method: "GET",
        url: "/api/meals"
    }).then(function success(response) {
        $scope.items = response.data;
        console.log($scope.items);
    });
});

search.controller('EventSearchController', function SearchController($scope, $http) {
    $http({
        method: "GET",
        url: "/api/events"
    }).then(function success(response) {
        $scope.items = response.data;
        console.log($scope.items);
    });

    $scope.post = function (eventId) {

    }

});