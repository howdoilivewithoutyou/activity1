using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity2
{
    internal class ConvertInfixToPostfix
    {
        private string infix;
        private string postConvert;
        private ArrayList operators = new ArrayList();
        public ConvertInfixToPostfix(string infix)
        {
           this.infix = infix;
        }

        public void SetConversion()
        {
            StringBuilder postfix = new StringBuilder();
            DoublyLinkedListStack list = new DoublyLinkedListStack();

            for (int i = 0; i < infix.Length; ++i)
            {
                char c = infix[i];
                if (Char.IsDigit(c))
                {
                    postfix.Append(c);
                }
                else if (c == '(')
                {
                    list.Push(c);
                }
                else if (c == ')')
                {
                    while (list.GetHead() != '(')
                    {
                        postfix.Append(list.GetHead());
                        list.Pop();
                    }
                    if (list.GetHead() == '(')
                    {
                        list.Pop();
                    }

                }
                else if (c == '^' || c == '/' || c == '*' || c == '+' || c == '-')
                {
                    list.GetPrecedence(c);
                    if (!list.IsEmptyStack())
                    {
                        if (list.GetPoppedItem() != "")
                        {
                            postfix.Append(list.GetPoppedItem());
                            list.SetPoppedItem("");
                        }
                    }
                    else
                    {
                        if (list.GetPoppedItem() == "")
                        {
                            postfix.Append(list.GetPoppedItem());
                            list.SetPoppedItem("");
                        }
                    }
                }

            }

            if (list.GetRemaining() == "")
            {
                list.RestOfTheOperators();
                postfix.Append(list.GetRemaining());
            }   
            postConvert = postfix.ToString();

            for (int i = postConvert.Length-1; i >=  0; i--)
            {
                char c = postConvert[i];
                if(!Char.IsDigit(c))
                {
                    operators.Add(c);
                }
            }
            Console.WriteLine("Postfix: " + postfix);

        }

        public ArrayList GetOperators()
        {
            return operators;   
        }
        
    }
}
