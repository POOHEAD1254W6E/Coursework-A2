using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A2Coursework
{
    public partial class UCaddEmployee : UserControl
    {
        public decimal salary;
        public string username;
        public string gender;
        public UCaddEmployee()
        {
            InitializeComponent();
            LoadStatuses();
        }

        private void CbxMale_CheckStateChanged(object sender, EventArgs e)
        {
            if (CbxMale.Checked && CbxFemale.Checked) 
            { 
                CbxFemale.Checked = false;
            }
        }
        private void LoadStatuses() 
        {
            EmployeeDal.GetAllStatuses(); 
            CbxStatus.DisplayMember = "StatusDescription";
            CbxStatus.ValueMember = "StatusID"; 
            CbxStatus.DataSource = EmploymentStatus.statuses; 
        }
        private void CbxFemale_CheckStateChanged(object sender, EventArgs e)
        {
            if (CbxMale.Checked && CbxFemale.Checked)
            {
                CbxMale.Checked = false;
            }
        }

        private void CbxMale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TbxFirstName_TextChanged(object sender, EventArgs e)
        {

            GenerateUsername(TbxFirstName.Text.ToLower(), TbxSurname.Text.ToLower());



        }
        private void GenerateUsername(string firstname, string surname)
        {
            
            int ID = Employee.employees.Count + 1;
            string UserNumber = "";
           if (ID < 10)
            {
                UserNumber = "00"+ID.ToString();
            }
           if (ID > 10)
            {
                UserNumber = "0"+ID.ToString();
            }
            if (ID > 100)
            {
                UserNumber = ID.ToString();
            }
            if (!string.IsNullOrEmpty(firstname) && !string.IsNullOrEmpty(surname))
            {
                username = firstname[0] + surname + UserNumber;
                lblUsername.Text= $"Username: {username}";
            }
        }
        private void TbxSurname_TextChanged(object sender, EventArgs e)
        {

            GenerateUsername(TbxFirstName.Text, TbxSurname.Text);
        }
        private bool DataCheck()
        {
            bool NoError = true;
            List<string> Errors = new List<string>();
            Errors.Clear();
            if (TbxFirstName.Text.Trim().Length == 0) 
            {
                Errors.Add("Please enter a first name.\n");
                pictureBox1.Visible = true;
                NoError = false;
            }
            else
            {
                pictureBox1.Visible = false;
            }
            if (TbxSurname.Text.Trim().Length == 0)
            {
                Errors.Add("Please enter a surname.\n");
                pictureBox2.Visible = true;
                NoError = false;
            }
            else
            {
                pictureBox2.Visible = false;
            }

            if (CbxMale.Checked == true)
            {
                gender = "Male";
                pictureBox3.Visible = false;
            }
            if (CbxFemale.Checked == true) 
            {
                gender = "Female";
                pictureBox3.Visible = false;
            }
            if (CbxMale.Checked == false && CbxFemale.Checked == false)
            {
                Errors.Add("Please select a gender.\n");
                pictureBox3.Visible = true;
                NoError = false;
                                   
            }
            if (TbxStreetAdress.Text.Length == 0)
            {
                Errors.Add("Please enter an address.\n");
                pictureBox4.Visible = true;
                NoError = false;
            }
            else
            {
                pictureBox4.Visible = false;
            }
            if (TbxEmail.Text.Trim().Length == 0)
            {
                Errors.Add("Please enter an email.\n");
                pictureBox5.Visible = true;
                NoError = false;
            }
            else
            {
                pictureBox5.Visible = false;
            }
            if (TbxTelephone.Text.Trim().Length == 0)
            {
                Errors.Add("Please enter a phone number.\n");
                pictureBox6.Visible = true;
                NoError = false;
            }
            else
            {
                pictureBox6.Visible = false;
            }
            if (TbxPassword.Text.Trim().Length == 0)
            {
                Errors.Add("Please enter a Password.\n");
                pictureBox7.Visible = true;
                NoError = false;
            }
            else
            {
                pictureBox7.Visible = false;
            }
            if (!decimal.TryParse(TbxSalary.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out salary))
            {
                Errors.Add("Salary must be a number\n");
                pictureBox8.Visible = true;
                NoError = false;

            }
            else
            {
                pictureBox8.Visible = false;
            }
            if (CbxStatus.Text.Trim().Length == 0)
            {
                Errors.Add("Please enter a status.\n");
                pictureBox9.Visible = true;
                NoError =false;
            }
            else
            {
                pictureBox9.Visible = false;
            }
            if (Errors.Count == 0)
            {
                NoError = true;
            }
            if (!NoError)
            {
                string errors = "";
                foreach (string error in Errors)
                {
                    errors += error;
                }
                MessageBox.Show(errors, "Error");
            }
                return NoError;
        }
        private Employee ReadInEmployee()
        {
            var employee = new Employee();
            employee.FirstName = TbxFirstName.Text.Trim();
            employee.Surname = TbxSurname.Text.Trim();
            employee.Gender = gender;
            employee.StreetAddress = TbxStreetAdress.Text.Trim();
            employee.DateOfBirth = dtpDOB.Value.Date;
            employee.Email = TbxEmail.Text.Trim();
            employee.TelephoneNo = TbxTelephone.Text.Trim();
            employee.Username = username;
            employee.Password = TbxPassword.Text.Trim();
            employee.DateHired = dtpHired.Value.Date;
            employee.Salary = salary;
            employee.Status = new EmploymentStatus();
            employee.Status.StatusID = Convert.ToInt32(CbxStatus.SelectedValue);

            return employee;
        }
        private void BtnAddEmployee_Click(object sender, EventArgs e)
        {
            bool DataCorrect = DataCheck();
            bool Success = false;
            if (DataCorrect) 
            {
                try
                {
                    Employee emp = ReadInEmployee();
                    int newId = EmployeeDal.AddEmployee(emp);
                    Success = true;
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message, "Add Failed");
                }
                if (Success) 
                {
                    MessageBox.Show("Added Employee.", "Success!");
                    EmployeeDal.GetEmployees();
                }
                
            }
        }

        private void UCaddEmployee_Load(object sender, EventArgs e)
        {

        }
    }
}
