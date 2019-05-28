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

namespace BattleShip2019
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Grid Window = new Grid();

        PlacingShips placingShips;
        public MainWindow()
        {
            
            InitializeComponent();
            Content = Window;

            placingShips = new PlacingShips();
            Window.Children.Add(placingShips);

        }

        //private void OnButtonClick(object sender, RoutedEventArgs e)
        //{
        //    Button btn = (Button) sender;
        //    string name = btn.Name;
        //    int x = name[3] - '0';
        //    int y = name[4] - 'A';

        //}
    }
}
