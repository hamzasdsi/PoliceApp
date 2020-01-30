using System;
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
    public partial class frmdivorce : Form
    {
        public frmdivorce()
        {
            InitializeComponent();
        }

        DBpoliceEntities dbpfen = new DBpoliceEntities();
        public static List<DataGridViewRow> select;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e) { }

        private void button5_Click(object sender, EventArgs e) { }

        private void button8_Click(object sender, EventArgs e) { }

        private void button4_Click(object sender, EventArgs e) { }

        private void textBox4_TextChanged(object sender, EventArgs e) { }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                dgw.Rows.Clear();
                //View_policierDivorce lstusr = new View_policierDivorce();
                List<View_policierDivorce> lstusr = null;
                if (textBox4.Text.ToString() != "")
                {
                    dgw.Rows.Clear();
                    int var = Convert.ToInt32(textBox4.Text.ToString());
                    lstusr = dbpfen.View_policierDivorce.Where(x => x.Matricule_ID == var).ToList();
                    if (lstusr != null)
                    {
                        for (int i = 0; i < lstusr.Count(); i++)
                        {
                            MessageBox.Show(lstusr.Count.ToString());
                            string id = lstusr[i].Epouse_ID.ToString();
                            string matricule = textBox4.Text.ToString();
                            string nompolicier = lstusr[i].Nom_policier.ToString();
                            string nomepouse = lstusr[i].Nom_epouse.ToString();
                            //string datemariage = lstusr[i].Date_mariage.ToString();
                            string statut = lstusr[i].Statut.ToString();

                            string[] row1 = new string[] {
                           //id,
                           matricule,
                           nompolicier,
                           nomepouse,
                           id,
                           statut,
                           
                          // datemariage,
                           
                          
                        };

                            dataGridView1.Rows.Add(row1);
                            dataGridView1.Visible = true;

                        }
                    }
                }
                else if (textBox3.Text.ToString() != "")
                {
                    dgw.Rows.Clear();
                    string var = textBox3.Text.ToString();
                    lstusr = dbpfen.View_policierDivorce.Where(x => x.Nom_policier == var).ToList();
                    if (lstusr != null)
                    {
                        for (int i = 0; i < lstusr.Count(); i++)
                        {
                            string id = lstusr[i].Epouse_ID.ToString();
                            string matricule = textBox4.Text.ToString();
                            string nompolicier = lstusr[i].Nom_policier.ToString();
                            string nomepouse = lstusr[i].Nom_epouse.ToString();
                            // string datemariage = lstusr[i].Date_mariage.ToString();
                            string statut = lstusr[i].Statut.ToString();

                            string[] row1 = new string[] {
                           //id,
                           matricule,
                           nompolicier,
                           nomepouse,
                           id,
                           statut,
                           
                          // datemariage,

                          
                        };

                            dataGridView1.Rows.Add(row1);
                            dataGridView1.Visible = true;
                        }
                    }
                }
                else if (textBox4.Text.ToString() != "" && textBox3.Text.ToString() != "")
                {
                    dgw.Rows.Clear();
                    int var = Convert.ToInt32(textBox4.Text.ToString());
                    lstusr = dbpfen.View_policierDivorce.Where(x => (x.Matricule_ID == var) && (x.Nom_policier == textBox3.Text.ToString())).ToList();
                    if (lstusr != null)
                    {
                        for (int i = 0; i < lstusr.Count(); i++)
                        {
                            string id = lstusr[i].Epouse_ID.ToString();
                            string matricule = textBox4.Text.ToString();
                            string nompolicier = lstusr[i].Nom_policier.ToString();
                            string nomepouse = lstusr[i].Nom_epouse.ToString();
                            // string datemariage = lstusr[i].Date_mariage.ToString();
                            string statut = lstusr[i].Statut.ToString();

                            string[] row1 = new string[] {
                         //  id,
                           matricule,
                           nompolicier,
                           nomepouse,
                           id,
                           statut,
                           
                           //datemariage,
                          
                        };
                            dataGridView1.Rows.Add(row1);
                            dataGridView1.Visible = true;
                        }
                    }
                }
                else
                    dgw.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmdivorce_Load(object sender, EventArgs e)
        {

            DataGridViewCheckBoxColumn dgCheckBox = new DataGridViewCheckBoxColumn();
            dgCheckBox.DisplayIndex = 0;
            dgCheckBox.Width = 50;
            dgCheckBox.Name = "dg";
            dgCheckBox.HeaderText = "";
            dataGridView1.Columns.Add(dgCheckBox);

            comboBox1.DataSource = new List<string> { "Marié(e)", "Divorcé(e)" };
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            select = (from row in dataGridView1.Rows.Cast<DataGridViewRow>()
                      where Convert.ToBoolean(row.Cells["dg"].Value) == true
                      select row).ToList();
            if (MessageBox.Show(string.Format("Voulez-vous enregistrer un divorce pour  {0} dossiers?", select.Count), "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                panel7.Visible = true;
            }
            else { panel7.Visible = false; }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            List<DataGridViewRow> selectedRows = (from row in dataGridView1.Rows.Cast<DataGridViewRow>()
                                                  where Convert.ToBoolean(row.Cells["dg"].Value) == true
                                                  select row).ToList();
            foreach (DataGridViewRow row in selectedRows)
            {
                Object num = row.Cells[3].Value;
                int num1 = Convert.ToInt32(num);

                ConnectionString cn = new ConnectionString();
                SqlConnection dbConn;
                dbConn = new SqlConnection(cn.DBConn());
                dbConn.Open();

                SqlCommand myCommand = new SqlCommand("update Epouses set Date_divorce=@e1, Statut=@e2 where Epouse_ID='" + num1 + "'", dbConn);

                myCommand.Parameters.AddWithValue("@e1", dateTimePicker1.Value);
                myCommand.Parameters.AddWithValue("@e2", comboBox1.SelectedValue);
                myCommand.ExecuteNonQuery();
                MessageBox.Show("Divorce ajouté avec succès");
                panel7.Hide();
                affichage();
            }

        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                dgw.Rows.Clear();

                List<View_policierDivorce> lstusr = null;

                if (textBox1.Text.ToString() != "")
                {
                    dgw.Rows.Clear();
                    int var = Convert.ToInt32(textBox1.Text.ToString());
                    lstusr = dbpfen.View_policierDivorce.Where(x => x.Matricule_ID == var).ToList();
                    if (lstusr != null)
                    {
                        for (int i = 0; i < lstusr.Count(); i++)
                        {

                            string id = lstusr[i].Epouse_ID.ToString();
                            string nomepouse = lstusr[i].Nom_epouse.ToString();
                            string datemariage = lstusr[i].Date_mariage.ToString();
                            string datedivorce = lstusr[i].Date_divorce.ToString();

                            string[] row1 = new string[] {
                           id,
                           nomepouse,
                           datemariage,
                           datedivorce,
                           
                          
                        };

                            dgw.Rows.Add(row1);
                            dgw.Visible = true;

                        }
                    }
                }
                else if (textBox2.Text.ToString() != "")
                {
                    dgw.Rows.Clear();
                    string var = textBox2.Text.ToString();
                    lstusr = dbpfen.View_policierDivorce.Where(x => x.Nom_policier == var).ToList();
                    if (lstusr != null)
                    {
                        for (int i = 0; i < lstusr.Count(); i++)
                        {
                            MessageBox.Show(lstusr.Count.ToString());
                            string id = lstusr[i].Epouse_ID.ToString();
                            string nomepouse = lstusr[i].Nom_epouse.ToString();
                            string datemariage = lstusr[i].Date_mariage.ToString();
                            string datedivorce = lstusr[i].Date_divorce.ToString();

                            string[] row1 = new string[] {
                           id,
                           nomepouse,
                           datemariage,
                           datedivorce,

                          
                        };

                            dataGridView1.Rows.Add(row1);
                            dataGridView1.Visible = true;
                        }
                    }
                }
                else if (textBox1.Text.ToString() != "" && textBox2.Text.ToString() != "")
                {
                    dgw.Rows.Clear();
                    int var = Convert.ToInt32(textBox1.Text.ToString());
                    lstusr = dbpfen.View_policierDivorce.Where(x => (x.Matricule_ID == var) && (x.Nom_policier == textBox2.Text.ToString())).ToList();
                    if (lstusr != null)
                    {
                        for (int i = 0; i < lstusr.Count(); i++)
                        {
                            string id = lstusr[i].Epouse_ID.ToString();
                            string nomepouse = lstusr[i].Nom_epouse.ToString();
                            string datemariage = lstusr[i].Date_mariage.ToString();
                            string datedivorce = lstusr[i].Date_divorce.ToString();

                            string[] row1 = new string[] {
                           id,
                           nomepouse,
                           datemariage,
                           datedivorce,
                          
                        };
                            dataGridView1.Rows.Add(row1);
                            dataGridView1.Visible = true;
                        }
                    }
                }
                else
                    dgw.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void affichage()
        {
            dgw.Rows.Clear();

            List<View_policierDivorce> lstusr = null;

            if (textBox1.Text.ToString() != "")
            {
                dgw.Rows.Clear();
                int var = Convert.ToInt32(textBox1.Text.ToString());
                lstusr = dbpfen.View_policierDivorce.Where(x => x.Matricule_ID == var).ToList();
                if (lstusr != null)
                {
                    for (int i = 0; i < lstusr.Count(); i++)
                    {

                        string id = lstusr[i].Epouse_ID.ToString();
                        string nomepouse = lstusr[i].Nom_epouse.ToString();
                        string datemariage = lstusr[i].Date_mariage.ToString();
                        string datedivorce = lstusr[i].Date_divorce.ToString();

                        string[] row1 = new string[] {
                           id,
                           nomepouse,
                           datemariage,
                           datedivorce,
                           
                          
                        };

                        dgw.Rows.Add(row1);
                        dgw.Visible = true;

                    }
                }
            }

        }
    }
}
