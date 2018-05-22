using System;
using System.Windows.Forms;

namespace CreateURealmsTilesV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_CreateImages_Click(object sender, EventArgs e)
        {

            string gimpLocation = textBox_gimpLocation.Text;
            string[] images = textBox_imageLocation.Text.Split(',');

            MakeImagesUsingGimp.MakeImages(gimpLocation, images);
        }

        void button_getImage_Click(object sender, EventArgs e)
        {
            string[] results = GetImagesLocation.ImagesLocation();
            textBox_imageLocation.Text = String.Join(", ", results);
        }


        //TODO - Update the textBox_OutputLog.Text value with error messages.
        /*
        public static void textBox_OutputLog_Update(string logValue)
        {
            string currentValue = textBox_OutputLog.Text;

            //Button textBox_OutputLog = (Button);

            Form1.textBox_OutputLog.Text += currentValue + "\r\n" + logValue;

        }
        */
    }   
}
