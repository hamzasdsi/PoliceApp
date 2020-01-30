using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
namespace PoliceApp
{
    public partial class docmn : MetroFramework.Forms.MetroForm
    {
        public docmn()
        {
            InitializeComponent();
        }
        DBpoliceEntities dbpfen = new DBpoliceEntities();
        ReportDocument cryRpt = new ReportDocument();
        private void docmn_Load(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "libelle";
            comboBox1.DataSource = dbpfen.typ_doc.ToList<typ_doc>();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                int n = Convert.ToInt32(textBox1.Text);

                var priv = (from emp in dbpfen.Policier
                            where emp.Matricule_ID == n
                            select emp.Nom_policier);
                textBox2.Text = priv.SingleOrDefault();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex==0)
            {


                TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                ConnectionInfo crConnectionInfo = new ConnectionInfo();
                Tables CrTables;

                cryRpt.Load(@"C:\PoliceApp\PoliceApp\AttesHeber.rpt");

                crConnectionInfo.ServerName = "DESKTOP-GITRNUG";
                crConnectionInfo.DatabaseName = "DBpolice";
                crConnectionInfo.UserID = "sa";
                crConnectionInfo.Password = "sdsi*2017";

                CrTables = cryRpt.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }
                int n = Convert.ToInt32(textBox1.Text);
                var query = from emp in dbpfen.Policier
                            where emp.Matricule_ID == n
                            select new { emp.Grad.Libelle };

                TextObject TO = (TextObject)cryRpt.ReportDefinition.Sections["Section1"].ReportObjects["Text5"];
                TO.Text = query.Single().Libelle.ToString() + ",";

                TextObject TO1 = (TextObject)cryRpt.ReportDefinition.Sections["Section1"].ReportObjects["Text7"];
                TO1.Text = textBox2.Text.ToUpper() + ",";
                TextObject TO2 = (TextObject)cryRpt.ReportDefinition.Sections["Section1"].ReportObjects["Text9"];
                TO2.Text = textBox1.Text;
                crystalReportViewer1.ReportSource = cryRpt;
                crystalReportViewer1.Refresh();
             
            }
        }
    }
}
