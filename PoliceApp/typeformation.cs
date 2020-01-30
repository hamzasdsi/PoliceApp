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
    public partial class typeformation : Form
    {
        public typeformation()
        {
            InitializeComponent();
            ConnectionString cs = new ConnectionString();
            CommonClasses cc = new CommonClasses();
            clsFunc cf = new clsFunc();
            string st1;
            string st2;
        }
        ConnectionString cn = new ConnectionString();
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        string cmd = "select count(*) from Type_Formation where libelle='" + txtPatientID.Text + "'";
                        SqlCommand cmmd = new SqlCommand(cmd, dbConn);
                        int count = Convert.ToInt32(cmmd.ExecuteScalar());
                        if (count != 0)
                        {
                            MessageBox.Show("Le type de formation existe déjà.", "Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else
                        {

                            string insertCmd = "insert into Type_Formation(libelle) values (@f1)";
                            SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);
                            myCommand.Parameters.AddWithValue("@f1", txtPatientID.Text);
                            myCommand.ExecuteNonQuery();
                            MessageBox.Show("Un type de formation a été ajouté");
                            panel6.Hide();
                            txtPatientID.Clear();
                        }
                    }

                }


                else
                {

                    MessageBox.Show("veuillez saisir un type de formation.","Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void typeformation_Load(object sender, EventArgs e)
        {
            panel6.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel6.Show();
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection dbConn;
            dbConn = new SqlConnection(cn.DBConn());
            dbConn.Open();

           /* if (textBox1.Text != "")
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from Type_Formation where libelle='" + textBox1.Text + "'", dbConn);
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
                SqlDataAdapter sda = new SqlDataAdapter("select id,libelle from Type_Formation", dbConn);
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

        private void button2_Click(object sender, EventArgs e)
        {
            int RowsAffected = 0;
                 if (this.dgw.SelectedRows.Count > 0)
                      {
                         SqlConnection dbConn;
                         dbConn = new SqlConnection(cn.DBConn());
                         dbConn.Open();
                         if (MessageBox.Show("voulez-vous vraiment supprimer ce formation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                string ct = "DELETE FROM Type_Formation WHERE id=" + dgw.SelectedRows[0].Cells[0].Value.ToString() + "";
                                SqlCommand myCommand = new SqlCommand(ct, dbConn);
                                RowsAffected = myCommand.ExecuteNonQuery();
                                if (RowsAffected > 0)
                                  {
                                     MessageBox.Show("Formation supprimée avec succès", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                      dgw.Rows.RemoveAt(this.dgw.SelectedRows[0].Index);
                                  }

                           }
                      }
                 else
                     MessageBox.Show("veuillez sélectionner une formation pour supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information); 
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
