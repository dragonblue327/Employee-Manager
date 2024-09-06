namespace Employee.Manager
{
	partial class NewDepartment
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
			DepartmentName = new TextBox();
			label1 = new Label();
			CancelButton = new Button();
			SaveButton = new Button();
			comboBox1 = new ComboBox();
			checkedListBox1 = new CheckedListBox();
			IsChild = new CheckBox();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			comboBox2 = new ComboBox();
			SuspendLayout();
			// 
			// DepartmentName
			// 
			DepartmentName.Location = new Point(146, 16);
			DepartmentName.Name = "DepartmentName";
			DepartmentName.Size = new Size(277, 27);
			DepartmentName.TabIndex = 0;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 19);
			label1.Name = "label1";
			label1.Size = new Size(120, 20);
			label1.TabIndex = 1;
			label1.Text = "Наименование ";
			// 
			// CancelButton
			// 
			CancelButton.BackColor = Color.FromArgb(222, 26, 51);
			CancelButton.Location = new Point(599, 213);
			CancelButton.Name = "CancelButton";
			CancelButton.Size = new Size(94, 29);
			CancelButton.TabIndex = 15;
			CancelButton.Text = "Отменить";
			CancelButton.UseVisualStyleBackColor = false;
			CancelButton.Click += CancelButton_Click;
			// 
			// SaveButton
			// 
			SaveButton.BackColor = Color.LightGreen;
			SaveButton.Location = new Point(715, 213);
			SaveButton.Name = "SaveButton";
			SaveButton.Size = new Size(94, 29);
			SaveButton.TabIndex = 16;
			SaveButton.Text = "Сохранить";
			SaveButton.UseVisualStyleBackColor = false;
			SaveButton.Click += SaveButton_Click;
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new Point(438, 45);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(372, 28);
			comboBox1.TabIndex = 17;
			comboBox1.Visible = false;
			// 
			// checkedListBox1
			// 
			checkedListBox1.FormattingEnabled = true;
			checkedListBox1.Location = new Point(146, 59);
			checkedListBox1.Name = "checkedListBox1";
			checkedListBox1.Size = new Size(277, 114);
			checkedListBox1.TabIndex = 18;
			// 
			// IsChild
			// 
			IsChild.AutoSize = true;
			IsChild.Location = new Point(792, 22);
			IsChild.Name = "IsChild";
			IsChild.Size = new Size(18, 17);
			IsChild.TabIndex = 19;
			IsChild.UseVisualStyleBackColor = true;
			IsChild.CheckedChanged += IsChild_CheckedChanged;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(438, 16);
			label2.Name = "label2";
			label2.Size = new Size(231, 20);
			label2.TabIndex = 20;
			label2.Text = "Есть головное подразделение ?";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(12, 59);
			label3.Name = "label3";
			label3.Size = new Size(95, 20);
			label3.TabIndex = 21;
			label3.Text = "Сотрудники ";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(438, 91);
			label4.Name = "label4";
			label4.Size = new Size(108, 20);
			label4.TabIndex = 22;
			label4.Text = "Руководитель ";
			// 
			// comboBox2
			// 
			comboBox2.FormattingEnabled = true;
			comboBox2.Location = new Point(438, 114);
			comboBox2.Name = "comboBox2";
			comboBox2.Size = new Size(372, 28);
			comboBox2.TabIndex = 23;
			// 
			// NewDepartment
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			ClientSize = new Size(821, 251);
			Controls.Add(comboBox2);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(IsChild);
			Controls.Add(checkedListBox1);
			Controls.Add(comboBox1);
			Controls.Add(SaveButton);
			Controls.Add(CancelButton);
			Controls.Add(label1);
			Controls.Add(DepartmentName);
			Name = "NewDepartment";
			ShowIcon = false;
			Text = "NewDepartment";
			Load += NewDepartment_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox DepartmentName;
		private Label label1;
		private Button CancelButton;
		private Button SaveButton;
		private ComboBox comboBox1;
		private CheckedListBox checkedListBox1;
		private CheckBox IsChild;
		private Label label2;
		private Label label3;
		private Label label4;
		private ComboBox comboBox2;
	}
}