using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinApp.Controller;
using WinApp.Model;

namespace WinApp.View
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            //LoadList();
            DashboardController control = new DashboardController();
            control.LoadListFowPanel(flowLayoutPanel1);
        }

        private void LoadList()
        {
            Device dv = new Device();
            DeviceController dvc = new DeviceController();
            dv.is_alert = true;
            dv.is_sendWater = true;
            dv.is_off = false;
            Item[] _list = new Item[20];
            for (int i = 0; i < _list.Length ; i++)
            {
                _list[i] = new Item(dv);

                if (flowLayoutPanel1.Controls.Count < 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                }
                else flowLayoutPanel1.Controls.Add(_list[i]);
            }

        }
    }
}
