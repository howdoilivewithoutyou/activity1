using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity2
{
    internal class DoublyLinkedListStack
    {
        Node head, tail;
        String poppedItem = "";
        String remains = "";
        public DoublyLinkedListStack()
        {
            head = tail = null;
        }

        public void Push(char item)
        {
            Node node = new Node(item);
            if (head == null && tail == null)
            {
                head = tail = node;
            }
            else
            {
                Node temp = head;
                temp.prev = node;
                node.next = temp;
                head = node;
            }

        }

        public void Pop()
        {
            if (head == null && tail == null)
            {
                Console.WriteLine("The list is empty");
                return;
            }
            else if (head == tail)
            {
                head = tail = null;
                Console.WriteLine("The list is now empty");
                return;
            }
            else
            {
                Node temp = head;
                temp = temp.next;
                temp.prev = null;
                head = temp;
            }
        }
        public char GetHead()
        {
            return head.item;
        }

        public void GetPrecedence(char c)
        {
            if (IsEmptyStack())
            {
                Push(c);
                return;
            }

            if (head.item == '(')
            {
                Push(c);
                return;
            }

            Node temp = head;

            while (temp != null)
            {
                char[] operators = { c, temp.item };
                int[] precedences = new int[2];
                Console.WriteLine(c + " " + temp.item);
                for (int i = 0; i < operators.Length; ++i)
                {
                    switch (operators[i])
                    {
                        //case '^':
                        //    precedences[i] = 3;
                        //    break;
                        case '/':
                        case '*':
                            precedences[i] = 2;
                            break;
                        case '+':
                        case '-':
                            precedences[i] = 1;
                            break;
                    }

                }
                if (temp.item == '(')
                {
                    Push(c);
                    return;
                }

                if (precedences[0] > precedences[1])
                {
                    Push(operators[0]);
                    return;
                }
                else if (precedences[0] <= precedences[1])
                {
                    Console.WriteLine(GetHead() + "popped ");
                    poppedItem += "" + GetHead();
                    Pop();
                    temp = head;
                    if (head == null && tail == null)
                    {
                        Console.WriteLine("dsfdsfsdfdsf");
                        Push(c);
                        return;
                    }
                }

            }
        }

        public String GetPoppedItem()
        {
            return poppedItem;
        }
        public void SetPoppedItem(String s)
        {
            poppedItem = s;
        }

        public Boolean IsEmptyStack()
        {
            return head == null;
        }

        public void RestOfTheOperators()
        {
            if (!IsEmptyStack())
            {
                Node temp = head;
                while (temp != null)
                {
                    remains += temp.item;
                    temp = temp.next;
                }
            }
            else
            {
                Console.WriteLine("Stack is empty.");
            }
        }

        public String GetRemaining()
        {
            return remains;
        }

    }
}
