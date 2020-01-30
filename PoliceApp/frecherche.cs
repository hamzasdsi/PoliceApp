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
    public partial class frecherche : Form
    {
        public frecherche()
        {
            InitializeComponent();
            ConnectionString cs = new ConnectionString();
            CommonClasses cc = new CommonClasses();
            clsFunc cf = new clsFunc();
            string st1;
            string st2;
            string gender;
        }
        
        
        ConnectionString cn = new ConnectionString();
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
         

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox7.SelectedIndex == 0)
            {
               label4.Text = "Etude:";
               etude();
            }

            if (comboBox7.SelectedIndex == 1)
            {
                label4.Text = "Détachement:";
                detachement();
            }

            if (comboBox7.SelectedIndex == 2)
            {
                label4.Text = "Service:";
                service();
            }

            if (comboBox7.SelectedIndex == 3)
            {
                label4.Text = "Direction:";
                direction();
            }
            if (comboBox7.SelectedIndex == 4)
            {
               label4.Text = "Grade:";
               grade();
           } 
            if (comboBox7.SelectedIndex == 5)
            {
                label4.Text = "Fonction:";
               fonction();
           }
           // if (comboBox7.SelectedIndex == 6)
            //{
              //  label14.Text = "Age:";
                //comboBox4.Items.Add("18");
               // comboBox4.Items.Add("19");
              
            //}
        }

        public void etude()
        {
            SqlConnection dbConn;
            SqlDataAdapter da;
            dbConn = new SqlConnection(cn.DBConn());
            dbConn.Open();
            da = new SqlDataAdapter("select libelle from etude", dbConn);
            DataTable ds = new DataTable();
            comboBox4.DataSource = ds;
            da.Fill(ds);
            comboBox4.DisplayMember = "libelle";
            comboBox4.ValueMember = "libelle";
            dbConn.Close();
       }
        public void detachement()
        {
            SqlConnection dbConn;
            SqlDataAdapter da;
            dbConn = new SqlConnection(cn.DBConn());
            dbConn.Open();
            da = new SqlDataAdapter("select Libelle from detach_agence", dbConn);
            DataTable ds0 = new DataTable();
            comboBox4.DataSource = ds0;
            da.Fill(ds0);
            comboBox4.DisplayMember = "Libelle";
            comboBox4.ValueMember = "Libelle";
            dbConn.Close();

          

        }
        public void grade()
        {
            SqlConnection dbConn;
            SqlDataAdapter da;
            dbConn = new SqlConnection(cn.DBConn());
            dbConn.Open();
            da = new SqlDataAdapter("select Libelle from Grad", dbConn);
            DataTable ds1 = new DataTable();
            comboBox4.DataSource = ds1;
            da.Fill(ds1);
            comboBox4.DisplayMember = "Libelle";
            comboBox4.ValueMember = "Libelle";
            dbConn.Close();

        }

        public void fonction()
        {
            SqlConnection dbConn;
            SqlDataAdapter da;
            dbConn = new SqlConnection(cn.DBConn());
            dbConn.Open();
            da = new SqlDataAdapter("select libelle from fonction", dbConn);
            DataTable ds2 = new DataTable();
            comboBox4.DataSource = ds2;
            da.Fill(ds2);
            comboBox4.DisplayMember = "libelle";
            comboBox4.ValueMember = "libelle";
            dbConn.Close();

        }

        public void service()
        {
            SqlConnection dbConn;
            SqlDataAdapter da;
            dbConn = new SqlConnection(cn.DBConn());
            dbConn.Open();
            da = new SqlDataAdapter("select libelle from service", dbConn);
            DataTable ds3 = new DataTable();
            comboBox4.DataSource = ds3;
            da.Fill(ds3);
            comboBox4.DisplayMember = "libelle";
            comboBox4.ValueMember = "libelle";
            dbConn.Close();

        }

        public void direction()
        {
            SqlConnection dbConn;
            SqlDataAdapter da;
            dbConn = new SqlConnection(cn.DBConn());
            dbConn.Open();
            da = new SqlDataAdapter("select Type_direction from Direction", dbConn);
            DataTable ds4 = new DataTable();
            comboBox4.DataSource = ds4;
            da.Fill(ds4);
            comboBox4.DisplayMember = "Type_direction";
            comboBox4.ValueMember = "Type_direction";
            dbConn.Close();

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e){}

        private void button1_Click(object sender, EventArgs e)
        {
            List<polic> lstusr3 = null;
            List<polic> lstusr4 = null;

            DBpoliceEntities dbpfen = new DBpoliceEntities();




            if (comboBox4.SelectedValue != "")
            {
                dgw.Rows.Clear();

                DateTime v = dateTimePicker1.Value;
               // MessageBox.Show(v.ToString());

                DateTime v1 = dateTimePicker2.Value;
               // MessageBox.Show(v1.ToString());

                lstusr3 = dbpfen.polic.Where(x => (x.Expr1 == comboBox4.SelectedValue && ((x.Date_naissance >= v) && (x.Date_naissance <= v1))) || (x.Libelle == comboBox4.SelectedValue && ((x.Date_naissance >= v) && (x.Date_naissance <= v1))) || (x.Expr4 == comboBox4.SelectedValue && ((x.Date_naissance >= v) && (x.Date_naissance <= v1))) || (x.Expr3 == comboBox4.SelectedValue && ((x.Date_naissance >= v) && (x.Date_naissance <= v1))) || (x.Expr2 == comboBox4.SelectedValue && ((x.Date_naissance >= v) && (x.Date_naissance <= v1))) || (x.Type_direction == comboBox4.SelectedValue && ((x.Date_naissance >= v) && (x.Date_naissance <= v1)))).ToList();
                lstusr4 = lstusr3.Distinct().ToList();

                if (lstusr4.Count() != 0)
                {
                    for (int i = 0; i < lstusr4.Count(); i++)
                    {
                        DateTime d = Convert.ToDateTime(lstusr4[i].Date_naissance.Value.Date);
                        int a = d.Year;
                        int da = DateTime.Now.Year;
                        int age = da - a;
                        // MessageBox.Show(da.ToString());
                        string Matricule_ID = lstusr4[i].Matricule_ID.ToString();
                        string Nom_policier = lstusr4[i].Nom_policier.ToString();
                        DateTime date = Convert.ToDateTime(lstusr4[i].Date_naissance.Value.Date);
                        String Date_naissance = Convert.ToString(date.ToShortDateString());
                        // string Date_naissance = Convert.ToString(age);
                        string Etude = lstusr4[i].Expr1.ToString();
                        string Grade = lstusr4[i].Expr3.ToString();
                        string Adresse = lstusr4[i].adresse.ToString();
                        string Service = lstusr4[i].Expr4.ToString();
                        string Detachement = lstusr4[i].Libelle.ToString();
                        string fonction = lstusr4[i].Expr2.ToString();
                        string direction = lstusr4[i].Type_direction.ToString();


                        string[] row1 = new string[] {
                                    Matricule_ID,
                                    Nom_policier,
                                    Date_naissance, 
                                    direction,
                                    Service,
                                    Detachement,
                                    fonction,
                                    Grade,
                                    Etude,
                                    Adresse,
                           };
                        dgw.Rows.Add(row1);
                        dgw.Visible = true;
                    }
                }
            }
        }

        private void gdvrecherche_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
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
    }
}
