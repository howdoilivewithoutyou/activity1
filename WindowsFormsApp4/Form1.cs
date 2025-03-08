using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        private StringBuilder calculation = new StringBuilder();
        private ArrayList numbers = new ArrayList();
        private ArrayList operations = new ArrayList();
        private double total = 0;
        private bool isDeleted = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void seven_Click(object sender, EventArgs e)
        {
            calculation.Append("7");
            display.Text = calculation.ToString();
        }
        private void eigth_Click(object sender, EventArgs e)
        {
            calculation.Append("8");
            display.Text = calculation.ToString();
        }
        private void nine_Click(object sender, EventArgs e)
        {
            calculation.Append("9");
            display.Text = calculation.ToString();
        }
        private void divide_Click(object sender, EventArgs e)
        {
            calculation.Append("/");
            display.Text = calculation.ToString();
        }
        private void four_Click(object sender, EventArgs e)
        {
            calculation.Append("4");
            display.Text = calculation.ToString();
        }
        private void five_Click(object sender, EventArgs e)
        {
            calculation.Append("5");
            display.Text = calculation.ToString();
        }
        private void six_Click(object sender, EventArgs e)
        {
            calculation.Append("6");
            display.Text = calculation.ToString();
        }
        private void times_Click(object sender, EventArgs e)
        {
            calculation.Append("*");
            display.Text = calculation.ToString();
        }
        private void one_Click(object sender, EventArgs e)
        {
            calculation.Append("1");
            display.Text = calculation.ToString();
        }
        private void two_Click(object sender, EventArgs e)
        {
            calculation.Append("2");
            display.Text = calculation.ToString();
        }
        private void three_Click(object sender, EventArgs e)
        {
            calculation.Append("3");
            display.Text = calculation.ToString();
        }
        private void minus_Click(object sender, EventArgs e)
        {
            calculation.Append("-");
            display.Text = calculation.ToString();
        }
        private void zero_Click(object sender, EventArgs e)
        {
            calculation.Append("0");
            display.Text = calculation.ToString();
        }
        private void delete_Click(object sender, EventArgs e)
        {
            calculation.Clear();
            total = 0;
            numbers.Clear();
            operations.Clear();
            display.Text = "0";
            history.Text = "";
        }
        private void equals_Click(object sender, EventArgs e)
        {
            if(CheckIfTheLastIsNotDigit())
                MessageBox.Show("Math Error!");
            else if(CheckIfThereAreThreeConsecutiveOperationsOrMore())
                MessageBox.Show("Math Error!");
            else
                AddTheNumbersOperations();

            ExecuteTheCalculation();
            if(!isDeleted)
            {
                calculation.Clear();
                calculation.Append(total);
                numbers.Clear();
                operations.Clear();
            }
           
        }

        public bool CheckIfTheLastIsNotDigit()
        {
            char a = calculation[calculation.Length - 1];         
            return !(char.IsDigit(a));  
        }
        public bool CheckIfThereAreThreeConsecutiveOperationsOrMore()
        {
            for (int i = 0; i < calculation.Length - 3; ++i)
            {
                char g = calculation[i];
                char l = calculation[i + 1];
                char y = calculation[i + 2];
                if (!char.IsDigit(g) && !char.IsDigit(l) && !char.IsDigit(y))               
                    return true;
            }
            return false;
        }
        public void AddTheNumbersOperations()
        {
            StringBuilder sb = new StringBuilder();
            string ngek = "";
            bool isFound = false;

            for (int i = 0; i < calculation.Length; ++i)
            {
                char c = calculation.ToString()[i];


                if (i == 0 && (c == '+' || c == '/' || c == '*'))
                {
                    MessageBox.Show("Syntax Error!");
                    return;
                }
                else if (i == 0 && c == '-')
                {
                    ngek = ngek + "-";
                }
                else if (char.IsDigit(c))
                {
                    ngek += c;

                }
                else if ((c == '+' || c == '-' || c == '/' || c == '*') && char.IsDigit(calculation[i + 1]))
                {
                    NextToDigit(ref ngek, c, isFound);

                }
                else if ((c == '+' || c == '-' || c == '/' || c == '*') && calculation[i + 1] == '-')
                {
                    NextToDigit(ref ngek, c, true);
                    ++i;
                }
                if (i == calculation.Length - 1)
                {
                    try
                    {
                        numbers.Add(ngek);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("tryht");
                    }
                }
            }

        }
        public void NextToDigit(ref string ngek, char c, bool isFound)
        {
            if(!isFound)
            {
                try
                {
                    numbers.Add(ngek);
                    ngek = "";
                    operations.Add(c);

                }
                catch (Exception)
                {
                    MessageBox.Show("iNVALID");
                }
            }else
            {
                try
                {
                    numbers.Add(ngek);
                    ngek = "-";
                    operations.Add(c);

                }
                catch (Exception)
                {
                    MessageBox.Show("iNVALID");
                }
            }
            
        }
        public void ExecuteTheCalculation()
        {
            int num = 1;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i == 0)
                {
                    char c = Convert.ToChar(operations[0]);

                    switch (c)
                    {
                        case '/':
                            total = Convert.ToDouble((numbers[i])) / Convert.ToDouble(numbers[i + 1]);
                            break;
                        case '*':
                            total = Convert.ToInt16((numbers[i])) * Convert.ToInt16(numbers[i + 1]);
                            break;
                        case '-':
                            total = Convert.ToInt16((numbers[i])) - Convert.ToInt16(numbers[i + 1]);
                            break;
                        case '+':
                            total = Convert.ToInt16((numbers[i])) + Convert.ToInt16(numbers[i + 1]);
                            break;
                    }
                } else if (i != 1)
                {
                    if (num < operations.Count)
                    {
                        char c = Convert.ToChar(operations[num]);
                        switch (c)
                        {
                            case '/':
                                total /= Convert.ToDouble((numbers[i]));
                                break;
                            case '*':
                                total *= Convert.ToInt16((numbers[i]));
                                break;
                            case '-':
                                total -= Convert.ToInt16((numbers[i]));
                                break;
                            case '+':
                                total += Convert.ToInt16((numbers[i]));
                                break;

                        }
                    }
                    ++num;
                }
            }
            string totalDecimal = $"{total:F2}";
            display.Text = totalDecimal;
            history.Text = calculation.ToString();

        }
        private void add_Click(object sender, EventArgs e)
        {
            calculation.Append("+");
            display.Text = calculation.ToString();
        }
        private void display_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
