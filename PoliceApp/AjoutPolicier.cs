using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

using WIA;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;


namespace PoliceApp
{
    public partial class AjoutPolicier : MetroFramework.Forms.MetroForm
    {
        public AjoutPolicier()
        {
            InitializeComponent();
        }
        DBpoliceEntities dbpfen = new DBpoliceEntities();
        private void button9_Click(object sender, EventArgs e)
        {
          
            //button28.Visible = false;
            groupBox1.Enabled = true;
            groupBox4.Enabled = true;
            panel4.Enabled = false;
            button5.Visible = true;
        

            TabPage t = tabControl1.TabPages[1];
            tabControl1.SelectedTab = t;

            this.rbMale.Checked = false;
            this.rbFemale.Checked = false;
         

            //   this.comboBox5.SelectedIndex = -1;
            // this.comboBox6.SelectedIndex = -1;
            this.comboBox9.SelectedIndex = -1;
            this.comboBox8.SelectedIndex = -1;
            this.comboBox11.SelectedIndex = -1;
            this.combetude.SelectedIndex = -1;
            this.comboBox12.SelectedIndex = -1;
          

 
            this.comboBox2.SelectedIndex = -1;


            this.textBox14.Text = "";
            this.textBox8.Text = "";
        
            this.textBox35.Text = "";
            //    this.textBox6.Text = "";
            //   this.textBox7.Text = "";
            this.textBox1.Text = "";
            this.txtPatientID.Text = "";
            this.textBox9.Text = "";
            this.txtPatientName.Text = "";
            this.textBox5.Text = "";
  

        }

        private void button8_Click(object sender, EventArgs e)
        {
                  pictureBox2.Image = null;
      
        }
  
        
        private void button1_Click(object sender, EventArgs e)
        {
      
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = (Bitmap)pictureBox1.Image.Clone();
        }
         
        private void AjoutPolicier_Load(object sender, EventArgs e)
        {
             




                comboBox2.ValueMember = "Idaresse";
                comboBox2.DisplayMember = "adresse";
                comboBox2.DataSource = dbpfen.adress.ToList<adress>();
                comboBox2.SelectedIndex = -1;

                comboBox8.ValueMember = "Grade_ID";
                comboBox8.DisplayMember = "Libelle";
                comboBox8.DataSource = dbpfen.Grad.ToList<Grad>();

                comboBox12.ValueMember = "Statut_ID";
                comboBox12.DisplayMember = "Libelle";
                comboBox12.DataSource = dbpfen.Statut.ToList<Statut>();
                comboBox12.SelectedIndex = -1;

                metroComboBox1.ValueMember = "id";
                metroComboBox1.DisplayMember = "libelle";
                metroComboBox1.DataSource = dbpfen.lien_parenté.ToList<lien_parenté>();
                metroComboBox1.SelectedIndex = -1;

                comboBox11.ValueMember = "id";
                comboBox11.DisplayMember = "libelle";
                comboBox11.DataSource = dbpfen.fonction.ToList<fonction>();

                comboBox9.ValueMember = "Direction_ID";
                comboBox9.DisplayMember = "Type_direction";
                comboBox9.DataSource = dbpfen.Direction.ToList<Direction>();

                combetude.ValueMember = "Niveau_ID";
                combetude.DisplayMember = "libelle";
                combetude.DataSource = dbpfen.etude.ToList<etude>();
               
            }
        private void TriggerScan()
        {
            Console.WriteLine("Image scannée aver succès");
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
     

        }

        private void button14_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtPatientName.Text == "")
            {
                MessageBox.Show("Veuillez saisir le nom du Policier", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPatientName.Focus();
                return;
            }
            if (textBox5.Text == "")
            {
                MessageBox.Show("Veuillez saisir le nom du pére du Policier", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox5.Focus();
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Veuillez saisir le nom de la mére du Policier", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            if (txtPatientID.Text == "")
            {
                MessageBox.Show("Veuillez saisir le matricule du Policier", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPatientID.Focus();
                return;
            }



            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez selectionner une adresse", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox2.Focus();
                return;
            }

            if (comboBox12.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez selectionner un status", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox12.Focus();
                return;
            }




            if (comboBox8.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez selectionner un grade", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox8.Focus();
                return;
            }

            if (comboBox9.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez selectionner une direction", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox9.Focus();
                return;
            }

            if (combetude.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez selectionner un niveau d'etude", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                combetude.Focus();
                return;
            }

            if (comboBox11.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez selectionner une fonction", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox11.Focus();
                return;
            }

            /*if (pictureBox2.Image == null)
            {
                MessageBox.Show("Veuillez inserer une photo de profile", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pictureBox2.Focus();
                return;

            }*/
            else
            {  ConnectionString cn = new ConnectionString();
                string cmd = "select count(*) from policier where Matricule_ID='" + txtPatientID.Text + "'  and Nom_policier='" + txtPatientName.Text + "'";
                // string insertCmd = "SET IDENTITY_INSERT Policier ON;insert into Policier([Matricule_ID],[Nom_policier],[Nom_pere],[Nom_mere],[Date_naissance],[LieuNaissance],[Adresse_ID],Taille,Poids,statu,[DateDebut_service],[Numero_CNI],[DateDelivrance_CNI],[Numero_CP],[DateDelivrance_CP],genre,idGrad,numdec,datedec,photo,idfonction,iddirect,idetude,telephone) values (@f1,@f2,@f3,@f4,@f5,@f6,@f7,@f8,@f9,@f10,@f11,@f12,@f13,@f14,@f15,@f16,@f17,@f18,@f19,@photo,@f20,@f21,@f22,@f23)";
                SqlConnection dbConn;
                dbConn = new SqlConnection(cn.DBConn());
                dbConn.Open();
                    try
                    {

                        string insertCmd = "insert into Policier([Matricule_ID],[Nom_policier],[Nom_pere],[Nom_mere],[Date_naissance],[LieuN],[Adresse_ID],statu,[Numero_CNI],[DateDelivrance_CNI],[Numero_CP],[DateDelivrance_CP],genre,idGrad,numdec,datedec,idfonction,idetude,telephone,iddirect,daterecru,photo,nbrenfant,nbrepouse,commentaire) values (@f1,@f2,@f3,@f4,@f5,@f6,@f7,@f10,@f12,@f13,@f14,@f15,@f16,@f17,@f18,@f19,@f20,@f22,@f23,@f54,@f55,@photo,@f61,@f62,@f63)";
                        SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);
                        SqlCommand cmmd = new SqlCommand(cmd, dbConn);
                        int count = Convert.ToInt32(cmmd.ExecuteScalar());
                        if (count != 0)
                        {
                            MessageBox.Show("L'agent policier existe déjà.", "Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {

                            myCommand.Parameters.AddWithValue("@f1", txtPatientID.Text);
                            myCommand.Parameters.AddWithValue("@f2", txtPatientName.Text);
                            myCommand.Parameters.AddWithValue("@f3", textBox5.Text);
                            myCommand.Parameters.AddWithValue("@f4", textBox1.Text);
                            myCommand.Parameters.AddWithValue("@f5", dtpDOB.Value);
                            myCommand.Parameters.AddWithValue("@f6", textBox33.Text);
                            myCommand.Parameters.AddWithValue("@f7", comboBox2.SelectedValue);
                            //   myCommand.Parameters.AddWithValue("@f8", textBox6.Text);
                            //  myCommand.Parameters.AddWithValue("@f9", textBox7.Text);
                            myCommand.Parameters.AddWithValue("@f10", comboBox12.SelectedValue);

                            myCommand.Parameters.AddWithValue("@f12", textBox9.Text);
                            myCommand.Parameters.AddWithValue("@f13", dateTimePicker1.Value);
                            myCommand.Parameters.AddWithValue("@f14", textBox8.Text.ToUpper());
                            myCommand.Parameters.AddWithValue("@f15", dateTimePicker2.Value);

                            if (rbMale.Checked)
                            {
                                myCommand.Parameters.AddWithValue("@f16", "Homme");
                            }
                            if (rbFemale.Checked)
                            {
                                myCommand.Parameters.AddWithValue("@f16", "Femme");
                            }


                            myCommand.Parameters.AddWithValue("@f17", comboBox8.SelectedValue);
                            myCommand.Parameters.AddWithValue("@f18", textBox14.Text);
                            myCommand.Parameters.AddWithValue("@f19", dateTimePicker4.Value);
                            myCommand.Parameters.AddWithValue("@f20", comboBox11.SelectedValue);
                            
                            myCommand.Parameters.AddWithValue("@f22", combetude.SelectedValue);
                            myCommand.Parameters.AddWithValue("@f23", textBox35.Text);


                            MemoryStream stream = new MemoryStream();
                            if (pictureBox2.Image != null)
                            {
                                pictureBox2.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                            }
                            byte[] imageBt1 = stream.ToArray();
                            myCommand.Parameters.Add("@photo", imageBt1);
                            myCommand.Parameters.AddWithValue("@f61", textBox32.Text);
                            myCommand.Parameters.AddWithValue("@f62", textBox36.Text);

                        // myCommand.Parameters.AddWithValue("@f52", comboBox5.SelectedValue);
                        //   myCommand.Parameters.AddWithValue("@f53", comboBox6.SelectedValue);
                        myCommand.Parameters.AddWithValue("@f54", comboBox9.SelectedValue);
                            myCommand.Parameters.AddWithValue("@f55", dateTimePicker33.Value);
                        myCommand.Parameters.AddWithValue("@f63", textBox37.Text);

                        myCommand.ExecuteNonQuery();

                        gestionEnfant(dbConn);
                        gestionEpouses(dbConn);
                        MessageBox.Show("Ajouté avec succès");
                            TabPage t = tabControl1.TabPages[0];
                            tabControl1.SelectedTab = t;

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }

        private void gestionEpouses(SqlConnection dbConn)
        {
            string insertCmd = "insert into epouses([idPolicier],[Nom_epouse],[Date_mariage],[DateN]) values (@f1,@f2,@f4,@f5)";
            SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);
            //Epouse 1
            if (textBox29.Text != "")
            {
                myCommand.Parameters.Clear();
                myCommand.Parameters.AddWithValue("@f1", txtPatientID.Text);
                myCommand.Parameters.AddWithValue("@f2", textBox29.Text);
                myCommand.Parameters.AddWithValue("@f4", dateTimePicker12.Value);
                myCommand.Parameters.AddWithValue("@f5", dateTimePicker11.Value);
                myCommand.ExecuteNonQuery();
            }
            //Epouse 2
            if (textBox28.Text != "")
            {
                myCommand.Parameters.Clear();
                myCommand.Parameters.AddWithValue("@f1", txtPatientID.Text);
                myCommand.Parameters.AddWithValue("@f2", textBox28.Text);
                myCommand.Parameters.AddWithValue("@f4", dateTimePicker13.Value);
                myCommand.Parameters.AddWithValue("@f5", dateTimePicker14.Value);
                myCommand.ExecuteNonQuery();
            }
            //Epouse 3
            if (textBox30.Text != "")
            {
                myCommand.Parameters.Clear();
                myCommand.Parameters.AddWithValue("@f1", txtPatientID.Text);
                myCommand.Parameters.AddWithValue("@f2", textBox30.Text);
                myCommand.Parameters.AddWithValue("@f4", dateTimePicker15.Value);
                myCommand.Parameters.AddWithValue("@f5", dateTimePicker16.Value);
                myCommand.ExecuteNonQuery();
            }
            //Epouse 4
            if (textBox31.Text != "")
            {
                myCommand.Parameters.Clear();
                myCommand.Parameters.AddWithValue("@f1", txtPatientID.Text);
                myCommand.Parameters.AddWithValue("@f2", textBox31.Text);
                myCommand.Parameters.AddWithValue("@f4", dateTimePicker17.Value);
                myCommand.Parameters.AddWithValue("@f5", dateTimePicker18.Value);
                myCommand.ExecuteNonQuery();
            }
        }

        private void gestionEnfant(SqlConnection dbConn)
        {
            string insertCmd = "insert into enfants([Matricule_ID],[Nom_enfant],[lieu],[Nom_mere],[Date_naissance]) values (@f1,@f2,@f3,@f4,@f5)";
            SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);
            //Enfant 1
            if(textBox2.Text != "")
            {
                myCommand.Parameters.AddWithValue("@f1", txtPatientID.Text);
                myCommand.Parameters.AddWithValue("@f2", textBox2.Text);
                myCommand.Parameters.AddWithValue("@f3", textBox10.Text);
                myCommand.Parameters.AddWithValue("@f4", textBox4.Text);
                myCommand.Parameters.AddWithValue("@f5", dateTimePicker5.Value);
                myCommand.ExecuteNonQuery();
            }
            //Enfant 2
            if (textBox11.Text != "")
            {
                myCommand.Parameters.Clear();
                myCommand.Parameters.AddWithValue("@f1", txtPatientID.Text);
                myCommand.Parameters.AddWithValue("@f2", textBox11.Text);
                myCommand.Parameters.AddWithValue("@f3", textBox6.Text);
                myCommand.Parameters.AddWithValue("@f4", textBox7.Text);
                myCommand.Parameters.AddWithValue("@f5", dateTimePicker3.Value);
                myCommand.ExecuteNonQuery();
            }
            //Enfant 3
            if (textBox15.Text != "")
            {
                myCommand.Parameters.Clear();
                myCommand.Parameters.AddWithValue("@f1", txtPatientID.Text);
                myCommand.Parameters.AddWithValue("@f2", textBox15.Text);
                myCommand.Parameters.AddWithValue("@f3", textBox12.Text);
                myCommand.Parameters.AddWithValue("@f4", textBox13.Text);
                myCommand.Parameters.AddWithValue("@f5", dateTimePicker6.Value);
                myCommand.ExecuteNonQuery();
            }
            //Enfant 4
            if (textBox18.Text != "")
            {
                myCommand.Parameters.Clear();
                myCommand.Parameters.AddWithValue("@f1", txtPatientID.Text);
                myCommand.Parameters.AddWithValue("@f2", textBox18.Text);
                myCommand.Parameters.AddWithValue("@f3", textBox16.Text);
                myCommand.Parameters.AddWithValue("@f4", textBox17.Text);
                myCommand.Parameters.AddWithValue("@f5", dateTimePicker7.Value);
                myCommand.ExecuteNonQuery();
            }
            //Enfant 5
            if (textBox21.Text != "")
            {
                myCommand.Parameters.Clear();
                myCommand.Parameters.AddWithValue("@f1", txtPatientID.Text);
                myCommand.Parameters.AddWithValue("@f2", textBox21.Text);
                myCommand.Parameters.AddWithValue("@f3", textBox19.Text);
                myCommand.Parameters.AddWithValue("@f4", textBox20.Text);
                myCommand.Parameters.AddWithValue("@f5", dateTimePicker8.Value);
                myCommand.ExecuteNonQuery();
            }
            //Enfant 6
            if (textBox24.Text != "")
            {
                myCommand.Parameters.Clear();
                myCommand.Parameters.AddWithValue("@f1", txtPatientID.Text);
                myCommand.Parameters.AddWithValue("@f2", textBox24.Text);
                myCommand.Parameters.AddWithValue("@f3", textBox22.Text);
                myCommand.Parameters.AddWithValue("@f4", textBox23.Text);
                myCommand.Parameters.AddWithValue("@f5", dateTimePicker9.Value);
                myCommand.ExecuteNonQuery();
            }
            //Enfant 7
            if (textBox27.Text != "")
            {
                myCommand.Parameters.Clear();
                myCommand.Parameters.AddWithValue("@f1", txtPatientID.Text);
                myCommand.Parameters.AddWithValue("@f2", textBox27.Text);
                myCommand.Parameters.AddWithValue("@f3", textBox25.Text);
                myCommand.Parameters.AddWithValue("@f4", textBox26.Text);
                myCommand.Parameters.AddWithValue("@f5", dateTimePicker10.Value);
                myCommand.ExecuteNonQuery();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
         
       

        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox12.SelectedIndex == 1)
            {
                button10.Visible = true;
                tabControlEnfantEpouse.Visible = true;
                label63.Visible = true;
                label64.Visible = true;
                textBox36.Visible = true;
                textBox32.Visible = true;
            }
            else
            {
                tabControlEnfantEpouse.Visible = false;
                label63.Visible = false;
                label64.Visible = false;
                textBox36.Visible = false;
                textBox32.Visible = false;
            }
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            metroComboBox1.Visible = true;
        }

        /*private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (metroComboBox1.SelectedIndex == 0)
            {
                tabControlEnfantEpouse.Visible = true;

                label10.Visible = true;
                textBox2.Visible = true;
              label13.Visible = true;
               dateTimePicker3.Visible = true;
               label14.Visible = true;
              dateTimePicker5.Visible = true;
               label17.Visible = true;
               textBox4.Visible = true;
             //   button11.Visible = true;
                label34.Visible = false;
                textBox10.Visible = false;
            }
           else if (metroComboBox1.SelectedIndex == 1)
           {
               label10.Visible = true;
               textBox2.Visible = true;
               label13.Visible = true;
               dateTimePicker3.Visible = true;
               label14.Visible = true;
               dateTimePicker5.Visible = false;
               label17.Visible = false;
               textBox4.Visible = true;
              // button11.Visible = true;
               label34.Visible = true;
               textBox10.Visible = true;
           }
           else
           {
               label10.Visible = false;
               textBox2.Visible = false;
               label13.Visible = false;
               dateTimePicker3.Visible =false;
               label14.Visible = false;
               dateTimePicker5.Visible = false;
               label17.Visible = false;
               textBox4.Visible = false;
              // button11.Visible = false;
            

           }

        }*/

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker11_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {

        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {

        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void label63_Click(object sender, EventArgs e)
        {

        }

        private void label65_Click(object sender, EventArgs e)
        {

        }

        private void textBox37_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

