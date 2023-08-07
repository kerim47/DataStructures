﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph.AdjancencySet
{
    public class DiGraph<T> : IDiGraph<T>
    {
        private Dictionary<T, DiGraphVertex<T>> vertices;

        public IDiGraphVertex<T> ReferenceVertex => vertices[this.First()];

        public IEnumerable<IDiGraphVertex<T>> VerticesAsEnumerable 
            => vertices.Select(x => x.Value);

        public bool isWeightedGraph => false;

        public int Count => vertices.Count;

        IGraphVertex<T> IGraph<T>.ReferenceVertex
             => vertices[this.First()] as IGraphVertex<T>;
        IEnumerable<IGraphVertex<T>> IGraph<T>.VerticesAsEnumerable
            => vertices.Select(x => x.Value);

        public DiGraph()
        {
            vertices = new Dictionary<T, DiGraphVertex<T>>();
        }

        public DiGraph(IEnumerable<T> collection)
        {
            vertices = new Dictionary<T, DiGraphVertex<T>>();
            foreach (var item in collection)
                AddVertex(item);
        }

        public void AddVertex(T key)
        {
            if (key == null)
                throw new ArgumentNullException("key");

            var newVertex = new DiGraphVertex<T>(key);
            vertices.Add(key, newVertex);
        }

        IGraph<T> IGraph<T>.Clone() => Clone();

        public DiGraph<T> Clone()
        {
            DiGraph<T> graph = new DiGraph<T>();
            foreach (var vertex in vertices)
                graph.AddVertex(vertex.Key);

            foreach (var vertex in vertices)
                foreach (var node in vertex.Value.OutEdges)
                    graph.AddEdge(vertex.Value.Key, node.Key);

            return graph;
        }

        public bool ContainsVertex(T key) => vertices.ContainsKey(key);

        public IEnumerable<T> Edges(T key)
        {
            if (key == null)
                throw new ArgumentNullException();

            return vertices[key].OutEdges.Select(x => x.Key);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return vertices.Select(x => x.Key).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IDiGraphVertex<T> GetVertex(T key)
            => vertices[key];

        //public IGraphVertex<T> GetVertex(T key) => vertices[key];

        IGraphVertex<T> IGraph<T>.GetVertex(T key)
            => vertices[key] as IGraphVertex<T>;


        //public IGraphVertex<T> GetVertex(T key) => vertices[key];

        private void StatusSrcDest(T source, T dest)
        {
            if (source == null || dest == null)
                throw new ArgumentNullException("source or dest");
        }

        private void StatusContains(T source, T dest)
        {
            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest))
                throw new ArgumentNullException("source or dest vertex is not in this graph.");
        }

        private void StatusEdgesContains(T source, T dest)
        {
            if (vertices[source].OutEdges.Contains(vertices[dest]) ||
                vertices[dest].OutEdges.Contains(vertices[source]))
                throw new Exception("The edge has been already defined!");
        }

        public void ExceptStatus(T source, T dest)
        {
            StatusSrcDest(source, dest);
            StatusContains(source, dest);
            StatusEdgesContains(source, dest);
        }

        public bool HasEdge(T source, T dest)
        {
            StatusSrcDest(source, dest);
            StatusContains(source, dest);
            return vertices[source].OutEdges.Contains(vertices[dest])
                && vertices[dest].InEdges.Contains(vertices[source]);
        }

        public void RemoveEdge(T source, T dest)
        {
            StatusSrcDest(source, dest);
            StatusContains(source, dest);

            if (!vertices[source].OutEdges.Contains(vertices[dest]) ||
                !vertices[dest].OutEdges.Contains(vertices[source]))
                throw new Exception("The edge does not exists!");

            vertices[source].OutEdges.Remove(vertices[dest]);
            vertices[dest].InEdges.Remove(vertices[source]); ;
        }

        public void AddEdge(T source, T dest)
        {
            StatusSrcDest(source, dest);
            StatusContains(source, dest);
            if (vertices[source].OutEdges.Contains(vertices[dest]) ||
                vertices[dest].InEdges.Contains(vertices[source]))
                throw new Exception("The edge has been already defined!");
            vertices[source].OutEdges.Add(vertices[dest]);
            vertices[dest].InEdges.Add(vertices[source]);
        }

        public void RemoveVertex(T key)
        {
            if (key == null)
                throw new ArgumentNullException();

            if (!vertices.ContainsKey(key))
                throw new ArgumentException("The vertex is not in this graph!");

            foreach (var vertex in vertices[key].OutEdges)
                vertex.OutEdges.Remove(vertices[key]);

            foreach (var vertex in vertices[key].InEdges)
                vertex.InEdges.Remove(vertices[key]);


            vertices.Remove(key);
        }

        private class DiGraphVertex<T> : IDiGraphVertex<T>
        {
            public HashSet<DiGraphVertex<T>> OutEdges { get; }
            public HashSet<DiGraphVertex<T>> InEdges { get; }

            IEnumerable<IEdge<T>> IDiGraphVertex<T>.OutEdges
                => OutEdges.Select(x => new DiEdge<T, int>(x, 1));

            IEnumerable<IEdge<T>> IDiGraphVertex<T>.InEdges
                => InEdges.Select(x => new DiEdge<T, int>(x, 1));

            public int OutEdgesCount => OutEdges.Count;

            public int InEdgesCount => InEdges.Count;

            public T Key { get; set; }

            public DiGraphVertex(T key)
            {
                Key = key;
                OutEdges = new HashSet<DiGraphVertex<T>>();
                InEdges = new HashSet<DiGraphVertex<T>>();
            }

            public IEnumerable<IEdge<T>> Edges => OutEdges.Select(x => new Edge<T, int>(x, 1));

            public IEdge<T> GetEdge(IGraphVertex<T> targetVertex) => new Edge<T, int>(targetVertex, 1);

            public IEnumerator<T> GetEnumerator()
            {
                return OutEdges.Select(x => x.Key).GetEnumerator();
            }

            public IDiEdge<T> GetOutEdge(IDiGraphVertex<T> targetVertex)
            {
                return new DiEdge<T, int>(targetVertex, 1);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
