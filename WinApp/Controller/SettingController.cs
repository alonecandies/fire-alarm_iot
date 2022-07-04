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
    class SettingController : DeviceController
    {
        public void Init(Panel panelChildForm)
        {
            openChildForm(panelChildForm, new frmTempSet());
        }
    }
}
