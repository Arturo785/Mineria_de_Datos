using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Software_de_Minería_de_Datos
{
    public partial class MainForm : Form
    {
        // Enum con las pestañas del TabControl.
        enum Stage { DataEntry, StatisticalAnalysis, DataCleaning, MachineLearningAlgorithms }

        // Variables Globales.
        DataTable dataSet;

        // "Forms" de cada etapa.
        DataEntry dataEntryForm;
        StatisticalAnalysis statisticalAnalysisForm;
        DataCleaning dataCleaningForm;
        MachineLearningAlgorithms machineLearningAlgorithmsForm;

        public MainForm()
        {
            InitializeComponent();

            // Inicializar DataTable global.
            dataSet = new DataTable();

            // Inicializar Form "DataEntry" en Tab Page "TabPageDataEntry".
            dataEntryForm = new DataEntry(dataSet)
            {
                TopLevel = false,
                Visible = true,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            TabPageDataEntry.Controls.Add(dataEntryForm);

            // Inicializar Form "StatisticalAnalysis" en Tab Page "TabPageStatisticalAnalysis".
            statisticalAnalysisForm = new StatisticalAnalysis(dataSet)
            {
                TopLevel = false,
                Visible = true,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            TabPageStatisticalAnalysis.Controls.Add(statisticalAnalysisForm);

            // Inicializar Form "DataCleaning" en Tab Page "TabPageDataCleaning".
            dataCleaningForm = new DataCleaning(dataSet)
            {
                TopLevel = false,
                Visible = true,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            TabPageDataCleaning.Controls.Add(dataCleaningForm);

            // Inicializar Form "MachineLearningAlgorithms" en Tab Page "MachineLearningAlgorithms".
            machineLearningAlgorithmsForm = new MachineLearningAlgorithms(dataSet)
            {
                TopLevel = false,
                Visible = true,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            TabPageMachineLearningAlgorithms.Controls.Add(machineLearningAlgorithmsForm);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataEntryForm.ChangesMade || dataCleaningForm.AttributeCleaningForm.ChangesMade)
            {
                DialogResult saveChangesMade = MessageBox.Show("¿Desea guardar los cambios realizados en \"" + Path.GetFileName(dataEntryForm.OpenFileDialogDataSet.FileName) + "\"?", "Software de Minería de Datos", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                switch (saveChangesMade)
                {
                    case DialogResult.Yes:
                        dataEntryForm.SaveFile();
                        break;

                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void TabControlStages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataCleaningForm.AttributeCleaningForm.ChangesMade)
            {
                if (!dataEntryForm.ChangesMade)
                {
                    dataEntryForm.ChangesMade = true;
                }

                dataCleaningForm.AttributeCleaningForm.ChangesMade = false;
            }

            switch ((Stage)TabControlStages.SelectedIndex)
            {
                case Stage.DataEntry:
                    dataEntryForm.UpdateContent();
                    break;

                case Stage.StatisticalAnalysis:
                    statisticalAnalysisForm.UpdateContent(dataEntryForm.DataSetDataFile);
                    break;

                case Stage.DataCleaning:
                    dataCleaningForm.UpdateContent(dataEntryForm.DataSetDataFile);
                    break;

                case Stage.MachineLearningAlgorithms:
                    machineLearningAlgorithmsForm.UpdateContent(dataEntryForm.DataSetDataFile);
                    break;
            }
        }
    }
}
