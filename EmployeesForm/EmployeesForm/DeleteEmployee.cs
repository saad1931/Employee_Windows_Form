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
    public partial class DeleteEmployee : Form
    {
        private SqlConnection connection;
        public DeleteEmployee()
        {
            InitializeComponent();

            InitializeDatabase();
        }
        private void InitializeDatabase()
        {
            string connectionString = "Data Source=DESKTOP-M4RB1S2;Initial Catalog=EmployeeDetails;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        private void load_Click(object sender, EventArgs e)
        {
            int employeeId;
            if (!int.TryParse(id.Text, out employeeId))
            {
                MessageBox.Show("Please enter a valid employee ID.");
                return;
            }

            LoadEmployeeDetails(employeeId);
        }
        private void LoadEmployeeDetails(int employeeId)
        {
            try
            {
                connection.Open();

                string query = "SELECT * FROM employees WHERE ID = @EmployeeId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeId", employeeId);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    fname.Text = reader["FName"].ToString();
                    lname.Text = reader["LName"].ToString();
                    Emaill.Text = reader["Email"].ToString();
                    phone.Text = reader["Phone"].ToString();
                    age.Text = reader["Age"].ToString();
                    acc.Text = reader["Acc"].ToString();
                    dep.SelectedItem = reader["Department"].ToString();
                    add1.Text = reader["A1"].ToString();
                    add2.Text = reader["A2"].ToString();
                    add3.Text = reader["A3"].ToString();
                    city.Text = reader["City"].ToString();
                    country.Text = reader["Country"].ToString();
                    postal.Text = reader["Postal"].ToString();
                    pTCL.Text = reader["Ptcl"].ToString();
                    Badd1.Text = reader["BA1"].ToString();
                    Badd2.Text = reader["BA2"].ToString();
                    Badd3.Text = reader["BA3"].ToString();
                    B_city.Text = reader["BCity"].ToString();
                    B_Country.Text = reader["BCountry"].ToString();
                    B_Postal.Text = reader["BPostal"].ToString();
                    B_PTCL.Text = reader["BPtcl"].ToString();
                }
                else
                {
                    MessageBox.Show("Employee not found.");
                    ClearFormFields();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading employee details: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void D_emp_Click(object sender, EventArgs e)
        {
            int employeeId;
            if (!int.TryParse(id.Text, out employeeId))
            {
                MessageBox.Show("Please enter a valid employee ID.");
                return;
            }
            try
            {
                connection.Open();

                string query = "DELETE FROM employees WHERE ID = @EmployeeId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeId", employeeId);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Employee record deleted successfully!");
                    ClearFormFields();
                }
                else
                {
                    MessageBox.Show("No employee found with the provided ID.");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating employee information: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void ClearFormFields()
        {
            fname.Text = string.Empty;
            lname.Text = string.Empty;
            Emaill.Text = string.Empty;
            phone.Text = string.Empty;
            age.Text = string.Empty;
            acc.Text = string.Empty;
            dep.SelectedIndex = -1;
            add1.Text = string.Empty;
            add2.Text = string.Empty;
            add3.Text = string.Empty;
            city.Text = string.Empty;
            country.Text = string.Empty;
            postal.Text = string.Empty;
            pTCL.Text = string.Empty;
            Badd1.Text = string.Empty;
            Badd2.Text = string.Empty;
            Badd3.Text = string.Empty;
            B_city.Text = string.Empty;
            B_Country.Text = string.Empty;
            B_Postal.Text = string.Empty;
            B_PTCL.Text = string.Empty;
        }

        private void V_emp_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Edit_Employee_Click(object sender, EventArgs e)
        {
            EdirEmployee edirEmployee = new EdirEmployee();
            edirEmployee.Show();
            this.Hide();
        }
    }
}
