using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;
using System.Net;
using System.IO;
using WinApp.Model;
using WinApp.View;

namespace WinApp.Controller
{
    class LoginController : BaseController
    {
        public void Init(Panel panelChildForm, Form1 mainfrm)
        {
            openChildForm(panelChildForm, new frmLogin(mainfrm));
        }

        public static async Task<string> GetToken(User use)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(baseURL + "User");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            //httpWebRequest.Headers["haha"] = "test";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"username\":\"" + use.username + "\"," +
                              "\"password\":\"" + use.password + "\"}";
                streamWriter.Write(json);
            }

            using (var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync())
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string data = await streamReader.ReadToEndAsync();
                if (data != null)
                {
                    Login account = JsonConvert.DeserializeObject<Login>(data);
                    token = account.token.ToString();
                    return account.token.ToString();
                }
            }
            return string.Empty;
        }
    }
}
