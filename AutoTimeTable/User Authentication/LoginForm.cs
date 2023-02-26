using Mart_System;
using AutoTimeTable;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using AutoTimeTable.Forms;
using AutoTimeTable.SourceCode;
using System.Data;
using LoginEncrpyt;

namespace LoginScreen
{
    public partial class Form1 : Form
    {
        public static string username = "";

        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public Form1()
        {
            this.Icon = AutoTimeTable.Properties.Resources.login;

            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }



        private void label2_Click(object sender, EventArgs e)
        {
            txtUserName.Focus();
            txtUserName.Clear();
            txtpassword.Clear();
            errorProvider1.Clear();
            errorProvider2.Clear();
        }



        private void Showpasswordbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Showpasswordbox.Checked == true)
            {
                txtpassword.UseSystemPasswordChar = false;

            }
            else
            {
                txtpassword.UseSystemPasswordChar = true;

            }
        }
        //LoginScreen Button Which Login From The DataBae To Dashboard  Foam
        private void loginbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text) == true)
            {
                txtUserName.Focus();
                errorProvider1.SetError(this.txtUserName, "Please Enter Your UserName or Email ");
            }
            else if (string.IsNullOrEmpty(txtpassword.Text) == true)
            {
                txtpassword.Focus();

                errorProvider2.SetError(this.txtpassword, "Please Enter Your Password");

            }
            else
            {
                string userName = "";
                string userPassword = "";
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from UserTable where (Username=@user and password=@pass) or (email=@email and password=@pass)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", txtUserName.Text);
                cmd.Parameters.AddWithValue("@pass", Encrypt.HashString(txtpassword.Text));
                cmd.Parameters.AddWithValue("@email", Encrypt.HashString(txtUserName.Text));
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    dr.Read();
                    string userNameFromDb = dr["username"].ToString().Trim();
                    string email = dr["email"].ToString().Trim();
                    //string passwordFromDb = dr["password"].ToString();
                    //string passwordFromDb = Encrypt.HashString(dr["password"].ToString());
                    dr.Close();
                    if ((userNameFromDb == txtUserName.Text)|| email == Encrypt.HashString(txtUserName.Text))
                    {
                        MessageBox.Show("Login Succesful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //username = txtUserName.Text;
                        con.Close();
                        this.Hide();
                        HomeForm dashboard = new HomeForm();
                        dashboard.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Username And Password Incorrect\nPlease Double Check Your UserName And Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                else
                {
                    MessageBox.Show("Username And Password Incorrect\nPlease Double Check Your UserName And Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                con.Close();
            }
        }
        //End

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linktosignupform_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUpForm signup = new SignUpForm();
            this.Hide();
            signup.ShowDialog();
        }


        // TextBox Leave Event

        #region Textbox_Leave_Event
        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text) == true)
            {
                txtUserName.Focus();
                errorProvider1.SetError(this.txtUserName, "Please Enter Your UserName ");
            }
            else
            {
                errorProvider1.Clear();

            }
        }

        private void txtpassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtpassword.Text) == true)
            {
                txtpassword.Focus();
                errorProvider2.SetError(this.txtpassword, "Please Enter Your Password");

            }
            else
            {
                errorProvider2.Clear();
            }
        }


        #endregion

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                loginbutton.PerformClick();
            }
        }
        // Visible Change Event Run When We Move One Form To Another Form && Back ANother Form To This Form 
        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtpassword.Clear();
            txtUserName.Focus();
        }
    }
}

