using System;
using System.Collections.Generic;
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

namespace DeviceDemo.Views.Home
{
    /// <summary>
    /// Interaction logic for StartBox.xaml
    /// </summary>
    public partial class StartBox : UserControl
    {
        public StartBox()
        {
            InitializeComponent();

            Views.Controls.MyButton.Init(btnStart, () => {
                Engine.Execute("device/demo/" + this.deviceId.Text.Trim());
            });
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            //Engine.Execute("device/demo/" + this.deviceId.Text.Trim());
        }
    }

    class Default : BaseView<StartBox>
    {

    }
}
