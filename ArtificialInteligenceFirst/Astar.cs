using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialInteligenceFirst
{
    class Astar : SearchAlgorithms
    {
        public HashSet<GraphNode> visitedList = new HashSet<GraphNode>();
        public Queue<GraphNode> queue = new Queue<GraphNode>();
        public HashSet<GraphNode> possibleMoves = new HashSet<GraphNode>();
        bool odd;
        public Astar(GraphNode correctNode, GraphNode startNode)
        {
            correctMatrix = correctNode.NumbersArray;           
            visitedList.Add(startNode);
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
            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                if (correctMatrix== item.NumbersArray)
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
            if(!visitedList.Any(x=> x.NumbersArray == tempMatrix)) { 
            possibleMoves.Add(new GraphNode(tempMatrix,node,correctMatrix));
            return true;
            }
            return false;
        }
        private void ActualMove()
        {
            var temp = possibleMoves.FirstOrDefault(x=>x.astar == (possibleMoves.Min(y => y.astar)));
            visitedList.Add(temp);
            queue.Enqueue(temp);
            possibleMoves.Remove(temp);
            
        }

        private int calculateDepth(GraphNode node)
        {

            int counter = 0;
            while (node != null)
            {
                node = node.backElement;
                counter++;
            }
            //Console.WriteLine(counter);
            return counter;
        }
           
        public void Move(GraphNode node)
        {
            for (int i = 0; i < 9; i++)
            {

                if ((node.NumbersArray[i] == '0') )
                {
                    if (i != 2 && i != 5 && i != 8) MoveRight(node, i);
                    if (i != 0 && i != 3 && i != 6) MoveLeft(node, i);
                    if (i != 7 && i != 6 && i != 8) MoveDown(node, i);
                    if (i != 0 && i != 1 && i != 2) MoveUp(node, i);
                    ActualMove();
                    return;
                }

            }
           
        }
    }
}
