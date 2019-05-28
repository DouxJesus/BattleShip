//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BattleShip2019
//{
//    public class Game
//    {
//        private GridGame boatsGrid;
//        private Ship[] ships;
//        GridGame attackGrid;
//        public Game()
//        {
//            GridGame boatsGrid = new GridGame();
//            GridGame attackGrid = new GridGame();

//            Ship[] ships = new Ship[7];
//            ships[0] = new Carrier(0);
//            ships[1] = new Battleship(1);
//            ships[2] = new Cruiser(2);
//            ships[3] = new Destroyer(3);
//            ships[4] = new Destroyer(4);
//            ships[5] = new Submarine(5);
//            ships[6] = new Submarine(6);
//        }

//        public void CreateBoardGame()
//        {
//            string x, y;
//            int X, Y;

//            foreach (Ship ship in ships)
//            {
//                for (int i = 0; i < 7; i++)
//                {
//                    bool placed = false;
//                    while (!placed)
//                    {
//                        boatsGrid.PrintGrid();
//                        Console.WriteLine("Where do you want to put your " + ships[i].Name() + "(" + ships[0].Size + " cases)");
//                        Console.WriteLine("Line number:");
//                        x = Console.ReadLine();
//                        Console.WriteLine("Column Letter:");
//                        y = Console.ReadLine();
//                        Console.WriteLine("Verticaly ? (y/n):");
//                        string verticaly = Console.ReadLine();

//                        Y = y[0] - 'A';
//                        X = x[0] - '0';
//                        bool vertical = verticaly[0] == 'y' ? true : false;

//                        placed = boatsGrid.putShip(ships[i], X, Y, vertical);
//                        if (placed)
//                        {
//                            Console.WriteLine("Your ship is ready to attack !");
//                        }
//                        else
//                        {
//                            Console.WriteLine("You can't put you ship here. Try an other place.");
//                        }
//                    }

//                }

//            }
//        }

//        public void Turn()
//        {
//            //Play
//            Console.WriteLine("Where do you want to attack ?");
//            attackGrid.PrintGrid();
//            Console.WriteLine("Line number:");
//            string x = Console.ReadLine();
//            Console.WriteLine("Column Letter:");
//            string y = Console.ReadLine();

//            int Y = y[0] - 'A';
//            int X = x[0] - '0';

//            //En vrai il faut envoyer à l'ennemi.
//            attackGrid.Shot(X, Y);
//        }
//    }
//}
