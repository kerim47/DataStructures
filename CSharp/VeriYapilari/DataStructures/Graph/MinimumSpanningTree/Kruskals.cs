using DataStructures.Heap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph.MinimumSpanningTree
{
    public class Kruskals<T, TW>
        where TW : IComparable
        where T  : IComparable
    {
        public List<MSTEdge<T, TW>> FindMinimumSpanningTree(IGraph<T> graph) 
        {
            var edges = new List<MSTEdge<T, TW>>();
            dfs(graph.ReferenceVertex
                , new HashSet<T>()
                , new Dictionary<T, HashSet<T>>()
                , edges);

            var heap = new BinaryHeap<MSTEdge<T, TW>>(Shared.SortDirection.Ascending);

            foreach (var edge in edges)
                heap.Add(edge);

            var sortedEdgearr = new MSTEdge<T, TW>[edges.Count];

            for (int i = 0; i < edges.Count; i++)
                sortedEdgearr[i] = heap.DeleteMinMax();

            var disjointSet = new Set.DisjointSet<T>();

            foreach (var vertex in graph.VerticesAsEnumerable)
                disjointSet.MakeSet(vertex.Key);

            var resultEdgeList = new List<MSTEdge<T, TW>>();

            for (int i = 0; i < edges.Count; i++)
            {
                var currentEdge = sortedEdgearr[i];
                var setA = disjointSet.FindSet(currentEdge.Source);
                var setB = disjointSet.FindSet(currentEdge.Destination);

                if (setA.Equals(setB))
                    continue;
                resultEdgeList.Add(currentEdge);
                disjointSet.Union(setA, setB);
            }

            return resultEdgeList;
        }

        private void dfs(IGraphVertex<T> currentVertex
            , HashSet<T> visitedVertices
            , Dictionary<T, HashSet<T>> visitedEdges
            , List<MSTEdge<T, TW>> edges)
        {
            if (!visitedVertices.Contains(currentVertex.Key))
            {
                visitedVertices.Add(currentVertex.Key);
                foreach (var edge in currentVertex.Edges)
                {
                    if(!visitedEdges.ContainsKey(currentVertex.Key) 
                        || !visitedEdges[currentVertex.Key].Contains(edge.TargetVertexKey))
                    {
                        edges.Add(new MSTEdge<T, TW>(
                            currentVertex.Key,
                            edge.TargetVertexKey,
                            edge.Weight<TW>()));

                        if (!visitedEdges.ContainsKey(currentVertex.Key))
                            visitedEdges.Add(currentVertex.Key, new HashSet<T>());

                        visitedEdges[currentVertex.Key].Add(edge.TargetVertexKey);

                        if (!visitedEdges.ContainsKey(edge.TargetVertexKey))
                            visitedEdges.Add(edge.TargetVertexKey, new HashSet<T>());

                        visitedEdges[edge.TargetVertexKey].Add(currentVertex.Key);

                        dfs(edge.TargetVertex, visitedVertices, visitedEdges, edges);
                    }
                }
            }
        }
    }
}
