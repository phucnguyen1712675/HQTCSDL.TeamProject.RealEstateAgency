﻿using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace HQTCSDL.TeamProject.RealEstateAgency.View.ChiNhanhScreens
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ChiNhanhMain : MetroWindow
    {
        public ChiNhanhMain()
        {
            InitializeComponent();
            IList<int> LongListToTestComboVirtualization = new List<int>(Enumerable.Range(0, 20));
            NumberOfRoomsComboBox.ItemsSource = LongListToTestComboVirtualization;
        }

        private void HouseOwnerNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
