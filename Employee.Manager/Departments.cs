using Employee.Application.Interfaces;
using Employee.Application.IServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee.Manager
{
	public partial class Departments : Form
	{
		private readonly IDepartmentService _departmentService;
		private readonly IEmployeeService _employeeService;
		public Departments(IEmployeeService employeeService, IDepartmentService departmentService)
		{
			InitializeComponent();
			_employeeService = employeeService;
			_departmentService = departmentService;
		}

		private async void Departments_Load(object sender, EventArgs e)
		{
			await LoadDataAsync();
			dataGridView1.CellClick += dataGridView1_CellClick;
		}
		private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{


			if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
			{

				var selectedRow = dataGridView1.Rows[e.RowIndex];
				var idValue = Convert.ToInt32(selectedRow.Cells["Id"].Value);
				var NameValue = selectedRow.Cells["Name"].Value;
				var result = MessageBox.Show("Вы уверены, что хотите удалить " + NameValue + "?", "Подтверждать удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (result == DialogResult.Yes)
				{
					await _departmentService.DeleteAsync(idValue);
					MessageBox.Show("Подразделения успешно удалена.", "удалить", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadDataAsync();
				}
				else
				{
					MessageBox.Show("удаление подразделения отменена.", "удалить", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}
		public async Task LoadDataAsync()
		{
			try
			{
				var departments = await _departmentService.GetAllAsync();

				dataGridView1.DataSource = departments.ToList();
				dataGridView1.Columns["Id"].Visible = false;
				dataGridView1.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred: {ex.Message}");
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			var form2 = new NewDepartment(_employeeService, _departmentService);
			form2.Show();
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var form2 = new Form1(_employeeService, _departmentService);
			form2.Show();
			this.Close();
		}
	}
}
