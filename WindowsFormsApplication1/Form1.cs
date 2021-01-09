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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void OpenButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Open Fle";
            open.Filter = "Text File (*.txt)|*.txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader read = new StreamReader(File.OpenRead(open.FileName));
                richTextBox1.Text = read.ReadToEnd();
                read.Dispose();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Save Fle";
            save.Filter = "Text File (*.txt)|*.txt";
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter write = new StreamWriter(File.Create(save.FileName));
                write.Write(richTextBox2.Text);
                write.Dispose();
            }
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            string[] tempArray = richTextBox1.Lines;

            List<string> list1 = new List<string>();

            for (int counter = 0; counter < tempArray.Length; counter++)
            {
                if((tempArray[counter]) == "")
                {
                    continue;
                }
                else
                {
                    list1.Add(string.Copy(tempArray[counter]));
                }
                
            }

            string[] arr = list1.ToArray();
            Array.Sort(arr);

            List<string> list2 = new List<string>();
            foreach (string item in arr)
            {
                list2.Add(item);
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                sb.AppendFormat(arr[i]);
                sb.AppendLine();
            }
            richTextBox2.Text = sb.ToString();



        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();

        }
    }
}
