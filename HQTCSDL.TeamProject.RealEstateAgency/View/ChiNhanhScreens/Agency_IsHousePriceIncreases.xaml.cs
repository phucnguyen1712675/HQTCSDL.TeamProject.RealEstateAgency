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
    /// Interaction logic for Agency_IsHousePriceIncreases.xaml
    /// </summary>
    public partial class Agency_IsHousePriceIncreases : MetroWindow
    {
        public Agency_IsHousePriceIncreases(string Title)
        {
            InitializeComponent();
            TitleLabel.Content = Title;
        }
    }
}
