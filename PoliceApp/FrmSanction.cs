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
    public partial class FrmSanction : MetroFramework.Forms.MetroForm
    {
        public FrmSanction()
        {
            InitializeComponent();
        }
        DBpoliceEntities dbpfen = new DBpoliceEntities();
        private void FrmSanction_Load(object sender, EventArgs e)
        {
            comboBox4.ValueMember = "id";
            comboBox4.DisplayMember = "libelle";
            comboBox4.DataSource = dbpfen.Type_sanction.ToList<Type_sanction>();

   

            DataGridViewCheckBoxColumn dgCheckBox = new DataGridViewCheckBoxColumn();
            dgCheckBox.DisplayIndex = 0;
            dgCheckBox.Width = 50;
            dgCheckBox.Name = "dg";
            dgCheckBox.HeaderText = "";
            dgw.Columns.Add(dgCheckBox);

            comboBox4.ValueMember = "id";
            comboBox4.DisplayMember = "libelle";
            comboBox4.DataSource = dbpfen.Type_sanction.ToList<Type_sanction>();

            comboBox2.ValueMember = "Grade_ID";
            comboBox2.DisplayMember = "Libelle";
            comboBox2.DataSource = dbpfen.Grad.ToList<Grad>();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void affichage()
        {
            dgw.Visible = true;

            List<View_sanction> lstusr = null;
            DBpoliceEntities dbpfen = new DBpoliceEntities();

            lstusr = dbpfen.View_sanction.ToList();
            if (lstusr.Count() != 0)
            {
                for (int i = 0; i < lstusr.Count(); i++)
                {

                    string nom = lstusr[i].Nom_policier.ToString();
                    string typesanction = lstusr[i].libelle.ToString();
                    string gr = lstusr[i].Expr1.ToString();
                    DateTime date = Convert.ToDateTime(lstusr[i].datedec.Value.Date);
                    String d = Convert.ToString(date.ToShortDateString());
                    string n = lstusr[i].numdec.ToString();


                    string aut = lstusr[i].autorite.ToString();
                    string id = lstusr[i].Matricule_ID.ToString();
                    string motif = lstusr[i].motif.ToString();
                    string[] row1 = new string[] {
                            id,
                            nom,
                            gr,
                           typesanction ,
                           
                           d,
                           n,
                           aut,
                             motif
                              
                        };

                    dgw.Rows.Add(row1);
                    dgw.Visible = true;
                }
            }


        }
        public static List<DataGridViewRow> select;
        private void button8_Click(object sender, EventArgs e)
        {
            select = (from row in dgw.Rows.Cast<DataGridViewRow>()
                      where Convert.ToBoolean(row.Cells["dg"].Value) == true
                      select row).ToList();


            if (MessageBox.Show(string.Format("Voulez-vous enregistrer une sanction pour {0} dossiers?", select.Count), "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)

            {

                panel7.Visible = true;

            }
            else
            {

                panel7.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dgw.Visible = true;
            button8.Visible = true;
            affichage1();
        }
        private void affichage1()
        {
            dgw.Visible = true;


            if (textBox4.Text != string.Empty)
            {
                List<View_policierGrad> lstusr = null;
                DBpoliceEntities dbpfen = new DBpoliceEntities();
                dgw.Rows.Clear();
                int var = Convert.ToInt32(textBox4.Text.ToString());
                lstusr = dbpfen.View_policierGrad.Where(x => x.Matricule_ID == var).ToList();


                if (lstusr.Count() != 0)
                {
                    for (int i = 0; i < lstusr.Count(); i++)
                    {

                        string nom = lstusr[i].Nom_policier.ToString();
                        string type = lstusr[i].Libelle.ToString();
                        string id = lstusr[i].Matricule_ID.ToString();

                        string[] row1 = new string[] {
                             id,
                        nom,
                            type,
                            

                        };

                        dgw.Rows.Add(row1);
                        dgw.Visible = true;
                    }
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex==6)
            {
                panel6.Visible = true;
                textBox7.Text =Convert.ToString( dgw.Rows[0].Cells[2].Value);


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> selectedRows = (from row in dgw.Rows.Cast<DataGridViewRow>()
                                                  where Convert.ToBoolean(row.Cells["dg"].Value) == true

                                                  select row).ToList();

            try
            {
                foreach (DataGridViewRow row in selectedRows)
                {

                    Object num = row.Cells[0].Value;
                    int num1 = Convert.ToInt32(num);

                    ConnectionString cn = new ConnectionString();
                    string insertCmd = "INSERT INTO sanction(datedec,numdec,motif,idPolicier,typeSanct,autorite) VALUES (@f,@f1,@f2,@f3,@f4,@f5)";
                    SqlConnection dbConn;
                    dbConn = new SqlConnection(cn.DBConn());
                    dbConn.Open();
                    //Authentification lg = new Authentification();

                    //GetValue value = new GetValue();

                    SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);
                    int var = Convert.ToInt32(comboBox4.SelectedValue.ToString());
                    myCommand.Parameters.AddWithValue("@f", dateTimePicker4.Value);
                    myCommand.Parameters.AddWithValue("@f1", textBox5.Text);
                    myCommand.Parameters.AddWithValue("@f2", richTextBox1.Text);
                    myCommand.Parameters.AddWithValue("@f3", num1);
                    myCommand.Parameters.AddWithValue("@f4", var);
                    myCommand.Parameters.AddWithValue("@f5", textBox6.Text);
                    myCommand.ExecuteNonQuery();




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
                MessageBox.Show("Ajouté avec succès");
           
               // lisConge f = new lisConge();
               // f.ShowDialog();
          
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

        private void button1_Click(object sender, EventArgs e)
        {
            int rowindex = dgw.CurrentRow.Index;
            int usrdel = 0;
            usrdel = Convert.ToInt32((string)dgw[7, rowindex].Value);
            if (usrdel != null)
            {
                if (MessageBox.Show("Supprimer cette sanction?", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                  sanction usedel = null;
                    usedel = dbpfen.sanction.Where(x => x.idPolicier == usrdel).ToList().First();
                    dbpfen.sanction.Remove(usedel);
                    dbpfen.SaveChanges();
                    MessageBox.Show("Sanction supprimée avec succès", "Supprimer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgw.Rows.RemoveAt(dgw.CurrentRow.Index);

                }

            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
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

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        private void dgw_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            affichage2();

        }
        private void affichage2()
        {
            dataGridView2.Visible = true;
            dataGridView2.Rows.Clear();
            List<View_sanction> lstusr;
            List<View_sanction> lstusr1;
            DBpoliceEntities dbpfen = new DBpoliceEntities();
            object mat = dgw.Rows[0].Cells[0].Value;
            int mat2 = Convert.ToInt32(mat);
            object typ = dgw.Rows[0].Cells[2].Value;
            string typ2 = Convert.ToString(typ);
            lstusr = dbpfen.View_sanction.Where(x => x.Matricule_ID == mat2).ToList();
         
            if (lstusr != null)
            {
                for (int i = 0; i < lstusr.Count(); i++)
                {

                    //string nom = lstusr[i].Nom_policier.ToString();0
                    string type = lstusr[i].libelle.ToString();

                    DateTime date = Convert.ToDateTime(lstusr[i].datedec.Value.Date);
                    string d = Convert.ToString(date.ToShortDateString());
                    string n = lstusr[i].numdec.ToString(); 
                    string idpolicier = Convert.ToString(lstusr[i].Matricule_ID);
                    string[] row1 = new string[] {
                       type,
                   d,
                   n,
                      idpolicier
                          
                        };

                    dataGridView2.Rows.Add(row1);
                    dataGridView2.Visible = true;
                }

            }
           



        }
    }
}
