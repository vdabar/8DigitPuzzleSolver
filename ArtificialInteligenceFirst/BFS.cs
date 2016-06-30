using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialInteligenceFirst
{
    class BFS : SearchAlgorithms
    {

        public HashSet<string> visitedList = new HashSet<string>();
        public Queue<GraphNode> queue = new Queue<GraphNode>();
        bool odd;
        public BFS(GraphNode correctNode, GraphNode startNode)
        {
            correctMatrix = correctNode.NumbersArray;
            visitedList.Add(startNode.NumbersArray);
            queue.Enqueue(startNode);
            odd = (checkIfOdd(correctMatrix) == checkIfOdd(startNode.NumbersArray)) ? true : false;
        }

        public void Calculate()
        {
            if (!odd)
            {
                Console.WriteLine("no solution");
                return;
            }
            int counter = 0;
            while (queue.Count >0)
            {
                var item = queue.Dequeue();
                if (correctMatrix == item.NumbersArray)
                {
                    Console.WriteLine("Found");
                    PrintPath(item);
                    return;

                }
                counter++;
                Move(item);
                // printNode(item);
                //Console.WriteLine(counter);
            }
            
            Console.WriteLine("No solution");
            return;
        }
        public override bool addNewNodeToGraph(string tempMatrix, GraphNode node)
        {
            if (visitedList.Add(tempMatrix)) { 
            if ( !(node.NumbersArray==tempMatrix))
            {
                GraphNode newItem = new GraphNode(tempMatrix,node);
               
                queue.Enqueue(newItem);
                return true;
            }
            }
            return false;
        }
        private int calculateDepth(GraphNode node)
        {
            
                int counter = 0;
                while (node != null)
                {
                    node = node.backElement;
                    counter++;
                }
          
            return counter;
        }
        public void Move(GraphNode node)
        {
            for (int i = 0; i < 9; i++)
            {
                
                    if ((node.NumbersArray[i] == '0'))
                    {
                        if (i != 2 && i != 5 && i != 8) MoveRight(node, i);
                        if (i != 0 && i != 3 && i != 6) MoveLeft(node, i);
                        if (i != 7 && i != 6 && i != 8) MoveDown(node, i);
                        if (i != 0 && i != 1 && i != 2) MoveUp(node, i);
                        return;
                    }
                

            }
        }
        
    }
}
