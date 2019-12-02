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
    public partial class DeleteAttribute : Form
    {
        // Variables.
        DataTable dataSet;
        DataFile dataSetDataFile;

        public DeleteAttribute(DataTable newDataSet, DataFile newDataSetDataFile)
        {
            InitializeComponent();

            dataSet = newDataSet;
            dataSetDataFile = newDataSetDataFile;
            List<string> attributes = new List<string>();

            for (int i = 0; i < dataSet.Columns.Count; i++)
            {
                attributes.Add(dataSet.Columns[i].Caption);
            }

            ListBoxAttributes.DataSource = attributes;
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            dataSet.Columns.RemoveAt(ListBoxAttributes.SelectedIndex);

            if (dataSet.Columns.Count == 0)
            {
                dataSet.Rows.Clear();

                if (dataSetDataFile != null)
                {
                    dataSetDataFile.Attributes.Clear();
                    dataSetDataFile.Data.Clear();
                }
            }
            else
            {
                if (dataSetDataFile != null)
                {
                    List<string> instance;

                    dataSetDataFile.Attributes.RemoveAt(ListBoxAttributes.SelectedIndex);

                    for (int i = 0; i < dataSetDataFile.Data.Count; i++)
                    {
                        instance = dataSetDataFile.Data[i].ToList();

                        instance.RemoveAt(ListBoxAttributes.SelectedIndex);

                        dataSetDataFile.Data[i] = instance;
                    }
                }
            }

            DialogResult = DialogResult.OK;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
