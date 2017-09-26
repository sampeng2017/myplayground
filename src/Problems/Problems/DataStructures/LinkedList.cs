using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.DataStructures
{
    public class ListNode<T>
    {
        public T Value { get; set; }
        public ListNode<T> Next { get; set; }

        public ListNode<T> GetNthNode(int n)
        {
            if (n < 0)
            {
                throw new IndexOutOfRangeException();
            }
            ListNode<T> tmp = this;
            for (int i = n; i > 0; i--)
            {
                if (tmp == null)
                    throw new IndexOutOfRangeException();
                tmp = tmp.Next;
            }
            return tmp;
        }

        public int GetLength()
        {
            int len = 0;
            var p = this;
            while (p != null)
            {
                len++;
                p = p.Next;
            }
            return len;
        }

        public override string ToString()
        {
            string valStr = string.Empty;
            if (typeof(T).IsClass && ((object)Value == null))
            {
                valStr = "[NULL]";
            }
            else
            {
                valStr = Value.ToString();
            }

            return $"Value: {valStr}";
        }
    }
}
