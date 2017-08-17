using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Basics
{
    public class MaxHeap<T> where T : IComparable
    {
        private readonly List<T> heap = new List<T>() { default(T) };

        public bool IsEmpty => heap.Count == 1;

        public void Insert(T val)
        {
            heap.Add(val);
            Swim();
        }

        public T GetMax()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Empty heap");
            var result = heap[1];
            Exchange(1, heap.Count - 1);
            heap.RemoveAt(heap.Count - 1);
            Sink();
            return result;
        }

        private void Sink()
        {
            int parent = 1;
            int child = parent * 2;
            while (child < heap.Count)
            {
                int childToCompare = child;
                if (child + 1 != heap.Count && Less(child, child + 1))
                {
                    childToCompare = child + 1;
                }

                if (Less(childToCompare, parent))
                {
                    break;
                }
                Exchange(parent, childToCompare);
                child = childToCompare;
            }
        }
        private void Swim()
        {
            int child = heap.Count - 1;
            if (child == 0)
                return;
            int parent = child / 2;
            while (parent > 0 && Less(parent, child))
            {
                Exchange(parent, child);
                child = parent;
                parent = child / 2;
            }
        }

        private void Exchange(int i, int j)
        {
            T tmp = heap[i];
            heap[i] = heap[j];
            heap[j] = tmp;
        }

        private bool Less(int i, int j)
        {
            return heap[i].CompareTo(heap[j]) < 0;
        }
    }
}
