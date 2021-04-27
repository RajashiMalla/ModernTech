using Moderntech.SOurce;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moderntech.USerInterface
{
    public partial class Employeelistform : Form
    {
        public Employeelistform()
        {
            InitializeComponent();
        }
        public string Employeename = string.Empty;
        public string UserName = string.Empty;
        public string Email = string.Empty;
        public string Password = string.Empty;
        public string PasswordSalt = string.Empty;
        public string Contact = string.Empty;
        public string RoleId = string.Empty;
        public string CreateDate = string.Empty;
        public bool IsActive = false;
        public bool IsApproved = false;
        public bool IsLockedout = false;
        public bool IsSystemGenerated = false;


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            EmployeeAddForm employeeAddForm = new EmployeeAddForm();
            this.Hide();
            employeeAddForm.Show();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Employeelistform_Load(object sender, EventArgs e)
        {
            EmployeeDataLogic projectDataLogic = new EmployeeDataLogic();
            DataTable dataTable = new DataTable();
            dataTable = projectDataLogic.GetEmployeeList();
            dataGridViewEmployee.DataSource = dataTable;
            this.ControlBox = false;
        }

        private void dataGridViewEmployee_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int employeeId = int.Parse(dataGridViewEmployee.Rows[rowIndex].Cells[0].Value.ToString());
            EmployeeDataLogic employeeDataLogic = new EmployeeDataLogic();
            
            
            bool result = employeeDataLogic.GetEmployeeInfo(employeeId, out Employeename, out IsActive, out IsSystemGenerated , out UserName, out Email, out Password,out PasswordSalt, out Contact, out RoleId, out date, out IsApproved, out IsLockedout);
            if (result == true)
            {
                EmployeeAddForm employeeAddForm = new EmployeeAddForm()
                {
                    MdiParent = this.Parent.FindForm()
                };
                employeeAddForm.projectName = projectName;
                employeeAddForm.projectDescription = projectDescription;
                employeeAddForm.isActive = IsActive;
                employeeAddForm.isSystemGenerated = isSystemGenerated;
                employeeAddForm.projectId = projectId;
                this.Hide();
                employeeAddForm.Show();
            }
            else
            {

                MessageBox.Show("No Valid Information Found!", "Error!");
            }
        }
    }
}
