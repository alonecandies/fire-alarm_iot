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
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;

namespace WinApp.View
{
    public partial class frmStatic : Form
    {
        public frmStatic()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStatic_Load(object sender, EventArgs e)
        {
            foreach (var item in DeviceController.DeviceDict)
            {
                cbDeviceName.Items.Add(item.Value);
            }
            recordBindingSource.DataSource = new List<Record>();
            //cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            //{
            //    Title = "Time",
            //    Labels = new[] { "test", "test2" }
            //});
            //cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            //{
            //    Title = "Temperature, do am",
            //    LabelFormatter = value => value.ToString("C")
            //});
            //cartesianChart1.LegendLocation = LiveCharts.LegendLocation.Right;
            //cartesianChart1.Series = new SeriesCollection()
            //{
            //    new LineSeries
            //    {
            //        Values = new ChartValues<Record>
            //        {
            //            new Record(DateTime.Now, 8),
            //            new Record(DateTime.Now.AddMinutes(9), 9),
            //            new Record(DateTime.Now.AddDays(9), 8),
            //            new Record(DateTime.Now.AddYears(9), 9)
            //        },
            //        PointGeometrySize = 15
            //    },
            //};
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            recordBindingSource.DataSource = null;
            var myKey = DeviceController.DeviceDict.FirstOrDefault(x => x.Value == cbDeviceName.Text).Key;
            recordBindingSource.DataSource = await StaticController.GetRecordById((int)myKey);
            //dataGridView1.DataSource = await StaticController.GetRecordById(3);
        }

    }
}
