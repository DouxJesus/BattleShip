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
    /// Logique d'interaction pour PlayGame.xaml
    /// </summary>
    public partial class PlayGame : UserControl
    {

        public event EventHandler Next;

        Grid[] MyGrid;
        Grid[] OppGrid;

        int deadShips;

        Grid selectedGrid;

        public PlayGame(string playername, Ship[] ships, Ship[] oppShips)
        {
            InitializeComponent();
            InitializeGrid();
            LabelPlayer.Content = playername.ToUpper();
            DrawShips(ships, false);
            DrawShips(oppShips, true);
        }

        private void InitializeGrid()
        {
            MyGrid = new Grid[] { myGridA1, myGridA2, myGridA3, myGridA4, myGridA5, myGridA6, myGridA7, myGridA8, myGridA9, myGridA10,
                myGridB1, myGridB2, myGridB3, myGridB4, myGridB5, myGridB6, myGridB7, myGridB8, myGridB9, myGridB10,
                myGridC1, myGridC2, myGridC3, myGridC4, myGridC5, myGridC6, myGridC7, myGridC8, myGridC9, myGridC10,
                myGridD1, myGridD2, myGridD3, myGridD4, myGridD5, myGridD6, myGridD7, myGridD8, myGridD9, myGridD10,
                myGridE1, myGridE2, myGridE3, myGridE4, myGridE5, myGridE6, myGridE7, myGridE8, myGridE9, myGridE10,
                myGridF1, myGridF2, myGridF3, myGridF4, myGridF5, myGridF6, myGridF7, myGridF8, myGridF9, myGridF10,
                myGridG1, myGridG2, myGridG3, myGridG4, myGridG5, myGridG6, myGridG7, myGridG8, myGridG9, myGridG10,
                myGridH1, myGridH2, myGridH3, myGridH4, myGridH5, myGridH6, myGridH7, myGridH8, myGridH9, myGridH10,
                myGridI1, myGridI2, myGridI3, myGridI4, myGridI5, myGridI6, myGridI7, myGridI8, myGridI9, myGridI10,
                myGridJ1, myGridJ2, myGridJ3, myGridJ4, myGridJ5, myGridJ6, myGridJ7, myGridJ8, myGridJ9, myGridJ10 };

            OppGrid = new Grid[]{oppGridA1 ,oppGridA2 ,oppGridA3 ,oppGridA4 ,oppGridA5 ,oppGridA6 ,oppGridA7 ,oppGridA8 ,oppGridA9 ,oppGridA10 ,
                oppGridB1 ,oppGridB2 ,oppGridB3 ,oppGridB4 ,oppGridB5 ,oppGridB6 ,oppGridB7 ,oppGridB8 ,oppGridB9 ,oppGridB10 ,
                oppGridC1 ,oppGridC2 ,oppGridC3 ,oppGridC4 ,oppGridC5 ,oppGridC6 ,oppGridC7 ,oppGridC8 ,oppGridC9 ,oppGridC10 ,
                oppGridD1 ,oppGridD2 ,oppGridD3 ,oppGridD4 ,oppGridD5 ,oppGridD6 ,oppGridD7 ,oppGridD8 ,oppGridD9 ,oppGridD10 ,
                oppGridE1 ,oppGridE2 ,oppGridE3 ,oppGridE4 ,oppGridE5 ,oppGridE6 ,oppGridE7 ,oppGridE8 ,oppGridE9 ,oppGridE10 ,
                oppGridF1 ,oppGridF2 ,oppGridF3 ,oppGridF4 ,oppGridF5 ,oppGridF6 ,oppGridF7 ,oppGridF8 ,oppGridF9 ,oppGridF10 ,
                oppGridG1 ,oppGridG2 ,oppGridG3 ,oppGridG4 ,oppGridG5 ,oppGridG6 ,oppGridG7 ,oppGridG8 ,oppGridG9 ,oppGridG10 ,
                oppGridH1 ,oppGridH2 ,oppGridH3 ,oppGridH4 ,oppGridH5 ,oppGridH6 ,oppGridH7 ,oppGridH8 ,oppGridH9 ,oppGridH10 ,
                oppGridI1 ,oppGridI2 ,oppGridI3 ,oppGridI4 ,oppGridI5 ,oppGridI6 ,oppGridI7 ,oppGridI8 ,oppGridI9 ,oppGridI10 ,
                oppGridJ1 ,oppGridJ2 ,oppGridJ3 ,oppGridJ4 ,oppGridJ5 ,oppGridJ6 ,oppGridJ7 ,oppGridJ8 ,oppGridJ9 ,oppGridJ10 };

            foreach (Grid grid in OppGrid)
            {
                ResetGridElmt(grid);

            }
            foreach (Grid grid in MyGrid)
            {
                ResetGridElmt(grid);
            }
        }

        private void DrawShips(Ship[] ships, bool opponent)
        {
            foreach(Ship ship in ships)
            {
                DrawShip(ship, opponent);
            }
        }

        private void DrawShip(Ship ship, bool opponent)
        {
            int index = ship.Index;
            bool horizontalOrientation = ship.Horizontal;
            int X = index / 10;
            int size = ship.Size;
            if (horizontalOrientation)
            {
                for (int i = 0; i < size; i++)
                {
                    if (index + i <= (X + 1) * 10)
                    {
                        if (!opponent)
                        {
                            MyGrid[index + i].Tag = ship.Id;
                            MyGrid[index + i].Background = ship.ShipColor;
                        }
                        else
                        {
                            OppGrid[index + i].Tag = ship.Id;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Horizontal Error Index=" + index + " and i=" + i + ".", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
            }
            else
            {
                for (int i = 0; i < ship.Size * 10; i += 10)
                {
                    if (index + i <= 99)
                    {
                        if (!opponent)
                        {
                            MyGrid[index + i].Tag = ship.Id;
                            MyGrid[index + i].Background = ship.ShipColor;
                        }
                        else
                        {
                            OppGrid[index + i].Tag = ship.Id;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vertical Error Index=" + index + " and i=" + i + ".", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                }
            }
        }

        private void ResetGridElmt(Grid elmt)
        {
            elmt.Tag = "water";
            elmt.IsEnabled = true;
            elmt.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#0094d9"));
        }

        private void oppGridMouseDown(object sender, EventArgs e)
        {
            Grid grid = (Grid)sender;

            if(grid.IsEnabled)
            {
                int index = Array.IndexOf(OppGrid, grid);
                int col = index % 10;
                char row = (char) ('A'+ index / 10);
                if(selectedGrid != null)
                {
                    selectedGrid.IsEnabled = true;
                    selectedGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#0094d9"));

                }
                selectedGrid = grid;
                selectedGrid.IsEnabled = false;
                selectedGrid.Background = new SolidColorBrush(Colors.Coral);
                //MessageBox.Show("Col:" + col + " row:" + row, "You clicked", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btn_Submit(object sender, EventArgs e)
        {
            if (selectedGrid != null)
            {
                if (selectedGrid.Tag.Equals("water"))
                {
                    selectedGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#2513C3"));
                    selectedGrid.IsEnabled = false;
                    MessageBox.Show("Flop! It's water", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    selectedGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#13C35A"));
                    selectedGrid.IsEnabled = false;
                    MessageBox.Show("Touch", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                selectedGrid = null;
                Next(this, e);
                Next = null;
            }
        }

    }
}
