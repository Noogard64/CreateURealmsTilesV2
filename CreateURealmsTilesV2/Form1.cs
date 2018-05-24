using System;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;

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

            int numberOfImages = images.Count();

            var increments = 100 /numberOfImages;

            foreach (string image in images)
            {
                
                MakeImagesUsingGimp.MakeImages(gimpLocation, image);
                progressBar_CreateImages.Value = progressBar_CreateImages.Value + increments;
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
