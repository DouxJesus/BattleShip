using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip2019.Game
{
    

    class Player
    {
        public readonly string _name;
        public readonly int _playerTurn;
        public Ship[] myships = new Ship[7];

        //PlacingShip window
        public PlacingShips placingShips;

        //Playerwait window
        public PlayerWait playerWait;

        //Game window
        public PlayGame playGame;

        public Player(string name, int playerTurn)
        {
            //format name
            this._name = name;
            this._playerTurn = playerTurn;
            

        }

        public void InitPlacingShip()
        {
            this.placingShips = new PlacingShips();
            placingShips.Play += new EventHandler(SetShips);

        }

        public void SetShips(object sender, EventArgs e)
        {
            myships = placingShips.MyShips;
        }


        public void InitPlayerWait()
        {
            this.playerWait = new PlayerWait(this._name, this._playerTurn);
        }

        public void InitGame (Ship[] enemies)
        {
            this.playGame = new PlayGame(this._name, myships, enemies);
        }


    }
}
