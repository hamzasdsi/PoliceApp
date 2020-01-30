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
    public partial class stat : MetroFramework.Forms.MetroForm
    {
        public stat()
        {
            InitializeComponent();
        }
        ReportDocument cryRpt = new ReportDocument();
        private void metroTile1_Click(object sender, EventArgs e)
        {
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;

            cryRpt.Load(@"C:\Reportpolice\statMarie.rpt");

            crConnectionInfo.ServerName = "192.168.1.103";
            crConnectionInfo.DatabaseName = "DBpolice";
            crConnectionInfo.UserID = "sa";
            crConnectionInfo.Password = "sdsi*2018";

            CrTables = cryRpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }

            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh(); 

        }
    }
}
