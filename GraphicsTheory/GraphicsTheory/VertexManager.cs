using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphicsTheory
{
    public class VertexManager
    {

        #region Constructors

        // Default constructor
        public VertexManager()
        {
            vertices = new LinkedList<Vertex>();
            edges = new LinkedList<Edge>();
            maxID = 1;
        }

        public VertexManager(LinkedList<Vertex> vertices, LinkedList<Edge> edges)
        {
            this.vertices = vertices;
            this.edges = edges;

            maxID = FindMaxID(vertices);
        }

        // Copy constructor
        public VertexManager(VertexManager cpy)
        {
            vertices = new LinkedList<Vertex>(cpy.vertices);
            edges = new LinkedList<Edge>(cpy.edges);
            maxID = cpy.maxID;
        }

        #endregion

        #region Properties

        public int Count
        {
            get
            {
                return vertices.Count;
            }
        }

        public LinkedList<Edge> InvertedEdges
        {
            get
            {
                LinkedList<Edge> result = new LinkedList<Edge>(edges);
                foreach (Edge e in result)
                {
                    Vertex temp = e.Source;
                    e.Source = e.Destination;
                    e.Destination = temp;
                }
                return result;
            }
        }
        public LinkedList<Edge> Edges
        {
            get
            {
                return edges;
            }
        }
        public LinkedList<Vertex> Vertices
        {
            get
            {
                return vertices;
            }
        }

        #endregion

        #region Methodes

        public void CreateVertex()
        {
            vertices.AddLast(new Vertex(maxID));
            ++maxID;
        }

        public void CreateVertex(string label)
        {
            vertices.AddLast(new Vertex(maxID, label));
            ++maxID;
        }

        public void ConnectVertex(int id1, int id2)
        {
            Vertex v1 = GetVertexById(id1);
            Vertex v2 = GetVertexById(id2);
            if (v1 == null || v2 == null)
            {
                Console.WriteLine("Unable to connect vertex with id " + id1 + " with vertex with id " + id2);
            }
            else
            {
                Edge edge = new Edge(v1, v2);
                edges.AddLast(edge);
            }
        }

        public Vertex GetVertexById(int id)
        {
            foreach (Vertex v in vertices)
            {
                if (v.GetID() == id)
                {
                    return v;
                }
            }

            Console.WriteLine("Unable to find vertex with id : " + id);
            return null;
        }

        public Vertex GetFirstVertexByName(string name)
        {
            var it = vertices.GetEnumerator();
            while (it.Current.GetLabel() != name && it.MoveNext()) ;
            return it.Current;
        }

        public LinkedList<Vertex> GetAllVerticesByName(string name)
        {
            LinkedList<Vertex> vertices = new LinkedList<Vertex>();
            foreach (Vertex v in this.vertices)
            {
                if (v.GetLabel() == name)
                {
                    vertices.AddLast(v);
                }
            }

            return vertices;
        }

        public void DescribeVertex(int id)
        {
            Vertex v = GetVertexById(id);
            if (v == null)
            {
                Console.WriteLine("Unable to find vertex " + id);
            }
            else
            {
                Console.WriteLine("Vertex " + v.GetID() + "'s name is " + v.GetLabel());
                Console.WriteLine("It has " + v.ConnexionCount() + " connexion(s) :");
                foreach (Vertex n in v.GetNeightbourList())
                {
                    Console.WriteLine("to vertex " + n.GetID());
                }
            }
        }

        public void DescribeVertex(Vertex v)
        {
            Console.WriteLine("Vertex " + v.GetID() + "'s name is " + v.GetLabel());
            Console.WriteLine("It has " + v.ConnexionCount() + " connexion(s) :");
            foreach (Vertex n in v.GetNeightbourList())
            {
                Console.WriteLine("to vertex " + n.GetID());
            }
        }

        public void DescribeAllVertices()
        {
            foreach (Vertex v in vertices)
            {
                DescribeVertex(v);
            }
        }

        public LinkedList<Vertex> GetParents(Vertex v)
        {
            LinkedList<Vertex> result = new LinkedList<Vertex>();

            foreach (Edge e in edges)
            {
                if (e.GetVertex2() == v && !result.Contains(e.GetVertex1()))
                {
                    result.AddLast(e.GetVertex1());
                }
            }

            return result;
        }

        public Path ComputeShortestPath(Vertex start, Vertex end)
        {
            return null;
        }

        public void LoadFromFile(string file)
        {
            string[] lines = System.IO.File.ReadAllLines(file);

            int nbVertices = int.Parse(lines[0]);
            int[,] matrice = ParseMatrice(lines, nbVertices);

            for (int i = 0; i < nbVertices; ++i)
            {
                CreateVertex();
            }

            for (int i = 1; i <= nbVertices; ++i)
            {
                for (int j = 1; j <= nbVertices; ++j)
                {
                    if (matrice[i-1, j-1] == 1)
                    {
                        ConnectVertex(i, j);
                    }
                }
            }
        }

        public int[,] ParseMatrice(string[] lines, int n)
        {
            int[,] result = new int[n, n];

            for (int i = 1; i < lines.Length; ++i)
            {
                int index = 0;
                int j = 0;
                while (index < lines[i].Length)
                {
                    if (lines[i][index] == ' ')
                    {
                    }
                    else if (lines[i][index] == '0')
                    {
                        result[i-1, j] = 0;
                        ++j;
                    }
                    else
                    {
                        result[i-1, j] = 1;
                        ++j;
                    }

                    ++index;
                }
            }

            return result;
        }

        public static int FindMaxID(LinkedList<Vertex> vertices)
        {
            int max = 0;
            foreach (Vertex v in vertices)
            {
                if (v.GetID() > max)
                    max = v.GetID();
            }

            return max;
        }

        public void UnmarkAll()
        {
            foreach (Vertex v in vertices)
            {
                v.Mark = false;
            }
        }

        public static void UnmarkAll(LinkedList<Vertex> vertices)
        {
            foreach (Vertex v in vertices)
            {
                v.Mark = false;
            }
        }

        public Stack<Vertex> DepthFirstSearch(bool post = true)
        {
            Stack<Vertex> result = new Stack<Vertex>();
            Vertex v = null;
            do 
            {
                v = GetUnmarkedVertex();
                if (v != null)
                    DFSRec(result, v, post);
            } while(v != null);
            return result;
        }
        public Stack<Vertex> DepthFirstSearch(Vertex v, bool post = true)
        {
            Stack<Vertex> result = new Stack<Vertex>();
            DFSRec(result, v, post);
            return result;
        }

        private void DFSRec(Stack<Vertex> stack, Vertex current, bool post)
        {
            if (stack == null || current == null)
            {
                Console.WriteLine("Error in DFSRec : stack or current is null reference");
            }
            else
            {
                current.Mark = true;
                if (!post)
                    stack.Push(current);
                foreach (Vertex v in current.GetChildren())
                {
                    if (!v.Mark)
                    {
                        DFSRec(stack, v, post);
                    }
                }

                if(post)
                    stack.Push(current);
            }
        }

        public bool IsContained(Stack<Vertex> stack)
        {
            foreach (Vertex v in vertices)
            {
                if (!stack.Contains(v))
                {
                    return false;
                }
            }

            return true;
        }

        public LinkedList<Vertex> ComputeLongestPast(Vertex a, Vertex b)
        {
            Dictionary<Vertex, int> lengthList = new Dictionary<Vertex, int>();
            bool modify = true;
            
            foreach (Vertex v in vertices)
            {
                lengthList.Add(v, int.MaxValue);
            }
            lengthList[a] = 0;

            while (modify)
            {
                modify = false;
                foreach (Vertex v in vertices)
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

        public Vertex GetVertexNotInStack(Stack<Vertex> stack)
        {
            foreach (Vertex v in vertices)
            {
                if (!stack.Contains(v))
                {
                    return v;
                }
            }

            return null;
        }

        public Vertex GetUnmarkedVertex()
        {
            foreach (Vertex v in vertices)
            {
                if (v.Mark == false)
                    return v;
            }

            return null;
        }

        public void Transpose()
        {
            VertexManager.Transpose(vertices, edges);
        }

        public static void Transpose(LinkedList<Vertex> vertices, LinkedList<Edge> edges)
        {
            foreach (Vertex v in vertices)
                v.DeleteAllEdges();

            edges = InvertEdges(vertices, edges);
            foreach (Edge e in edges)
            {
                e.GetVertex1().AddEdge(e);
            }
        }

        private static LinkedList<Edge> InvertEdges(LinkedList<Vertex> vertices, LinkedList<Edge> edges)
        {
            LinkedList<Edge> result = new LinkedList<Edge>(edges);
            foreach (Edge e in result)
            {
                Vertex temp = e.Source;
                e.Source = e.Destination;
                e.Destination = temp;
            }
            return result;
        }

        public LinkedList<LinkedList<Vertex>> CreateAdjacencyList()
        {
            LinkedList<LinkedList<Vertex>> result = new LinkedList<LinkedList<Vertex>>();

            foreach (Vertex v in vertices)
            {
                result.AddLast(new LinkedList<Vertex>());
                CreateAdjacencyListRecursive(result.Last.Value, v);
            }

            return result;
        }
        public void CreateAdjacencyListRecursive(LinkedList<Vertex> list, Vertex current)
        {
            list.AddLast(current);
            foreach (Vertex v in current.GetChildren())
            {
                CreateAdjacencyListRecursive(list, v);
            }
        }

        public int[,] CreateAdjacencyMatrix()
        {
            int[,] matrice = new int[vertices.Count, vertices.Count];

            for (int i = 0; i < vertices.Count; ++i)
            {
                for (int j = 0; j < vertices.Count; ++j)
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

        public int ConnectionNumber(Vertex v1, Vertex v2)
        {
            int i = 0;
            foreach (Edge e in v1.GetEdges())
            {
                if (e.Destination == v2)
                {
                    ++i;
                }
            }

            return i;
        }

        public bool ConnectionExists(Vertex v1, Vertex v2)
        {
            var neightbour = v1.GetNeightbourList();
            foreach (Vertex v in neightbour)
            {
                if (v.GetID() == v2.GetID())
                    return true;
            }

            return false;
        }

        public void ExportAdjacencyMatrix(string file)
        {
            var matrice = CreateAdjacencyMatrix();
            string text = ""+vertices.Count+((char)13);

            for (int i = 0; i < vertices.Count; ++i)
            {
                for (int j = 0; j < vertices.Count; ++j)
                {
                    text += matrice[i, j] + " ";
                }
                if(i<vertices.Count-1)
                    text += ((char)13);
            }

            file += "/export.txt";

            System.IO.File.WriteAllText(@file, text);

        }

        new public string ToString()
        {
            string s = "";

            foreach (Vertex v in vertices)
            {
                s += v.ToString();
                s += ((char)13);
            }

            return s;
        }

        #endregion

        #region Attributes
        protected int maxID;
        protected LinkedList<Vertex> vertices;
        protected LinkedList<Edge> edges;
        #endregion
    }
}
