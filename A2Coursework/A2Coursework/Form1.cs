using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A2Coursework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            EmployeeDal.GetEmployees();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         

        }

        private void button1_Click(object sender, EventArgs e)
        {
          LoginCheck();
           
        }
        private void LoginCheck()
        {
            int i = 0;
            string username = TBXname.Text; string password = TBXpassword.Text; bool ValidLogin = false; bool IsAdmin = true;
            foreach (Employee employee in Employee.employees) 
            {
                i++;
                if (employee.Username == username && employee.Password == password)
                {
                    Employee.currentEmployee = i;
                    ValidLogin = true;
                    if (CbxAdmin.Checked == true && employee.Status.StatusID != 3)
                    {
                        
                        IsAdmin = false;
                    }
                }  
            }
            if (!ValidLogin) 
            {
                MessageBox.Show("Invalid Username or Password", "Incorrect");
            }
            if (!IsAdmin)
            {
                MessageBox.Show("No admin found with those details.", "Error");
            }
            if (IsAdmin && ValidLogin)
            {
                MessageBox.Show("You have successfully logged in.");
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
                this.Hide();
            }
             
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TxtUsername_Click(object sender, EventArgs e)
        {
          
        }
    }
}
