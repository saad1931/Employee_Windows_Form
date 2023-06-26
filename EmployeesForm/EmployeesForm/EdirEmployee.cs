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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EmployeesForm
{
    public partial class EdirEmployee : Form
    {
        private SqlConnection connection;

        public EdirEmployee()
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
        private void Edit_Employee_Click(object sender, EventArgs e)
        {
            int employeeId;
            if (!int.TryParse(id.Text, out employeeId))
            {
                MessageBox.Show("Please enter a valid employee ID.");
                return;
            }


            string Fname = fname.Text;
            string Lname = lname.Text;
            string email = Emaill.Text;
            string Phone = phone.Text;
            string Age = age.Text;
            string Acc = acc.Text;
            string department = dep.SelectedItem != null ? dep.SelectedItem.ToString() : null;
            string a1 = add1.Text;
            string a2 = add2.Text;
            string a3 = add3.Text;
            string City = city.Text;
            string Country = country.Text;
            string Postal = postal.Text;
            string PTCL = pTCL.Text;
            string ba1 = Badd1.Text;
            string ba2 = Badd2.Text;
            string ba3 = Badd3.Text;
            string BCity = B_city.Text;
            string BCountry = B_Country.Text;
            string BPostal = B_Postal.Text;
            string BPTCL = B_PTCL.Text;

            try
            {
                connection.Open();

                string query = "UPDATE employees SET FName = @FName, LName = @LName, Email = @Email, Phone = @Phone, Age = @Age, Acc = @Acc, " +
                    "Department = @Department, A1 = @A1, A2 = @A2, A3 = @A3, City = @City, Country = @Country, Postal = @Postal, Ptcl = @Ptcl, " +
                    "BA1 = @BA1, BA2 = @BA2, BA3 = @BA3, BCity = @BCity, BCountry = @BCountry, BPostal = @BPostal, BPtcl = @BPtcl " +
                    "WHERE ID = @EmployeeId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FName", Fname);
                command.Parameters.AddWithValue("@LName", Lname);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Phone", Phone);
                command.Parameters.AddWithValue("@Age", Age);
                command.Parameters.AddWithValue("@Acc", Acc);
                command.Parameters.AddWithValue("@Department", department);
                command.Parameters.AddWithValue("@A1", a1);
                command.Parameters.AddWithValue("@A2", a2);
                command.Parameters.AddWithValue("@A3", a3);
                command.Parameters.AddWithValue("@City", City);
                command.Parameters.AddWithValue("@Country", Country);
                command.Parameters.AddWithValue("@Postal", Postal);
                command.Parameters.AddWithValue("@Ptcl", PTCL);
                command.Parameters.AddWithValue("@BA1", ba1);
                command.Parameters.AddWithValue("@BA2", ba2);
                command.Parameters.AddWithValue("@BA3", ba3);
                command.Parameters.AddWithValue("@BCity", BCity);
                command.Parameters.AddWithValue("@BCountry", BCountry);
                command.Parameters.AddWithValue("@BPostal", BPostal);
                command.Parameters.AddWithValue("@BPtcl", BPTCL);
                command.Parameters.AddWithValue("@EmployeeId", employeeId);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Employee information updated successfully!");
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

        private void D_emp_Click(object sender, EventArgs e)
        {
            DeleteEmployee deleteEmployee = new DeleteEmployee();
            deleteEmployee.Show();
            this.Hide();
        }
    }
}
