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
        private GameField gameField;

        public MainWindow()
        {
            InitializeComponent();

            gameField = new GameField(CanvasGameField);
            gameField.draw();
            //@TODO: запускам новый поток, если игра не на паузе, то по кд генерим новые поколения
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
          
        }

  
        private void NextGenButton_Click(object sender, RoutedEventArgs e)
        {
            gameField.makeNewGeneration();
        }         
    }
}
