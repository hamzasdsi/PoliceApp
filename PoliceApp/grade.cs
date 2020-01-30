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


namespace PoliceApp
{
    public partial class grade : Form
    {
        public grade()
        {
            InitializeComponent();
            ConnectionString cs = new ConnectionString();
            CommonClasses cc = new CommonClasses();
            clsFunc cf = new clsFunc();
            string st1;
            string st2;
        }

        ConnectionString cn = new ConnectionString();

        private void button4_Click(object sender, EventArgs e)
        {
            panel6.Show();
        }

        private void grade_Load(object sender, EventArgs e)
        {
            panel6.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPatientID.Text != "")
                {

                    SqlConnection dbConn;
                    dbConn = new SqlConnection(cn.DBConn());
                    dbConn.Open();
                    if (txtPatientID.Text != "")
                    {
                        string cmd = "select count(*) from Grad where Libelle='" + txtPatientID.Text + "'";
                        SqlCommand cmmd = new SqlCommand(cmd, dbConn);
                        int count = Convert.ToInt32(cmmd.ExecuteScalar());
                        if (count != 0)
                        {
                            MessageBox.Show("Le type de grade existe déjà.", "Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else
                        {

                            string insertCmd = "insert into Grad(Libelle) values (@f1)";
                            SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);
                            myCommand.Parameters.AddWithValue("@f1", txtPatientID.Text);
                            myCommand.ExecuteNonQuery();
                            MessageBox.Show("Un type de grade a été ajouté");
                            panel6.Hide();
                            txtPatientID.Clear();
                        }
                    }

                }


                else
                {

                    MessageBox.Show("veuillez saisir un type de grade.","Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection dbConn;
            dbConn = new SqlConnection(cn.DBConn());
            dbConn.Open();

         /*   if (textBox1.Text != "")
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from Grad where Libelle='"+ textBox1.Text + "'", dbConn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgw.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dgw.Rows.Add();
                    dgw.Rows[n].Cells[0].Value = dr[0].ToString();
                    dgw.Rows[n].Cells[1].Value = dr[1].ToString();

                }
            }
            else
            {*/
                SqlDataAdapter sda = new SqlDataAdapter("select Grade_ID,Libelle from Grad", dbConn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgw.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dgw.Rows.Add();
                    dgw.Rows[n].Cells[0].Value = dr[0].ToString();
                    dgw.Rows[n].Cells[1].Value = dr[1].ToString();

                }
            //}
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int RowsAffected = 0;
                if (this.dgw.SelectedRows.Count > 0)
                   {
                       SqlConnection dbConn;
                       dbConn = new SqlConnection(cn.DBConn());
                       dbConn.Open();
                       if (MessageBox.Show("voulez-vous vraiment supprimer ce grade?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                             {
                                string ct = "DELETE FROM Grad WHERE Grade_ID=" + dgw.SelectedRows[0].Cells[0].Value.ToString() + "";
                                SqlCommand myCommand = new SqlCommand(ct, dbConn);
                                RowsAffected = myCommand.ExecuteNonQuery();
                                if (RowsAffected > 0)
                                    {
                                         MessageBox.Show("Grade supprimé avec succès", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                         dgw.Rows.RemoveAt(this.dgw.SelectedRows[0].Index);
                                    }

                             }
                   }
                else
                    MessageBox.Show("veuillez sélectionner un grade pour supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
        }

        private void panel6_Paint(object sender, PaintEventArgs e) { }
        private void txtPatientID_TextChanged(object sender, EventArgs e){}

        private void dgw_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
