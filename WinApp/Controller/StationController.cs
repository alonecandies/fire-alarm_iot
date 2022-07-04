using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinApp.View;
using WinApp.Model;
using Newtonsoft.Json;

namespace WinApp.Controller
{
    public class StationController : BaseController
    {
        public void Init(Panel panelChildForm)
        {
            openChildForm(panelChildForm, new frmStation());
        }
        public static Dictionary<int, string> LocationDict = new Dictionary<int, string>();
        public async Task<List<Station>> getLocations()
        {
            var respond = await GET("Location", String.Empty, BaseController.token);
            if (respond == null) return null;
            List<Station> stLst = (List<Station>)Deserializing<List<Station>>(respond.ToString());
            LocationDict.Clear();
            foreach (Station item in stLst)
            {
                LocationDict.Add(item.id, item.location_name);
            }
            return stLst;
        }

        public void createLocations()
        {

        }

        public void editLocation(int id)
        {

        }

        public async void LoadListFowPanel(FlowLayoutPanel flp, Form ParentFrm)
        {
            List<Station> lst = new List<Station>();
            lst.Clear();
            lst = await getLocations();
            if (lst == null) return;
            foreach (Station item in lst)
            {
                if (flp.Controls.Count < 0)
                {
                    flp.Controls.Clear();
                }
                else
                {
                    Button viewItem = new Button();
                    viewItem = CustomButton(viewItem, item, item.location_name.ToString(), lst.FindIndex(a => a.location_name == item.location_name), ParentFrm);
                    flp.Controls.Add(viewItem);
                }
            }
        }

        public Button CustomButton(Button btn, Station locationObj ,string location, int color, Form ParentFrm)
        {
            btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            if (color % 2 == 1)
            {
                btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            }
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn.ForeColor = System.Drawing.Color.LightGray;
            btn.Size = new System.Drawing.Size(350, 40);
            btn.Text = location;
            btn.UseVisualStyleBackColor = false;
            btn.Tag = "ID = " + locationObj.id.ToString() + "and updated at" + locationObj.updated_at.ToString();
            btn.Click += (s, e) => {
                MessageBox.Show(btn.Tag.ToString());
            };
            return btn;
        }





    }
}
