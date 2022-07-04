using DeviceDemo.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace DeviceDemo.Views.Device
{
    class Led : Border
    {
        static Brush Safe = Brushes.Green;
        static Brush HighTemp = Brushes.Yellow;
        static Brush Causion = Brushes.Orange;
        static Brush Burning = Brushes.Red;
        static Brush Off = Brushes.LightGray;

        public Led()
        {
            this.Width = this.Height = 30;
            this.CornerRadius = new CornerRadius(this.Width / 2);
            this.BorderThickness = new Thickness(1);
            this.Background = Off;
        }
        public int State
        {
            get => Background == Off ? 1 : 0;
            set
            {
                if (value == -1) this.Background = Off;
                else if (value == 0) this.Background = Safe;
                else if (value == 1) this.Background = HighTemp;
                else if (value == 2) this.Background = Causion;
                else if (value == 3)
                {
                    this.Background = Burning;
                }
            }
        }
    }
    class Demo : BaseView<Models.DeviceViewModel, MyTableLayout>
    {
        Dictionary<string, Led> _leds = new Dictionary<string, Led>();
        void SetValue(int value)
        {
            int v = 3 - value;
            _leds["LED0"].State = -1;
            _leds["LED1"].State = -1;
            _leds["LED2"].State = -1;
            _leds["LED3"].State = -1;
            _leds["LED" + v.ToString()].State = value;
            //Model.UpdateStatus(value);
        }

        void SetValue(string name, int value)
        {
            _leds[name].State = value;
        }

        Image CreateImage(string path)
        {
            Image img = new Image();
            string bitmapPath = @path;
            BitmapImage bitmapImage = new BitmapImage(new Uri(bitmapPath, UriKind.Relative));
            img.Source = bitmapImage;
            return img;
        }
        protected override void RenderBody()
        {
            var gridTbl = new MyTableLayout();
            var gridLed = new MyTableLayout();
            var gridSetTemp = new MyTableLayout();
            var gridTemp = new MyTableLayout();
            var gridTestTemp = new MyTableLayout();
            var gridAlert = new MyTableLayout();
            var gridBuring = new MyTableLayout();
            
            //MainContent.AddRow(gridTbl);
            MainContent.AddRow(gridLed);
            MainContent.AddRow(gridSetTemp);
            MainContent.AddRow(gridTemp);
            MainContent.AddRow(gridTestTemp);
            MainContent.AddRow(gridAlert);
            MainContent.AddRow(gridBuring);

            MainContent.Background = Brushes.White;

            string[] s = new string[4] { "An Toàn ✓", "Nhiệt Độ Cao !", "Nhiệt Độ Nguy Hiểm ✕", "Cháy !!!" };
            int i = 0, c = 0;

            //Hiển thị Led
            foreach (var p in Model.Status)
            {
                var led = new Led();
                var tbl = new TextBlock
                {
                    Text = s[c],
                    TextAlignment = TextAlignment.Center,
                    FontSize = 14,
                    Margin = new Thickness(1),
                    Width = 150,
                    Height = 30,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                gridLed.Add(0, c++, tbl);
                gridLed.Add(1, Model.Status.Count - (++i), led);
                _leds.Add(p.Key, led);
            }

            //TextBlock cài đặt nhiệt độ
            var tbl0 = new TextBlock
            {
                Text = "Thay đổi Ngưỡng Báo Động:" +
                "\n<= 30 là An toàn, <= 50 là Nhiệt độ cao\n<= 70 là Nhiệt độ nguy hiểm, \n> 70 là Cháy!",
                TextAlignment = TextAlignment.Left,
                FontSize = 14,
                Margin = new Thickness(1),
                Width = 250,
                Height = 80,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            gridSetTemp.Add(0, 0, tbl0);

            //TextBox cài đặt nhiệt độ
            var tbSetTemp = new TextBox
            {
                Text = "30-50-70",
                TextAlignment = TextAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                FontSize = 14,
                Margin = new Thickness(1),
                Width = 150,
                Height = 50,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            gridSetTemp.Add(0, 1, tbSetTemp);

            double tempHighTemp = 30;
            double tempCausion = 50;
            double tempAlert = 70;
            double tempNow = 20;
            double humiNow = 50;
            Image img = CreateImage("alert.PNG");
            Image img1 = CreateImage("fire.PNG");
            img1.Opacity = 0;
            gridBuring.Add(0, 0, img1);

            //Button áp dụng cài đặt nhiệt độ
            var btnSetTemp = new Button
            {
                Content = "Áp Dụng",
                Margin = new Thickness(1),
                Width = 100,
                Height = 50,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            btnSetTemp.Click += (b, e) =>
            {
                double t;
                string[] setup = tbSetTemp.Text.Split('-');
                if (double.TryParse(setup[0], out t) && double.TryParse(setup[1], out t) && double.TryParse(setup[2], out t))
                {
                    double t1 = double.Parse(setup[0]);
                    double t2 = double.Parse(setup[1]);
                    double t3 = double.Parse(setup[2]);
                    if (t1 < t2 && t2 < t3)
                    {
                        MessageBox.Show("Cài Đặt Thành Công");
                        tempHighTemp = t1;
                        tempCausion = t2;
                        tempAlert = t3;
                    }
                }
                else MessageBox.Show("Cài Đặt Thất Bại\nNhập Sai Format");
            };
            gridSetTemp.Add(0, 2, btnSetTemp);

            //TextBlock hiển thị nhiệt độ
            var tbl1 = new TextBlock
            {
                Text = "Nhiệt Độ Hiện Tại:\n",
                TextAlignment = TextAlignment.Left,
                FontSize = 14,
                Margin = new Thickness(1),
                Width = 200,
                Height = 40,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            gridTemp.Add(0, 0, tbl1);
            var tblTemp = new TextBlock
            {
                Text = "20°C",
                Foreground = Brushes.Red,
                TextAlignment = TextAlignment.Center,
                FontSize = 50,
                Margin = new Thickness(1),
                Width = 200,
                Height = 80,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            gridTemp.Add(0, 1, tblTemp);

            DateTime now = DateTime.Now;
            //TextBlock hiển thị thời gian
            var tblTime = new TextBlock
            {
                Text = now.ToString(),
                TextAlignment = TextAlignment.Center,
                FontSize = 14,
                Margin = new Thickness(1),
                Width = 200,
                Height = 40,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            gridTemp.Add(0, 2, tblTime);

            //TextBlock hiển thị độ ẩm
            var tbl2 = new TextBlock
            {
                Text = "Độ ẩm hiện tại:",
                TextAlignment = TextAlignment.Left,
                FontSize = 14,
                Margin = new Thickness(1),
                Width = 200,
                Height = 40,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            gridTestTemp.Add(0, 0, tbl2);
            var tblHumi = new TextBlock
            {
                Text = "50 %",
                Foreground = Brushes.Blue,
                TextAlignment = TextAlignment.Center,
                FontSize = 30,
                Margin = new Thickness(1),
                Width = 200,
                Height = 80,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            gridTestTemp.Add(0, 1, tblHumi);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += SendRecord;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            void SendRecord(object sender, EventArgs e)
            {
                int round = int.Parse(now.Minute.ToString()) - int.Parse(DateTime.Now.Minute.ToString());
                int second = int.Parse(now.Second.ToString()) - int.Parse(DateTime.Now.Second.ToString());
                if (second == -5 || second == 54)
                {
                    now = DateTime.Now;
                    Random();
                }
                else if (round == -1 || round == 59)
                {
                    now = DateTime.Now;
                    HTTP_Post();
                }
                tblTime.Text = DateTime.Now.ToString();
            }

            void Random()
            {
                Random random = new Random();
                tempNow = random.Next(1, 100);
                humiNow = random.Next(20, 70);
                tblTemp.Text = tempNow.ToString() + "°C";
                tblHumi.Text = humiNow.ToString() + "%";
                if (tempNow <= tempHighTemp) { img1.Opacity = 0; SetValue(0); }
                else if (tempNow <= tempCausion) { img1.Opacity = 0; SetValue(1); }
                else if (tempNow <= tempAlert) { img1.Opacity = 0; SetValue(2); }
                else if (tempNow > tempAlert) { img1.Opacity = 100; SetValue(3); HTTP_Post(); }
            }

            //Button kiểm tra nhiệt độ
            var btnTemp = new Button
            {
                Content = "Generate Nhiệt Độ",
                Margin = new Thickness(1),
                Width = 150,
                Height = 50,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            btnTemp.Click += (b, e) =>
            {
                Random();
            };
            gridTestTemp.Add(0, 2, btnTemp);

            async void HTTP_Post()
            {
                var httpClient = new HttpClient();
                var httpMessageRequest = new HttpRequestMessage();
                httpMessageRequest.Method = HttpMethod.Post;
                httpMessageRequest.RequestUri = new Uri("http://localhost:5000/Record");
                
                Random random = new Random();
                int temp = random.Next(1, 100);
                int humi = random.Next(20, 70);


                string data = "{\"temperature\":" + temp.ToString() + ", \"humidity\":" + humi.ToString() + ", \"device_id\":" + Model.Id + "}";

                var content = new StringContent(data, Encoding.UTF8, "application/json");
                httpMessageRequest.Content = content;

                var httpResponseMessage = await httpClient.SendAsync(httpMessageRequest);
                var html = await httpResponseMessage.Content.ReadAsStringAsync();
                MessageBox.Show(html);
            }

            var btnAlert = new Button
            {
                Content = img,
                Margin = new Thickness(1),
                Width = 100,
                Height = 100,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            btnAlert.Click += async (b, e) =>
            {
                img1.Opacity = 100;
                //MessageBox.Show(Model.Id);
                tblTemp.Text = "100°C";
                SetValue(3);
                HTTP_Post();
                return;
            };
            gridAlert.Add(0, 1, btnAlert);

            var tblAlert1 = new TextBlock
            {
                Text = "✕DÙNG BÌNH CHỮA CHÁY✕",
                Foreground = Brushes.Red,
                TextAlignment = TextAlignment.Left,
                FontSize = 20,
                Margin = new Thickness(1),
                Width = 400,
                Height = 40,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            gridAlert.Add(0, 2, tblAlert1);

            var tblAlert2 = new TextBlock
            {
                Text = "✕GỌI NGAY 114✕",
                Foreground = Brushes.Red,
                TextAlignment = TextAlignment.Right,
                FontSize = 20,
                Margin = new Thickness(1),
                Width = 400,
                Height = 40,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            gridAlert.Add(0, 0, tblAlert2);

            gridLed.SetWidths(GridUnitType.Star, 1, 1, 1, 1);
            gridLed.SetHeights(GridUnitType.Star, 1, 1);
            gridSetTemp.SetWidths(GridUnitType.Star, 1, 1, 1);
            gridTemp.SetWidths(GridUnitType.Star, 1, 1, 1);
            gridTestTemp.SetWidths(GridUnitType.Star, 1, 1, 1);
            gridAlert.SetWidths(GridUnitType.Star, 1, 1, 1);
            gridBuring.SetWidths(GridUnitType.Star, 1);

            MainContent.SetHeights(GridUnitType.Star, 1, 1, 1, 1, 1, 1);
        }
    }
}
