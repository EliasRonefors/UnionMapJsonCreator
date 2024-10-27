namespace UnionMapCreator
{
    partial class CreateContinentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label6 = new Label();
            label5 = new Label();
            ContinentTroopBox = new TextBox();
            ContinentNameBox = new TextBox();
            CreateContinent = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(219, 23);
            label6.Name = "label6";
            label6.Size = new Size(85, 17);
            label6.TabIndex = 26;
            label6.Text = "Troop Bonus:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 23);
            label5.Name = "label5";
            label5.Size = new Size(46, 17);
            label5.TabIndex = 25;
            label5.Text = "Name:";
            // 
            // ContinentTroopBox
            // 
            ContinentTroopBox.Location = new Point(219, 43);
            ContinentTroopBox.Name = "ContinentTroopBox";
            ContinentTroopBox.Size = new Size(130, 25);
            ContinentTroopBox.TabIndex = 24;
            // 
            // ContinentNameBox
            // 
            ContinentNameBox.Location = new Point(12, 43);
            ContinentNameBox.Name = "ContinentNameBox";
            ContinentNameBox.Size = new Size(184, 25);
            ContinentNameBox.TabIndex = 22;
            // 
            // CreateContinent
            // 
            CreateContinent.Location = new Point(274, 102);
            CreateContinent.Name = "CreateContinent";
            CreateContinent.Size = new Size(75, 23);
            CreateContinent.TabIndex = 27;
            CreateContinent.Text = "Create";
            CreateContinent.UseVisualStyleBackColor = true;
            CreateContinent.Click += CreateContinent_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(193, 102);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 28;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // CreateContinentForm
            // 
            AccessibleName = "Create Continent";
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(361, 137);
            Controls.Add(CancelButton);
            Controls.Add(CreateContinent);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(ContinentTroopBox);
            Controls.Add(ContinentNameBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "CreateContinentForm";
            Text = "Create Continent";
            Load += CreateContinentForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Label label5;
        private TextBox ContinentTroopBox;
        private TextBox ContinentNameBox;
        private Button CreateContinent;
        private Button CancelButton;
    }
}