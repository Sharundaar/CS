using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AG44
{
    class Vertex
    {
        private int id;
        private string name;
        private int height;

        private LinkedList<Edge> connection;


        public bool Marked { get; set; }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public void AddConnection(Edge newConnection)
        {
            if (newConnection != null)
            {
                connection.AddLast(newConnection);
            }
        }

        public Vertex(int id, string name, int height)
        {
            ID = id;
            Name = name;
            Height = height;
            Marked = false;

            connection = new LinkedList<Edge>();
        }

        public void ClearConnections()
        {
            connection.Clear();
        }


        public LinkedList<Edge> Connection
        {
            get
            {
                return connection;
            }
        }

        public override string ToString()
        {
            return Name + " (" + ID + ")";
        }
    }
}
