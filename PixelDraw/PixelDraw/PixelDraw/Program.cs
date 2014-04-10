using System;
using System.Windows.Forms;

namespace PixelDraw
{
#if WINDOWS || XBOX
    static class Program
    {
        static EditorWindow mainForm;
        static Editor editor;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            mainForm = new EditorWindow();
            mainForm.Show();
            using (editor = new Editor(mainForm.GetXNAView(), mainForm.GetXNAViewSize()))
            {
                mainForm.SetXNAEditor(editor);
                mainForm.FormClosing += new FormClosingEventHandler(OnFormClosing);
                editor.Exiting += new EventHandler<EventArgs>(OnGameExiting);
                editor.Run();
            }
        }

        static void OnGameExiting(object sender, EventArgs e)
        {
            Application.Exit();
        }

        static void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            editor.Exit();
        }
    }
#endif
}

