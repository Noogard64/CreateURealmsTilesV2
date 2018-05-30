using System;
using System.Text;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace CreateURealmsTilesV2
{
    class Imgur
    {
        public static string UploadImageAndReturnURL(string filename)
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

                    dynamic stuff = JObject.Parse(jsonResults);

                    string url = stuff.data.link;
                    return url;

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }

        }
    }
}
