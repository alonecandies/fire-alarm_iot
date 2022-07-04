using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinApp.Model;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Net.Http.Headers;
using System.Net;
using System.IO;
using WinApp.Model;
using WinApp.View;

namespace WinApp.Controller
{
    public class DeviceController : BaseController
    {
        public void Init(Panel panelChildForm)
        {
            openChildForm(panelChildForm, new frmProDevice());
        }

        public static List<Device> DeviceList = new List<Device>();

        public static Dictionary<int, string> DeviceDict = new Dictionary<int, string>();
        public async Task<List<Device>> GetAllDevice()
        {
            var respond = await GET("Device", String.Empty , BaseController.token);
            if (respond == null) return null;
            List<Device> dvLst = (List<Device>)Deserializing<List<Device>>(respond.ToString());
            DeviceDict.Clear();
            foreach (Device item in dvLst)
            {
                DeviceDict.Add(item.id, item.name);
                item.data = await GetRecordById(item.id);
            }
            DeviceList = dvLst;
            return dvLst;
        }

        public async static Task<List<Device>> GetApartDevice()
        {
            var respond = await GET("Device", String.Empty, BaseController.token);
            if (respond == null) return null;
            List<Device> dvLst = (List<Device>)Deserializing<List<Device>>(respond.ToString());
            DeviceDict.Clear();
            foreach (Device item in dvLst)
            {
                DeviceDict.Add(item.id, item.name);
            }
            DeviceList = dvLst;
            return dvLst;
        }

        public Device[] GetDeviceByLocation(int id)
        {
            return null;
        }

        public static async Task<Device> EditDevice (int idDevice, Device dvObj)
        {
            var respond = await PUT("Device", "/" + idDevice, BaseController.token, dvObj);
            if (respond == null) return null;
            Device dv = (Device)Deserializing<Device>(respond.ToString());
            var res = await GetApartDevice();
            return dv;
        }

        public void deleteDivice(int id)
        {

        }
        public static async Task<Device> GetStatusById(int id)
        {
            var respond = await GET("Device/Status/", id.ToString() , BaseController.token);
            Device[] dvLst = (Device[]) Deserializing<Device[]>(respond.ToString());
            return dvLst[0];
        }
        public void updatePhone(int id)
        {

        }

        public void insertPhone(int id)
        {

        }

        public void deletePhone(int id)
        {

        }

        public static async Task<Record[]> GetRecordById(int id)
        {
            var respond = await GET("Record/", id.ToString(), BaseController.token);
            Record[] rcLst = (Record[])Deserializing<Record[]>(respond.ToString());
            return rcLst;
        }
    }
}
