﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Basics
{
    public class Heap<T> where T : IComparable
    {
        private readonly List<T> heap;
        private readonly Func<List<T>, int, int, bool> compare;

        public int Count => heap.Count - 1;
        public bool IsEmpty => Count == 0;
        public bool IsMaxHeap { get; }

        public Heap(bool maxHeap = true)
        {
            IsMaxHeap = maxHeap;
            if (maxHeap)
                compare = Helpers.Less;
            else
                compare = Helpers.More;
            // add a dummy item to index 0
            // this makes calcuating parent/child index eaiser
            heap = new List<T>() { default(T) };
        }

        public Heap(T[] elements, bool maxHeap = true)
            : this(maxHeap)
        {
            heap.AddRange(elements);
            for (int i = elements.Length /2; i >= 1; i--)
            {
                Sink(i);
            }
        }

        public void Insert(T val)
        {
            heap.Add(val);
            Swim();
        }

        public T TakeNext()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Empty heap");
            var result = heap[1];
            Exchange(1, heap.Count - 1);
            heap.RemoveAt(heap.Count - 1);
            Sink();
            return result;
        }

        public T PeekNext()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Empty heap");
            return heap[1];
        }

        private void Sink(int parent = 1)
        {
            int leftChild = parent * 2;
            while (leftChild < heap.Count)
            {
                int childToCompare = leftChild;
                int rightChild = leftChild + 1;
                if (rightChild != heap.Count && compare(heap, leftChild, rightChild))
                {
                    childToCompare = rightChild;
                }

                if (compare(heap, childToCompare, parent))
                {
                    break;
                }
                Exchange(parent, childToCompare);
                parent = childToCompare;
                leftChild = childToCompare * 2;
            }
        }

        private void Swim()
        {
            int child = heap.Count - 1;
            int parent = child / 2;
            while (parent > 0 && compare(heap,parent, child))
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
    }
}
