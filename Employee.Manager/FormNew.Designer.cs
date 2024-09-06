namespace Employee.Manager
{
	partial class FormNew
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
			FullName = new TextBox();
			EmployeeNumber = new TextBox();
			Position = new TextBox();
			Email = new TextBox();
			Phone = new TextBox();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			label6 = new Label();
			HireDate = new DateTimePicker();
			SaveButton = new Button();
			CancelButton = new Button();
			comboBox1 = new ComboBox();
			label7 = new Label();
			SuspendLayout();
			// 
			// FullName
			// 
			FullName.Location = new Point(200, 45);
			FullName.Name = "FullName";
			FullName.Size = new Size(125, 27);
			FullName.TabIndex = 0;
			// 
			// EmployeeNumber
			// 
			EmployeeNumber.Location = new Point(200, 90);
			EmployeeNumber.Name = "EmployeeNumber";
			EmployeeNumber.Size = new Size(125, 27);
			EmployeeNumber.TabIndex = 1;
			// 
			// Position
			// 
			Position.Location = new Point(200, 139);
			Position.Name = "Position";
			Position.Size = new Size(125, 27);
			Position.TabIndex = 2;
			// 
			// Email
			// 
			Email.Location = new Point(200, 195);
			Email.Name = "Email";
			Email.Size = new Size(125, 27);
			Email.TabIndex = 3;
			// 
			// Phone
			// 
			Phone.Location = new Point(200, 239);
			Phone.Name = "Phone";
			Phone.Size = new Size(125, 27);
			Phone.TabIndex = 4;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(38, 45);
			label1.Name = "label1";
			label1.Size = new Size(46, 20);
			label1.TabIndex = 6;
			label1.Text = "ФИО ";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(38, 97);
			label2.Name = "label2";
			label2.Size = new Size(141, 20);
			label2.TabIndex = 7;
			label2.Text = "Табельный номер ";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(38, 146);
			label3.Name = "label3";
			label3.Size = new Size(90, 20);
			label3.TabIndex = 8;
			label3.Text = "Должность ";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(41, 202);
			label4.Name = "label4";
			label4.Size = new Size(50, 20);
			label4.TabIndex = 9;
			label4.Text = "Email ";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(41, 247);
			label5.Name = "label5";
			label5.Size = new Size(73, 20);
			label5.TabIndex = 10;
			label5.Text = "Телефон ";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(41, 292);
			label6.Name = "label6";
			label6.Size = new Size(103, 20);
			label6.TabIndex = 11;
			label6.Text = "Дата приема ";
			// 
			// HireDate
			// 
			HireDate.CalendarTrailingForeColor = SystemColors.GradientActiveCaption;
			HireDate.Format = DateTimePickerFormat.Short;
			HireDate.Location = new Point(200, 292);
			HireDate.MaxDate = new DateTime(2025, 12, 31, 0, 0, 0, 0);
			HireDate.MinDate = new DateTime(2024, 9, 5, 0, 0, 0, 0);
			HireDate.Name = "HireDate";
			HireDate.Size = new Size(125, 27);
			HireDate.TabIndex = 12;
			// 
			// SaveButton
			// 
			SaveButton.BackColor = Color.LightGreen;
			SaveButton.Location = new Point(273, 443);
			SaveButton.Name = "SaveButton";
			SaveButton.Size = new Size(94, 29);
			SaveButton.TabIndex = 13;
			SaveButton.Text = "Сохранить";
			SaveButton.UseVisualStyleBackColor = false;
			SaveButton.Click += SaveButton_Click;
			// 
			// CancelButton
			// 
			CancelButton.BackColor = Color.FromArgb(222, 26, 51);
			CancelButton.Location = new Point(173, 443);
			CancelButton.Name = "CancelButton";
			CancelButton.Size = new Size(94, 29);
			CancelButton.TabIndex = 14;
			CancelButton.Text = "Отменить";
			CancelButton.UseVisualStyleBackColor = false;
			CancelButton.Click += CancelButton_Click;
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new Point(200, 334);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(151, 28);
			comboBox1.TabIndex = 15;
			comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(41, 342);
			label7.Name = "label7";
			label7.Size = new Size(119, 20);
			label7.TabIndex = 16;
			label7.Text = "Подразделение";
			// 
			// FormNew
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			ClientSize = new Size(400, 484);
			Controls.Add(label7);
			Controls.Add(comboBox1);
			Controls.Add(CancelButton);
			Controls.Add(SaveButton);
			Controls.Add(HireDate);
			Controls.Add(label6);
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
			Name = "FormNew";
			ShowIcon = false;
			Text = "FormNew";
			Load += FormNew_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox FullName;
		private TextBox EmployeeNumber;
		private TextBox Position;
		private TextBox Email;
		private TextBox Phone;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private Label label6;
		private DateTimePicker HireDate;
		private Button SaveButton;
		private Button CancelButton;
		private ComboBox comboBox1;
		private Label label7;
	}
}