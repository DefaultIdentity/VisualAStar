namespace VisualAStar
{
    partial class Window
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
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ShowValsBox = new System.Windows.Forms.CheckBox();
            this.ShowPathBox = new System.Windows.Forms.CheckBox();
            this.ModeBox = new System.Windows.Forms.ComboBox();
            this.CellSizeBox = new System.Windows.Forms.TextBox();
            this.ProbObstacleBox = new System.Windows.Forms.TextBox();
            this.DestRowBox = new System.Windows.Forms.TextBox();
            this.DestColBox = new System.Windows.Forms.TextBox();
            this.RootRowBox = new System.Windows.Forms.TextBox();
            this.RootColBox = new System.Windows.Forms.TextBox();
            this.ColsBox = new System.Windows.Forms.TextBox();
            this.RowsBox = new System.Windows.Forms.TextBox();
            this.NewMapButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.ViewBox = new System.Windows.Forms.PictureBox();
            this.ControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ViewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ControlPanel
            // 
            this.ControlPanel.Controls.Add(this.label9);
            this.ControlPanel.Controls.Add(this.label8);
            this.ControlPanel.Controls.Add(this.label7);
            this.ControlPanel.Controls.Add(this.label6);
            this.ControlPanel.Controls.Add(this.label5);
            this.ControlPanel.Controls.Add(this.label4);
            this.ControlPanel.Controls.Add(this.label3);
            this.ControlPanel.Controls.Add(this.label2);
            this.ControlPanel.Controls.Add(this.label1);
            this.ControlPanel.Controls.Add(this.ShowValsBox);
            this.ControlPanel.Controls.Add(this.ShowPathBox);
            this.ControlPanel.Controls.Add(this.ModeBox);
            this.ControlPanel.Controls.Add(this.CellSizeBox);
            this.ControlPanel.Controls.Add(this.ProbObstacleBox);
            this.ControlPanel.Controls.Add(this.DestRowBox);
            this.ControlPanel.Controls.Add(this.DestColBox);
            this.ControlPanel.Controls.Add(this.RootRowBox);
            this.ControlPanel.Controls.Add(this.RootColBox);
            this.ControlPanel.Controls.Add(this.ColsBox);
            this.ControlPanel.Controls.Add(this.RowsBox);
            this.ControlPanel.Controls.Add(this.NewMapButton);
            this.ControlPanel.Controls.Add(this.SearchButton);
            this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ControlPanel.Location = new System.Drawing.Point(1114, 0);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(150, 682);
            this.ControlPanel.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Dest. Col:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Dest. Row:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Root Col:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Root Row:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Cols:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Rows:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Probability of Obstacle (1/X):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 455);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Cell Size:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 504);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Mode:";
            // 
            // ShowValsBox
            // 
            this.ShowValsBox.AutoSize = true;
            this.ShowValsBox.Location = new System.Drawing.Point(10, 590);
            this.ShowValsBox.Name = "ShowValsBox";
            this.ShowValsBox.Size = new System.Drawing.Size(132, 17);
            this.ShowValsBox.TabIndex = 12;
            this.ShowValsBox.Text = "Show Heuristic Values";
            this.ShowValsBox.UseVisualStyleBackColor = true;
            this.ShowValsBox.CheckedChanged += new System.EventHandler(this.ShowValsBox_CheckedChanged);
            // 
            // ShowPathBox
            // 
            this.ShowPathBox.AutoSize = true;
            this.ShowPathBox.Checked = true;
            this.ShowPathBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowPathBox.Location = new System.Drawing.Point(10, 567);
            this.ShowPathBox.Name = "ShowPathBox";
            this.ShowPathBox.Size = new System.Drawing.Size(75, 17);
            this.ShowPathBox.TabIndex = 11;
            this.ShowPathBox.Text = "ShowPath";
            this.ShowPathBox.UseVisualStyleBackColor = true;
            this.ShowPathBox.CheckedChanged += new System.EventHandler(this.ShowPathBox_CheckedChanged);
            // 
            // ModeBox
            // 
            this.ModeBox.FormattingEnabled = true;
            this.ModeBox.Items.AddRange(new object[] {
            "4-Directional",
            "4-Directional (Cross)",
            "4-Direction (Djikstra\'s)",
            "8-Directional (Cross)",
            "8-Directional"});
            this.ModeBox.Location = new System.Drawing.Point(7, 520);
            this.ModeBox.Name = "ModeBox";
            this.ModeBox.Size = new System.Drawing.Size(135, 21);
            this.ModeBox.TabIndex = 10;
            // 
            // CellSizeBox
            // 
            this.CellSizeBox.Location = new System.Drawing.Point(10, 471);
            this.CellSizeBox.Name = "CellSizeBox";
            this.CellSizeBox.Size = new System.Drawing.Size(131, 20);
            this.CellSizeBox.TabIndex = 9;
            this.CellSizeBox.Text = "20";
            // 
            // ProbObstacleBox
            // 
            this.ProbObstacleBox.Location = new System.Drawing.Point(9, 311);
            this.ProbObstacleBox.Name = "ProbObstacleBox";
            this.ProbObstacleBox.Size = new System.Drawing.Size(131, 20);
            this.ProbObstacleBox.TabIndex = 8;
            this.ProbObstacleBox.Text = "4";
            // 
            // DestRowBox
            // 
            this.DestRowBox.Location = new System.Drawing.Point(6, 211);
            this.DestRowBox.Name = "DestRowBox";
            this.DestRowBox.Size = new System.Drawing.Size(131, 20);
            this.DestRowBox.TabIndex = 6;
            this.DestRowBox.Text = "29";
            // 
            // DestColBox
            // 
            this.DestColBox.Location = new System.Drawing.Point(7, 250);
            this.DestColBox.Name = "DestColBox";
            this.DestColBox.Size = new System.Drawing.Size(131, 20);
            this.DestColBox.TabIndex = 7;
            this.DestColBox.Text = "29";
            // 
            // RootRowBox
            // 
            this.RootRowBox.Location = new System.Drawing.Point(6, 122);
            this.RootRowBox.Name = "RootRowBox";
            this.RootRowBox.Size = new System.Drawing.Size(131, 20);
            this.RootRowBox.TabIndex = 4;
            this.RootRowBox.Text = "0";
            // 
            // RootColBox
            // 
            this.RootColBox.Location = new System.Drawing.Point(7, 161);
            this.RootColBox.Name = "RootColBox";
            this.RootColBox.Size = new System.Drawing.Size(131, 20);
            this.RootColBox.TabIndex = 5;
            this.RootColBox.Text = "0";
            // 
            // ColsBox
            // 
            this.ColsBox.Location = new System.Drawing.Point(7, 64);
            this.ColsBox.Name = "ColsBox";
            this.ColsBox.Size = new System.Drawing.Size(131, 20);
            this.ColsBox.TabIndex = 3;
            this.ColsBox.Text = "30";
            // 
            // RowsBox
            // 
            this.RowsBox.Location = new System.Drawing.Point(8, 25);
            this.RowsBox.Name = "RowsBox";
            this.RowsBox.Size = new System.Drawing.Size(131, 20);
            this.RowsBox.TabIndex = 2;
            this.RowsBox.Text = "30";
            // 
            // NewMapButton
            // 
            this.NewMapButton.Location = new System.Drawing.Point(3, 649);
            this.NewMapButton.Name = "NewMapButton";
            this.NewMapButton.Size = new System.Drawing.Size(144, 30);
            this.NewMapButton.TabIndex = 1;
            this.NewMapButton.Text = "New Map";
            this.NewMapButton.UseVisualStyleBackColor = true;
            this.NewMapButton.Click += new System.EventHandler(this.NewMapButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(3, 613);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(144, 30);
            this.SearchButton.TabIndex = 0;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ViewBox
            // 
            this.ViewBox.BackColor = System.Drawing.Color.White;
            this.ViewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewBox.Location = new System.Drawing.Point(0, 0);
            this.ViewBox.Name = "ViewBox";
            this.ViewBox.Size = new System.Drawing.Size(1114, 682);
            this.ViewBox.TabIndex = 1;
            this.ViewBox.TabStop = false;
            this.ViewBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ViewBox_MouseClick);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.ViewBox);
            this.Controls.Add(this.ControlPanel);
            this.Name = "Window";
            this.Text = "Visual A*";
            this.ControlPanel.ResumeLayout(false);
            this.ControlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ViewBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.PictureBox ViewBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button NewMapButton;
        private System.Windows.Forms.TextBox ColsBox;
        private System.Windows.Forms.TextBox RowsBox;
        private System.Windows.Forms.TextBox CellSizeBox;
        private System.Windows.Forms.TextBox ProbObstacleBox;
        private System.Windows.Forms.TextBox DestRowBox;
        private System.Windows.Forms.TextBox DestColBox;
        private System.Windows.Forms.TextBox RootRowBox;
        private System.Windows.Forms.TextBox RootColBox;
        private System.Windows.Forms.CheckBox ShowValsBox;
        private System.Windows.Forms.CheckBox ShowPathBox;
        private System.Windows.Forms.ComboBox ModeBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}

