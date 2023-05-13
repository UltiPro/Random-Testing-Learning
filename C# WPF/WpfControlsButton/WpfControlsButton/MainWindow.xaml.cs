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

namespace WpfControlsButton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            double myFontsize = myLabel.FontSize;
            myLabel.FontSize = myFontsize + 1;
        }

        private void myButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            double myFontsize = myLabel.FontSize;
            myLabel.FontSize = myFontsize - 1;
        }

        private void myButton_MouseEnter(object sender, MouseEventArgs e)
        {
            myButton.Foreground = Brushes.Yellow;
        }

        private void myButton_MouseLeave(object sender, MouseEventArgs e)
        {
            myButton.Foreground = Brushes.Red;
        }
    }
}
