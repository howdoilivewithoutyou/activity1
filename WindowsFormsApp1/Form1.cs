using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Activity_1 : Form
    {
        private StringBuilder compute = new StringBuilder();
        private StringBuilder num = new StringBuilder();
        private ArrayList operands = new ArrayList();
        private ArrayList operators = new ArrayList();
        private double total;


        public Activity_1()
        {
            InitializeComponent();
        }

        private void btn_five_Click(object sender, EventArgs e)
        {
            
            compute.Append("5");
            num.Append("5");
            tb_display.Text = num.ToString();
        }

        private void btn_seven_Click(object sender, EventArgs e)
        {

            compute.Append("7");
            num.Append("7");
            tb_display.Text = num.ToString();
        }

        private void Activity_1_Load(object sender, EventArgs e)
        {

        }

        private void btn_nine_Click(object sender, EventArgs e)
        {
            compute.Append("9");
            num.Append("9");
            tb_display.Text = num.ToString();
        }

        private void btn_divide_Click(object sender, EventArgs e)
        {
            compute.Append("/");
            num.Clear();
        }

        private void btn_multiply_Click(object sender, EventArgs e)
        {
            compute.Append("*");
            num.Clear();
        }

        private void btn_eigth_Click(object sender, EventArgs e)
        {

            compute.Append("8");
            num.Append("8");
            tb_display.Text = num.ToString();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            compute.Append("+");
            num.Clear();
        }

        private void btn_equals_Click(object sender, EventArgs e)
        {
            string number = "";
            for (int i = 0; i < compute.Length; i++)
            {
                char c = compute[i];

                if(i == 0 && c != '-' && !Char.IsDigit(c))
                {
                    compute.Clear();
                    num.Clear();
                    operands.Clear();
                    operators.Clear();
                    total = 0;
                    tb_display.Clear();
                    tb_history.Clear();
                    MessageBox.Show("Invalid Equation");
                    return;
                }
                
                if(i == 0 && c == '-' && !Char.IsDigit(c))
                {
                    number += '-';
                }
                else if (Char.IsDigit(c))
                {
                    number += c;
                } else if (!Char.IsDigit(c) && !Char.IsDigit(compute[i + 1]) && compute[i + 1] == '-')
                {
                    operands.Add(Convert.ToInt16(number));
                    operators.Add(c);
                    number = "";
                    number += compute[i + 1];
                    ++i;
                    Console.WriteLine(number);
                }
                else if (!Char.IsDigit(c) && !Char.IsDigit(compute[i + 1]) && compute[i + 1] != '-')
                {
                    MessageBox.Show("Invalid Equation DSFSDFG");
                    compute.Clear();
                    num.Clear();
                    operands.Clear();
                    operators.Clear();
                    total = 0;
                    tb_display.Clear();
                    tb_history.Clear();
                    return;
                }
                else if (!Char.IsDigit(c)) 
                {
                    Console.WriteLine(number);
                    operands.Add(Convert.ToInt16(number));
                    operators.Add(c);
                    number = "";
                }
                if (i == compute.Length - 1)
                {
                    operands.Add(Convert.ToInt16(number));
                    number = "";
                }

            }
            int count = 1;
            for (int i = 0; i < operands.Count; i++)
            {
                if (i == 0)
                {
                    char d = Convert.ToChar(operators[i]);
                    
                    switch(d)
                    {
                        case '/':
                            total = Convert.ToDouble(operands[i]) / Convert.ToDouble(operands[i + 1]);
                            break;
                        case '*':
                            total = Convert.ToInt16(operands[i]) * Convert.ToInt16(operands[i + 1]);
                            break;
                        case '+':
                            total = Convert.ToInt16(operands[i]) + Convert.ToInt16(operands[i + 1]);
                            break;
                        case '-':
                            total = Convert.ToInt16(operands[i]) - Convert.ToInt16(operands[i + 1]);
                            break;
                        default:
                            MessageBox.Show("Invalid Equation");
                            return;
                    }
                }else if(i != 1)
                {
                    char d = Convert.ToChar(operators[count]);

                    switch (d)
                    {
                        case '/':
                            total /= Convert.ToDouble(operands[i]);
                            break;
                        case '*':
                            total *= Convert.ToInt16(operands[i]);
                            break;
                        case '+':
                            total += Convert.ToInt16(operands[i]);
                            break;
                        case '-':
                            total -= Convert.ToInt16(operands[i]);
                            break;
                        default:
                            MessageBox.Show("Invalid Equation");
                            break;
                    }
                }
            }
           
            string totalDisplay = (total % 1 != 0) ? $"{total:F10}" : $"{total:0}";
            tb_display.Text = totalDisplay;
            tb_history.Text = compute.ToString();
            compute.Clear();
            compute.Append(Convert.ToString(total));
            operands.Clear();
            operators.Clear();
            total = 0;
        }

        private void btn_three_Click(object sender, EventArgs e)
        {

            compute.Append("3");
            num.Append("3");
            tb_display.Text = num.ToString();
        }

        private void btn_six_Click(object sender, EventArgs e)
        {

            compute.Append("6");
            num.Append("6");
            tb_display.Text = num.ToString();
        }

        private void bnt_subtract_Click(object sender, EventArgs e)
        {
            compute.Append("-");
            num.Clear();
        }

        private void btn_two_Click(object sender, EventArgs e)
        {

            compute.Append("2");
            num.Append("2");
            tb_display.Text = num.ToString();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            compute.Clear();
            num.Clear();
            operands.Clear();
            operators.Clear();
            total = 0;
            tb_display.Clear();
            tb_history.Clear();
        }

        private void btn_zero_Click(object sender, EventArgs e)
        {
            compute.Append("0");
            num.Append("0");
            tb_display.Text = num.ToString();
        }

        private void btn_one_Click(object sender, EventArgs e)
        {
            compute.Append("1");
            num.Append("1");
            tb_display.Text = num.ToString();
        }

        private void btn_four_Click(object sender, EventArgs e)
        {
            compute.Append("4");
            num.Append("4");
            tb_display.Text = num.ToString();
        }
    }
}
