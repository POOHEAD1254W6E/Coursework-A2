using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace A2Coursework
{
    public partial class MainMenu : Form
    {
        private UserControl ActiveUserControl = null;
        private readonly EmployeeDal _dal;
        public static MainMenu instance;
        public MainMenu() 
        {
            InitializeComponent(); 
            instance = this;
            this.Location = new Point(189, 76);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        public void ChildUserControls(UserControl ChildUserControl)
        {

            pnlMainPanel.Controls.Clear();

            ActiveUserControl = ChildUserControl;
            pnlMainPanel.Controls.Add(ActiveUserControl);
            ChildUserControl.Dock = DockStyle.Fill;
            pnlMainPanel.Tag = ChildUserControl;
            ChildUserControl.BringToFront();
            ChildUserControl.Show();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void employeesToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            employeesToolStripMenuItem.ForeColor = Color.Black;
          
        }

        private void employeesToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            
            employeesToolStripMenuItem.ForeColor = Color.White;

        }

        private void lilEmployeesToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            employeesToolStripMenuItem.ForeColor = Color.White;
        }

        private void viewToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            employeesToolStripMenuItem.ForeColor = Color.White;
        }

        private void lilEmployeesToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employeesToolStripMenuItem.ForeColor = Color.White;
            employeesToolStripMenuItem.BackColor = Color.Black;
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCViewEmployee uCViewEmployee = new UCViewEmployee();
            ChildUserControls(uCViewEmployee);
        }

        private void employeesToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            employeesToolStripMenuItem.ForeColor = Color.Black;
        }

        private void employeesToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            employeesToolStripMenuItem.ForeColor = Color.White;
        }

        private void vehiclesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestViewAddEditDelete test = new TestViewAddEditDelete();
            test.Show();
        }

        private void pnlMainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lilEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCaddEmployee uCaddEmployee = new UCaddEmployee();
            ChildUserControls(uCaddEmployee);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
