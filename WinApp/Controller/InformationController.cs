using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinApp.View;

namespace WinApp.Controller
{
    class InformationController : BaseController
    {
        public void Init(Panel panelChildForm)
        {
            openChildForm(panelChildForm, new frmInfor());
        }
    }
}
