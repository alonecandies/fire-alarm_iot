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
    public partial class frmLogin : Form
    {
        public Form1 _mainfrm;
        public frmLogin(Form1 mainfrm)
        {
            InitializeComponent();
            _mainfrm = mainfrm;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.username = txtName.Text;
            user.password = txtPassword.Text;
            var respond = await LoginController.GetToken(user);
            //MessageBox.Show(respond);
            _mainfrm.getInfo();
            this.Close();
        }
        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
