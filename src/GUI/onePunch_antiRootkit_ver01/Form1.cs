using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;  //Inserted to get OS Version.
using System.Diagnostics;   //Inserted to use Process.Start that can excute outer program.

namespace onePunch_antiRootkit_ver01
{
    //Override Form with MetroFramework
    public partial class ClientForm01 : MetroFramework.Forms.MetroForm
    {
        bool isCheckbtnClicked = false;

        public ClientForm01()
        {
            InitializeComponent();
        }

        //Load Client Program
        private void ClientForm01_Load(object sender, EventArgs e)
        {
            //windows name, version, build version ex) Windows 10 Home, 6.3, 14393
            var windowsName = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\", "ProductName", "");
            var windowsVersion = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\", "CurrentVersion", "");
            var windowsBuild = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\", "CurrentBuild", "");

            //Initialize OS information of current Client Computer.
            lblOsversion_desc.Text = windowsName.ToString();
            lblOsversion_ver.Text = windowsVersion.ToString();
            lblOsversion_build.Text = windowsBuild.ToString();

            //Initialize Current status of Rootkit.
            lblCurStatus.Text = "Bad";  //text
            lblCurStatus.ForeColor = Color.Red; //font color
        }

        //Click event - 'check shape label'
        private void lblCheck_Click(object sender, EventArgs e)
        {
            Process.Start("DKOM_REVEALER.exe");
            //Initialize Progress Spinner
            timerForProgress.Enabled = true;
            timerForProgress.Start();
            timerForProgress.Interval = 50;
            progressSpin.Maximum = 100;

            //Assign eventHandler to Progress Spinner with 'timerForProgress_Tick'
            timerForProgress.Tick += new EventHandler(timerForProgress_Tick);
        }




        //EventHandler - 'manage time of Timer named timerForProgress'
        void timerForProgress_Tick(object sender, EventArgs e)
        {
            /*
             * excute Outer program.
             * If you want to use this method, then remove the bottom comment line
             * and change the text in "" to Address of your Program.
             */

            //Process.Start("DKOM_REVEALER.exe");

            //max value of progressSpin is 100 and min is 0.
            if (progressSpin.Value != 100)
            {
                progressSpin.Value++;
            }
            else
            {
                timerForProgress.Stop();    //stop the timer
                isCheckbtnClicked = true;   //check the Button is clicked.

                //After timer is over, update Current status of Rootkit (Label text & Font color)
                lblCurStatus.Text = "Safe";
                lblCurStatus.ForeColor = Color.Lime;
            }
        }

        //Click event - 'Show Logs Tile'
        private void btn_showLogFile_Click(object sender, EventArgs e)
        {
            if (isCheckbtnClicked == true)
            {
                //Make new Form & show it.
                LogForm logTextBox = new LogForm();
                logTextBox.Show();
            }
            else
            {
                MessageBox.Show("Please click the button('✔')...");
            }
        }

        //Click event - 'Show Detected Result Tile'
        private void btn_showDetected_Click(object sender, EventArgs e)
        {
            if (isCheckbtnClicked == true)
            {
                //Make new Form & show it.
                DetectedForm detectedResult = new DetectedForm();
                detectedResult.Show();
            }
            else
            {
                MessageBox.Show("Please click the button('✔')...");
            }
        }

        public MetroFramework.MetroColorStyle Green { get; set; }
        public MetroFramework.MetroColorStyle Lime { get; set; }
    }
}
