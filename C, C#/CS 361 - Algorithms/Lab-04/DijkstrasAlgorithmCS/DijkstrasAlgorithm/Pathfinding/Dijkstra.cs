using DijkstrasAlgorithm.GraphAdt;
using DijkstrasAlgorithm.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DijkstrasAlgorithm.Pathfinding
{
    public class Dijkstra
    {
        private readonly Graph<City, Highway> _graph;
        private readonly double[] _distances;
        private readonly int[] _predecessors;
        private City[] _cities;

        public Dijkstra(Graph<City, Highway> graph)
        {
            _graph = graph;
            var numberOfVertexes = graph.AllVertices.Length;

            _distances = new double[numberOfVertexes];
            _predecessors = new int[numberOfVertexes];

            Array.Fill(_distances, -1.0);
            Array.Fill(_predecessors, -1);
        }

        public string ShortestPath(string originName, string destinationName)
        {
            _cities = _graph.AllVertices;

            var origin = _cities.Single(city => city.Name.Equals(originName));
            var originIndex = Array.IndexOf(_cities, origin);

            var destination = _cities.Single(city => city.Name.Equals(destinationName));
            var destinationIndex = Array.IndexOf(_cities, destination);

            var highways = _graph.Edges(origin);
            _distances[0] = 0;
            int i = 0;
            foreach (var highway in highways)
            {
                foreach (var name in this._cities)
                {
                    
                }
            }
            return string.Empty;
        }
    }
}
