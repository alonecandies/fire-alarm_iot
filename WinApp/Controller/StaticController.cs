using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinApp.View;
using WinApp.Model;
using Newtonsoft.Json;

namespace WinApp.Controller
{
    class StaticController : BaseController
    {
        public void Init(Panel panelChildForm)
        {
            openChildForm(panelChildForm, new frmStatic());
        }
        public static async Task<List<Record>> GetRecordById(int idDevice)
        {
            var respond = await GET("Record", "/"+ idDevice, BaseController.token);
            if (respond == null) return null;
            List<Record> Lst = (List<Record>)Deserializing<List<Record>>(respond.ToString());
            return Lst;
        }
    }
}
