using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphicsTheory
{
    public class StronglyConnectedGraphs : VertexManager
    {
        public int Count
        {
            get
            {
                return scvertices.Count;
            }
        }

        public StronglyConnectedGraphs(VertexManager source)
            : base(source)
        {
            scvertices = new LinkedList<SCVertex>();
            scedges = new LinkedList<Edge>();

            this.source = source;
            maxID = 1;

            var stack = source.DepthFirstSearch();
            source.UnmarkAll();
            source.Transpose();
            while (stack.Count > 0)
            {
                Vertex v = null;
                while (stack.Count > 0 && (v != null ? v.Mark : true))
                {
                    v = stack.Pop();
                } 

                if (v != null && !v.Mark)
                {
                    Stack<Vertex> r = source.DepthFirstSearch(v);
                    CreateSCVertex(r);
                }
            }

            source.Transpose();
            UpdateEdges();
        }

        new public void DescribeAllVertices()
        {
            foreach (SCVertex v in scvertices)
            {
                Console.WriteLine("Vertex " + v.GetID() + "'s name is " + v.GetLabel());
                Console.WriteLine("It is composed of " + v.ComponentListToString());
                Console.WriteLine("It has " + v.ConnexionCount() + " connexion(s) :");
                foreach (Edge e in v.GetEdges())
                {
                    Console.WriteLine("to vertex " + e.Destination.GetID());
                }
            }
        }

        public void CreateSCVertex(LinkedList<Vertex> listvertices)
        {
            scvertices.AddLast(new SCVertex(maxID, listvertices));
            ++maxID;
        }

        public void CreateSCVertex(Stack<Vertex> stackvertices)
        {
            LinkedList<Vertex> vertices = new LinkedList<Vertex>(stackvertices);
            scvertices.AddLast(new SCVertex(maxID, vertices));
            ++maxID;
        }

        public LinkedList<Vertex> ComputeLongestPast()
        {
            return ComputeLongestPast(scvertices.First.Value, scvertices.Last.Value);
        }

        new public LinkedList<Vertex> ComputeLongestPast(Vertex a, Vertex b)
        {
            Dictionary<Vertex, int> lengthList = new Dictionary<Vertex, int>();
            bool modify = true;

            foreach (Vertex v in scvertices)
            {
                lengthList.Add(v, int.MaxValue);
            }
            lengthList[a] = 0;

            while (modify)
            {
                modify = false;
                foreach (Vertex v in scvertices)
                {
                    if (lengthList[v] < int.MaxValue)
                    {
                        foreach (Vertex u in v.GetChildren())
                        {
                            if (lengthList[u] > lengthList[v] + 1)
                            {
                                lengthList[u] = lengthList[v] + 1;
                                modify = true;
                            }
                        }
                    }
                }
            }


            Vertex current = b;
            LinkedList<Vertex> result = new LinkedList<Vertex>();
            do
            {
                var parents = GetParents(current);
                Vertex max = null;

                result.AddFirst(current);
                foreach (Vertex p in parents)
                {
                    if (max == null)
                        max = p;
                    else if (lengthList[max] < lengthList[p])
                        max = p;
                }
                current = max;
            } while (current != a);

            result.AddFirst(a);
            return result;
        }

        new public LinkedList<Vertex> GetParents(Vertex v)
        {
            LinkedList<Vertex> result = new LinkedList<Vertex>();

            foreach (Edge e in scedges)
            {
                if (e.GetVertex2() == v && !result.Contains(e.GetVertex1()))
                {
                    result.AddLast(e.GetVertex1());
                }
            }

            return result;
        }

        public void UpdateEdges()
        {
            foreach (Edge e in source.Edges)
            {
                var sc1 = GetSCVertexContainingVertex(e.Source);
                var sc2 = GetSCVertexContainingVertex(e.Destination);

                ConnectVertex(sc1, sc2);
            }
        }

        public SCVertex GetSCVertexContainingVertex(Vertex find)
        {
            foreach (SCVertex scv in scvertices)
            {
                foreach (Vertex v in scv.Components)
                {
                    if (v == find)
                    {
                        return scv;
                    }
                }
            }

            return null;
        }

        new public int[,] CreateAdjacencyMatrix()
        {
            int[,] matrice = new int[Count, Count];

            for (int i = 0; i < Count; ++i)
            {
                for (int j = 0; j < Count; ++j)
                {
                    Vertex v1 = GetVertexById(i + 1), v2 = GetVertexById(j + 1);
                    if (ConnectionExists(v1, v2))
                    {
                        matrice[i, j] = ConnectionNumber(v1, v2);
                    }
                    else
                    {
                        matrice[i, j] = 0;
                    }
                }
            }

            return matrice;
        }

        new public Vertex GetVertexById(int id)
        {
            foreach (Vertex v in scvertices)
            {
                if (v.GetID() == id)
                {
                    return v;
                }
            }

            Console.WriteLine("Unable to find vertex with id : " + id);
            return null;
        }

        public void DescribeGameLevel()
        {
            Console.WriteLine("There is " + scvertices.Count + " game level.");

            foreach (SCVertex v in scvertices)
            {
                Console.WriteLine("Lvl n°" + v.GetID());
                Console.WriteLine("Composed of : " + v.ComponentListToString());
                Console.Write("Connect to :");
                foreach (SCVertex k in v.GetNeightbourList())
                {
                    Console.Write(" " + k.GetID() + " ");
                }

                if (v.GetNeightbourList().Count == 0)
                {
                    Console.Write(" nothing.");
                }

                Console.WriteLine();
            }
        }

        public string GetLevelDescription()
        {
            string text = "";
            text = "There is " + scvertices.Count + " game level.\n";

            foreach (SCVertex v in scvertices)
            {
                text += "Lvl n°" + v.GetID() + "\n";
                text += "Composed of : " + v.ComponentListToString() + "\n";
                text += "Connect to :";
                foreach (SCVertex k in v.GetNeightbourList())
                {
                    text += " " + k.GetID() + " ";
                }

                if (v.GetNeightbourList().Count == 0)
                {
                    text += " nothing.";
                }

                text += "\n";
            }

            return text;
        }

        public void ConnectVertex(SCVertex source, SCVertex destination)
        {
            if (source == null || destination == null)
                return;

            if (source != destination)
            {
                scedges.AddLast(new Edge(source, destination));
            }
        }

        new public string ToString()
        {
            string s = "";

            foreach (SCVertex v in scvertices)
            {
                s += v.ToString();
                s += ((char)13);
            }

            return s;
        }

        private LinkedList<SCVertex> scvertices;
        private LinkedList<Edge> scedges;
        VertexManager source;
    }
}
