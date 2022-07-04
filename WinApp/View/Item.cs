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
    public partial class Item : UserControl
    {
        public Item()
        {
            InitializeComponent(); 
        }

        public Item(Device _dev)
        {
            InitializeComponent();
            lbDeviceName.Text = (_dev.name == null ? "Unknow" : _dev.name.ToUpper());
            lbStation.Text = StationController.LocationDict[_dev.station_id] == null ? "Unknow" : StationController.LocationDict[_dev.station_id];
            lbOnOff.Text = (_dev.is_off ? "Turned Off" : "Turned On");
            lbMaxTemp.Text += ": " + _dev.max_temperature + "°C";
            lbWater.Text = (_dev.is_sendWater ? "Watering" : "Not Watering");
            txtAlert.Text = (_dev.is_alert ? "Alert" : "Good");
            pnAlarm.BackColor = (_dev.is_alert ? Color.Red : Color.LimeGreen);
            double temperature = 10, humidity = 10;
            if (_dev.data != null)
            {
                if(_dev.data.Length == 0)
                {
                    //MessageBox.Show("check");
                    return;
                }
                //MessageBox.Show(_dev.name + _dev.data[_dev.data.Length - 1].temperature.ToString());
                temperature = _dev.data[_dev.data.Length - 1].temperature;
                humidity = _dev.data[_dev.data.Length - 1].humidity;
            }
            circularProgressBar1.Value = (int)humidity;
            circularProgressBar1.Text = humidity.ToString();
            circularProgressBar2.Text = temperature.ToString();
            if (_dev.max_temperature <= 0)
            {
                circularProgressBar2.Value = (int)(100 * temperature / 100);
            }
            else
            {
                if(temperature > _dev.max_temperature)
                {
                    circularProgressBar2.Value = 1;
                    return;
                }
                circularProgressBar2.Value = (int)(100 * temperature / _dev.max_temperature);
            }

        }

        public async void LoadData(Device _dev)
        {
            lbDeviceName.Text = (_dev.name == null ? "Unknow" : _dev.name.ToUpper());
            if(StationController.LocationDict.Count == 0)
            {
                StationController location = new StationController();
                await location.getLocations();
            }
            lbStation.Text = StationController.LocationDict[_dev.station_id] == null ? "Unknow" : StationController.LocationDict[_dev.station_id];
            lbOnOff.Text = (_dev.is_off ? "Turned Off" : "Turned On");
            lbMaxTemp.Text = "Max Temperature";
            lbMaxTemp.Text += ": " + _dev.max_temperature + "°C";
            lbWater.Text = (_dev.is_sendWater ? "Watering" : "Not Watering");
            txtAlert.Text = (_dev.is_alert ? "Alert" : "Good");
            pnAlarm.BackColor = (_dev.is_alert ? Color.Red : Color.LimeGreen);
        }


    }
}
