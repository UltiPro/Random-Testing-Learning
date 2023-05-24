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

namespace Wpf_Controls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            mytexxblock.Text = "Hello from the cs side!";
            mytexxblock.Foreground = Brushes.Blue;

            TextBlock textblock = new TextBlock();
            textblock.Text = "Hello world";
            textblock.Inlines.Add(" this was added inlines!");
            textblock.Inlines.Add(new Run(" this run lol") {
                Foreground = Brushes.Blue,
                TextDecorations = TextDecorations.Underline

            });
            textblock.TextWrapping = TextWrapping.Wrap;
            textblock.Foreground = Brushes.Red;
            this.Content = textblock;
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
        }   
    }
}
