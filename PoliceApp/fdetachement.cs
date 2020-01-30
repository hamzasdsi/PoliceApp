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
    public partial class fdetachement : Form
    {
        public fdetachement()
        {
            InitializeComponent();
            ConnectionString cs = new ConnectionString();
            CommonClasses cc = new CommonClasses();
            clsFunc cf = new clsFunc();
            string st1;
            string st2;
        }

        ConnectionString cn = new ConnectionString();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection dbConn;
            dbConn = new SqlConnection(cn.DBConn());
            dbConn.Open();

            /*if (textBox1.Text != "")
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from Direction where Type_direction='" + textBox1.Text + "'", dbConn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgw.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dgw.Rows.Add();
                    dgw.Rows[n].Cells[0].Value = dr[0].ToString();
                    dgw.Rows[n].Cells[1].Value = dr[1].ToString();

                }
             }*/


            SqlDataAdapter sda = new SqlDataAdapter("select agence_ID,Libelle from detach_agence", dbConn);
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

        private void button4_Click(object sender, EventArgs e)
        {
            panel6.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int RowsAffected = 0;
            if (this.dgw.SelectedRows.Count > 0)
                  {
                      SqlConnection dbConn;
                      dbConn = new SqlConnection(cn.DBConn());
                      dbConn.Open();
                      if (MessageBox.Show("voulez-vous vraiment supprimer ce détachement?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                         {
                             string ct = "DELETE FROM detach_agence WHERE agence_ID=" + dgw.SelectedRows[0].Cells[0].Value.ToString() + "";
                             SqlCommand myCommand = new SqlCommand(ct, dbConn);
                             RowsAffected = myCommand.ExecuteNonQuery();
                             if (RowsAffected > 0)
                                  {
                                     MessageBox.Show("Détachement supprimée avec succès", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                     dgw.Rows.RemoveAt(this.dgw.SelectedRows[0].Index);

                                  }
                        }
                  }
            else
                MessageBox.Show("veuillez sélectionner un détachement pour supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

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
                        string cmd = "select count(*) from detach_agence where Libelle='" + txtPatientID.Text + "'";
                        SqlCommand cmmd = new SqlCommand(cmd, dbConn);
                        int count = Convert.ToInt32(cmmd.ExecuteScalar());
                        if (count != 0)
                        {
                            MessageBox.Show("Le type de détachement existe déjà.", "Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else
                        {

                            string insertCmd = "insert into detach_agence(Libelle) values (@f1)";
                            SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);
                            myCommand.Parameters.AddWithValue("@f1", txtPatientID.Text);
                            myCommand.ExecuteNonQuery();
                            MessageBox.Show("Un type de détachement a été ajouté");
                            panel6.Hide();
                            txtPatientID.Clear();

                        }

                    }
                }


                else
                {

                    MessageBox.Show("veuillez saisir un type de détachement.", "Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
    }
}
