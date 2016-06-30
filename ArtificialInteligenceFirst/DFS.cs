using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialInteligenceFirst
{
    class DFS:SearchAlgorithms
    {

        public Stack<GraphNode> nodeStack = new Stack<GraphNode>();
        public HashSet<string> visitedList = new HashSet<string>();
        bool odd;
        public DFS(GraphNode correctNode, GraphNode startNode)
        { 
            correctMatrix = correctNode.NumbersArray;
            visitedList.Add(startNode.NumbersArray);
            nodeStack.Push(startNode);
            odd = (checkIfOdd(correctMatrix) == checkIfOdd(startNode.NumbersArray)) ? true : false;

        }

        public void Calculate()
        {
            if (!odd)
            {
                Console.WriteLine("no solution");
                return;
            }
            while (nodeStack.Count>0)
            {    
                var item = nodeStack.Pop();
                if (correctMatrix == item.NumbersArray)
                {
                    Console.WriteLine("Found");
                    PrintPath(item);
                    return;
                    
                }
                // if (nodeStack.Count < 24) 
                Move(item);             
                //Console.WriteLine(nodeStack.Count); 
            }
         
            Console.WriteLine("No solution");
            return;
        }
       
        public void Move(GraphNode node)
        {
            for (int i = 0; i < 9; i++)
            {
                
                    if ((node.NumbersArray[i] == '0'))
                    {

                    if (i != 2 && i != 5 && i != 8) { if (MoveRight(node, i)) return; } 
                    if (i != 0 && i != 3 && i != 6) { if (MoveLeft(node, i)) return; } 
                    if (i != 7 && i != 6 && i != 8) { if (MoveDown(node, i)) return; }
                    if (i != 0 && i != 1 && i != 2) { if (MoveUp(node, i)) return; } 
                        return;
                    }
                
            }
            return;
        }

        public override bool addNewNodeToGraph(String tempMatrix, GraphNode node)
        {
           
            if ((visitedList.Add(tempMatrix)) )
            {
                
                GraphNode newItem = new GraphNode(tempMatrix,node);              
                nodeStack.Push(node);
                nodeStack.Push(newItem);
                return true;
            }
            //else if ((temp.nodesCount > nodeStack.Count))
            //{
            //    GraphNode newItem = new GraphNode(tempMatrix, node);
            //    visitedList.Add(newItem);
            //    nodeStack.Push(node);
            //    nodeStack.Push(newItem);
            //    visitedList.Remove(temp);
            //    return true;
            //}
            return false;
        }
    }
}
