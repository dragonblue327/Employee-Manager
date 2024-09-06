
using Employee.Application.Interfaces;
using Employee.Application.IServices;

namespace Employee.Manager
{
	public partial class Form1 : Form
	{
		private readonly IEmployeeService _employeeService;
		private readonly IDepartmentService _departmentService;
		public Form1(IEmployeeService employeeService, IDepartmentService departmentService)
		{
			InitializeComponent();
			_employeeService = employeeService;
			_departmentService = departmentService;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			LoadDataAsync();

			dataGridView1.CellClick += dataGridView1_CellClick;
		}
		private async Task LoadDataAsync()
		{
			try
			{
				var employees = await _employeeService.GetAllAsync();

				dataGridView1.DataSource = employees.ToList();
				if (!dataGridView1.Columns.Contains("DepartmentNames"))
					dataGridView1.Columns["DepartmentNames"].DataPropertyName = "DepartmentNames";
				dataGridView1.Columns["Departments"].Visible = false;
				dataGridView1.Columns["Id"].Visible = false;
				dataGridView1.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred: {ex.Message}");
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var form2 = new FormNew(_employeeService, _departmentService);
			
			form2.Show();
			this.Hide();

		}

		private void button2_Click(object sender, EventArgs e)
		{
			var form2 = new NewDepartment(_employeeService, _departmentService);
			form2.Show();
			this.Close();
		}
		private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{

			if (e.ColumnIndex == dataGridView1.Columns["DataGridViewButtonColumn"].Index && e.RowIndex >= 0)
			{

				var selectedRow = dataGridView1.Rows[e.RowIndex];
				var idValue = Convert.ToInt32(selectedRow.Cells["Id"].Value);
				var NameValue = selectedRow.Cells["FullName"].Value;

				Form newForm = new ChangeEmployeeData(_employeeService, _departmentService, idValue);
				newForm.Text = $"Edit employee: {NameValue}";
				newForm.Show();
			}
			if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
			{

				var selectedRow = dataGridView1.Rows[e.RowIndex];
				var idValue = Convert.ToInt32(selectedRow.Cells["Id"].Value);
				var NameValue = selectedRow.Cells["FullName"].Value;
				var result = MessageBox.Show("Вы уверены, что хотите удалить " + NameValue + "?", "Подтверждать удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (result == DialogResult.Yes)
				{
					await _employeeService.DeleteAsync(idValue);
					MessageBox.Show("сотрудник успешно удален.", "удалить", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadDataAsync();
				}
				else
				{
					MessageBox.Show("удаление сотрудника отменено.", "удалить", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			LoadDataAsync();
		}

		private void Search_Click(object sender, EventArgs e)
		{
			string searchValue = textBox1.Text.ToLower();
			dataGridView1.CurrentCell = null;
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				bool rowVisible = false;
				foreach (DataGridViewCell cell in row.Cells)
				{
					if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchValue))
					{
						rowVisible = true;
						break;
					}
				}
				row.Visible = rowVisible;
			}
		}
		private async Task openDialog()
		{
			using (FileDialog fileDialog = new OpenFileDialog())
			{
				if (DialogResult.OK == fileDialog.ShowDialog())
				{
					string fileName = fileDialog.FileName;
					_employeeService.SaveDataFromExcelFileAsync(fileName);
				}
			}
		}
		private async void test_Click(object sender, EventArgs e)
		{
			await openDialog();
		}

		private async void button3_Click(object sender, EventArgs e)
		{
			var form2 = new Departments(_employeeService, _departmentService);
			await form2.LoadDataAsync();
			form2.Show();
			this.Hide();
		}
	}
}
