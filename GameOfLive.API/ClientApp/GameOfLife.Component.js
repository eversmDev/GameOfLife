angular.module('GameOfLife')
    .component('gameOfLifeBoard',{
        templateUrl: '/ClientApp/gameOfLife.Template.html',
        controller: ['$scope', 'GameOfLifeService', function ($scope, gameOfLifeService) {

            var self = this;
            self.board = [[1, 1, 0, 0, 0], [1, 0, 0, 0, 0], [0, 0, 0, 0, 0], [0, 0, 0, 0, 0], [0, 0, 0, 0, 0]];

            var onError = function (reason) {
                self.error = 'Could not perform step';
            }

            var onStepPerformed = function (data) {

                self.board = data;

            }

            self.changeCell = function changeCell(rowIndex, columnIndex) {

                self.board[rowIndex][columnIndex] = self.board[rowIndex][columnIndex] == 0 ? 1 : 0;  
               
            }

            self.performStep = function(){

                gameOfLifeService.performStep(self.board).then(onStepPerformed,onError);

            }

        }]
    });