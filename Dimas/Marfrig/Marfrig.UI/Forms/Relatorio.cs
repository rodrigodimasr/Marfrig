using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Marfrig.UI.Forms
{
    public partial class Relatorio : Form
    {
        private readonly DataTable _dataTable;
        private readonly string valorTotal;
        public Relatorio(DataTable dataTable, string valorTotal)
        {
            
            InitializeComponent();
            _dataTable = dataTable;
            this.valorTotal = valorTotal;
        }

        private void Relatorio_Load(object sender, EventArgs e)
        {
            ReportParameterCollection reportParameters = new ReportParameterCollection {new ReportParameter("pTotal", valorTotal)};
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtCompradeGado", _dataTable));
            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();

             
        }
    }
}
