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
    /// Interaction logic for MilkCollectionWindow.xaml
    /// </summary>
    public partial class MilkCollectionWindow : Window
    {
        public MilkCollectionWindow()
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
    }
}
