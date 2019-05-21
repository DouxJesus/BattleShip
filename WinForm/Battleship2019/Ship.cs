using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship2019
{
    public class Ship
    {
        private bool alive;
        private int size;
        private int pv;
        private int id;
        private int x;
        private int y;
        private bool vertical;


        public Ship(int size, int id)
        {
            alive = true;
            this.size = size;
            pv = size;
            this.id = id;
            this.x = -1;
            this.y = -1;
        }

        public bool Shot()
        {
            pv--;
            if (pv <= 0)
                alive = false;
            return alive;
        }

        public bool SetCoordinates(int x, int y, bool vertical)
        {
            if (this.x != -1 && this.y != -1)
            {
                this.x = x;
                this.y = y;
                this.vertical = vertical;
                return true;
            }
            else
                return false;
        }

        public int Id { get => Id; }
        public int Size { get => Size; }
        public int Pv { get => pv; }
        public int X { get => x; }
        public int Y { get => y; }
        public bool Vertical { get => vertical; }
    }

   public class Chasseur : Ship
    {
        
        public Chasseur(int id) : base(3, id)
        {
        }
    }
}
