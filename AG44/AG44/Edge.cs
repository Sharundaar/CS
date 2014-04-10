using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AG44
{
    enum EdgeType
    {
        TK, TS, TSD, TC, BUS, V, B, R, N, KL, SURF, TPH,
        ERROR
    };

    class Edge
    {
        private Vertex source;
        private Vertex destination;
        private EdgeType type;
        private int id;
        private string name;
        private float time;

        public float Time
        {
            get { return time; }
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


        public EdgeType Type
        {
            get { return type; }
            set { type = value; }
        }


        public Vertex Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        public Vertex Source
        {
            get { return source; }
            set { source = value; }
        }

        public float Slope
        {
            get
            {
                return Math.Abs((Source.Height - Destination.Height));
            }
        }

        public Edge(Vertex source, Vertex destination, int id, string name, EdgeType type)
        {
            Source = source;
            Destination = destination;
            ID = id;
            Name = name;
            Type = type;

            time = GetTime();
        }
        
        public float GetTime()
        {
            switch (type)
            {
                case EdgeType.TK:
                case EdgeType.TS:
                    return (1f + 4f * Slope / 100f) * 60f;

                case EdgeType.TPH:
                    return (4f + 2f * Slope / 100f) * 60f;
                
                case EdgeType.TSD:
                    return (1f + 3f * Slope / 100f) * 60f;
                
                case EdgeType.TC:
                    return (2f + 3f * Slope / 100f) * 60f;
                
                case EdgeType.BUS:
                    if (name.Contains("1800"))
                        return 60f * 30f;
                    else if (name.Contains("2000"))
                        return 60f * 40f;
                    else
                        return -1f;

                case EdgeType.V:
                    return 60f * 5f * Slope / 100f;

                case EdgeType.B:
                    return 60f * 4f * Slope / 100f;

                case EdgeType.R:
                    return 60f * 3f * Slope / 100f;

                case EdgeType.N:
                    return 60f * 2f * Slope / 100f;

                case EdgeType.KL:
                    return 10f * Slope / 100f;

                case EdgeType.SURF:
                    return 600f * Slope / 100f;
                default:
                    return -1f;
            }
        }

        public void Clean()
        {
            source = null;
            destination = null;
        }

        public static bool ParseType(string type, out EdgeType result)
        {
            switch (type)
            {
                case "TPH":
                    result = EdgeType.TPH;
                    break;

                case "TK":
                    result = EdgeType.TK;
                    break;

                case "TS":
                    result = EdgeType.TS;
                    break;

                case "TSD":
                    result = EdgeType.TSD;
                    break;

                case "TC":
                    result = EdgeType.TC;
                    break;

                case "BUS":
                    result = EdgeType.BUS;
                    break;

                case "V":
                    result = EdgeType.V;
                    break;

                case "B":
                    result = EdgeType.B;
                    break;

                case "R":
                    result = EdgeType.R;
                    break;

                case "N":
                    result = EdgeType.N;
                    break;

                case "KL":
                    result = EdgeType.KL;
                    break;

                case "SURF":
                    result = EdgeType.SURF;
                    break;

                default:
                    result = EdgeType.ERROR;
                    return false;
            }

            return true;
        }

        public override string ToString()
        {
            return Name + " (" + ID + ")";
        }
    }
}
