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


        class AlphabetNumber
        {
            const string cs = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const int hs = 26;

            public static string GetExcelColumnName(int columnNumber)
            {
                int sochia = columnNumber;
                string columnName = String.Empty;
                int sodu;

                while (sochia > 0)
                {
                    sodu = (sochia - 1) % hs;
                    columnName = Convert.ToChar(65 + sodu).ToString() + columnName;
                    sochia = (int)((sochia - sodu) / hs);
                }

                return columnName;
            }

            public static Int64 toInt(string AlphabetNumberStr)
            {
                if (string.IsNullOrEmpty(AlphabetNumberStr))
                {
                    throw new System.ArgumentNullException("Is null or empty", new Exception("string is null or empty"));
                }
                else if (System.Text.RegularExpressions.Regex.IsMatch(AlphabetNumberStr, "[^A-Z]+"))
                {
                    //kiểm tra chuỗi nhập vào có đúng định dạng ko?
                    throw new System.ArgumentException("Invalid alphabet!");
                }
                else
                {
                    int s = 0;
                    Int64 kq = 0;
                    string revereverseStr = Reverse(AlphabetNumberStr);
                    for (int i = 0; i < revereverseStr.Length; i++)
                    {
                        s = Array.IndexOf(cs.ToArray(), revereverseStr[i]) + 1;
                        //if (i == revereverseStr.Length - 1 && revereverseStr.Length > 1)
                        //{
                        //    //trường hợp A đứng đầu thì A = 1;
                        //    // bình thường A = 0;
                        //    s = s == 0 ? 1 : s;
                        //}
                        kq += s * (Int64)Math.Pow(hs, i);
                    }
                    return kq - 1;
                }
            }

            public static string toAlphabetNumber(Int64 ndec)
            {
                if (ndec < 0)
                {
                    throw new System.ArgumentException("to small");
                }

                if (ndec <= 25)
                {
                    return cs[(int)ndec].ToString();
                }

                int soDu = 0;
                Int64 sochia = ndec + 1;
                List<int> kq = new List<int>();
                while (sochia != 0)
                {
                    soDu = (int)(sochia % hs);
                    sochia = sochia / hs;
                    kq.Add(soDu);
                }

                string strAlpN = "";

                kq = standard(kq);
                for (int i = kq.Count - 1; i >= 0; i--)
                {
                    strAlpN += cs[kq[i] - 1].ToString();
                }
                return strAlpN;
            }

            static List<int> standard(List<int> arr)
            {
                List<int> outarr = new List<int>();
                for (int i = 0; i < arr.Count; i++)
                {
                    if (i == arr.Count - 1 && arr[i] <= 0)
                    {
                        break;
                    }
                    if (arr[i] <= 0)
                    {
                        arr[i] = 26;
                        arr[i + 1] = arr[i + 1] - 1;
                    }
                    outarr.Add(arr[i]);
                }
                return outarr;
            }

            static string Reverse(string s)
            {
                char[] charArray = s.ToCharArray();
                Array.Reverse(charArray);
                return new string(charArray);
            }
        }

        private void btnStI_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.ToUpper();
            numericUpDown1.Value = AlphabetNumber.toInt(textBox1.Text);
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
