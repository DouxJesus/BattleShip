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
    /// Logique d'interaction pour PlayerWait.xaml
    /// </summary>
    public partial class PlayerWait : UserControl
    {
        string playername;
        public event EventHandler PlayerReady;

        public PlayerWait(string playername, int playernb)
        {
            InitializeComponent();
            this.playername = playername;
            LabelPlayer.Content = playername;
            if (playernb == 2)
            {
                this.Background = new SolidColorBrush(Colors.Coral);
                btnReady.Background = new SolidColorBrush(Colors.LightCoral);
            }
        } 

        public void btn_Ready(object sender, EventArgs e)
        {
            //Invoke event Playerready
            PlayerReady(this, e);
            //To fix bug of multiple unwanted turn
            //Fix :send only one event
            PlayerReady = null;
        }
    }
}
