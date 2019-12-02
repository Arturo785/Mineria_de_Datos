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
    public partial class AddInstances : Form
    {
        // Variables.
        DataTable dataSet;
        DataFile dataSetDataFile;
        public int NumberOfInstancesAdded { get; set; }

        public AddInstances(DataTable newDataSet, DataFile newDataSetDataFile)
        {
            InitializeComponent();

            dataSet = newDataSet;
            dataSetDataFile = newDataSetDataFile;

            // Verificar si el tipo de archivo es CSV (null) o DATA.
            if (dataSetDataFile != null)
            {
                TextBoxDefaultValue.Text = dataSetDataFile.MissingValue;
                TextBoxDefaultValue.Enabled = false;
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (dataSetDataFile == null)
            {
                if (TextBoxDefaultValue.Text == "")
                {
                    MessageBox.Show("El valor por defecto del atributo se encuentra vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            List<string> instance = new List<string>();

            for (int i = 0; i < NumericUpDownNumberOfInstances.Value; i++)
            {
                for (int j = 0; j < dataSet.Columns.Count; j++)
                {
                    instance.Add(TextBoxDefaultValue.Text);
                }

                dataSet.Rows.Add(instance.ToArray());

                if (dataSetDataFile != null)
                {
                    List<string> dataFileInstance = new List<string>();

                    for (int j = 0; j < dataSet.Columns.Count; j++)
                    {
                        dataFileInstance.Add("");
                    }

                    dataSetDataFile.Data.Add(dataFileInstance);
                }

                instance.Clear();
            }

            NumberOfInstancesAdded = (int)NumericUpDownNumberOfInstances.Value;

            DialogResult = DialogResult.OK;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
