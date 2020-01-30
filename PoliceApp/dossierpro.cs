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
using System.Collections.Generic;
using Dynamsoft.TWAIN.Interface;
using Dynamsoft.Core;
using Dynamsoft.PDF;
using Dynamsoft.Core.Enums;
using Dynamsoft.TWAIN;
namespace PoliceApp
{
    public partial class dossierpro : MetroFramework.Forms.MetroForm
    {

        public dossierpro()
        {
            InitializeComponent();
        }
        ConnectionString cs = new ConnectionString();
        CommonClasses cc = new CommonClasses();
        public TwainManager m_TwainManager = null;
        public ImageCore m_ImageCore = null;
        public string m_StrProductKey = "t0068UwAAAKFpIU8HbPdT+N5/w5kIId/1KPF5RmctGkta5hAAreTfhXryOvVplpsw5yszIAB6sK4p/F6s7s8ozk38LluDUZc=";

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {

                MessageBox.Show("Remplissez les éléments vides", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
            }
            else
            {
                try
                {




                    //save scanned image into specific folder
                    //  image.Save(@"F:\" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".jpeg", ImageFormat.Jpeg);

                    ConnectionString cn = new ConnectionString();
                    string insertCmd = "INSERT INTO decision (document,idpolicier,datecreate,createby,id_type_dec,datedec,numdec,comment) VALUES (@f,@f1,@f2,@f3,@f6,@f7,@f8,@f9)";
                    SqlConnection dbConn;
                    dbConn = new SqlConnection(cn.DBConn());
                    dbConn.Open();
                    //Authentification lg = new Authentification();
                    FileInfo fi = new FileInfo(textBox3.Text);
                    FileStream fs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read);
                    BinaryReader rdr = new BinaryReader(fs);
                    byte[] fileData = rdr.ReadBytes((int)fs.Length);
                    rdr.Close();
                    fs.Close();


                    SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);

                    myCommand.Parameters.AddWithValue("@f", SqlDbType.VarBinary).Value = fileData;
                    myCommand.Parameters.AddWithValue("@f1", textBox1.Text);

                    myCommand.Parameters.AddWithValue("@f2", DateTime.Now);
                    myCommand.Parameters.AddWithValue("@f3", frmLogin.ControlID.LOGINATE);

                    myCommand.Parameters.AddWithValue("@f6", metroComboBox1.SelectedValue);
                    myCommand.Parameters.AddWithValue("@f7", dateTimePicker1.Value);
                    myCommand.Parameters.AddWithValue("@f8", textBox2.Text);
                    myCommand.Parameters.AddWithValue("@f9", richTextBox1.Text);
                    myCommand.ExecuteNonQuery();

                    MessageBox.Show("Ajouté avec succès");


                }






                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }

            }

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        DBpoliceEntities dbpfen = new DBpoliceEntities();
        private void dossierpro_Load(object sender, EventArgs e)
        {
            metroComboBox1.ValueMember = "id";
            metroComboBox1.DisplayMember = "libelle";
            metroComboBox1.DataSource = dbpfen.type_decision.ToList<type_decision>();

            metroComboBox2.ValueMember = "id";
            metroComboBox2.DisplayMember = "libelle";
            metroComboBox2.DataSource = dbpfen.Type_sanction.ToList<Type_sanction>();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void rdbtnTIFF_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = openFileDialog1.FileName;
            }

        }

        // Punition
        private void button3_Click_2(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                MessageBox.Show("Remplissez les éléments vides", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox6.Focus();
            }
            else
            {
                try
                {




                    //save scanned image into specific folder
                    //  image.Save(@"F:\" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".jpeg", ImageFormat.Jpeg);

                    ConnectionString cn = new ConnectionString();
                    string insertCmd = "INSERT INTO punition (document,idpolicier,datecreate,createby,idtype,datefait,duree,comment) VALUES (@f,@f1,@f2,@f3,@f6,@f7,@f8,@f9)";
                    SqlConnection dbConn;
                    dbConn = new SqlConnection(cn.DBConn());
                    dbConn.Open();
                    //Authentification lg = new Authentification();
                    FileInfo fi = new FileInfo(textBox4.Text);
                    FileStream fs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read);
                    BinaryReader rdr = new BinaryReader(fs);
                    byte[] fileData = rdr.ReadBytes((int)fs.Length);
                    rdr.Close();
                    fs.Close();


                    SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);

                    myCommand.Parameters.AddWithValue("@f", SqlDbType.VarBinary).Value = fileData;
                    myCommand.Parameters.AddWithValue("@f1", textBox6.Text);

                    myCommand.Parameters.AddWithValue("@f2", DateTime.Now);
                    myCommand.Parameters.AddWithValue("@f3", frmLogin.ControlID.LOGINATE);

                    myCommand.Parameters.AddWithValue("@f6", metroComboBox2.SelectedValue);
                    myCommand.Parameters.AddWithValue("@f7", dateTimePicker2.Value);
                    myCommand.Parameters.AddWithValue("@f8", textBox5.Text);
                    myCommand.Parameters.AddWithValue("@f9", richTextBox2.Text);
                    myCommand.ExecuteNonQuery();

                    MessageBox.Show("Ajouté avec succès");


                }






                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }

            }

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = openFileDialog1.FileName;
            }
        }
        private void buttonNotation_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox22.Text = openFileDialog1.FileName;
            }
        }

        private void buttonFicheSolde_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox18.Text = openFileDialog1.FileName;
            }
        }

        private void buttonDivers_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox24.Text = openFileDialog1.FileName;
            }
        }

        private void buttonInstruction_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox21.Text = openFileDialog1.FileName;
            }
        }

        // Conge annuel
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {

                MessageBox.Show("Remplissez les éléments vides", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox9.Focus();
            }
            else
            {
                try
                {




                    //save scanned image into specific folder
                    //  image.Save(@"F:\" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".jpeg", ImageFormat.Jpeg);

                    ConnectionString cn = new ConnectionString();
                    string insertCmd = "INSERT INTO congeAnnuel (document,idpolicier,datecreate,createby,dated,datef,duree) VALUES (@f,@f1,@f2,@f3,@f7,@f8,@f9)";
                    SqlConnection dbConn;
                    dbConn = new SqlConnection(cn.DBConn());
                    dbConn.Open();
                    //Authentification lg = new Authentification();
                    FileInfo fi = new FileInfo(textBox7.Text);
                    FileStream fs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read);
                    BinaryReader rdr = new BinaryReader(fs);
                    byte[] fileData = rdr.ReadBytes((int)fs.Length);
                    rdr.Close();
                    fs.Close();


                    SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);

                    myCommand.Parameters.AddWithValue("@f", SqlDbType.VarBinary).Value = fileData;
                    myCommand.Parameters.AddWithValue("@f1", textBox9.Text);

                    myCommand.Parameters.AddWithValue("@f2", DateTime.Now);
                    myCommand.Parameters.AddWithValue("@f3", frmLogin.ControlID.LOGINATE);


                    myCommand.Parameters.AddWithValue("@f7", dateTimePicker3.Value);
                    myCommand.Parameters.AddWithValue("@f8", dateTimePicker4.Value);
                    myCommand.Parameters.AddWithValue("@f9", textBox8.Text);
                    myCommand.ExecuteNonQuery();

                    MessageBox.Show("Ajouté avec succès");


                }






                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox7.Text = openFileDialog1.FileName;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox11.Text = openFileDialog1.FileName;
            }

        }

        // Conge Maladie
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox12.Text == "")
            {

                MessageBox.Show("Remplissez les éléments vides", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox12.Focus();
            }
            else
            {
                try
                {




                    //save scanned image into specific folder
                    //  image.Save(@"F:\" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".jpeg", ImageFormat.Jpeg);

                    ConnectionString cn = new ConnectionString();
                    string insertCmd = "INSERT INTO congeMaladie (document,idpolicier,datecreate,createby,dated,datef,duree) VALUES (@f,@f1,@f2,@f3,@f7,@f8,@f9)";
                    SqlConnection dbConn;
                    dbConn = new SqlConnection(cn.DBConn());
                    dbConn.Open();
                    //Authentification lg = new Authentification();
                    FileInfo fi = new FileInfo(textBox11.Text);
                    FileStream fs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read);
                    BinaryReader rdr = new BinaryReader(fs);
                    byte[] fileData = rdr.ReadBytes((int)fs.Length);
                    rdr.Close();
                    fs.Close();


                    SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);

                    myCommand.Parameters.AddWithValue("@f", SqlDbType.VarBinary).Value = fileData;
                    myCommand.Parameters.AddWithValue("@f1", textBox12.Text);

                    myCommand.Parameters.AddWithValue("@f2", DateTime.Now);
                    myCommand.Parameters.AddWithValue("@f3", frmLogin.ControlID.LOGINATE);


                    myCommand.Parameters.AddWithValue("@f7", dateTimePicker6.Value);
                    myCommand.Parameters.AddWithValue("@f8", dateTimePicker5.Value);
                    myCommand.Parameters.AddWithValue("@f9", textBox10.Text);
                    myCommand.ExecuteNonQuery();

                    MessageBox.Show("Ajouté avec succès");


                }






                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }

            }

        }

        // Affectation
        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox15.Text == "")
            {

                MessageBox.Show("Remplissez les éléments vides", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox15.Focus();
            }
            else
            {
                try
                {




                    //save scanned image into specific folder
                    //  image.Save(@"F:\" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".jpeg", ImageFormat.Jpeg);

                    ConnectionString cn = new ConnectionString();
                    string insertCmd = "INSERT INTO Affectation (document,idpolicier,datecreate,createby,dateA,lieu,numNs,comment) VALUES (@f,@f1,@f2,@f3,@f7,@f8,@f9,@f10)";
                    SqlConnection dbConn;
                    dbConn = new SqlConnection(cn.DBConn());
                    dbConn.Open();
                    //Authentification lg = new Authentification();
                    FileInfo fi = new FileInfo(textBox13.Text);
                    FileStream fs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read);
                    BinaryReader rdr = new BinaryReader(fs);
                    byte[] fileData = rdr.ReadBytes((int)fs.Length);
                    rdr.Close();
                    fs.Close();


                    SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);

                    myCommand.Parameters.AddWithValue("@f", SqlDbType.VarBinary).Value = fileData;
                    myCommand.Parameters.AddWithValue("@f1", textBox15.Text);

                    myCommand.Parameters.AddWithValue("@f2", DateTime.Now);
                    myCommand.Parameters.AddWithValue("@f3", frmLogin.ControlID.LOGINATE);


                    myCommand.Parameters.AddWithValue("@f7", dateTimePicker7.Value);
                    myCommand.Parameters.AddWithValue("@f8", textBox16.Text);
                    myCommand.Parameters.AddWithValue("@f9", textBox14.Text);
                    myCommand.Parameters.AddWithValue("@f10", richTextBox3.Text);
                    myCommand.ExecuteNonQuery();

                    MessageBox.Show("Ajouté avec succès");


                }






                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox13.Text = openFileDialog1.FileName;
            }
        }

        private void metroLabel29_Click(object sender, EventArgs e)
        {

        }

        //Notation
        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox25.Text == "")
            {
                MessageBox.Show("Remplissez les éléments vides", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox25.Focus();
            }
            else
            {
                try
                {
                    //save scanned image into specific folder
                    //  image.Save(@"F:\" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".jpeg", ImageFormat.Jpeg);

                    ConnectionString cn = new ConnectionString();
                    string insertCmd = "INSERT INTO notation (document,idpolicier,datecreate,createby,comment,notationAnnuelle) VALUES (@f,@f1,@f2,@f3,@f7,@f8)";
                    SqlConnection dbConn;
                    dbConn = new SqlConnection(cn.DBConn());
                    dbConn.Open();
                    //Authentification lg = new Authentification();
                    FileInfo fi = new FileInfo(textBox22.Text);
                    FileStream fs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read);
                    BinaryReader rdr = new BinaryReader(fs);
                    byte[] fileData = rdr.ReadBytes((int)fs.Length);
                    rdr.Close();
                    fs.Close();


                    SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);
                    myCommand.Parameters.AddWithValue("@f", SqlDbType.VarBinary).Value = fileData;
                    myCommand.Parameters.AddWithValue("@f1", textBox25.Text);
                    myCommand.Parameters.AddWithValue("@f2", DateTime.Now);
                    myCommand.Parameters.AddWithValue("@f3", frmLogin.ControlID.LOGINATE);
                    myCommand.Parameters.AddWithValue("@f7", richTextBox6.Text);
                    myCommand.Parameters.AddWithValue("@f8", textBox19.Text);
                    myCommand.ExecuteNonQuery();
                    MessageBox.Show("Ajouté avec succès");

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        // Instruction

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox23.Text == "")
            {
                MessageBox.Show("Remplissez les éléments vides", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox23.Focus();
            }
            else
            {
                try
                {
                    //save scanned image into specific folder
                    //  image.Save(@"F:\" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".jpeg", ImageFormat.Jpeg);

                    ConnectionString cn = new ConnectionString();
                    string insertCmd = "INSERT INTO instruction (document,idpolicier,datecreate,createby,comment) VALUES (@f,@f1,@f2,@f3,@f7)";
                    SqlConnection dbConn;
                    dbConn = new SqlConnection(cn.DBConn());
                    dbConn.Open();
                    //Authentification lg = new Authentification();
                    FileInfo fi = new FileInfo(textBox21.Text);
                    FileStream fs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read);
                    BinaryReader rdr = new BinaryReader(fs);
                    byte[] fileData = rdr.ReadBytes((int)fs.Length);
                    rdr.Close();
                    fs.Close();


                    SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);
                    myCommand.Parameters.AddWithValue("@f", SqlDbType.VarBinary).Value = fileData;
                    myCommand.Parameters.AddWithValue("@f1", textBox23.Text);
                    myCommand.Parameters.AddWithValue("@f2", DateTime.Now);
                    myCommand.Parameters.AddWithValue("@f3", frmLogin.ControlID.LOGINATE);
                    myCommand.Parameters.AddWithValue("@f7", richTextBox5.Text);
                    myCommand.ExecuteNonQuery();
                    MessageBox.Show("Ajouté avec succès");

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        // Fiche de solde
        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox20.Text == "")
            {
                MessageBox.Show("Remplissez les éléments vides", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox20.Focus();
            }
            else
            {
                try
                {
                    //save scanned image into specific folder
                    //  image.Save(@"F:\" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".jpeg", ImageFormat.Jpeg);

                    ConnectionString cn = new ConnectionString();
                    string insertCmd = "INSERT INTO ficheSolde (document,idpolicier,datecreate,createby,comment,etatSolde) VALUES (@f,@f1,@f2,@f3,@f7,@f8)";
                    SqlConnection dbConn;
                    dbConn = new SqlConnection(cn.DBConn());
                    dbConn.Open();
                    //Authentification lg = new Authentification();
                    FileInfo fi = new FileInfo(textBox18.Text);
                    FileStream fs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read);
                    BinaryReader rdr = new BinaryReader(fs);
                    byte[] fileData = rdr.ReadBytes((int)fs.Length);
                    rdr.Close();
                    fs.Close();


                    SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);
                    myCommand.Parameters.AddWithValue("@f", SqlDbType.VarBinary).Value = fileData;
                    myCommand.Parameters.AddWithValue("@f1", textBox20.Text);
                    myCommand.Parameters.AddWithValue("@f2", DateTime.Now);
                    myCommand.Parameters.AddWithValue("@f3", frmLogin.ControlID.LOGINATE);
                    myCommand.Parameters.AddWithValue("@f7", richTextBox4.Text);
                    myCommand.Parameters.AddWithValue("@f8", textBox17.Text);
                    myCommand.ExecuteNonQuery();
                    MessageBox.Show("Ajouté avec succès");

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox26.Text == "")
            {
                MessageBox.Show("Remplissez les éléments vides", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox26.Focus();
            }
            else
            {
                try
                {
                    //save scanned image into specific folder
                    //  image.Save(@"F:\" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".jpeg", ImageFormat.Jpeg);

                    ConnectionString cn = new ConnectionString();
                    string insertCmd = "INSERT INTO divers (document,idpolicier,datecreate,createby,comment) VALUES (@f,@f1,@f2,@f3,@f7)";
                    SqlConnection dbConn;
                    dbConn = new SqlConnection(cn.DBConn());
                    dbConn.Open();
                    //Authentification lg = new Authentification();
                    FileInfo fi = new FileInfo(textBox24.Text);
                    FileStream fs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read);
                    BinaryReader rdr = new BinaryReader(fs);
                    byte[] fileData = rdr.ReadBytes((int)fs.Length);
                    rdr.Close();
                    fs.Close();


                    SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);
                    myCommand.Parameters.AddWithValue("@f", SqlDbType.VarBinary).Value = fileData;
                    myCommand.Parameters.AddWithValue("@f1", textBox26.Text);
                    myCommand.Parameters.AddWithValue("@f2", DateTime.Now);
                    myCommand.Parameters.AddWithValue("@f3", frmLogin.ControlID.LOGINATE);
                    myCommand.Parameters.AddWithValue("@f7", richTextBox7.Text);
                    myCommand.ExecuteNonQuery();
                    
                    MessageBox.Show("Ajouté avec succès");

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox27.Text = openFileDialog1.FileName;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (textBox28.Text == "")
            {
                MessageBox.Show("Remplissez les éléments vides", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox28.Focus();
            }
            else
            {
                try
                {
                    //save scanned image into specific folder
                    //  image.Save(@"F:\" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".jpeg", ImageFormat.Jpeg);

                    ConnectionString cn = new ConnectionString();
                    string insertCmd = "INSERT INTO etatcivil (document,idpolicier,datecreate,createby,comment) VALUES (@f,@f1,@f2,@f3,@f7)";
                    SqlConnection dbConn;
                    dbConn = new SqlConnection(cn.DBConn());
                    dbConn.Open();
                    //Authentification lg = new Authentification();
                    FileInfo fi = new FileInfo(textBox27.Text);
                    FileStream fs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read);
                    BinaryReader rdr = new BinaryReader(fs);
                    byte[] fileData = rdr.ReadBytes((int)fs.Length);
                    rdr.Close();
                    fs.Close();


                    SqlCommand myCommand = new SqlCommand(insertCmd, dbConn);
                    myCommand.Parameters.AddWithValue("@f", SqlDbType.VarBinary).Value = fileData;
                    myCommand.Parameters.AddWithValue("@f1", textBox28.Text);
                    myCommand.Parameters.AddWithValue("@f2", DateTime.Now);
                    myCommand.Parameters.AddWithValue("@f3", frmLogin.ControlID.LOGINATE);
                    myCommand.Parameters.AddWithValue("@f7", richTextBox8.Text);
                    myCommand.ExecuteNonQuery();

                    MessageBox.Show("Ajouté avec succès");

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }
    }
}

