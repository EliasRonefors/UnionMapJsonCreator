namespace UnionMapCreator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            NodeNameBox = new TextBox();
            label1 = new Label();
            ContinentLabel = new Label();
            AdjecentNodeList = new ListBox();
            ContinentNameBox = new TextBox();
            CreateButton = new Button();
            CurrentNodeLabel = new Label();
            ContinentListBox = new ListBox();
            CancelButton = new Button();
            label4 = new Label();
            NodeConnectedBox = new TextBox();
            ConnectedContinentsList = new ListBox();
            AddContinentNameBox = new TextBox();
            AddContinentButton = new Button();
            ContinentTroopBox = new TextBox();
            CreateFileButton = new Button();
            label5 = new Label();
            label6 = new Label();
            NodeLabel = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(960, 540);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            // 
            // NodeNameBox
            // 
            NodeNameBox.Location = new Point(1122, 54);
            NodeNameBox.Name = "NodeNameBox";
            NodeNameBox.Size = new Size(130, 23);
            NodeNameBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1122, 36);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 4;
            label1.Text = "Name:";
            // 
            // ContinentLabel
            // 
            ContinentLabel.AutoSize = true;
            ContinentLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ContinentLabel.Location = new Point(978, 12);
            ContinentLabel.Name = "ContinentLabel";
            ContinentLabel.Size = new Size(105, 15);
            ContinentLabel.TabIndex = 5;
            ContinentLabel.Text = "Create Continent:";
            // 
            // AdjecentNodeList
            // 
            AdjecentNodeList.FormattingEnabled = true;
            AdjecentNodeList.ItemHeight = 15;
            AdjecentNodeList.Location = new Point(197, 558);
            AdjecentNodeList.Name = "AdjecentNodeList";
            AdjecentNodeList.Size = new Size(150, 109);
            AdjecentNodeList.TabIndex = 6;
            // 
            // ContinentNameBox
            // 
            ContinentNameBox.Location = new Point(984, 54);
            ContinentNameBox.Name = "ContinentNameBox";
            ContinentNameBox.Size = new Size(130, 23);
            ContinentNameBox.TabIndex = 7;
            // 
            // CreateButton
            // 
            CreateButton.Location = new Point(1039, 127);
            CreateButton.Name = "CreateButton";
            CreateButton.Size = new Size(75, 23);
            CreateButton.TabIndex = 8;
            CreateButton.Text = "Create";
            CreateButton.UseVisualStyleBackColor = true;
            CreateButton.Click += CreateButton_Click;
            // 
            // CurrentNodeLabel
            // 
            CurrentNodeLabel.AutoSize = true;
            CurrentNodeLabel.Location = new Point(12, 559);
            CurrentNodeLabel.Name = "CurrentNodeLabel";
            CurrentNodeLabel.Size = new Size(0, 15);
            CurrentNodeLabel.TabIndex = 9;
            CurrentNodeLabel.TextChanged += CurrentNodeLabel_TextChanged;
            // 
            // ContinentListBox
            // 
            ContinentListBox.FormattingEnabled = true;
            ContinentListBox.ItemHeight = 15;
            ContinentListBox.Location = new Point(984, 160);
            ContinentListBox.Name = "ContinentListBox";
            ContinentListBox.Size = new Size(130, 154);
            ContinentListBox.TabIndex = 10;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(12, 577);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 11;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1122, 80);
            label4.Name = "label4";
            label4.Size = new Size(119, 15);
            label4.TabIndex = 12;
            label4.Text = "connected Continent";
            // 
            // NodeConnectedBox
            // 
            NodeConnectedBox.Location = new Point(1122, 98);
            NodeConnectedBox.Name = "NodeConnectedBox";
            NodeConnectedBox.Size = new Size(130, 23);
            NodeConnectedBox.TabIndex = 13;
            // 
            // ConnectedContinentsList
            // 
            ConnectedContinentsList.FormattingEnabled = true;
            ConnectedContinentsList.ItemHeight = 15;
            ConnectedContinentsList.Location = new Point(353, 558);
            ConnectedContinentsList.Name = "ConnectedContinentsList";
            ConnectedContinentsList.Size = new Size(150, 109);
            ConnectedContinentsList.TabIndex = 14;
            // 
            // AddContinentNameBox
            // 
            AddContinentNameBox.Location = new Point(1122, 178);
            AddContinentNameBox.Name = "AddContinentNameBox";
            AddContinentNameBox.Size = new Size(130, 23);
            AddContinentNameBox.TabIndex = 15;
            // 
            // AddContinentButton
            // 
            AddContinentButton.Location = new Point(1177, 207);
            AddContinentButton.Name = "AddContinentButton";
            AddContinentButton.Size = new Size(75, 23);
            AddContinentButton.TabIndex = 16;
            AddContinentButton.Text = "Add";
            AddContinentButton.UseVisualStyleBackColor = true;
            AddContinentButton.Click += AddContinentButton_Click;
            // 
            // ContinentTroopBox
            // 
            ContinentTroopBox.Location = new Point(984, 98);
            ContinentTroopBox.Name = "ContinentTroopBox";
            ContinentTroopBox.Size = new Size(130, 23);
            ContinentTroopBox.TabIndex = 17;
            // 
            // CreateFileButton
            // 
            CreateFileButton.Location = new Point(1177, 646);
            CreateFileButton.Name = "CreateFileButton";
            CreateFileButton.Size = new Size(75, 23);
            CreateFileButton.TabIndex = 18;
            CreateFileButton.Text = "Create File";
            CreateFileButton.UseVisualStyleBackColor = true;
            CreateFileButton.Click += CreateFileButton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(984, 36);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 19;
            label5.Text = "Name:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(984, 80);
            label6.Name = "label6";
            label6.Size = new Size(76, 15);
            label6.TabIndex = 20;
            label6.Text = "Troop Bonus:";
            // 
            // NodeLabel
            // 
            NodeLabel.AutoSize = true;
            NodeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            NodeLabel.Location = new Point(1122, 12);
            NodeLabel.Name = "NodeLabel";
            NodeLabel.Size = new Size(43, 15);
            NodeLabel.TabIndex = 21;
            NodeLabel.Text = "Node: ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1122, 160);
            label8.Name = "label8";
            label8.Size = new Size(88, 15);
            label8.TabIndex = 22;
            label8.Text = "Add Continent:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(label8);
            Controls.Add(NodeLabel);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(CreateFileButton);
            Controls.Add(ContinentTroopBox);
            Controls.Add(AddContinentButton);
            Controls.Add(AddContinentNameBox);
            Controls.Add(ConnectedContinentsList);
            Controls.Add(NodeConnectedBox);
            Controls.Add(label4);
            Controls.Add(CancelButton);
            Controls.Add(ContinentListBox);
            Controls.Add(CurrentNodeLabel);
            Controls.Add(CreateButton);
            Controls.Add(ContinentNameBox);
            Controls.Add(AdjecentNodeList);
            Controls.Add(ContinentLabel);
            Controls.Add(label1);
            Controls.Add(NodeNameBox);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox NodeNameBox;
        private Label label1;
        private Label ContinentLabel;
        private ListBox AdjecentNodeList;
        private TextBox ContinentNameBox;
        private Button CreateButton;
        private Label CurrentNodeLabel;
        private ListBox ContinentListBox;
        private Button CancelButton;
        private Label label4;
        private TextBox NodeConnectedBox;
        private ListBox ConnectedContinentsList;
        private TextBox AddContinentNameBox;
        private Button AddContinentButton;
        private TextBox ContinentTroopBox;
        private Button CreateFileButton;
        private Label label5;
        private Label label6;
        private Label NodeLabel;
        private Label label8;
    }
}