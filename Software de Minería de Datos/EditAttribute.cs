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
    public partial class EditAttribute : Form
    {
        // Variables.
        DataTable dataSet;
        DataFile dataSetDataFile;

        public EditAttribute(DataTable newDataSet, DataFile newDataSetDataFile)
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

            if (dataSetDataFile == null)
            {
                ComboBoxDataType.Enabled = false;

                TextBoxDomain.Text = "N/A";
                TextBoxDomain.Enabled = false;
            }
        }

        private void ListBoxAttributes_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAttributeInformation();
        }

        private void GetAttributeInformation()
        {
            TextBoxName.Text = ListBoxAttributes.SelectedValue.ToString();

            if (dataSetDataFile != null)
            {
                DataFileAttribute attribute = dataSetDataFile.Attributes.Find(DataFileAttribute => DataFileAttribute.Name == TextBoxName.Text);

                ComboBoxDataType.SelectedIndex = (int)attribute.GetDataTypeIndex();
                TextBoxDomain.Text = attribute.Domain.ToString();
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (TextBoxName.Text == "")
            {
                MessageBox.Show("El nombre del atributo se encuentra vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dataSet.Columns[ListBoxAttributes.SelectedIndex].Caption = TextBoxName.Text;
            dataSet.Columns[ListBoxAttributes.SelectedIndex].ColumnName = TextBoxName.Text;

            if (dataSetDataFile != null)
            {
                try
                {
                    dataSetDataFile.Attributes[ListBoxAttributes.SelectedIndex].Edit(TextBoxName.Text, ComboBoxDataType.SelectedIndex, TextBoxDomain.Text);
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("El dominio (expresión regular) es inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
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
