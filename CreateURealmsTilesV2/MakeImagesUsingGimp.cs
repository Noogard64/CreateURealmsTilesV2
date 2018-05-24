using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CreateURealmsTilesV2
{
    class MakeImagesUsingGimp
    {
        static public void MakeImages(string gimpLocation, string file)
        {

            try
            {
                string args = "gimp --as-new --verbose --no-interface -idf --batch-interpreter=python-fu-eval -b \"import sys; sys.path =['.'] + sys.path; import batch_CreateURealmsTileImages; batch_CreateURealmsTileImages.run('" + file + "')\" -b \"pdb.gimp_quit(1)\"";
                var startInfo = new ProcessStartInfo
                {
                    WorkingDirectory = Environment.CurrentDirectory,
                    WindowStyle = ProcessWindowStyle.Normal,
                    FileName = gimpLocation,
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    Verb = "runas",
                    Arguments = args
                };

                Console.WriteLine("#################################");

                Console.WriteLine("Reproduce with follow command line input:");
                Console.WriteLine("cd " + Environment.CurrentDirectory.ToString());
                Console.WriteLine("\"" + gimpLocation  + "\" "+ args);

                var process = Process.Start(startInfo);

                process.WaitForExit();
            }
            catch (Exception e)
            {

                //TODO Finish textBox_OutputLog_Update function in Form1.cs 
                //Form1.textBox_OutputLog_Update(e.ToString());

                MessageBox.Show(e.ToString());

                //Logging.ReportToOutput(e.ToString());

            }
        }
    }
}
