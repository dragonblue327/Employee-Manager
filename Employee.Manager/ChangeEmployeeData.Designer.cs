namespace Employee.Manager
{
	partial class ChangeEmployeeData
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
			label7 = new Label();
			CancelButton = new Button();
			SaveButton = new Button();
			label5 = new Label();
			label4 = new Label();
			label3 = new Label();
			label2 = new Label();
			label1 = new Label();
			Phone = new TextBox();
			Email = new TextBox();
			Position = new TextBox();
			EmployeeNumber = new TextBox();
			FullName = new TextBox();
			label6 = new Label();
			selectedDepartment = new TextBox();
			comboBox1 = new ComboBox();
			comboBox2 = new ComboBox();
			label8 = new Label();
			SuspendLayout();
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(434, 121);
			label7.Name = "label7";
			label7.Size = new Size(167, 20);
			label7.TabIndex = 32;
			label7.Text = "Новая Подразделения";
			// 
			// CancelButton
			// 
			CancelButton.BackColor = Color.FromArgb(222, 26, 51);
			CancelButton.Location = new Point(137, 382);
			CancelButton.Name = "CancelButton";
			CancelButton.Size = new Size(94, 29);
			CancelButton.TabIndex = 30;
			CancelButton.Text = "Отменить";
			CancelButton.UseVisualStyleBackColor = false;
			CancelButton.Click += CancelButton_Click;
			// 
			// SaveButton
			// 
			SaveButton.BackColor = Color.LightGreen;
			SaveButton.Location = new Point(237, 382);
			SaveButton.Name = "SaveButton";
			SaveButton.Size = new Size(94, 29);
			SaveButton.TabIndex = 29;
			SaveButton.Text = "Сохранить";
			SaveButton.UseVisualStyleBackColor = false;
			SaveButton.Click += SaveButton_Click;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(31, 213);
			label5.Name = "label5";
			label5.Size = new Size(73, 20);
			label5.TabIndex = 26;
			label5.Text = "Телефон ";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(31, 169);
			label4.Name = "label4";
			label4.Size = new Size(50, 20);
			label4.TabIndex = 25;
			label4.Text = "Email ";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(31, 113);
			label3.Name = "label3";
			label3.Size = new Size(90, 20);
			label3.TabIndex = 24;
			label3.Text = "Должность ";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(31, 60);
			label2.Name = "label2";
			label2.Size = new Size(141, 20);
			label2.TabIndex = 23;
			label2.Text = "Табельный номер ";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(31, 12);
			label1.Name = "label1";
			label1.Size = new Size(46, 20);
			label1.TabIndex = 22;
			label1.Text = "ФИО ";
			// 
			// Phone
			// 
			Phone.Location = new Point(193, 206);
			Phone.Name = "Phone";
			Phone.Size = new Size(220, 27);
			Phone.TabIndex = 21;
			// 
			// Email
			// 
			Email.Location = new Point(193, 162);
			Email.Name = "Email";
			Email.Size = new Size(220, 27);
			Email.TabIndex = 20;
			// 
			// Position
			// 
			Position.Location = new Point(193, 106);
			Position.Name = "Position";
			Position.Size = new Size(220, 27);
			Position.TabIndex = 19;
			// 
			// EmployeeNumber
			// 
			EmployeeNumber.Location = new Point(193, 57);
			EmployeeNumber.Name = "EmployeeNumber";
			EmployeeNumber.Size = new Size(220, 27);
			EmployeeNumber.TabIndex = 18;
			// 
			// FullName
			// 
			FullName.Location = new Point(193, 12);
			FullName.Name = "FullName";
			FullName.Size = new Size(220, 27);
			FullName.TabIndex = 17;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(434, 73);
			label6.Name = "label6";
			label6.Size = new Size(119, 20);
			label6.TabIndex = 34;
			label6.Text = "Подразделения";
			// 
			// selectedDepartment
			// 
			selectedDepartment.Location = new Point(615, 66);
			selectedDepartment.Name = "selectedDepartment";
			selectedDepartment.ReadOnly = true;
			selectedDepartment.Size = new Size(220, 27);
			selectedDepartment.TabIndex = 35;
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new Point(615, 113);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(220, 28);
			comboBox1.TabIndex = 36;
			// 
			// comboBox2
			// 
			comboBox2.FormattingEnabled = true;
			comboBox2.Location = new Point(615, 32);
			comboBox2.Name = "comboBox2";
			comboBox2.Size = new Size(220, 28);
			comboBox2.TabIndex = 37;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(434, 35);
			label8.Name = "label8";
			label8.Size = new Size(52, 20);
			label8.TabIndex = 38;
			label8.Text = "Статус";
			// 
			// ChangeEmployeeData
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(890, 442);
			Controls.Add(label8);
			Controls.Add(comboBox2);
			Controls.Add(comboBox1);
			Controls.Add(selectedDepartment);
			Controls.Add(label6);
			Controls.Add(label7);
			Controls.Add(CancelButton);
			Controls.Add(SaveButton);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(Phone);
			Controls.Add(Email);
			Controls.Add(Position);
			Controls.Add(EmployeeNumber);
			Controls.Add(FullName);
			Name = "ChangeEmployeeData";
			Text = "ChangeEmployeeData";
			Load += ChangeEmployeeData_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label7;
		private Button CancelButton;
		private Button SaveButton;
		private Label label5;
		private Label label4;
		private Label label3;
		private Label label2;
		private Label label1;
		private TextBox Phone;
		private TextBox Email;
		private TextBox Position;
		private TextBox EmployeeNumber;
		private TextBox FullName;
		private Label label6;
		private TextBox selectedDepartment;
		private ComboBox comboBox1;
		private ComboBox comboBox2;
		private Label label8;
	}
}