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
    /// Logique d'interaction pour MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public event EventHandler LaunchGame;

        public string player1Name;
        public string player2Name;
        public GameType gameType;
        public MainMenu()
        {
            InitializeComponent();
        }

        public void LaunchReset()
        {
            LaunchGame = null;
        }

        private void btnLaunch(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if(btn == btnBot)
            {
                if (txtboxName.Text.Length > 1)
                {
                    gameType = GameType.BOT;
                    if (txtboxName.Text.Length > 20)
                        player1Name = txtboxName.Text.Substring(0, 20);
                    else
                        player1Name = txtboxName.Text;
                    LaunchGame(this, e);
                }
            }
            else
            {
                if (txtboxName.Text.Length > 1 && txtboxName2.Text.Length > 1)
                {
                    gameType = GameType.OneVersusOne;
                    if (txtboxName.Text.Length > 20)
                        player1Name = txtboxName.Text.Substring(0, 20);
                    else
                        player1Name = txtboxName.Text;
                    if (txtboxName2.Text.Length > 20)
                        player2Name = txtboxName2.Text.Substring(0, 20);
                    else
                        player2Name = txtboxName2.Text;
                    LaunchGame(this, e);
                }
            }

            
        }
    }
}
