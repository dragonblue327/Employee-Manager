namespace Employee.Manager
{
	partial class Departments
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
			dataGridView1 = new DataGridView();
			DataGridViewButtonColumn = new DataGridViewButtonColumn();
			Delete = new DataGridViewButtonColumn();
			Search = new Button();
			textBox1 = new TextBox();
			button2 = new Button();
			button1 = new Button();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// dataGridView1
			// 
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Columns.AddRange(new DataGridViewColumn[] { DataGridViewButtonColumn, Delete });
			dataGridView1.GridColor = Color.White;
			dataGridView1.Location = new Point(12, 91);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.ReadOnly = true;
			dataGridView1.RowHeadersWidth = 51;
			dataGridView1.RowTemplate.Height = 29;
			dataGridView1.Size = new Size(776, 220);
			dataGridView1.TabIndex = 3;
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
			// Search
			// 
			Search.Location = new Point(162, 58);
			Search.Name = "Search";
			Search.Size = new Size(94, 29);
			Search.TabIndex = 7;
			Search.Text = "Поиск";
			Search.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			textBox1.Location = new Point(12, 58);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(153, 27);
			textBox1.TabIndex = 6;
			// 
			// button2
			// 
			button2.Location = new Point(12, 23);
			button2.Name = "button2";
			button2.Size = new Size(192, 29);
			button2.TabIndex = 8;
			button2.Text = "Создать подразделение";
			button2.TextAlign = ContentAlignment.MiddleLeft;
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// button1
			// 
			button1.Location = new Point(694, 317);
			button1.Name = "button1";
			button1.Size = new Size(94, 29);
			button1.TabIndex = 9;
			button1.Text = "Назад =>";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// Departments
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			ClientSize = new Size(800, 347);
			Controls.Add(button1);
			Controls.Add(button2);
			Controls.Add(Search);
			Controls.Add(textBox1);
			Controls.Add(dataGridView1);
			Name = "Departments";
			ShowIcon = false;
			Text = "Departments";
			Load += Departments_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView dataGridView1;
		private DataGridViewButtonColumn DataGridViewButtonColumn;
		private DataGridViewButtonColumn Delete;
		private Button Search;
		private TextBox textBox1;
		private Button button2;
		private Button button1;
	}
}