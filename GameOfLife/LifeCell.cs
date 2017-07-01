using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GameOfLife
{
    public class LifeCell : UIElement
    {
        private int size = 5;
        public bool alive = false;
        public int numbeOfNeighbors;
        public Vector position;
        Brush brush;
        public Rectangle body;

        public LifeCell(int x, int y)
        {
            this.position.X = x * size;
            this.position.Y = y * size;

            body = new Rectangle();
            body.Width = size;
            body.Height = size;
            body.Fill = Brushes.Black;

            Canvas.SetLeft(body, x * (size + 1));
            Canvas.SetTop(body, y * (size + 1));
            body.MouseDown += changeState;
        }

        public void changeState(object sender, MouseButtonEventArgs e) {
            alive = !alive;
            body.Fill = alive ? Brushes.Green : Brushes.Black; 
            Console.Write(alive?"Жив\n":"Мертв\n");
        }

        public void draw(Canvas GameField) {
            GameField.Children.Add(body);
        }

    }
}