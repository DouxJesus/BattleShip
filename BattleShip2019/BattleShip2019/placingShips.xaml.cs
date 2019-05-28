﻿using System;
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
    /// Logique d'interaction pour placingShips.xaml
    /// </summary>
    public partial class PlacingShips : UserControl
    {
        public event EventHandler play;

        private Grid[] MyGrid;
        private List<Ship> MyShips;

        Path selectedShip;
        Ship myShip;
        Polygon selectedArrow;
        bool horizontalOrientation;

        private int id;

        //Universal Color Code
        SolidColorBrush colorOnSelect =  new SolidColorBrush(Colors.Coral);
        SolidColorBrush colorNotSelected = new SolidColorBrush(Colors.Black);
        SolidColorBrush colorPlacedShip = new SolidColorBrush(Colors.LawnGreen);

        public PlacingShips()
        {
            InitializeComponent();
            MyGrid = new Grid[] { gridA1, gridA2, gridA3, gridA4, gridA5, gridA6, gridA7,gridA8,gridA9,gridA10,
                                gridB1, gridB2, gridB3, gridB4, gridB5, gridB6, gridB7,gridB8,gridB9,gridB10,
                                gridC1, gridC2, gridC3, gridC4, gridC5, gridC6, gridC7,gridC8,gridC9,gridC10,
                                gridD1, gridD2, gridD3, gridD4, gridD5, gridD6, gridD7,gridD8,gridD9,gridD10,
                                gridE1, gridE2, gridE3, gridE4, gridE5, gridE6, gridE7,gridE8,gridE9,gridE10,
                                gridF1, gridF2, gridF3, gridF4, gridF5, gridF6, gridF7,gridF8,gridF9,gridF10,
                                gridG1, gridG2, gridG3, gridG4, gridG5, gridG6, gridG7,gridG8,gridG9,gridG10,
                                gridH1, gridH2, gridH3, gridH4, gridH5, gridH6, gridH7,gridH8,gridH9,gridH10,
                                gridI1, gridI2, gridI3, gridI4, gridI5, gridI6, gridI7,gridI8,gridI9,gridI10,
                                gridJ1, gridJ2, gridJ3, gridJ4, gridJ5, gridJ6, gridJ7,gridJ8,gridJ9,gridJ10 };  
            
            ResetGrid();

        }

        private void ResetGrid()
        {
            id = 0;
            foreach (Grid elmt in MyGrid)
            {
                elmt.Tag = "water";
                elmt.Background = (SolidColorBrush) (new BrushConverter().ConvertFrom("#0094d9"));
            }

            Path[] MyPathsShips = new Path[] { submarine1, submarine2, destroyer1, destroyer2, cruiser1, battleship, carrier };
            foreach (Path ship in MyPathsShips)
            {
                ship.IsEnabled = true;
                ship.Opacity = 100;
            }
            if(selectedShip != null)
            {
                selectedShip.Stroke = new SolidColorBrush(Colors.Black);
            }
            selectedShip = null;

            MyShips = new List<Ship>();

            if (selectedArrow != null)
            {
                selectedArrow.Stroke = new SolidColorBrush(Colors.Black);
            }
            selectedArrow = rightPoly;
            horizontalOrientation = true;
            rightPoly.Stroke = new SolidColorBrush(Colors.WhiteSmoke);

        }


        private void ship_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Path shipPath = (Path)sender;
            if (!shipPath.IsEnabled)
            {
                return;
            }
            if (selectedShip != null)
            {
                selectedShip.Opacity = 100;
                selectedShip.Stroke = new SolidColorBrush(Colors.Black);
            }

            shipPath.Opacity = .95;
            selectedShip = shipPath;
            selectedShip.Stroke = new SolidColorBrush(Colors.WhiteSmoke);
            switch (shipPath.Name)
            {
                case "carrier":
                    myShip = new Carrier(id);
                    break;
                case "battleship":
                    myShip = new Battleship(id);
                    break; 
                case "cruiser1":
                case "cruiser2":
                    myShip = new Cruiser(id);
                    break;
                case "destroyer":
                    myShip = new Destroyer(id);
                    break;
                case "submarine1":
                case "submarine2":
                    myShip = new Submarine(id);
                    break;
            }

        }

        private void orientationMouseDown(object sender, MouseButtonEventArgs e)
        {
            Polygon arrow = (Polygon)sender;

            selectedArrow.Stroke = colorNotSelected;
            selectedArrow = arrow;
            arrow.Stroke = colorOnSelect;
            horizontalOrientation = arrow.Name.Equals("rightPoly") || arrow.Name.Equals("leftPoly");
        }

        private void gridMouseDown(object sender, MouseButtonEventArgs e)
        {
            Grid square = (Grid)sender;
            int index = -1;
            if (selectedShip == null)
            {
                MessageBox.Show("You must choose a ship", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!square.Tag.Equals("water"))
            {
                return;
            }
            
            index = Array.IndexOf(MyGrid, square);
            if(checkAvailablePlacement(ref index))
            {
                placeShip(index);
                selectedShip.IsEnabled = false;
                selectedShip.Opacity = 0.5;
                selectedShip = null;
                MyShips.Add(myShip);
                id++;
            }           
        }

        private bool checkAvailablePlacement(ref int index)
        {
            int counter = 0;
            int X = index / 10;
            int size = myShip.Size;
            if (horizontalOrientation)
            {
                try
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (index + i <= (X + 1) * 10)
                        {
                            if (!MyGrid[index + i].Tag.Equals("water"))
                            {
                                throw new IndexOutOfRangeException("Invalid ship placement, not enough space!");
                            }
                        }
                        else
                        {
                            counter++;
                            if (index - counter < 0 || !MyGrid[index - counter].Tag.Equals("water"))
                            {
                                throw new IndexOutOfRangeException("Invalid ship placement");
                            }    
                        }

                    }
                  
                }
                catch (IndexOutOfRangeException iore)
                {
                    MessageBox.Show(iore.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else //for orientation down
            {
                try
                {
                    for (int i = 0; i < myShip.Size * 10; i += 10)
                    {
                        if (index + i <= 99)
                        {
                            if (!MyGrid[index + i].Tag.Equals("water"))
                            {
                                throw new IndexOutOfRangeException("Invalid ship placement!");
                            }
                        }
                        else
                        {
                            counter += 10;
                            if (index - counter < 0 || !MyGrid[index - counter].Tag.Equals("water"))
                            {
                                throw new IndexOutOfRangeException("Invalid ship placement!");
                            }                        
                        }
                    }
                    if ((index / 10) + (myShip.Size * 10) > 100)
                    {
                        throw new IndexOutOfRangeException("Invalid ship placement, not enough space!");
                    }
                }
                catch (IndexOutOfRangeException iore)
                {
                    MessageBox.Show(iore.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            index -= counter;
            return true;
        }

        /// <summary>
        /// Place the selected ship on the grid
        /// </summary>
        /// <param name="index"></param>
        private void placeShip(int index)
        {
            myShip.SetCoordinates(index, horizontalOrientation);
            int X = index / 10;
            int size = myShip.Size;
            if (horizontalOrientation)
            {
                for (int i = 0; i < myShip.Size; i++)
                {
                    if (index + i <= (X + 1) * 10)
                    {
                        MyGrid[index + i].Tag = myShip.Name();
                        MyGrid[index + i].Background = myShip.ShipColor;
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
                for (int i = 0; i < myShip.Size * 10; i += 10)
                {
                    if (index + i <= 99)
                    {
                        MyGrid[index + i].Tag = myShip.Name();
                        MyGrid[index + i].Background = myShip.ShipColor;
                    }
                    else
                    {
                        MessageBox.Show("Vertical Error Index=" + index + " and i=" + i + ".", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                   
                }
            }
        }

        /// <summary>
        /// Button Submit : Submit the page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (MyShips.Count != 7)
            {
                return;
            }
            play(this, e);
        }

        /// <summary>
        /// Reset button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetGrid();
        }


    }
}

    