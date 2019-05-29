//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BattleShip2019.Game
//{


//    class Bot : Player
//    {
//        public readonly string _name;
//        public readonly int _playerTurn;
//        //private static readonly int name;
//        //public Ship[] myships;
//        //public Ship[] oppShips;
//        //public int[] grid;
//        //public int[] oppGrid;

//        bool TouchedABoat;
//        int lastAttack;
//        int nextOrientation;
//        int hitCount;

//        public static object playerTurn { get; }

//        public Bot(string name, int playerTurn) : base(name,playerTurn)
//        {
//            this.TouchedABoat = false;
//            this.lastAttack = -1;
//            this.nextOrientation = 1;
//            this.hitCount = 0;

//        }
//        //this.playGame.OppGrid[index].Tag.Equals("water")
//        public int Attack()
//        {
//            int index = -1;
//            this.TouchedABoat = (lastAttack != 1 && this.playGame.OppGrid[lastAttack].IsEnabled);
//            if (TouchedABoat)       //Bot touched a bot, target next smart move
//            {

//            }
//            else                    //Else target random
//            {
//                Random random = new Random();
//                index = random.Next(0, 100);
//                while (!this.playGame.OppGrid[index].IsEnabled)
//                {
//                    index = random.Next(0, 100);
//                }

//            }
//            this.playGame.selectedGrid = this.playGame.OppGrid[index];
//            this.playGame.Shot();
//            this.lastAttack = index;
//            //To talk to playgame
//            this.playGame.LastIndexShoot = index;
//             return 0;

//        }
//    }
//}
