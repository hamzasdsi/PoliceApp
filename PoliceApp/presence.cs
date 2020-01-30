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
using System.Globalization;
namespace PoliceApp
{
    public partial class presence : MetroFramework.Forms.MetroForm
    {
        public presence()
        {
            InitializeComponent();
        }
        DBpoliceEntities dbpfen = new DBpoliceEntities();
        public static List<DataGridViewRow> select;
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
               
            }
        }

        private void presence_Load(object sender, EventArgs e)
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

        private void button8_Click(object sender, EventArgs e)
        {
            select = (from row in dataGridView1.Rows.Cast<DataGridViewRow>()
                      where Convert.ToBoolean(row.Cells["dg"].Value) == true
                      select row).ToList();


            if (MessageBox.Show(string.Format("Voulez-vous ajouter une absence {0} dossiers?", select.Count), "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                    string insertCmd = "INSERT INTO presences (present,Date,idPolicier) VALUES (@f,@f1,@f2)";
                    SqlConnection dbConn;
                    dbConn = new SqlConnection(cn.DBConn());
                    dbConn.Open();
                    //Authentification lg = new Authentification();

                    //GetValue value = new GetValue();

                    SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);
                   if(metroCheckBox1.Checked)
                    myCommand.Parameters.AddWithValue("@f", "1");
                   if(metroCheckBox2.Checked)
                       myCommand.Parameters.AddWithValue("@f", "0");
                    myCommand.Parameters.AddWithValue("@f1", dateTimePicker4.Value);
                    myCommand.Parameters.AddWithValue("@f2", num1);
                  
                    myCommand.ExecuteNonQuery();




                }
                MessageBox.Show("Ajouté avec succès");
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           affichage2();
        }
        private void affichage2()
        {
           dataGridView2.Visible = true;
            dataGridView2.Rows.Clear();
            List<View_presence> lstusr;
          // List<View_congé> lstusr1;
            DBpoliceEntities dbpfen = new DBpoliceEntities();
            object mat = dataGridView1.Rows[0].Cells[0].Value;
            int mat2 = Convert.ToInt32(mat);
           // object typ = dataGridView1.Rows[0].Cells[2].Value;
           // string typ2 = Convert.ToString(typ);
           // lstusr = dbpfen.View_presence.Where(x => x.idPolicier == mat2).ToList();
          //  lstusr1 = dbpfen.View_congé.Where(x => x.Type_direction == typ2).ToList();
 
                    //string nom = lstusr[i].Nom_policier.ToString();0
              

            
                    var priv = (from emp in dbpfen.View_presence
                               where emp.idPolicier==mat2
                                select emp.present).Count();

                    var priv1 = (from emp in dbpfen.View_presence
                                 where emp.present==1 && emp.idPolicier==mat2
                                select emp.present).Count();

                    var priv2 = (from emp in dbpfen.View_presence
                                 where emp.present == 0 && emp.idPolicier==mat2
                                 select emp.present).Count();

                    var priv3 = (from emp in dbpfen.View_presence
                              where emp.idPolicier==mat2
                                 select emp.Date.Value.Month).FirstOrDefault();
                    int n = Convert.ToInt32(priv3);
                    string tot = priv.ToString();
                    string pres = priv1.ToString();
                    string abs = priv2.ToString();
                   string d = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(n);
                    string[] row1 = new string[] {
                     
                    d,
                      tot,
                      pres,
                      abs
     
                          
                        };

                    dataGridView2.Rows.Add(row1);
                    dataGridView2.Visible = true;
                }

            }
          




        
    }

