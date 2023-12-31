﻿using DMS.Services.Services;
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

namespace DairyManagementSystem.Forms
{
    /// <summary>
    /// Interaction logic for Master.xaml
    /// </summary>
    public partial class Master : Window
    {
        public Master()
        {
            InitializeComponent();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private bool isMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                this.WindowState = WindowState.Normal;
                this.Width = 700;
                this.Height = 1000;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                isMaximized = true;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
           Button button = (Button)sender; 
            string keyValue = button.Tag as string;

            if (keyValue == "MilkCollection")
                Main.Content = new MilkCollection();
            else if (keyValue == "Reports")
                Main.Content = new MilkCollectionReport();
            else if (keyValue == "RateMaster")
                Main.Content = new RateList();

        }
    }
}


