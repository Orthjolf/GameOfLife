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
        public static int size = 5;
        public Rectangle body;
        public bool alive = false;
        public int numbeOfNeighbors;
        public Vector position;
     
        public LifeCell(int x, int y)
        {
            this.position.X = x * size;
            this.position.Y = y * size;

            body = new Rectangle();
            body.Width = size;
            body.Height = size;
            
            Canvas.SetLeft(body, x * (size + 1));
            Canvas.SetTop(body, y * (size + 1));
            body.MouseDown += changeState;
        }

        public void changeState(object sender, MouseButtonEventArgs e) {
            alive = !alive;
            setColor(alive);
        }

        public void dies() {
            alive = false;
            setColor(alive);
        }

        public void reborn() {
            alive = true;
            setColor(alive);
        }

        public void setColor(bool alive) {
            body.Fill = alive ? Brushes.Blue : Brushes.White;
        }

        public void draw(Canvas GameField) {
            body.Fill = Brushes.White;
            GameField.Children.Add(body);
        }

    }
}