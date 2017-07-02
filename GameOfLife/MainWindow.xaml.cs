using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GameOfLife
{
    /*@
     * @Description:
     *      Тестовое задание "Игра жизнь"
     * @Author:
     *      Novitsky Wilhelm 01.07.2017
     * @*/
    public partial class MainWindow : Window
    {
        private const int gameSpeed = 100;

        private GameField gameField;
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            gameField = new GameField(CanvasGameField);
            gameField.draw();
 
          
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(gameSpeed);
            timer.Tick += NextGen;
        }

        private void NextGen(object sender, EventArgs e)
        {
            gameField.makeNewGeneration();
        }

        private void RunLife(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void SetPause(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void NextGenButton_Click(object sender, RoutedEventArgs e)
        {
            if(!timer.IsEnabled)
                gameField.makeNewGeneration();
        }         
    }
}
