namespace onePunch_antiRootkit_ver01
{
    partial class ClientForm01
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
            this.btn_showLogFile = new MetroFramework.Controls.MetroTile();
            this.progressSpin = new MetroFramework.Controls.MetroProgressSpinner();
            this.lblCheck = new MetroFramework.Controls.MetroLabel();
            this.lblOsversion_title = new MetroFramework.Controls.MetroLabel();
            this.lblOsversion_desc = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.lblOsversion_ver = new MetroFramework.Controls.MetroLabel();
            this.lblOsversion_build = new MetroFramework.Controls.MetroLabel();
            this.timerForProgress = new System.Windows.Forms.Timer(this.components);
            this.lblRootkitStatus = new MetroFramework.Controls.MetroLabel();
            this.lblCurStatus = new MetroFramework.Controls.MetroLabel();
            this.btn_showDetected = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // btn_showLogFile
            // 
            this.btn_showLogFile.ActiveControl = null;
            this.btn_showLogFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_showLogFile.Location = new System.Drawing.Point(494, 417);
            this.btn_showLogFile.Name = "btn_showLogFile";
            this.btn_showLogFile.Size = new System.Drawing.Size(147, 89);
            this.btn_showLogFile.TabIndex = 0;
            this.btn_showLogFile.Text = "Show Logs";
            this.btn_showLogFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_showLogFile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_showLogFile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btn_showLogFile.UseSelectable = true;
            this.btn_showLogFile.Click += new System.EventHandler(this.btn_showLogFile_Click);
            // 
            // progressSpin
            // 
            this.progressSpin.Location = new System.Drawing.Point(222, 161);
            this.progressSpin.Maximum = 100;
            this.progressSpin.Name = "progressSpin";
            this.progressSpin.Size = new System.Drawing.Size(239, 245);
            this.progressSpin.Spinning = false;
            this.progressSpin.Style = MetroFramework.MetroColorStyle.Blue;
            this.progressSpin.TabIndex = 1;
            this.progressSpin.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.progressSpin.UseSelectable = true;
            // 
            // lblCheck
            // 
            this.lblCheck.AutoSize = true;
            this.lblCheck.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblCheck.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblCheck.Location = new System.Drawing.Point(323, 264);
            this.lblCheck.MinimumSize = new System.Drawing.Size(35, 35);
            this.lblCheck.Name = "lblCheck";
            this.lblCheck.Size = new System.Drawing.Size(27, 25);
            this.lblCheck.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblCheck.TabIndex = 2;
            this.lblCheck.Text = "✔";
            this.lblCheck.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lblCheck.UseStyleColors = true;
            this.lblCheck.Click += new System.EventHandler(this.lblCheck_Click);
            // 
            // lblOsversion_title
            // 
            this.lblOsversion_title.AutoSize = true;
            this.lblOsversion_title.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblOsversion_title.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblOsversion_title.Location = new System.Drawing.Point(23, 108);
            this.lblOsversion_title.Name = "lblOsversion_title";
            this.lblOsversion_title.Size = new System.Drawing.Size(51, 25);
            this.lblOsversion_title.Style = MetroFramework.MetroColorStyle.White;
            this.lblOsversion_title.TabIndex = 3;
            this.lblOsversion_title.Text = "OS : ";
            this.lblOsversion_title.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblOsversion_desc
            // 
            this.lblOsversion_desc.AutoSize = true;
            this.lblOsversion_desc.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblOsversion_desc.Location = new System.Drawing.Point(86, 114);
            this.lblOsversion_desc.Name = "lblOsversion_desc";
            this.lblOsversion_desc.Size = new System.Drawing.Size(15, 19);
            this.lblOsversion_desc.Style = MetroFramework.MetroColorStyle.White;
            this.lblOsversion_desc.TabIndex = 4;
            this.lblOsversion_desc.Text = "-";
            this.lblOsversion_desc.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(23, 161);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(90, 25);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Version : ";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(21, 211);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(71, 25);
            this.metroLabel2.TabIndex = 6;
            this.metroLabel2.Text = "Build : ";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblOsversion_ver
            // 
            this.lblOsversion_ver.AutoSize = true;
            this.lblOsversion_ver.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblOsversion_ver.Location = new System.Drawing.Point(139, 170);
            this.lblOsversion_ver.Name = "lblOsversion_ver";
            this.lblOsversion_ver.Size = new System.Drawing.Size(15, 19);
            this.lblOsversion_ver.TabIndex = 7;
            this.lblOsversion_ver.Text = "-";
            this.lblOsversion_ver.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblOsversion_build
            // 
            this.lblOsversion_build.AutoSize = true;
            this.lblOsversion_build.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblOsversion_build.Location = new System.Drawing.Point(112, 219);
            this.lblOsversion_build.Name = "lblOsversion_build";
            this.lblOsversion_build.Size = new System.Drawing.Size(15, 19);
            this.lblOsversion_build.TabIndex = 8;
            this.lblOsversion_build.Text = "-";
            this.lblOsversion_build.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblRootkitStatus
            // 
            this.lblRootkitStatus.AutoSize = true;
            this.lblRootkitStatus.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblRootkitStatus.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblRootkitStatus.Location = new System.Drawing.Point(23, 460);
            this.lblRootkitStatus.Name = "lblRootkitStatus";
            this.lblRootkitStatus.Size = new System.Drawing.Size(80, 25);
            this.lblRootkitStatus.TabIndex = 9;
            this.lblRootkitStatus.Text = "Status : ";
            this.lblRootkitStatus.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblCurStatus
            // 
            this.lblCurStatus.AutoSize = true;
            this.lblCurStatus.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblCurStatus.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblCurStatus.Location = new System.Drawing.Point(125, 462);
            this.lblCurStatus.Name = "lblCurStatus";
            this.lblCurStatus.Size = new System.Drawing.Size(19, 25);
            this.lblCurStatus.Style = MetroFramework.MetroColorStyle.Red;
            this.lblCurStatus.TabIndex = 10;
            this.lblCurStatus.Text = "-";
            this.lblCurStatus.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lblCurStatus.UseCustomForeColor = true;
            this.lblCurStatus.UseStyleColors = true;
            // 
            // btn_showDetected
            // 
            this.btn_showDetected.ActiveControl = null;
            this.btn_showDetected.Location = new System.Drawing.Point(494, 318);
            this.btn_showDetected.Name = "btn_showDetected";
            this.btn_showDetected.Size = new System.Drawing.Size(147, 89);
            this.btn_showDetected.Style = MetroFramework.MetroColorStyle.Teal;
            this.btn_showDetected.TabIndex = 11;
            this.btn_showDetected.Text = "Result";
            this.btn_showDetected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_showDetected.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_showDetected.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_showDetected.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.btn_showDetected.UseSelectable = true;
            this.btn_showDetected.Click += new System.EventHandler(this.btn_showDetected_Click);
            // 
            // ClientForm01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 529);
            this.Controls.Add(this.btn_showDetected);
            this.Controls.Add(this.lblCurStatus);
            this.Controls.Add(this.lblRootkitStatus);
            this.Controls.Add(this.lblOsversion_build);
            this.Controls.Add(this.lblOsversion_ver);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.lblOsversion_desc);
            this.Controls.Add(this.lblOsversion_title);
            this.Controls.Add(this.lblCheck);
            this.Controls.Add(this.progressSpin);
            this.Controls.Add(this.btn_showLogFile);
            this.Name = "ClientForm01";
            this.Text = "Onepunch Man AntiRootkit";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.ClientForm01_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile btn_showLogFile;
        private MetroFramework.Controls.MetroProgressSpinner progressSpin;
        private MetroFramework.Controls.MetroLabel lblCheck;
        private MetroFramework.Controls.MetroLabel lblOsversion_title;
        private MetroFramework.Controls.MetroLabel lblOsversion_desc;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel lblOsversion_ver;
        private MetroFramework.Controls.MetroLabel lblOsversion_build;
        private System.Windows.Forms.Timer timerForProgress;
        private MetroFramework.Controls.MetroLabel lblRootkitStatus;
        private MetroFramework.Controls.MetroLabel lblCurStatus;
        private MetroFramework.Controls.MetroTile btn_showDetected;
    }
}

