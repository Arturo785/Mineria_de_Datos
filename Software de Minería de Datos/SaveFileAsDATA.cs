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
    public partial class SaveFileAsDATA : Form
    {
        // Enum con las posiciones de las columnas de los atributos.
        enum ColumnIndex { Number, Name, DataType, Domain }

        // Variables.
        DataTable dataSet;
        public DataFile DataSetDataFile { get; set; }

        public SaveFileAsDATA(DataTable newDataSet, DataFile newDataSetDataFile)
        {
            InitializeComponent();

            dataSet = newDataSet;
            DataSetDataFile = newDataSetDataFile;

            if (DataSetDataFile != null)
            {
                TextBoxGeneralInformation.Text = DataSetDataFile.GeneralInformation;
                TextBoxRelation.Text = DataSetDataFile.Relation;
                TextBoxMissingValue.Text = DataSetDataFile.MissingValue;
            }

            InitializeDataGridViewAttributes();
        }

        private void InitializeDataGridViewAttributes()
        {
            if (DataSetDataFile != null)
            {
                DataFileAttribute attribute;

                for (int i = 0; i < DataSetDataFile.Attributes.Count; i++)
                {
                    attribute = DataSetDataFile.Attributes[i];

                    switch (attribute.GetDataTypeIndex())
                    {
                        case DataFileAttribute.AttributeDataType.Nominal:
                            DataGridViewAttributes.Rows.Add(i + 1, attribute.Name, "Nominal", attribute.Domain);
                            break;

                        case DataFileAttribute.AttributeDataType.Ordinal:
                            DataGridViewAttributes.Rows.Add(i + 1, attribute.Name, "Ordinal", attribute.Domain);
                            break;

                        case DataFileAttribute.AttributeDataType.SymmetricBinary:
                            DataGridViewAttributes.Rows.Add(i + 1, attribute.Name, "Binario Simétrico", attribute.Domain);
                            break;

                        case DataFileAttribute.AttributeDataType.AsymmetricBinary:
                            DataGridViewAttributes.Rows.Add(i + 1, attribute.Name, "Binario Asimétrico", attribute.Domain);
                            break;

                        case DataFileAttribute.AttributeDataType.Numeric:
                            DataGridViewAttributes.Rows.Add(i + 1, attribute.Name, "Numérico", attribute.Domain);
                            break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < dataSet.Columns.Count; i++)
                {
                    DataGridViewAttributes.Rows.Add(i + 1, dataSet.Columns[i].Caption, "Nominal", "");
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (TextBoxGeneralInformation.Text == "")
            {
                MessageBox.Show("La información general se encuentra vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TextBoxRelation.Text == "")
            {
                MessageBox.Show("La relación se encuentra vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DataSetDataFile != null)
            {
                DataSetDataFile.GeneralInformation = TextBoxGeneralInformation.Text;
                DataSetDataFile.Relation = TextBoxRelation.Text;

                for (int i = 0; i < DataGridViewAttributes.RowCount; i++)
                {
                    if (DataGridViewAttributes[(int)ColumnIndex.Name, i].Value == null || DataGridViewAttributes[(int)ColumnIndex.Name, i].Value.ToString() == "")
                    {
                        MessageBox.Show("El nombre del atributo #" + (i + 1) + " se encuentra vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (DataGridViewAttributes[(int)ColumnIndex.Domain, i].Value == null || DataGridViewAttributes[(int)ColumnIndex.Domain, i].Value.ToString() == "")
                    {
                        MessageBox.Show("El dominio del atributo #" + (i + 1) + " se encuentra vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DataFileAttribute attribute = DataSetDataFile.Attributes[i];
                    DataGridViewComboBoxCell attributeDataType = (DataGridViewComboBoxCell)DataGridViewAttributes[(int)ColumnIndex.DataType, i];

                    try
                    {
                        attribute.Edit(DataGridViewAttributes[(int)ColumnIndex.Name, i].Value.ToString(), attributeDataType.Items.IndexOf(attributeDataType.Value), DataGridViewAttributes[(int)ColumnIndex.Domain, i].Value.ToString());
                    }
                    catch (ArgumentException)
                    {
                        MessageBox.Show("El dominio (expresión regular) del atributo #" + (i + 1) + " es inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (TextBoxMissingValue.Text == "")
                {
                    MessageBox.Show("El valor faltante se encuentra vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataSetDataFile.MissingValue = TextBoxMissingValue.Text;
            }
            else
            {
                List<DataFileAttribute> attributes = new List<DataFileAttribute>();

                for (int i = 0; i < DataGridViewAttributes.RowCount; i++)
                {
                    if (DataGridViewAttributes[(int)ColumnIndex.Name, i].Value == null || DataGridViewAttributes[(int)ColumnIndex.Name, i].Value.ToString() == "")
                    {
                        MessageBox.Show("El nombre del atributo #" + (i + 1) + " se encuentra vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (DataGridViewAttributes[(int)ColumnIndex.Domain, i].Value == null || DataGridViewAttributes[(int)ColumnIndex.Domain, i].Value.ToString() == "")
                    {
                        MessageBox.Show("El dominio del atributo #" + (i + 1) + " se encuentra vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DataGridViewComboBoxCell attributeDataType = (DataGridViewComboBoxCell)DataGridViewAttributes[(int)ColumnIndex.DataType, i];

                    try
                    {
                        attributes.Add(new DataFileAttribute(DataGridViewAttributes[(int)ColumnIndex.Name, i].Value.ToString(), attributeDataType.Items.IndexOf(attributeDataType.Value), DataGridViewAttributes[(int)ColumnIndex.Domain, i].Value.ToString()));
                    }
                    catch (ArgumentException)
                    {
                        MessageBox.Show("El dominio (expresión regular) del atributo #" + (i + 1) + " es inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                DataSetDataFile = new DataFile(TextBoxGeneralInformation.Text, TextBoxRelation.Text, attributes, TextBoxMissingValue.Text, dataSet);
            }

            DialogResult = DialogResult.OK;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
