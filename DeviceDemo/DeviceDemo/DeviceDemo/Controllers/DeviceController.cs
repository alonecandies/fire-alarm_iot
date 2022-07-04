using System;
using System.Collections.Generic;
using System.Linq;
using System.Mvc;
using System.Text;
using System.Threading.Tasks;

namespace DeviceDemo.Controllers
{
    using DEV = Models.DeviceViewModel;

    class DeviceController : BaseController
    {

        static DEV _selected;
        static void Subcribe()
        {
            if (MqttController.IsConnected)
            {
                MqttController.Broker.Subscribe(
                    new string[] { "control/" + _selected.Id },
                    new byte[] { 0 });
            }
        }
        static void Publish(int value)
        {
            if (MqttController.IsConnected)
            {
                MqttController.Broker.Publish(
                    "status/" + _selected.Id, 
                    Encoding.ASCII.GetBytes("{\"value\":" + value + "}"));
            }
        }
        public ActionResult Demo(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Redirect("home");
            }

            var s = new Models.DeviceStatus();
            for (int i = 0; i < 4; i++)
                s.Add("LED" + i, -1);

            _selected = new DEV { Id = id, Status = s };
            _selected.Changed += (d, v) => {
                Publish(v);
            };
            MqttController.Connected += br => {
                Subcribe();
            };
            Engine.CreateThread(MqttController.Connect);

            return View(_selected);
        }
    }
}
