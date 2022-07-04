using DeviceDemo.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using MQTT = DeviceDemo.Controllers.MqttController;

namespace DeviceDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IWindowView _currentView;
        public MainWindow()
        {
            InitializeComponent();

            Engine.ValidateActionResult = result =>
            {
                var form = result.View as Views.IPopup;
                if (form != null)
                {
                    form.Show();
                    return;
                }
                this.Dispatcher.InvokeAsync(() => {
                    SetMainContent(result.View as IWindowView);
                });
            };
        }

        void SetMainContent(Views.IWindowView view)
        {
            if (view == null) return;

            var content = view.GetMainContent();
            if (content != null)
            {
                panel1.Child = content;
                if (_currentView != null)
                {
                    if (_currentView is IDisposable)
                    {
                        ((IDisposable)(_currentView)).Dispose();
                    }
                }
                _currentView = view;
            }
        }
        protected override void OnContentRendered(EventArgs e)
        {
            MQTT.Connected += (br) => {
                
            };

            Engine.Execute("home");
            base.OnContentRendered(e);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            Engine.Execute("home/exit");
            base.OnClosing(e);
        }
    }
}
