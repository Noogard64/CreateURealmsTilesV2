using System;
using System.Text;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

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

            foreach (string tileImage in tileImages)
            {
                //Upload image to get URL
                url = UploadImageToImgur(image);

                //populate json file with url
                PopulateJSONFile(url, image, jsonFile);
            }

            string imageName = Path.GetFileNameWithoutExtension(image);

        }

        public static string[] GetTileImages(string image)
        {
            //Getting file name without extension
            string imageFileNameNoExt = Path.GetFileNameWithoutExtension(image);

            //Getting temp directory for tile images
            string tileImageDirectory = ImageTempFolder + @"\" + imageFileNameNoExt;

            //Getting tile images
            string[] tileImages = Directory.GetFiles(tileImageDirectory);

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
        public static void PopulateJSONFile(string url, string image, string jsonFile)
        {

            string find;
            if (image.Contains("Blind"))
            {
                find = "insert blind url here";
            }
            else if (image.Contains("Burning"))
            {
                find = "insert burning url here";
            }
            else if (image.Contains("Charmed"))
            {
                find = "insert charmed url here";
            }
            else if (image.Contains("Defeated"))
            {
                find = "insert defeated url here";
            }
            else if (image.Contains("Frozen"))
            {
                find = "insert frozen url here";
            }
            else if (image.Contains("Poisoned"))
            {
                find = "insert poisoned url here";
            }
            else if (image.Contains("Silenced"))
            {
                find = "insert silenced url here";
            }
            else if (image.Contains("Stunned"))
            {
                find = "insert stunned url here";
            }
            else
            {
                find = "insert base url here";
            }

            string fileContent = File.ReadAllText(jsonFile);
            string updatedFileContent = fileContent.Replace(find, url);
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
                Console.WriteLine(e.ToString());
            }
            return null;

        }


    }
}
