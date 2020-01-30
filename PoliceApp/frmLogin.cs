using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
namespace PoliceApp
{
    public partial class frmLogin : MetroFramework.Forms.MetroForm
    {
      
     
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public frmLogin()
        {
            InitializeComponent();
        }

        ConnectionString cons = new ConnectionString();
        public  class ControlID
        {
            public static string LOGINATE { get; set; }
        }
        public string utilisateur
        {
            get
            {
                return (UserID.Text);
            }
            set
            {
                UserID.Text = value.ToString();
            }
        }
        public string password
        {
            get
            {
                return (Password.Text);
            }
            set
            {
                Password.Text = value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //LOGINATE = 
                ControlID.LOGINATE = utilisateur;


                //conn.connectdb();
                SqlDataReader rd = null;
                string query = "select * from  [User] where login='" + UserID.Text + "' and password='" + Password.Text + "'";

                SqlConnection dbConn;
                dbConn = new SqlConnection(cons.DBConn());
                dbConn.Open();
                SqlCommand cmd = new SqlCommand(query, dbConn);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    MainMenu fr1 = new MainMenu();
                    this.Hide();
                    fr1.Show();
                    st1 = UserID.Text;
                    st2 = "connexion à l application";
                    //cf.LogFunc(st1, System.DateTime.Now, st2);
                }
                else
                {
                    MessageBox.Show("login ou mot de passe incorrect , veillez réessayer!! ");

                }
            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);
            }

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmChangePassword frm = new frmChangePassword();
            frm.Show();
           // frm.txtUserID.Text = "";
          //  frm.txtNewPassword.Text = "";
           // frm.txtOldPassword.Text = "";
           // frm.txtConfirmPassword.Text = "";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Password_Click(object sender, EventArgs e)
        {
            if (Password.Text == string.Empty)
            {
                passwordLabel.Visible = true;
            }
            if (Password.Text != "Password" && Password.Text != string.Empty)
            {
                passwordLabel.Visible = false;
            }

        }

        private void UserID_Click(object sender, EventArgs e)
        {
            if (UserID.Text == string.Empty)
            {
                usernameLabel.Visible = true;
            }
            if (UserID.Text != "Username" && UserID.Text != string.Empty)
            {
                usernameLabel.Visible = false;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

   
    }
}
