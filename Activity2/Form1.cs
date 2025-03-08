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
using Activity2;

namespace WindowsFormsApp1
{
    public partial class Activity_1 : Form
    {
        StringBuilder equation = new StringBuilder();
        ArrayList operands = new ArrayList();
        ArrayList operators;
        double total;


        public Activity_1()
        {
            InitializeComponent();
        }

        private void btn_five_Click(object sender, EventArgs e)
        {
            equation.Append("5");
            tb_display.Text = equation.ToString();
        }

        private void btn_seven_Click(object sender, EventArgs e)
        {
            equation.Append("7");
            tb_display.Text = equation.ToString();

        }

        private void Activity_1_Load(object sender, EventArgs e)
        {

        }

        private void btn_nine_Click(object sender, EventArgs e)
        {
            equation.Append("9");
            tb_display.Text = equation.ToString();
        }

        private void btn_divide_Click(object sender, EventArgs e)
        {
            equation.Append("/");
            tb_display.Text = equation.ToString();
        }

        private void btn_multiply_Click(object sender, EventArgs e)
        {
            equation.Append("*");
            tb_display.Text = equation.ToString();
        }

        private void btn_eigth_Click(object sender, EventArgs e)
        {
            equation.Append("8");
            tb_display.Text = equation.ToString();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            equation.Append("+");
            tb_display.Text = equation.ToString();
        }

        private void btn_equals_Click(object sender, EventArgs e)
        {
            ConvertInfixToPostfix convert = new ConvertInfixToPostfix(equation.ToString());
            convert.SetConversion();
            operators = convert.GetOperators();

            Console.WriteLine("Operators");
            foreach(var l in operators) 
                Console.WriteLine(l);

            string number = "";

            for (int i = 0; i < equation.Length; ++i)
            {
                char c = equation[i];

                if (i == 0 && c == '-' && !Char.IsDigit(c))
                {
                    number += '-';
                }
                else if (Char.IsDigit(c))
                {
                    number += c;
                }
                else if (!Char.IsDigit(c) && !Char.IsDigit(equation[i + 1]) && equation[i + 1] == '-')
                {
                    operands.Add(Convert.ToInt16(number));
                    number = "";
                    number += equation[i + 1];
                    ++i;
                }
                else if (!Char.IsDigit(c) && !Char.IsDigit(equation[i + 1]) && equation[i + 1] != '-')
                {
                    MessageBox.Show("Invalid Equation");
                    equation.Clear();
                    operands.Clear();
                    operators.Clear();
                    total = 0;
                    tb_display.Clear();
                    tb_history.Clear();
                    return;
                }
                else if (!Char.IsDigit(c))
                {
                    operands.Add(Convert.ToInt16(number));
                    number = "";
                }
                if (i == equation.Length - 1)
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

                    switch (d)
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
                }
                else if (i != 1)
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
                            MessageBox.Show("Invalid Equationd");
                            break;
                    }
                }






            }

            string totalDisplay = (total % 1 != 0) ? $"{total:F10}" : $"{total:0}";
            tb_display.Text = totalDisplay;
            tb_history.Text = equation.ToString();
            equation.Clear();
            equation.Append(Convert.ToString(total));
            operands.Clear();
            operators.Clear();
            total = 0;

        }

        private void btn_three_Click(object sender, EventArgs e)
        {
            equation.Append("3");
            tb_display.Text = equation.ToString();

        }

        private void btn_six_Click(object sender, EventArgs e)
        {
            equation.Append("6");
            tb_display.Text = equation.ToString();

        }

        private void bnt_subtract_Click(object sender, EventArgs e)
        {
            equation.Append("-");
            tb_display.Text = equation.ToString();
        }

        private void btn_two_Click(object sender, EventArgs e)
        {
            equation.Append("2");
            tb_display.Text = equation.ToString();

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            equation.Clear();
            operands.Clear();
            operators.Clear();
            total = 0;
            tb_display.Clear();
            tb_history.Clear();
        }

        private void btn_zero_Click(object sender, EventArgs e)
        {
            equation.Append("0");
            tb_display.Text = equation.ToString();
        }

        private void btn_one_Click(object sender, EventArgs e)
        {
            equation.Append("1");
            tb_display.Text = equation.ToString();
        }

        private void btn_four_Click(object sender, EventArgs e)
        {
            equation.Append("4");
            tb_display.Text = equation.ToString();
        }



    }
}
