using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text;

namespace WinApp.Controller
{
    public class BaseController
    {
        protected static readonly string baseURL = "http://localhost:5000/";

        private static bool CheckToken()
        {
            if (token == "")
            {
                MessageBox.Show("Vui lòng đăng nhập");
                return true;
            }
            return false;    
        }
        public string Serializing<T>(T obj)
        {
            string output = JsonConvert.SerializeObject(obj);
            return output;
        }

        public static T Deserializing<T>(string output)
        {
            T deserializedProduct = JsonConvert.DeserializeObject<T>(output);
            return deserializedProduct;
        }
        
        public static string token = "";
        public static async Task<string> GET(string path, string querry, string token)
        {
            if (CheckToken()) return null;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("token", token);
                using (HttpResponseMessage res = await client.GetAsync(baseURL + path + querry))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
                return string.Empty;
            }
        }

        public static async Task<string> PUT(string path, string querry, string token, object anObject)
        {
            if (CheckToken()) return null;
            using (HttpClient client = new HttpClient())
            {
                string json = await Task.Run(() => JsonConvert.SerializeObject(anObject));
                var dictionary = JObject.FromObject(anObject).ToObject<Dictionary<string, string>>();
                client.DefaultRequestHeaders.Add("token", token);
                HttpContent input = new StringContent(json, Encoding.UTF8, "application/json");
                using (HttpResponseMessage res = await client.PutAsync(baseURL + path + querry, input))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
                return string.Empty;
            }
        }

        private static Form activeForm = null;
        public void openChildForm(Panel panelChildForm, Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            } 
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
        
}
