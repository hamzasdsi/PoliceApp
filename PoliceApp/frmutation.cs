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
    public partial class frmutation : MetroFramework.Forms.MetroForm
    {
        public frmutation()
        {
            InitializeComponent();
        }
        DBpoliceEntities dbpfen = new DBpoliceEntities();
        private void frmutation_Load(object sender, EventArgs e)
        {
       

            comboBox5.ValueMember = "Direction_ID";
            comboBox5.DisplayMember = "Type_direction";
            comboBox5.DataSource = dbpfen.Direction.ToList<Direction>();

            DataGridViewCheckBoxColumn dgCheckBox = new DataGridViewCheckBoxColumn();
            dgCheckBox.DisplayIndex = 0;
            dgCheckBox.Width = 50;
            dgCheckBox.Name = "dg";
            dgCheckBox.HeaderText = "";
            dataGridView1.Columns.Add(dgCheckBox);

    

         
        }
        private void affichage()
        {
            dataGridView1.Visible = true;

            List<View_policDir> lstusr = null;
            DBpoliceEntities dbpfen = new DBpoliceEntities();

            lstusr = dbpfen.View_policDir.ToList();
            if (lstusr.Count() != 0)
            {
                for (int i = 0; i < lstusr.Count(); i++)
                {

                    string nom = lstusr[i].Nom_policier.ToString();
                   // string type= lstusr[i].Type_direction.ToString();
                
                    string id = lstusr[i].Matricule_ID.ToString();
                   
                    string[] row1 = new string[] {
                        id,
                            nom,
                           
                        //   type 
                           
                         
                        };

                    dataGridView1.Rows.Add(row1);
                    dataGridView1.Visible = true;
                }
            }


        }
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
             if (textBox4.Text == string.Empty)
            {
                affichage();
            }
             else
             {
            List<View_policDir> lstusr = null;
            DBpoliceEntities dbpfen = new DBpoliceEntities();
            dataGridView1.Rows.Clear();
            int var = Convert.ToInt32(textBox4.Text.ToString());
            lstusr = dbpfen.View_policDir.Where(x => x.Matricule_ID == var).ToList();
           
           

                if (lstusr.Count() != 0)
                {
                    for (int i = 0; i < lstusr.Count(); i++)
                    {

                        string nom = lstusr[i].Nom_policier.ToString();
                        //string type = lstusr[i].Type_direction.ToString();

                        string id = lstusr[i].Matricule_ID.ToString();

                        string[] row1 = new string[] {
                        id,
                            nom,
                           
                          // type 
                           
                         
                        };

                        dataGridView1.Rows.Add(row1);
                        dataGridView1.Visible = true;
                    }


                }
            }
         
        }
        public static List<DataGridViewRow> select;
        private void button8_Click(object sender, EventArgs e)
        {
            select = (from row in dataGridView1.Rows.Cast<DataGridViewRow>()
                      where Convert.ToBoolean(row.Cells["dg"].Value) == true
                      select row).ToList();


            if (MessageBox.Show(string.Format("Voulez-vous enregistrer une affectation pour {0} dossiers?", select.Count), "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                panel7.Visible = true;

            }
            else
            {

                panel7.Visible = false;
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string d = Convert.ToString(row.Cells[2].Value);

                textBox7.Text = d;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> selectedRows = (from row in dataGridView1.Rows.Cast<DataGridViewRow>()
                                                  where Convert.ToBoolean(row.Cells["dg"].Value) == true

                                                  select row).ToList();

            try
            {
                foreach (DataGridViewRow row in selectedRows)
                {

                    Object num = row.Cells[0].Value;
                    int num1 = Convert.ToInt32(num);

                    ConnectionString cn = new ConnectionString();
                    string insertCmd = "INSERT INTO Affectation(Dateaffectation,departement1,departement2,motif,idpolicier) VALUES (@f,@f1,@f2,@f3,@f4)";
                    SqlConnection dbConn;
                    dbConn = new SqlConnection(cn.DBConn());
                    dbConn.Open();
                    //Authentification lg = new Authentification();

                    //GetValue value = new GetValue();

                    SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);
                    int var = Convert.ToInt32(comboBox5.SelectedValue.ToString());
                    myCommand.Parameters.AddWithValue("@f", dateTimePicker4.Value);
                    myCommand.Parameters.AddWithValue("@f1", textBox7.Text);
                    myCommand.Parameters.AddWithValue("@f2", var);
                    myCommand.Parameters.AddWithValue("@f3", textBox5.Text);
                    myCommand.Parameters.AddWithValue("@f4", num1);

                    myCommand.ExecuteNonQuery();




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            MessageBox.Show("Ajouté avec succès");
           // affichage();
           
          
        }
        
        private void btnGetData_Click(object sender, EventArgs e)
        {

        }
    }
}
