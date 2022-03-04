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

namespace notepad_2000
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.FileName = "Megnyitás";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
            {
                richTextBox1.Text = sr.ReadToEnd();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
            {
                sw.WriteLine(richTextBox1.Text);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Szeretnéd elmenteni?", "Mentés",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.ShowDialog();
                richTextBox1.Text = "";
            }
            else
            {
                richTextBox1.Text = "";
            }
            
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.BackColor = colorDialog1.Color;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            if (richTextBox1.SelectionLength == 0)
            {
                richTextBox1.ForeColor = colorDialog1.Color;
            }
            else
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
            
        }

        private void fontstyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            if (richTextBox1.SelectionLength == 0)
            {
                richTextBox1.Font = fontDialog1.Font;
            }
            richTextBox1.SelectionFont = fontDialog1.Font;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog1 = new PrintDialog();
            printDialog1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }
    }
}
