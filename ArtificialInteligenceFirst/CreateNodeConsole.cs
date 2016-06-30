using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialInteligenceFirst
{
    class CreateNodeConsole
    {

        public GraphNode GetNode()
        {
            Console.WriteLine("Insert matrix numbers");
            String matrix = "";
            for (int i = 0; i < 9; i++)
            {
                
                    string input = Console.ReadLine();
                    matrix += input;
                
            }

            return new GraphNode(matrix,null);
        }
    }
}