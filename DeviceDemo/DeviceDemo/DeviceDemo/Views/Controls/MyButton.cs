using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DeviceDemo.Views.Controls
{
    class MyButton
    {
        public static void Init(Grid button, Action clickCallback)
        {
            button.PreviewMouseLeftButtonUp += (s, e) => {
                clickCallback?.Invoke();
            };
        }
    }
}
