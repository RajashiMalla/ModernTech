using Moderntech.Helper;
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
    public partial class EmployeeAddForm : Form
    {
        public EmployeeAddForm()
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
        public int EmployeeId;

        private void EmployeeAddForm_Load(object sender, EventArgs e)
        {
            List<Isactive> dropDownActivities = new List<Isactive>();
            dropDownActivities.Add(new Isactive()
            {
                Value = 1,
                Text = "Is Active"
            });
            dropDownActivities.Add(new Isactive()
            {
                Value = 0,
                Text = "Not Active"
            });
            comboBoxIsActive.DataSource = dropDownActivities;
            comboBoxIsActive.DisplayMember = "Text";
            comboBoxIsActive.ValueMember = "Value";

            List<IsLockedOut> yesorno = new List<IsLockedOut>();
            yesorno.Add(new IsLockedOut()
            {
                Value = 1,
                Text = "Yes"
            });
            yesorno.Add(new IsLockedOut()
            {
                Value = 0,
                Text = "No"
            });
            comboBoxLockedOut.DataSource = yesorno;
            comboBoxLockedOut.DisplayMember = "Text";
            comboBoxLockedOut.ValueMember = "Value";

            List<IsApproved> approval = new List<IsApproved>();
            approval.Add(new IsApproved()
            {
                Value = 1,
                Text = "Yes"
            });
            approval.Add(new IsApproved()
            {
                Value = 0,
                Text = "No"
            });
            comboBoxApproved.DataSource = approval;
            comboBoxApproved.DisplayMember = "Text";
            comboBoxApproved.ValueMember = "Value";
            textBoxFullName.Text = Employeename;
            textBoxContact.Text = Contact;
            textBoxDate.Text = CreateDate;
            textBoxEmail.Text = Email;
            textBoxRollId.Text = RoleId;
            textBoxUserName.Text = UserName;
            textBoxPassword.Text = Password;
            textBoxPasswordSalt.Text = PasswordSalt;

            if (!string.IsNullOrEmpty(Employeename))
            {
                buttonSave.Enabled = false;
            }
            else
            {
                buttonUpdate.Enabled = false;
            }


        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            EmployeeDataLogic employeeDataLogic = new EmployeeDataLogic();
            Employeename = textBoxFullName.Text.Trim();
            Contact = textBoxContact.Text.Trim();
            Email = textBoxEmail.Text.Trim();
            RoleId = textBoxRollId.Text.Trim();
            UserName = textBoxUserName.Text.Trim();
            Password = textBoxPassword.Text.Trim();
            PasswordSalt = textBoxPasswordSalt.Text.Trim();
            CreateDate = textBoxDate.Text.Trim();
            string isactive = comboBoxIsActive.SelectedValue.ToString();
            IsActive = isactive == "0" ? false : true;
            string isapproved = comboBoxApproved.SelectedValue.ToString();
            IsApproved = isapproved == "0" ? false : true;
            string islockedout = comboBoxLockedOut.SelectedValue.ToString();
            IsLockedout = islockedout == "0" ? false : true;
            bool result = employeeDataLogic.AddEmployee(Employeename, Contact, Email, RoleId, IsActive, UserName, Password, PasswordSalt, CreateDate, IsApproved, IsLockedout, IsSystemGenerated);
            if (result == true)
            {
                MessageBox.Show("Success!");
                Employeelistform employeeListForm = new Employeelistform();
                this.Hide();
                employeeListForm.Show();
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            EmployeeDataLogic employeeDataLogic = new EmployeeDataLogic();
            Employeename = textBoxFullName.Text.Trim();
            Contact = textBoxContact.Text.Trim();
            Email = textBoxEmail.Text.Trim();
            RoleId = textBoxRollId.Text.Trim();
            UserName = textBoxUserName.Text.Trim();
            Password = textBoxPassword.Text.Trim();
            PasswordSalt = textBoxPasswordSalt.Text.Trim();
            CreateDate = textBoxDate.Text.Trim();
            string isactive = comboBoxIsActive.SelectedValue.ToString();
            IsActive = isactive == "0" ? false : true;
            string isapproved = comboBoxApproved.SelectedValue.ToString();
            IsApproved = isapproved == "0" ? false : true;
            string islockedout = comboBoxLockedOut.SelectedValue.ToString();
            IsLockedout = islockedout == "0" ? false : true;
            bool result = employeeDataLogic.UpdateEmployee(employeeId,Employeename, Contact, Email, RoleId, IsActive, UserName, Password, PasswordSalt, CreateDate, IsApproved, IsLockedout, IsSystemGenerated);
            if (result == true)
            {
                MessageBox.Show("Success!");
                Employeelistform employeeListForm = new Employeelistform();
                this.Hide();
                employeeListForm.Show();
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }
    }
}
