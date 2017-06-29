using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hesodem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(int.MaxValue.ToString("0,0"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //for (int i = 65; i < 65+26; i++)
            //{
            //    textBox1.Text += Convert.ToChar(i).ToString();
            //}
            //MessageBox.Show(AlphabetNumber.toAlphabetNumber(26));

            //int a = AlphabetNumber.toInt("AA");
            //MessageBox.Show(a.ToString());
        }

        private void btnStI_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.ToUpper();
            try
            {
                numericUpDown1.Value = AlphabetNumber.toInt(textBox1.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnItS_Click(object sender, EventArgs e)
        {
            textBox1.Text = AlphabetNumber.toAlphabetNumber((int)numericUpDown1.Value);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = AlphabetNumber.toAlphabetNumber((Int64)numericUpDown1.Value);
        }

        private void btnget_Click(object sender, EventArgs e)
        {
            string tempurl = "http://img.10fastfingers.com/badge/typing-test_1_{0}.png";
            if (textBox1.Text.Length <= 2)
            {
                string url = string.Format(tempurl, textBox1.Text);
                pictureBox1.ImageLocation = url;
            }
        }
    }
}
