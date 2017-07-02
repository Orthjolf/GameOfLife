using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GameOfLife
{
    internal class GameField : Canvas
    {
        public HashSet<LifeCell> buffer;
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

        public void setRandom()
        {
            Random rnd = new Random();

            foreach (LifeCell cell in lifeCells) {
                int a = rnd.Next(0,2);
                if (a == 0)
                    cell.dies();
                else
                    cell.lives();
            }
        }

        public void makeNewGeneration()
        {
            for (int x = 0; x < numCellsInRow; x++)
                for (int y = 0; y < numCellsInColumn; y++)
                    lifeCells[x, y].numOfNeighbors = getNumOfNeighbors(x, y);

            for (int x = 0; x < numCellsInRow; x++)
            {
                for (int y = 0; y < numCellsInColumn; y++)
                {
                    if (lifeCells[x,y].alive && (lifeCells[x, y].numOfNeighbors == 2 || lifeCells[x, y].numOfNeighbors == 3)) {
                        lifeCells[x, y].lives();
                    }
                    else lifeCells[x, y].dies();

                    if (!lifeCells[x, y].alive && lifeCells[x, y].numOfNeighbors == 3) {
                        lifeCells[x, y].lives();
                    }              
                }
            }      
        }

        private int getNumOfNeighbors(int x, int y) {
            int numOfNeighbors = 0;
               
            int xMinus1 = (x - 1 < 0) ? numCellsInRow - 1 : x - 1;
            int yMinus1 = (y - 1 < 0) ? numCellsInColumn - 1 : y - 1;
            int xPlus1 = (x + 1 == numCellsInRow) ? 0 : x + 1;
            int yPlus1 = (y + 1 == numCellsInColumn) ? 0 : y + 1;

            if (lifeCells[xMinus1, yMinus1].alive)
                numOfNeighbors++;

            if (lifeCells[xMinus1, y].alive)
                numOfNeighbors++;

            if (lifeCells[xMinus1, yPlus1].alive)
                numOfNeighbors++;

            if (lifeCells[xPlus1, yMinus1].alive)
                numOfNeighbors++;

            if (lifeCells[xPlus1, y].alive)
                numOfNeighbors++;

            if (lifeCells[xPlus1, yPlus1].alive)
                numOfNeighbors++;

            if (lifeCells[x, yPlus1].alive)
                numOfNeighbors++;

            if (lifeCells[x, yMinus1].alive)
                numOfNeighbors++;

            return numOfNeighbors;
        }
    }
}