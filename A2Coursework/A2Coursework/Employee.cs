using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace A2Coursework
{
    internal class Employee
    {
        public static List<Employee> employees = new List<Employee>();
        public static int currentEmployee;
        

        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string StreetAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string TelephoneNo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateHired { get; set; }
        public decimal Salary { get; set; }
        public EmploymentStatus Status = new EmploymentStatus();
        public List<string> Roles = new List<string>();
        public string FullName
        {
            get
            {
                return $"{FirstName} {Surname}";
            }
        }

        public Employee()
        {

        }

        public Employee(int employeeID, string Username, string Password)
        {
            EmployeeID = employeeID;
            this.Username = Username;
            this.Password = Password;
        }
        public string GetStatusDesc(int id)
        {
            string status = "";
            if (id == 1)
            {
                status = "Hired";
            }
            if (id == 2)
            {
                status = "Fired";
            }
            if (id == 3)
            {
                status = "Admin";
            }
            if (id == 4)
            {
                status = "Quit";
            }
            if (id == 5)
            {
                status = "Off";
            }
            return status;
        }
        public Employee(int employeeID, string firstName, string surname, string gender, string address, DateTime dateOfBirth, string email, string telephoneNo, string username, string password, DateTime dateHired, decimal salary, EmploymentStatus status)
        {
            EmployeeID = employeeID;
            FirstName = firstName;
            Surname = surname;
            Gender = gender;
            StreetAddress = address;
            DateOfBirth = dateOfBirth;
            Email = email;
            TelephoneNo = telephoneNo;
            Username = username;
            Password = password;
            DateHired = dateHired;
            Salary = salary;
            this.Status = status;
        }

        public static bool CheckIfExists(int ID)
        {
            foreach (Employee employee in employees)
            {
                if (employee.EmployeeID == ID)
                {
                    return false;
                }
            }

            return true;
        }

        public static void AddRole(int ID, string role)
        {
            foreach (Employee employee in employees)
            {
                if (employee.EmployeeID == ID)
                {
                    employee.Roles.Add(role);
                }
            }
        }

        public int GetListIndex(int ID)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].EmployeeID == ID)
                {
                    return i;
                }
            }
            return -1;
        }
        public static decimal MaxSalary()
        {
            decimal max = 0;
            foreach (Employee e in employees)
            {
                if (e.Salary > max)
                {
                    max = e.Salary;
                }
            }
            return max;
        }

        public static decimal MinSalary()
        {
            decimal min = MaxSalary();
            foreach (Employee e in employees)
            {
                if (e.Salary < min)
                {
                    min = e.Salary;
                }
            }
            return min;
        }
    }
}
