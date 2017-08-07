using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.DataStructures
{
    public class LikedListNode<T>
    {
        public T Value { get; set; }
        public LikedListNode<T> Next { get; set; }
    }
}
