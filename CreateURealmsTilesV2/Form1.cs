using System;
using System.Windows.Forms;
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

        List<string> images = new List<string>();
        public string errorLog;
        public static string TempFolder = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\CreateUrealmsTiles";
        public static string gimpLocation;

        private void buttonCreateTiles_Click(object sender, EventArgs e)
        {

            gimpLocation = textBox_gimpLocation.Text;
            images = GetImagesLocation.ImagesLocation();

            if (images.Count == 0)
            {
                textBox_OutputLog.Text = "No images selected.";
            }
            else
            {
                textBox_OutputLog.Text = "Starting images creation...";

                foreach (string image in images)
                {
                    textBox_OutputLog.Text = updateLogField("[" + image + "] started!");

                    bool results = URealms.CreateTiles(image);
                    if (results)
                    {
                        textBox_OutputLog.Text = updateLogField("[" + Path.GetFileNameWithoutExtension(image) + "] finished!");
                    }
                    else
                    {
                        textBox_OutputLog.Text = updateLogField("[" + Path.GetFileNameWithoutExtension(image) + "] failed!");
                    }
                }
            }

        }

        private void button_OpenTempFolder_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp\CreateUrealmsTiles");
        }


        private string updateLogField(string logItem)
        {
            return textBox_OutputLog.Text + "\r\n" + logItem;
        }
    }   
}
