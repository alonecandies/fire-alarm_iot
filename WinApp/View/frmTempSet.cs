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
    public partial class frmTempSet : Form
    {
        private static Device _dv = new Device();
        public frmTempSet()
        {
            InitializeComponent();
            this.btnSubmit.Click += (s, e) => {
                Submit();
            };
            this.Load += (s, e) => {
                Init();
            };  
        }
        private async void Submit()
        {
            if(txtMaxTemp.Text == null || lbAlarm.Tag == null || lbWater.Tag == null)
            {
                MessageBox.Show("Yêu cầu nhập đủ thông tin");
                return;
            }
            //MessageBox.Show("alarm " + lbAlarm.Tag + " water " + lbWater.Tag);
           
            _dv.max_temperature = Double.Parse(txtMaxTemp.Text);
            _dv.is_alert = (lbAlarm.Tag.ToString() == "on" ? true : false);
            _dv.is_sendWater = (lbWater.Tag.ToString() == "on" ? true : false);
            var res = await DeviceController.EditDevice(_dv.id, _dv);
            item1.LoadData(_dv);
        }

        private async void Init()
        {
            cbDeviceName.Items.Clear();
            if (DeviceController.DeviceDict.Count == 0)
            {
                var a = await DeviceController.GetApartDevice();
            }
            foreach (var item in DeviceController.DeviceDict)
            {
                cbDeviceName.Items.Add(item.Value);
            }
        }
        

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            var myKey = DeviceController.DeviceDict.FirstOrDefault(x => x.Value == cbDeviceName.Text).Key;
            _dv = await DeviceController.GetStatusById((int)myKey);
            item1.LoadData(_dv);
            Init();
        }

        

        private void btnOnAlarm_Click(object sender, EventArgs e)
        {
            ResetBackColor("alarm");
            btnOnAlarm.BackColor = Color.Red;
            lbAlarm.Tag = "on";
        }

        private void btnOffAlarm_Click(object sender, EventArgs e)
        {
            ResetBackColor("alarm");
            btnOffAlarm.BackColor = Color.LimeGreen;
            lbAlarm.Tag = "off";
        }

        private void btnOnWater_Click(object sender, EventArgs e)
        {
            ResetBackColor("water");
            btnOnWater.BackColor = Color.Red;
            lbWater.Tag = "on";
        }

        private void btnOffWater_Click(object sender, EventArgs e)
        {
            ResetBackColor("water");
            btnOffWater.BackColor = Color.LimeGreen;
            lbWater.Tag = "off";
        }

        private void ResetBackColor(string option)
        {
            if(option == "alarm")
            {
                btnOnAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
                btnOffAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            }
            else
            {
                btnOnWater.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
                btnOffWater.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            }
        }
    }
}
