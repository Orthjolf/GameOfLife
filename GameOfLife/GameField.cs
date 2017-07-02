using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GameOfLife
{
    internal class GameField : Canvas
    {
        private int numCellsInRow;
        private int numCellsInColumn;

        private LifeCell[,] lifeCells;
        private Canvas canvasGameField;

        public GameField(Canvas canvasGameField)
        {
            this.canvasGameField = canvasGameField;
            numCellsInRow = (int)canvasGameField.Width / (LifeCell.size + 1);
            numCellsInColumn = (int)canvasGameField.Height / (LifeCell.size + 1);

            lifeCells = new LifeCell[numCellsInRow, numCellsInColumn];
        }

        public void draw() {
            for (int x = 0; x < numCellsInRow; x++)
            {
                for (int y = 0; y < numCellsInColumn; y++)
                {
                    LifeCell cell = new LifeCell(x, y);
                    cell.draw(canvasGameField);
                    lifeCells[x, y] = cell;
                }
            }
        }

        public void makeNewGeneration()
        {
            int[,] numOfNeighbors = new int[numCellsInRow, numCellsInColumn];

            for (int x = 0; x < numCellsInRow; x++)
                for (int y = 0; y < numCellsInColumn; y++)
                    lifeCells[x, y].numbeOfNeighbors = getNumOfNeighbors(x, y);

            for (int x = 0; x < numCellsInRow; x++)
            {
                for (int y = 0; y < numCellsInColumn; y++)
                {
                    if (lifeCells[x,y].alive && (lifeCells[x, y].numbeOfNeighbors == 2 || lifeCells[x, y].numbeOfNeighbors == 3)) {
                        lifeCells[x, y].reborn();
                    }
                    else lifeCells[x, y].dies();

                    if (!lifeCells[x, y].alive && numOfNeighbors[x, y] == 3) {
                        lifeCells[x, y].reborn();
                    }
                }
            }      
        }

        private int getNumOfNeighbors(int x, int y) {
            lifeCells[x, y].numbeOfNeighbors = 0;
       
            
            int xMinus1 = (x - 1 < 0) ? numCellsInRow - 1 : x - 1;
            int yMinus1 = (y - 1 < 0) ? numCellsInColumn - 1 : y - 1;
            int xPlus1 = (x + 1 == numCellsInRow) ? 0 : x + 1;
            int yPlus1 = (y + 1 == numCellsInColumn) ? 0 : y + 1;

            if (lifeCells[xMinus1, yMinus1].alive)
                lifeCells[x, y].numbeOfNeighbors++;

            if (lifeCells[xMinus1, y].alive)
                lifeCells[x, y].numbeOfNeighbors++;

            if (lifeCells[xMinus1, yPlus1].alive)
                lifeCells[x, y].numbeOfNeighbors++;

            if (lifeCells[xPlus1, yMinus1].alive)
                lifeCells[x, y].numbeOfNeighbors++;

            if (lifeCells[xPlus1, y].alive)
                lifeCells[x, y].numbeOfNeighbors++;

            if (lifeCells[xPlus1, yPlus1].alive)
                lifeCells[x, y].numbeOfNeighbors++;

            if (lifeCells[x, yPlus1].alive)
                lifeCells[x, y].numbeOfNeighbors++;

            if (lifeCells[x, yMinus1].alive)
                lifeCells[x, y].numbeOfNeighbors++;

            return lifeCells[x, y].numbeOfNeighbors;
        }


    }
}