using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace CreateURealmsTilesV2
{
    class GetImagesLocation
    {
        public static List<string> ImagesLocation()
        {
            
            OpenFileDialog GetImage = new OpenFileDialog
            {

                Title = "Please select an image(s).",
                InitialDirectory = @"C:\Users\"+ Environment.UserName + @"\Desktop",
                FilterIndex = 2,
                RestoreDirectory = true,
                Multiselect = true

            };
            GetImage.ShowDialog();

            return GetImage.FileNames.OfType<string>().ToList<string>();

        }
    }
}
