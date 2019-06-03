using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
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

        public Grid[] MyGrid;
        public Grid[] OppGrid;

        public Ship[] oppShips;

        public int deadShips;

        string playername;

        //Communication Variables
        public string UpdateData;
        public int LastIndexShoot;

        //Image imgWater;
        //Image imgFire;

        public Grid selectedGrid;

        //BOT
        bool TouchedABoat;
        int lastAttack;
        int nextOrientation;
        int phase;


        public void resetNext()
        {
            Next = null;
        }

        public PlayGame(string playername, Ship[] ships, Ship[] oppShips)
        {
            InitializeComponent();
            this.playername = playername.ToUpper();
            UpdateData = "";
            LabelPlayer.Content = this.playername;
            this.oppShips = oppShips;
            deadShips = 0;
            LastIndexShoot = -1;

            //for bot
            this.TouchedABoat = false;
            this.lastAttack = -1;
            this.nextOrientation = 1;
            this.phase = 0;

            InitializeGrid();
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

        private void IsGameOver()
        {
            throw new NotImplementedException();
        }

        private void DrawShips(Ship[] ships, bool opponent)
        {
            foreach(Ship ship in ships)
            {
                if(opponent)
                    DrawShip(ship, OppGrid, true);
                else
                    DrawShip(ship, MyGrid, false);
            }
        }

        private void DrawShip(Ship ship, Grid[] grid, bool hiddenShip)
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
                        if (!hiddenShip)
                        {
                            grid[index + i].Tag = ship.Id;
                            grid[index + i].Background = ship.ShipColor;
                        }
                        else
                        {
                            grid[index + i].Tag = ship.Id;
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
                        if (!hiddenShip)
                        {
                            grid[index + i].Tag = ship.Id;
                            grid[index + i].Background = ship.ShipColor;
                        }
                        else
                        {
                            grid[index + i].Tag = ship.Id;
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

            //Double click
            if(grid == selectedGrid)
            {
                Shot();
                selectedGrid = null;
                if(Next != null)
                    Next(this, e);
                
            }
            else if(grid.IsEnabled)
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
                selectedGrid.Background = new SolidColorBrush(Colors.Coral);
            }

        }


        //bool TouchedABoat;
        //int lastAttack;
        //int nextOrientation;
        //int hitCount;
        //for bot
        //this.TouchedABoat = false;
        //this.lastAttack = -1;
        //this.nextOrientation = 1;
        //this.phase = 0;   //Phase 0 first shot Phase 1 figuring out orientation - phase 2 orientation is known shoot down the boat - phase 3 boat is dead reset to phase 0 and shoot random
        int knownOrientation = -1;
        int lastShipCount = 0;
        bool hasKilled = false;
        int hitCount = 0;
        int phase1InitialShot = 0;
        public void Attack()
        {
            if(lastShipCount < deadShips)
            {
                hasKilled = true;
                lastShipCount = deadShips;
                knownOrientation = -1;
                nextOrientation = 1;
                phase = 0;
                hitCount = 0;
            } else
            {
                hasKilled = false;
            }
            int index = -1;
            this.TouchedABoat = (lastAttack != -1 && !OppGrid[lastAttack].Tag.Equals("water"));
            Console.WriteLine("Touched a boat " + TouchedABoat);
            if ((TouchedABoat || phase > 0) && !hasKilled)       //Bot touched a boat or in phase superior than 0, target next smart move
            {
                bool shotmade = false;
                while (!shotmade)
                {
                    switch (phase)
                    { 
                        case 0:
                            phase = 1;
                            phase1InitialShot = lastAttack;
                            break;
                        case 1:
                            if (TouchedABoat)    //We figured out which orientation it is
                            {
                                phase = 2;
                                if (nextOrientation == 1 || nextOrientation == 3)   //vertical
                                {
                                    knownOrientation = 2;
                                }
                                else            //horizontal
                                {
                                    knownOrientation = 1;
                                }
                            }
                            else                  //looking for orientation
                            {
                                if (lastAttack != phase1InitialShot) //When in phase 1 we shot and got in water -> try next orientation
                                {
                                    nextOrientation++;
                                }
                                bool decided = false;
                                while (!decided)
                                {
                                    switch (this.nextOrientation)
                                    {
                                        case 1: //case up
                                            if ((phase1InitialShot - 10) < 0) //cant shoot futher up -> 
                                            {
                                                nextOrientation++;
                                            }
                                            else
                                            {
                                                index = phase1InitialShot - 10;
                                                decided = true;
                                            }
                                            break;
                                        case 2: //case right
                                            if ((phase1InitialShot + 1) % 10 < phase1InitialShot) //cant shoot futher right -> 
                                            {
                                                nextOrientation++;
                                            }
                                            else
                                            {
                                                index = phase1InitialShot + 1;
                                                decided = true;
                                            }
                                            break;
                                        case 3: //case down
                                            if ((phase1InitialShot + 10) < 100) //cant shoot futher down -> 
                                            {
                                                nextOrientation++;
                                            }
                                            else
                                            {
                                                index = phase1InitialShot + 10;
                                                decided = true;
                                            }
                                            break;
                                        case 4: //case down
                                            if ((phase1InitialShot - 1) % 10 > phase1InitialShot) //cant shoot futher right // This case should not happen except for submarine
                                            {
                                                nextOrientation++;
                                                Console.WriteLine("Hoho something wrong happen");
                                            }
                                            else
                                            {
                                                index = phase1InitialShot - 1;
                                                decided = true;
                                            }
                                            break;

                                    }
                                }
                                shotmade = true;
                            }
                            break;
                        case 2:
                            if (knownOrientation == 2) //Its vertical
                            {
                                bool decided = false;
                                while (!decided)
                                {
                                    if (TouchedABoat) //Keep shooting 
                                    {
                                        if (nextOrientation == 1) //shooting up
                                        {
                                            if (lastAttack - 10 > 0)
                                            {
                                                index = lastAttack - 10;
                                                decided = true;
                                            }
                                            else //we reach the edge of the map and therefore of the boat change orientation
                                            {
                                                nextOrientation = 3;
                                                lastAttack = phase1InitialShot;
                                            }
                                        }
                                        else //shooting down
                                        {
                                            if (lastAttack + 10 < 100)
                                            {
                                                index = lastAttack + 10;
                                                decided = true;
                                            }
                                            else //we reach the edge of the map and therefore of the boat change
                                            {
                                                nextOrientation = 1;
                                                lastAttack = phase1InitialShot;
                                            }
                                        }
                                    }
                                    else //We hit the water in phase 2 -> it means we reach the edge of the target -> change orientation and go back to initial hit
                                    {
                                        if (nextOrientation == 1) //switch to down
                                        {
                                            nextOrientation = 3;
                                        } else if (nextOrientation == 3) //switch to up
                                        {
                                            nextOrientation = 1;
                                        }
                                    }
                                }
                            }
                            else                    //Its horizontal
                            {
                                bool decided = false;
                                while (!decided)
                                {
                                    if (TouchedABoat) //Keep shooting 
                                    {
                                        if (nextOrientation == 2) //shooting left
                                        {
                                            if ((lastAttack + 1) % 10 < lastAttack)
                                            {
                                                index = lastAttack + 1;
                                                decided = true;
                                            }
                                            else //we reach the edge of the map and therefore of the boat change orientation
                                            {
                                                nextOrientation = 4;
                                                lastAttack = phase1InitialShot;
                                            }
                                        }
                                        else //shooting down
                                        {
                                            if ((lastAttack - 1) % 10 > lastAttack)
                                            {
                                                index = lastAttack - 1;
                                                decided = true;
                                            }
                                            else //we reach the edge of the map and therefore of the boat change
                                            {
                                                nextOrientation = 2;
                                                lastAttack = phase1InitialShot;
                                            }
                                        }
                                    }
                                    else //We hit the water in phase 2 -> it means we reach the edge of the target -> change orientation and go back to initial hit
                                    {
                                        if (nextOrientation == 2) //switch to right
                                        {
                                            nextOrientation = 4;
                                        }
                                        else if (nextOrientation == 4) //switch to left
                                        {
                                            nextOrientation = 2;
                                        }
                                    }
                                }
                            }
                            shotmade = true; ;
                            break;
                    }
                }
                
                

                     
            }
            else                    //Else target random
            { 
                Random random = new Random();
                index = random.Next(0, 100);
                while (!OppGrid[index].IsEnabled)
                {
                    index = random.Next(0, 100);
                }

            }
            
            this.selectedGrid = OppGrid[index];
            Shot();
            this.lastAttack = index;
            //To talk to playgame
            LastIndexShoot = index;
        }

        public void GameUpdate()
        {
            Notifications.Text += UpdateData;

            if(LastIndexShoot > 0 && LastIndexShoot < 100)
            {
                if (MyGrid[LastIndexShoot].Tag.Equals("water"))
                {
                    MyGrid[LastIndexShoot].Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D3ECFD"));
                    Uri fileUri = new Uri("/Content/img_waves.png", UriKind.Relative);
                    Image imgWater = new Image();
                    imgWater.Source = new BitmapImage(fileUri);

                    MyGrid[LastIndexShoot].Children.Add(imgWater);
                }
                else
                {
                    Uri fileUri = new Uri("/Content/redcross.png", UriKind.Relative);
                    Image imgFire = new Image();
                    imgFire.Source = new BitmapImage(fileUri);
                    MyGrid[LastIndexShoot].Children.Add(imgFire);
                }
            }
        }

        public void Shot()
        {
            int index = Array.IndexOf(OppGrid, selectedGrid);
            LastIndexShoot = index;
            UpdateData = playername + " SHOOT " + (char)('A' + index / 10) + index % 10 + "\n";
            if (selectedGrid.Tag.Equals("water"))
            {
                selectedGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D3ECFD"));
                Uri fileUri = new Uri("/Content/img_waves.png", UriKind.Relative);
                Image imgWaves = new Image();
                imgWaves.Source = new BitmapImage(fileUri);
                selectedGrid.Children.Add(imgWaves);
                selectedGrid.IsEnabled = false;
                UpdateData += playername + ": Flop it's water! \n";
            }
            else
            {
                selectedGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#13C35A"));
                Uri fileUri = new Uri("/Content/redcross.png", UriKind.Relative);
                Image imgFire = new Image();
                imgFire.Source = new BitmapImage(fileUri);
                selectedGrid.Children.Add(imgFire);
                selectedGrid.IsEnabled = false;
                int id = Int32.Parse(selectedGrid.Tag.ToString());
                ProgressBar.Value += 1;
                //Shoot ship class
                if (!oppShips[id].Shot())
                {
                    //The boat is dead
                    DrawShip(oppShips[id], OppGrid, false);
                    deadShips += 1;
                    ProgressBar.Value += 1;
                    UpdateData += playername + ": Touch and Sink! \n";
                }
                else
                {
                   UpdateData += playername + ": Touch! \n";
                }
                
            }
        }

    }
}
