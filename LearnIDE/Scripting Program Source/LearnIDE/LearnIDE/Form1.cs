using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnIDE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //RUN
        private void button1_Click(object sender, EventArgs e)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filename = textBox2.Text + ".txt";
            string line = textBox1.Text;
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            path = path + "\\MainScript.exe";
            filename = docPath + "\\LearnIDE\\" + filename;

            System.IO.File.WriteAllText(filename, line);
            System.IO.File.WriteAllText(docPath + "\\LearnIDE\\" + "ToOpen.txt", textBox2.Text);

            Process.Start(path);
        }

        //SAVE
        private void button3_Click(object sender, EventArgs e)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filename = textBox2.Text + ".txt";
            string line = textBox1.Text;

            filename = docPath + "\\LearnIDE\\" + filename;

            System.IO.File.WriteAllText(filename, line);
            System.IO.File.WriteAllText(docPath + "\\LearnIDE\\" + "ToOpen.txt", textBox2.Text);
        }

        //LOAD
        private void button2_Click(object sender, EventArgs e)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filename = textBox2.Text + ".txt";
            string line = null;

            filename = docPath + "\\LearnIDE\\" + filename;

            try
            {   // Open the text file using a stream reader
                using (StreamReader sr = new StreamReader(filename))
                {
                    // Read the stream to a string, and write the string to text box 1
                    line = sr.ReadToEnd();
                    textBox1.Text = line;
                }
            }
            catch (IOException)
            {
                textBox1.Text = "COULD NOT LOAD.  CHECK FILENAME AND TRY AGAIN.";
            }
        }
    }
}
