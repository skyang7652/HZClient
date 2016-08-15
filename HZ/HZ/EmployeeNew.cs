using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HZ
{
    public partial class FormEmployeeNew : Form
    {
        public static string firstName = null;
        public static string lastName = null;
        public static string pay = null;
        public static string overtimePay = null;
        public static string phone = null;
        public static string address = null;
     

        public FormEmployeeNew()
        {
            InitializeComponent();
        }

        private void FormEmployeeNew_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            firstName = textBoxFirstName.Text;
            lastName =  textBoxLastName.Text;
            pay = numPay.Value.ToString();
            overtimePay = numOvetime.Value.ToString();
            phone = textBoxPhone.Text;
            address = textBoxAddress.Text;
            string api = API.getApi((int)ENUM.API_t.API_NEW_EMPLOYEE);
            
            Task<string> task = Task.Run(() => PostRequest(api)) ;

            string content = task.Result;

            Func.result Ret = new Func.result();
            Ret = Func.getResult(content);
            if(Ret.type == "E000")
            {
                MessageBox.Show("新增成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("新增失敗 Message:" + Ret.message);
                this.Close();
            }

        }
        
        async static Task<string> PostRequest(string Url)
        {
            
            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("firstName", firstName),
                new KeyValuePair<string, string>("lastName", lastName),
                new KeyValuePair<string, string>("pay", pay),
                new KeyValuePair<string, string>("overtimePay", overtimePay),
                new KeyValuePair<string, string>("phone", phone),
                new KeyValuePair<string, string>("address", address),
            };
            HttpContent q = new FormUrlEncodedContent(queries);
            using(HttpClient client = new HttpClient())
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

    }
}
