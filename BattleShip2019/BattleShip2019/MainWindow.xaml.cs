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

namespace BattleShip2019
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Grid Window = new Grid();

        enum GameType{ BOT, OneVersusOne, OneVSOneBlind }

        GameType gameType;

        PlacingShips playerOneplacingShips;
        PlacingShips playerTwoplacingShips;

        PlayerWait PlayerOneWait;
        PlayerWait PlayerTwoWait;
        PlayGame playGamePlayerOne;
        PlayGame playGamePlayerTwo;

        int currentTurn;

        public MainWindow()
        {
            
            InitializeComponent();
            Content = Window;
            this.MinWidth = 800;
            this.MinHeight = 500;
            this.Width = 800;
            this.Height = 500;

            gameType = GameType.OneVersusOne;
            //Menu
            //Ask players names
            //initialize waitframes

            this.MinWidth = 500;
            this.MinHeight = 500;
            this.Width = 953.286;
            this.Height = 600;

            currentTurn = 1;
            PlayerOneWait = new PlayerWait("Player 1", 1);
            PlayerTwoWait = new PlayerWait("Player 2", 2);
            Window.Children.Add(PlayerOneWait);
            PlayerOneWait.PlayerReady += new EventHandler(ShipInitialize);
            
        }

        private void ShipInitialize(object sender, EventArgs e)
        {
            Window.Children.Clear();
            if (currentTurn == 1)
            {
                playerOneplacingShips = new PlacingShips();
                Window.Children.Add(playerOneplacingShips);
                if (gameType == GameType.BOT)
                   playerOneplacingShips.Play += new EventHandler(PlayStart);
                else
                {
                    currentTurn = 2;
                    playerOneplacingShips.Play += new EventHandler(WaitInitialize);
                }
            }
            else
            {
                playerTwoplacingShips = new PlacingShips();
                Window.Children.Add(playerTwoplacingShips);
                currentTurn = 1;
                playerTwoplacingShips.Play += new EventHandler(PlayStart);
            }
           
        }

        private void WaitInitialize(object sender, EventArgs e)
        {
            Window.Children.Clear();
            if (currentTurn == 2)
            {
                Window.Children.Add(PlayerTwoWait);
                PlayerTwoWait.PlayerReady += new EventHandler(ShipInitialize);
            }
            
        }

        private void WaitTurn(object sender, EventArgs e)
        {
            Window.Children.Clear();
            currentTurn = currentTurn == 1 ? 2 : 1;
            if (currentTurn == 2)
            {
                Window.Children.Add(PlayerTwoWait);
                PlayerTwoWait.PlayerReady += new EventHandler(Turn);
            }
            else
            {
                Window.Children.Add(PlayerOneWait);
                PlayerOneWait.PlayerReady += new EventHandler(Turn);
            }

        }

        private void PlayStart(object sender, EventArgs e)
        {
            Window.Children.Clear();
            playGamePlayerOne = new PlayGame("player1",playerOneplacingShips.MyShips, playerTwoplacingShips.MyShips);
            playGamePlayerTwo = new PlayGame("player2", playerTwoplacingShips.MyShips, playerOneplacingShips.MyShips);
            currentTurn = 1;
            Window.Children.Add(PlayerOneWait);
            PlayerOneWait.PlayerReady += new EventHandler(Turn);

        }

        private void Turn(object sender, EventArgs e)
        {
            Window.Children.Clear();
            if (currentTurn == 1)
            {
                Window.Children.Add(playGamePlayerOne);
                playGamePlayerOne.Next += null;
                playGamePlayerOne.Next += new EventHandler(WaitTurn);
            }
            else
            {
                Window.Children.Add(playGamePlayerTwo);
                playGamePlayerTwo.Next += null;
                playGamePlayerTwo.Next += new EventHandler(WaitTurn);
            }
        }

    }
}
