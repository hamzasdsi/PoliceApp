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
    public partial class formMut : MetroFramework.Forms.MetroForm
    {
        public formMut()
        {
            InitializeComponent();
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
                  

                    string id = lstusr[i].Matricule_ID.ToString();

                    string[] row1 = new string[] {
                        id,
                            nom,
                           
                         
                           
                         
                        };

                    dataGridView1.Rows.Add(row1);
                    dataGridView1.Visible = true;
                }
            }


        }
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            button8.Visible = true;
            if (textBox4.Text == string.Empty)
            {
                affichage();
            }
            else
            {
                List<polic> lstusr = null;
                DBpoliceEntities dbpfen = new DBpoliceEntities();
                dataGridView1.Rows.Clear();
                int var = Convert.ToInt32(textBox4.Text.ToString());
                lstusr = dbpfen.polic.Where(x => x.Matricule_ID == var).ToList();



                if (lstusr.Count() != 0)
                {
                    for (int i = 0; i < lstusr.Count(); i++)
                    {

                        string nom = lstusr[i].Nom_policier.ToString();
                  

                        string id = lstusr[i].Matricule_ID.ToString();

                        string[] row1 = new string[] {
                        id,
                            nom,
                           
                   
                           
                         
                        };

                        dataGridView1.Rows.Add(row1);
                        dataGridView1.Visible = true;
                    }


                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DBpoliceEntities dbpfen = new DBpoliceEntities();
        private void formMut_Load(object sender, EventArgs e)
        {
            comboBox4.ValueMember = "agence_ID";
            comboBox4.DisplayMember = "Libelle";
            comboBox4.DataSource = dbpfen.detach_agence.ToList<detach_agence>();

            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "libelle";
            comboBox1.DataSource = dbpfen.type_dec.ToList<type_dec>();

            DataGridViewCheckBoxColumn dgCheckBox = new DataGridViewCheckBoxColumn();
            dgCheckBox.DisplayIndex = 0;
            dgCheckBox.Width = 50;
            dgCheckBox.Name = "dg";
            dgCheckBox.HeaderText = "";
            dataGridView1.Columns.Add(dgCheckBox);
        }
        public static List<DataGridViewRow> select;
        private void button8_Click(object sender, EventArgs e)
        {
            select = (from row in dataGridView1.Rows.Cast<DataGridViewRow>()
                      where Convert.ToBoolean(row.Cells["dg"].Value) == true
                      select row).ToList();


            if (MessageBox.Show(string.Format("Voulez-vous enregistrer une mutation pour {0} policier?", select.Count), "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                panel7.Visible = true;

            }
            else
            {

                panel7.Visible = false;
            }
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
                    string insertCmd = "INSERT INTO mutation(agence,idpolicier,motif,numdec,datedec,typedec) VALUES (@f,@f1,@f2,@f3,@f4,@f5)";
                    SqlConnection dbConn;
                    dbConn = new SqlConnection(cn.DBConn());
                    dbConn.Open();
                    //Authentification lg = new Authentification();

                    //GetValue value = new GetValue();

                    SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);
                    int var = Convert.ToInt32(comboBox4.SelectedValue.ToString());
                    int var1 = Convert.ToInt32(comboBox1.SelectedValue.ToString());

                    myCommand.Parameters.AddWithValue("@f", var);
                    myCommand.Parameters.AddWithValue("@f1",num1);
                    myCommand.Parameters.AddWithValue("@f2", richTextBox1.Text);
                    myCommand.Parameters.AddWithValue("@f3", textBox5.Text);
                    myCommand.Parameters.AddWithValue("@f4", dateTimePicker4.Value);
                    myCommand.Parameters.AddWithValue("@f5", var1);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          /*  if (textBox1.Text != string.Empty)
            {
                int n = Convert.ToInt32(textBox1.Text);

                var priv = (from emp in dbpfen.Policier
                            where emp.Matricule_ID == n
                            select emp.Nom_policier);
                textBox2.Text = priv.SingleOrDefault();
            }*/
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != string.Empty)
            {
                int n = Convert.ToInt32(textBox4.Text);

                var priv = (from emp in dbpfen.Policier
                            where emp.Matricule_ID == n
                            select emp.Nom_policier);
                textBox3.Text = priv.SingleOrDefault();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label11.Text = "Date décret:";
                label6.Text = "Numéro décret:";
            }

            if (comboBox1.SelectedIndex == 1)
            {
                label11.Text = "Date décision:";
                label6.Text = "Numéro décision:";
            }

            if (comboBox1.SelectedIndex == 2)
            {
                label11.Text = "Date arreté:";
                label6.Text = "Numéro arreté:";
            }
            if (comboBox1.SelectedIndex == 3)
            {
                label11.Text = "Date note service:";
                label6.Text = "Numéro note service:";
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
