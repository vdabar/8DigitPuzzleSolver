using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialInteligenceFirst
{
    class IDFS:SearchAlgorithms
    {
        public Stack<GraphNode> nodeStack = new Stack<GraphNode>();
        public Dictionary<string, int> visitedList = new Dictionary<string, int>();
        GraphNode startNode;
        bool odd;
        public IDFS(GraphNode correctNode, GraphNode startNode)
        {
            correctMatrix = correctNode.NumbersArray;
            this.startNode = startNode;        
            odd = (checkIfOdd(correctMatrix) == checkIfOdd(startNode.NumbersArray)) ? true : false;

        }

        public bool Calculate(int limit)
        {
            visitedList.Add(startNode.NumbersArray, 0);
            nodeStack.Push(startNode);
            if (!odd)
            {
                Console.WriteLine("no solution");
                return false;
            }
            
            int counter = 0;
            while (nodeStack.Count > 0)
            {

                var item2 = nodeStack.Pop();
                if (item2.NumbersArray == correctMatrix)
                {
                    Console.WriteLine("Found");
                    PrintPath(item2);
                    return true;

                }
                counter++;
                
                    Move(item2, limit);
                   // Console.WriteLine(nodeStack.Count.ToString(), counter);
                
                
            }
            visitedList.Clear();
            return false;

            
        }

        public bool Move(GraphNode node, int limit)
        {
            for (int i = 0; i < 9; i++)
            {

                if ((node.NumbersArray[i] == '0') && node.nodesCount<limit)
                {

                    if (i != 2 && i != 5 && i != 8) { if (MoveRight(node, i)) return true; }
                    if (i != 0 && i != 3 && i != 6) { if (MoveLeft(node, i)) return true; }
                    if (i != 7 && i != 6 && i != 8) { if (MoveDown(node, i)) return true ; }
                    if (i != 0 && i != 1 && i != 2) { if (MoveUp(node, i)) return true ; }
                    return false;
                }

            }
            return false;
        }

        public override bool addNewNodeToGraph(string tempMatrix, GraphNode node)
        {
            int temp = visitedList.ContainsKey(tempMatrix) ? visitedList[tempMatrix] : -1;
            if (temp == -1)
            {
                visitedList.Add(tempMatrix, node.nodesCount);
                GraphNode newItem = new GraphNode(tempMatrix, node);             
                nodeStack.Push(node);
                nodeStack.Push(newItem);
                return true;
            }
            else if (temp > node.nodesCount)
            {
                visitedList[tempMatrix] = node.nodesCount;
                GraphNode newItem = new GraphNode(tempMatrix, node);
                nodeStack.Push(node);
                nodeStack.Push(newItem);
                return true;
            }

           
            return false;
        }
    }
}
