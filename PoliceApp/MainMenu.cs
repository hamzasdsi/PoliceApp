using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Data.SqlClient;

namespace PoliceApp
{
    public partial class MainMenu : MetroFramework.Forms.MetroForm
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
          
        }

        private void nouveauPolicierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AjoutPolicier frm = new AjoutPolicier();
            frm.ShowDialog();
        }

        private void modifierPolicierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPatient frm = new frmPatient();
            frm.ShowDialog();
        }

        private void nouveauDossierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dossierpro frm = new dossierpro();
            frm.ShowDialog();
        }

        private void resuméPolicierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resumepolicier frm = new resumepolicier();
            frm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void scanDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = @"C:\DotNETTWAINDemo\DotNETTWAINDemo\DotNETTWAINDemo.exe";
            Process process = new Process();
            process.StartInfo.FileName = str;
            process.Start();
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            viewdossier frm = new viewdossier();
            frm.ShowDialog();
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            ConnectionString cs = new ConnectionString();
            SqlConnection cn = new SqlConnection(cs.DBConn());
            string commandText = "select * from view_export";

            //Create a oleDbCommand
            SqlCommand command = new SqlCommand(commandText, cn);

            // Create the data adapter.
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            //Create a new data table
            DataTable table = new DataTable();

            //Fill the data table
            adapter.Fill(table);
            using (ExcelPackage packge = new ExcelPackage())
            {
                //Create the worksheet
                ExcelWorksheet ws = packge.Workbook.Worksheets.Add("Demo");

                //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1
                ws.Cells["A1"].LoadFromDataTable(table, true);

                //Format the header for column 1-3
                using (ExcelRange range = ws.Cells["A1:Z1"])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                    range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189)); //Set color to dark blue
                    range.Style.Font.Color.SetColor(Color.White);
                }
                ws.Column(3).Style.Numberformat.Format = "dd-mm-yyyy";
                ws.Column(9).Style.Numberformat.Format = "dd-mm-yyyy";
                ws.Column(10).Style.Numberformat.Format = "dd-mm-yyyy";
                ws.Cells.AutoFitColumns();
                /*
                //Example how to Format Column 1 as numeric 
                using (ExcelRange col = ws.Cells[2, 1, 2 + table.Rows.Count, 1])
                {
                    col.Style.Numberformat.Format = "#,##0.00";
                    col.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }
                */
                FileInfo file = new FileInfo(@"C:\PoliceApp\Export\export.xlsx");
                packge.SaveAs(file);
                /*
                //Write it back to the client
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=ExcelExport.xlsx");
                Response.BinaryWrite(packge.GetAsByteArray());*/
            }
        }
    }
    }

