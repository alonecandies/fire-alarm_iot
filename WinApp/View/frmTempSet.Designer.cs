
namespace WinApp.View
{
    partial class frmTempSet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnOffWater = new System.Windows.Forms.Button();
            this.btnOffAlarm = new System.Windows.Forms.Button();
            this.btnOnWater = new System.Windows.Forms.Button();
            this.btnOnAlarm = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaxTemp = new System.Windows.Forms.TextBox();
            this.lbWater = new System.Windows.Forms.Label();
            this.lbAlarm = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.item1 = new WinApp.View.Item();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDeviceName = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.recordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recordBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(389, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "SETTING";
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.LightGray;
            this.button5.Location = new System.Drawing.Point(4, 4);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(33, 31);
            this.button5.TabIndex = 14;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(912, 47);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(912, 480);
            this.panel2.TabIndex = 17;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnOffWater);
            this.panel5.Controls.Add(this.btnOffAlarm);
            this.panel5.Controls.Add(this.btnOnWater);
            this.panel5.Controls.Add(this.btnOnAlarm);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.txtMaxTemp);
            this.panel5.Controls.Add(this.lbWater);
            this.panel5.Controls.Add(this.lbAlarm);
            this.panel5.Controls.Add(this.btnSubmit);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(381, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(531, 480);
            this.panel5.TabIndex = 18;
            // 
            // btnOffWater
            // 
            this.btnOffWater.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnOffWater.FlatAppearance.BorderSize = 0;
            this.btnOffWater.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOffWater.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOffWater.ForeColor = System.Drawing.Color.LightGray;
            this.btnOffWater.Location = new System.Drawing.Point(177, 256);
            this.btnOffWater.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOffWater.Name = "btnOffWater";
            this.btnOffWater.Size = new System.Drawing.Size(149, 49);
            this.btnOffWater.TabIndex = 18;
            this.btnOffWater.Text = "Off";
            this.btnOffWater.UseVisualStyleBackColor = false;
            this.btnOffWater.Click += new System.EventHandler(this.btnOffWater_Click);
            // 
            // btnOffAlarm
            // 
            this.btnOffAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnOffAlarm.FlatAppearance.BorderSize = 0;
            this.btnOffAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOffAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOffAlarm.ForeColor = System.Drawing.Color.LightGray;
            this.btnOffAlarm.Location = new System.Drawing.Point(181, 160);
            this.btnOffAlarm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOffAlarm.Name = "btnOffAlarm";
            this.btnOffAlarm.Size = new System.Drawing.Size(149, 49);
            this.btnOffAlarm.TabIndex = 18;
            this.btnOffAlarm.Text = "Off";
            this.btnOffAlarm.UseVisualStyleBackColor = false;
            this.btnOffAlarm.Click += new System.EventHandler(this.btnOffAlarm_Click);
            // 
            // btnOnWater
            // 
            this.btnOnWater.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnOnWater.FlatAppearance.BorderSize = 0;
            this.btnOnWater.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnWater.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOnWater.ForeColor = System.Drawing.Color.LightGray;
            this.btnOnWater.Location = new System.Drawing.Point(7, 256);
            this.btnOnWater.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOnWater.Name = "btnOnWater";
            this.btnOnWater.Size = new System.Drawing.Size(149, 49);
            this.btnOnWater.TabIndex = 18;
            this.btnOnWater.Text = "On";
            this.btnOnWater.UseVisualStyleBackColor = false;
            this.btnOnWater.Click += new System.EventHandler(this.btnOnWater_Click);
            // 
            // btnOnAlarm
            // 
            this.btnOnAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnOnAlarm.FlatAppearance.BorderSize = 0;
            this.btnOnAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOnAlarm.ForeColor = System.Drawing.Color.LightGray;
            this.btnOnAlarm.Location = new System.Drawing.Point(11, 160);
            this.btnOnAlarm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOnAlarm.Name = "btnOnAlarm";
            this.btnOnAlarm.Size = new System.Drawing.Size(149, 49);
            this.btnOnAlarm.TabIndex = 18;
            this.btnOnAlarm.Text = "On";
            this.btnOnAlarm.UseVisualStyleBackColor = false;
            this.btnOnAlarm.Click += new System.EventHandler(this.btnOnAlarm_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(11, 52);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Max Temperature";
            // 
            // txtMaxTemp
            // 
            this.txtMaxTemp.Location = new System.Drawing.Point(11, 86);
            this.txtMaxTemp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaxTemp.Name = "txtMaxTemp";
            this.txtMaxTemp.Size = new System.Drawing.Size(319, 22);
            this.txtMaxTemp.TabIndex = 9;
            this.txtMaxTemp.Text = "100";
            // 
            // lbWater
            // 
            this.lbWater.AutoSize = true;
            this.lbWater.ForeColor = System.Drawing.Color.Black;
            this.lbWater.Location = new System.Drawing.Point(7, 223);
            this.lbWater.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbWater.Name = "lbWater";
            this.lbWater.Size = new System.Drawing.Size(81, 16);
            this.lbWater.TabIndex = 10;
            this.lbWater.Text = "On Watering";
            // 
            // lbAlarm
            // 
            this.lbAlarm.AutoSize = true;
            this.lbAlarm.ForeColor = System.Drawing.Color.Black;
            this.lbAlarm.Location = new System.Drawing.Point(11, 127);
            this.lbAlarm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAlarm.Name = "lbAlarm";
            this.lbAlarm.Size = new System.Drawing.Size(62, 16);
            this.lbAlarm.TabIndex = 10;
            this.lbAlarm.Text = "On Alarm";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.btnSubmit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.LightGray;
            this.btnSubmit.Location = new System.Drawing.Point(0, 431);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(531, 49);
            this.btnSubmit.TabIndex = 16;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.item1);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.cbDeviceName);
            this.panel4.Controls.Add(this.btnLoad);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(381, 480);
            this.panel4.TabIndex = 0;
            // 
            // item1
            // 
            this.item1.BackColor = System.Drawing.Color.White;
            this.item1.Location = new System.Drawing.Point(4, 7);
            this.item1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.item1.Name = "item1";
            this.item1.Size = new System.Drawing.Size(363, 231);
            this.item1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(29, 245);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 29);
            this.label2.TabIndex = 18;
            this.label2.Text = "Device Name";
            // 
            // cbDeviceName
            // 
            this.cbDeviceName.BackColor = System.Drawing.Color.White;
            this.cbDeviceName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.cbDeviceName.FormattingEnabled = true;
            this.cbDeviceName.Location = new System.Drawing.Point(29, 294);
            this.cbDeviceName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbDeviceName.Name = "cbDeviceName";
            this.cbDeviceName.Size = new System.Drawing.Size(171, 24);
            this.cbDeviceName.TabIndex = 17;
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.Color.LightGray;
            this.btnLoad.Location = new System.Drawing.Point(29, 345);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(172, 49);
            this.btnLoad.TabIndex = 16;
            this.btnLoad.Text = "Select Device";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 47);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(912, 3);
            this.panel3.TabIndex = 17;
            // 
            // recordBindingSource
            // 
            this.recordBindingSource.DataSource = typeof(WinApp.Model.Record);
            // 
            // frmTempSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(912, 530);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmTempSet";
            this.Text = "frmStatic";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recordBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.BindingSource recordBindingSource;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbDeviceName;
        private Item item1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaxTemp;
        private System.Windows.Forms.Label lbAlarm;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnOffAlarm;
        private System.Windows.Forms.Button btnOnAlarm;
        private System.Windows.Forms.Button btnOffWater;
        private System.Windows.Forms.Button btnOnWater;
        private System.Windows.Forms.Label lbWater;
    }
}