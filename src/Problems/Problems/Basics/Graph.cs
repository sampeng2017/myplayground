using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Basics
{
    public class GraphVertice<T>
    {
        public GraphVertice()
        {
            AdjacentVertices = new List<GraphVertice<T>>();
        }

        public T Value { get; set; }
        public IList<GraphVertice<T>> AdjacentVertices { get; }

        public static void DFS(GraphVertice<T> vertice, Action<GraphVertice<T>> visit)
        {
            visit(vertice);
            foreach (var v in vertice.AdjacentVertices)
            {
                DFS(v, visit);
            }
        }

        public static void BFS(GraphVertice<T> vertice, Action<GraphVertice<T>> visit)
        {
            var queue = new Queue<GraphVertice<T>>();
            queue.Enqueue(vertice);
            while (queue.Count >0 )
            {
                var v = queue.Dequeue();
                visit(v);
                foreach (var a in v.AdjacentVertices)
                {
                    queue.Enqueue(a);
                }
            }
        }
    }
}
