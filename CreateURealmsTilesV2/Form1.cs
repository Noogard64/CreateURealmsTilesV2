using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace CreateURealmsTilesV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string[] images;
        public string errorLog;

        private void button_CreateImages_Click(object sender, EventArgs e)
        {
            string gimpLocation = textBox_gimpLocation.Text;
            images = GetImagesLocation.ImagesLocation();
            textBox_OutputLog.Text = "Starting images creation...";

            foreach (string image in images)
            {
                MakeImagesUsingGimp.MakeImages(gimpLocation, image);
                textBox_OutputLog.Text = textBox_OutputLog.Text + "\r\n" + "[" + Path.GetFileNameWithoutExtension(image) + "] finished."; 
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
