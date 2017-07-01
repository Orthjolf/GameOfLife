using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GameOfLife
{
    internal class GameField
    {
        private int numCellsInRow;
        private int numCellsInColumn;
        const int lifeCellSize = 5;

        LifeCell[,] field;

        Canvas canvasGameField;

        public GameField(Canvas canvasGameField)
        {
            this.canvasGameField = canvasGameField;
            numCellsInRow = (int)canvasGameField.Width / (lifeCellSize + 1);
            numCellsInColumn = (int)canvasGameField.Height / (lifeCellSize + 1);

            field = new LifeCell[numCellsInRow, numCellsInColumn];
        }

        public void draw() {
            for (int x = 0; x < numCellsInRow; x++)
            {
                for (int y = 0; y < numCellsInColumn; y++)
                {
                    LifeCell cell = new LifeCell(x, y);
                    cell.draw(canvasGameField);
                    field[x, y] = cell;
                }
            }
        }

        public void makeNewGeneration()
        {
            int[,] numOfNeighbors = new int[numCellsInRow, numCellsInColumn];

            for (int x = 0; x < numCellsInRow; x++)
            {
                for (int y = 0; y < numCellsInColumn; y++)
                {
                    int neighbour = 0;

                    int xMinus1 = (x - 1 < 0) ? numCellsInRow - 1 : x - 1;
                    int yMinus1 = (y - 1 < 0) ? numCellsInColumn - 1 : y - 1;
                    int xPlus1 = (x + 1 == numCellsInRow) ? 0 : x + 1;
                    int yPlus1 = (y + 1 == numCellsInColumn) ? 0 : y + 1;

                    if (field[xMinus1, yMinus1].alive)
                        neighbour++;

                    if (field[xMinus1, y].alive)
                        neighbour++;

                    if (field[xMinus1, yPlus1].alive)
                        neighbour++;

                    if (field[xPlus1, yMinus1].alive)
                        neighbour++;

                    if (field[xPlus1, y].alive)
                        neighbour++;

                    if (field[xPlus1, yPlus1].alive)
                        neighbour++;

                    if (field[x, yPlus1].alive)
                        neighbour++;

                    if (field[x, yMinus1].alive)
                        neighbour++;

                    numOfNeighbors[x, y] = neighbour;
                }
            }
        }

        private int getNumOfNeighbors(int i, int j) {
            int numOfNeighbors = 0;

            return numOfNeighbors;
        }

        private void R_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ((Rectangle)sender).Fill = Brushes.Black;
        }

    }
}