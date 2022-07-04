using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinApp.Model;
using WinApp.Controller;

namespace WinApp.View
{
    public partial class frmStation : Form
    {
        public frmStation()
        {
            InitializeComponent();
        }

        

        private void frmStation_Load(object sender, EventArgs e)
        {
            StationController control = new StationController();
            control.LoadListFowPanel(flowLayoutPanel1, this);
        }

        

        
    }
}
