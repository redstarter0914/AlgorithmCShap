using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmTest.LinkedList
{

    public class ListNode<T>
    {
        public T Value;
        public ListNode(T value)
        {
            Value = value;
        }

        public ListNode<T> Next { get; set; }
    }
}
