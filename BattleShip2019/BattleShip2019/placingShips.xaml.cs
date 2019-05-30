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
    /// Logique d'interaction pour placingShips.xaml
    /// </summary>
    public partial class PlacingShips : UserControl
    {
        public event EventHandler Play;

        private Grid[] MyGrid;
        public Ship[] MyShips;


        Path selectedShip;
        Ship myShip;
        Polygon selectedArrow;
        bool horizontalOrientation;

        //private int id;
        private int shipCount;

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

        //RESET

        private void ResetGrid()
        {
            //id = 0;
            foreach (Grid elmt in MyGrid)
            {
                ResetGridElmt(elmt);
                
            }

            Path[] MyPathsShips = new Path[] { submarine1, submarine2, destroyer1, destroyer2, cruiser1, battleship, carrier };
            foreach (Path ship in MyPathsShips)
            {
                ResetBoat(ship);
            }

            selectedShip = null;

            MyShips = new Ship[7];

            ResetOrientation();
        }

        private void ResetOrientation()
        {
            if (selectedArrow != null)
            {
                selectedArrow.Stroke = new SolidColorBrush(Colors.Black);
            }
            btnVertival.BorderBrush = new SolidColorBrush(Colors.White);
            btnHorizontal.BorderBrush = new SolidColorBrush(Colors.Coral);
            horizontalOrientation = true;
        }

        private void ResetBoat(Path ship)
        {
            ship.IsEnabled = true;
            ship.Opacity = 100;
            ship.Stroke = new SolidColorBrush(Colors.Black);
        }

        private void ResetGridElmt(Grid elmt)
        {
            elmt.Tag = "water";
            elmt.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#0094d9"));
        }



        //EVENTS

        private void ship_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Path shipPath = (Path)sender;
            if (!shipPath.IsEnabled)
            {
                return;
            }
            if (selectedShip != null)
            {
                ResetBoat(selectedShip);
            }

            shipPath.Opacity = .95;
            selectedShip = shipPath;
            selectedShip.Stroke = new SolidColorBrush(Colors.WhiteSmoke);
            switch (shipPath.Name)
            {
                case "carrier":
                    myShip = new Carrier(6);
                    break;
                case "battleship":
                    myShip = new Battleship(5);
                    break; 
                case "cruiser1":
                    myShip = new Cruiser(4);
                    break;
                case "destroyer1":
                    myShip = new Destroyer(2);
                    break;
                case "destroyer2":
                    myShip = new Destroyer(3);
                    break;
                case "submarine1":
                    myShip = new Submarine(0);
                    break;
                case "submarine2":
                    myShip = new Submarine(1);
                    break;
            }

        }

        private void btn_orientation(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            btnHorizontal.BorderBrush = new SolidColorBrush(Colors.White);
            btnVertival.BorderBrush = new SolidColorBrush(Colors.White);

            btn.BorderBrush = new SolidColorBrush(Colors.Coral);
            horizontalOrientation = btn.Name.Equals("btnHorizontal");
        }

        private void gridMouseDown(object sender, MouseButtonEventArgs e)
        {
            Grid square = (Grid)sender;
            int index = -1;
            if (!square.Tag.Equals("water"))
            {
                dropShip(square);
                return;
            }
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
            if(checkAvailablePlacement(ref index, true))
            {
                placeShip(index);
                selectedShip.IsEnabled = false;
                selectedShip.Opacity = 0.5;
                selectedShip.Stroke = new SolidColorBrush(Colors.Black);
                selectedShip = null;
                MyShips[myShip.Id] = myShip;
                
                shipCount++;
            }           
        }

        private void dropShip(Grid square)
        {
            if (!square.Tag.Equals("water"))
            {
                int squareId = Int32.Parse(square.Tag.ToString());
                int index = Array.IndexOf(MyGrid, square);
                if (MyShips[squareId] != null && MyShips[squareId].Id == squareId)
                {
                    bool horizontal = MyShips[squareId].Horizontal;
                    int size = MyShips[squareId].Size;
                    switch (squareId)
                    {
                        case 6:
                            ResetBoat(carrier);
                            break;
                        case 5:
                            ResetBoat(battleship);
                            break;
                        case 4:
                            ResetBoat(cruiser1);
                            break;
                        case 3:
                            ResetBoat(destroyer2);
                            break;
                        case 2:
                            ResetBoat(destroyer1);
                            break;
                        case 1:
                            ResetBoat(submarine2);
                            break;
                        case 0:
                            ResetBoat(submarine1);
                            break;
                    }

                    MyShips[squareId] = null;

                    dropGraphicShip(index, squareId, horizontal, size);
                    shipCount--;
                }
                else
                {
                    MessageBox.Show("Operation failed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void dropGraphicShip(int index, int id, bool horizontal, int size)
        {
            int counter = 0;
            int X = index / 10;

            int incr = 1;
            int max = (X + 1) * 10;
            if (!horizontal)
            {
                incr = 10;
                max = 100;
            }

            for (int i = 0; i < size * incr; i += incr)
            {
                if (index + i < max && MyGrid[index + i].Tag.Equals(id))
                {
                    MyGrid[index + i].Tag = "water";
                    MyGrid[index + i].Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#0094d9"));
                }
                else
                {
                    counter+=incr;
                    if (index - counter > 0 && MyGrid[index - counter].Tag.Equals(id))
                    {
                        MyGrid[index - counter].Tag = "water";
                        MyGrid[index - counter].Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#0094d9"));
                    }
                }
            }
        }

        private bool checkAvailablePlacement(ref int index, bool errorPopUp)
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
                        if (index + i < (X + 1) * 10)
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
                    if(errorPopUp)
                        MessageBox.Show(iore.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else //for orientation down
            {
                try
                {
                    for (int i = 0; i < size * 10; i += 10)
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
                    if (errorPopUp)
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
           
            int X = index / 10;
            int size = myShip.Size;
            if (horizontalOrientation)
            {
                for (int i = 0; i < size; i++)
                {
                    if (index + i <= (X + 1) * 10)
                    {
                        MyGrid[index + i].Tag = myShip.Id;
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
                        MyGrid[index + i].Tag = myShip.Id;
                        MyGrid[index + i].Background = myShip.ShipColor;
                    }
                    else
                    {
                        MessageBox.Show("Vertical Error Index=" + index + " and i=" + i + ".", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                   
                }
            }
            myShip.SetCoordinates(index, horizontalOrientation);
        }

        /// <summary>
        /// Button Submit : Submit the page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (shipCount != 7)
            {
                return;
            }

           // Play(this, e);
            Play(this, e);
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

        private void btn_RandomClick(object sender, RoutedEventArgs e)
        {
            ResetGrid();
            MyShips = new Ship[7] { new Submarine(0), new Submarine(1), new Destroyer(2), new Destroyer(3), new Cruiser(4), new Battleship(5), new Carrier(6)};
            Path[] MyPathsShips = new Path[] { submarine1, submarine2, destroyer1, destroyer2, cruiser1, battleship, carrier };
            foreach (Path ship in MyPathsShips)
            {
                ship.IsEnabled = false;
                ship.Opacity = 0.5;
                ship.Stroke = new SolidColorBrush(Colors.Black);
            }
            Random random = new Random();
            for(int i = 0; i < MyShips.Length; i++)
            {
                int index = random.Next(0, 100);
                horizontalOrientation = random.Next(0, 2) == 1 ? true: false;
                myShip = MyShips[i];
                while(!checkAvailablePlacement(ref index, false))
                {
                    index = random.Next(0, 100);
                }
                placeShip(index);
                MyShips[myShip.Id] = myShip;
            }
            shipCount = 7;
            ResetOrientation();
        }

    }
}

    