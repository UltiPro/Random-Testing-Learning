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

namespace WpfControlsCheckboxes
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

        private void Checkbox1_Checked(object sender, RoutedEventArgs e)
        {
            lb1.Background = Brushes.Gray;
        }

        private void Checkbox1_Unchecked(object sender, RoutedEventArgs e)
        {
            lb1.Background = Brushes.White;
        }

        private void cbParent_Checked(object sender, RoutedEventArgs e)
        {
            bool newVal = (cbParent.IsChecked == true);
            Checkbox1.IsChecked = newVal;
            Checkbox2.IsChecked = newVal;
            Checkbox3.IsChecked = newVal;
        }

        private void Checked(object sender, RoutedEventArgs e)
        {
            cbParent.IsChecked = null;
            if(Checkbox1.IsChecked == true && Checkbox2.IsChecked == true && Checkbox3.IsChecked == true)
            {
                cbParent.IsChecked = true;
            }
            if (Checkbox1.IsChecked == false && Checkbox2.IsChecked == false && Checkbox3.IsChecked == false)
            {
                cbParent.IsChecked = false;
            }
        }
    }
}
