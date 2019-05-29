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
        protected bool alive;
        protected int size;
        protected int pv;
        protected int id;
        //Top left corner of ship
        protected int index;
        protected string name;
        protected bool horizontalOrientation;
        protected SolidColorBrush shipColor;


        protected Ship(int size, int id)
        {
            alive = true;
            this.size = size;
            pv = size;
            name = "";
            this.id = id;
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

        public bool SetCoordinates(int index, bool horizontal)
        {
            if (this.index == -1)
            {
                this.index = index;
                this.horizontalOrientation = horizontal;
                return true;
            }
            else
                return false;
        }



        public string Name { get => name; }

        public int Id { get => id; }
        public int Size { get => size; }
        public int Pv { get => pv; }
        public int Index { get => index; }
        public bool Horizontal { get => horizontalOrientation; }
        public SolidColorBrush ShipColor { get => shipColor;}
    }

   public class Cruiser : Ship
    {
        
        public Cruiser(int id) : base(3, id)
        {
            this.shipColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#fbfd64"));
            this.name = "Cruiser";
        }

    }

    public class Destroyer : Ship
    {

        public Destroyer(int id) : base(2, id)
        {
            this.shipColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#fb3980"));
            this.name = "Destroyer";
        }
        
    }
    public class Submarine : Ship
    {

        public Submarine(int id) : base(1, id)
        {
            this.shipColor = new SolidColorBrush(Colors.DarkOrange);
            this.name = "Submarine";
        }
    }
    public class Battleship : Ship
    {

        public Battleship(int id) : base(4, id)
        {
            this.shipColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#51fd64"));
            this.name = "Battleship";
        }
    }
    public class Carrier : Ship
    {

        public Carrier(int id) : base(5, id)
        {
            this.shipColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#DE003F"));
            this.name = "Carrier";
        }
    }
}
