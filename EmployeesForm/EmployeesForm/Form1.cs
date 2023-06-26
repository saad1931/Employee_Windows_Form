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
    public partial class Form1 : Form
    {
        private SqlConnection connection;
        public Form1()
        {
            InitializeComponent();
            InitializeDatabase();
        }
        private void InitializeDatabase()
        {
            string connectionString = "Data Source=DESKTOP-M4RB1S2;Initial Catalog=EmployeeDetails;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        private void Add_Employee_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

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

                if (string.IsNullOrEmpty(Fname) || string.IsNullOrEmpty(Lname) || string.IsNullOrEmpty(department))
                {
                    MessageBox.Show("Please enter First Name,Last Name & department");
                }
                else
                {
                    string query = "INSERT INTO employees (FName, LName, Email, Phone, Age, Acc, Department, A1, A2, A3, City, Country, Postal, Ptcl, BA1, BA2, BA3, BCity, BCountry, BPostal, BPtcl) " +
                                   "VALUES (@FName, @LName, @Email, @Phone, @Age, @Acc, @Department, @A1, @A2, @A3, @City, @Country, @Postal, @Ptcl, @BA1, @BA2, @BA3, @BCity, @BCountry, @BPostal, @BPtcl)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FName", Fname);
                    command.Parameters.AddWithValue("@LName", Lname);
                    command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? DBNull.Value : (object)email);
                    command.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(Phone) ? DBNull.Value : (object)Phone);
                    command.Parameters.AddWithValue("@Age", string.IsNullOrEmpty(Age) ? DBNull.Value : (object)Age);
                    command.Parameters.AddWithValue("@Acc", string.IsNullOrEmpty(Acc) ? DBNull.Value : (object)Acc);
                    command.Parameters.AddWithValue("@Department", department);
                    command.Parameters.AddWithValue("@A1", string.IsNullOrEmpty(a1) ? DBNull.Value : (object)a1);
                    command.Parameters.AddWithValue("@A2", string.IsNullOrEmpty(a2) ? DBNull.Value : (object)a2);
                    command.Parameters.AddWithValue("@A3", string.IsNullOrEmpty(a3) ? DBNull.Value : (object)a3);
                    command.Parameters.AddWithValue("@City", string.IsNullOrEmpty(City) ? DBNull.Value : (object)City);
                    command.Parameters.AddWithValue("@Country", string.IsNullOrEmpty(Country) ? DBNull.Value : (object)Country);
                    command.Parameters.AddWithValue("@Postal", string.IsNullOrEmpty(Postal) ? DBNull.Value : (object)Postal);
                    command.Parameters.AddWithValue("@Ptcl", string.IsNullOrEmpty(PTCL) ? DBNull.Value : (object)PTCL);
                    command.Parameters.AddWithValue("@BA1", string.IsNullOrEmpty(ba1) ? DBNull.Value : (object)ba1);
                    command.Parameters.AddWithValue("@BA2", string.IsNullOrEmpty(ba2) ? DBNull.Value : (object)ba2);
                    command.Parameters.AddWithValue("@BA3", string.IsNullOrEmpty(ba3) ? DBNull.Value : (object)ba3);
                    command.Parameters.AddWithValue("@BCity", string.IsNullOrEmpty(BCity) ? DBNull.Value : (object)BCity);
                    command.Parameters.AddWithValue("@BCountry", string.IsNullOrEmpty(BCountry) ? DBNull.Value : (object)BCountry);
                    command.Parameters.AddWithValue("@BPostal", string.IsNullOrEmpty(BPostal) ? DBNull.Value : (object)BPostal);
                    command.Parameters.AddWithValue("@BPtcl", string.IsNullOrEmpty(BPTCL) ? DBNull.Value : (object)BPTCL);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Employee information saved successfully!");
                    ClearFields();

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
        private void ClearFields()
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
            ViewEmployees detailsForm = new ViewEmployees();
            detailsForm.Show();
            this.Hide();
        }

        private void E_emp_Click(object sender, EventArgs e)
        {
            EdirEmployee edirEmployee = new EdirEmployee();
            edirEmployee.Show();
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
