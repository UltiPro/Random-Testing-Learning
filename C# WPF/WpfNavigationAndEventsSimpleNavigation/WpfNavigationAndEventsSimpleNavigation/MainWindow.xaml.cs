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
using WpfNavigationAndEventsSimpleNavigation.Pages;

namespace WpfNavigationAndEventsSimpleNavigation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Page1 page1;
        public Page2 page2;
        public MainWindow()
        {
            page1 = new Page1();
            page2 = new Page2();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Mainwindowframe.Content = page1;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Mainwindowframe.Content = page2;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Mainwindowframe.NavigationService.CanGoBack)
            {
                Mainwindowframe.NavigationService.GoBack();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Mainwindowframe.NavigationService.CanGoForward) 
            {
                Mainwindowframe.NavigationService.GoForward();
            }
        }
    }
}
