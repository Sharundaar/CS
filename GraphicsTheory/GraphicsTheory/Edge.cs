using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphicsTheory
{
    public class Edge
    {
        public bool Enabled { get; set; }
        public float Weigth { get; set; }

        public Vertex Source
        {
            get
            {
                return vertex1;
            }

            set
            {
                vertex1 = value;
            }
        }

        public Vertex Destination
        {
            get
            {
                return vertex2;
            }

            set
            {
                vertex2 = value;
            }
        }

        public Edge(Vertex v1, Vertex v2, float weigth = 1.0f)
        {
            vertex1 = v1;
            vertex2 = v2;

            Weigth = weigth;
            Enabled = true;

            vertex1.AddEdge(this);
        }

        public Vertex GetVertex1()
        {
            return vertex1;
        }

        public Vertex GetVertex2()
        {
            return vertex2;
        }

        Vertex vertex1;
        Vertex vertex2;
    }
}
