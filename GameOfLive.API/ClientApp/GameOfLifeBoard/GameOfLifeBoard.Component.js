angular.module('GameOfLife')
    .component('gameOfLifeBoard',{
        templateUrl: '/ClientApp/GameOfLifeBoard/GameOfLifeBoard.Template.html',
        controller: ['$route','$routeParams','$location','GameOfLifeService', function ($route, $routeParams,$location, gameOfLifeService) {

            var self = this;
            //self.board = [[1, 1, 0, 0, 0], [1, 0, 0, 0, 0], [0, 0, 0, 0, 0], [0, 0, 0, 0, 0], [0, 0, 0, 0, 0]];
            self.rowCount = $routeParams.rowCount ? $routeParams.rowCount : 10;
            self.columnCount = $routeParams.columnCount ? $routeParams.columnCount : 10;
           
            var onError = function (reason) {
                self.error = 'Could not perform step';
            }

            var onStepPerformed = function (data) {

                self.board = data;

            }

            var setBoardSize = function (rowCount,columnCount) {
                var rows = new Array(rowCount);

                for (var i = 0; i < rowCount; i++) {
                    var row = new Array(columnCount);
                    for (var j = 0; j < columnCount; j++) row[j] = 0;
                    rows[i] = row;
                }

                self.board = rows;
            }

            self.changeBoardSize = function changeBoardSize() {
                //$routeParams.rowCount = self.rowCount;
                //$routeParams.columnCount = self.columnCount;
     
                $route.updateParams({ rowCount: self.rowCount, columnCount: self.columnCount });
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