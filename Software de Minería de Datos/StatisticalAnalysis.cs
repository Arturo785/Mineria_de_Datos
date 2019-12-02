using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_de_Minería_de_Datos
{
    public partial class StatisticalAnalysis : Form
    {
        // Enum con los tipos de análisis.
        enum Analysis { Univariate, Bivariate }

        // Variables.
        DataTable dataSet;
        DataFile dataSetDataFile;
        UnivariateAnalysis univariateAnalysisForm;
        BivariateAnalysis bivariateAnalysisForm;

        public StatisticalAnalysis(DataTable newDataSet)
        {
            InitializeComponent();

            dataSet = newDataSet;

            // Inicializar Form "UnivariateAnalysis" en Tab Page "TabPageUnivariateAnalysis".
            univariateAnalysisForm = new UnivariateAnalysis(dataSet)
            {
                TopLevel = false,
                Visible = true,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            TabPageUnivariableAnalysis.Controls.Add(univariateAnalysisForm);

            // Inicializar Form "Bivariate" en Tab Page "TabPageBivariateAnalysis".
            bivariateAnalysisForm = new BivariateAnalysis(dataSet)
            {
                TopLevel = false,
                Visible = true,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            TabPageBivariateAnalysis.Controls.Add(bivariateAnalysisForm);
        }

        public void UpdateContent(DataFile newDataSetDataFile)
        {
            dataSetDataFile = newDataSetDataFile;

            UpdateTabPages();
        }

        private void UpdateTabPages()
        {
            switch ((Analysis)TabControlStatisticalAnalysis.SelectedIndex)
            {
                case Analysis.Univariate:
                    univariateAnalysisForm.UpdateContent(dataSetDataFile);
                    break;

                case Analysis.Bivariate:
                    bivariateAnalysisForm.UpdateContent(dataSetDataFile);
                    break;
            }
        }

        private void TabControlStatisticalAnalysis_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTabPages();
        }
    }
}
