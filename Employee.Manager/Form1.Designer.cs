namespace Employee.Manager
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
			button1 = new Button();
			textBox1 = new TextBox();
			dataGridView1 = new DataGridView();
			button2 = new Button();
			linkLabel1 = new LinkLabel();
			Search = new Button();
			test = new Button();
			DataGridViewButtonColumn = new DataGridViewButtonColumn();
			Delete = new DataGridViewButtonColumn();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// button1
			// 
			button1.Location = new Point(12, 12);
			button1.Name = "button1";
			button1.Size = new Size(131, 29);
			button1.TabIndex = 0;
			button1.Text = "New Employee";
			button1.TextAlign = ContentAlignment.MiddleLeft;
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// textBox1
			// 
			textBox1.Location = new Point(12, 95);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(153, 27);
			textBox1.TabIndex = 1;
			// 
			// dataGridView1
			// 
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Columns.AddRange(new DataGridViewColumn[] { DataGridViewButtonColumn, Delete });
			dataGridView1.GridColor = Color.White;
			dataGridView1.Location = new Point(12, 124);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.ReadOnly = true;
			dataGridView1.RowHeadersWidth = 51;
			dataGridView1.RowTemplate.Height = 29;
			dataGridView1.Size = new Size(932, 220);
			dataGridView1.TabIndex = 2;
			// 
			// button2
			// 
			button2.Location = new Point(12, 47);
			button2.Name = "button2";
			button2.Size = new Size(131, 29);
			button2.TabIndex = 3;
			button2.Text = "New Department";
			button2.TextAlign = ContentAlignment.MiddleLeft;
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// linkLabel1
			// 
			linkLabel1.AutoSize = true;
			linkLabel1.Location = new Point(886, 101);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new Size(58, 20);
			linkLabel1.TabIndex = 4;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "Refresh";
			linkLabel1.LinkClicked += linkLabel1_LinkClicked;
			// 
			// Search
			// 
			Search.Location = new Point(162, 95);
			Search.Name = "Search";
			Search.Size = new Size(94, 29);
			Search.TabIndex = 5;
			Search.Text = "Search";
			Search.UseVisualStyleBackColor = true;
			Search.Click += Search_Click;
			// 
			// test
			// 
			test.Location = new Point(806, 12);
			test.Name = "test";
			test.Size = new Size(118, 29);
			test.TabIndex = 6;
			test.Text = "From (.xlsx) file";
			test.TextAlign = ContentAlignment.MiddleLeft;
			test.UseVisualStyleBackColor = true;
			test.Click += test_Click;
			// 
			// DataGridViewButtonColumn
			// 
			DataGridViewButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			DataGridViewButtonColumn.HeaderText = "Edit";
			DataGridViewButtonColumn.MinimumWidth = 10;
			DataGridViewButtonColumn.Name = "DataGridViewButtonColumn";
			DataGridViewButtonColumn.ReadOnly = true;
			DataGridViewButtonColumn.Resizable = DataGridViewTriState.True;
			DataGridViewButtonColumn.Text = "edit";
			DataGridViewButtonColumn.Width = 41;
			// 
			// Delete
			// 
			Delete.HeaderText = "Delete";
			Delete.MinimumWidth = 6;
			Delete.Name = "Delete";
			Delete.ReadOnly = true;
			Delete.Width = 41;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(956, 361);
			Controls.Add(test);
			Controls.Add(Search);
			Controls.Add(linkLabel1);
			Controls.Add(button2);
			Controls.Add(dataGridView1);
			Controls.Add(textBox1);
			Controls.Add(button1);
			Name = "Form1";
			Text = "Employee Manager";
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button button1;
		private TextBox textBox1;
		private DataGridView dataGridView1;
		private Button button2;
		private LinkLabel linkLabel1;
		private Button Search;
		private Button test;
		private DataGridViewButtonColumn DataGridViewButtonColumn;
		private DataGridViewButtonColumn Delete;
	}
}
