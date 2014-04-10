namespace AG44
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.authorizedLevelGroupBox = new System.Windows.Forms.GroupBox();
            this.bus = new System.Windows.Forms.CheckBox();
            this.tk = new System.Windows.Forms.CheckBox();
            this.ts = new System.Windows.Forms.CheckBox();
            this.tsd = new System.Windows.Forms.CheckBox();
            this.tc = new System.Windows.Forms.CheckBox();
            this.tph = new System.Windows.Forms.CheckBox();
            this.snow = new System.Windows.Forms.CheckBox();
            this.track = new System.Windows.Forms.CheckBox();
            this.black = new System.Windows.Forms.CheckBox();
            this.red = new System.Windows.Forms.CheckBox();
            this.blue = new System.Windows.Forms.CheckBox();
            this.green = new System.Windows.Forms.CheckBox();
            this.reachableButton = new System.Windows.Forms.Button();
            this.reachableEdit = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.startEdit = new System.Windows.Forms.TextBox();
            this.endEdit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.shortestButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.listButton = new System.Windows.Forms.Button();
            this.authorizedLevelGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // authorizedLevelGroupBox
            // 
            this.authorizedLevelGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.authorizedLevelGroupBox.Controls.Add(this.bus);
            this.authorizedLevelGroupBox.Controls.Add(this.tk);
            this.authorizedLevelGroupBox.Controls.Add(this.ts);
            this.authorizedLevelGroupBox.Controls.Add(this.tsd);
            this.authorizedLevelGroupBox.Controls.Add(this.tc);
            this.authorizedLevelGroupBox.Controls.Add(this.tph);
            this.authorizedLevelGroupBox.Controls.Add(this.snow);
            this.authorizedLevelGroupBox.Controls.Add(this.track);
            this.authorizedLevelGroupBox.Controls.Add(this.black);
            this.authorizedLevelGroupBox.Controls.Add(this.red);
            this.authorizedLevelGroupBox.Controls.Add(this.blue);
            this.authorizedLevelGroupBox.Controls.Add(this.green);
            this.authorizedLevelGroupBox.Location = new System.Drawing.Point(279, 27);
            this.authorizedLevelGroupBox.Name = "authorizedLevelGroupBox";
            this.authorizedLevelGroupBox.Size = new System.Drawing.Size(128, 306);
            this.authorizedLevelGroupBox.TabIndex = 0;
            this.authorizedLevelGroupBox.TabStop = false;
            this.authorizedLevelGroupBox.Text = "Authorized Level";
            // 
            // bus
            // 
            this.bus.AutoSize = true;
            this.bus.Checked = true;
            this.bus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bus.Location = new System.Drawing.Point(6, 277);
            this.bus.Name = "bus";
            this.bus.Size = new System.Drawing.Size(44, 17);
            this.bus.TabIndex = 11;
            this.bus.Text = "Bus";
            this.bus.UseVisualStyleBackColor = true;
            this.bus.CheckedChanged += new System.EventHandler(this.bus_CheckedChanged);
            // 
            // tk
            // 
            this.tk.AutoSize = true;
            this.tk.Checked = true;
            this.tk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tk.Location = new System.Drawing.Point(6, 256);
            this.tk.Name = "tk";
            this.tk.Size = new System.Drawing.Size(40, 17);
            this.tk.TabIndex = 10;
            this.tk.Text = "TK";
            this.tk.UseVisualStyleBackColor = true;
            this.tk.CheckedChanged += new System.EventHandler(this.tk_CheckedChanged);
            // 
            // ts
            // 
            this.ts.AutoSize = true;
            this.ts.Checked = true;
            this.ts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ts.Location = new System.Drawing.Point(6, 232);
            this.ts.Name = "ts";
            this.ts.Size = new System.Drawing.Size(40, 17);
            this.ts.TabIndex = 9;
            this.ts.Text = "TS";
            this.ts.UseVisualStyleBackColor = true;
            this.ts.CheckedChanged += new System.EventHandler(this.ts_CheckedChanged);
            // 
            // tsd
            // 
            this.tsd.AutoSize = true;
            this.tsd.Checked = true;
            this.tsd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsd.Location = new System.Drawing.Point(6, 208);
            this.tsd.Name = "tsd";
            this.tsd.Size = new System.Drawing.Size(48, 17);
            this.tsd.TabIndex = 8;
            this.tsd.Text = "TSD";
            this.tsd.UseVisualStyleBackColor = true;
            this.tsd.CheckedChanged += new System.EventHandler(this.tsd_CheckedChanged);
            // 
            // tc
            // 
            this.tc.AutoSize = true;
            this.tc.Checked = true;
            this.tc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tc.Location = new System.Drawing.Point(6, 184);
            this.tc.Name = "tc";
            this.tc.Size = new System.Drawing.Size(40, 17);
            this.tc.TabIndex = 7;
            this.tc.Text = "TC";
            this.tc.UseVisualStyleBackColor = true;
            this.tc.CheckedChanged += new System.EventHandler(this.tc_CheckedChanged);
            // 
            // tph
            // 
            this.tph.AutoSize = true;
            this.tph.Checked = true;
            this.tph.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tph.Location = new System.Drawing.Point(6, 160);
            this.tph.Name = "tph";
            this.tph.Size = new System.Drawing.Size(48, 17);
            this.tph.TabIndex = 6;
            this.tph.Text = "TPH";
            this.tph.UseVisualStyleBackColor = true;
            this.tph.CheckedChanged += new System.EventHandler(this.tph_CheckedChanged);
            // 
            // snow
            // 
            this.snow.AutoSize = true;
            this.snow.Checked = true;
            this.snow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.snow.Location = new System.Drawing.Point(6, 137);
            this.snow.Name = "snow";
            this.snow.Size = new System.Drawing.Size(74, 17);
            this.snow.TabIndex = 5;
            this.snow.Text = "Snowpark";
            this.snow.UseVisualStyleBackColor = true;
            this.snow.CheckedChanged += new System.EventHandler(this.snow_CheckedChanged);
            // 
            // track
            // 
            this.track.AutoSize = true;
            this.track.Checked = true;
            this.track.CheckState = System.Windows.Forms.CheckState.Checked;
            this.track.Location = new System.Drawing.Point(6, 114);
            this.track.Name = "track";
            this.track.Size = new System.Drawing.Size(84, 17);
            this.track.TabIndex = 4;
            this.track.Text = "Track skiing";
            this.track.UseVisualStyleBackColor = true;
            this.track.CheckedChanged += new System.EventHandler(this.track_CheckedChanged);
            // 
            // black
            // 
            this.black.AutoSize = true;
            this.black.Checked = true;
            this.black.CheckState = System.Windows.Forms.CheckState.Checked;
            this.black.Location = new System.Drawing.Point(7, 90);
            this.black.Name = "black";
            this.black.Size = new System.Drawing.Size(80, 17);
            this.black.TabIndex = 3;
            this.black.Text = "Black track";
            this.black.UseVisualStyleBackColor = true;
            this.black.CheckedChanged += new System.EventHandler(this.black_CheckedChanged);
            // 
            // red
            // 
            this.red.AutoSize = true;
            this.red.Checked = true;
            this.red.CheckState = System.Windows.Forms.CheckState.Checked;
            this.red.Location = new System.Drawing.Point(6, 66);
            this.red.Name = "red";
            this.red.Size = new System.Drawing.Size(73, 17);
            this.red.TabIndex = 2;
            this.red.Text = "Red track";
            this.red.UseVisualStyleBackColor = true;
            this.red.CheckedChanged += new System.EventHandler(this.red_CheckedChanged);
            // 
            // blue
            // 
            this.blue.AutoSize = true;
            this.blue.Checked = true;
            this.blue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.blue.Location = new System.Drawing.Point(6, 42);
            this.blue.Name = "blue";
            this.blue.Size = new System.Drawing.Size(74, 17);
            this.blue.TabIndex = 1;
            this.blue.Text = "Blue track";
            this.blue.UseVisualStyleBackColor = true;
            this.blue.CheckedChanged += new System.EventHandler(this.blue_CheckedChanged);
            // 
            // green
            // 
            this.green.AutoSize = true;
            this.green.Checked = true;
            this.green.CheckState = System.Windows.Forms.CheckState.Checked;
            this.green.Location = new System.Drawing.Point(6, 19);
            this.green.Name = "green";
            this.green.Size = new System.Drawing.Size(82, 17);
            this.green.TabIndex = 0;
            this.green.Text = "Green track";
            this.green.UseVisualStyleBackColor = true;
            this.green.CheckedChanged += new System.EventHandler(this.green_CheckedChanged);
            // 
            // reachableButton
            // 
            this.reachableButton.Enabled = false;
            this.reachableButton.Location = new System.Drawing.Point(279, 361);
            this.reachableButton.Name = "reachableButton";
            this.reachableButton.Size = new System.Drawing.Size(128, 25);
            this.reachableButton.TabIndex = 1;
            this.reachableButton.Text = " Get Reachable Point";
            this.reachableButton.UseVisualStyleBackColor = true;
            this.reachableButton.Click += new System.EventHandler(this.reachableButton_Click);
            // 
            // reachableEdit
            // 
            this.reachableEdit.Location = new System.Drawing.Point(279, 339);
            this.reachableEdit.Name = "reachableEdit";
            this.reachableEdit.Size = new System.Drawing.Size(128, 20);
            this.reachableEdit.TabIndex = 2;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 27);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(261, 280);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // startEdit
            // 
            this.startEdit.Location = new System.Drawing.Point(50, 313);
            this.startEdit.Name = "startEdit";
            this.startEdit.Size = new System.Drawing.Size(223, 20);
            this.startEdit.TabIndex = 4;
            // 
            // endEdit
            // 
            this.endEdit.Location = new System.Drawing.Point(50, 339);
            this.endEdit.Name = "endEdit";
            this.endEdit.Size = new System.Drawing.Size(223, 20);
            this.endEdit.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Start : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 340);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "End  : ";
            // 
            // shortestButton
            // 
            this.shortestButton.Enabled = false;
            this.shortestButton.Location = new System.Drawing.Point(12, 363);
            this.shortestButton.Name = "shortestButton";
            this.shortestButton.Size = new System.Drawing.Size(261, 23);
            this.shortestButton.TabIndex = 8;
            this.shortestButton.Text = "Get Shortest Path";
            this.shortestButton.UseVisualStyleBackColor = true;
            this.shortestButton.Click += new System.EventHandler(this.shortestButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(198, 390);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 24);
            this.button3.TabIndex = 9;
            this.button3.Text = "Exit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(111, 391);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(81, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Reset";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(419, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "dataski.txt";
            // 
            // listButton
            // 
            this.listButton.Enabled = false;
            this.listButton.Location = new System.Drawing.Point(12, 390);
            this.listButton.Name = "listButton";
            this.listButton.Size = new System.Drawing.Size(93, 23);
            this.listButton.TabIndex = 12;
            this.listButton.Text = "List Everything";
            this.listButton.UseVisualStyleBackColor = true;
            this.listButton.Click += new System.EventHandler(this.listButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 420);
            this.Controls.Add(this.listButton);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.shortestButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.endEdit);
            this.Controls.Add(this.startEdit);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.reachableEdit);
            this.Controls.Add(this.reachableButton);
            this.Controls.Add(this.authorizedLevelGroupBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "AG44";
            this.authorizedLevelGroupBox.ResumeLayout(false);
            this.authorizedLevelGroupBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox authorizedLevelGroupBox;
        private System.Windows.Forms.CheckBox bus;
        private System.Windows.Forms.CheckBox tk;
        private System.Windows.Forms.CheckBox ts;
        private System.Windows.Forms.CheckBox tsd;
        private System.Windows.Forms.CheckBox tc;
        private System.Windows.Forms.CheckBox tph;
        private System.Windows.Forms.CheckBox snow;
        private System.Windows.Forms.CheckBox track;
        private System.Windows.Forms.CheckBox black;
        private System.Windows.Forms.CheckBox red;
        private System.Windows.Forms.CheckBox blue;
        private System.Windows.Forms.CheckBox green;
        private System.Windows.Forms.Button reachableButton;
        private System.Windows.Forms.TextBox reachableEdit;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox startEdit;
        private System.Windows.Forms.TextBox endEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button shortestButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button listButton;

    }
}

