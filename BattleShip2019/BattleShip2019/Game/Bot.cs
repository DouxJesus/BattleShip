using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip2019.Game
{
    

    class Bot
    {
        public readonly string _name;
        public readonly int _playerTurn;
        public Ship[] myships;

        public int[] grid;

        public Bot(string name, int playerTurn)
        {   
            this._playerTurn = playerTurn;
            
        }

         public void InitShips()
        {


        }

        private void initGrid()
        {
            this.grid = new int[100];
        }

        private bool checkAvailablePlacement(int index, bool orientation, int length)
        {
            int index2 = index;
            bool isOk = true;
            int i = 0;
            int nextJ = orientation ? 1 : 10;
            //CHECK IF NOT ON EDGES
            isOk = orientation ? (((index + length * nextJ) % 10) > index) :((index + length * nextJ) < 100);

            //CHECK IF ON OTHER SHIP
            while (isOk && i < myships.Length && myships[i].Index == -1)
            {
                int j = 0;
                while(isOk && j < length)
                {

                    if(grid[index2] != -1)
                    {
                        isOk = false;
                    }
                    j++;
                    index2 += nextJ;
                }
                i++;
            }

            return isOk;
        }

        public void RandomShip()
        {

            Ship[] myships = new Ship[7] { new Submarine(0), new Submarine(1), new Destroyer(2), new Destroyer(3), new Cruiser(4), new Battleship(5), new Carrier(6) };
            Random random = new Random();

            foreach(Ship s in myships)
            {
                int index = random.Next(0, 100);
                bool horizontalOrientation = random.Next(0, 2) == 1 ? true : false;
                while (!checkAvailablePlacement(index,horizontalOrientation, s.Size))
                {
                    index = random.Next(0, 100);
                }
                s.SetCoordinates(index, horizontalOrientation);
                int id = s.Id;

            }
        }
    }
}
