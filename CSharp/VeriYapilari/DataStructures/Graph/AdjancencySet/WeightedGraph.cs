﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph.AdjancencySet
{
    public class WeightedGraph<T, TW> : IGraph<T>
        where TW : IComparable 
    {
        private Dictionary<T, WeightedGraphVertex<T, TW>> vertices;
        public bool isWeightedGraph => true;

        public int Count => vertices.Count;

        public IGraphVertex<T> ReferenceVertex => vertices[this.First()];

        public IEnumerable<IGraphVertex<T>> VerticesAsEnumerable => 
            vertices.Select(x => x.Value);

        public void AddVertex(T key)
        {
            if( key == null )
                throw new ArgumentNullException("key");

            var newVertex = new WeightedGraphVertex<T, TW>(key);
            vertices.Add(key, newVertex);
        }

        IGraph<T> IGraph<T>.Clone() => Clone();

        public WeightedGraph<T, TW> Clone()
        {
            WeightedGraph<T, TW> graph = new WeightedGraph<T, TW>();
            foreach (var vertex in vertices)
                graph.AddVertex(vertex.Key);

            foreach (var vertex in vertices)
                foreach (var edge in vertex.Value.Edges)
                    graph.AddEdge(vertex.Value.Key, edge.Key.Key, edge.Value);

            return graph;
        }

        public bool ContainsVertex(T key) => vertices.ContainsKey(key);

        public IEnumerable<T> Edges(T key)
        {
            if (key == null)
                throw new ArgumentNullException();

            return vertices[key].Edges.Select(x => x.Key.Key);
        }

        public void AddEdge(T source, T dest, TW weight)
        {
            StatusContains(source, dest);
            StatusSrcDest(source, dest);
            vertices[source].Edges.Add(vertices[dest], weight);
            vertices[dest].Edges.Add(vertices[source], weight);
        }

        private void StatusSrcDest(T source, T dest)
        {
            if(source == null || dest == null) 
                throw new ArgumentNullException("source or dest");
        }

        private void StatusContains(T source, T dest)
        {
            if(!vertices.ContainsKey(source) || !vertices.ContainsKey(dest)) 
                throw new ArgumentNullException("source or dest vertex is not in this graph.");
        }

        public IEnumerator<T> GetEnumerator()
        {
            return vertices.Select(x => x.Key).GetEnumerator();
        }

        public IGraphVertex<T> GetVertex(T key) => vertices[key];

        public bool HasEdge(T source, T dest)
        {
            StatusSrcDest(source, dest);
            StatusContains(source, dest);
            return vertices[source].Edges.ContainsKey(vertices[dest]) 
                && vertices[dest].Edges.ContainsKey(vertices[source]);
        }

        public void RemoveEdge(T source, T dest)
        {
            StatusSrcDest(source, dest);
            StatusContains(source, dest);

            if (!vertices[source].Edges.ContainsKey(vertices[dest]) || 
                !vertices[dest].Edges.ContainsKey(vertices[source]))
                throw new Exception("The edge does not exists!");

            vertices[source].Edges.Remove(vertices[dest]);
            vertices[dest].Edges.Remove(vertices[source]);;
        }

        public void RemoveVertex(T key)
        {
            if (key == null)
                throw new ArgumentNullException();

            if (vertices.ContainsKey(key))
                throw new ArgumentException("The vertex is not in this graph!");

            foreach (var vertex in vertices[key].Edges)
                vertex.Key.Edges.Remove(vertices[key]);

            vertices.Remove(key);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return  GetEnumerator();
        }

        public WeightedGraph()
        {
            vertices = new Dictionary<T, WeightedGraphVertex<T, TW>>();
        }

        public WeightedGraph(IEnumerable<T> collection)
        {
            vertices = new Dictionary<T, WeightedGraphVertex<T, TW>>();
            foreach (var item in collection)
                AddVertex(item);
        }

        private class WeightedGraphVertex<T, TW> : IGraphVertex<T>
            where TW : IComparable
        {
            public T Key { get; set; }

            public Dictionary<WeightedGraphVertex<T, TW>, TW> Edges;

            IEnumerable<IEdge<T>> IGraphVertex<T>.Edges =>  Edges.Select(x => new Edge<T, TW>(x.Key, x.Value));

            public WeightedGraphVertex(T key)
            {
                Key   = key;
                Edges = new Dictionary<WeightedGraphVertex<T, TW>, TW>();
            }

            public IEdge<T> GetEdge(IGraphVertex<T> targetVertex)
            {
                return new Edge<T, TW>(targetVertex, Edges[targetVertex as WeightedGraphVertex<T, TW>]);
            }

            public IEnumerator<T> GetEnumerator()
            {
                return Edges.Select(x => x.Key.Key).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}