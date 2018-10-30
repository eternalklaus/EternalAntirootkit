using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace onePunch_antiRootkit_ver01
{
    public partial class LogForm : MetroFramework.Forms.MetroForm
    {
        //LogData Class
        class LogData
        {
            public string ProcessId { get; set; }       //ProcessId Column
            public string ProcessName { get; set; }     //ProcessName Column
            public string Result { get; set; }          //Result Column
        }

        public LogForm()
        {
            InitializeComponent();
        }

        /*
         * Load the LogForm, When you load the LogForm then, Read the text and parse them.
         * After parsing Bind those data and assign to GridView Like Database. This is fake. HaHaHa!!!
         * Don't try this.
         */
        private void LogForm_Load(object sender, EventArgs e)
        {
            /*Read String data from text file. and parse with ('|')*/
            string line;

            StreamReader file = new StreamReader("log.txt");
            List<LogData> antiRootkitResult = new List<LogData>();

            while((line = file.ReadLine()) != null)
            {
                //Add Data to String List<>
                antiRootkitResult.Add(new LogData() { ProcessId = line.Split('|')[0], ProcessName = line.Split('|')[1], Result = line.Split('|')[2] });
            }

            //Bind with one List of StringData.
            var list = new BindingList<LogData>(antiRootkitResult);

            //Assign to MetroGridView
            dataGridView.DataSource = list;
        }
    }
}
