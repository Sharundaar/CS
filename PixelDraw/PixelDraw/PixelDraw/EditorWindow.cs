using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PixelDraw
{
    public partial class EditorWindow : Form
    {
        private Editor XNAEditor;
        private Microsoft.Xna.Framework.Color currentColor;

        public EditorWindow()
        {
            InitializeComponent();
            Resize += new System.EventHandler(WinMain_Resize);
            currentColor = new Microsoft.Xna.Framework.Color(0, 0, 0);
        }

        private void WinMain_Resize(object sender, EventArgs e)
        {
            XNAEditor.graphics.PreferredBackBufferWidth = XNAView.Width;
            XNAEditor.graphics.PreferredBackBufferHeight = XNAView.Height;
            XNAEditor.graphics.ApplyChanges();
        }

        public IntPtr GetXNAView()
        {
            return XNAView.Handle;
        }

        internal void SetXNAEditor(Editor editor)
        {
            XNAEditor = editor;
        }

        internal Microsoft.Xna.Framework.Point GetXNAViewSize()
        {
            return new Microsoft.Xna.Framework.Point(XNAView.Size.Width, XNAView.Size.Height);
        }

        private void RedBar_ValueChanged(object sender, EventArgs e)
        {
            currentColor.R = (byte) RedBar.Value;
            UpdatePixelColor();
        }

        private void GreenBar_ValueChanged(object sender, EventArgs e)
        {
            currentColor.G = (byte)GreenBar.Value;
            UpdatePixelColor();
        }

        private void BlueBar_ValueChanged(object sender, EventArgs e)
        {
            currentColor.B = (byte)BlueBar.Value;
            UpdatePixelColor();
        }

        private void UpdatePixelColor()
        {
            PixelColor.BackColor = Color.FromArgb(currentColor.R, currentColor.G, currentColor.B);
        }
    }
}
