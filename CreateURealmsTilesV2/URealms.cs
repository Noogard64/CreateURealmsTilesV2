using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;


namespace CreateURealmsTilesV2
{
    class URealms
    {
        public static bool CreateTiles(string fileName)
        {

            //#######################################################################
            //Starting GIMP process
            //#######################################################################
            try
            {
                string args = "gimp --as-new --verbose --no-interface -idf --batch-interpreter=python-fu-eval -b \"import sys; sys.path =['.'] + sys.path; import batch_CreateURealmsTileImages; batch_CreateURealmsTileImages.run('" + fileName + "')\" -b \"pdb.gimp_quit(1)\"";
                string gimpLocation = Form1.gimpLocation;
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

                var process = Process.Start(startInfo);

                process.WaitForExit();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;

            }

            //#######################################################################
            //Getting a child images
            //#######################################################################
            
            //Getting file name without extension
            string imageFileNameNoExt = Path.GetFileNameWithoutExtension(fileName);
            string[] tileImages;

            try
            {
                //Getting temp directory for tile images
                string tileImageDirectory = Form1.TempFolder + @"\" + imageFileNameNoExt;

                //Getting tile images
                tileImages = Directory.GetFiles(tileImageDirectory, "*.png");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }


            //#######################################################################
            //Create JSON file
            //#######################################################################

            string newJsonFileNameAndLocation;
            try
            { 
                //Getting json template
                string jsonTemplate = Environment.CurrentDirectory + @"\json_Example.json";

                //Creating new filepath and file name for new JSON file.
                newJsonFileNameAndLocation = Form1.TempFolder + @"\" + imageFileNameNoExt + @"\" + imageFileNameNoExt + ".json";

                //Copying the new json file to the temp folder location
                File.Copy(jsonTemplate, newJsonFileNameAndLocation, true);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }

            //#######################################################################
            //Upload Images to Imgur
            //#######################################################################

            List<string> urls = new List<string>();
            try
            {
                foreach (string tileImage in tileImages)
                {

                    string tileImageNoPath = Path.GetFileName(tileImage);
                    if ((tileImageNoPath == "Blind.png") || (tileImageNoPath == "Burning.png") || (tileImageNoPath == "Charmed.png") || (tileImageNoPath == "Defeated.png") || (tileImageNoPath == "Frozen.png") || (tileImageNoPath == "Poisoned.png") || (tileImageNoPath == "Silenced.png") || (tileImageNoPath == "Stunned.png") || (tileImageNoPath == "saved_BaseTile.png"))
                    {
                        //Upload image to get URL
                        string url = Imgur.UploadImageAndReturnURL(tileImage);
                        if (url == null)
                        {
                            //Fail
                            break;
                        }
                        else
                        {
                            MakeJSONFile.PopulateJSONFile(url, tileImage, newJsonFileNameAndLocation, fileName);
                            urls.Add(url);
                        }
                    }
                    else
                    {
                        //Do Nothing
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }

            //#######################################################################
            //Clean up extra images
            //#######################################################################

            try
            {
                if (urls.Count == 9)
                {
                    foreach (string tileImage in tileImages)
                    {
                        string tileImageNoPath = Path.GetFileName(tileImage);
                        if ((tileImageNoPath == "Blind.png") || (tileImageNoPath == "Burning.png") || (tileImageNoPath == "Charmed.png") || (tileImageNoPath == "Defeated.png") || (tileImageNoPath == "Frozen.png") || (tileImageNoPath == "Poisoned.png") || (tileImageNoPath == "Silenced.png") || (tileImageNoPath == "Stunned.png") || (tileImageNoPath == "saved_BaseTile.png"))
                        {
                            File.Delete(tileImage);
                        }
                    }
                }
                else
                {
                    //Fail
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }

            return true;

        }

    }
}
