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
    public partial class DetectedForm : MetroFramework.Forms.MetroForm
    {
        //LogData Class
        class ResultData
        {
            public string ProcessId { get; set; }       //ProcessId Column
            public string ProcessName { get; set; }     //ProcessName Column
            public string Status { get; set; }          //Status Column
        }

        public DetectedForm()
        {
            InitializeComponent();
        }

        /*
         * Load the DetectedForm, When you load the DetectedForm then, Read the text and parse them.
         * After parsing Bind those data and assign to GridView Like Database. This is fake. HaHaHa!!!
         * Don't try this.
         */
        private void DetectedForm_Load(object sender, EventArgs e)
        {
            /*Read String data from text file. and parse with ('|')*/
            string line;

            StreamReader file = new StreamReader("resultFile.txt");
            List<ResultData> detectedResult = new List<ResultData>();

            while ((line = file.ReadLine()) != null)
            {
                //Add Data to String List<>
                detectedResult.Add(new ResultData() { ProcessId = line.Split('|')[0], ProcessName = line.Split('|')[1], Status = line.Split('|')[2] });
            }

            //Bind with one List of StringData.
            var list = new BindingList<ResultData>(detectedResult);

            //Assign to MetroGridView
            resultDataGridView.DataSource = list;
        }

        //Skip
        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Nothing
        }
    }
}
