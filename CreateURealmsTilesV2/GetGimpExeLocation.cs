using System.IO;
using System.Windows.Forms;

namespace CreateURealmsTilesV2
{
    class GetGimpExeLocation
    {
        public static string GimpExeLocation()
        {
            string gimpLocation = @"C:\Program Files\GIMP 2\bin\gimp-2.8.exe";

            if (File.Exists(gimpLocation) == false)
            {
                OpenFileDialog GetGIMPExe = new OpenFileDialog
                {

                    Title = "'gimp-2.8.exe' not found in default location. Please select it.",
                    InitialDirectory = @"C:\Program Files\GIMP 2\bin",
                    Filter = "gimp-2.8.exe|gimp-2.8.exe",
                    FilterIndex = 2,
                    RestoreDirectory = true

                };
                GetGIMPExe.ShowDialog();
                gimpLocation = GetGIMPExe.FileName;
            }

            return gimpLocation;

        }


    }
}
