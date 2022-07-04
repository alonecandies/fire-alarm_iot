using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp.Model
{
    public class Record
    {
        public int id { get; set; }
        public double temperature { get; set; }
        public double humidity { get; set; }
        public int device_id { get; set; }
        public DateTime created_at { get; set; }

        //public Record(DateTime dateTime, double value)
        //{
        //    this.created_at = dateTime;
        //    this.temperature = value;
        //}
    }
}
