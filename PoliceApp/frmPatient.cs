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

using System.Drawing.Imaging;

using WIA;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Generic;

namespace PoliceApp
{
    public partial class frmPatient : MetroFramework.Forms.MetroForm
    {
        ConnectionString cs = new ConnectionString();
        CommonClasses cc = new CommonClasses();
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        string gender;
        DataSet ds;
        SqlDataAdapter adapter;
       public frmPatient()
        {
            InitializeComponent();
       
        }
        ConnectionString cn = new ConnectionString();

        public void auto()
        {
            try
            {
                int Num = 0;
                cc.con = new SqlConnection(cs.DBConn());
                cc.con.Open();
                string sql = "SELECT MAX(P_ID+1) FROM Patient";
                cc.cmd = new SqlCommand(sql);
                cc.cmd.Connection = cc.con;
                if (Convert.IsDBNull(cc.cmd.ExecuteScalar()))
                {
                    Num = 1;

                    txtPatientID.Text = "P-" + Convert.ToString(Num);
                }
                else
                {
                    Num = (int)(cc.cmd.ExecuteScalar());

                    txtPatientID.Text = "P-" + Convert.ToString(Num);
                }
                cc.cmd.Dispose();
                cc.con.Close();
                cc.con.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void textBox11_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            if (!char.IsNumber(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }

        }

        private void textBox11_Validating(object sender, CancelEventArgs e){}


        DBpoliceEntities dbpfen = new DBpoliceEntities();

        private void frmPatient_Load(object sender, EventArgs e)
        {
            panel33.Hide();
      
            pictureBox4.Hide();

            //progressBar1.Width = this.Width;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = 1000;
            //progressBar1.Maximum = 12;
            timer1.Tick += new EventHandler(timer1_Tick);
            
            comboBox2.ValueMember = "Idaresse";
            comboBox2.DisplayMember = "adresse";
            comboBox2.DataSource = dbpfen.adress.ToList<adress>();

            comboBox8.ValueMember = "Grade_ID";
            comboBox8.DisplayMember = "Libele";
            comboBox8.DataSource = dbpfen.Grad.ToList<Grad>();

            comboBox12.ValueMember = "Statut_ID";
            comboBox12.DisplayMember = "Libelle";
            comboBox12.DataSource = dbpfen.Statut.ToList<Statut>();
            comboBox12.SelectedIndex = -1;

            comboBox11.ValueMember   = "id";
            comboBox11.DisplayMember = "libelle";
            comboBox11.DataSource = dbpfen.fonction.ToList<fonction>();

            comboBox9.ValueMember = "Direction_ID";
            comboBox9.DisplayMember = "Type_direction";
            comboBox9.DataSource = dbpfen.Direction.ToList<Direction>();


            comboBox8.ValueMember = "Grade_ID";
            comboBox8.DisplayMember = "Libelle";
            comboBox8.DataSource = dbpfen.Grad.ToList<Grad>();

         

            combetude.ValueMember = "Niveau_ID";
            combetude.DisplayMember = "libelle";
            combetude.DataSource = dbpfen.etude.ToList<etude>();

            //metroComboBox1.ValueMember = "id";
            //metroComboBox1.DisplayMember = "libelle";
            //metroComboBox1.DataSource = dbpfen.lien_parenté.ToList<lien_parenté>();

            int a;
            // string cnstr = "Data Source=DESKTOP-GITRNUG;Initial Catalog=DBpolice;User ID=sa;Password=sdsi*2017";
            ConnectionString con = new ConnectionString();
            SqlConnection dbConn;
            dbConn = new SqlConnection(con.DBConn());
            // SqlConnection con = new SqlConnection(cn);
            dbConn.Open();
            string query = "Select Max(Matricule_ID) from Policier";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    txtPatientID.Text = "1";
                }
                else
                {
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    txtPatientID.Text = a.ToString();
                }

            }
            // Set start output folder TMP
            textBox4.Text = Path.GetTempPath();
            // Set JPEG as default
           comboBox1.SelectedIndex = -1;
        }
        


   
        private void button1_Click(object sender, EventArgs e)
        {
         //   FinalFrame = new VideoCaptureDevice(CaptureDevice[comboBox10.SelectedIndex].MonikerString);// specified web cam and its filter moniker string
          
        }
        
        private void button2_Click(object sender, EventArgs e)
        {

        }
       
        

        private void btnSave_Click_2(object sender, EventArgs e)
        {
            try
            {

                if (txtPatientID.Text != "")
                {

                    string nompolicier = txtPatientName.Text;
                    string nompere = textBox5.Text;
                    string nommere = textBox1.Text;
                    string lieunaissance = textBox33.Text;
                    string adresseID = comboBox2.SelectedValue.ToString();

                    string statut = comboBox12.SelectedValue.ToString();
                    string numeroCNI = textBox9.Text;
                    string numeroCP = textBox8.Text;
                    string genre = null;

                    if (rbMale.Checked)
                    {
                        genre = "Homme";
                    }
                    if (rbFemale.Checked)
                    {
                        genre = "Femme";
                    }

                    string idGrad = comboBox8.SelectedValue.ToString();
                    string numdec = textBox14.Text;
                    string idfonction = comboBox11.SelectedValue.ToString();

                    string idetude = combetude.SelectedValue.ToString();
                    string iddirect = comboBox9.SelectedValue.ToString();

                    string telephone = textBox35.Text;
                    string serv = Convert.ToString(textBox34.Text);
                    MemoryStream stream1 = new MemoryStream();

                    byte[] imageBt1= stream1.ToArray(); 
                    if (pictureBox4.Image != null)
                    {
                        MemoryStream stream = new MemoryStream();
                        pictureBox4.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        imageBt1 = stream.ToArray();

                    }
                    SqlConnection dbConn;
                    dbConn = new SqlConnection(cn.DBConn());
                    dbConn.Open();
                    SqlCommand myCommand = new SqlCommand("update Policier set Date_naissance=@c1,DateDelivrance_CNI=@c3,DateDelivrance_CP=@c4,Nom_policier=@c5, Nom_pere=@c6, Nom_mere=@c7,LieuN=@c8,Adresse_ID=@c9,statu=@c12,Numero_CNI=@c13,Numero_CP=@c14,genre=@c15,idGrad=@c16,numdec=@c17,datedec=@c18,idfonction=@c19,Affect=@c20,idetude=@c21,telephone=@c22,iddirect=@c23,daterecru=@c24,nbrenfant=@c25,photo=@c26 where [Matricule_ID]='" + txtPatientID.Text + "'", dbConn);

                    myCommand.Parameters.AddWithValue("@c1", dtpDOB.Value);

                    myCommand.Parameters.AddWithValue("@C3", dateTimePicker1.Value);
                    myCommand.Parameters.AddWithValue("@C4", dateTimePicker2.Value);
                    myCommand.Parameters.AddWithValue("@c5", nompolicier);
                    myCommand.Parameters.AddWithValue("@C6", nompere);
                    myCommand.Parameters.AddWithValue("@C7", nommere);
                    myCommand.Parameters.AddWithValue("@C8", lieunaissance);
                    myCommand.Parameters.AddWithValue("@c9", adresseID);

                    myCommand.Parameters.AddWithValue("@C12", statut);
                    myCommand.Parameters.AddWithValue("@c13", numeroCNI);
                    myCommand.Parameters.AddWithValue("@C14", numeroCP);
                    myCommand.Parameters.AddWithValue("@C15", genre);
                    myCommand.Parameters.AddWithValue("@C16", idGrad);
                    myCommand.Parameters.AddWithValue("@C17", numdec);
                    myCommand.Parameters.AddWithValue("@C18", dateTimePicker4.Value);
                    myCommand.Parameters.AddWithValue("@c19", idfonction);
                    myCommand.Parameters.AddWithValue("@c20", serv);
                    myCommand.Parameters.AddWithValue("@C21", idetude);
                    myCommand.Parameters.AddWithValue("@C22", telephone);
                    myCommand.Parameters.AddWithValue("@C23", iddirect);
                    myCommand.Parameters.AddWithValue("@C24", dateTimePicker33.Value);
                    myCommand.Parameters.AddWithValue("@C25", textBox11.Text);
                    myCommand.Parameters.AddWithValue("@C26", imageBt1);
                    // myCommand.Parameters.Add("@photo", imageBt1);

                    myCommand.ExecuteNonQuery();
                    SqlCommandBuilder sql = new SqlCommandBuilder(adapter);
                    adapter.Update(ds);

                    //   int var2 = Convert.ToInt32(textBox11.Text);


                    /*   if (var2 == 1)
                       {



                           string nomepouse1 = textBox2.Text;
                           DateTime datemariage1 = dateTimePicker5.Value.Date;
                           string nbrenfantepouse1 = textBox10.Text;

                           var query = from emp in dbpfen.polic
                                       where emp.Expr5.ToString() == txtPatientID.Text
                                       select new { emp.Epouse_ID };

                           string k = query.First().Epouse_ID.ToString();
                           int k1 = Convert.ToInt32(k);


                           SqlCommand myCommand1 = new SqlCommand("update Epouses set Nom_epouse=@e1,Date_mariage=@e2,nbrenfant=@e3,Statut=@e4 where Epouse_ID='" + k1 + "'", dbConn);

                           myCommand1.Parameters.AddWithValue("@e1", textBox2.Text);
                           myCommand1.Parameters.AddWithValue("@e2", dateTimePicker5.Value);
                           myCommand1.Parameters.AddWithValue("@e3", textBox10.Text);
                           myCommand1.Parameters.AddWithValue("@e4", comboBox13.SelectedValue);
                           myCommand1.ExecuteNonQuery();


                       }
                       if (var2 == 2)
                       {


                           string nomepouse1 = textBox2.Text;
                           DateTime datemariage1 = dateTimePicker5.Value.Date;
                           string nbrenfantepouse1 = textBox10.Text;

                           string nomepouse2 = textBox16.Text;
                           DateTime datemariage2 = dateTimePicker6.Value.Date;
                           string nbrenfantepouse2 = textBox15.Text;

                           var query = from emp in dbpfen.polic
                                       where emp.Expr5.ToString() == txtPatientID.Text
                                       select new { emp.Epouse_ID };

                           string k = query.First().Epouse_ID.ToString();
                           int k1 = Convert.ToInt32(k);
                           int k2 = k1 + 1;

                           SqlCommand myCommand1 = new SqlCommand("update Epouses set Nom_epouse=@e1,Date_mariage=@e2,nbrenfant=@e3,Statut=@e4 where Epouse_ID='" + k1 + "'", dbConn);

                           myCommand1.Parameters.AddWithValue("@e1", textBox2.Text);
                           myCommand1.Parameters.AddWithValue("@e2", dateTimePicker5.Value);
                           myCommand1.Parameters.AddWithValue("@e3", textBox10.Text);
                           myCommand1.Parameters.AddWithValue("@e4", comboBox13.SelectedValue);

                           SqlCommand myCommand2 = new SqlCommand("update Epouses set Nom_epouse=@e4,Date_mariage=@e5,nbrenfant=@e6,Statut=@e7 where Epouse_ID='" + k2 + "'", dbConn);

                           myCommand2.Parameters.AddWithValue("@e4", textBox16.Text);
                           myCommand2.Parameters.AddWithValue("@e5", dateTimePicker6.Value);
                           myCommand2.Parameters.AddWithValue("@e6", textBox15.Text);
                           myCommand1.Parameters.AddWithValue("@e7", comboBox14.SelectedValue);


                           myCommand1.ExecuteNonQuery();
                           myCommand2.ExecuteNonQuery();




                       }
                       if (var2 == 3)
                       {


                           string nomepouse1 = textBox2.Text;
                           DateTime datemariage1 = dateTimePicker5.Value.Date;
                           string nbrenfantepouse1 = textBox10.Text;

                           string nomepouse2 = textBox16.Text;
                           DateTime datemariage2 = dateTimePicker6.Value.Date;
                           string nbrenfantepouse2 = textBox15.Text;

                           string nomepouse3 = textBox18.Text;
                           DateTime datemariage3 = dateTimePicker7.Value.Date;
                           string nbrenfantepouse3 = textBox17.Text;

                           var query = from emp in dbpfen.polic
                                       where emp.Expr5.ToString() == txtPatientID.Text
                                       select new { emp.Epouse_ID };

                           string k = query.First().Epouse_ID.ToString();
                           int k1 = Convert.ToInt32(k);
                           int k2 = k1 + 1;
                           int k3 = k2 + 1;

                           SqlCommand myCommand1 = new SqlCommand("update Epouses set Nom_epouse=@e1,Date_mariage=@e2,nbrenfant=@e3,Statut=@e4 where Epouse_ID='" + k1 + "'", dbConn);

                           myCommand1.Parameters.AddWithValue("@e1", textBox2.Text);
                           myCommand1.Parameters.AddWithValue("@e2", dateTimePicker5.Value);
                           myCommand1.Parameters.AddWithValue("@e3", textBox10.Text);
                           myCommand1.Parameters.AddWithValue("@e4", comboBox13.SelectedValue);

                           SqlCommand myCommand2 = new SqlCommand("update Epouses set Nom_epouse=@e4,Date_mariage=@e5,nbrenfant=@e6,Statut=@e7 where Epouse_ID='" + k2 + "'", dbConn);

                           myCommand2.Parameters.AddWithValue("@e4", textBox16.Text);
                           myCommand2.Parameters.AddWithValue("@e5", dateTimePicker6.Value);
                           myCommand2.Parameters.AddWithValue("@e6", textBox15.Text);
                           myCommand1.Parameters.AddWithValue("@e7", comboBox14.SelectedValue);

                           SqlCommand myCommand3 = new SqlCommand("update Epouses set Nom_epouse=@e7,Date_mariage=@e8,nbrenfant=@e9,Statut=@e10 where Epouse_ID='" + k3 + "'", dbConn);

                           myCommand3.Parameters.AddWithValue("@e7", textBox18.Text);
                           myCommand3.Parameters.AddWithValue("@e8", dateTimePicker7.Value);
                           myCommand3.Parameters.AddWithValue("@e9", textBox17.Text);
                           myCommand1.Parameters.AddWithValue("@e10", comboBox15.SelectedValue);

                           myCommand1.ExecuteNonQuery();
                           myCommand2.ExecuteNonQuery();
                           myCommand3.ExecuteNonQuery();





                       }
                       if (var2 == 4)
                       {


                           string nomepouse1 = textBox2.Text;
                           DateTime datemariage1 = dateTimePicker5.Value.Date;
                           string nbrenfantepouse1 = textBox10.Text;

                           string nomepouse2 = textBox16.Text;
                           DateTime datemariage2 = dateTimePicker6.Value.Date;
                           string nbrenfantepouse2 = textBox15.Text;

                           string nomepouse3 = textBox18.Text;
                           DateTime datemariage3 = dateTimePicker7.Value.Date;
                           string nbrenfantepouse3 = textBox17.Text;

                           string nomepouse4 = textBox20.Text;
                           DateTime datemariage4 = dateTimePicker8.Value.Date;
                           string nbrenfantepouse4 = textBox19.Text;

                           var query = from emp in dbpfen.polic
                                       where emp.Expr5.ToString() == txtPatientID.Text
                                       select new { emp.Epouse_ID };

                           string k = query.First().Epouse_ID.ToString();
                           int k1 = Convert.ToInt32(k);
                           int k2 = k1 + 1;
                           int k3 = k2 + 1;
                           int k4 = k3 + 1;

                           SqlCommand myCommand1 = new SqlCommand("update Epouses set Nom_epouse=@e1,Date_mariage=@e2,nbrenfant=@e3,Statut=@e4 where Epouse_ID='" + k1 + "'", dbConn);

                           myCommand1.Parameters.AddWithValue("@e1", textBox2.Text);
                           myCommand1.Parameters.AddWithValue("@e2", dateTimePicker5.Value);
                           myCommand1.Parameters.AddWithValue("@e3", textBox10.Text);
                           myCommand1.Parameters.AddWithValue("@e4", comboBox13.SelectedValue);

                           SqlCommand myCommand2 = new SqlCommand("update Epouses set Nom_epouse=@e4,Date_mariage=@e5,nbrenfant=@e6,Statut=@e7 where Epouse_ID='" + k2 + "'", dbConn);

                           myCommand2.Parameters.AddWithValue("@e4", textBox16.Text);
                           myCommand2.Parameters.AddWithValue("@e5", dateTimePicker6.Value);
                           myCommand2.Parameters.AddWithValue("@e6", textBox15.Text);
                           myCommand1.Parameters.AddWithValue("@e7", comboBox14.SelectedValue);

                           SqlCommand myCommand3 = new SqlCommand("update Epouses set Nom_epouse=@e7,Date_mariage=@e8,nbrenfant=@e9,Statut=@e10 where Epouse_ID='" + k3 + "'", dbConn);

                           myCommand3.Parameters.AddWithValue("@e7", textBox18.Text);
                           myCommand3.Parameters.AddWithValue("@e8", dateTimePicker7.Value);
                           myCommand3.Parameters.AddWithValue("@e9", textBox17.Text);
                           myCommand1.Parameters.AddWithValue("@e10", comboBox15.SelectedValue);

                           SqlCommand myCommand4 = new SqlCommand("update Epouses set Nom_epouse=@e10,Date_mariage=@e11,nbrenfant=@e12,Statut=@e13 where Epouse_ID='" + k4 + "'", dbConn);

                           myCommand4.Parameters.AddWithValue("@e10", textBox20.Text);
                           myCommand4.Parameters.AddWithValue("@e11", dateTimePicker8.Value);
                           myCommand4.Parameters.AddWithValue("@e12", textBox19.Text);
                           myCommand1.Parameters.AddWithValue("@e13", comboBox16.SelectedValue);

                           myCommand1.ExecuteNonQuery();
                           myCommand2.ExecuteNonQuery();
                           myCommand3.ExecuteNonQuery();
                           myCommand4.ExecuteNonQuery();





                       }*/

                    MessageBox.Show("Modifier avec succés");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBox4.Text = folderDlg.SelectedPath;
            }
        }

        private void btnNew_Click_2(object sender, EventArgs e)
        {
         


        }
        private void button5_Click(object sender, EventArgs e)
        {
            //progressBar1.Increment(1);
            //progressBar1.Value = 2;
            TabPage t = tabControl1.TabPages[2];
            tabControl1.SelectedTab = t;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TabPage t = tabControl1.TabPages[3];
            tabControl1.SelectedTab = t;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TabPage t = tabControl1.TabPages[1];
            tabControl1.SelectedTab = t;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TabPage t = tabControl1.TabPages[2];
            tabControl1.SelectedTab = t;
        }
        void ClearTextBoxes(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                TextBox textBox = child as TextBox;
                if (textBox == null)
                    ClearTextBoxes(child);
                else
                    textBox.Text = string.Empty;
            }
        }
        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void dgw_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        
       
            //button28.Visible = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox4.Enabled = false;
            panel4.Enabled = false;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
           // button5.Visible = false;

            List<polic> lstusr = null;
            DBpoliceEntities dbpfen = new DBpoliceEntities();

            try
            {
                int selectedrowindex = dgw.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgw.Rows[selectedrowindex];

                int var = Convert.ToInt32(selectedRow.Cells["Column1"].Value);         

               
           
                lstusr = dbpfen.polic.Where(x => x.Matricule_ID == var).ToList();
                if (lstusr != null)
                {
                    for (int i = 0; i < lstusr.Count(); i++)
                    {
                        label87.Visible = true;
                        label88.Visible = true;
                        txtPatientID.Text = lstusr[i].Matricule_ID.ToString();
                        txtPatientName.Text = lstusr[i].Nom_policier.ToString();
                        label87.Text = lstusr[i].Nom_policier.ToString();
                        DateTime date = Convert.ToDateTime(lstusr[i].Date_naissance.Value.Date);
                        dtpDOB.Value = date;
                        textBox33.Text = lstusr[i].LieuN.ToString();
                        if (lstusr[i].Adresse_ID != null)
                            comboBox2.SelectedValue = lstusr[i].Adresse_ID.Value;
                        else

                            comboBox2.SelectedIndex = -1;
                      
                  
                        if (lstusr[i].Numero_CNI != null)

                            textBox9.Text = lstusr[i].Numero_CNI.ToString();
                       
                        if (lstusr[i].Nom_mere != null)
                            textBox1.Text = lstusr[i].Nom_mere.ToString();
                  
                        if (lstusr[i].Nom_pere != null)
                            textBox5.Text = lstusr[i].Nom_pere.ToString();
                       
                        if (lstusr[i].Affect != null)
                            textBox34.Text = lstusr[i].Affect.ToString();
                  
                    
                        if (lstusr[i].Numero_CP != null)
                            textBox8.Text = lstusr[i].Numero_CP.ToString();
                   
                        if (lstusr[i].DateDelivrance_CNI != null)
                        {
                            DateTime dat = Convert.ToDateTime(lstusr[i].DateDelivrance_CNI.Value.Date);
                            dateTimePicker1.Value = dat;
                        }

                        if (lstusr[i].numdec != null)
                            textBox14.Text = lstusr[i].numdec.ToString();
                        if (lstusr[i].datedec != null)
                        {
                            DateTime d = Convert.ToDateTime(lstusr[i].datedec.Value.Date);
                            dateTimePicker4.Value = d;
                        }

                        if (lstusr[i].idfonction != null)
                            comboBox11.SelectedValue = lstusr[i].idfonction.Value;
                        else comboBox11.SelectedIndex = -1;
                        if (lstusr[i].numdec != null)
                            textBox14.Text = lstusr[i].numdec.ToString();
                        if (lstusr[i].idGrad != null)
                            comboBox8.SelectedValue = lstusr[i].idGrad.Value;
                        else
                            comboBox8.SelectedIndex = -1;
                        if (lstusr[i].statu != null)
                            comboBox12.SelectedValue = lstusr[i].statu.Value;
                        else
                            comboBox12.SelectedIndex = -1;
                        // comboBox13.SelectedValue = lstusr.decede.Value;
                        if (lstusr[i].DateDelivrance_CP != null)
                        {
                            DateTime d1 = Convert.ToDateTime(lstusr[i].DateDelivrance_CP.Value.Date);
                            dateTimePicker2.Value = d1;
                        }
                        if (lstusr[i].idetude != null)
                        {
                            combetude.SelectedValue = lstusr[i].idetude.Value;
                        }
                        else
                            combetude.SelectedIndex = -1;



                        if (lstusr[i].telephone != null)
                            textBox35.Text = lstusr[i].telephone.ToString();

                        if (lstusr[i].nbrenfant!= null)
                            textBox11.Text = lstusr[i].nbrenfant.ToString();
                        // comboBox4.SelectedValue = lstusr.idsousdirect.Value;
                     
                        
                        if (lstusr[i].iddirect != null)
                            comboBox9.SelectedValue = lstusr[i].iddirect.Value;
                        else
                            comboBox9.SelectedIndex = -1;
                        if (lstusr[i].daterecru != null)
                        {
                            DateTime daterec = Convert.ToDateTime(lstusr[i].daterecru.Value.Date);
                            dateTimePicker33.Value = daterec;
                        }
                        pictureBox4.Show();
                        // Get Image as
                        if (lstusr[i].photo != null && lstusr[i].photo.Length>0)
                        {
                            byte[] pic = (byte[])lstusr[i].photo; // Change Index According to Your Select Query
                            MemoryStream ms = new MemoryStream(pic);
                            System.Drawing.Image myImage = System.Drawing.Image.FromStream(ms);
                            pictureBox4.Image = myImage;
                        }

                        String var1 = lstusr[i].genre;
                        if (lstusr[i].genre != null)
                        {
                            if (var1 == "Homme")
                            {
                                rbMale.Checked = true;

                            }
                            else
                            {
                                rbFemale.Checked = true;
                            }
                        }

                        //  String var2 = lstusr.Expr9;

                        /*  if (var2 == "Oui")
                          {
                              checkBox14.Checked = true;
                              comboBox13.Show();
                            
                          }
                          else
                          {
                              checkBox14.Checked = true;
                              comboBox13.Show();
                          }*/
                        // MessageBox.Show(lstusr.nbrepouse.ToString());
                        // MessageBox.Show("i am avant 2");
                        /* if (lstusr.nbrepouse != null)
                         {
                             //MessageBox.Show("i am in 2");
                             textBox11.Text = lstusr.nbrepouse.ToString();
                           

                         int var3 = Convert.ToInt32(lstusr.nbrepouse.ToString());
                         if (var3 == 1)
                         {

                             panel6.Show();
                             panel8.Show();
                             textBox2.Text = lstusr.Nom_epouse.ToString();
                             DateTime d5 = Convert.ToDateTime(lstusr.Date_mariage.Value.Date);
                             dateTimePicker5.Value = d5;
                             textBox10.Text = lstusr.nbrenfant.ToString();
                             comboBox13.SelectedItem = lstusr.Statut;
                         }
                         if (var3 == 2)
                         {

                             panel6.Show();
                             panel8.Show();
                             panel7.Show();
                             var query = from emp in dbpfen.polic
                                         where emp.Expr5 == var
                                         select new { emp.Epouse_ID };


                             int k = Convert.ToInt32(query.First().Epouse_ID);



                             var query2 = from emp in dbpfen.polic
                                          where emp.Expr5 == var && emp.Epouse_ID == k
                                          select new { emp.Nom_epouse, emp.Date_mariage, emp.nbrenfant, emp.Statut };

                             var query3 = from emp in dbpfen.polic
                                          where emp.Expr5 == var && emp.Epouse_ID == k + 1
                                          select new { emp.Nom_epouse, emp.Date_mariage, emp.nbrenfant, emp.Statut };

                             if (query.Count() == 2)
                             {

                                 for (int i = 0; i < query.Count(); i++)
                                 {
                                     textBox2.Text = query2.First().Nom_epouse.ToString();
                                     textBox16.Text = query3.First().Nom_epouse.ToString();
                                     DateTime d5 = Convert.ToDateTime(query2.Single().Date_mariage.Value.Date);
                                     dateTimePicker5.Value = d5;
                                     DateTime d6 = Convert.ToDateTime(query3.Single().Date_mariage.Value.Date);
                                     dateTimePicker6.Value = d6;
                                     textBox10.Text = query2.First().nbrenfant.ToString();
                                     textBox15.Text = query3.First().nbrenfant.ToString();
                                     comboBox13.SelectedItem = query2.First().Statut.ToString();
                                     comboBox14.SelectedItem = query3.First().Statut.ToString();
                                }
                             }

                         }
                         if (var3 == 3)
                         {
                             panel6.Show();
                             panel8.Show();
                             panel7.Show();
                             panel9.Show();

                             var query = from emp in dbpfen.polic
                                         where emp.Expr5 == var
                                         select new { emp.Epouse_ID };

                             int k = Convert.ToInt32(query.First().Epouse_ID);

                             var query2 = from emp in dbpfen.polic
                                          where emp.Expr5 == var && emp.Epouse_ID == k
                                          select new { emp.Nom_epouse, emp.Date_mariage, emp.nbrenfant, emp.Statut };

                             var query3 = from emp in dbpfen.polic
                                          where emp.Expr5 == var && emp.Epouse_ID == k + 1
                                          select new { emp.Nom_epouse, emp.Date_mariage, emp.nbrenfant, emp.Statut };

                             var query4 = from emp in dbpfen.polic
                                          where emp.Expr5 == var && emp.Epouse_ID == k + 2
                                          select new { emp.Nom_epouse, emp.Date_mariage, emp.nbrenfant, emp.Statut };
                             if (query.Count() == 3)
                             {
                                 for (int i = 0; i < query.Count(); i++)
                                 {
                                     textBox2.Text = query2.First().Nom_epouse.ToString();
                                     textBox16.Text = query3.First().Nom_epouse.ToString();
                                     textBox18.Text = query4.First().Nom_epouse.ToString();
                                     DateTime d5 = Convert.ToDateTime(query2.Single().Date_mariage.Value.Date);
                                     dateTimePicker5.Value = d5;
                                     DateTime d6 = Convert.ToDateTime(query3.Single().Date_mariage.Value.Date);
                                     dateTimePicker6.Value = d6;
                                     DateTime d7 = Convert.ToDateTime(query4.Single().Date_mariage.Value.Date);
                                     dateTimePicker7.Value = d6;
                                     textBox10.Text = query2.First().nbrenfant.ToString();
                                     textBox15.Text = query3.First().nbrenfant.ToString();
                                     textBox17.Text = query4.First().nbrenfant.ToString();
                                     comboBox13.SelectedItem = query2.First().Statut.ToString();
                                     comboBox14.SelectedItem = query3.First().Statut.ToString();
                                     comboBox15.SelectedItem = query4.First().Statut.ToString();
                                   
                                 }
                             }
                         }
                         if (var3 == 4)
                         {
                             panel6.Show();
                             panel8.Show();
                             panel7.Show();
                             panel9.Show();
                             panel10.Show();
                             var query = from emp in dbpfen.polic
                                         where emp.Expr5 == var select new { emp.Epouse_ID };

                             int k = Convert.ToInt32(query.First().Epouse_ID);

                             var query2 = from emp in dbpfen.polic
                                          where emp.Expr5 == var && emp.Epouse_ID == k
                                          select new { emp.Nom_epouse, emp.Date_mariage, emp.nbrenfant, emp.Statut };

                             var query3 = from emp in dbpfen.polic
                                          where emp.Expr5 == var && emp.Epouse_ID == k + 1
                                          select new { emp.Nom_epouse, emp.Date_mariage, emp.nbrenfant, emp.Statut };

                             var query4 = from emp in dbpfen.polic
                                          where emp.Expr5 == var && emp.Epouse_ID == k + 2
                                          select new { emp.Nom_epouse, emp.Date_mariage, emp.nbrenfant, emp.Statut };

                             var query5 = from emp in dbpfen.polic
                                          where emp.Expr5 == var && emp.Epouse_ID == k + 3
                                          select new { emp.Nom_epouse, emp.Date_mariage, emp.nbrenfant, emp.Statut };

                             if (query.Count() == 4)
                             {
                                 for (int i = 0; i < query.Count(); i++)
                                 {
                                     textBox2.Text = query2.First().Nom_epouse.ToString();
                                     textBox16.Text = query3.First().Nom_epouse.ToString();
                                     textBox18.Text = query4.First().Nom_epouse.ToString();
                                     textBox20.Text = query5.First().Nom_epouse.ToString();
                                     DateTime d5 = Convert.ToDateTime(query2.Single().Date_mariage.Value.Date);
                                     dateTimePicker5.Value = d5;
                                     DateTime d6 = Convert.ToDateTime(query3.Single().Date_mariage.Value.Date);
                                     dateTimePicker6.Value = d6;
                                     DateTime d7 = Convert.ToDateTime(query4.Single().Date_mariage.Value.Date);
                                     dateTimePicker7.Value = d7;
                                     DateTime d8 = Convert.ToDateTime(query5.Single().Date_mariage.Value.Date);
                                     dateTimePicker6.Value = d8;
                                     textBox10.Text = query2.First().nbrenfant.ToString();
                                     textBox15.Text = query3.First().nbrenfant.ToString();
                                     textBox17.Text = query4.First().nbrenfant.ToString();
                                     textBox19.Text = query5.First().nbrenfant.ToString();
                                     comboBox13.SelectedItem = query2.First().Statut.ToString();
                                     comboBox14.SelectedItem = query3.First().Statut.ToString();
                                     comboBox15.SelectedItem = query4.First().Statut.ToString();
                                     comboBox16.SelectedItem = query5.First().Statut.ToString();
                                 }

                             }
                         }
                        
                     }*/
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        

            TabPage t = tabControl1.TabPages[1];
            tabControl1.SelectedTab = t;

        }

        private void panel6_Paint(object sender, PaintEventArgs e) { }

        private void textBox10_TextChanged_1(object sender, EventArgs e)
        {
          /*  if (textBox10.Text != "")
            {

                int n = Convert.ToInt32(textBox10.Text);
                if (n == 1)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(button11);
                    panel11.Show();
                    panel12.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 2)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(button11);
                    panel11.Show();
                    panel12.Show();
                    panel14.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 3)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(button11);
                    panel11.Show();
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 4)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 5)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 6)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(panel16);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    panel16.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;

                }
                else if (n == 7)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(panel16);
                    panel11.Controls.Add(panel24);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    panel16.Show();
                    panel24.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;

                }
                else if (n == 8)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(panel16);
                    panel11.Controls.Add(panel24);
                    panel11.Controls.Add(panel34);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    panel16.Show();
                    panel24.Show();
                    panel34.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 9)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(panel16);
                    panel11.Controls.Add(panel24);
                    panel11.Controls.Add(panel34);
                    panel11.Controls.Add(panel38);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    panel16.Show();
                    panel24.Show();
                    panel34.Show();
                    panel38.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 10)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(panel16);
                    panel11.Controls.Add(panel24);
                    panel11.Controls.Add(panel34);
                    panel11.Controls.Add(panel38);
                    panel11.Controls.Add(panel59);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    panel16.Show();
                    panel24.Show();
                    panel34.Show();
                    panel38.Show();
                    panel59.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 11)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(panel16);
                    panel11.Controls.Add(panel24);
                    panel11.Controls.Add(panel34);
                    panel11.Controls.Add(panel38);
                    panel11.Controls.Add(panel59);
                    panel11.Controls.Add(panel63);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    panel16.Show();
                    panel24.Show();
                    panel34.Show();
                    panel38.Show();
                    panel59.Show();
                    panel63.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
            }*/
        }

        private void label43_Click(object sender, EventArgs e) {}

        private void panel14_Paint(object sender, PaintEventArgs e) {}

        private void panel12_Paint(object sender, PaintEventArgs e) {}

        private void button11_Click(object sender, EventArgs e)
        {
            //panel11.Controls.Clear();

   
           // checkBox26.Checked = false;
            TabPage t = tabControl1.TabPages[2];
            tabControl1.SelectedTab = t;
        }

        private void panel11_Paint(object sender, PaintEventArgs e) { }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void panel34_Paint(object sender, PaintEventArgs e) { }

        private void dateTimePicker11_ValueChanged(object sender, EventArgs e) { }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
        
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
           /* if (checkBox13.Checked = true)
                panel39.Show();*/
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
          /*  if (checkBox24.Checked = true)
                panel60.Show();*/
        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
           /* if (checkBox26.Checked = true)
                panel64.Show();*/
        }

        private void button9_Click(object sender, EventArgs e)
        {
         

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            /*if (textBox15.Text != "")
            {

                int n = Convert.ToInt32(textBox15.Text);
                if (n == 1)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(button11);
                    panel11.Show();
                    panel12.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 2)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(button11);
                    panel11.Show();
                    panel12.Show();
                    panel14.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 3)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(button11);
                    panel11.Show();
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 4)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 5)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 6)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(panel16);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    panel16.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;

                }
                else if (n == 7)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(panel16);
                    panel11.Controls.Add(panel24);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    panel16.Show();
                    panel24.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                   
                }
                else if (n == 8)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(panel16);
                    panel11.Controls.Add(panel24);
                    panel11.Controls.Add(panel34);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    panel16.Show();
                    panel24.Show();
                    panel34.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 9)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(panel16);
                    panel11.Controls.Add(panel24);
                    panel11.Controls.Add(panel34);
                    panel11.Controls.Add(panel38);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    panel16.Show();
                    panel24.Show();
                    panel34.Show();
                    panel38.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 10)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(panel16);
                    panel11.Controls.Add(panel24);
                    panel11.Controls.Add(panel34);
                    panel11.Controls.Add(panel38);
                    panel11.Controls.Add(panel59);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    panel16.Show();
                    panel24.Show();
                    panel34.Show();
                    panel38.Show();
                    panel59.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 11)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(panel16);
                    panel11.Controls.Add(panel24);
                    panel11.Controls.Add(panel34);
                    panel11.Controls.Add(panel38);
                    panel11.Controls.Add(panel59);
                    panel11.Controls.Add(panel63);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    panel16.Show();
                    panel24.Show();
                    panel34.Show();
                    panel38.Show();
                    panel59.Show();
                    panel63.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;

                }
            }*/
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            /*if (textBox17.Text != "")
            {

                int n = Convert.ToInt32(textBox17.Text);
                if (n == 1)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(button11);
                    panel11.Show();
                    panel12.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 2)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(button11);
                    panel11.Show();
                    panel12.Show();
                    panel14.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 3)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(button11);
                    panel11.Show();
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 4)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 5)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 6)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(panel16);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    panel16.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;

                }
                else if (n == 7)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(panel16);
                    panel11.Controls.Add(panel24);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    panel16.Show();
                    panel24.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;

                }
                else if (n == 8)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(panel16);
                    panel11.Controls.Add(panel24);
                    panel11.Controls.Add(panel34);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    panel16.Show();
                    panel24.Show();
                    panel34.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 9)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(panel16);
                    panel11.Controls.Add(panel24);
                    panel11.Controls.Add(panel34);
                    panel11.Controls.Add(panel38);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    panel16.Show();
                    panel24.Show();
                    panel34.Show();
                    panel38.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 10)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(panel16);
                    panel11.Controls.Add(panel24);
                    panel11.Controls.Add(panel34);
                    panel11.Controls.Add(panel38);
                    panel11.Controls.Add(panel59);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    panel16.Show();
                    panel24.Show();
                    panel34.Show();
                    panel38.Show();
                    panel59.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 11)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(panel16);
                    panel11.Controls.Add(panel24);
                    panel11.Controls.Add(panel34);
                    panel11.Controls.Add(panel38);
                    panel11.Controls.Add(panel59);
                    panel11.Controls.Add(panel63);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    panel16.Show();
                    panel24.Show();
                    panel34.Show();
                    panel38.Show();
                    panel59.Show();
                    panel63.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;

                }
            }*/
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            /*if (textBox19.Text != "")
            {

                int n = Convert.ToInt32(textBox19.Text);
                if (n == 1)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(button11);
                    panel11.Show();
                    panel12.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 2)
                {
                    panel11.Controls.Clear();
                    checkBox1.Checked = false;
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(button11);
                    panel11.Show();
                    panel12.Show();
                    panel14.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 3)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(button11);
                    panel11.Show();
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 4)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 5)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 6)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(panel16);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    panel16.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;

                }
                else if (n == 7)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(panel16);
                    panel11.Controls.Add(panel24);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    panel16.Show();
                    panel24.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;

                }
                else if (n == 8)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(panel16);
                    panel11.Controls.Add(panel24);
                    panel11.Controls.Add(panel34);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    panel16.Show();
                    panel24.Show();
                    panel34.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 9)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(panel16);
                    panel11.Controls.Add(panel24);
                    panel11.Controls.Add(panel34);
                    panel11.Controls.Add(panel38);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    panel16.Show();
                    panel24.Show();
                    panel34.Show();
                    panel38.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 10)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(panel16);
                    panel11.Controls.Add(panel24);
                    panel11.Controls.Add(panel34);
                    panel11.Controls.Add(panel38);
                    panel11.Controls.Add(panel59);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    panel16.Show();
                    panel24.Show();
                    panel34.Show();
                    panel38.Show();
                    panel59.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;
                }
                else if (n == 11)
                {
                    panel11.Controls.Clear();
                    panel11.Controls.Add(panel12);
                    panel11.Controls.Add(panel14);
                    panel11.Controls.Add(panel20);
                    panel11.Controls.Add(panel18);
                    panel11.Controls.Add(panel26);
                    panel11.Controls.Add(panel16);
                    panel11.Controls.Add(panel24);
                    panel11.Controls.Add(panel34);
                    panel11.Controls.Add(panel38);
                    panel11.Controls.Add(panel59);
                    panel11.Controls.Add(panel63);
                    panel11.Controls.Add(button11);
                    panel12.Show();
                    panel14.Show();
                    panel20.Show();
                    panel18.Show();
                    panel26.Show();
                    panel16.Show();
                    panel24.Show();
                    panel34.Show();
                    panel38.Show();
                    panel59.Show();
                    panel63.Show();
                    button11.Show();
                    TabPage t = tabControl1.TabPages[3];
                    tabControl1.SelectedTab = t;

                }
            }*/

        }

        private void panel26_Paint(object sender, PaintEventArgs e){}

        private void checkBox1_CheckStateChanged(object sender, EventArgs e){}

        private void pictureBox4_Click(object sender, EventArgs e){}

        private void pictureBox3_Click(object sender, EventArgs e){}

        private void button14_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JPG(*.jpg, *.jpeg) | *.jpg; *.jpeg | TIFF(*.tif, *.tiff) | *.tif; *.tiff |  PNG(*.png) | *.png | JFIF(*.jfif) | *.jfif";
            DialogResult res = ofd.ShowDialog();
            if (res == DialogResult.OK)
            {
             //   pictureBox3.Image = System.Drawing.Image.FromFile(ofd.FileName);
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e){}

        /*private void button15_Click(object sender, EventArgs e)
        {
            List<polic> lstusr3 = null;
            List<polic> lstusr4 = null;
            DBpoliceEntities dbpfen = new DBpoliceEntities();
            if (comboBox13.SelectedValue != "" | comboBox9.SelectedValue != "")
            {
                    dgw.Rows.Clear();

                    DateTime v = dateTimePicker40.Value;
                    DateTime v1 = dateTimePicker39.Value;
                    int var = Convert.ToInt32(comboBox13.SelectedValue);
                    int var1 = Convert.ToInt32(comboBox9.SelectedValue);
                    lstusr3 = dbpfen.polic.Where(x => (x.Date_naissance >= v) && (x.Date_naissance <= v1) && (x.idGrad == var) && (x.idetude == var1)).ToList();
                    lstusr4 = lstusr3.Distinct().ToList();
                    if (lstusr4.Count() != 0)
                    {
                        for (int i = 0; i < lstusr4.Count(); i++)
                        {

                            
                            string Matricule_ID = lstusr4[i].Matricule_ID.ToString();
                            string Nom_policier = lstusr4[i].Nom_policier.ToString();
                            DateTime date = Convert.ToDateTime(lstusr4[i].Date_naissance.Value.Date);
                            String Date_naissance = Convert.ToString(date.ToShortDateString());
                        string Etude = lstusr4[i].Expr6.ToString();
                            string Grade = lstusr4[i].Expr2.ToString();
                            string Adresse = lstusr4[i].adresse.ToString();
                            string[] row1 = new string[] {
                                     Matricule_ID,
                                     Nom_policier,
                                     Date_naissance,
                                     Etude,
                                     Grade,
                                     Adresse,
                            };
                            dgw.Rows.Add(row1);
                            dgw.Visible = true;
                        }
                    }
            }
        }*/

        private void label96_Click(object sender, EventArgs e){}

        private void checkBox15_CheckedChanged(object sender, EventArgs e){}

        private void button16_Click(object sender, EventArgs e)
        {
            //progressBar1.Increment(1);
            //progressBar1.Value = 4;
            TabPage t = tabControl1.TabPages[4];
            tabControl1.SelectedTab = t;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            TabPage t = tabControl1.TabPages[5];
            tabControl1.SelectedTab = t;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            //progressBar1.Increment(1);
            //progressBar1.Value = progressBar1.Maximum;
            TabPage t = tabControl1.TabPages[0];
            tabControl1.SelectedTab = t;
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            //progressBar1.Value = 6;
            TabPage t = tabControl1.TabPages[5];
            tabControl1.SelectedTab = t;
        }

        private void timer1_Tick(object sender, EventArgs e){}

        private void checkBox15_Click(object sender, EventArgs e)
        {
            if (checkBox15.Checked)
            {
                checkBox15.Text = "criteres avancés";
                panel33.Show();
            }
            else
            {
                checkBox15.Text = "criteres avancés";
                panel33.Hide();
            }
        }

        private void checkBox15_CheckStateChanged(object sender, EventArgs e){}

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
           
        
     
            groupBox1.Enabled = true;
            groupBox4.Enabled = true;
            groupBox2.Enabled = true;
            panel4.Enabled = true;
            btnSave.Visible = true;
            //groupBox6.Visible = false;
         
           
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e){}

        private void label86_Click(object sender, EventArgs e){}

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsNumber(ch) && ch != 8 && ch!= 46)
            {
                e.Handled = true;
            }
        }

        private void txtPatientName_KeyPress(object sender, KeyPressEventArgs e) {}

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsNumber(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox35_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsNumber(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsNumber(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e){}
        private void label31_Click(object sender, EventArgs e){}

      /*  public void diresousdir(string iddirec)
        {
            SqlConnection dbConn;
            dbConn = new SqlConnection(cn.DBConn());
            dbConn.Open();
            SqlCommand cmmd = new SqlCommand("select libelle,idDirect from sous_direction where idDirect = @iddirec", dbConn);
            cmmd.Parameters.AddWithValue("iddirec", iddirec);
            SqlDataAdapter da = new SqlDataAdapter(cmmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            comboBox4.ValueMember = "idDirect";
            comboBox4.DisplayMember = "libelle";
            comboBox4.DataSource = dt;
            dbConn.Close();
        }*/

     /*   public void service(string iddirec)
        {
          
             
            SqlConnection dbConn;
            dbConn = new SqlConnection(cn.DBConn());
            dbConn.Open();
            SqlCommand cmmd = new SqlCommand("select libelle,idsouDirect from service where iddirec = @iddirec", dbConn);
            cmmd.Parameters.AddWithValue("iddirec", iddirec);
            SqlDataAdapter da = new SqlDataAdapter(cmmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dbConn.Close();
            comboBox5.ValueMember = "idsouDirect";
            comboBox5.DisplayMember = "libelle";
            comboBox5.DataSource = dt;
            dbConn.Close();
        }*/

        private void miniToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e){}
        private void textBox2_TextChanged(object sender, EventArgs e){}
        private void dateTimePicker5_ValueChanged(object sender, EventArgs e){}
        private void textBox16_TextChanged(object sender, EventArgs e){}

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            TabPage t = tabControl1.TabPages[6];
            tabControl1.SelectedTab = t;
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            TabPage t = tabControl1.TabPages[4];
            tabControl1.SelectedTab = t;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            TabPage t = tabControl1.TabPages[6];
            tabControl1.SelectedTab = t;
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            TabPage t = tabControl1.TabPages[1];
            tabControl1.SelectedTab = t;
        }

        
      

        private void panel45_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            List<polic> lstusr = null;
            List<polic> lstusr2 = null;
           
           
            DBpoliceEntities dbpfen = new DBpoliceEntities();
            lstusr = dbpfen.polic.ToList();
            lstusr2 = dbpfen.polic.ToList();
          

            try
            {
                if (comboBox7.SelectedValue != "")
                {
                    dgw.Rows.Clear();
                    int var = Convert.ToInt32(comboBox7.SelectedValue);
                    lstusr = dbpfen.polic.Where(x => x.idetude == var).ToList();

                    lstusr2 = lstusr.Distinct().ToList();
                    if (lstusr2.Count() != 0)
                    {
                        for (int i = 0; i < lstusr2.Count(); i++)
                        {

                            string Matricule_ID = lstusr2[i].Matricule_ID.ToString();
                            string Nom_policier = lstusr2[i].Nom_policier.ToString();
                            DateTime date = Convert.ToDateTime(lstusr2[i].Date_naissance.Value.Date);
                            String Date_naissance = Convert.ToString(date.ToShortDateString());
                            string Etude = lstusr2[i].Expr1.ToString();
                            string Grade = lstusr2[i].Expr3.ToString();
                            string Adresse = lstusr2[i].adresse.ToString();
                            string Service = lstusr2[i].Expr4.ToString();
                            string Detachement = lstusr2[i].Libelle.ToString();
                            string Fonction = lstusr2[i].Expr2.ToString();


                            string[] row1 = new string[] {
                                        Matricule_ID,
                                        Nom_policier,
                                        Date_naissance,
                                        Service,
                                        Detachement,
                                        Fonction,
                                        Grade,
                                        Etude,
                                        Adresse,
                               };
                            dgw.Rows.Add(row1);
                            dgw.Visible = true;

                        }

                    }
                }
                if (comboBox4.SelectedValue != "")
                {
                    dgw.Rows.Clear();
                    int var = Convert.ToInt32(comboBox4.SelectedValue);
                    lstusr = dbpfen.polic.Where(x => x.iddetachement == var).ToList();

                    lstusr2 = lstusr.Distinct().ToList();
                    if (lstusr2.Count() != 0)
                    {
                        for (int i = 0; i < lstusr2.Count(); i++)
                        {

                            string Matricule_ID = lstusr2[i].Matricule_ID.ToString();
                            string Nom_policier = lstusr2[i].Nom_policier.ToString();
                            DateTime date = Convert.ToDateTime(lstusr2[i].Date_naissance.Value.Date);
                            String Date_naissance = Convert.ToString(date.ToShortDateString());
                            string Etude = lstusr2[i].Expr1.ToString();
                            string Grade = lstusr2[i].Expr3.ToString();
                            string Adresse = lstusr2[i].adresse.ToString();
                            string Service = lstusr2[i].Expr4.ToString();
                            string Detachement = lstusr2[i].Libelle.ToString();
                            string Fonction = lstusr2[i].Expr2.ToString();


                            string[] row1 = new string[] {
                                        Matricule_ID,
                                        Nom_policier,
                                        Date_naissance,
                                        Service,
                                        Detachement,
                                        Fonction,
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel42_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            //
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            //
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            //
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
        public void Age()
        {
            Dictionary<string, string> comboBox = new Dictionary<string, string>();
            comboBox.Add("0","0-20");
            comboBox.Add("1","20-40");
            comboBox.Add("2","40-60");
            comboBox.Add("3", "60-80");

            comboBox4.DataSource = new BindingSource(comboBox, null);

            comboBox4.DisplayMember = "Value";
            comboBox4.ValueMember = "Key";


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

        public void statut()
        {
            SqlConnection dbConn;
            SqlDataAdapter da;
            dbConn = new SqlConnection(cn.DBConn());
            dbConn.Open();
            da = new SqlDataAdapter("select Libelle from Statut", dbConn);
            DataTable ds2 = new DataTable();
            comboBox4.DataSource = ds2;
            da.Fill(ds2);
            comboBox4.DisplayMember = "Libelle";
            comboBox4.ValueMember = "Libelle";
            dbConn.Close();

        }

        private void comboBox7_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox7.SelectedIndex == 0)
            {
               // panel38.Hide();
                label10.Text = "Grade:";
                grade();
            }

            if (comboBox7.SelectedIndex == 1)
            {
                //panel38.Hide();
               label10.Text = "Direction:";
               direction();
            }

            if (comboBox7.SelectedIndex == 2)
            {
                //panel38.Hide();
                label10.Text = "Service:";
                service();
            }

            if (comboBox7.SelectedIndex == 3)
            {
               // panel38.Hide();
                label10.Text = "Direction:";
                direction();
            }
            if (comboBox7.SelectedIndex == 4)
            {
               // panel38.Hide();
                label10.Text = "Grade:";
                grade();
            }
            if (comboBox7.SelectedIndex == 5)
            {
                //panel38.Hide();
                label10.Text = "Fonction:";
                fonction();
            }
            if (comboBox7.SelectedIndex == 6)
            {
                //panel38.Hide();
                label10.Text = "Statut:";
                statut();
            }
            if (comboBox7.SelectedIndex == 7)
            {
                label10.Text = "NombreEnfant:";
               // panel38.Show();

                //comboBox4.DataSource = new List<string> { "18", "19", "20","21","22","23","24","25","26","27","28","29","30","31","32","33","34","35","36","37","38","39","40","41","42","43","44","45","46","47","48","49","50","51","52","53","54","55","56","57","58","59","60","61","62","63","64","65","66","67","68","69","70","71","72","73","74","75","76","77","78","79","80" };
                comboBox4.DataSource = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" }; 
            }
        }

        private void button15_Click_2(object sender, EventArgs e)
        {
            List<polic> lstusr3 = null;
            List<polic> lstusr4 = null;
             
            DBpoliceEntities dbpfen = new DBpoliceEntities();




            

            if (comboBox4.SelectedValue != "")
          {
               dgw.Rows.Clear();
                lstusr3 = dbpfen.polic.Where(x => (x.Expr1 == comboBox4.SelectedValue) || (x.Libelle == comboBox4.SelectedValue) || (x.Expr4 == comboBox4.SelectedValue) || (x.Expr3 == comboBox4.SelectedValue) || (x.Expr2 == comboBox4.SelectedValue) || (x.Type_direction == comboBox4.SelectedValue) || (x.Expr7 == comboBox4.SelectedValue)).ToList();
                lstusr4 = lstusr3.Distinct().ToList();

                if (lstusr4.Count() != 0)
                {
                    for (int i = 0; i < lstusr4.Count(); i++)
                    {
                        string Matricule_ID = lstusr4[i].Matricule_ID.ToString();
                        string Nom_policier = lstusr4[i].Nom_policier.ToString();
                      
                        DateTime date = Convert.ToDateTime(lstusr4[i].Date_naissance.Value.Date);

                        String Date_naissance = Convert.ToString(date.ToShortDateString());
                   
                        string Lieu = lstusr4[i].LieuN.ToString(); 
                        string Grade = lstusr4[i].Expr3.ToString();
                        DateTime date1 = Convert.ToDateTime(lstusr4[i].daterecru.Value.Date);
                        string dateEng = Convert.ToString(date1.ToShortDateString());
                   

                        DateTime date2 = Convert.ToDateTime(lstusr4[i].dateDAvanc.Value.Date);

                        string dateAV = Convert.ToString(date2.ToShortDateString());
                        string d = lstusr4[i].Type_direction.ToString();

                        if (Matricule_ID != null && Nom_policier != null && Date_naissance != null && Lieu != null && Grade != null && dateEng != null && dateAV != null)
                        {

                            string[] row1 = new string[] {
                                    Matricule_ID,
                                    Nom_policier,
                                    Date_naissance,
                               
                                     Lieu,
                                    Grade,
                                    dateEng,
                                    dateAV,
                                    d
                                
                           };

                            dgw.Rows.Add(row1);
                            dgw.Visible = true;
                            label89.Visible = true;
                            label90.Visible = true;
                            label90.Text = dgw.RowCount.ToString();
                        }
                    }
                }
               
            }
          
        }

        private void button22_Click(object sender, EventArgs e)
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

        private void button24_Click(object sender, EventArgs e)
        {
            TabPage t = tabControl1.TabPages[2];
            tabControl1.SelectedTab = t;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            TabPage t = tabControl1.TabPages[1];
            tabControl1.SelectedTab = t;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            TabPage t = tabControl1.TabPages[4];
            tabControl1.SelectedTab = t;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            TabPage t = tabControl1.TabPages[6];
            tabControl1.SelectedTab = t;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            TabPage t = tabControl1.TabPages[2];
            tabControl1.SelectedTab = t;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            TabPage t = tabControl1.TabPages[4];
            tabControl1.SelectedTab = t;
        }

     

        private void checkBox14_CheckedChanged_1(object sender, EventArgs e)
        {
            //
        }



        private void tabPage2_Click(object sender, EventArgs e)
        {
            List<polic> lstusr3 = null;
            List<polic> lstusr4 = null;

            DBpoliceEntities dbpfen = new DBpoliceEntities();
            if (textBox13.Text != "")
            {
                int var = Convert.ToInt32(textBox13.Text);
                dgw.Rows.Clear();
                ConnectionString cs = new ConnectionString();
                SqlConnection cn = new SqlConnection(cs.DBConn());

                //open
                cn.Open();
                string commandText = "select Nom_enfant,Date_naissance,lieu,Nom_mere,Matricule_ID  from enfants where matricule_ID='" + var + "'";
                SqlCommand command = new SqlCommand(commandText, cn);
                adapter = new SqlDataAdapter(command);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                lstusr3 = dbpfen.polic.Where(x => (x.Matricule_ID == var)).ToList();
                lstusr4 = lstusr3.Distinct().ToList();

                if (lstusr4.Count() != 0)
                {
                    for (int i = 0; i < lstusr4.Count(); i++)
                    {
                        string Matricule_ID = lstusr4[i].Matricule_ID.ToString();
                        string Nom_policier = lstusr4[i].Nom_policier.ToString();

                        DateTime date = Convert.ToDateTime(lstusr4[i].Date_naissance.Value.Date);

                        String Date_naissance = Convert.ToString(date.ToShortDateString());

                        String Lieu = lstusr4[i].LieuN.ToString();
                        string Grade = lstusr4[i].Expr3.ToString();
                        DateTime date1 = Convert.ToDateTime(lstusr4[i].daterecru.Value.Date);
                        String dateEng = Convert.ToString(date1.ToShortDateString());


                       DateTime date2 = Convert.ToDateTime(lstusr4[i].daterecru.Value.Date);

                        String dateAV = Convert.ToString(date2.ToShortDateString());
                        string d = lstusr4[i].Type_direction.ToString();
                        if (Matricule_ID != null && Nom_policier != null && Date_naissance != null && Lieu != null && Grade != null && dateEng != null && dateAV != null)
                        {

                            string[] row1 = new string[] {
                                    Matricule_ID,
                                    Nom_policier,
                                    Date_naissance,
                               
                                     Lieu,
                                    Grade,
                                    dateEng,
                                    dateAV,
                                    d
                                
                           };

                            dgw.Rows.Add(row1);
                            dgw.Visible = true;
                            label89.Visible = true;
                            label90.Visible = true;
                            label90.Text = dgw.RowCount.ToString();
                            
                        }
                    }
                }

            }
            else if (textBox12.Text != "")
            {
                dgw.Rows.Clear();
                string n = textBox12.Text;
                lstusr3 = dbpfen.polic.Where(x => (x.Nom_policier.StartsWith(n))).ToList();
                lstusr4 = lstusr3.Distinct().ToList();

                if (lstusr4.Count() != 0)
                {
                    for (int i = 0; i < lstusr4.Count(); i++)
                    {
                        string Matricule_ID = lstusr4[i].Matricule_ID.ToString();
                        string Nom_policier = lstusr4[i].Nom_policier.ToString();
                   
                        DateTime date = Convert.ToDateTime(lstusr4[i].Date_naissance.Value.Date);
                     
                        String Date_naissance = Convert.ToString(date.ToShortDateString());
                      
                        String Lieu = lstusr4[i].LieuN.ToString();
                        string Grade = lstusr4[i].Expr3.ToString();
                     
                        DateTime date1 = Convert.ToDateTime(lstusr4[i].daterecru.Value.Date);
                        String dateEng = Convert.ToString(date1.ToShortDateString());
                 

                         DateTime date2 = Convert.ToDateTime(lstusr4[i].dateDAvanc.Value.Date); 

                        String dateAV = Convert.ToString(date2.ToShortDateString());
                        string d = lstusr4[i].Type_direction.ToString();
                        if (Matricule_ID != null && Nom_policier != null && Date_naissance != null && Lieu != null && Grade != null && dateEng != null && dateAV != null)
                        {

                            string[] row1 = new string[] {
                                    Matricule_ID,
                                    Nom_policier,
                                    Date_naissance,
                               
                                     Lieu,
                                    Grade,
                                    dateEng,
                                    dateAV,
                                    d
                                
                           };

                            dgw.Rows.Add(row1);
                            dgw.Visible = true;
                            label89.Visible = true;
                            label90.Visible = true;
                            label90.Text = dgw.RowCount.ToString();

                        }
                    }

                }
            }
        }
 
        private void checkBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void label89_Click(object sender, EventArgs e)
        {

        }

        private void dgw_SelectionChanged(object sender, EventArgs e)
        {
             foreach (DataGridViewRow row in dgw.SelectedRows) 
    {
                 }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }


        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsNumber(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
    

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
         

        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*try
            {
                //get list of devices available
                List<string> devices = WIAScanner.GetDevices();

                foreach (string device in devices)
                {
                    lbDevices.Items.Add(device);
                }
                //check if device is not available
                if (lbDevices.Items.Count == 0)
                {
                    MessageBox.Show("Aucun peripherie detecté.");
                    this.Close();
                }
                else
                {
                    lbDevices.SelectedIndex = 0;
                }
                //get images from scanner
                List<System.Drawing.Image> images = WIAScanner.Scan((string)lbDevices.SelectedItem);
                foreach (System.Drawing.Image image in images)
                {
                    pictureBox3.Image = image;
                    pictureBox3.Show();
                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                    //save scanned image into specific folder
                  //  image.Save(@"F:\" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".jpeg", ImageFormat.Jpeg);

                      ConnectionString cn = new ConnectionString();
                string insertCmd = "INSERT INTO filesImages (nomimage,image,idpolicier) VALUES (@f,@f1,@f2)";
                SqlConnection dbConn;
                dbConn = new SqlConnection(cn.DBConn());
                dbConn.Open();
                //Authentification lg = new Authentification();

                //GetValue value = new GetValue();
              
                    SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);

                    myCommand.Parameters.AddWithValue("@f", textBox6.Text);
                    MemoryStream stream = new MemoryStream();
                    pictureBox3.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] imageBt1 = stream.ToArray();
                    myCommand.Parameters.AddWithValue("@f1", imageBt1);
                    myCommand.Parameters.AddWithValue("@f2", txtPatientID.Text);
                  
                    myCommand.ExecuteNonQuery();
                    MessageBox.Show("Scan succès");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            */
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
          
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox12_SelectedIndexChanged_1(object sender, EventArgs e)
        {
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
           // metroComboBox1.Visible = true;

            
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
         /*   if (metroComboBox1.SelectedIndex == 0)
            {
                label32.Visible = true;
                textBox7.Visible = true;
                label28.Visible = true;
                dateTimePicker3.Visible = true;
                label24.Visible = true;
                dateTimePicker5.Visible = true;
                label26.Visible = true;
                textBox2.Visible = true;
                button11.Visible = true;
              
            }
            else if (metroComboBox1.SelectedIndex == 1)
            {
                label32.Visible = true;
                textBox7.Visible = true;
                label28.Visible = true;
                dateTimePicker3.Visible = true;
                label26.Visible = true;
                dateTimePicker5.Visible = false;
                label24.Visible = false;
                textBox2.Visible = true;
                button11.Visible = true;
                label34.Visible = true;
                textBox10.Visible = true;
                label26.Visible = true;
                textBox2.Visible = true;

               /* int n = Convert.ToInt32(txtPatientID.Text);
                var item = (from m in dbpfen.Epouses.Where(a => a.idPolicier == n)
                            select m.Nom_epouse).ToList();




                metroComboBox2.ValueMember = "Epouse_ID";
                metroComboBox2.DisplayMember = "Nom_epouse";
                metroComboBox2.DataSource = item.ToArray();
         
            }
            else
            {
                label32.Visible = false;
                textBox7.Visible = false;
                label28.Visible = false;
                dateTimePicker3.Visible = false;
                label24.Visible = false;
                dateTimePicker5.Visible = false;
                label26.Visible = false;
                textBox2.Visible = false;
                button11.Visible = false;
                //metroComboBox2.Visible = false;
                label34.Visible = false;
                textBox10.Visible = false;
            }*/
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            ConnectionString cs = new ConnectionString();
            SqlConnection cn = new SqlConnection(cs.DBConn());

            //open
            cn.Open();
            string commandText = "select * from view_enfant where matricule_id='" + txtPatientID + "'";
            SqlCommand command = new SqlCommand(commandText, cn);
            adapter = new SqlDataAdapter(command);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            /*if(metroComboBox1.SelectedIndex==0)
            {
                DateTime d = Convert.ToDateTime(dateTimePicker3.Text);
                int a = d.Year;
                int da = DateTime.Now.Year;
                int age = da - a;

                ConnectionString cn = new ConnectionString();
                string insertCmd = "INSERT INTO Epouses (Nom_epouse,DateN,Lieu,Date_mariage,idPolicier) VALUES (@f,@f1,@f2,@f3,@f4)";
                SqlConnection dbConn;
                dbConn = new SqlConnection(cn.DBConn());
                dbConn.Open();
                //Authentification lg = new Authentification();

                //GetValue value = new GetValue();
                if (age > 18)
                {
                    SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);

                    myCommand.Parameters.AddWithValue("@f", textBox7.Text);
                    myCommand.Parameters.AddWithValue("@f1", dateTimePicker3.Value);
                    myCommand.Parameters.AddWithValue("@f2", textBox2.Text);
                    myCommand.Parameters.AddWithValue("@f3", dateTimePicker5.Value);
                    myCommand.Parameters.AddWithValue("@f4", txtPatientID.Text);
                    myCommand.ExecuteNonQuery();
                    MessageBox.Show("Ajout membre de la famille succès");
                }
                else
                    MessageBox.Show("Erreur! l'age de l'epouse  est inférieur à 18 ans . ", "Liste policier", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (metroComboBox1.SelectedIndex == 1)
            {
            

                ConnectionString cn = new ConnectionString();
                string insertCmd = "INSERT INTO Enfants (Nom_enfant,Date_naissance,lieu,nomM,Matricule_ID) VALUES (@f,@f1,@f2,@f3,@f4)";
                SqlConnection dbConn;
                dbConn = new SqlConnection(cn.DBConn());
                dbConn.Open();
              //  int n= Convert.ToInt32(metroComboBox2.SelectedItem.ToString());
                //Authentification lg = new Authentification();

                //GetValue value = new GetValue();
              
                    SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);

                    myCommand.Parameters.AddWithValue("@f", textBox7.Text);
                    myCommand.Parameters.AddWithValue("@f1", dateTimePicker3.Value);
                    myCommand.Parameters.AddWithValue("@f2", textBox2.Text);
                    myCommand.Parameters.AddWithValue("@f3", textBox10.Text);
                    myCommand.Parameters.AddWithValue("@f4", txtPatientID.Text);
                    myCommand.ExecuteNonQuery();
                    MessageBox.Show("Ajout membre de la famille succès");
                
                
            }*/

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Open Image";
            dlg.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";


            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox4.Image = new Bitmap(dlg.OpenFile());
            }

            dlg.Dispose();

        }

    }
}

