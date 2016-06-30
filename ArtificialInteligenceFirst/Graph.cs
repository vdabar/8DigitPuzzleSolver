using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialInteligenceFirst
{
    class Graph
    {
        GraphNode nodea;
        public GraphNode ElementA;
        private List<GraphNode> nodeList = new List<GraphNode>();

        public void addNode(GraphNode node)
        {
            nodeList.Add(node);
        }
        public void addNode(int[,] node)
        {
        }
        public void addEdge(GraphNode from, GraphNode to)
        {
            //from.neighbours.Add(to);
            to.backElement = from;
        }
    }
}