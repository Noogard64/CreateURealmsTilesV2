using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
<<<<<<< HEAD
=======
using System.Collections.Generic;
>>>>>>> 4f1e5f8397d336f562b4bfb4986d3203096b1a20

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
<<<<<<< HEAD
            images = GetImagesLocation.ImagesLocation();
            textBox_OutputLog.Text = "Starting images creation...";
=======
            
            images = new List<string>(GetImagesLocation.ImagesLocation());

            int numberOfImages = images.Count();

            var increments = 100 /numberOfImages;
>>>>>>> 4f1e5f8397d336f562b4bfb4986d3203096b1a20

            foreach (string image in images)
            {
                MakeImagesUsingGimp.MakeImages(gimpLocation, image);
<<<<<<< HEAD
                textBox_OutputLog.Text = textBox_OutputLog.Text + "\r\n" + "[" + Path.GetFileNameWithoutExtension(image) + "] finished."; 
=======

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

                
>>>>>>> 4f1e5f8397d336f562b4bfb4986d3203096b1a20
            }
        }

        private void buttonCreateTiles_Click(object sender, EventArgs e)
        {

            var imageCount = images.Length;
            if (imageCount == 0)
            {
                images = GetImagesLocation.ImagesLocation();
            }

            textBox_OutputLog.Text = "Starting Tile creation...";
            foreach (string image in images)
            {

                MakeJSONFile.MakeJSONFileProcess(image);
                textBox_OutputLog.Text = textBox_OutputLog.Text + "\r\n" + "[" + Path.GetFileNameWithoutExtension(image) + "] finished.";
            }

        }

        private void button_OpenTempFolder_Click(object sender, EventArgs e)
        {
            
            Process.Start(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\CreateUrealmsTiles");
        }

    }   
}
