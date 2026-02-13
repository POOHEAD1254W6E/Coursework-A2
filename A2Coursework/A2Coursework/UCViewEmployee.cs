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
    public partial class UCViewEmployee : UserControl
    {
        private Dictionary<int, string> _index;
        private UserControl ActiveUserControl = null;
  
        public UCViewEmployee()
        {            
            InitializeComponent();

            LoadEmployeeList();
            
        }
     
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void LoadEmployeeList() 
        {
            int numbers = 0;
            Dictionary<int, string> EmpNames = new Dictionary<int, string>();
            foreach (Employee emp in Employee.employees)
            {
                EmpNames.Add(emp.EmployeeID, emp.FullName);
            }
            LbxEmployeeView.DataSource = EmpNames.ToArray();
            LbxEmployeeView.DisplayMember = "Value";
            LbxEmployeeView.ValueMember = "Key";

            LbxEmployeeView.SelectedIndex = 0;
        }
        private void UCViewEmployee_Load(object sender, EventArgs e)
        {

        }

        private void pnlEmployeeProfile_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LbxEmployeeView_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnEdit.BackColor = Color.Blue;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

        }

        private void LbxEmployeeView_DoubleClick(object sender, EventArgs e)
        {
            var pair = (KeyValuePair<int, string>)LbxEmployeeView.SelectedItem;
            int employeeId = pair.Key;
           
            UCVi.CurrentEmployeeID = employeeId;
            UCVi uCVi = new UCVi();
            MainMenu.instance.ChildUserControls(uCVi);
      
        }
    }
}
