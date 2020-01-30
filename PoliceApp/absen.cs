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
    public partial class absen : Form
    {
        public absen()
        {
            InitializeComponent();
        }
        DBpoliceEntities dbpfen = new DBpoliceEntities();
        private void absen_Load(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "libelle";
            comboBox1.DataSource = dbpfen.Type_Conge.ToList<Type_Conge>();

            DataGridViewCheckBoxColumn dgCheckBox = new DataGridViewCheckBoxColumn();
            dgCheckBox.DisplayIndex = 0;
            dgCheckBox.Width = 50;
            dgCheckBox.Name = "dg";
            dgCheckBox.HeaderText = "";
            dataGridView1.Columns.Add(dgCheckBox);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static List<DataGridViewRow> select;
        private void btnReset_Click(object sender, EventArgs e)
        {

            select = (from row in dataGridView1.Rows.Cast<DataGridViewRow>()
                      where Convert.ToBoolean(row.Cells["dg"].Value) == true
                      select row).ToList();


            if (MessageBox.Show(string.Format("Voulez-vous enregistrer un congé {0} dossiers?", select.Count), "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)

            {

                panel6.Visible = true;

            }
            else
            {

                panel6.Visible = false;
            }


        }
        private void affichage()
        {
            dgw.Visible = true;

            List<View_absenc> lstusr = null;
            DBpoliceEntities dbpfen = new DBpoliceEntities();

            lstusr = dbpfen.View_absenc.ToList();
            if (lstusr.Count() != 0)
            {
                for (int i = 0; i < lstusr.Count(); i++)
                {

                    string id = lstusr[i].Matricule_ID.ToString();
                    string nom = lstusr[i].Nom_policier.ToString();
                    string typeabs = lstusr[i].libelle.ToString();
       DateTime dateb = Convert.ToDateTime(lstusr[i].dateab.ToString());
                    string d1 = Convert.ToString(dateb.ToShortDateString());
               DateTime   datef = Convert.ToDateTime( lstusr[i].datef.ToString());
                    string d2 = Convert.ToString(datef.ToShortDateString());
                    string com = lstusr[i].comment.ToString();
                    string[] row1 = new string[] {
                        id,
                        nom,

                           d1,
                           d2,
                                  typeabs,
                                  com
                        };

                    dgw.Rows.Add(row1);
                    dgw.Visible = true;
                }
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {


            ConnectionString cn = new ConnectionString();
            string insertCmd = "INSERT INTO absences (dateab,motif,idpolicier) VALUES (@f,@f1,@f2)";
            SqlConnection dbConn;
            dbConn = new SqlConnection(cn.DBConn());
            dbConn.Open();
            //Authentification lg = new Authentification();

            //GetValue value = new GetValue();

            SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);
            int var = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            // myCommand.Parameters.AddWithValue("@f2", txtPatientID.Text);
            myCommand.Parameters.AddWithValue("@f", dateTimePicker1.Value);
            myCommand.Parameters.AddWithValue("@f1", var);
            myCommand.ExecuteNonQuery();

            MessageBox.Show("Ajouté avec succès");
            affichage();

        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))
            {
                DBpoliceEntities dbpfen = new DBpoliceEntities();
                int num = Convert.ToInt32(textBox1.Text);
                List<View_absenc> lstusr = null;


                lstusr = dbpfen.View_absenc.ToList().Where(x => x.Matricule_ID == num).ToList();
                dgw.Rows.Clear();
                if (lstusr.Count() != 0)
                {
                    for (int i = 0; i < lstusr.Count(); i++)
                    {

                        string nom = lstusr[i].Nom_policier;
                        DateTime date = Convert.ToDateTime(lstusr[i].dateab.Value.Date);
                        String d = Convert.ToString(date.ToShortDateString());
                        string motif = lstusr[i].libelle.ToString();

                        string[] row1 = new string[] {
                            nom,

                        d,
                        motif


                        };

                        dgw.Rows.Add(row1);
                        dgw.Visible = true;


                    }

                }
            }
            else
            {
                //MessageBox.Show("veuillez rentrer un critére");
                affichage();

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                int n = Convert.ToInt32(textBox1.Text);

                var priv = (from emp in dbpfen.Policier
                            where emp.Matricule_ID == n
                            select emp.Nom_policier);
                textBox2.Text = priv.SingleOrDefault();
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                int StartCol = 1;
                int StartRow = 1;
                int j = 0, i = 0;

                //Write Headers
                for (j = 0; j < dgw.Columns.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = dgw.Columns[j].HeaderText;
                }

                StartRow++;

                //Write datagridview content
                for (i = 0; i < dgw.Rows.Count; i++)
                {
                    for (j = 0; j < dgw.Columns.Count; j++)
                    {
                        try
                        {
                            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                            myRange.Value2 = dgw[j, i].Value == null ? "" : dgw[j, i].Value;
                        }
                        catch
                        {
                            ;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void affichage1()
        {
            dgw.Visible = true;

            List<View_policDir> lstusr = null;


            lstusr = dbpfen.View_policDir.ToList();
            if (lstusr.Count() != 0)
            {
                for (int i = 0; i < lstusr.Count(); i++)
                {

                    string nom = lstusr[i].Nom_policier.ToString();
                    // string type = lstusr[i].Type_direction.ToString();
                    string id = lstusr[i].Matricule_ID.ToString();

                    string[] row1 = new string[] {
                           id,
                        nom



                        };

                    dataGridView1.Rows.Add(row1);
                    dataGridView1.Visible = true;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            affichage1();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            List<DataGridViewRow> selectedRows = (from row in dataGridView1.Rows.Cast<DataGridViewRow>()
                                                  where Convert.ToBoolean(row.Cells["dg"].Value) == true

                                                  select row).ToList();
         
                foreach (DataGridViewRow row in selectedRows)
                {

                    Object num = row.Cells[0].Value;
                    int num1 = Convert.ToInt32(num);

                    ConnectionString cn = new ConnectionString();
                    string insertCmd = "INSERT INTO absences (dateab,motif,idpolicier,datef,comment,dateS) VALUES (@f,@f1,@f2,@f3,@f4,@f5)"; 
                    SqlConnection dbConn;
                    dbConn = new SqlConnection(cn.DBConn());
                    dbConn.Open();
                    //Authentification lg = new Authentification();

                    //GetValue value = new GetValue();

                    SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);
                    int var = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                    myCommand.Parameters.AddWithValue("@f", dateTimePicker1.Value);
                    myCommand.Parameters.AddWithValue("@f1", var);
                    myCommand.Parameters.AddWithValue("@f2", num1);
                    myCommand.Parameters.AddWithValue("@f3", dateTimePicker2.Value);
                    myCommand.Parameters.AddWithValue("@f4", richTextBox1.Text);
                    myCommand.Parameters.AddWithValue("@f5", DateTime.Now);
                    myCommand.ExecuteNonQuery();




                }
                MessageBox.Show("Ajouté avec succès");
                affichage();


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

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                int n = Convert.ToInt32(textBox1.Text);

                var priv = (from emp in dbpfen.Policier
                            where emp.Matricule_ID == n
                            select emp.Nom_policier);
                textBox2.Text = priv.SingleOrDefault();
            }
        }

        private void textBox1_TextAlignChanged(object sender, EventArgs e)
        {

        }
    }
    }

