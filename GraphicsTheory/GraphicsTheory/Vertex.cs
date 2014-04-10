using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphicsTheory
{
    public class Vertex
    {

        public bool Mark { get; set; }
        public int ID
        {
            get
            {
                return id;
            }
        }

        public Vertex()
        {
            id = 0;
            label = "Default";
            edgesList = new LinkedList<Edge>();
        }

        public Vertex(int id)
        {
            this.id = id;
            label = "Default";
            edgesList = new LinkedList<Edge>();
        }

        public Vertex(int id, string label)
        {
            this.id = id;
            this.label = label;
            edgesList = new LinkedList<Edge>();
        }

        public string GetLabel()
        {
            return label;
        }

        public int GetID()
        {
            return id;
        }

        public void AddEdge(Edge edge)
        {
            edgesList.AddLast(edge);
        }

        public int ConnexionCount()
        {
            return edgesList.Count;
        }

        public LinkedList<Edge> GetEdges()
        {
            return edgesList;
        }

        public LinkedList<Vertex> GetNeightbourList()
        {
            LinkedList<Vertex> neightbourgs = new LinkedList<Vertex>();
            foreach (Edge e in edgesList)
            {
                if (e.GetVertex1() != this)
                {
                    neightbourgs.AddLast(e.GetVertex1());
                }
                else
                {
                    neightbourgs.AddLast(e.GetVertex2());
                }
            }
            return neightbourgs;
        }

        public LinkedList<Vertex> GetChildren()
        {
            LinkedList<Vertex> children = new LinkedList<Vertex>();

            foreach (Edge e in edgesList)
            {
                children.AddLast(e.GetVertex2());
            }

            return children;
        }

        public void DeleteAllEdges()
        {
            edgesList.Clear();
        }

        public string ToString()
        {
            string s = "";

            s = "Vertex n°" + id + ((char)13) + '\n' + "Connected to :" + ((char)13);
            foreach (Edge e in edgesList)
            {
                s += e.Destination.ID + " ";
            }

            if (edgesList.Count == 0)
            {
                s += "nothing";
            }

            return s;
        }

        public static bool operator<(Vertex v1, Vertex v2) {
            return v1.GetID() < v2.GetID();
        }

        public static bool operator >(Vertex v1, Vertex v2)
        {
            return v2.GetID() > v2.GetID();
        }

        protected int id;
        protected string label;
        protected LinkedList<Edge> edgesList;

        internal void RemoveEdge(Edge e)
        {
            edgesList.Remove(e);
        }
    }
}
