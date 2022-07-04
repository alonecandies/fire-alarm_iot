using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp.Model
{
    public class Device
    {
        public int id { get; set; }
        public String name { get; set; }
        public double max_temperature { get; set; }
        public bool is_off { get; set; }
        public bool is_alert { get; set; }
        public bool is_sendWater { get; set; }
        public int station_id { get; set; }
        public DateTime updated_at { get; set; }
        public String station_name { get; set; }
        public Record[] data { get; set; }
        public String phones { get; set; }
    }

    
}
