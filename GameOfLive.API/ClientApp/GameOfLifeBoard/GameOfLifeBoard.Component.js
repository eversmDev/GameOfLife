angular.module('GameOfLife')
    .component('gameOfLifeBoard',{
        templateUrl: '/ClientApp/GameOfLifeBoard/GameOfLifeBoard.Template.html',
        controller: ['$route','$routeParams','$location','GameOfLifeService', function ($route, $routeParams,$location, gameOfLifeService) {

            var self = this;
            self.rowCount = $routeParams.rowCount ? $routeParams.rowCount : 10;
            self.columnCount = $routeParams.columnCount ? $routeParams.columnCount : 10;
            self.randomStates = $routeParams.randomStates ? $routeParams.randomStates : false;

            var sizeErrorMessage = "The maximum number of colums or rows allowed is 50";

            if (self.columnCount > 50) {
                self.columnCount = 50;
                self.error = sizeErrorMessage;
            }
           
            var onError = function (reason) {
                self.error = 'Could not perform step';
            }

            var onStepPerformed = function (data) {
                self.board = data;
            }

            var createCellState = function () {

                if (self.randomStates) return Math.floor(Math.random() * 2);
                else return 0;
            }

            var setBoardSize = function (rowCount,columnCount) {
                var rows = new Array(rowCount);

                for (var i = 0; i < rowCount; i++) {
                    var row = new Array(columnCount);
                    for (var j = 0; j < columnCount; j++) row[j] = createCellState();
                    rows[i] = row;
                }

                self.board = rows;
            }


            self.changeBoardSize = function changeBoardSize() {
                $route.updateParams({ rowCount: self.rowCount, columnCount: self.columnCount, randomStates: self.randomStates });
            }

            self.reset = function reset() {
                $route.reload();
            }

            self.changeCell = function changeCell(rowIndex, columnIndex) {
                self.board[rowIndex][columnIndex] = self.board[rowIndex][columnIndex] == 0 ? 1 : 0;  
            }

            self.performStep = function(){
                gameOfLifeService.performStep(self.board).then(onStepPerformed,onError);
            }

            setBoardSize(self.rowCount, self.columnCount);

        }]
    });