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
    public class DashboardController : DeviceController
    {
        public void Init(Panel panelChildForm)
        {
            openChildForm(panelChildForm, new frmDashboard());
        }

        static List<Device> lst = null;
        public async void LoadListFowPanel(FlowLayoutPanel flp)
        {
            lst = await GetDataFromAPI();
            if (lst == null) return;
            foreach (Device item in lst)
            {
                if (flp.Controls.Count < 0)
                {
                    flp.Controls.Clear();
                }
                else 
                {
                    Item viewItem = new Item(item);
                    flp.Controls.Add(viewItem);
                }
                
            }
        }
        private async Task<List<Device>> GetDataFromAPI()
        {
            StationController sta = new StationController();
            await sta.getLocations();
            DeviceController dv = new DeviceController();
            await dv.GetAllDevice();
            return DeviceController.DeviceList;
        }
    }
}
