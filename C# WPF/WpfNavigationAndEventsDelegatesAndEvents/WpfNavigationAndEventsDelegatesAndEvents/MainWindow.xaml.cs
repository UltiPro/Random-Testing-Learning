﻿using System;
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

namespace WpfNavigationAndEventsDelegatesAndEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ValueController.MinThresHoldReached += ValueController_MinThresholdReached;
        }

        private void ValueController_MinThresholdReached(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Minimum value reached!");
        }
    }
}
