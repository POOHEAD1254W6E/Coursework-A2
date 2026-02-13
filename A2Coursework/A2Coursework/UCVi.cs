using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A2Coursework
{
    public partial class UCVi : UserControl
    {
        
        public static int CurrentEmployeeID;
        public static UCVi instance;
        private bool IsAdmin => Employee.employees[Employee.currentEmployee].Status.StatusID == 3;
        public UCVi()
        {
            
            InitializeComponent();
            instance = this;
            DisplayEmployees();
            
        }

        private void UCVi_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        private void DisplayEmployees()
        {
            TbxFirstName.Visible = false;
            TbxSurname.Visible = false;
            TbxPhoneNo.Visible = false;
            TbxEmail.Visible = false;
            TbxStreetAddress.Visible = false;
            TbxUsername.Visible = false;
            TbxPassword.Visible = false;
            TbxSalary.Visible = false;
            CbxStatus.Visible = false;

            ChxFemale.Visible = false;
            ChxMale.Visible = false;
            

            var emp = EmployeeDal.GetEmployeeById(CurrentEmployeeID);
            lblFirstName.Text = $"First name: {emp.FirstName}";
            LblSurname.Text = $"Surname: {emp.Surname}";
            lblGender.Text = $"Gender: {emp.Gender}";
            lblAddress.Text = $"Address: {emp.StreetAddress}";
            lblEmail.Text = $"Email: {emp.Email}";
            dtpDOB.Value = emp.DateOfBirth;
            LblPhoneNumber.Text = $"Phone Number: {emp.TelephoneNo}";
            lblUsername.Text= $"Username: {emp.Username}";
            LblPassword.Text = $"Password: ********";
            LblSalary.Text = $"Salary: {emp.Salary}";
            if (Employee.employees[Employee.currentEmployee].Status.StatusID == 3)
            {
                LblPassword.Text = $"Password: {emp.Password}";
            }
            Employee employee = new Employee();
            string Status = employee.GetStatusDesc(emp.Status.StatusID);
            LblStatus.Text = $"Status: {Status}";
            DTPdateHired.Value = emp.DateHired;

        }

        private void LoadStatuses()
        {
            EmployeeDal.GetAllStatuses();
            CbxStatus.DisplayMember = "StatusDescription";
            CbxStatus.ValueMember = "StatusID";
            CbxStatus.DataSource = EmploymentStatus.statuses;
        }
     
        private void ChangeEditUI()
        {
            TbxFirstName.Visible = true;
            TbxSurname.Visible =   true;
            TbxPhoneNo.Visible = true;
            TbxEmail.Visible = true;
            TbxStreetAddress.Visible = true;

            ChxFemale.Visible = true;
            ChxMale.Visible = true;
            
            lblFirstName.Text = $"First name:";
            LblSurname.Text = $"Surname:";
            lblGender.Text = $"Gender:";
            lblAddress.Text = $"Address:";
            lblEmail.Text = $"Email:";
            LblPhoneNumber.Text = $"Phone Number:";

            var emp = EmployeeDal.GetEmployeeById(CurrentEmployeeID);
            TbxFirstName.Text = emp.FirstName;
            TbxSurname.Text = emp.Surname;
            TbxEmail.Text = emp.Email;
            TbxPhoneNo.Text = emp.TelephoneNo;
            TbxStreetAddress.Text = emp.StreetAddress;
            dtpDOB.Value = emp.DateOfBirth;
            DTPdateHired.Value = emp.DateHired;
            TbxUsername.Text = emp.Username;
            TbxPassword.Text = emp.Password;
            TbxSalary.Text = emp.Salary.ToString();
            CbxStatus.SelectedValue = emp.Status.StatusDescription;

            if (IsAdmin)
            {
                TbxUsername.Visible = true;
                TbxPassword.Visible = true;
                TbxSalary.Visible = true;
                CbxStatus.Visible = true;

                lblUsername.Text = "Username: ";
                LblPassword.Text = "Password: ";
                LblSalary.Text = "Salary: ";
                LblStatus.Text = "Status: ";

                TbxUsername.Text = emp.Username;
                TbxPassword.Text = emp.Password;
                TbxSalary.Text = emp.Salary.ToString();
                LoadStatuses();
                CbxStatus.SelectedValue = emp.Status.StatusID;
                
                
            }
            if (emp.Gender == "Male")
            {
                ChxMale.Checked = true;
            }
            else
            {
                ChxFemale.Checked = true;
            }
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            ChangeEditUI();
            BtnEdit.Visible = false;
            BtnConfirm.Visible = true;
        }
        private Employee ReadInputs()
        {
            var emp = EmployeeDal.GetEmployeeById(CurrentEmployeeID);
            emp.FirstName = TbxFirstName.Text.Trim();
            emp.Surname = TbxSurname.Text.Trim();
            emp.StreetAddress = TbxStreetAddress.Text.Trim();
            emp.Email = TbxEmail.Text.Trim();
            emp.TelephoneNo = TbxPhoneNo.Text.Trim();
            emp.DateOfBirth = dtpDOB.Value;
            if (ChxMale.Checked == true)
            {
                emp.Gender = "Male";
            }
            else
            {
                emp.Gender = "Female";
            }

            if (IsAdmin)
            {
                emp.Username = TbxUsername.Text.Trim();
                emp.Password = TbxPassword.Text.Trim();
                emp.Salary = Convert.ToDecimal(TbxSalary.Text);
                emp.Status.StatusID = Convert.ToInt32(CbxStatus.SelectedValue);
                emp.DateHired = DTPdateHired.Value;
            }
          
          

                return emp;
            
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Delete this employee?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) return; 
            var emp = EmployeeDal.GetEmployeeById(CurrentEmployeeID);
            bool success = true;
            try
            {
                EmployeeDal.DeleteEmployee(emp.Status.StatusID);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
                success = false;
            }
            if (success)
            {
                MessageBox.Show("Employee successfully deleted.");
                UCViewEmployee viewEmployee = new UCViewEmployee();
                EmployeeDal.GetEmployees();
                MainMenu.instance.ChildUserControls(viewEmployee); 
            }
           
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            
            Employee emp = ReadInputs();
            EmployeeDal.UpdateEmployee(emp);
            EmployeeDal.GetEmployees();
            BtnConfirm.Visible=false;
            BtnEdit.Visible=true;
            DisplayEmployees();


        }
    }
}
