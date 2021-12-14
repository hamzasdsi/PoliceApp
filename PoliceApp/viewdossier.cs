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
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing.Imaging;
using System.Diagnostics;
using WIA;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
namespace PoliceApp
{
    public partial class viewdossier : MetroFramework.Forms.MetroForm
    {
        public viewdossier()
        {
            InitializeComponent();
        }

        private void viewdossier_Load(object sender, EventArgs e)
        {

        }

        private void radButton2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            if (textBox1.Text != string.Empty)
            {
                List<decision> lstusr = null;
                DBpoliceEntities dbpfen = new DBpoliceEntities();
               
             //   dataGridView1.Rows.Clear();
                int var = Convert.ToInt32(textBox1.Text.ToString());
                lstusr = dbpfen.decision.Where(x => x.idpolicier == var).ToList();
              


                if (lstusr.Count() != 0)
                {
                    for (int i = 0; i < lstusr.Count(); i++)
                    {
                     
                       DateTime dat =Convert.ToDateTime( lstusr[i].datedec.Value.Date);
                        //string type = lstusr[i].Type_direction.ToString();
                        string dat1 = Convert.ToString(dat.ToShortDateString());
                        string id = lstusr[i].idpolicier.ToString();
                        string doc = lstusr[i].numdec;
                        string doc1 = Convert.ToString(doc);
                        string d = lstusr[i].comment;
                        string[] row1 = new string[] {
                            id,
                       dat1,
                       doc,
                            d
                       
                     
                         
                        };

                        dataGridView1.Rows.Add(row1);
                     
                   
                    }


                }
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                ConnectionString cs = new ConnectionString();
                SqlConnection cn = new SqlConnection(cs.DBConn());

                //open
                     cn.Open();
            // 0 is the column index
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    // 0 is the column index

                    string var = ""+selectedRow.Cells["Column5"].Value;

               
               
                    string commandText = "select document from decision where numdec='" + var + "'";

                    //Create a oleDbCommand
                    SqlCommand command = new SqlCommand(commandText, cn);

                    // Create the data adapter.
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    //Create a new data table
                    DataTable dataTable = new DataTable();

                    //Fill the data table
                    adapter.Fill(dataTable);
                    if (dataTable.Rows.Count > 0)
                    {
                        //Do your stuff here.

                        //Retrive the PDF file from the data table
                        byte[] buffer = (byte[])dataTable.Rows[0]["document"];

                        //Save the PDF file
                        using (FileStream fstream = new FileStream("fichierDecision.pdf", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                        {
                            fstream.Write(buffer, 0, buffer.Length);
                        }
                        //This will open the PDF file so, the result will be seen in default PDF viewer 
                        Process.Start("fichierDecision.pdf");
                    }}
                
            if (e.ColumnIndex == 5)
            {
                PopupForm popup = new PopupForm();
                DialogResult dialogresult = popup.ShowDialog();
                if (dialogresult == DialogResult.OK)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    string var = "" + selectedRow.Cells["Column5"].Value;
                    string var2 = textBox1.Text;
                    ConnectionString cs = new ConnectionString();
                    SqlConnection cn = new SqlConnection(cs.DBConn());
                    string insertCmd = "delete from decision where numdec ='" + var + "' and idpolicier = "+var2+"";
                    cn.Open();
                    SqlCommand myCommand = new SqlCommand(insertCmd, cn);
                    myCommand.ExecuteNonQuery();
                    this.button1_Click(null, null);
                    cn.Close();
                    Console.WriteLine("You clicked OK");
                }
                else if (dialogresult == DialogResult.Cancel)
                {
                    Console.WriteLine("You clicked either Cancel or X button in the top right corner");
                }
                popup.Dispose();

            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            if (textBox2.Text != string.Empty)
            {
                List<congeAnnuel> lstusr = null;
                DBpoliceEntities dbpfen = new DBpoliceEntities();

                //   dataGridView1.Rows.Clear();
                int var = Convert.ToInt32(textBox2.Text.ToString());
                lstusr = dbpfen.congeAnnuel.Where(x => x.idpolicier == var).ToList();



                if (lstusr.Count() != 0)
                {
                    for (int i = 0; i < lstusr.Count(); i++)
                    {

                        DateTime dat = Convert.ToDateTime(lstusr[i].dated.Value.Date);
                        //string type = lstusr[i].Type_direction.ToString();
                        string dat1 = Convert.ToString(dat.ToShortDateString());
                        DateTime dat2 = Convert.ToDateTime(lstusr[i].datef.Value.Date);
                        //string type = lstusr[i].Type_direction.ToString();
                        string dat3 = Convert.ToString(dat2.ToShortDateString());
                        string id = lstusr[i].id.ToString();
                     
                   
                        string d = lstusr[i].duree.ToString();
                        string[] row1 = new string[] {
                            id,
                       dat1,
                      dat3,
                            d



                        };

                        dataGridView2.Rows.Add(row1);


                    }


                }
            }



        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }
        private void buttonDivers_Click(object sender, EventArgs e)
        {
            dataGridView7.DataSource = null;
            dataGridView7.Rows.Clear();
            if (textBox7.Text != string.Empty)
            {
                List<divers> lstusr = null;
                DBpoliceEntities dbpfen = new DBpoliceEntities();
                //   dataGridView1.Rows.Clear();
                int var = Convert.ToInt32(textBox7.Text.ToString());
                lstusr = dbpfen.divers.Where(x => x.idpolicier == var).ToList();
                if (lstusr.Count() != 0)
                {
                    for (int i = 0; i < lstusr.Count(); i++)
                    {
                        string id = lstusr[i].id.ToString();
                        //string notation = lstusr[i].notation.ToString();
                        string comment = lstusr[i].comment.ToString();

                        string[] row1 = new string[] { id, comment };
                        dataGridView7.Rows.Add(row1);
                    }
                }
            }
        }

        private void buttonNotation_Click(object sender, EventArgs e)
        {
            dataGridView6.DataSource = null;
            dataGridView6.Rows.Clear();
            if (textBox6.Text != string.Empty)
            {
                List<notation> lstusr = null;
                DBpoliceEntities dbpfen = new DBpoliceEntities();
                //   dataGridView1.Rows.Clear();
                int var = Convert.ToInt32(textBox6.Text.ToString());
                lstusr = dbpfen.notation.Where(x => x.idpolicier == var).ToList();
                if (lstusr.Count() != 0)
                {
                    for (int i = 0; i < lstusr.Count(); i++)
                    {
                        string id = lstusr[i].id.ToString();
                        string notation = lstusr[i].notationAnnuelle.ToString();
                        string comment = lstusr[i].comment.ToString();

                        string[] row1 = new string[] { id, notation };
                        dataGridView6.Rows.Add(row1);
                    }
                }
            }
        }

        private void buttonInstruction_Click(object sender, EventArgs e)
        {
            dataGridView5.DataSource = null;
            dataGridView5.Rows.Clear();
            if (textBox5.Text != string.Empty)
            {
                List<instruction> lstusr = null;
                DBpoliceEntities dbpfen = new DBpoliceEntities();
                //   dataGridView1.Rows.Clear();
                int var = Convert.ToInt32(textBox5.Text.ToString());
                lstusr = dbpfen.instruction.Where(x => x.idpolicier == var).ToList();
                if (lstusr.Count() != 0)
                {
                    for (int i = 0; i < lstusr.Count(); i++)
                    {
                        string id = lstusr[i].id.ToString();
                        //string type = lstusr[i].etatSolde.ToString();
                        string comment = lstusr[i].comment.ToString();

                        string[] row1 = new string[] { id, comment };
                        dataGridView5.Rows.Add(row1);
                    }
                }
            }
        }

        private void buttonFicheSolde_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = null;
            dataGridView4.Rows.Clear();
            if (textBox4.Text != string.Empty)
            {
                List<ficheSolde> lstusr = null;
                DBpoliceEntities dbpfen = new DBpoliceEntities();
                //   dataGridView1.Rows.Clear();
                int var = Convert.ToInt32(textBox4.Text.ToString());
                lstusr = dbpfen.ficheSolde.Where(x => x.idpolicier == var).ToList();
                if (lstusr.Count() != 0)
                {
                    for (int i = 0; i < lstusr.Count(); i++)
                    {
                        string id = lstusr[i].id.ToString();
                        string solde = lstusr[i].etatsolde;
                        string comment = lstusr[i].comment.ToString();

                        string[] row1 = new string[] { id, solde,comment };
                        dataGridView4.Rows.Add(row1);
                    }
                }
            }
        }

        private void buttonPunition_Click(object sender, EventArgs e)
        {
            dataGridViewPunition.DataSource = null;
            dataGridViewPunition.Rows.Clear();
            if (textBoxPunition.Text != string.Empty)
            {
                List<punition> lstusr = null;
                DBpoliceEntities dbpfen = new DBpoliceEntities();
                //   dataGridView1.Rows.Clear();
                int var = Convert.ToInt32(textBoxPunition.Text.ToString());
                lstusr = dbpfen.punition.Where(x => x.idpolicier == var).ToList();
                if (lstusr.Count() != 0)
                {
                    for (int i = 0; i < lstusr.Count(); i++)
                    {
                        DateTime dat = Convert.ToDateTime(lstusr[i].datefait.Value.Date);
                        //string type = lstusr[i].Type_direction.ToString();
                        string dat1 = Convert.ToString(dat.ToShortDateString());
                        string id = lstusr[i].id.ToString();
                        string type = lstusr[i].Type_sanction.libelle.ToString();
                        //string motif = lstusr[i].motif.ToString();
                        string comment = lstusr[i].comment.ToString();

                        string[] row1 = new string[] { id, dat1, type, comment};
                        dataGridViewPunition.Rows.Add(row1);
                    }
                }
            }
        }

        private void buttonAffectation_Click(object sender, EventArgs e)
        {
            dataGridViewAffectation.DataSource = null;
            dataGridViewAffectation.Rows.Clear();
            if (textBoxAffectation.Text != string.Empty)
            {
                List<Affectation> lstusr = null;
                DBpoliceEntities dbpfen = new DBpoliceEntities();
                //   dataGridView1.Rows.Clear();
                int var = Convert.ToInt32(textBoxAffectation.Text.ToString());
                lstusr = dbpfen.affectation.Where(x => x.idpolicier == var).ToList();
                if (lstusr.Count() != 0)
                {
                    for (int i = 0; i < lstusr.Count(); i++)
                    {
                        string id = lstusr[i].id.ToString();
                        string num = lstusr[i].numNs.ToString();
                        string comment = lstusr[i].comment.ToString();
                        DateTime dat2 = Convert.ToDateTime(lstusr[i].dateA.Value.Date);
                        string dat3 = Convert.ToString(dat2.ToShortDateString());
                        string[] row1 = new string[] { id, dat3,num, comment };
                        dataGridViewAffectation.Rows.Add(row1);
                    }
                }
            }
        }

        private void buttonCongeMaladie_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = null;
            dataGridView3.Rows.Clear();
            if (textBox3.Text != string.Empty)
            {
                List<congeMaladie> lstusr = null;
                DBpoliceEntities dbpfen = new DBpoliceEntities();
                //   dataGridView1.Rows.Clear();
                int var = Convert.ToInt32(textBox3.Text.ToString());
                lstusr = dbpfen.congeMaladie.Where(x => x.idpolicier == var).ToList();
                if (lstusr.Count() != 0)
                {
                    for (int i = 0; i < lstusr.Count(); i++)
                    {
                        string id = lstusr[i].id.ToString();
                        string duree = lstusr[i].duree.ToString();
                        string comment = lstusr[i].comment;
                        DateTime dat = Convert.ToDateTime(lstusr[i].dated.Value.Date);
                        string datDebut = Convert.ToString(dat.ToShortDateString());
                        DateTime dat2 = Convert.ToDateTime(lstusr[i].datef.Value.Date);
                        string datFin = Convert.ToString(dat2.ToShortDateString());
                        string[] row1 = new string[] { id, datDebut, datFin, duree,comment };
                        dataGridView3.Rows.Add(row1);
                    }
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                ConnectionString cs = new ConnectionString();
                SqlConnection cn = new SqlConnection(cs.DBConn());

                //open
                cn.Open();
                int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex];
                // 0 is the column index
            
                int var = Convert.ToInt32(selectedRow.Cells["dataGridViewTextBoxColumn1"].Value);

                string commandText = "select document from View_congeAnn where id='" + var + "'";

                //Create a oleDbCommand
                SqlCommand command = new SqlCommand(commandText, cn);

                // Create the data adapter.
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                //Create a new data table
                DataTable dataTable = new DataTable();

                //Fill the data table
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    //Do your stuff here.

                    //Retrive the PDF file from the data table
                    byte[] buffer = (byte[])dataTable.Rows[0]["document"];

                    //Save the PDF file
                    using (FileStream fstream = new FileStream("fichierconge.pdf", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        fstream.Write(buffer, 0, buffer.Length);
                    }
                    //This will open the PDF file so, the result will be seen in default PDF viewer 
                    Process.Start("fichierconge.pdf");
                }
            }
            if (e.ColumnIndex == 5)
            {
                PopupForm popup = new PopupForm();
                DialogResult dialogresult = popup.ShowDialog();
                if (dialogresult == DialogResult.OK)
                {
                    int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex];
                    int var = Convert.ToInt32(selectedRow.Cells["dataGridViewTextBoxColumn1"].Value);
                    ConnectionString cs = new ConnectionString();
                    SqlConnection cn = new SqlConnection(cs.DBConn());
                    string insertCmd = "delete from congeAnnuel where id ='" + var + "'";
                    cn.Open();
                    SqlCommand myCommand = new SqlCommand(insertCmd, cn);
                    myCommand.ExecuteNonQuery();
                    this.button2_Click_1(null, null);
                    cn.Close();
                    Console.WriteLine("You clicked OK");
                }
                else if (dialogresult == DialogResult.Cancel)
                {
                    Console.WriteLine("You clicked either Cancel or X button in the top right corner");
                }
                popup.Dispose();
               

            }




        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewCongeMaladie_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                ConnectionString cs = new ConnectionString();
                SqlConnection cn = new SqlConnection(cs.DBConn());

                //open
                cn.Open();
                int selectedrowindex = dataGridView3.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView3.Rows[selectedrowindex];
                // 0 is the column index

                int var = Convert.ToInt32(selectedRow.Cells["dataGridViewTextBoxColumn5"].Value);

                string commandText = "select document from View_congeMal where id='" + var + "'";

                //Create a oleDbCommand
                SqlCommand command = new SqlCommand(commandText, cn);

                // Create the data adapter.
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                //Create a new data table
                DataTable dataTable = new DataTable();

                //Fill the data table
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    //Do your stuff here.

                    //Retrive the PDF file from the data table
                    byte[] buffer = (byte[])dataTable.Rows[0]["document"];

                    //Save the PDF file
                    using (FileStream fstream = new FileStream("fichiercongemaladie.pdf", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        fstream.Write(buffer, 0, buffer.Length);
                    }
                    //This will open the PDF file so, the result will be seen in default PDF viewer 
                    Process.Start("fichiercongemaladie.pdf");
                }
            }
            if (e.ColumnIndex == 6)
            {
                PopupForm popup = new PopupForm();
                DialogResult dialogresult = popup.ShowDialog();
                if (dialogresult == DialogResult.OK)
                {

                    int selectedrowindex = dataGridView3.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView3.Rows[selectedrowindex];
                    int var = Convert.ToInt32(selectedRow.Cells["dataGridViewTextBoxColumn5"].Value);
                    ConnectionString cs = new ConnectionString();
                    SqlConnection cn = new SqlConnection(cs.DBConn());
                    string insertCmd = "delete from congeMaladie where id ='" + var + "'";
                    cn.Open();
                    SqlCommand myCommand = new SqlCommand(insertCmd, cn);
                    myCommand.ExecuteNonQuery();
                    this.buttonCongeMaladie_Click(null, null);
                    cn.Close();

                    Console.WriteLine("You clicked OK");
                }
                else if (dialogresult == DialogResult.Cancel)
                {
                    Console.WriteLine("You clicked either Cancel or X button in the top right corner");
                }
                popup.Dispose();
              
            }
        }

        private void dataGridViewAffectation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                ConnectionString cs = new ConnectionString();
                SqlConnection cn = new SqlConnection(cs.DBConn());

                //open
                cn.Open();
                int selectedrowindex = dataGridViewAffectation.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridViewAffectation.Rows[selectedrowindex];
                // 0 is the column index

                int var = Convert.ToInt32(selectedRow.Cells["ColumnAffectation1"].Value);

                string commandText = "select document from View_affetc where id='" + var + "'";

                //Create a oleDbCommand
                SqlCommand command = new SqlCommand(commandText, cn);

                // Create the data adapter.
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                //Create a new data table
                DataTable dataTable = new DataTable();

                //Fill the data table
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    //Do your stuff here.

                    //Retrive the PDF file from the data table
                    byte[] buffer = (byte[])dataTable.Rows[0]["document"];

                    //Save the PDF file
                    using (FileStream fstream = new FileStream("fichierAffectation.pdf", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        fstream.Write(buffer, 0, buffer.Length);
                    }
                    //This will open the PDF file so, the result will be seen in default PDF viewer 
                    Process.Start("fichierAffectation.pdf");
                }
            }
            if (e.ColumnIndex == 5)
            {
                PopupForm popup = new PopupForm();
                DialogResult dialogresult = popup.ShowDialog();
                if (dialogresult == DialogResult.OK)
                {
                    int selectedrowindex = dataGridViewAffectation.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridViewAffectation.Rows[selectedrowindex];
                    int var = Convert.ToInt32(selectedRow.Cells["ColumnAffectation1"].Value);
                    ConnectionString cs = new ConnectionString();
                    SqlConnection cn = new SqlConnection(cs.DBConn());
                    string insertCmd = "delete from affectation where id ='" + var + "'";
                    cn.Open();
                    SqlCommand myCommand = new SqlCommand(insertCmd, cn);
                    myCommand.ExecuteNonQuery();
                    this.buttonAffectation_Click(null, null);
                    cn.Close();

                    Console.WriteLine("You clicked OK");
                }
                else if (dialogresult == DialogResult.Cancel)
                {
                    Console.WriteLine("You clicked either Cancel or X button in the top right corner");
                }
                popup.Dispose();
               

            }
        }

        private void dataGridViewPunition_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                ConnectionString cs = new ConnectionString();
                SqlConnection cn = new SqlConnection(cs.DBConn());

                //open
                cn.Open();
                int selectedrowindex = dataGridViewPunition.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridViewPunition.Rows[selectedrowindex];
                // 0 is the column index

                int var = Convert.ToInt32(selectedRow.Cells["ColumnPunition1"].Value);

                string commandText = "select document from View_punition where id='" + var + "'";

                //Create a oleDbCommand
                SqlCommand command = new SqlCommand(commandText, cn);

                // Create the data adapter.
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                //Create a new data table
                DataTable dataTable = new DataTable();

                //Fill the data table
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    //Do your stuff here.

                    //Retrive the PDF file from the data table
                    byte[] buffer = (byte[])dataTable.Rows[0]["document"];

                    //Save the PDF file
                    using (FileStream fstream = new FileStream("fichierPunition.pdf", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        fstream.Write(buffer, 0, buffer.Length);
                    }
                    //This will open the PDF file so, the result will be seen in default PDF viewer 
                    Process.Start("fichierPunition.pdf");
                }
            }
            if (e.ColumnIndex == 5)
            {
                PopupForm popup = new PopupForm();
                DialogResult dialogresult = popup.ShowDialog();
                if (dialogresult == DialogResult.OK)
                {
                    int selectedrowindex = dataGridViewPunition.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridViewPunition.Rows[selectedrowindex];
                    int var = Convert.ToInt32(selectedRow.Cells["ColumnPunition1"].Value);
                    ConnectionString cs = new ConnectionString();
                    SqlConnection cn = new SqlConnection(cs.DBConn());
                    string insertCmd = "delete from punition where id ='" + var + "'";
                    cn.Open();
                    SqlCommand myCommand = new SqlCommand(insertCmd, cn);
                    myCommand.ExecuteNonQuery();
                    this.buttonPunition_Click(null, null);
                    cn.Close();

                    Console.WriteLine("You clicked OK");
                }
                else if (dialogresult == DialogResult.Cancel)
                {
                    Console.WriteLine("You clicked either Cancel or X button in the top right corner");
                }
                popup.Dispose();
              

            }
        }

        private void dataGridViewFicheSolde_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                ConnectionString cs = new ConnectionString();
                SqlConnection cn = new SqlConnection(cs.DBConn());

                //open
                cn.Open();
                int selectedrowindex = dataGridView4.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView4.Rows[selectedrowindex];
                // 0 is the column index

                int var = Convert.ToInt32(selectedRow.Cells["dataGridViewTextBoxColumn9"].Value);

                string commandText = "select document from View_ficheSolde where id='" + var + "'";

                //Create a oleDbCommand
                SqlCommand command = new SqlCommand(commandText, cn);

                // Create the data adapter.
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                //Create a new data table
                DataTable dataTable = new DataTable();

                //Fill the data table
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    //Do your stuff here.

                    //Retrive the PDF file from the data table
                    byte[] buffer = (byte[])dataTable.Rows[0]["document"];

                    //Save the PDF file
                    using (FileStream fstream = new FileStream("fichierFicheSolde.pdf", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        fstream.Write(buffer, 0, buffer.Length);
                    }
                    //This will open the PDF file so, the result will be seen in default PDF viewer 
                    Process.Start("fichierFicheSolde.pdf");
                }
            }
            if (e.ColumnIndex == 4)
            {
                PopupForm popup = new PopupForm();
                DialogResult dialogresult = popup.ShowDialog();
                if (dialogresult == DialogResult.OK)
                {
                    int selectedrowindex = dataGridView4.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView4.Rows[selectedrowindex];
                    int var = Convert.ToInt32(selectedRow.Cells["dataGridViewTextBoxColumn9"].Value);
                    ConnectionString cs = new ConnectionString();
                    SqlConnection cn = new SqlConnection(cs.DBConn());
                    string insertCmd = "delete from ficheSolde where id ='" + var + "'";
                    cn.Open();
                    SqlCommand myCommand = new SqlCommand(insertCmd, cn);
                    myCommand.ExecuteNonQuery();
                    this.buttonFicheSolde_Click(null, null);
                    cn.Close();

                    Console.WriteLine("You clicked OK");
                }
                else if (dialogresult == DialogResult.Cancel)
                {
                    Console.WriteLine("You clicked either Cancel or X button in the top right corner");
                }
                popup.Dispose();
               

            }
        }

        private void dataGridViewInstruction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                ConnectionString cs = new ConnectionString();
                SqlConnection cn = new SqlConnection(cs.DBConn());

                //open
                cn.Open();
                int selectedrowindex = dataGridView5.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView5.Rows[selectedrowindex];
                // 0 is the column index

                int var = Convert.ToInt32(selectedRow.Cells["dataGridViewTextBoxColumn10"].Value);

                string commandText = "select document from View_instruction where id='" + var + "'";

                //Create a oleDbCommand
                SqlCommand command = new SqlCommand(commandText, cn);

                // Create the data adapter.
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                //Create a new data table
                DataTable dataTable = new DataTable();

                //Fill the data table
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    //Do your stuff here.

                    //Retrive the PDF file from the data table
                    byte[] buffer = (byte[])dataTable.Rows[0]["document"];

                    //Save the PDF file
                    using (FileStream fstream = new FileStream("fichierInstruction.pdf", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        fstream.Write(buffer, 0, buffer.Length);
                    }
                    //This will open the PDF file so, the result will be seen in default PDF viewer 
                    Process.Start("fichierInstruction.pdf");
                }
            }
            if (e.ColumnIndex == 3)
            {
                PopupForm popup = new PopupForm();
                DialogResult dialogresult = popup.ShowDialog();
                if (dialogresult == DialogResult.OK)
                {
                    int selectedrowindex = dataGridView5.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView5.Rows[selectedrowindex];
                    int var = Convert.ToInt32(selectedRow.Cells["dataGridViewTextBoxColumn10"].Value);
                    ConnectionString cs = new ConnectionString();
                    SqlConnection cn = new SqlConnection(cs.DBConn());
                    string insertCmd = "delete from instruction where id ='" + var + "'";
                    cn.Open();
                    SqlCommand myCommand = new SqlCommand(insertCmd, cn);
                    myCommand.ExecuteNonQuery();
                    this.buttonInstruction_Click(null, null);
                    cn.Close();

                    Console.WriteLine("You clicked OK");
                }
                else if (dialogresult == DialogResult.Cancel)
                {
                    Console.WriteLine("You clicked either Cancel or X button in the top right corner");
                }
                popup.Dispose();
               
               

            }
        }

        private void dataGridViewNotation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                ConnectionString cs = new ConnectionString();
                SqlConnection cn = new SqlConnection(cs.DBConn());

                //open
                cn.Open();
                int selectedrowindex = dataGridView6.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView6.Rows[selectedrowindex];
                // 0 is the column index

                int var = Convert.ToInt32(selectedRow.Cells["dataGridViewTextBoxColumn13"].Value);

                string commandText = "select document from View_notation where id='" + var + "'";

                //Create a oleDbCommand
                SqlCommand command = new SqlCommand(commandText, cn);

                // Create the data adapter.
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                //Create a new data table
                DataTable dataTable = new DataTable();

                //Fill the data table
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    //Do your stuff here.

                    //Retrive the PDF file from the data table
                    byte[] buffer = (byte[])dataTable.Rows[0]["document"];

                    //Save the PDF file
                    using (FileStream fstream = new FileStream("fichierNotation.pdf", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        fstream.Write(buffer, 0, buffer.Length);
                    }
                    //This will open the PDF file so, the result will be seen in default PDF viewer 
                    Process.Start("fichierNotation.pdf");
                }
            }
            if (e.ColumnIndex == 3)
            {
                PopupForm popup = new PopupForm();
                DialogResult dialogresult = popup.ShowDialog();
                if (dialogresult == DialogResult.OK)
                {
                    int selectedrowindex = dataGridView6.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView6.Rows[selectedrowindex];
                    int var = Convert.ToInt32(selectedRow.Cells["dataGridViewTextBoxColumn13"].Value);
                    ConnectionString cs = new ConnectionString();
                    SqlConnection cn = new SqlConnection(cs.DBConn());
                    string insertCmd = "delete from notation where id ='" + var + "'";
                    cn.Open();
                    SqlCommand myCommand = new SqlCommand(insertCmd, cn);
                    myCommand.ExecuteNonQuery();
                    this.buttonNotation_Click(null, null);
                    cn.Close();


                    Console.WriteLine("You clicked OK");
                }
                else if (dialogresult == DialogResult.Cancel)
                {
                    Console.WriteLine("You clicked either Cancel or X button in the top right corner");
                }
                popup.Dispose();
              
            }
        }

        private void dataGridViewDivers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                ConnectionString cs = new ConnectionString();
                SqlConnection cn = new SqlConnection(cs.DBConn());

                //open
                cn.Open();
                int selectedrowindex = dataGridView7.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView7.Rows[selectedrowindex];
                // 0 is the column index

                int var = Convert.ToInt32(selectedRow.Cells["dataGridViewTextBoxColumn16"].Value);

                string commandText = "select document from View_divers where id='" + var + "'";

                //Create a oleDbCommand
                SqlCommand command = new SqlCommand(commandText, cn);

                // Create the data adapter.
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                //Create a new data table
                DataTable dataTable = new DataTable();

                //Fill the data table
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    //Do your stuff here.

                    //Retrive the PDF file from the data table
                    byte[] buffer = (byte[])dataTable.Rows[0]["document"];

                    //Save the PDF file
                    using (FileStream fstream = new FileStream("fichierDivers.pdf", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        fstream.Write(buffer, 0, buffer.Length);
                    }
                    //This will open the PDF file so, the result will be seen in default PDF viewer 
                    Process.Start("fichierDivers.pdf");
                }
            }
            if (e.ColumnIndex == 3)
            {
                PopupForm popup = new PopupForm();
                DialogResult dialogresult = popup.ShowDialog();
                if (dialogresult == DialogResult.OK)
                {
                    int selectedrowindex = dataGridView7.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView7.Rows[selectedrowindex];
                    int var = Convert.ToInt32(selectedRow.Cells["dataGridViewTextBoxColumn16"].Value);
                    ConnectionString cs = new ConnectionString();
                    SqlConnection cn = new SqlConnection(cs.DBConn());
                    string insertCmd = "delete from divers where id ='" + var + "'";
                    cn.Open();
                    SqlCommand myCommand = new SqlCommand(insertCmd, cn);
                    myCommand.ExecuteNonQuery();
                    this.buttonDivers_Click(null, null);
                    cn.Close();


                    Console.WriteLine("You clicked OK");
                }
                else if (dialogresult == DialogResult.Cancel)
                {
                    Console.WriteLine("You clicked either Cancel or X button in the top right corner");
                }
                popup.Dispose();
              
              
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView8.DataSource = null;
            dataGridView8.Rows.Clear();
            if (textBox8.Text != string.Empty)
            {
                List<etatCivil> lstusr = null;
                DBpoliceEntities dbpfen = new DBpoliceEntities();
                lstusr = dbpfen.etatCivil.ToList();
                int var = Convert.ToInt32(textBox8.Text.ToString());
                lstusr = dbpfen.etatCivil.Where(x => x.idpolicier == var).ToList();
                if (lstusr.Count() != 0)
                {
                    for (int i = 0; i < lstusr.Count(); i++)
                    {
                        string id = lstusr[i].id.ToString();
                        string comment = lstusr[i].comment.ToString();
                        string[] row1 = new string[] { id, comment };
                        dataGridView8.Rows.Add(row1);
                    }
                }
            }
        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                ConnectionString cs = new ConnectionString();
                SqlConnection cn = new SqlConnection(cs.DBConn());

                //open
                cn.Open();
                int selectedrowindex = dataGridView8.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dataGridView8.Rows[selectedrowindex];
                // 0 is the column index

                int var = Convert.ToInt32(selectedRow.Cells["dataGridViewTextBoxColumn18"].Value);

                string commandText = "select document from View_etatCivil where id='" + var + "'";

                //Create a oleDbCommand
                SqlCommand command = new SqlCommand(commandText, cn);

                // Create the data adapter.
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                //Create a new data table
                DataTable dataTable = new DataTable();

                //Fill the data table
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    //Do your stuff here.

                    //Retrive the PDF file from the data table
                    byte[] buffer = (byte[])dataTable.Rows[0]["document"];

                    //Save the PDF file
                    using (FileStream fstream = new FileStream("fichierEtatCivil.pdf", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        fstream.Write(buffer, 0, buffer.Length);
                    }
                    //This will open the PDF file so, the result will be seen in default PDF viewer 
                    Process.Start("fichierEtatCivil.pdf");
                }
            }
            if (e.ColumnIndex == 3)
            {
                PopupForm popup = new PopupForm();
                DialogResult dialogresult = popup.ShowDialog();
                if (dialogresult == DialogResult.OK)
                {
                    int selectedrowindex = dataGridView8.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView8.Rows[selectedrowindex];
                    int var = Convert.ToInt32(selectedRow.Cells["dataGridViewTextBoxColumn18"].Value);
                    ConnectionString cs = new ConnectionString();
                    SqlConnection cn = new SqlConnection(cs.DBConn());
                    string insertCmd = "delete from etatCivil where id ='" + var + "'";
                    cn.Open();
                    SqlCommand myCommand = new SqlCommand(insertCmd, cn);
                    myCommand.ExecuteNonQuery();
                    this.button9_Click(null, null);
                    cn.Close();
                    Console.WriteLine("You clicked OK");
                }
                else if (dialogresult == DialogResult.Cancel)
                {
                    Console.WriteLine("You clicked either Cancel or X button in the top right corner");
                }
                popup.Dispose();
               
            }
        }
        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (metroTabControl1.SelectedTab == metroTabControl1.TabPages["metroTabPage1"])
                {
                    this.button1_Click(null,null);
                }
                else if (metroTabControl1.SelectedTab == metroTabControl1.TabPages["metroTabPage6"])
                {
                    this.buttonPunition_Click(null, null);
                }
                else if (metroTabControl1.SelectedTab == metroTabControl1.TabPages["metroTabPage4"])
                {
                    this.buttonCongeMaladie_Click(null, null);
                }
                else if (metroTabControl1.SelectedTab == metroTabControl1.TabPages["metroTabPage3"])
                {
                    this.button2_Click_1(null, null);
                }
                else if (metroTabControl1.SelectedTab == metroTabControl1.TabPages["metroTabPage2"])
                {
                    this.buttonAffectation_Click(null, null);
                }
                else if (metroTabControl1.SelectedTab == metroTabControl1.TabPages["metroTabPageFicheSolde"])
                {
                    this.buttonFicheSolde_Click(null, null);
                }
                else if (metroTabControl1.SelectedTab == metroTabControl1.TabPages["metroTabPage5"])
                {
                    this.buttonInstruction_Click(null, null);
                }
                else if (metroTabControl1.SelectedTab == metroTabControl1.TabPages["metroTabPage7"])
                {
                    this.buttonNotation_Click(null, null);
                }else
                {
                    this.buttonDivers_Click(null, null);
                }
            }
        }
        }
}
