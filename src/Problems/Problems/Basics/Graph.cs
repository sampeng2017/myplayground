﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Basics
{
    public class Graph
    {
        // number of vertices
        private readonly int v;
        // number of edges
        private int e;
        // adjacency lists
        private List<int>[] adj; // adjacency lists

        public Graph(int v)
        {
            this.v = v;
            this.e = 0;
            this.adj = new List<int>[v];
            for (int i = 0; i < v; i++) 
                adj[i] = new List<int>();
        }

        public int V() { return v; }
        public int E() { return e; }
        public void AddEdge(int v, int w)
        {
            adj[v].Add(w); // Add w to v’s list.
            adj[w].Add(v); // Add v to w’s list.
            e++;
        }
        public IEnumerable<int> GetAdjacencents(int v)
        {
            return adj[v];
        }

        public static int Degree(Graph g, int v)
        {
            int degree = 0;
            foreach (int w in g.GetAdjacencents(v))
            {
                degree++;
            }
            return degree;
        }

        public static int MaxDegree(Graph G)
        {
            int max = 0;
            for (int v = 0; v < G.V(); v++)
            {
                var d = Degree(G, v);
                if (d > max)
                    max = d;
            }
            return max;
        }
    }

    public class GraphNode<T>
    {
        public GraphNode()
        {
            Adjacencents = new List<GraphNode<T>>();
        }
        public T Value { get; set; }
        public IList<GraphNode<T>> Adjacencents { get; }

        public IEnumerable<GraphNode<T>> TopologicalSort()
        {
            var visited = new HashSet<GraphNode<T>>();
            var stack = new Stack<GraphNode<T>>();
            var recursionStack = new Stack<GraphNode<T>>();
            TopologicalSort(visited, stack, recursionStack);

            return stack.ToList();
        }

        private void TopologicalSort(HashSet<GraphNode<T>> visited, Stack<GraphNode<T>> sortStack, Stack<GraphNode<T>> recursionStack)
        {
            if (recursionStack.Contains(this))
                throw new InvalidOperationException($"Circular path detected: {this.Value}");

            if (visited.Contains(this))
                return;

            recursionStack.Push(this);
            sortStack.Push(this);
            visited.Add(this);
            foreach (var a in Adjacencents)
            {
                a.TopologicalSort(visited, sortStack, recursionStack);
            }
            recursionStack.Pop();
        }
    }
}
