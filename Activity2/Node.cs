using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity2
{
    internal class Node
    {
        public Node prev;
        public char item;
        public Node next;

        public Node(char item)
        {
            prev = null;
            this.item = item;
            next = null;
        }

    }
}
