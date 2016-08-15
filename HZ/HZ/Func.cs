using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.ComponentModel;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HZ
{
    class Func
    {
    

        public class result
        {
            public string type { get; set; }
            public string message { get; set; }          
        }

        public static result getResult(string result)
        {
            result ret = (result)JsonConvert.DeserializeObject(result,typeof(result));
            return ret;

        }


        public  async static Task<string> PostRequest(string Url, IEnumerable<KeyValuePair<string, string>> queries)
        {


            HttpContent q = new FormUrlEncodedContent(queries);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.PostAsync(Url, q))
                {
                    using (HttpContent content = response.Content)
                    {
                        string myContent = await content.ReadAsStringAsync();
                        //HttpContentHeaders headers = content.Headers; 

                        return myContent;
                    }
                }
            }
        }
        public static int HideUpDown(System.Windows.Forms.NumericUpDown num)
        {
            Label tmpLabel = new Label();
            tmpLabel.Size = num.Controls[0].Size;
            tmpLabel.Location = num.Controls[0].Location;
            num.BackColor = Color.White;

            num.Controls[0].Visible = true;
            num.Controls.Add(tmpLabel);
            tmpLabel.BringToFront();
            num.ReadOnly = true;
            num.Enabled = false;

            return 1;
        }
    }
}
