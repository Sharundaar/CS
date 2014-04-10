namespace PixelDraw
{
    partial class EditorWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.XNAView = new System.Windows.Forms.PictureBox();
            this.PixelColor = new System.Windows.Forms.Panel();
            this.RedBar = new System.Windows.Forms.TrackBar();
            this.GreenBar = new System.Windows.Forms.TrackBar();
            this.BlueBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.XNAView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueBar)).BeginInit();
            this.SuspendLayout();
            // 
            // XNAView
            // 
            this.XNAView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.XNAView.Location = new System.Drawing.Point(12, 12);
            this.XNAView.Name = "XNAView";
            this.XNAView.Size = new System.Drawing.Size(365, 380);
            this.XNAView.TabIndex = 0;
            this.XNAView.TabStop = false;
            // 
            // PixelColor
            // 
            this.PixelColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PixelColor.BackColor = System.Drawing.SystemColors.Desktop;
            this.PixelColor.Location = new System.Drawing.Point(383, 12);
            this.PixelColor.Name = "PixelColor";
            this.PixelColor.Size = new System.Drawing.Size(150, 150);
            this.PixelColor.TabIndex = 1;
            // 
            // RedBar
            // 
            this.RedBar.Location = new System.Drawing.Point(383, 168);
            this.RedBar.Maximum = 255;
            this.RedBar.Name = "RedBar";
            this.RedBar.Size = new System.Drawing.Size(104, 45);
            this.RedBar.TabIndex = 2;
            this.RedBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.RedBar.ValueChanged += new System.EventHandler(this.RedBar_ValueChanged);
            // 
            // GreenBar
            // 
            this.GreenBar.Location = new System.Drawing.Point(383, 199);
            this.GreenBar.Maximum = 255;
            this.GreenBar.Name = "GreenBar";
            this.GreenBar.Size = new System.Drawing.Size(104, 45);
            this.GreenBar.TabIndex = 3;
            this.GreenBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.GreenBar.ValueChanged += new System.EventHandler(this.GreenBar_ValueChanged);
            // 
            // BlueBar
            // 
            this.BlueBar.Location = new System.Drawing.Point(383, 233);
            this.BlueBar.Maximum = 255;
            this.BlueBar.Name = "BlueBar";
            this.BlueBar.Size = new System.Drawing.Size(104, 45);
            this.BlueBar.TabIndex = 4;
            this.BlueBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.BlueBar.ValueChanged += new System.EventHandler(this.BlueBar_ValueChanged);
            // 
            // EditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 404);
            this.Controls.Add(this.BlueBar);
            this.Controls.Add(this.GreenBar);
            this.Controls.Add(this.RedBar);
            this.Controls.Add(this.PixelColor);
            this.Controls.Add(this.XNAView);
            this.Name = "EditorWindow";
            this.Text = "EditorWindow";
            ((System.ComponentModel.ISupportInitialize)(this.XNAView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox XNAView;
        private System.Windows.Forms.Panel PixelColor;
        private System.Windows.Forms.TrackBar RedBar;
        private System.Windows.Forms.TrackBar GreenBar;
        private System.Windows.Forms.TrackBar BlueBar;
    }
}