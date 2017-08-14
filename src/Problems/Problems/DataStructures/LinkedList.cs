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
