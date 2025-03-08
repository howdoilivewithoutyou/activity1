using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Node
    {
        public Node prev;
        public int item;
        public Node next;

        public Node(int item)
        {
            prev = null;
            this.item = item;
            next = null;
        }

    }
}
