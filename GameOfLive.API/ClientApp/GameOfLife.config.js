angular.module('GameOfLife')
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/gameOfLife/:rowCount:columnCount', {
                template: "<game-of-life-board></game-of-life-board>"
            })
            .when('/gameOfLife', {
                template: "<game-of-life-board></game-of-life-board>"
            })
            .otherwise({
                redirectTo: '/gameOfLife'
            });
    }]);