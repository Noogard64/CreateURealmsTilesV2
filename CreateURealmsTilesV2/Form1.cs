using System;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace CreateURealmsTilesV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> images;
        public string errorLog;
        public static string TempFolder = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\CreateUrealmsTiles";

        private void button_CreateImages_Click(object sender, EventArgs e)
        {
            string gimpLocation = textBox_gimpLocation.Text;
            
            images = new List<string>(GetImagesLocation.ImagesLocation());

            int numberOfImages = images.Count();

            var increments = 100 /numberOfImages;

            foreach (string image in images)
            {
                
                MakeImagesUsingGimp.MakeImages(gimpLocation, image);

                string imageFileNameNoExt = Path.GetFileNameWithoutExtension(image);

                string imageTempFolder = TempFolder + @"\" + imageFileNameNoExt;

                string[] allImages = Directory.GetFiles(imageTempFolder);

                if (allImages.Count() != 10)
                {
                    MessageBox.Show("Failed to make images for [" + image + ")");
                }
                else
                {
                    progressBar_CreateImages.Value = progressBar_CreateImages.Value + increments;
                }

                
            }

            progressBar_CreateImages.Value = 100;

        }

        private void buttonCreateTiles_Click(object sender, EventArgs e)
        {
            int numberOfImages = images.Count();

            var increments = 100 / numberOfImages;

            foreach (string image in images)
            {

                MakeJSONFile.MakeJSONFileProcess(image);
                progressBar_CreateTiles.Value = progressBar_CreateTiles.Value + increments;
            }
            progressBar_CreateTiles.Value = 100;
        }

        private void button_OpenTempFolder_Click(object sender, EventArgs e)
        {
            
            Process.Start(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\CreateUrealmsTiles");
        }


    }   
}
