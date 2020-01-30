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
using Excel = Microsoft.Office.Interop.Excel;

namespace PoliceApp
{
    public partial class congé : MetroFramework.Forms.MetroForm
    {
        public congé()
        {
            InitializeComponent();
        }
        public static List<DataGridViewRow> select;
        DBpoliceEntities dbpfen = new DBpoliceEntities();
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            select = (from row in dataGridView1.Rows.Cast<DataGridViewRow>()
                      where Convert.ToBoolean(row.Cells["dg"].Value) == true
                      select row).ToList();


            if (MessageBox.Show(string.Format("Voulez-vous enregistrer un congé {0} dossiers?", select.Count), "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                /* object n = dataGridView1.Rows[0].Cells["dg"].Value;
                 bool n1 = Convert.ToBoolean(dataGridView1.Rows[0].Cells["dg"].Value);
                 if (n1 = true)
                     button8.Visible = true;*/

                panel7.Visible = true;

            }
            else
            {

                panel7.Visible = false;
            }
        }

        private void congé_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn dgCheckBox = new DataGridViewCheckBoxColumn();
            dgCheckBox.DisplayIndex = 0;
            dgCheckBox.Width = 50;
            dgCheckBox.Name = "dg";
            dgCheckBox.HeaderText = "";
            dataGridView1.Columns.Add(dgCheckBox);




            comboBox3.ValueMember = "Direction_ID";
            comboBox3.DisplayMember = "Type_direction";
            comboBox3.DataSource = dbpfen.Direction.ToList<Direction>();

            comboBox4.ValueMember = "id";
            comboBox4.DisplayMember = "libelle";
            comboBox4.DataSource = dbpfen.Type_Conge.ToList<Type_Conge>();
        }

        private void affichage()
        {
            /* dgw.Visible = true;

             List<View_congé> lstusr = null;
             DBpoliceEntities dbpfen = new DBpoliceEntities();

             lstusr = dbpfen.View_congé.ToList();
             if (lstusr.Count() != 0)
             {
                 for (int i = 0; i < lstusr.Count(); i++)
                 {

                     string nom = lstusr[i].Nom_policier.ToString();
                     string typecong = lstusr[i].libelle.ToString();
                     DateTime date = Convert.ToDateTime(lstusr[i].dateD.Value.Date);
                     String d = Convert.ToString(date.ToShortDateString());

                     DateTime date2 = Convert.ToDateTime(lstusr[i].dateF.Value.Date);
                     String d2 = Convert.ToString(date2.ToShortDateString());

                     string id = lstusr[i].Matricule_ID.ToString();
                     string[] row1 = new string[] {
                                id,
                         nom,
                             typecong,
                            d,
                                   d2,
                           
                         };

                     dgw.Rows.Add(row1);
                     dgw.Visible = true;
                 }
             }

             */
        }


        private void button1_Click(object sender, EventArgs e)
        {


        }



        private void txtPatientID_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            /* if (!textBox1.Text.Equals(""))
             {
                 DBpoliceEntities dbpfen = new DBpoliceEntities();
                 int num = Convert.ToInt32(textBox1.Text);
                 List<View_congé> lstusr = null;


                 lstusr = dbpfen.View_congé.ToList().Where(x => x.Matricule_ID == num).ToList();
                 dgw.Rows.Clear();
                 if (lstusr.Count() != 0)
                 {
                     for (int i = 0; i < lstusr.Count(); i++)
                     {

                         string nom = lstusr[i].Nom_policier.ToString();
                         string typecong = lstusr[i].libelle.ToString();
                         DateTime date = Convert.ToDateTime(lstusr[i].dateD.Value.Date);
                         String d = Convert.ToString(date.ToShortDateString());

                         DateTime date2 = Convert.ToDateTime(lstusr[i].dateF.Value.Date);
                         String d2 = Convert.ToString(date2.ToShortDateString());
                         string id  = lstusr[i].Matricule_ID.ToString();

                         string[] row1 = new string[] {
                                 id,
                             nom,
                             typecong,
                            d,
                                   d2
                              
                         };

                         dgw.Rows.Add(row1);
                         dgw.Visible = true;


                     }

                 }
             }
             else
             {
                 affichage();

             }

           */


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

        private void button2_Click(object sender, EventArgs e)
        {
            //  textBox1.Text = string.Empty;
            // panel6.Visible = false;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            /*  try
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
              */
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            button8.Visible = true;
            if (textBox4.Text != string.Empty)
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


                        string id = lstusr[i].Matricule_ID.ToString();

                        string typ = lstusr[i].Type_direction.ToString();
                        string[] row1 = new string[] {
                        id,
                            nom,
                           typ
                   
                           
                         
                        };

                        dataGridView1.Rows.Add(row1);
                        dataGridView1.Visible = true;
                    }


                }
            }
            else if (comboBox3.Text != null)
            {
                List<View_policDir> lstusr = null;
                DBpoliceEntities dbpfen = new DBpoliceEntities();
                dataGridView1.Rows.Clear();

                lstusr = dbpfen.View_policDir.Where(x => x.Type_direction == comboBox3.Text).ToList();



                if (lstusr.Count() != 0)
                {
                    for (int i = 0; i < lstusr.Count(); i++)
                    {

                        string nom = lstusr[i].Nom_policier.ToString();


                        string id = lstusr[i].Matricule_ID.ToString();
                        string typ = lstusr[i].Type_direction.ToString();

                        string[] row1 = new string[] {
                        id,
                            nom,
                        typ
                   
                           
                         
                        };

                        dataGridView1.Rows.Add(row1);
                        dataGridView1.Visible = true;
                    }


                }

            }
            else
            {
                affichage();
            }

        }

        private void affichage1()
        {
            /*  dgw.Visible = true;

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
                          nom,
                          //    type,
                         
                          
                          };

                      dataGridView1.Rows.Add(row1);
                      dataGridView1.Visible = true;
                  }
              }


          }
          DBpoliceEntities ent = new DBpoliceEntities();
       
              private void button1_Click_1(object sender, EventArgs e)
          {
              int rowindex = dgw.CurrentRow.Index;
         int  usrdel = 0;
              usrdel = Convert.ToInt32((string)dgw[4, rowindex].Value);
              if (usrdel != null)
              {
                  if (MessageBox.Show("Supprimer ce congé?", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                  {
               conge usedel = null;
                      usedel = dbpfen.conge.Where(x => x.idPolicier == usrdel).ToList().First();
                    dbpfen.conge.Remove(usedel);
                      dbpfen.SaveChanges();
                      MessageBox.Show("Congé supprimé avec succès", "Supprimer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      dgw.Rows.RemoveAt(dgw.CurrentRow.Index);

                  }

              }*/
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            affichage2();
            //button1.Visible = true;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == 3)
            {
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
                    string insertCmd = "INSERT INTO conge (dateD,dateF,typeConge,idPolicier,dateSave) VALUES (@f,@f1,@f2,@f3,@f4)";
                    SqlConnection dbConn;
                    dbConn = new SqlConnection(cn.DBConn());
                    dbConn.Open();
                    //Authentification lg = new Authentification();

                    //GetValue value = new GetValue();

                    SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);
                    int var = Convert.ToInt32(comboBox4.SelectedValue.ToString());
                    myCommand.Parameters.AddWithValue("@f", dateTimePicker4.Value);
                    myCommand.Parameters.AddWithValue("@f1", dateTimePicker3.Value);
                    myCommand.Parameters.AddWithValue("@f2", var);
                    myCommand.Parameters.AddWithValue("@f3", num1);
                    myCommand.Parameters.AddWithValue("@f4", DateTime.Now);
                    myCommand.ExecuteNonQuery();




                }
                MessageBox.Show("Ajouté avec succès");
                affichage();
                if (comboBox4.SelectedIndex == 0)
                {
                    lisConge f = new lisConge();
                    f.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {



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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void affichage2()
        {
            dataGridView2.Visible = true;
            dataGridView2.Rows.Clear();
            List<View_congé> lstusr;
            List<View_congé> lstusr1;
            DBpoliceEntities dbpfen = new DBpoliceEntities();
            object mat = dataGridView1.Rows[0].Cells[0].Value;
            int mat2 = Convert.ToInt32(mat);
            object typ = dataGridView1.Rows[0].Cells[2].Value;
            string typ2 = Convert.ToString(typ);
            lstusr = dbpfen.View_congé.Where(x => x.Matricule_ID == mat2).ToList();
            lstusr1 = dbpfen.View_congé.Where(x => x.Type_direction == typ2).ToList();
            if (lstusr != null)
            {
                for (int i = 0; i < lstusr.Count(); i++)
                {

                    //string nom = lstusr[i].Nom_policier.ToString();0
                    string type = lstusr[i].libelle.ToString();

                    DateTime date = Convert.ToDateTime(lstusr[i].dateD.Value.Date);
                    String d = Convert.ToString(date.ToShortDateString());
                    DateTime date2 = Convert.ToDateTime(lstusr[i].dateF.Value.Date);
                    String d2 = Convert.ToString(date2.ToShortDateString());
                    string idpolicier = Convert.ToString(lstusr[i].Matricule_ID);
                    string[] row1 = new string[] {
                       type,
                      d,
                      d2,
                      idpolicier
                          
                        };

                    dataGridView2.Rows.Add(row1);
                    dataGridView2.Visible = true;
                }

            }
            else if (lstusr1 != null)
            {
                dataGridView2.Refresh();

                for (int i = 0; i < lstusr1.Count(); i++)
                {

                    //string nom = lstusr[i].Nom_policier.ToString();0
                    string type = lstusr1[i].libelle.ToString();

                    DateTime date = Convert.ToDateTime(lstusr1[i].dateD.Value.Date);
                    String d = Convert.ToString(date.ToShortDateString());
                    DateTime date2 = Convert.ToDateTime(lstusr1[i].dateF.Value.Date);
                    String d2 = Convert.ToString(date2.ToShortDateString());
                    string idpolicier = Convert.ToString(lstusr[i].Matricule_ID);
                    string[] row1 = new string[] {
                       type,
                      d,
                      d2,
                      idpolicier
                          
                        };

                    dataGridView2.Rows.Add(row1);
                    dataGridView2.Visible = true;
                }
            }




        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Text = string.Empty;
            textBox3.Text = string.Empty;
        }
        ConnectionString cn = new ConnectionString();
        private void button1_Click_1(object sender, EventArgs e)

        {
            object id=dataGridView2.Rows[0].Cells[3].Value;
            
            int id1=Convert.ToInt32(id);
            DialogResult dr = System.Windows.Forms.MessageBox.Show("Supprimer ce congé?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

        if (dr == DialogResult.Yes)
        {
            var query =
                from t in dbpfen.conge
                where t.idPolicier ==id1 
                select t;

            var items = query.ToList();
                        
            foreach (var item in items)
            {
                dbpfen.conge.Remove(item);
                dbpfen.SaveChanges();
            }
            dataGridView2.Refresh();
            MessageBox.Show("congé supprimé avec succès", "Supprimer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        

          
       

        }
    

        }
    }
}
