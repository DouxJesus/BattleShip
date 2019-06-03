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

    //Define game type
    public enum GameType { BOT, OneVersusOne }

    public partial class MainWindow : Window
    {
        Grid Window = new Grid();

        GameType gameType;

        Player player1;
        Player player2;

        GameOver gameOver;
        MainMenu mainMenu;

        int currentPlayer;

        public MainWindow()
        {
            
            InitializeComponent();
            Content = Window;
            this.MinWidth = 500;
            this.MinHeight = 500;
            this.Width = 953.286;
            this.Height = 600;

            mainMenu = new MainMenu();
            mainMenu.LaunchGame += new EventHandler(LaunchGame);
            Window.Children.Add(mainMenu);
            
        }

        private void LaunchGame(object sender, EventArgs e)
        {
            gameType = mainMenu.gameType;
            currentPlayer = 1;
            if (gameType == GameType.BOT)
            {
                player1 = new Player(mainMenu.player1Name, 1);
                player2 = new Player("Edward The Bot", 2);
                this.player1.InitPlayerWait();
            }
            else
            {
                player1 = new Player(mainMenu.player1Name, 1);
                player2 = new Player(mainMenu.player2Name, 2);
                this.player2.InitPlayerWait();
                this.player1.InitPlayerWait();
            }
            Window.Children.Add(player1.playerWait);
            player1.playerWait.PlayerReady += new EventHandler(ShipInitialize);
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

        private void ShipInitialize(object sender, EventArgs e)
        {

            Window.Children.Clear();
            if (currentPlayer == 1)
            {
                player1.InitPlacingShip();
                Window.Children.Add(player1.placingShips);
                if (gameType == GameType.BOT)
                {
                    player2.InitPlacingShip();
                    player2.placingShips.btnRandomize.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    player2.placingShips.btnSubmit.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    player1.placingShips.Play += new EventHandler(PlayStart);
                }
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

        private void PlayStart(object sender, EventArgs e)
        {
            if (this.Width != SystemParameters.PrimaryScreenWidth)
                this.Width = 1100;
            if (this.Height != SystemParameters.PrimaryScreenHeight)
                this.Height = 600;
            Window.Children.Clear();

            currentPlayer = 1;

            player1.InitGame(player2.myships);
            player2.InitGame(player1.myships);
            player1.playGame.MenuEvent += new EventHandler(CallMenu);
            player2.playGame.MenuEvent += new EventHandler(CallMenu);

            Window.Children.Add(player1.playerWait);
            if (gameType == GameType.BOT)
                player1.playerWait.PlayerReady += new EventHandler(BotTurn);
            else
                player1.playerWait.PlayerReady += new EventHandler(Turn);
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

        private void Turn(object sender, EventArgs e)
        {
            Window.Children.Clear();
            player1.playGame.resetNext();
            player2.playGame.resetNext();
            if (player1.playGame.deadShips == 7 || player2.playGame.deadShips == 7)
            {
                Window.Children.Clear();
                gameOver = new GameOver(player1.playGame.deadShips == 7 ? player1._name : player2._name);
                Window.Children.Add(gameOver);
                gameOver.MenuCall += new EventHandler(CallMenu);
            }
            else if (currentPlayer == 1)
            {
                player1.playGame.UpdateData += player2.playGame.UpdateData;
                player1.playGame.LastIndexShoot = player2.playGame.LastIndexShoot;
                player1.playGame.GameUpdate();
                Window.Children.Add(player1.playGame);
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

        private void BotTurn(object sender, EventArgs e)
        {
            Window.Children.Clear();
            player1.playGame.resetNext();
            Window.Children.Add(player1.playGame);
            if (player1.playGame.deadShips == 7 || player2.playGame.deadShips == 7)
            {
                Window.Children.Clear();
                gameOver = new GameOver(player1.playGame.deadShips == 7 ? player1._name : player2._name);
                Window.Children.Add(gameOver);
                gameOver.MenuCall += new EventHandler(CallMenu);
            }
            else
            {
                player2.playGame.UpdateData += player1.playGame.UpdateData;
                player2.playGame.LastIndexShoot = player1.playGame.LastIndexShoot;
                player2.playGame.GameUpdate();
                player2.playGame.Attack();

                player1.playGame.UpdateData += player2.playGame.UpdateData;
                player1.playGame.LastIndexShoot = player2.playGame.LastIndexShoot;
                player1.playGame.GameUpdate();

                player1.playGame.Next += new EventHandler(BotTurn);
            }
        }

        private void CallMenu(object sender, EventArgs e)
        {
            player1 = null;
           player2 = null;
            currentPlayer = 1;
            mainMenu.LaunchReset();
            Window.Children.Clear();
            Window.Children.Add(mainMenu);
            mainMenu.LaunchGame += new EventHandler(LaunchGame);
        }

    }
}
