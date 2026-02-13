using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data; // Gives DataTable/DataSet/CommandType
using System.Data.SqlClient; // Gives SqlConnection/SqlCommand/SqlDataReader
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace A2Coursework
{
    internal class EmployeeDal
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["ProjectManagementConnectionString"].ConnectionString;

        public EmployeeDal() // Constructor runs when you create EmployeeDal
        {
            
        }

        public static void GetEmployees()
        {
            Employee.employees.Clear();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                Debug.WriteLine("Connection String: " + connection.ConnectionString);
                Debug.WriteLine("Database File: " + connection.Database);

                SqlCommand getEmployeesCommand = new SqlCommand();
                getEmployeesCommand.Connection = connection;

                getEmployeesCommand.CommandType = System.Data.CommandType.StoredProcedure;

                getEmployeesCommand.CommandText = "GetEmployees";

                SqlDataReader sqlDataReader = getEmployeesCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    int employeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);

                    try
                    {
                        object roleIdValue = sqlDataReader["RoleID"];
                        object roleNameValue = sqlDataReader["RoleName"];

                        string role = null;
                        if (roleIdValue != DBNull.Value)
                        {
                            role = Convert.ToString(roleNameValue);
                        }

                        if (Employee.CheckIfExists(employeeID))
                        {
                            EmploymentStatus status = new EmploymentStatus(Convert.ToInt32(sqlDataReader["StatusID"]), Convert.ToString(sqlDataReader["StatusDescription"]));
                            Employee employee = new Employee(Convert.ToInt32(sqlDataReader["EmployeeID"]), Convert.ToString(sqlDataReader["FirstName"]), Convert.ToString(sqlDataReader["Surname"]), Convert.ToString(sqlDataReader["Gender"]), Convert.ToString(sqlDataReader["StreetAddress"]), Convert.ToDateTime(sqlDataReader["DateOfBirth"]), Convert.ToString(sqlDataReader["Email"]), Convert.ToString(sqlDataReader["TelephoneNo"]), Convert.ToString(sqlDataReader["Username"]), Convert.ToString(sqlDataReader["Password"]), Convert.ToDateTime(sqlDataReader["DateHired"]), Convert.ToDecimal(sqlDataReader["Salary"]), status);
                            Employee.employees.Add(employee);
                        }

                        if (role != null)
                        {
                            Employee.AddRole(employeeID, role);
                        }
                    }
                    catch
                    {
                        if (Employee.CheckIfExists(employeeID))
                        {
                            EmploymentStatus status = new EmploymentStatus(Convert.ToInt32(sqlDataReader["StatusID"]), Convert.ToString(sqlDataReader["StatusDescription"]));
                            Employee employee = new Employee(Convert.ToInt32(sqlDataReader["EmployeeID"]), Convert.ToString(sqlDataReader["FirstName"]), Convert.ToString(sqlDataReader["Surname"]), Convert.ToString(sqlDataReader["Gender"]), Convert.ToString(sqlDataReader["Address"]), Convert.ToDateTime(sqlDataReader["DateOfBirth"]), Convert.ToString(sqlDataReader["Email"]), Convert.ToString(sqlDataReader["TelephoneNo"]), Convert.ToString(sqlDataReader["Username"]), Convert.ToString(sqlDataReader["Password"]), Convert.ToDateTime(sqlDataReader["DateHired"]), Convert.ToDecimal(sqlDataReader["Salary"]), status);
                            Employee.employees.Add(employee);
                        }
                    }
                }

                connection.Close();
            }
        }
        public static Dictionary<int, string> GetEmploymentstatuses()
        {
            var list = new Dictionary<int, string>();
            using (var con = new SqlConnection(_connectionString))
                using ( var cmd = new SqlCommand("dbo.EmploymentStatus_GetAll", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        int StatusID = (int)rdr[""];
                        string StatusDesc = $"{rdr["StatusDescription"]}";
                        list.Add(StatusID, StatusDesc);
                    }
                }
            }


            return list;
        }
        public static Dictionary<int, string> GetEmployeesForList() 
        {
            var list = new Dictionary<int, string>();

            using (var con = new SqlConnection(_connectionString)) 
            using (var cmd = new SqlCommand("dbo.Employee_GetAll_Basic", con)) 
            {
                cmd.CommandType = CommandType.StoredProcedure; 

                con.Open(); 
                using (var rdr = cmd.ExecuteReader()) 
                {
                    while (rdr.Read()) 
                    {
                        int id = (int)rdr["EmployeeID"]; 
                        string name = $"{rdr["FirstName"]} {rdr["Surname"]}"; 
                        list.Add(id, name); 
                    }
                }
            }

            return list; 
        }

        public static Employee GetEmployeeById(int employeeId) 
        {
            using (var con = new SqlConnection(_connectionString)) 
            using (var cmd = new SqlCommand("dbo.Employee_GetByID", con)) 
            {
                cmd.CommandType = CommandType.StoredProcedure; 
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);  

                con.Open(); 
                using (var rdr = cmd.ExecuteReader()) 
                {
                    if (!rdr.Read())
                        throw new Exception("No employee found");

                        var e = new Employee(); 

                    e.EmployeeID = (int)rdr["EmployeeID"]; 
                    e.FirstName = (string)rdr["FirstName"]; 
                    e.Surname = (string)rdr["Surname"];
                    e.Gender = (string)rdr["Gender"]; 
                    e.StreetAddress = (string)rdr["StreetAddress"]; 
                    e.DateOfBirth = (DateTime)rdr["DateOfBirth"]; 
                    e.Email = (string)rdr["Email"]; 
                    e.TelephoneNo = (string)rdr["TelephoneNo"]; 
                    e.Username = (string)rdr["Username"]; 
                    e.Password = (string)rdr["Password"]; 
                    e.DateHired = (DateTime)rdr["DateHired"]; 
                    e.Salary = (decimal)rdr["Salary"]; 
                    e.Status.StatusID = (int)rdr["StatusID"];

                    return e; 
                }
            }
        }

        public static void GetAllStatuses() 
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand getStatusesCommand = new SqlCommand();
                getStatusesCommand.Connection = connection;
                getStatusesCommand.CommandType = CommandType.StoredProcedure;
                getStatusesCommand.CommandText = "EmploymentStatus_GetAll";

                SqlDataReader statusDataReader = getStatusesCommand.ExecuteReader();

                while(statusDataReader.Read())
                {
                    int StatusID = (int)statusDataReader["StatusID"];
                    string StatusDescription = (string)statusDataReader["StatusDescription"];

                    EmploymentStatus status = new EmploymentStatus(StatusID, StatusDescription);
                    EmploymentStatus.statuses.Add(status);
                }

                connection.Close();
            }
        }

        public static List<int> GetRoleIdsForEmployee(int employeeId) // Returns RoleIDs for one employee
        {
            var roleIds = new List<int>(); // Create list of role IDs

            using (var con = new SqlConnection(_connectionString)) // Create connection
            using (var cmd = new SqlCommand("dbo.EmployeeRole_GetByEmployeeID", con)) // Stored procedure
            {
                cmd.CommandType = CommandType.StoredProcedure; 
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId); 

                con.Open(); 
                using (var rdr = cmd.ExecuteReader()) 
                {
                    while (rdr.Read()) 
                    {
                        roleIds.Add((int)rdr["RoleID"]); 
                    }
                }
            }

            return roleIds;
        }

        public static int AddEmployee(Employee e) 
        {
            using (var con = new SqlConnection(_connectionString)) 
            using (var cmd = new SqlCommand("dbo.Employee_Insert", con)) 
            {
                cmd.CommandType = CommandType.StoredProcedure; 

                cmd.Parameters.AddWithValue("@FirstName", e.FirstName); 
                cmd.Parameters.AddWithValue("@Surname", e.Surname);
                cmd.Parameters.AddWithValue("@Gender", e.Gender); 
                cmd.Parameters.AddWithValue("@StreetAddress", e.StreetAddress); 
                cmd.Parameters.AddWithValue("@DateOfBirth", e.DateOfBirth.Date); 
                cmd.Parameters.AddWithValue("@Email", e.Email); 
                cmd.Parameters.AddWithValue("@TelephoneNo", e.TelephoneNo); 
                cmd.Parameters.AddWithValue("@Username", e.Username); 
                cmd.Parameters.AddWithValue("@Password", e.Password); 
                cmd.Parameters.AddWithValue("@DateHired", e.DateHired.Date); 
                cmd.Parameters.AddWithValue("@Salary", e.Salary); 
                cmd.Parameters.AddWithValue("@StatusID", e.Status.StatusID); 

                var outId = new SqlParameter("@NewEmployeeID", SqlDbType.Int); 
                outId.Direction = ParameterDirection.Output; 
                cmd.Parameters.Add(outId); 

                con.Open(); 
                cmd.ExecuteNonQuery(); 

                return (int)outId.Value; 
            }
        }

        public static void UpdateEmployee(Employee e) 
        {
            using (var con = new SqlConnection(_connectionString)) 
            using (var cmd = new SqlCommand("dbo.Employee_Update", con)) 
            {
                cmd.CommandType = CommandType.StoredProcedure; 

                cmd.Parameters.AddWithValue("@EmployeeID", e.EmployeeID); 
                cmd.Parameters.AddWithValue("@FirstName", e.FirstName);
                cmd.Parameters.AddWithValue("@Surname", e.Surname); 
                cmd.Parameters.AddWithValue("@Gender", e.Gender); 
                cmd.Parameters.AddWithValue("@StreetAddress", e.StreetAddress); 
                cmd.Parameters.AddWithValue("@DateOfBirth", e.DateOfBirth.Date); 
                cmd.Parameters.AddWithValue("@Email", e.Email); 
                cmd.Parameters.AddWithValue("@TelephoneNo", e.TelephoneNo);
                cmd.Parameters.AddWithValue("@Username", e.Username); 
                cmd.Parameters.AddWithValue("@Password", e.Password); 
                cmd.Parameters.AddWithValue("@DateHired", e.DateHired.Date); 
                cmd.Parameters.AddWithValue("@Salary", e.Salary); 
                cmd.Parameters.AddWithValue("@StatusID", e.Status.StatusID); 

                con.Open(); 
                cmd.ExecuteNonQuery(); 
            }
        }
        public static void UpdateEmployeeInfo(Employee employee)
        {
            Debug.WriteLine("UpdateEmployeeInfo");
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand updateEmployeeInfoCommand = new SqlCommand();
                updateEmployeeInfoCommand.Connection = connection;
                updateEmployeeInfoCommand.CommandType = System.Data.CommandType.StoredProcedure;
                updateEmployeeInfoCommand.CommandText = "UpdateEmployeeInfo";
                updateEmployeeInfoCommand.Parameters.Add(new SqlParameter("@EmployeeID", employee.EmployeeID));
                updateEmployeeInfoCommand.Parameters.Add(new SqlParameter("@FirstName", employee.FirstName));
                updateEmployeeInfoCommand.Parameters.Add(new SqlParameter("@Surname", employee.Surname));
                updateEmployeeInfoCommand.Parameters.Add(new SqlParameter("@Gender", employee.Gender));
                updateEmployeeInfoCommand.Parameters.Add(new SqlParameter("@Address", employee.StreetAddress));
                updateEmployeeInfoCommand.Parameters.Add(new SqlParameter("@DateOfBirth", employee.DateOfBirth.Date));
                updateEmployeeInfoCommand.Parameters.Add(new SqlParameter("@Email", employee.Email));
                updateEmployeeInfoCommand.Parameters.Add(new SqlParameter("@TelephoneNo", employee.TelephoneNo));
                updateEmployeeInfoCommand.Parameters.Add(new SqlParameter("@Username", employee.Username));
                updateEmployeeInfoCommand.Parameters.Add(new SqlParameter("@Password", employee.Password));
                updateEmployeeInfoCommand.Parameters.Add(new SqlParameter("@DateHired", employee.DateHired.Date));
                updateEmployeeInfoCommand.Parameters.Add(new SqlParameter("@Salary", employee.Salary));
                updateEmployeeInfoCommand.Parameters.Add(new SqlParameter("@StatusID", employee.Status.StatusID));

                updateEmployeeInfoCommand.ExecuteNonQuery();

                connection.Close();
            }
        }

        public static void DeleteEmployee(int employeeId) 
        {
            using (var con = new SqlConnection(_connectionString)) 
            using (var cmd = new SqlCommand("dbo.Employee_Delete", con)) // Delete procedure
            {
                cmd.CommandType = CommandType.StoredProcedure; // Stored procedure mode
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId); // Pass employee ID

                con.Open(); // Open connection
                cmd.ExecuteNonQuery(); // Run delete procedure
            }
        }

        public void ReplaceEmployeeRoles(int employeeId, List<int> newRoleIds) // Deletes old roles and inserts new ones
        {
            using (var con = new SqlConnection(_connectionString)) // Create connection
            {
                con.Open(); // Open connection

                using (var tran = con.BeginTransaction()) // Start a transaction so changes are all-or-nothing
                {
                    try
                    {
                        using (var del = new SqlCommand("dbo.EmployeeRole_DeleteByEmployeeID", con, tran)) // Create delete roles command
                        {
                            del.CommandType = CommandType.StoredProcedure; // Stored procedure mode
                            del.Parameters.AddWithValue("@EmployeeID", employeeId); // Pass employee ID
                            del.ExecuteNonQuery(); // Delete old roles
                        }

                        foreach (int roleId in newRoleIds) // Loop each selected role
                        {
                            using (var add = new SqlCommand("dbo.EmployeeRole_Insert", con, tran)) // Insert role command
                            {
                                add.CommandType = CommandType.StoredProcedure; // Stored procedure mode
                                add.Parameters.AddWithValue("@EmployeeID", employeeId); // Pass employee ID
                                add.Parameters.AddWithValue("@RoleID", roleId); // Pass role ID
                                add.ExecuteNonQuery(); // Insert role row
                            }
                        }

                        tran.Commit(); // Save all role changes
                    }
                    catch
                    {
                        tran.Rollback(); // Undo role changes if anything fails
                        throw; // Re-throw so UI can show an error
                    }
                }
            }
        }

    }
}
