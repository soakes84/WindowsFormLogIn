﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormLogIn
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=LAPTOP-92TRGVJ3\SQLEXPRESS;Initial Catalog=WindowsFormLogIn;Integrated Security=True");
            string query = "select * from logins where username ='" + userNameTextBox.Text.Trim() + "'and password='" + passwordTextBox.Text.Trim() + "'";

            SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            if (dataTable.Rows.Count == 1)
            {
                formLoggedIn objFormLoggedIn = new formLoggedIn();
                this.Hide();
                objFormLoggedIn.Show();
            }
            else
            {
                MessageBox.Show("Please re-enter your username and password");
            }

        }
    }
}
