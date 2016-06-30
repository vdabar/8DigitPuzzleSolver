using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialInteligenceFirst
{
    abstract class SearchAlgorithms
    {

        
        public string startMatrix;
        public string correctMatrix = "123804765";
     
        public void PrintPath(GraphNode node)
        {
            int counter = 0;
            while (node != null)
            {
                printNode(node);
                node = node.backElement;
                counter++;
            }
            Console.WriteLine("Total nodes: " + counter);
            return;
        }
        public void printNode(GraphNode node)
        {
            int c = 0;
            for (int i = 0; i < 9; i++)
            {

                    Console.Write(node.NumbersArray[i] + " ");
                if (c==2)
                {
                    Console.WriteLine();
                    c = 0;
                }         
                    else
                {
                    c++;
                } 
              
            }
            Console.WriteLine();
            return;
        }

        public bool compareArrays(int[,] arrayA, int[,] arrayB)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (arrayA[i, j] != arrayB[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool MoveUp(GraphNode node, int index)
        {
            
            char[] matrix = node.GetNodeMatrix().ToCharArray();
            char temp = matrix[index];
            matrix[index] = matrix[index - 3];
            matrix[index - 3] = temp;
            string tempString = new string(matrix);
            if (addNewNodeToGraph(tempString, node)) return true;
            return false;

        }

        public bool MoveDown(GraphNode node, int index)
        {
            char[] matrix = node.GetNodeMatrix().ToCharArray();
            char temp = matrix[index];
            matrix[index] = matrix[index + 3];
            matrix[index + 3] = temp;
            string tempString = new string(matrix);
            if (addNewNodeToGraph(tempString, node)) return true;
            return false;

        }
        public bool MoveLeft(GraphNode node, int index)
        {
            char[] matrix = node.GetNodeMatrix().ToCharArray();
            char temp = matrix[index];
            matrix[index] = matrix[index - 1];
            matrix[index - 1] = temp;
            string tempString = new string(matrix);
            if (addNewNodeToGraph(tempString, node)) return true;
            return false;
        }

        public bool MoveRight(GraphNode node, int index)
        {
            char[] matrix = node.GetNodeMatrix().ToCharArray();
            char temp = matrix[index];
            matrix[index] = matrix[index +1];
            matrix[index + 1] = temp;
            string tempString = new string(matrix);
            if (addNewNodeToGraph(tempString, node)) return true;
            return false;
        }
        public bool checkIfOdd(string matrix)
        {
            
            int counter = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = i; j < 9; j++)
                {
                    if (((int)Char.GetNumericValue(matrix[i])> (int)Char.GetNumericValue(matrix[j])) && (matrix[j]!='0') && (matrix[i] != '0'))
                    {
                        counter++;
                    }
                }
            }
            return counter % 2 == 0 ? true : false;
        }
        public abstract bool addNewNodeToGraph(string tempMatrix, GraphNode node);
        

       
    }
}