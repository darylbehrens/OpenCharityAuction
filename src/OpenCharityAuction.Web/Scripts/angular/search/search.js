var search = angular.module('search', []);

search.controller('SearchController', function SearchController($scope, $http) {
    $http({
        method: "GET",
        url: "/api/meals"
    }).then(function success(response) {
        $scope.items = response.data;
        console.log($scope.items);
    })
});