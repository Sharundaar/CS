using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AG44
{
    class Graph
    {
        private LinkedList<Vertex> vertices;
        private LinkedList<Edge> edges;
        private int maxID;

        public float[,] GetAdgacencyMatrix()
        {
            int size = vertices.Count;
            float[,] matrix = new float[size, size];

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = float.PositiveInfinity;
                }

                matrix[i, i] = 0;
            }

            foreach (Edge e in edges)
            {
                if (e.Destination != null && e.Source != null)
                {
                    matrix[e.Source.ID - 1, e.Destination.ID - 1] = Math.Min(matrix[e.Source.ID - 1, e.Destination.ID - 1], e.GetTime());
                }
            }

            return matrix;
        }

        public float[,] GetAdgacencyMatrix(LinkedList<EdgeType> authorizedLevel)
        {
            int size = vertices.Count;
            float[,] matrix = new float[size, size];

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = float.PositiveInfinity;
                }

                matrix[i, i] = 0;
            }

            foreach (Edge e in edges)
            {
                if (authorizedLevel.Contains(e.Type))
                {
                    if (e.Destination != null && e.Source != null)
                    {
                        matrix[e.Source.ID - 1, e.Destination.ID - 1] = Math.Min(matrix[e.Source.ID - 1, e.Destination.ID - 1], e.GetTime());
                    }
                }
            }

            return matrix;
        }

        public float[,] FloydWarshall(out int[,] next, LinkedList<EdgeType> authorizedLevel)
        {
            float[,] matrix = GetAdgacencyMatrix(authorizedLevel);
            int size = vertices.Count;
            next = new int[size, size];

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    if (i != j && matrix[i, j] < float.PositiveInfinity)
                    {
                        next[i, j] = i + 1;
                    }
                    else
                    {
                        next[i, j] = 0;
                    }
                }
            }

            for (int k = 0; k < size; ++k)
            {
                for (int i = 0; i < size; ++i)
                {
                    for (int j = 0; j < size; ++j)
                    {
                        if (matrix[i, k] + matrix[k, j] < matrix[i, j])
                        {
                            matrix[i, j] = matrix[i, k] + matrix[k, j];
                            next[i, j] = next[k, j];
                        }
                    }
                }
            }

            return matrix;
        }

        public void Dijkstra(Vertex start)
        {

        }

        public Edge GetFastestEdge(Vertex v1, Vertex v2, LinkedList<EdgeType> authorizedLevel)
        {
            if (v1 != null && v2 != null)
            {
                Edge min = null;

                foreach (Edge e in v1.Connection)
                {
                    if (e.Source == v1 && e.Destination == v2 && authorizedLevel.Contains(e.Type))
                    {
                        if (min == null)
                        {
                            min = e;
                        }
                        else if (min.GetTime() > e.GetTime())
                        {
                            min = e;
                        }
                    }
                }

                return min;
            }
            else
            {
                return null;
            }

        }

        public string ShortestPathFW(string source, string destination, LinkedList<EdgeType> authorizedLevel)
        {
            Vertex s = FindName(source);
            Vertex d = FindName(destination);

            if (s == null)
            {
                return "Unable to find " + s + '\n';
            }
            else if (d == null)
            {
                return "Unable to find " + d + '\n';
            }
            else
            {
                return ShortestPathFW(s.ID, d.ID, authorizedLevel);
            }
        }

        public string ShortestPathFW(int source, int destination, LinkedList<EdgeType> authorizedLevel)
        {
            string result = "";

            LinkedList<Vertex> path;
            if (!ShortestPathFW(source, destination, out path, authorizedLevel))
            {
                return "No path exists between " + GetVertex(source) + " and " + GetVertex(destination) + '\n';
            }
            else
            {
                Vertex previous = null;
                float length = 0f;

                foreach (Vertex v in path)
                {
                    Edge e;
                    if (v.ID == source)
                    {
                        result += "Starting from " + v + '\n';
                    }
                    else if (v.ID == destination)
                    {
                        e = GetFastestEdge(previous, v, authorizedLevel);
                        result += "Arriving at " + v + " by " + e + '\n';
                        length += e.GetTime();
                    }
                    else
                    {
                        e = GetFastestEdge(previous, v, authorizedLevel);
                        result += "Go to " + v + " by " + e + '\n';
                        length += e.GetTime();
                    }

                    previous = v;
                }

                float h = (float) Math.Floor(length / 3600f);
                float m = (float)Math.Floor(length / 60f) - h * 60f;
                float s = (float)Math.Floor(length - m * 60f - h * 3600f);

                result += "Duration : " + h + "h" + m + "m" + s + "s\n"; 
            }

            return result;
        }

        public string GetReachableVertexWithShortestPath(string start, LinkedList<EdgeType> authorizedLevel)
        {
            Vertex s = FindName(start);

            if (s == null)
                return "Unable to find vertex " + start;

            Dictionary<Vertex, float> dijkstra;
            Dijkstra(s, authorizedLevel, out dijkstra);
            string result = "Starting at " + s.Name + ", you can reach {ReachableVertexCount} vertices:\n";
            int Count = 0;
            foreach (Vertex v in vertices)
            {
                if (v != s && !float.IsInfinity(dijkstra[v]))
                {
                    float length = dijkstra[v];
                    float h = (float)Math.Floor(length / 3600f);
                    float m = (float)Math.Floor(length / 60f) - h * 60f;
                    float sec = (float)Math.Floor(length - m * 60f - h * 3600f);
                    
                    result += v.Name + " (" + v.ID + ") in "+ h + "h"+m+"m"+sec+"s\n";
                    
                    ++Count;
                }
            }

            result = result.Replace("{ReachableVertexCount}", "" + Count);

            if (Count == 0)
                result += "\tnothing";


            return result;
        }

        public bool Dijkstra(Vertex start, LinkedList<EdgeType> authorizedLevel, out Dictionary<Vertex, float> result)
        {
            result = new Dictionary<Vertex, float>();
            LinkedList<Vertex> list = new LinkedList<Vertex>();

            /* Initialisation */
            foreach (Vertex v in vertices)
            {
                if (v == start)
                {
                    result.Add(v, 0f);
                }
                else
                {
                    result.Add(v, float.PositiveInfinity);
                }
                list.AddLast(v);
            }

            while (list.Count > 0)
            {
                Vertex current = GetClosestVertex(list, result);
                list.Remove(current);
                foreach (Edge e in current.Connection)
                {
                    if (authorizedLevel.Contains(e.Type))
                    {
                        if (e.Time + result[current] < result[e.Destination])
                        {
                            result[e.Destination] = e.Time + result[current];
                        }
                    }
                }
            }
            

            return true;
        }

        private Vertex GetClosestVertex(LinkedList<Vertex> list, Dictionary<Vertex, float> dico)
        {
            Vertex result = null;
            foreach (Vertex v in list)
            {
                if (result == null)
                    result = v;
                else
                {
                    if (dico[v] < dico[result])
                        result = v;
                }
            }

            return result;
        }

        public Stack<Edge> DeleteEdges(EdgeType type)
        {
            Stack<Edge> result = new Stack<Edge>();

            foreach (Edge e in edges.Where<Edge>(e => e.Type == type))
            {
                result.Push(e);
                edges.Remove(e);
            }

            return result;
        }

        public void RestoreGraph(Stack<Edge> stack)
        {
            Edge edge;

            while ((edge = stack.Pop()) != null)
            {
                edges.AddLast(edge);
                edge.Source.AddConnection(edge);
            }
        }

        public bool ShortestPathFW(int sourceid, int destid, out LinkedList<Vertex> result, LinkedList<EdgeType> authorizedLevel)
        {
            result = new LinkedList<Vertex>();
            LinkedList<int> idList = new LinkedList<int>();
            
            float[,] dist;
            int[,] next;

            dist = FloydWarshall(out next, authorizedLevel);
            if (float.IsInfinity(dist[sourceid - 1, destid - 1]))
            {
                return false;
            }
            else
            {
                string path = PathRetrieving(sourceid, destid, dist, next);
                string[] split = path.Split(' ');
                foreach (string s in split)
                {
                    int i;
                    if (int.TryParse(s, out i))
                    {
                        result.AddLast(GetVertex(i));
                    }
                }

                result.AddFirst(GetVertex(sourceid));
                result.AddLast(GetVertex(destid));

                return true;
            }
        }

        public string PathRetrieving(int sourceid, int destid, float[,] dist, int[,] next) 
        {
            int sourceindex = sourceid - 1, destindex = destid - 1;

            var intermediate = next[sourceindex, destindex];
            if (intermediate == 0 || intermediate == sourceid || intermediate == destid)
            {
                return " ";
            }
            else
            {
                return PathRetrieving(sourceid, intermediate, dist, next) + intermediate + PathRetrieving(intermediate, destid, dist, next);
            }
        }

        private LinkedList<Vertex> GetReachablePoint(Vertex start, LinkedList<EdgeType> authorizedLvl)
        {
            if (start != null && !start.Marked)
            {
                LinkedList<Vertex> result = new LinkedList<Vertex>();
                result.AddLast(start);
                start.Marked = true;
                foreach (Edge e in start.Connection)
                {
                    if (authorizedLvl.Contains(e.Type))
                    {
                        LinkedList<Vertex> c = GetReachablePoint(e.Destination, authorizedLvl);
                        if (c != null)
                        {
                            foreach (Vertex v in c)
                            {
                                result.AddLast(v);
                            }
                        }
                    }
                }
                return result;
            }

            return null;
        }

        public string GetReachablePoint(string start, LinkedList<EdgeType> authorizedLvl)
        {
            Vertex v = FindName(start);

            if (v == null)
            {
                return "Unable to find " + start;
            }

            return GetReachablePoint(v.ID, authorizedLvl);
        }
            
        public string GetReachablePoint(int start, LinkedList<EdgeType> authorizedLvl)
        {
            string result = "";
            if (start < 1 || GetVertex(start) == null)
            {
                return "Unable to find Vertex n°" + start;
            }

            foreach (Vertex v in vertices)
            {
                v.Marked = false;
            }

            LinkedList<Vertex> reach = GetReachablePoint(GetVertex(start), authorizedLvl);

            if (reach.Count == 1)
            {
                result += "Starting at " + reach.First.Value + " you can reach nothing.\n";
            }
            else
            {
                foreach (Vertex v in reach)
                {
                    if (v.ID == start)
                    {
                        result += "Starting at " + v + " you can reach " + (reach.Count - 1) + " points :\n";
                    }
                    else
                    {
                        result += "" + v + '\n';
                    }
                }
            }


            return result;
        }

        public Graph()
        {
            vertices = new LinkedList<Vertex>();
            edges = new LinkedList<Edge>();
            maxID = 1;
        }

        public bool CreateVertex(int id, string name, int height)
        {
            foreach (Vertex v in vertices)
            {
                if (v.ID == id)
                {
                    Console.WriteLine("A Vertex with the ID " + id + " already exists.");
                    return false;
                }
            }

            vertices.AddLast(new Vertex(id, name, height));
            if (id > maxID)
                maxID = id;
            return true;
        }

        public void CreateVertex(string name, int height)
        {
            ++maxID;
            CreateVertex(maxID, name, height);
        }

        public bool ConnectVertex(Vertex source, Vertex destination, int id, string name, EdgeType type)
        {
            if (source != null && destination != null)
            {
                foreach (Edge e in edges)
                {
                    if (e.ID == id)
                    {
                        Console.WriteLine("An Edge with the ID " + id + " already exists.");
                        return false;
                    }
                }

                Edge edge = new Edge(source, destination, id, name, type);
                edges.AddLast(edge);
                source.AddConnection(edge);

                return true;

            }

            return false;
        }

        public IEnumerable<Vertex> Find(Func<Vertex, bool> predicate) 
        {
            return vertices.Where<Vertex>(predicate);
        }

        public Vertex FindName(string name)
        {
            foreach (Vertex v in vertices)
            {
                if (v.Name.Contains(name))
                {
                    return v;
                }
            }

            return null;
        }

        public bool ParseSkiDataFile(string file, out string log)
        {
            /* Example of a data file :
             * 37
             * 1	villaroger	1200		
             * 2	2	1425		
             * 95
             * 1	aiguille-rouge	TPH	12	5
             */

            string[] data = System.IO.File.ReadAllLines(file);
            int nbVertices = 0;
            int nbEdges = 0;
            log = "";

            log += "Begin parsing of "+ file + '\n';

            if (!int.TryParse(data[0], out nbVertices))
            {
                log += "Unable to read the number of Vertices.\n";
                log += "Abort parsing.\n";
                Reset();
                return false;
            }

            for (int i = 1; i <= nbVertices; ++i)
            {
                int id, height;
                string name;

                string[] split = data[i].Split('\t');
                if (split.Length < 3)
                {
                    log += "Line : "+i+1+". Not enougth parameters to define a Vertex.\n";
                    log += "Abort parsing.\n";
                    Reset();
                    return false;
                }

                if (!int.TryParse(split[0], out id))
                {
                    log += "Line : "+i+1+". Unable to parse the ID.\n";
                    log += "Abort parsing.\n";
                    Reset();
                    return false;
                }

                name = split[1];

                if (!int.TryParse(split[2], out height))
                {
                    log += "Line : " + i+1 + ". Unable to parse the Height.\n";
                    log += "Abort parsing.\n";
                    Reset();
                    return false;
                }

                CreateVertex(id, name, height);
            }

            if (!int.TryParse(data[nbVertices + 1], out nbEdges))
            {
                log += "Unable to read the number of Edges.\n";
                log += "Abort parsing.\n";
                Reset();
                return false;
            }

            for (int i = nbVertices + 2; i < data.Length; ++i)
            {
                int id, source, destination;
                string name;
                EdgeType type;

                string[] split = data[i].Split('\t');
                if (split.Length < 5)
                {
                    log += "Line : " + i+1 + ". Not enougth parameters to define an Edge.\n";
                    log += "Abort parsing.\n";
                    Reset();
                    return false;
                }

                if (!int.TryParse(split[0], out id))
                {
                    log += "Line : " + i+1 + ". Unable to parse the ID.\n";
                    log += "Abort parsing.\n";
                    Reset();
                    return false;
                }

                name = split[1];

                if (!Edge.ParseType(split[2], out type))
                {
                    log += "Line : " + i + ". Unable to parse the type.\n";
                    log += "Abort parsing.\n";
                    Reset();
                    return false;
                }

                if (!int.TryParse(split[3], out source))
                {
                    log += "Line : " + i+1 + ". Unable to parse the source.\n";
                    log += "Abort parsing.\n";
                    Reset();
                    return false;
                }

                if (!int.TryParse(split[4], out destination))
                {
                    log += "Line : " + i + ". Unable to parse the destination.\n";
                    log += "Abort parsing.\n";
                    Reset();
                    return false;
                }

                ConnectVertex(source, destination, id, name, type);
            }

            log += nbVertices + " vertices created.\n";
            log += nbEdges+" edges created.\n";
            log += "Parsing complete.\n";    

            return true;
        }

        public void ConnectVertex(int source, int destination, int id, string name, EdgeType type)
        {
            ConnectVertex(GetVertex(source), GetVertex(destination), id, name, type);
        }

        public Vertex GetVertex(int id)
        {
            foreach (Vertex v in vertices)
            {
                if (v.ID == id)
                    return v;
            }

            return null;
        }

        public void Reset()
        {
            foreach (Edge e in edges)
            {
                e.Clean();
            }

            foreach (Vertex v in vertices)
            {
                v.ClearConnections();
            }

            vertices.Clear();
            edges.Clear();

        }

        public override string ToString()
        {
            string result = "";

            result += "This graph is composed of :\n";
            result += vertices.Count + " Vertices.\n";
            result += edges.Count + " Edges.\n\n";
            result += "Vertices list : \n";
            foreach (Vertex v in vertices)
            {
                result += "" + v + '\n';
            }

            result += "\nEdges list : \n";
            foreach(Edge e in edges)
            {
                result += "" + e + '\n';
            }

            return result;
        }

    }
}
