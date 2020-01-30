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
    public partial class Recompen : Form
    {
        public Recompen()
        {
            InitializeComponent();
        }
        DBpoliceEntities dbpfen = new DBpoliceEntities();
        public static List<DataGridViewRow> select;
        private void Recompen_Load(object sender, EventArgs e)
        {
            comboBox4.ValueMember = "id";
            comboBox4.DisplayMember = "libelle";
            comboBox4.DataSource = dbpfen.Type_recompense.ToList<Type_recompense>();

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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                
                View_policierGrad lstusr = new View_policierGrad();
                if (textBox4.Text.ToString() != "")
                {
                    dgw.Rows.Clear();
                    int var = Convert.ToInt32(textBox4.Text.ToString());
                    lstusr = dbpfen.View_policierGrad.Where(x => x.Matricule_ID == var).ToList().First();
                    if (lstusr != null)
                    {
                        string nom = lstusr.Nom_policier.ToString();
                        string typegrade = lstusr.Libelle.ToString();
                        string id = lstusr.Matricule_ID.ToString();

                        string[] row1 = new string[] {
                           id,
                           nom,
                          typegrade,
                        };

                        dataGridView1.Rows.Add(row1);
                        dataGridView1.Visible = true;
                    }  
                }
                else if (textBox3.Text.ToString() != "")
                {
                    dgw.Rows.Clear();
                    string var = textBox3.Text.ToString();
                    lstusr = dbpfen.View_policierGrad.Where(x => x.Nom_policier == var).ToList().First();
                    if (lstusr != null)
                    {
                        string nom = lstusr.Nom_policier.ToString();
                        string typegrade = lstusr.Libelle.ToString();
                        string id = lstusr.Matricule_ID.ToString();

                        string[] row1 = new string[] {
                           id,
                          nom,
                          typegrade,
                        };

                        dataGridView1.Rows.Add(row1);
                        dataGridView1.Visible = true;
                    }
                }
                else if (textBox4.Text.ToString() != "" && textBox3.Text.ToString() != "")
                {
                    dgw.Rows.Clear();
                    int var = Convert.ToInt32(textBox4.Text.ToString());
                    lstusr = dbpfen.View_policierGrad.Where(x => (x.Matricule_ID == var) && (x.Nom_policier == textBox3.Text.ToString())).ToList().First();
                    if (lstusr != null)
                    {
                        string nom = lstusr.Nom_policier.ToString();
                        string typegrade = lstusr.Libelle.ToString();
                        string id = lstusr.Matricule_ID.ToString();

                        string[] row1 = new string[] {
                           id,
                          nom,
                          typegrade,
                        };
                        dataGridView1.Rows.Add(row1);
                        dataGridView1.Visible = true;
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
        private void button8_Click(object sender, EventArgs e)
        {
            select = (from row in dataGridView1.Rows.Cast<DataGridViewRow>()
                      where Convert.ToBoolean(row.Cells["dg"].Value) == true
                      select row).ToList();
             if (MessageBox.Show(string.Format("Voulez-vous enregistrer une récompense pour  {0} dossiers?", select.Count), "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
              { 
                panel7.Visible = true;
              }
            else  {  panel7.Visible = false;  }
        }

        private void tabPage2_Click(object sender, EventArgs e)  {}

        private void button5_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> selectedRows = (from row in dataGridView1.Rows.Cast<DataGridViewRow>()
                                                  where Convert.ToBoolean(row.Cells["dg"].Value) == true
                                                  select row).ToList();
              foreach (DataGridViewRow row in selectedRows)
                {
                    Object num = row.Cells[0].Value;
                    int num1 = Convert.ToInt32(num);

                    ConnectionString cn = new ConnectionString();
                    string insertCmd = "INSERT INTO recompense (datedec,numdec,typeRecomp,idPolicier,dateS,autorite) VALUES (@f,@f1,@f2,@f3,@f4,@f5)";
                    SqlConnection dbConn;
                    dbConn = new SqlConnection(cn.DBConn());
                    dbConn.Open();
                   
                    SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);
                    int var = Convert.ToInt32(comboBox4.SelectedValue.ToString());
                    myCommand.Parameters.AddWithValue("@f", dateTimePicker4.Value);
                    myCommand.Parameters.AddWithValue("@f1", textBox5.Text);
                    myCommand.Parameters.AddWithValue("@f2", var);
                    myCommand.Parameters.AddWithValue("@f3", num1);
                    myCommand.Parameters.AddWithValue("@f4", DateTime.Now);
                    myCommand.Parameters.AddWithValue("@f5", textBox6.Text);
                    myCommand.ExecuteNonQuery();
                    MessageBox.Show("Ajouté avec succès");
                    panel7.Hide();
                 }
                  
                 
            }

        private void btnGetData_Click(object sender, EventArgs e)
        {


            dgw.Visible = true;

            List<View_recompense> lstusr = null;
            DBpoliceEntities dbpfen = new DBpoliceEntities();

            lstusr = dbpfen.View_recompense.ToList();
            if (lstusr.Count() != 0)
            {
                for (int i = 0; i < lstusr.Count(); i++)
                {

                    string nom = lstusr[i].Nom_policier.ToString();
                    string typerecompense = lstusr[i].libelle.ToString();
                    DateTime date = Convert.ToDateTime(lstusr[i].datedec.Value.Date);
                    String d = Convert.ToString(date.ToShortDateString());

                   // DateTime date2 = Convert.ToDateTime(lstusr[i].dateF.Value.Date);
                    //String d2 = Convert.ToString(date.ToShortDateString());
                    string numdec = lstusr[i].numdec.ToString();
                    string id = lstusr[i].Matricule_ID.ToString();
                    string autorite = lstusr[i].autorite.ToString();
                    string[] row1 = new string[] {
                               id,
                        nom,
                            typerecompense,
                           d,
                                  numdec,
                           autorite,
                           
                        };

                    dgw.Rows.Add(row1);
                    dgw.Visible = true;
                }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox4_DropDown(object sender, EventArgs e) {}

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

 }

