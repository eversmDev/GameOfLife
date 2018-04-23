angular.module('GameOfLife')
    .factory('GameOfLifeService', function ($http) {

        var performStep = function performStep(board){

            return $http.post('http://localhost:64642/GameOfLife', board).then(function (response) { return response.data; });

        }

        return {
            performStep: performStep
        }
    });