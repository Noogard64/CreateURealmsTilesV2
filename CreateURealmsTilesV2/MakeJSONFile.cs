using System;
using System.Text;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CreateURealmsTilesV2
{
    class MakeJSONFile
    {

        public static string ImageTempFolder = Form1.TempFolder;
        public static void MakeJSONFileProcess(string image)
        {

            //declaring some vars
            string url;

            //Get tile images from Temp directory
            var tileImages = GetTileImages(image);

            //Creating JSON file
            var jsonFile = CreateJSONFileFromTemplate(image);

            List<string> urls = new List<string>();

            foreach (string tileImage in tileImages)
            {
                if (tileImage == )
                {

                }
                //Upload image to get URL
                url = UploadImageToImgur(tileImage);

                //populate json file with url
                PopulateJSONFile(url, tileImage, jsonFile, image);

                urls.Add(url);
            }

            if(urls.Count == 9)
            {
                foreach(string tileImage in tileImages)
                {
                    File.Delete(tileImage);
                }
            }

            //string imageName = Path.GetFileNameWithoutExtension(image);

        }

        public static string[] GetTileImages(string image)
        {
            //Getting file name without extension
            string imageFileNameNoExt = Path.GetFileNameWithoutExtension(image);

            //Getting temp directory for tile images
            string tileImageDirectory = ImageTempFolder + @"\" + imageFileNameNoExt;

            //Getting tile images
            string[] tileImages = Directory.GetFiles(tileImageDirectory,"*.png");

            return tileImages;
        }


        public static string CreateJSONFileFromTemplate(string image)
        {

            //Getting file name without extension
            string imageFileNameNoExt = Path.GetFileNameWithoutExtension(image);

            //Getting json template
            string jsonTemplate = Environment.CurrentDirectory + @"\json_Example.json";

            //Creating new filepath and file name for new JSON file.
            string newJsonFileNameAndLocation = ImageTempFolder + @"\" + imageFileNameNoExt + @"\" + imageFileNameNoExt + ".json";

            //Copying the new json file to the temp folder location
            File.Copy(jsonTemplate, newJsonFileNameAndLocation,true);

            return newJsonFileNameAndLocation;
        }

        //Populate JSON file with URLs.
        public static void PopulateJSONFile(string url, string image, string jsonFile, string baseImage)
        {
            //MessageBox.Show(image);
            string fileContent = File.ReadAllText(jsonFile);
            string find;
            string updatedFileContent;

            string baseImageFileNameNoExt = Path.GetFileNameWithoutExtension(baseImage);

            if (image == "Blind.png")
            {
                find = "insert blind url here";
                updatedFileContent = fileContent.Replace(find, url); 
            }
            else if (image == "Burning.png")
            {
                find = "insert burning url here";
                updatedFileContent = fileContent.Replace(find, url);
            }
            else if (image == "Charmed.png")
            {
                find = "insert charmed url here";
                updatedFileContent = fileContent.Replace(find, url);
            }
            else if (image == "Defeated.png")
            {
                find = "insert defeated url here";
                updatedFileContent = fileContent.Replace(find, url);
            }
            else if (image == "Frozen.png")
            {
                find = "insert frozen url here";
                updatedFileContent = fileContent.Replace(find, url);
            }
            else if (image == "Poisoned.png")
            {
                find = "insert poisoned url here";
                updatedFileContent = fileContent.Replace(find, url);
            }
            else if (image == "Silenced.png")
            {
                find = "insert silenced url here";
                updatedFileContent = fileContent.Replace(find, url); 
            }
            else if (image == "Stunned.png")
            {
                find = "insert stunned url here";
                updatedFileContent = fileContent.Replace(find, url);
            }
            else if (image == "saved_BaseTile.png")
            {
                find = "insert base url here";
                updatedFileContent = fileContent.Replace(find, url);
            }
            else
            {
                updatedFileContent = fileContent;
            }

            //string fileContent = File.ReadAllText(jsonFile);
            //string updatedFileContent = fileContent.Replace(find, url);
            File.WriteAllText(jsonFile, updatedFileContent);

        }

        static public string UploadImageToImgur(string file)
        {

            string jsonResults = UploadImage(file);
            if (jsonResults == null)
            {
                MessageBox.Show("jsonResults were null. for ["+ file + "]");
            }

            string url = getURLFromJson(jsonResults);
            return url;

        }


        static public string getURLFromJson(string jsonResults)
        {
            dynamic stuff = JObject.Parse(jsonResults);

            string url = stuff.data.link;
            return url;
        }

        static public string UploadImage(string filename)
        {
            try
            {
                var file = File.ReadAllBytes(filename);

                using (var w = new WebClient())
                {
                    var values = new NameValueCollection
                    {
                        {"image", Convert.ToBase64String(file)},
                        {"type", "base64"}
                    };
                    //client.Headers.Add("Authorization", "BEARER " + accessToken);
                    w.Headers.Add("Authorization", "Client-ID c927064c3cd35e5");
                    var response = w.UploadValues("https://api.imgur.com/3/image", values);

                    string jsonResults = Encoding.UTF8.GetString(response);
                    return jsonResults;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return null;

        }


    }
}
