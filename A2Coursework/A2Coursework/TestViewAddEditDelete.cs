
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace A2Coursework
{
    public partial class TestViewAddEditDelete : Form
    {
        private Dictionary<int,  string> _index; // Keeps employee list for ListBox

        public TestViewAddEditDelete() // Constructor
        {
            InitializeComponent(); // Designer setup
        }

        private void TestViewAddEditDelete_Load(object sender, EventArgs e) // Form load event
        {
            //LoadStatuses(); // Load status dropdown
            //LoadEmployeeList(); // Load employees into listbox
            //ClearForm(); // Reset inputs/labels
        }

        private void LoadStatuses() // Populates status ComboBox
        {
            EmployeeDal.GetAllStatuses(); // Load statuses from DB
            cboStatus.DisplayMember = "StatusDescription"; // What user sees
            cboStatus.ValueMember = "StatusID"; // Stored value
            cboStatus.DataSource = EmploymentStatus.statuses; // Bind to combo
        }

        private void LoadEmployeeList() // Populates employee ListBox
        {
            Dictionary<int, string> myDictionary = new Dictionary<int, string>();
            foreach(Employee emp in Employee.employees)
            {
                myDictionary.Add(emp.EmployeeID, $"{emp.FullName}");
            }
            lstEmployees.DataSource = myDictionary.ToArray();
            lstEmployees.DisplayMember = "Value"; 
            lstEmployees.ValueMember = "Key";

            lstEmployees.SelectedIndex = 0;
        }

        private void LoadEmployeeToViewAndEdit(int id) // Loads employee into labels + inputs
        {
            Employee emp = EmployeeDal.GetEmployeeById(id); // Load from DB

            
            lblId.Text = emp.EmployeeID.ToString(); // Show ID
            lblName.Text = emp.FirstName + " " + emp.Surname; // Show name
            lblEmail.Text = emp.Email; // Show email
            lblPhone.Text = emp.TelephoneNo; // Show phone
            lblSalary.Text = emp.Salary.ToString("0.00"); // Show salary
            lblStreetAddress.Text = emp.StreetAddress; // Show address

            cboStatus.SelectedValue = emp.Status.StatusID; // Set combo to correct status
            lblStatus.Text = cboStatus.Text; // Display status description

           
            txtFirstName.Text = emp.FirstName; // Fill first name
            txtSurname.Text = emp.Surname; // Fill surname
            txtGender.Text = emp.Gender; // Fill gender
            txtStreetAddress.Text = emp.StreetAddress; // Fill address
            dtpDOB.Value = emp.DateOfBirth; // Fill DOB
            txtEmail.Text = emp.Email; // Fill email
            txtTelephone.Text = emp.TelephoneNo; // Fill phone
            txtUsername.Text = emp.Username; // Fill username
            txtPassword.Text = emp.Password; // Fill password
            dtpHired.Value = emp.DateHired; // Fill hired date
            txtSalary.Text = emp.Salary.ToString("0.00"); // Fill salary
        }

        private void btnAdd_Click(object sender, EventArgs e) // Add new employee
        {
            try
            {
                Employee emp = ReadEmployeeFromInputs(); // Read inputs into Employee object
                int newId = EmployeeDal.AddEmployee(emp); 

                LoadEmployeeList(); // Refresh listbox
                SelectEmployeeById(newId); // Select new employee
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Failed"); // Show error
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e) // Update selected employee
        {
            try
            {
                if (lstEmployees.SelectedValue == null) throw new Exception("Select an employee to update."); // Validation

                int id = (int)lstEmployees.SelectedValue; // Selected employee ID
                Employee emp = ReadEmployeeFromInputs(); 
                
                EmployeeDal.UpdateEmployee(emp); 

                LoadEmployeeList(); // Refresh listbox
                SelectEmployeeById(id); // Re-select same employee
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Failed"); // Show error
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) 
        {
            try
            {
                if (lstEmployees.SelectedValue == null) throw new Exception("Select an employee to delete."); 

                int id = (int)lstEmployees.SelectedValue; // Selected ID

                var result = MessageBox.Show("Delete this employee?", "Confirm Delete", MessageBoxButtons.YesNo); 
                if (result != DialogResult.Yes) return; // Stop if no

                EmployeeDal.DeleteEmployee(id); // Delete from DB

                LoadEmployeeList(); // Refresh listbox
                ClearForm(); // Clear fields
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Failed"); // Show error
            }
        }

        private void btnClear_Click(object sender, EventArgs e) // Clear inputs (useful before Add)
        {
            ClearForm(); // Reset fields for new add
            lstEmployees.ClearSelected(); // Unselect list item
        }

        private void btnRefresh_Click(object sender, EventArgs e) 
        {
            ClearForm();
            int id = (int)lstEmployees.SelectedValue;
            LoadEmployeeToViewAndEdit(id); 
            LoadEmployeeList(); 
        }

        private Employee ReadEmployeeFromInputs() // Reads and validates inputs
        {
           

            decimal salary; 
            if (!decimal.TryParse(txtSalary.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out salary))
                throw new Exception("Salary must be a number."); 

            var emp = new Employee(); 
            emp.FirstName = txtFirstName.Text.Trim(); 
            emp.Surname = txtSurname.Text.Trim(); 
            emp.Gender = txtGender.Text.Trim(); 
            emp.StreetAddress = txtStreetAddress.Text.Trim(); 
            emp.DateOfBirth = dtpDOB.Value.Date; 
            emp.Email = txtEmail.Text.Trim(); 
            emp.TelephoneNo = txtTelephone.Text.Trim(); 
            emp.Username = txtUsername.Text.Trim(); 
            emp.Password = txtPassword.Text; 
            emp.DateHired = dtpHired.Value.Date; 
            emp.Salary = salary;
             

            return emp; // Return object
        }

        private void ClearForm() 
        {
            
            lblId.Text = ""; 
            lblName.Text = ""; 
            lblEmail.Text = ""; // Clear email label
            lblPhone.Text = ""; // Clear phone label
            lblStatus.Text = ""; // Clear status label
            lblSalary.Text = ""; // Clear salary label
            lblStreetAddress.Text = ""; // Clear address label

            // Clear edit inputs
            txtFirstName.Text = ""; // Clear first name
            txtSurname.Text = ""; // Clear surname
            txtGender.Text = ""; // Clear gender
            txtStreetAddress.Text = ""; // Clear address
            dtpDOB.Value = DateTime.Today; // Reset DOB
            txtEmail.Text = ""; // Clear email
            txtTelephone.Text = ""; // Clear telephone
            txtUsername.Text = ""; // Clear username
            txtPassword.Text = ""; // Clear password
            dtpHired.Value = DateTime.Today; // Reset hired date
            txtSalary.Text = ""; // Clear salary

            if (cboStatus.Items.Count > 0) cboStatus.SelectedIndex = 0; // Reset status selection
        }

        private void SelectEmployeeById(int employeeId) // Selects employee after add/update
        {
            for (int i = 0; i < Employee.employees.Count; i++) // Loop list items
            {
                if (Employee.employees[i].EmployeeID == employeeId) // Find matching ID
                {
                    lstEmployees.SelectedIndex = i; // Select it
                    break; // Stop loop
                }
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadStatuses(); 
            LoadEmployeeList(); 
            ClearForm(); 
        }

        private void lstEmployees_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
            if (lstEmployees.SelectedValue != null)
            {
                try
                {
                    int id = (int)lstEmployees.SelectedValue; 
                    LoadEmployeeToViewAndEdit(id); 
                }
                catch { }
            }  
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            string Fname = tbxFirstName.Text;
            string Lname = tbxSurname.Text;
            string username = Fname[0] + Lname;
            Employee employee = new Employee();
            int ID = ((ushort)employee.EmployeeID); //*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/**/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/


                
            username = username + ID;
            lblUsername.Text = username;

            

        }
    }
}
