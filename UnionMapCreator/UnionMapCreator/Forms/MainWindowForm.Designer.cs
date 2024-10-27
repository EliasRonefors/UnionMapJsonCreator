namespace UnionMapCreator
{
    partial class MainWindowForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param Name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            NodeNameBox = new TextBox();
            label1 = new Label();
            ContinentLabel = new Label();
            CurrentNodeLabel = new Label();
            CancelButton = new Button();
            label4 = new Label();
            NodeLabel = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            button1 = new Button();
            HintLabel = new Label();
            betterListBox1 = new BetterListBox();
            betterListBox2 = new BetterListBox();
            betterListBox3 = new BetterListBox();
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            createToolStripMenuItem = new ToolStripMenuItem();
            continentToolStripMenuItem = new ToolStripMenuItem();
            territoryToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // NodeNameBox
            // 
            NodeNameBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            NodeNameBox.BorderStyle = BorderStyle.FixedSingle;
            NodeNameBox.Location = new Point(1122, 88);
            NodeNameBox.Name = "NodeNameBox";
            NodeNameBox.Size = new Size(130, 25);
            NodeNameBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(1122, 68);
            label1.Name = "label1";
            label1.Size = new Size(46, 17);
            label1.TabIndex = 4;
            label1.Text = "Name:";
            // 
            // ContinentLabel
            // 
            ContinentLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ContinentLabel.AutoSize = true;
            ContinentLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ContinentLabel.Location = new Point(978, 41);
            ContinentLabel.Name = "ContinentLabel";
            ContinentLabel.Size = new Size(67, 15);
            ContinentLabel.TabIndex = 5;
            ContinentLabel.Text = "Continents";
            // 
            // CurrentNodeLabel
            // 
            CurrentNodeLabel.AutoSize = true;
            CurrentNodeLabel.Location = new Point(1122, 118);
            CurrentNodeLabel.Name = "CurrentNodeLabel";
            CurrentNodeLabel.Size = new Size(0, 17);
            CurrentNodeLabel.TabIndex = 9;
            CurrentNodeLabel.TextChanged += CurrentNodeLabel_TextChanged;
            // 
            // CancelButton
            // 
            CancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CancelButton.FlatStyle = FlatStyle.Flat;
            CancelButton.Location = new Point(1122, 138);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(130, 26);
            CancelButton.TabIndex = 11;
            CancelButton.Text = "Cancel Selection";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(1122, 402);
            label4.Name = "label4";
            label4.Size = new Size(135, 17);
            label4.TabIndex = 12;
            label4.Text = "Connected Continents";
            // 
            // NodeLabel
            // 
            NodeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            NodeLabel.AutoSize = true;
            NodeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            NodeLabel.Location = new Point(1122, 41);
            NodeLabel.Name = "NodeLabel";
            NodeLabel.Size = new Size(43, 15);
            NodeLabel.TabIndex = 21;
            NodeLabel.Text = "Node: ";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(1122, 188);
            label2.Name = "label2";
            label2.Size = new Size(113, 17);
            label2.TabIndex = 22;
            label2.Text = "Connected Nodes";
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(1122, 597);
            comboBox1.Margin = new Padding(3, 0, 0, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(106, 25);
            comboBox1.TabIndex = 23;
            comboBox1.DropDown += comboBox1_DropDown;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(1228, 597);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(24, 27);
            button1.TabIndex = 24;
            button1.Text = "+";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // HintLabel
            // 
            HintLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            HintLabel.AutoSize = true;
            HintLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            HintLabel.Location = new Point(12, 632);
            HintLabel.Name = "HintLabel";
            HintLabel.Size = new Size(46, 21);
            HintLabel.TabIndex = 25;
            HintLabel.Text = "Hint: ";
            // 
            // betterListBox1
            // 
            betterListBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            betterListBox1.AutoScroll = true;
            betterListBox1.BorderStyle = BorderStyle.FixedSingle;
            betterListBox1.Location = new Point(978, 68);
            betterListBox1.Name = "betterListBox1";
            betterListBox1.Size = new Size(130, 174);
            betterListBox1.TabIndex = 26;
            // 
            // betterListBox2
            // 
            betterListBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            betterListBox2.BackColor = SystemColors.Control;
            betterListBox2.BorderStyle = BorderStyle.FixedSingle;
            betterListBox2.Location = new Point(1122, 208);
            betterListBox2.Name = "betterListBox2";
            betterListBox2.Size = new Size(130, 174);
            betterListBox2.TabIndex = 27;
            // 
            // betterListBox3
            // 
            betterListBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            betterListBox3.BorderStyle = BorderStyle.FixedSingle;
            betterListBox3.Location = new Point(1122, 423);
            betterListBox3.Name = "betterListBox3";
            betterListBox3.Size = new Size(130, 174);
            betterListBox3.TabIndex = 28;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(12, 41);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(960, 560);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { createToolStripMenuItem, exportToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1264, 25);
            menuStrip1.TabIndex = 29;
            menuStrip1.Text = "menuStrip1";
            // 
            // createToolStripMenuItem
            // 
            createToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { continentToolStripMenuItem, territoryToolStripMenuItem });
            createToolStripMenuItem.Name = "createToolStripMenuItem";
            createToolStripMenuItem.Size = new Size(58, 21);
            createToolStripMenuItem.Text = "Create";
            // 
            // continentToolStripMenuItem
            // 
            continentToolStripMenuItem.Name = "continentToolStripMenuItem";
            continentToolStripMenuItem.Size = new Size(131, 22);
            continentToolStripMenuItem.Text = "Continent";
            continentToolStripMenuItem.Click += continentToolStripMenuItem_Click;
            // 
            // territoryToolStripMenuItem
            // 
            territoryToolStripMenuItem.Name = "territoryToolStripMenuItem";
            territoryToolStripMenuItem.Size = new Size(131, 22);
            territoryToolStripMenuItem.Text = "Territory";
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(58, 21);
            exportToolStripMenuItem.Text = "Export";
            exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 661);
            Controls.Add(pictureBox1);
            Controls.Add(betterListBox3);
            Controls.Add(betterListBox2);
            Controls.Add(betterListBox1);
            Controls.Add(HintLabel);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(NodeLabel);
            Controls.Add(label4);
            Controls.Add(CancelButton);
            Controls.Add(CurrentNodeLabel);
            Controls.Add(ContinentLabel);
            Controls.Add(label1);
            Controls.Add(NodeNameBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(700, 700);
            Name = "Form1";
            Text = "Union Map Maker";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox NodeNameBox;
        private Label label1;
        private Label ContinentLabel;
        private Label CurrentNodeLabel;
        private Button CancelButton;
        private Label label4;
        private Label NodeLabel;
        private Label label2;
        private ComboBox comboBox1;
        private Button button1;
        private Label HintLabel;
        private BetterListBox betterListBox1;
        private BetterListBox betterListBox2;
        private BetterListBox betterListBox3;
        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem createToolStripMenuItem;
        private ToolStripMenuItem continentToolStripMenuItem;
        private ToolStripMenuItem territoryToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
    }
}