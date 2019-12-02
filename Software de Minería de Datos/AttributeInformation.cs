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
    public partial class AttributeInformation : Form
    {
        DataTable dataSet;
        DataFile dataSetDataFile;

        public AttributeInformation(DataTable newDataSet, DataFile newDataSetDataFile)
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

        private void ListBoxAttributes_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAttributeInformation();
        }

        private void GetAttributeInformation()
        {
            string value;
            int numberOfMissingValues = 0;

            LabelNameValue.Text = ListBoxAttributes.SelectedValue.ToString();

            if (dataSetDataFile != null)
            {
                DataFileAttribute attribute = dataSetDataFile.Attributes[ListBoxAttributes.SelectedIndex];
                int numberOfOutOfDomainValues = 0;

                LabelDataTypeValue.Text = attribute.DataType;

                foreach (DataRow instance in dataSet.Rows)
                {
                    value = instance[ListBoxAttributes.SelectedIndex].ToString();

                    if (!attribute.Domain.IsMatch(value))
                    {
                        if (value == dataSetDataFile.MissingValue || value == "")
                        {
                            numberOfMissingValues++;
                        }
                        else
                        {
                            numberOfOutOfDomainValues++;
                        }
                    }
                }

                if (dataSet.Rows.Count != 0)
                {
                    LabelMissingValuesValue.Text = numberOfMissingValues + " (" + (numberOfMissingValues * 100) / dataSet.Rows.Count + "% del total)";
                }
                else
                {
                    LabelMissingValuesValue.Text = "0 (0% del total)";
                }

                LabelDomainValue.Text = attribute.Domain.ToString();
                LabelOutOfDomainValuesValue.Text = numberOfOutOfDomainValues.ToString();
            }
            else
            {
                foreach (DataRow instance in dataSet.Rows)
                {
                    if (instance[ListBoxAttributes.SelectedIndex].ToString() == "")
                    {
                        numberOfMissingValues++;
                    }
                }

                LabelDataTypeValue.Text = "N/A";

                if (dataSet.Rows.Count != 0)
                {
                    LabelMissingValuesValue.Text = numberOfMissingValues + " (" + (numberOfMissingValues * 100) / dataSet.Rows.Count + "% del total)";
                }
                else
                {
                    LabelMissingValuesValue.Text = "0 (0% del total)";
                }

                LabelDomainValue.Text = "N/A";
                LabelOutOfDomainValuesValue.Text = "N/A";
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }
    }
}
