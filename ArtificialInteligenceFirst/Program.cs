using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialInteligenceFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            
            GraphNode finalNode;
            Console.WriteLine("Start matrix:");
            var startNode = (new CreateNodeConsole()).GetNode();
            Console.WriteLine("Final matrix:");
            finalNode = (new CreateNodeConsole()).GetNode();
            while (true) {

                Console.WriteLine("1.DFS \n2.BFS\n3.IDFS\n4.A*\n5.Greedy\n6.New Start Matrix\n7.New Final Matrix");
                String caseSwitch = Console.ReadLine();
            switch (caseSwitch)
            {
                case "1":
                     
                        DFS dfs = new DFS(finalNode,startNode);
                        dfs.Calculate();
                        break;
                case "2":
                        
                        BFS bfs = new BFS(finalNode,startNode);
                        bfs.Calculate();
                        break;
                    case "3":
                     
                        
                        IDFS idfs = new IDFS(finalNode,startNode);
                        int i = 0;
                        while (!idfs.Calculate(i)) { i++; Console.WriteLine(i); }
                        
                        break;
                    case "4":
                        
                        Astar astar = new Astar(finalNode,startNode);
                        astar.Calculate();
                        break;
                    case "5":
                    
                        Greedy greedy = new Greedy(finalNode,startNode);
                        greedy.Calculate();
                        break;
                    case "6":
                        Console.WriteLine("Start matrix:");
                        startNode = (new CreateNodeConsole()).GetNode();                       
                        break;
                    case "7":
                        Console.WriteLine("Final matrix:");
                        finalNode = (new CreateNodeConsole()).GetNode();
                        break;
                    default:
                    Console.WriteLine("wrong number");
                    break;
            }
            }
        }
    }
}
