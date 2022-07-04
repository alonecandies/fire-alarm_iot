namespace WinApp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnInfor = new System.Windows.Forms.Button();
            this.btnEqualizer = new System.Windows.Forms.Button();
            this.panelSettingSubMenu = new System.Windows.Forms.Panel();
            this.btnWarterSet = new System.Windows.Forms.Button();
            this.btnAlarmStatusSet = new System.Windows.Forms.Button();
            this.btnPhoneNumSet = new System.Windows.Forms.Button();
            this.btnTemAlarmSet = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.panelDashBoard = new System.Windows.Forms.Panel();
            this.btnProperties = new System.Windows.Forms.Button();
            this.btnStatic = new System.Windows.Forms.Button();
            this.btnStaLst = new System.Windows.Forms.Button();
            this.btnDashboardSub = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelPlayer = new System.Windows.Forms.Panel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.panelSideMenu.SuspendLayout();
            this.panelSettingSubMenu.SuspendLayout();
            this.panelDashBoard.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelPlayer.SuspendLayout();
            this.panelChildForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelSideMenu.Controls.Add(this.btnExit);
            this.panelSideMenu.Controls.Add(this.btnInfor);
            this.panelSideMenu.Controls.Add(this.btnEqualizer);
            this.panelSideMenu.Controls.Add(this.panelSettingSubMenu);
            this.panelSideMenu.Controls.Add(this.btnSetting);
            this.panelSideMenu.Controls.Add(this.panelDashBoard);
            this.panelSideMenu.Controls.Add(this.btnDashboard);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(250, 600);
            this.panelSideMenu.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.Silver;
            this.btnExit.Image = global::WinApp.Properties.Resources.btnExit_Image;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(0, 602);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnExit.Size = new System.Drawing.Size(233, 45);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "  Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnInfor
            // 
            this.btnInfor.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInfor.FlatAppearance.BorderSize = 0;
            this.btnInfor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.btnInfor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnInfor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfor.ForeColor = System.Drawing.Color.Silver;
            this.btnInfor.Image = global::WinApp.Properties.Resources.btnHelp_Image;
            this.btnInfor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInfor.Location = new System.Drawing.Point(0, 557);
            this.btnInfor.Name = "btnInfor";
            this.btnInfor.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnInfor.Size = new System.Drawing.Size(233, 45);
            this.btnInfor.TabIndex = 8;
            this.btnInfor.Text = "  Information";
            this.btnInfor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInfor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInfor.UseVisualStyleBackColor = true;
            this.btnInfor.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnEqualizer
            // 
            this.btnEqualizer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEqualizer.FlatAppearance.BorderSize = 0;
            this.btnEqualizer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.btnEqualizer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnEqualizer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEqualizer.ForeColor = System.Drawing.Color.Silver;
            this.btnEqualizer.Image = global::WinApp.Properties.Resources.btnEqualizer_Image;
            this.btnEqualizer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEqualizer.Location = new System.Drawing.Point(0, 512);
            this.btnEqualizer.Name = "btnEqualizer";
            this.btnEqualizer.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnEqualizer.Size = new System.Drawing.Size(233, 45);
            this.btnEqualizer.TabIndex = 5;
            this.btnEqualizer.Text = "  Developing";
            this.btnEqualizer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEqualizer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEqualizer.UseVisualStyleBackColor = true;
            this.btnEqualizer.Click += new System.EventHandler(this.btnEqualizer_Click);
            // 
            // panelSettingSubMenu
            // 
            this.panelSettingSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelSettingSubMenu.Controls.Add(this.btnWarterSet);
            this.panelSettingSubMenu.Controls.Add(this.btnAlarmStatusSet);
            this.panelSettingSubMenu.Controls.Add(this.btnPhoneNumSet);
            this.panelSettingSubMenu.Controls.Add(this.btnTemAlarmSet);
            this.panelSettingSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSettingSubMenu.Location = new System.Drawing.Point(0, 347);
            this.panelSettingSubMenu.Name = "panelSettingSubMenu";
            this.panelSettingSubMenu.Size = new System.Drawing.Size(233, 165);
            this.panelSettingSubMenu.TabIndex = 4;
            // 
            // btnWarterSet
            // 
            this.btnWarterSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnWarterSet.FlatAppearance.BorderSize = 0;
            this.btnWarterSet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnWarterSet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnWarterSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWarterSet.ForeColor = System.Drawing.Color.Silver;
            this.btnWarterSet.Location = new System.Drawing.Point(0, 120);
            this.btnWarterSet.Name = "btnWarterSet";
            this.btnWarterSet.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnWarterSet.Size = new System.Drawing.Size(233, 40);
            this.btnWarterSet.TabIndex = 3;
            this.btnWarterSet.Text = "None";
            this.btnWarterSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWarterSet.UseVisualStyleBackColor = true;
            this.btnWarterSet.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAlarmStatusSet
            // 
            this.btnAlarmStatusSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAlarmStatusSet.FlatAppearance.BorderSize = 0;
            this.btnAlarmStatusSet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnAlarmStatusSet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnAlarmStatusSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlarmStatusSet.ForeColor = System.Drawing.Color.Silver;
            this.btnAlarmStatusSet.Location = new System.Drawing.Point(0, 80);
            this.btnAlarmStatusSet.Name = "btnAlarmStatusSet";
            this.btnAlarmStatusSet.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnAlarmStatusSet.Size = new System.Drawing.Size(233, 40);
            this.btnAlarmStatusSet.TabIndex = 2;
            this.btnAlarmStatusSet.Text = "None";
            this.btnAlarmStatusSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlarmStatusSet.UseVisualStyleBackColor = true;
            this.btnAlarmStatusSet.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnPhoneNumSet
            // 
            this.btnPhoneNumSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPhoneNumSet.FlatAppearance.BorderSize = 0;
            this.btnPhoneNumSet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnPhoneNumSet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnPhoneNumSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhoneNumSet.ForeColor = System.Drawing.Color.Silver;
            this.btnPhoneNumSet.Location = new System.Drawing.Point(0, 40);
            this.btnPhoneNumSet.Name = "btnPhoneNumSet";
            this.btnPhoneNumSet.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnPhoneNumSet.Size = new System.Drawing.Size(233, 40);
            this.btnPhoneNumSet.TabIndex = 1;
            this.btnPhoneNumSet.Text = "Phone Number";
            this.btnPhoneNumSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPhoneNumSet.UseVisualStyleBackColor = true;
            this.btnPhoneNumSet.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnTemAlarmSet
            // 
            this.btnTemAlarmSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTemAlarmSet.FlatAppearance.BorderSize = 0;
            this.btnTemAlarmSet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnTemAlarmSet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnTemAlarmSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemAlarmSet.ForeColor = System.Drawing.Color.Silver;
            this.btnTemAlarmSet.Location = new System.Drawing.Point(0, 0);
            this.btnTemAlarmSet.Name = "btnTemAlarmSet";
            this.btnTemAlarmSet.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnTemAlarmSet.Size = new System.Drawing.Size(233, 40);
            this.btnTemAlarmSet.TabIndex = 0;
            this.btnTemAlarmSet.Text = "Device";
            this.btnTemAlarmSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTemAlarmSet.UseVisualStyleBackColor = true;
            this.btnTemAlarmSet.Click += new System.EventHandler(this.button8_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSetting.FlatAppearance.BorderSize = 0;
            this.btnSetting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.btnSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.ForeColor = System.Drawing.Color.Silver;
            this.btnSetting.Image = global::WinApp.Properties.Resources.btnTools_Image;
            this.btnSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetting.Location = new System.Drawing.Point(0, 302);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSetting.Size = new System.Drawing.Size(233, 45);
            this.btnSetting.TabIndex = 3;
            this.btnSetting.Text = "  Setting";
            this.btnSetting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // panelDashBoard
            // 
            this.panelDashBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelDashBoard.Controls.Add(this.btnProperties);
            this.panelDashBoard.Controls.Add(this.btnStatic);
            this.panelDashBoard.Controls.Add(this.btnStaLst);
            this.panelDashBoard.Controls.Add(this.btnDashboardSub);
            this.panelDashBoard.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDashBoard.Location = new System.Drawing.Point(0, 137);
            this.panelDashBoard.Name = "panelDashBoard";
            this.panelDashBoard.Size = new System.Drawing.Size(233, 165);
            this.panelDashBoard.TabIndex = 2;
            // 
            // btnProperties
            // 
            this.btnProperties.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProperties.FlatAppearance.BorderSize = 0;
            this.btnProperties.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnProperties.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnProperties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProperties.ForeColor = System.Drawing.Color.Silver;
            this.btnProperties.Location = new System.Drawing.Point(0, 120);
            this.btnProperties.Name = "btnProperties";
            this.btnProperties.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnProperties.Size = new System.Drawing.Size(233, 40);
            this.btnProperties.TabIndex = 3;
            this.btnProperties.Text = "Properties";
            this.btnProperties.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProperties.UseVisualStyleBackColor = true;
            this.btnProperties.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnStatic
            // 
            this.btnStatic.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStatic.FlatAppearance.BorderSize = 0;
            this.btnStatic.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnStatic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnStatic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatic.ForeColor = System.Drawing.Color.Silver;
            this.btnStatic.Location = new System.Drawing.Point(0, 80);
            this.btnStatic.Name = "btnStatic";
            this.btnStatic.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnStatic.Size = new System.Drawing.Size(233, 40);
            this.btnStatic.TabIndex = 2;
            this.btnStatic.Text = "Static";
            this.btnStatic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatic.UseVisualStyleBackColor = true;
            this.btnStatic.Click += new System.EventHandler(this.btnStatic_Click);
            // 
            // btnStaLst
            // 
            this.btnStaLst.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStaLst.FlatAppearance.BorderSize = 0;
            this.btnStaLst.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnStaLst.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnStaLst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaLst.ForeColor = System.Drawing.Color.Silver;
            this.btnStaLst.Location = new System.Drawing.Point(0, 40);
            this.btnStaLst.Name = "btnStaLst";
            this.btnStaLst.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnStaLst.Size = new System.Drawing.Size(233, 40);
            this.btnStaLst.TabIndex = 1;
            this.btnStaLst.Text = "Station List";
            this.btnStaLst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStaLst.UseVisualStyleBackColor = true;
            this.btnStaLst.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnDashboardSub
            // 
            this.btnDashboardSub.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboardSub.FlatAppearance.BorderSize = 0;
            this.btnDashboardSub.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnDashboardSub.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(38)))), ((int)(((byte)(46)))));
            this.btnDashboardSub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboardSub.ForeColor = System.Drawing.Color.Silver;
            this.btnDashboardSub.Location = new System.Drawing.Point(0, 0);
            this.btnDashboardSub.Name = "btnDashboardSub";
            this.btnDashboardSub.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnDashboardSub.Size = new System.Drawing.Size(233, 40);
            this.btnDashboardSub.TabIndex = 0;
            this.btnDashboardSub.Text = "Dashboard";
            this.btnDashboardSub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboardSub.UseVisualStyleBackColor = true;
            this.btnDashboardSub.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.ForeColor = System.Drawing.Color.Silver;
            this.btnDashboard.Image = global::WinApp.Properties.Resources.icons8_home_64;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(0, 92);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(233, 45);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "  Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(233, 92);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WinApp.Properties.Resources.logo_bottom;
            this.pictureBox1.Location = new System.Drawing.Point(42, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(159, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelPlayer
            // 
            this.panelPlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.panelPlayer.Controls.Add(this.btnConnect);
            this.panelPlayer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPlayer.Location = new System.Drawing.Point(250, 555);
            this.panelPlayer.Name = "panelPlayer";
            this.panelPlayer.Size = new System.Drawing.Size(857, 45);
            this.panelPlayer.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.Firebrick;
            this.btnConnect.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnConnect.FlatAppearance.BorderSize = 0;
            this.btnConnect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.btnConnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.ForeColor = System.Drawing.Color.Silver;
            this.btnConnect.Image = global::WinApp.Properties.Resources.pictureBox5_Image;
            this.btnConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnect.Location = new System.Drawing.Point(0, 0);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnConnect.Size = new System.Drawing.Size(152, 45);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "  Disconnected";
            this.btnConnect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.Color.Snow;
            this.panelChildForm.Controls.Add(this.pictureBox9);
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(250, 0);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(857, 555);
            this.panelChildForm.TabIndex = 2;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(249, 90);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(416, 76);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox9.TabIndex = 2;
            this.pictureBox9.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1107, 600);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelPlayer);
            this.Controls.Add(this.panelSideMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelSideMenu.ResumeLayout(false);
            this.panelSettingSubMenu.ResumeLayout(false);
            this.panelDashBoard.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelPlayer.ResumeLayout(false);
            this.panelChildForm.ResumeLayout(false);
            this.panelChildForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelDashBoard;
        private System.Windows.Forms.Button btnProperties;
        private System.Windows.Forms.Button btnStatic;
        private System.Windows.Forms.Button btnStaLst;
        private System.Windows.Forms.Button btnDashboardSub;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnInfor;
        private System.Windows.Forms.Button btnEqualizer;
        private System.Windows.Forms.Panel panelSettingSubMenu;
        private System.Windows.Forms.Button btnWarterSet;
        private System.Windows.Forms.Button btnAlarmStatusSet;
        private System.Windows.Forms.Button btnPhoneNumSet;
        private System.Windows.Forms.Button btnTemAlarmSet;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panelPlayer;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Button btnConnect;
    }
}

