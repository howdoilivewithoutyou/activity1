using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class DoublyLinkedList
    {
        Node head, tail;

        public DoublyLinkedList()
        {
            head = tail = null;
        }

        public void AddToHead(int item)
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
                head = temp;
            }
        }

        public void DeleteFromHead()
        {
            if(head == null)
            {
                Console.WriteLine("The list is empty");
                return;
            }else if (head == tail)
            {
                Console.WriteLine("The list is now empty");
                return;
            }else
            {
                Node temp = head;
                temp = temp.next;
                temp.prev = null;
                head = temp;
            }

        }


    }
}
