using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphicsTheory
{
    class Program
    {
        static void Main(string[] args)
        {
            VertexManager vm = new VertexManager();

            vm.LoadFromFile(@"C:\Users\Fireflown\Documents\Visual Studio 2010\Projects\CS\GraphicsTheory\mat3.txt");
            vm.DescribeAllVertices();

            Console.WriteLine("\n");

            StronglyConnectedGraphs SCC = new StronglyConnectedGraphs(vm);
            SCC.DescribeGameLevel();
            
 
            Console.Write("Press enter to continue...");
            Console.Read();

        }
    }
}
