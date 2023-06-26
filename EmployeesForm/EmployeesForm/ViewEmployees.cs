using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeesForm
{
    public partial class ViewEmployees : Form
    {
        private SqlConnection connection;
        private DataGridView dgvEmployees;
        public ViewEmployees()
        {
            InitializeComponent();
            InitializeDatabase();
            LoadEmployeeDetails();
        }

        private void InitializeComponent()
        {
            dgvEmployees = new DataGridView();
            V_emp = new Button();
            label1 = new Label();
            ((ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();
            
            dgvEmployees.Location = new Point(39, 81);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.ReadOnly = true;
            dgvEmployees.Size = new Size(804, 368);
            dgvEmployees.TabIndex = 0;
            
            V_emp.BackColor = Color.LightSteelBlue;
            V_emp.Location = new Point(702, 20);
            V_emp.Name = "V_emp";
            V_emp.Size = new Size(150, 36);
            V_emp.TabIndex = 50;
            V_emp.Text = "Back";
            V_emp.UseVisualStyleBackColor = false;
            V_emp.Click += V_emp_Click;
            
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(39, 19);
            label1.Name = "label1";
            label1.Size = new Size(359, 37);
            label1.TabIndex = 49;
            label1.Text = "All Employees Information";
           
            ClientSize = new Size(878, 488);
            Controls.Add(V_emp);
            Controls.Add(label1);
            Controls.Add(dgvEmployees);
            Name = "ViewEmployees";
            ((ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void InitializeDatabase()
        {
            string connectionString = "Data Source=DESKTOP-M4RB1S2;Initial Catalog=EmployeeDetails;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        private void LoadEmployeeDetails()
        {
            try
            {
                connection.Open();

                string query = "SELECT ID, fname,lname, Email,Phone,Age,Department,City,Country FROM Employees";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dgvEmployees.Columns.Add("ID", "ID");
                    dgvEmployees.Columns.Add("fname", "fname");
                    dgvEmployees.Columns.Add("lname", "lname");
                    dgvEmployees.Columns.Add("Email", "Email");
                    dgvEmployees.Columns.Add("Phone", "Phone");
                    dgvEmployees.Columns.Add("Age", "Age");
                    dgvEmployees.Columns.Add("Department", "Department");
                    dgvEmployees.Columns.Add("City", "City");
                    dgvEmployees.Columns.Add("Country", "Country");

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string fname = reader.GetString(1);
                        string lname = reader.GetString(2);
                        string email = reader.GetString(3);
                        string phone = reader.GetString(4);
                        string age = reader.GetString(5);
                        string department = reader.GetString(6);
                        string city = reader.GetString(7);
                        string country = reader.GetString(8);

                        dgvEmployees.Rows.Add(id, fname, lname, email,phone,age ,department,city,country);
                    }
                }
                else
                {
                    MessageBox.Show("No employee details found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void V_emp_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
    }
}
