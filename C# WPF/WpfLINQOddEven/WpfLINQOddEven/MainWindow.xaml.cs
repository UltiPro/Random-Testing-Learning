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

namespace WpfLINQOddEven
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> list;
        public MainWindow()
        {
            InitializeComponent();

            list = new List<int>() { 14, 5, 6, 3, 2, 1, 7, 8, 9 };
        }

        public string StringifyList(List<int> list)
        {
            string accum = "";

            foreach (int item in list)
            {
                if (item == list.Last())
                    accum += item.ToString();
                else
                    accum += item.ToString() + ", ";
            }

            return accum;
        }

        public List<int> FilterListOddNumbers(List<int> list)
        {
            return list.Where(e => (e % 2) != 0).ToList();
        }

        public List<int> FilterListEvenNumbers(List<int> list)
        {
            return list.Where(e => (e % 2) == 0).ToList();
        }

        private void Odd_Click(object sender, RoutedEventArgs e)
        {
            list = FilterListOddNumbers(list);
            myTextBlock.Text = StringifyList(list);
        }

        private void Even_Click(object sender, RoutedEventArgs e)
        {
            list = FilterListEvenNumbers(list);
            myTextBlock.Text = StringifyList(list);
        }

        private void RemoveFilter_Click(object sender, RoutedEventArgs e)
        {
            list = new List<int>() { 14, 5, 6, 3, 2, 1, 7, 8, 9 };
            myTextBlock.Text = StringifyList(list);
        }

        private List<int> Sort(List<int> list, bool asc)
        {
            if (asc)
                return list.OrderBy(x => x).ToList();
            else
                return list.OrderByDescending(x => x).ToList();
        }

        private void Ascending_Click(object sender, RoutedEventArgs e)
        {
            list = Sort(list, true);
            myTextBlock.Text = StringifyList(list);
        }

        private void Descending_Click(object sender, RoutedEventArgs e)
        {
            list = Sort(list, false);
            myTextBlock.Text = StringifyList(list);
        }
    }
}
