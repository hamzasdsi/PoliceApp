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
    public partial class lisConge : MetroFramework.Forms.MetroForm
    {
        public lisConge()
        {
            InitializeComponent();
        }
DBpoliceEntities ent = new DBpoliceEntities();
        ReportDocument cryRpt = new ReportDocument();

        private void lisConge_Load(object sender, EventArgs e)
        {
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;

            cryRpt.Load(@"C:\Reporting\listeConge.rpt");

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

            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
            int d = DateTime.Now.Year;
            string d1= Convert.ToString(d);
            TextObject TO = (TextObject)cryRpt.ReportDefinition.Sections["Section1"].ReportObjects["Text21"];
            TO.Text = d1 ;

            TextObject TO1 = (TextObject)cryRpt.ReportDefinition.Sections["Section1"].ReportObjects["Text7"];
            TO1.Text = d1;

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
