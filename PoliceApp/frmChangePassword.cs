using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace PoliceApp
{
    public partial class frmChangePassword : Form
    {
        CommonClasses cc = new CommonClasses();
        clsFunc cf = new clsFunc();
        ConnectionString cs = new ConnectionString();
        string st1;
        string st2;
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int RowsAffected = 0;
                if ((txtUserID.Text.Trim().Length == 0))
                {
                    MessageBox.Show("Veuillez saisir l'utilisateur", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUserID.Focus();
                    return;
                }
                if ((txtOldPassword.Text.Trim().Length == 0))
                {
                    MessageBox.Show("Veuillez saisir l'ancien mot de passe", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtOldPassword.Focus();
                    return;
                }
                if ((txtNewPassword.Text.Trim().Length == 0))
                {
                    MessageBox.Show("Veuillez saisir votre nouveau mot de passe", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNewPassword.Focus();
                    return;
                }
                if ((txtConfirmPassword.Text.Trim().Length == 0))
                {
                    MessageBox.Show("Veuillez confirmer votre nouveau mot de passe", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConfirmPassword.Focus();
                    return;
                }
                if ((txtNewPassword.TextLength < 4))
                {
                    MessageBox.Show("Le nouveau mot de passe doit etre au minimum 4 caractère", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    txtNewPassword.Focus();
                    return;
                }
                else if ((txtNewPassword.Text != txtConfirmPassword.Text))
                {
                    MessageBox.Show("Incompatibité des mots de passe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewPassword.Text = "";
                    txtOldPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    txtOldPassword.Focus();
                    return;
                }
                else if ((txtOldPassword.Text == txtNewPassword.Text))
                {
                    MessageBox.Show("Mot de passe identique à l'ancien , veuillez entre à nouveau", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    txtNewPassword.Focus();
                    return;
                }

                cc.con = new SqlConnection(cs.DBConn());
                cc.con.Open();
                string co = "Update [User] set password = '" + txtNewPassword.Text + "'where login=@d1 and password =@d2";
                cc.cmd = new SqlCommand(co);
                cc.cmd.Connection = cc.con;
                cc.cmd.Parameters.AddWithValue("@d1", txtUserID.Text);
                cc.cmd.Parameters.AddWithValue("@d2", txtOldPassword.Text);
                RowsAffected = cc.cmd.ExecuteNonQuery();
                if ((RowsAffected > 0))
                {
                    // st1 = txtUserID.Text;
                    // st2 = "Mot de passe changé avec succès";
                    //cf.LogFunc(st1, System.DateTime.Now, st2);
                    MessageBox.Show("Changé avec succès");
                    txtUserID.Text = "";
                    txtNewPassword.Text = "";
                    txtOldPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    txtUserID.Focus();
                   // txtUserID.Text = "";
                    //txtNewPassword.Text = "";
                   // txtOldPassword.Text = "";
                    //txtConfirmPassword.Text = "";
                    //frmLogin LoginForm1 = new frmLogin();
                    //this.Hide();
                   // frmLogin frm = new frmLogin();
                    //frm.UserID.Text = "";
                    //frm.Password.Text = "";
                   // frm.ProgressBar1.Visible = false;
                    //frm.UserID.Focus();
                    //frm.Show();
                }
                else
                {
                    MessageBox.Show("invalid user name or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserID.Text = "";
                    txtNewPassword.Text = "";
                    txtOldPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    txtUserID.Focus();
                }
                if ((cc.con.State == ConnectionState.Open))
                {
                    cc.con.Close();
                }
                cc.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

    }
}
