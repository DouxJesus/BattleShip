//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BattleShip2019
//{
//    class GridGame
//    {
//        private const int gridSize = 10;
//        private Cell[,] Cells;

//        public GridGame()
//        {
//            Cells = new Cell[gridSize, gridSize];
//            for(int i = 0; i < gridSize; i++)
//            {
//                for(int j = 0; j < gridSize; j++)
//                {
//                    Cells[i, j] = new Cell(i, j);
//                }
//            }
//        }

//        public bool putShip(Ship ship, int x, int y, bool vertical)
//        {
//            bool verif = true;

//            int X = x, Y = y;
//            while(verif && X < x + ship.Size && Y < y + ship.Size)
//            {
//                verif = X > 0 && Y > 0 && x < gridSize && Y < gridSize && Cells[X, Y].ID == -1;
//                if (vertical)
//                    Y++;
//                else
//                    X++;
//            }
//            if (verif)
//            {
//                while (X < x + ship.Size && Y < y + ship.Size)
//                {
//                    this.Cells[X, Y].putShip(ship.Id);
//                    if (vertical)
//                        Y++;
//                    else
//                        X++;
//                }

//                ship.SetCoordinates(index, horizontal);
//            }
//            return verif;
//        }

//        public void PrintGrid()
//        {
//            Console.Write(" A B C D E F G H I J");
//            for (int i = 0; i < gridSize; i++)
//            {
//                Console.Write(i);
//                for (int j = 0; j < gridSize; j++)
//                {
//                    if (Cells[i, j].ID == -1)
//                        Console.Write(" O");
//                    else
//                        Console.Write(" X");
//                }
//                Console.WriteLine();
//            }
//        }

//        public bool Shot(int x, int y)
//        {
//            if (x > 0 && y > 0 && x < gridSize && y < gridSize)
//                return Cells[x, y].Shot();
//            else
//                return false;
//        }
//    }
//}
