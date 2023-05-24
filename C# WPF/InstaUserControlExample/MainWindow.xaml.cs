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

namespace InstaUserControlExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //TODO: Step 9: Create a random number generator
        Random Generator;
        public MainWindow()
        {
            InitializeComponent();
            //TODO: Step 10: Initialize it
            Generator = new Random(DateTime.Now.Millisecond);
            MainStackPanel.Children.Add(new VideoPost(new VideoPostModel()));
            //TODO: Step 11: Supply PicturePost with a model
            MainStackPanel.Children.Add(new PicturePost(new PicturePostModel()));
            MainStackPanel.Children.Add(new VideoPost(new VideoPostModel()));
            //TODO: Step 12: Supply PicturePost with a model here too
            //This is just so that we have enogh content from the very beginning
            //when we start the app
            MainStackPanel.Children.Add(new PicturePost(new PicturePostModel()));
        }

        private void MainScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.VerticalChange > 0)
            {
                int adjustment = 400;
                if (e.VerticalOffset + e.ViewportHeight + adjustment >= e.ExtentHeight)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        //TODO: Step 13: Have a 70% chance to generate a picture
                        //That's it!
                        //While it is still far away from a real application 
                        //the UI essentials for creating an instagram like
                        //application are all there
                        if (Generator.Next(0,100) < 70)
                        {
                            PicturePost newPost = new PicturePost(new PicturePostModel());
                            MainStackPanel.Children.Add(newPost);
                        }
                        else
                        {
                            VideoPost newVid = new VideoPost(new VideoPostModel());
                            MainStackPanel.Children.Add(newVid);
                        }
                    }
                }
            }
        }
    }
}
