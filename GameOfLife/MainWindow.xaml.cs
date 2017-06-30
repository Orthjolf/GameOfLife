using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameOfLife
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int cellSize = 5;
        int numCellsInRow;
        int numCellsInColumn;

        public MainWindow()
        {
            InitializeComponent();

            numCellsInRow = (int)GameField.Width / (cellSize + 1);
            numCellsInColumn = (int)GameField.Height / (cellSize + 1);
        }

       

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            

            for (int i = 0; i < numCellsInColumn; i++) {
                for (int j = 0; j < numCellsInRow; j++) {
                    Rectangle cell = new Rectangle();
                    cell.Width = cellSize;
                    cell.Height = cellSize;
                    cell.Fill = Brushes.White;      
                 
                    GameField.Children.Add(cell);
                    Canvas.SetLeft(cell, j * (cellSize+1));
                    Canvas.SetTop(cell, i * (cellSize+1));
                    cell.MouseDown += R_MouseDown;
                }
            }
            Console.Write(numCellsInColumn+","+ numCellsInRow);
        }

        private void R_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ((Rectangle)sender).Fill = (((Rectangle)sender).Fill == Brushes.White) ? Brushes.Blue : Brushes.White;
        }

        private void NextGenButton_Click(object sender, RoutedEventArgs e)
        {
            int[,] numOfNeighbors = new int[numCellsInRow,numCellsInColumn];

            for (int i = 0; i < numCellsInColumn; i++)
            {
                for (int j = 0; j < numCellsInRow; j++)
                {
                    int neighbour=0;
                    if () {
                        neighbour++;
                    }

                    numOfNeighbors[i, j] = neighbour;
                }
            }
        }
    }
}
