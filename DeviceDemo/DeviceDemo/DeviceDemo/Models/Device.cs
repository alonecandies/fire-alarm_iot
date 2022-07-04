using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceDemo.Models
{
    public class DeviceStatus : Dictionary<string, int> 
    { 
    }
    public class Device : BsonData.Document
    {
        public string Name { get; set; }
        public DeviceStatus Status { get; set; } = new DeviceStatus();
    }
    public class DeviceViewModel : Device
    {
        public void UpdateStatus(int value)
        {
            int i = 0;
            bool changed = true;

            var s = new DeviceStatus();
            
            foreach (var p in Status)
            {
                if (i == 3 - value)
                {
                    s.Add(p.Key, value);
                }
                else s.Add(p.Key, -1);
                i++;
            }
            if (changed)
            {
                Status = s;
                Changed?.Invoke(this, value);
            }
        }

        public event Action<Device, int> Changed;
    }

}