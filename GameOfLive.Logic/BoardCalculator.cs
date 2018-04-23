using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLive.Logic
{
    public class BoardCalculator
    {

        private int rowCount;
        private int columnCount;
        private int[,] board;

        private int[,] cellStates = {
                //Cell states for dead cells
                { 0, 0, 0, 1, 0 ,0, 0, 0, 0 },
                //Cell states for live cells
                { 0, 0, 1, 1, 0, 0, 0, 0, 0 }
            };

        public int[,] PerformStep(int[,] board)
        {
            rowCount = board.GetLength(0);
            columnCount = board.GetLength(1);
            this.board = board;

            var newboard = new int[rowCount, columnCount];
            var aliveNeighBoursCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    //Get alive neighbours total for each cell
                    aliveNeighBoursCount = GetCellAliveNeighBours(i, j);

                    var currentCellState = board[i, j];
                    
                    //Set new state based on states array
                    newboard[i, j] = cellStates[currentCellState, aliveNeighBoursCount];
                }
            }

            return newboard;
        }


        private int GetCellAliveNeighBours(int cellRowPosition, int cellColumnPosition) {

            var neighbourTotal = 0;

            //Set row and column position to start count, if the positions are outsize boundaries these are set to 0
            var rowPosition = cellRowPosition == 0 ? cellRowPosition : cellRowPosition - 1;
            var columnPosition = cellColumnPosition == 0 ? cellColumnPosition : cellColumnPosition - 1;

            for (int i = rowPosition; (i < cellRowPosition + 2) && !(i >= rowCount); i++)
            {

                for (int j = columnPosition; (j < cellColumnPosition + 2) && !(j >= columnCount); j++)
                {
                    //If the current position is the verified cell it is skiped
                    if (i == cellRowPosition && j == cellColumnPosition) continue;

                    neighbourTotal += board[i, j];
                }

            }

            return neighbourTotal;
        }

    }
}
