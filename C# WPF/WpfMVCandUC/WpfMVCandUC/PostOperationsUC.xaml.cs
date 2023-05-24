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

namespace WpfMVCandUC
{
    /// <summary>
    /// Logika interakcji dla klasy PostOperationsUC.xaml
    /// </summary>
    public partial class PostOperationsUC : UserControl
    {
        public bool PostLiked { get; set; }

        public PostOperationsUC()
        {
            InitializeComponent();
        }

        public void LikedPost()
        {
            Heart.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\..\..\like.png", UriKind.RelativeOrAbsolute));
            PostLiked = true;
        }

        public void UnLikedPost()
        {
            Heart.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\..\..\nolike.png", UriKind.RelativeOrAbsolute));
            PostLiked = false;
        }

        private void Heart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!PostLiked)
            {
                LikedPost();
            }
            else
            {
                UnLikedPost();
            }
        }
    }
}
