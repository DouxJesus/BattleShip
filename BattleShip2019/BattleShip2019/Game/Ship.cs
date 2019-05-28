using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BattleShip2019
{
    public class Ship
    {
        /*protected*/ bool alive;
        /*protected*/ int size;
        /*protected*/ int pv;
        /*protected*/ int id;
        /*protected*/ int index;
        /*protected*/ int x;
        /*protected*/ int y;
        /*protected*/ bool horizontalOrientation;
        /*protected*/ SolidColorBrush shipColor;


        protected Ship(int size, int id)
        {
            alive = true;
            this.size = size;
            pv = size;
            this.id = id;
            this.x = -1;
            this.y = -1;
            this.index = -1;
            horizontalOrientation = true;
            shipColor = new SolidColorBrush(Colors.Gray);
        }

        public bool Shot()
        {
            pv--;
            if (pv <= 0)
                alive = false;
            return alive;
        }

        public bool SetCoordinates(int index, bool vertical)
        {
            if (this.x != -1 && this.y != -1)
            {
                this.index = index;
                this.horizontalOrientation = vertical;
                return true;
            }
            else
                return false;
        }

        public string Name()
        {
            return "";
        }

        public int Id { get => id; }
        public int Size { get => size; }
        public int Pv { get => pv; }
        public int X { get => x; }
        public int Y { get => y; }
        public bool Horizontal { get => horizontalOrientation; }
        public SolidColorBrush ShipColor { get => shipColor;/* set => shipColor = value; */}
    }

   public class Cruiser : Ship
    {
        
        public Cruiser(int id) : base(3, id)
        {
        }

        public new string Name()
        {
            return "Cruiser";
        }
    }

    public class Destroyer : Ship
    {

        public Destroyer(int id) : base(2, id)
        {
        }
        public new string Name()
        {
            return "Destroyer";
        }
    }
    public class Submarine : Ship
    {

        public Submarine(int id) : base(1, id)
        {
        }
        public new string Name()
        {
            return "Submarine";
        }
    }
    public class Battleship : Ship
    {

        public Battleship(int id) : base(4, id)
        {
        }
        public new string Name()
        {
            return "Battleship";
        }
    }
    public class Carrier : Ship
    {

        public Carrier(int id) : base(5, id)
        {
        }

        public new string Name()
        {
            return "Carrier";
        }
    }
}
