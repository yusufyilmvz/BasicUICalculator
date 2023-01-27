using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string operation;

        private void button14_Click(object sender, EventArgs e)
        {
            operation = "";
            Regex regex = new Regex(@"(\d+)");
            double result = 0;

            if (tbxInput.Text == "")
            {
                MessageBox.Show("Herhangi bir işlem girilmemiştir", "Uyarı", MessageBoxButtons.OK);
            }
            else
            {
                if (regex.Match(tbxInput.Text.ToString()).Index != 0)
                {
                    MessageBox.Show("Sayı girerek başlayınız!", "Uyarı", MessageBoxButtons.OK);
                }

                else
                {
                    Regex regex1 = new Regex(@"(\d+)[\+\-\*/](\d+)");
                    if (!regex1.Match(tbxInput.Text).Success)
                    {
                        MessageBox.Show("Yanlış formatta giriş!!", "Uyarı", MessageBoxButtons.OK);
                    }
                    else
                    {
                        Regex regex2 = new Regex(@"[\+\-\*/]{2,}");
                        if (regex2.Match(tbxInput.Text).Success)
                        {
                            MessageBox.Show("Yanlış formatta giriş!!", "Uyarı", MessageBoxButtons.OK);
                        }
                        else
                        {
                            Regex regex3 = new Regex(@"[\+\-\*/]$");

                            if (regex3.Match(tbxInput.Text).Success)
                            {
                                MessageBox.Show("Yanlış formatta giriş!!", "Uyarı", MessageBoxButtons.OK);
                            }
                            else
                            {
                                string text = tbxInput.Text;
                                Regex regex4 = new Regex(@"[\+\-\*/]");
                                MatchCollection matches = regex4.Matches(text);

                                List<int> indexes = new List<int>();
                                foreach (Match item in matches)
                                {
                                    indexes.Add(item.Index);
                                }
                                List<double> numbers = new List<double>();
                                foreach (Match item in regex.Matches(text))
                                {
                                    numbers.Add(Convert.ToInt32(item.Value));
                                }

                                for (int i = 0; i < indexes.Count; i++)
                                {
                                    if (text[indexes[i]] == '+')
                                    {
                                        result += (numbers[i] + numbers[i + 1]);
                                        numbers[i + 1] = result;
                                        if (i + 1 == indexes.Count)
                                        {
                                            break;
                                        }
                                        result = 0;
                                    }
                                    if (text[indexes[i]] == '-')
                                    {
                                        result += (numbers[i] - numbers[i + 1]);
                                        numbers[i + 1] = result;
                                        if (i + 1 == indexes.Count)
                                        {
                                            break;
                                        }
                                        result = 0;
                                    }
                                    if (text[indexes[i]] == '*')
                                    {
                                        result += (numbers[i] * numbers[i + 1]);
                                        numbers[i + 1] = result;
                                        if (i + 1 == indexes.Count)
                                        {
                                            break;
                                        }
                                        result = 0;
                                    }
                                    if (text[indexes[i]] == '/')
                                    {
                                        if (numbers[i + 1] == 0)
                                        {
                                            MessageBox.Show("Bir sayı 0'a bölünemez.!", "Uyarı", MessageBoxButtons.OK);
                                            goto finalPart;
                                        }
                                        else
                                        {
                                            result += (numbers[i] / numbers[i + 1]);
                                            numbers[i + 1] = result;
                                            if (i + 1 == indexes.Count)
                                            {
                                                break;
                                            }
                                            result = 0;
                                            
                                        }
                                    }
                                }
                                MessageBox.Show("Yapılan işlemin sonucu: " + result.ToString());
                            }


                        }
                    }
                   
                }

                finalPart:
                tbxInput.Text = "";
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            char oper = '1';
            operation += oper;
            tbxInput.Text = operation;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            char oper = '2';
            operation += oper;
            tbxInput.Text = operation;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            char oper = '3';
            operation += oper;
            tbxInput.Text = operation;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            char oper = '4';
            operation += oper;
            tbxInput.Text = operation;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            char oper = '5';
            operation += oper;
            tbxInput.Text = operation;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            char oper = '6';
            operation += oper;
            tbxInput.Text = operation;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            char oper = '7';
            operation += oper;
            tbxInput.Text = operation;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            char oper = '8';
            operation += oper;
            tbxInput.Text = operation;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            char oper = '9';
            operation += oper;
            tbxInput.Text = operation;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            char oper = '+';
            operation += oper;
            tbxInput.Text = operation;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            char oper = '-';
            operation += oper;
            tbxInput.Text = operation;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            char oper = '*';
            operation += oper;
            tbxInput.Text = operation;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            char oper = '/';
            operation += oper;
            tbxInput.Text = operation;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            char oper = '0';
            operation += oper;
            tbxInput.Text = operation;
        }
    }
}
