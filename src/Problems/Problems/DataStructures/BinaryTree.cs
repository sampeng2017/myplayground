using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.DataStructures
{
    public class BinaryTreeNode<T>
    {
        public T Value { get; set; }
        public BinaryTreeNode<T> LeftChild { get; set; }
        public BinaryTreeNode<T> RightChild { get; set; }

        public bool IsLeaf => LeftChild == null && RightChild == null;

        public override string ToString()
        {
            if (IsLeaf)
            {
                return $"{{{Value}(leaf)}}";
            }
            var left = LeftChild == null ? "NIL" : LeftChild.ToString();
            var right = RightChild == null ? "NIL" : RightChild.ToString();
            return $"{{{Value}; Left: {left}; Right: {right}}}";
        }

        public void InOrderVisit(Action<BinaryTreeNode<T>> visit)
        {
            LeftChild?.InOrderVisit(visit);
            visit(this);
            RightChild?.InOrderVisit(visit);
        }
    }
}
