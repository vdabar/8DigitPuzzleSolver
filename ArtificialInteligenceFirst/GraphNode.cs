using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialInteligenceFirst
{
    class GraphNode
    {
        public String NumbersArray;
        public List<GraphNode> neighbours = new List<GraphNode>();
        public GraphNode backElement ;
        public int nodesCount;
        public int manhatanDistance;
        public String correctMatrix = "123804765";
        public int astar;

        public GraphNode(String numbersArray, GraphNode node)
        {
            this.NumbersArray = numbersArray;
            this.backElement = node;
            this.nodesCount = countNodes();
            this.manhatanDistance = calculateManhatanDistance();
            astar = manhatanDistance + nodesCount;
            
        }
        public GraphNode(String numbersArray, GraphNode node, String correctMatrix)
        {
            this.correctMatrix = correctMatrix;
            this.NumbersArray = numbersArray;
            this.backElement = node;
            this.nodesCount = countNodes();
            this.manhatanDistance = calculateManhatanDistance();           
            astar = manhatanDistance + nodesCount;

        }
        private int calculateManhatanDistance()
        {
            int answer = 0;
            for (int x1 = 0; x1 < 9; x1++)
            {
                    if (NumbersArray[x1] != 0)
                    {
                        for (int x2 = 0; x2 < 9; x2++)
                        {

                        if (NumbersArray[x1] == correctMatrix[x2])
                        {
                            answer += CordinatesSum(x1,x2);
                                                }

  
                        }
                    }
                
            }
            return answer;
        }
        private int CordinatesSum(int i, int j)
        {
            int x=0, y = 0, x1 = 0, y1 = 0;
            if (i == 0 || i == 3 || i == 6) x = 0;
            if (i == 1 || i == 4 || i == 7) x = 1;
            if (i == 2 || i == 5 || i == 8) x = 2;
            if (i == 0 || i == 1 || i == 2) y = 0;
            if (i == 3 || i == 4 || i == 5) y = 1;
            if (i == 6 || i == 7 || i == 8) y = 2;
            if (j == 0 || j == 3 || j == 6) x1 = 0;
            if (j == 1 || j == 4 || j == 7) x1= 1;
            if (j == 2 || j == 5 || j == 8) x1 = 2;
            if (j == 0 || j == 1 || j == 2) y1 = 0;
            if (j == 3 || j == 4 || j == 5) y1 = 1;
            if (j == 6 || j == 7 || j == 8) y1 = 2;
            return Math.Abs(x - x1)+ Math.Abs(y- y1);

        }

        private int countNodes()
        {
            int counter = 0;
            var node = this;
            while (node != null)
            {
                node = node.backElement;
                counter++;
            }
            
            return counter;
        }
        public String GetNodeMatrix()
        {
            return NumbersArray;
        }
        

        
    }
}