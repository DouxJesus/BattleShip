using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip2019
{
    class Cell
    {
        private int x;
        private int y;
        private int id;
        //private CellState state;

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.id = -1;
        }

        //public CellState Occupied { get => occupied; set => occupied = value; }

        public bool Shot()
        {
            bool touch = false;
            //if()
            //{
            //    touch = true;
            //}
            //state = CellState.TOUCH;

            return touch;
        }

        public bool putShip(int id)
        {
            if (id != -1)
            {
                this.id = id;
                //this.state = CellState.OCCUPIED;
                return true;
            }
            else
                return false;
        }

        //public CellState State { get => state; }

        public int ID { get => id; }
    }

    public enum CellState
    {
        FREE,
        OCCUPIED,
        TOUCH
    }
}
