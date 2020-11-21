﻿using MaterialDesignThemes.Wpf;
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

namespace HQTCSDL.TeamProject.RealEstateAgency.View.CompanyView
{
    /// <summary>
    /// Interaction logic for KindsOfHouseContent.xaml
    /// </summary>
    public partial class KindsOfHouseContent : UserControl
    {
        public KindsOfHouseContent() => InitializeComponent();

        private void KindsOfHouse_DialogHost_OnDialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            Console.WriteLine($"SAMPLE 5: Closing dialog with parameter: {eventArgs.Parameter ?? string.Empty}");

            //you can cancel the dialog close:
            //eventArgs.Cancel();

            if (!Equals(eventArgs.Parameter, true))
                return;

            if (!string.IsNullOrWhiteSpace(KindsOfHouseTextBox.Text))
            {
                KindsOfHouseListBox.Items.Add(KindsOfHouseTextBox.Text.Trim());
            }
        }
    }
}
