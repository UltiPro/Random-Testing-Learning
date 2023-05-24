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
using System.Speech.Synthesis;

namespace WpfSpeechSynthesiser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SpeechSynthesizer speechSynthesizer;
        public MainWindow()
        {
            InitializeComponent();
            speechSynthesizer = new SpeechSynthesizer();
            speechSynthesizer.Volume = 50;
            speechSynthesizer.Rate = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            speechSynthesizer.Speak(MainTextBox.Text);
        }
    }
}
