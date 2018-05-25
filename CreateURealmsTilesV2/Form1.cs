using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace CreateURealmsTilesV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> images = new List<string>();
        public string errorLog;
        public static string TempFolder = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\CreateUrealmsTiles";

        private void button_CreateImages_Click(object sender, EventArgs e)
        {
            string gimpLocation = textBox_gimpLocation.Text;
            images = GetImagesLocation.ImagesLocation();

            if (images.Count == 0)
            {
                textBox_OutputLog.Text = "No images selected.";
            }
            else
            {
                textBox_OutputLog.Text = "Starting images creation...";
                MakeImagesUsingGimp.MakeBulkImages(gimpLocation, images);
                /*
                foreach (string image in images)
                {
                    MakeImagesUsingGimp.MakeImages(gimpLocation, image);
                    textBox_OutputLog.Text = textBox_OutputLog.Text + "\r\n" + "[" + Path.GetFileNameWithoutExtension(image) + "] finished.";
                }
                */
                textBox_OutputLog.Text = "Finished!";
            }
        }

        private void buttonCreateTiles_Click(object sender, EventArgs e)
        {

            int imageCount = images.Count;
            if (imageCount == 0)
            {
                images = GetImagesLocation.ImagesLocation();
                imageCount = images.Count;
            }

            if (images.Count == 0)
            {
                textBox_OutputLog.Text = "No images selected.";
            }
            else
            {
                textBox_OutputLog.Text = "Starting Tile creation for [" + imageCount + "] images...";
                foreach (string image in images)
                {
                    int i = images.IndexOf(image) + 1;
                    textBox_OutputLog.Text = textBox_OutputLog.Text + "\r\n" + "Starting tile [" + i + "] of [" + imageCount + "].";

                    MakeJSONFile.MakeJSONFileProcess(image);

                    textBox_OutputLog.Text = textBox_OutputLog.Text + "\r\n" + "[" + Path.GetFileNameWithoutExtension(image) + "] finished.";
                }
            }

        }

        private void button_OpenTempFolder_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\CreateUrealmsTiles");
        }

    }   
}
