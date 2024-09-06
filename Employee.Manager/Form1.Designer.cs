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
			DataGridViewButtonColumn = new DataGridViewButtonColumn();
			Delete = new DataGridViewButtonColumn();
			linkLabel1 = new LinkLabel();
			Search = new Button();
			test = new Button();
			button3 = new Button();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// button1
			// 
			button1.Location = new Point(148, 12);
			button1.Name = "button1";
			button1.Size = new Size(154, 29);
			button1.TabIndex = 0;
			button1.Text = "Новый сотрудник";
			button1.TextAlign = ContentAlignment.MiddleLeft;
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// textBox1
			// 
			textBox1.Location = new Point(7, 47);
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
			dataGridView1.Location = new Point(7, 76);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.ReadOnly = true;
			dataGridView1.RowHeadersWidth = 51;
			dataGridView1.RowTemplate.Height = 29;
			dataGridView1.Size = new Size(998, 284);
			dataGridView1.TabIndex = 2;
			// 
			// DataGridViewButtonColumn
			// 
			DataGridViewButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			DataGridViewButtonColumn.FlatStyle = FlatStyle.Popup;
			DataGridViewButtonColumn.HeaderText = "Редактировать";
			DataGridViewButtonColumn.MinimumWidth = 10;
			DataGridViewButtonColumn.Name = "DataGridViewButtonColumn";
			DataGridViewButtonColumn.ReadOnly = true;
			DataGridViewButtonColumn.Resizable = DataGridViewTriState.True;
			DataGridViewButtonColumn.Text = "edit";
			DataGridViewButtonColumn.Width = 117;
			// 
			// Delete
			// 
			Delete.HeaderText = "Удалить";
			Delete.MinimumWidth = 6;
			Delete.Name = "Delete";
			Delete.ReadOnly = true;
			Delete.Width = 50;
			// 
			// linkLabel1
			// 
			linkLabel1.AutoSize = true;
			linkLabel1.Location = new Point(925, 44);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new Size(58, 20);
			linkLabel1.TabIndex = 4;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "Refresh";
			linkLabel1.LinkClicked += linkLabel1_LinkClicked;
			// 
			// Search
			// 
			Search.Location = new Point(157, 47);
			Search.Name = "Search";
			Search.Size = new Size(94, 29);
			Search.TabIndex = 5;
			Search.Text = "Поиск";
			Search.UseVisualStyleBackColor = true;
			Search.Click += Search_Click;
			// 
			// test
			// 
			test.Location = new Point(876, 12);
			test.Name = "test";
			test.Size = new Size(118, 29);
			test.TabIndex = 6;
			test.Text = "From (.xlsx) file";
			test.TextAlign = ContentAlignment.MiddleLeft;
			test.UseVisualStyleBackColor = true;
			test.Click += test_Click;
			// 
			// button3
			// 
			button3.Location = new Point(7, 12);
			button3.Name = "button3";
			button3.Size = new Size(135, 29);
			button3.TabIndex = 7;
			button3.Text = "Подразделение";
			button3.UseVisualStyleBackColor = true;
			button3.Click += button3_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			ClientSize = new Size(1022, 378);
			Controls.Add(button3);
			Controls.Add(test);
			Controls.Add(Search);
			Controls.Add(linkLabel1);
			Controls.Add(dataGridView1);
			Controls.Add(textBox1);
			Controls.Add(button1);
			Name = "Form1";
			ShowIcon = false;
			Text = "Employee Manager";
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button button1;
		private TextBox textBox1;
		private LinkLabel linkLabel1;
		private Button Search;
		private Button test;
		private Button button3;
		private DataGridViewButtonColumn DataGridViewButtonColumn;
		private DataGridViewButtonColumn Delete;
		public DataGridView dataGridView1;
	}
}
