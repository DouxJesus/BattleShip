using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BattleShip2019.Game;

namespace BattleShip2019
{
    /// <summary>
    /// TODO :
    /// 1. Main Menu
    /// 2. Player class 
    ///  BOT -> player with bool
    ///  bot func -> in player
    /// </summary>
    public partial class MainWindow : Window
    {
        Grid Window = new Grid();

        //Define game type
        enum GameType{ BOT, OneVersusOne, OneVSOneBlind }

        GameType gameType;

        Player player1;
        Player player2;

        

        int currentPlayer;
        bool IsOver = false;

        public MainWindow()
        {
            
            InitializeComponent();
            Content = Window;
            this.MinWidth = 800;
            this.MinHeight = 500;
            this.Width = 800;
            this.Height = 500;

            //Change this according to menu
            gameType = GameType.OneVersusOne;

            //Menu
            //Ask players names
            //initialize waitframes

            string name1 = "Default1";
            string name2 = "Default2";

            this.MinWidth = 500;
            this.MinHeight = 500;
            this.Width = 953.286;
            this.Height = 600;


            currentPlayer = 1;
            if (gameType == GameType.BOT)
            {
                player1 = new Player(name1, 1);
                player2 = new Player("Edward The Bot", 2);
                this.player1.InitPlayerWait();
            } else
            {
                player1 = new Player(name1, 1);
                player2 = new Player(name2, 2);
                this.player2.InitPlayerWait();
            }
            Window.Children.Add(player1.playerWait);
            player1.playerWait.PlayerReady += new EventHandler(ShipInitialize);
        }

        private void ShipInitialize(object sender, EventArgs e)
        {

            Window.Children.Clear();
            if (currentPlayer == 1)
            {
                //playerOneplacingShips = new PlacingShips();
                player1.InitPlacingShip();
                Window.Children.Add(player1.placingShips);
                if (gameType == GameType.BOT)

                    player1.placingShips.Play += new EventHandler(PlayStart);
                else
                {
                    currentPlayer = 2;
                    player1.placingShips.Play += new EventHandler(WaitInitialize);
                }
            }
            else
            {
                player2.InitPlacingShip();
                Window.Children.Add(player2.placingShips);
                currentPlayer = 1;
                player2.placingShips.Play += new EventHandler(PlayStart);
            }
           
        }

        private void WaitInitialize(object sender, EventArgs e)
        {
            Window.Children.Clear();
            if (currentPlayer == 2)
            {
                Window.Children.Add(player2.playerWait);
                player2.playerWait.PlayerReady += new EventHandler(ShipInitialize);
            }
            
        }

        private void WaitTurn(object sender, EventArgs e)
        {
            Window.Children.Clear();
            currentPlayer = currentPlayer == 1 ? 2 : 1;
            if (currentPlayer == 2)
            {
                Window.Children.Add(player2.playerWait);
                player2.playerWait.PlayerReady += new EventHandler(Turn);
            }
            else
            {
                Window.Children.Add(player1.playerWait);
                player1.playerWait.PlayerReady += new EventHandler(Turn);
            }
        }

        private void PlayStart(object sender, EventArgs e)
        {
            if(this.Width != SystemParameters.PrimaryScreenWidth)
                this.Width = 1100;
            if(this.Height != SystemParameters.PrimaryScreenHeight)
                this.Height = 600;
            Window.Children.Clear();
            currentPlayer = 1;
            player1.InitGame(player2.myships);
            player2.InitGame(player1.myships);

            Window.Children.Add(player1.playerWait);
            player1.playerWait.PlayerReady += new EventHandler(Turn);
        }

        private void Turn(object sender, EventArgs e)
        {
            //EventHandle GAMEOVER

            Window.Children.Clear();
            if (this.IsOver)
            {
                //GAME FINISH
            }
            else if (currentPlayer == 1)
            {
                player1.playGame.UpdateData += player2.playGame.UpdateData;
                player1.playGame.LastIndexShoot = player2.playGame.LastIndexShoot;
                player1.playGame.GameUpdate();
                Window.Children.Add(player1.playGame);
                player1.playGame.Next += null;
                player1.playGame.Next += new EventHandler(WaitTurn);
            }
            else
            {
                player2.playGame.UpdateData += player1.playGame.UpdateData;
                player2.playGame.LastIndexShoot = player1.playGame.LastIndexShoot;
                player2.playGame.GameUpdate();
                Window.Children.Add(player2.playGame);
                player2.playGame.Next += null;
                player2.playGame.Next += new EventHandler(WaitTurn);
            }
            
        }

    }
}
