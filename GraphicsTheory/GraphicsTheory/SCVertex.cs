using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphicsTheory
{
    public class SCVertex : Vertex
    {
        public SCVertex()
            : base()
        {
            components = new LinkedList<Vertex>();
        }

        public SCVertex(int id)
            : base(id)
        {
            components = new LinkedList<Vertex>();
        }

        public SCVertex(int id, LinkedList<Vertex> vertices)
            : base(id)
        {
            components = vertices;
        }

        public SCVertex(int id, string label)
            : base(id, label)
        {
            components = new LinkedList<Vertex>();
        }

        new public string ToString()
        {
            string s = "";

            s = "Vertex n°" + id + "\nComposed of : \n{ ";

            foreach (Vertex v in components)
            {
                s+=v.ID+" ";
            }
            s += "}\nConnected to :\n";

            if (edgesList.Count == 0)
            {
                s += "nothing";
            }
            else
            {
                foreach (Edge e in edgesList)
                {
                    if (e.Destination != null)
                        s += e.Destination.ID + " ";
                }
            }

            return s;
        }

        public LinkedList<Vertex> components;

        internal string ComponentListToString()
        {
            string result = "{ ";

            foreach (Vertex v in components)
            {
                result += v.GetID() + " ";
            }

            result += "}";
            return result;
        }

        public LinkedList<Vertex> Components
        {
            get
            {
                return components;
            }

            set
            {
                components = value;
            }
        }
    }
}
