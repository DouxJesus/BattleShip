﻿using System;
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
    /// Logique d'interaction pour GameOver.xaml
    /// </summary>
    public partial class GameOver : UserControl
    {
        public event EventHandler MenuCall;
        public GameOver(string playername)
        {
            InitializeComponent();
            LabelPlayer.Content = playername.ToUpper();
        }

        private void btnMenu(Object sender, EventArgs e )
        {
            MenuCall(this, e);
        }
    }
}
