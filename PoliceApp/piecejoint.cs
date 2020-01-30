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
    public partial class piecejoint : MetroFramework.Forms.MetroForm
    {
        public piecejoint()
        {
            InitializeComponent();
        }
        ReportDocument cryRpt = new ReportDocument();
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;

            cryRpt.Load(@"C:\Reportpolice\documents.rpt");

            crConnectionInfo.ServerName = "192.168.110.112";
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cryRpt.Load(@"C:\Reportpolice\documents.rpt");

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = textBox1.Text;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["Mat"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
        }
    }
}
