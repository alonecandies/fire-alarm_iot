using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinApp.View;
using WinApp.Controller;

namespace WinApp
{
    public partial class Form1 : Form
    {
        public Form1 mainfrm ;
        public Form1()
        {
            InitializeComponent();
            mainfrm = this;
            Init();
        }

        private void Init()
        {
            DashboardController db = new DashboardController();
            LoginController lg = new LoginController();
            InformationController im = new InformationController();
            StationController station = new StationController();
            StaticController sta = new StaticController();
            SettingController set = new SettingController();
            DeviceController dev = new DeviceController();
            lg.Init(panelChildForm, mainfrm);
            hideSubMenu();
            this.btnConnect.Click += (s, e) => {
                lg.Init(panelChildForm, mainfrm);
            };
            this.btnDashboardSub.Click += (s, e) => {
                db.Init(panelChildForm);
            };
            this.btnStaLst.Click += (s, e) => {
                station.Init(panelChildForm);
            };
            this.btnStatic.Click += (s, e) => {
                sta.Init(panelChildForm);
            };
            this.btnInfor.Click += (s, e) => {
                im.Init(panelChildForm);
            };
            this.btnTemAlarmSet.Click += (s, e) => {
                set.Init(panelChildForm);
            };
            this.btnProperties.Click += (s, e) => {
                dev.Init(panelChildForm);
            };

        }

        private void hideSubMenu()
        {
            panelDashBoard.Visible = false;
            panelSettingSubMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            showSubMenu(panelDashBoard);
        }


        #region DashboardSubMenu
        
        private void button2_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void  button3_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnStatic_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }
        #endregion

        private void btnSetting_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSettingSubMenu);
        }

        #region SettingSubMenu
        private void button8_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }
        #endregion

        private void btnEqualizer_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void getInfo()
        {
            btnConnect.BackColor = Color.Green;
            btnConnect.Text = "Conected";

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            getInfo();
        }

        
    }
}
