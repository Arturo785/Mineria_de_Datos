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
    public partial class AddAttribute : Form
    {
        // Variables.
        DataTable dataSet;
        DataFile dataSetDataFile;

        public AddAttribute(DataTable newDataSet, DataFile newDataSetDataFile)
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
            else
            {
                // Desactivar las opciones innecesarias para una archivo CSV.
                ComboBoxDataType.Enabled = false;
                TextBoxDomain.Enabled = false;
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (TextBoxName.Text == "")
            {
                MessageBox.Show("El nombre del atributo se encuentra vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar si el tipo de archivo es CSV (null) o DATA.
            if (dataSetDataFile != null)
            {
                //Archivo DATA.

                if (ComboBoxDataType.SelectedIndex == -1)
                {
                    MessageBox.Show("El tipo de dato del atributo se encuentra vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (TextBoxDomain.Text == "")
                {
                    MessageBox.Show("El dominio (expresión regular) del atributo se encuentra vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Agregar nuevo atributo a la lista de atributos del archivo DATA.
                try
                {
                    dataSetDataFile.Attributes.Add(new DataFileAttribute(TextBoxName.Text, ComboBoxDataType.SelectedIndex, TextBoxDomain.Text));
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("El dominio (expresión regular) es inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Agregar ',' en cada instancia de la lista de data del archivo DATA.
                foreach (List<string> instance in dataSetDataFile.Data)
                {
                    instance.Add("");
                }
            }
            else
            {
                // Archivo CSV.

                if (TextBoxDefaultValue.Text == "")
                {
                    MessageBox.Show("El valor por defecto del atributo se encuentra vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Agregar a la DataTable la columna del nuevo atributo.
            DataColumn newAttribute = new DataColumn(TextBoxName.Text)
            {
                DefaultValue = TextBoxDefaultValue.Text
            };

            dataSet.Columns.Add(newAttribute);

            DialogResult = DialogResult.OK;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
