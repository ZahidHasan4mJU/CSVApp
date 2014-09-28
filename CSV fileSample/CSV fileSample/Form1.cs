using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSVLib;

namespace CSV_fileSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string fileLocation = @"D:\zahid\person.csv";

        private void showButton_Click(object sender, EventArgs e)
        {
           FileStream a = new FileStream(fileLocation, FileMode.OpenOrCreate);
           CsvFileReader read = new CsvFileReader(a);
           List<string> personRecord = new List<string>();

            listView.Items.Clear();

            while (read.ReadRow(personRecord))
            {
                ListViewItem list = new ListViewItem(new string[]
                {

                    personRecord[0],
                    personRecord[1],
                    personRecord[2],
                    personRecord[3],
                    personRecord[4]
                }
                    );
                listView.Items.Add(list);


            }
            a.Close();


        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            FileStream a = new FileStream(fileLocation, FileMode.OpenOrCreate);
            CsvFileReader read = new CsvFileReader(a);
            List<string> personRecord2 = new List<string>();

            if (new FileInfo(fileLocation).Length != 0)
                while (read.ReadRow(personRecord2))
                {
                    if (personRecord2[2] == pcTextBox.Text)
                    {
                        MessageBox.Show(@"conflict");
                        a.Close();
                        return;
                    }

                }
            a.Close();

            FileStream b = new FileStream(fileLocation, FileMode.Append);
            CsvFileWriter w = new CsvFileWriter(b);
            List<string> personRecord = new List<string>();

            personRecord.Add(nameTextBox.Text);
            personRecord.Add(emailTextBox.Text);
            personRecord.Add(pcTextBox.Text);
            personRecord.Add(hcTextBox.Text);
            personRecord.Add(homeAddTextBox.Text);

            w.WriteRow(personRecord2);
            b.Close();
        }
    }
}
