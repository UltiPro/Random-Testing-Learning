using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace InstaUserControlExample
{
    public static class MockDb
    {
        public static Uri GetPostVideo()
        {
            return new Uri(Environment.CurrentDirectory + @"\..\..\Videos\cat.mp4", UriKind.RelativeOrAbsolute);
        }
        //TODO: Step 3: Write the GetPostPicure function
        public static BitmapImage GetPostPicture()
        {
            //TODO: Step 4: Get all jpg in this folder, these are the only type of pictures that are posts
            List<string> filepaths = Directory.GetFiles(Environment.CurrentDirectory + @"\..\..\Icons", "*.jpg").ToList<string>();
            //TODO: Step 5: Seed the random number generator so the content is different each time
            Random generator = new Random(DateTime.Now.Millisecond);
            //TODO: Step 6: Pick a random image file and return it 
            //GOTO PicturePostModel.cs
            FileInfo myRandomFile = new FileInfo(filepaths[generator.Next(filepaths.Count)]);
            return new BitmapImage(new Uri(myRandomFile.FullName, UriKind.RelativeOrAbsolute));
        }
    }
}
