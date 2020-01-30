using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoliceApp
{
    public partial class family : MetroFramework.Forms.MetroForm
    {
        public family()
        {
            InitializeComponent();
        }
        DBpoliceEntities dbpfen = new DBpoliceEntities();
        private void family_Load(object sender, EventArgs e)
        {
            metroComboBox1.ValueMember = "id";
            metroComboBox1.DisplayMember = "libelle";
            metroComboBox1.DataSource = dbpfen.lien_parenté.ToList<lien_parenté>();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (metroComboBox1.SelectedIndex == 0)
            {
                dataGridView1.Visible = true;
            this.dataGridView1.Columns["Column2"].HeaderText= "Date de mariage";
                if (textBox7.Text != string.Empty)
                {
                    List<Epouses> lstusr = null;
                    DBpoliceEntities dbpfen = new DBpoliceEntities();
                    dataGridView1.Rows.Clear();
                    int var = Convert.ToInt32(textBox7.Text.ToString());
                    lstusr = dbpfen.Epouses.Where(x => x.idPolicier == var).ToList();



                    if (lstusr.Count() != 0)
                    {
                        for (int i = 0; i < lstusr.Count(); i++)
                        {


                            string nom = lstusr[i].Nom_epouse.ToString();
                            DateTime date = Convert.ToDateTime(lstusr[i].DateN.Value.Date);

                            string id = Convert.ToString(date.ToShortDateString());

                            string typ = lstusr[i].Lieu.ToString();
                            DateTime date1 = Convert.ToDateTime(lstusr[i].Date_mariage.Value.Date);
                            string dateM = Convert.ToString(date1.ToShortDateString());
                            string[] row1 = new string[] {
                        nom,
                        id,
                           typ,
                           dateM
                   
                           
                         
                        };

                            dataGridView1.Rows.Add(row1);
                            dataGridView1.Visible = true;
                        }


                    }
                }
            }
            else 
            {
                this.dataGridView1.Columns["Column2"].HeaderText = "Nom mère";

                if (textBox7.Text != string.Empty)
                {
                    List<View_enfant> lstusr = null;
                    DBpoliceEntities dbpfen = new DBpoliceEntities();
                    dataGridView1.Rows.Clear();
                    int var = Convert.ToInt32(textBox7.Text.ToString());
                    lstusr = dbpfen.View_enfant.Where(x => x.Matricule_ID == var).ToList();



                    if (lstusr.Count() != 0)
                    {
                        for (int i = 0; i < lstusr.Count(); i++)
                        {


                            string nom = lstusr[i].Nom_enfant.ToString();
                            DateTime date = Convert.ToDateTime(lstusr[i].Date_naissance.Value.Date);

                            string id = Convert.ToString(date.ToShortDateString());

                            string typ = lstusr[i].lieu.ToString();
                         //   string n = lstusr[i].nomM.ToString();
                          
                            string[] row1 = new string[] {
                        nom,
                        id,
                           typ,
                   
                   
                           
                         
                        };

                            dataGridView1.Rows.Add(row1);
                            dataGridView1.Visible = true;
                        }


                    }
                }

            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text != string.Empty)
            {
                int n = Convert.ToInt32(textBox7.Text);

                var priv = (from emp in dbpfen.Policier
                            where emp.Matricule_ID == n
                            select emp.Nom_policier);
                textBox3.Text = priv.SingleOrDefault();
            }
        }
    }
}
