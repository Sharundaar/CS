using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AG44
{
    public partial class Form1 : Form
    {
        Graph graph;
        LinkedList<EdgeType> authorizedList;

        public Form1()
        {
            InitializeComponent();
            graph = new Graph();
            authorizedList = new LinkedList<EdgeType>();
            authorizedList.AddLast(EdgeType.TK);
            authorizedList.AddLast(EdgeType.TS);
            authorizedList.AddLast(EdgeType.TSD);
            authorizedList.AddLast(EdgeType.TC);
            authorizedList.AddLast(EdgeType.BUS);
            authorizedList.AddLast(EdgeType.V);
            authorizedList.AddLast(EdgeType.B);
            authorizedList.AddLast(EdgeType.R);
            authorizedList.AddLast(EdgeType.N);
            authorizedList.AddLast(EdgeType.KL);
            authorizedList.AddLast(EdgeType.SURF);
            authorizedList.AddLast(EdgeType.TPH);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            graph.Reset();
            button4.Enabled = false;
            shortestButton.Enabled = false;
            reachableButton.Enabled = false;
            listButton.Enabled = false;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream myStream;
            string log;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = (FileStream)openFileDialog1.OpenFile()) != null)
                {
                    graph.Reset();
                    if (graph.ParseSkiDataFile(myStream.Name, out log))
                    {
                        reachableButton.Enabled = true;
                        button4.Enabled = true;

                        shortestButton.Enabled = true;
                        listButton.Enabled = true;
                    }
                    richTextBox1.Text = log;
                    myStream.Close();


                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void green_CheckedChanged(object sender, EventArgs e)
        {
            if (green.Checked)
                authorizedList.AddLast(EdgeType.V);
            else
                authorizedList.Remove(EdgeType.V);
        }

        private void blue_CheckedChanged(object sender, EventArgs e)
        {
            if (blue.Checked)
                authorizedList.AddLast(EdgeType.B);
            else
                authorizedList.Remove(EdgeType.B);
        }

        private void red_CheckedChanged(object sender, EventArgs e)
        {
            if (red.Checked)
                authorizedList.AddLast(EdgeType.R);
            else
                authorizedList.Remove(EdgeType.R);
        }

        private void black_CheckedChanged(object sender, EventArgs e)
        {
            if (black.Checked)
                authorizedList.AddLast(EdgeType.N);
            else
                authorizedList.Remove(EdgeType.N);
        }

        private void track_CheckedChanged(object sender, EventArgs e)
        {
            if (track.Checked)
                authorizedList.AddLast(EdgeType.KL);
            else
                authorizedList.Remove(EdgeType.KL);
        }

        private void snow_CheckedChanged(object sender, EventArgs e)
        {
            if (snow.Checked)
                authorizedList.AddLast(EdgeType.SURF);
            else
                authorizedList.Remove(EdgeType.SURF);
        }

        private void tph_CheckedChanged(object sender, EventArgs e)
        {
            if (tph.Checked)
                authorizedList.AddLast(EdgeType.TPH);
            else
                authorizedList.Remove(EdgeType.TPH);
        }

        private void tc_CheckedChanged(object sender, EventArgs e)
        {
            if (tc.Checked)
                authorizedList.AddLast(EdgeType.TC);
            else
                authorizedList.Remove(EdgeType.TC);
        }

        private void tsd_CheckedChanged(object sender, EventArgs e)
        {
            if (tsd.Checked)
                authorizedList.AddLast(EdgeType.TSD);
            else
                authorizedList.Remove(EdgeType.TSD);
        }

        private void ts_CheckedChanged(object sender, EventArgs e)
        {
            if (ts.Checked)
                authorizedList.AddLast(EdgeType.TS);
            else
                authorizedList.Remove(EdgeType.TS);
        }

        private void tk_CheckedChanged(object sender, EventArgs e)
        {
            if (tk.Checked)
                authorizedList.AddLast(EdgeType.TK);
            else
                authorizedList.Remove(EdgeType.TK);
        }

        private void bus_CheckedChanged(object sender, EventArgs e)
        {
            if (bus.Checked)
                authorizedList.AddLast(EdgeType.BUS);
            else
                authorizedList.Remove(EdgeType.BUS);
        }

        private void shortestButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = graph.ShortestPathFW(startEdit.Text, endEdit.Text, authorizedList);
        }

        private void reachableButton_Click(object sender, EventArgs e)
        {
            // richTextBox1.Text = graph.GetReachablePoint(reachableEdit.Text, authorizedList);
            richTextBox1.Text = graph.GetReachableVertexWithShortestPath(reachableEdit.Text, authorizedList);
        }

        private void listButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = graph.ToString();
        }
    }
}
