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
    public partial class CorrectOutliers : Form
    {
        // Variables.
        DataTable dataSet;
        DataFile dataSetDataFile;
        int attributeIndex;
        List<string> attributeValues;
        List<int> possibleOutliersIndices;
        List<int> outliersIndices;
        public bool ChangesMade { get; set; }

        public CorrectOutliers(DataTable newDataSet, DataFile newDataSetDataFile, int newAttributeIndex, List<string> newAttributeValues, List<int> newPossibleOutliersIndices, List<int> newOutliersIndices)
        {
            InitializeComponent();

            // Inicializar las variables.
            dataSet = newDataSet;
            dataSetDataFile = newDataSetDataFile;
            attributeIndex = newAttributeIndex;
            attributeValues = newAttributeValues;
            possibleOutliersIndices = newPossibleOutliersIndices;
            outliersIndices = newOutliersIndices;
            ChangesMade = false;

            // Inicializar las herramientas.
            UpdateTools();
        }

        private void UpdateTools()
        {
            // Verificar si existen posibles "Outliers".
            if (possibleOutliersIndices.Count != 0)
            {
                // Existen posibles "Outliers".
                // Asignar la categoría de "Posible" al "Outlier".
                LabelCategoryValue.Text = "Posible Outlier";

                // Mostrar el "Outlier".
                TextBoxOutlierValue.Text = attributeValues[possibleOutliersIndices[0]];

                // Sugerir un valor para el "Outlier".
                TextBoxNewValue.Text = GetValueSuggestion().ToString();
            }
            else
            {
                // No existen posibles "Outliers".
                // Verificar si existen "Outliers".
                if (outliersIndices.Count != 0)
                {
                    // Existen "Outliers".
                    // Asignar la categoría al "Outlier".
                    LabelCategoryValue.Text = "Outlier";

                    // Mostrar el "Outlier".
                    TextBoxOutlierValue.Text = attributeValues[outliersIndices[0]].ToString();

                    // Sugerir un valor para el "Outlier".
                    TextBoxNewValue.Text = GetValueSuggestion().ToString();
                }
                else
                {
                    // No existen "Outliers".
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private double GetValueSuggestion()
        {
            // Variables para obtener la sugerencia.
            List<double> attributeValuesWithoutOutliers = new List<double>();
            double mean, median;

            // Obtener una lista de los valores del atributo sin los "Outliers".
            for (int i = 0; i < attributeValues.Count; i++)
            {
                // Verificar si el índice actual le pertenece a un "Outlier".
                if (!possibleOutliersIndices.Contains(i) && !outliersIndices.Contains(i))
                {
                    // Variable en la que se almacenará el valor del atributo.
                    string value = attributeValues[i];

                    // Verificar si el valor es un número.
                    if (double.TryParse(value, out double parsedValue))
                    {
                        // El valor es un número.
                        // Agregar el valor a la lista de los valores del atributo sin los "Outliers".
                        attributeValuesWithoutOutliers.Add(parsedValue);
                    }
                }
            }

            // Calcular la media y la mediana.
            mean = attributeValuesWithoutOutliers.Average();
            median = GetMedian(attributeValuesWithoutOutliers);

            // Verificar si la distribución se encuentra sesgada.
            if (mean == median)
            {
                // La distribucion no se encuentra sesgada.
                // Sugerir la media.
                return mean;
            }
            else
            {
                // La distribucion se encuentra sesgada.
                // Sugerir la mediana.
                return median;
            }
        }

        private double GetMedian(List<double> values)
        {
            // Verificar si los valores no tienen elementos.
            if (values.Count == 0)
            {
                // Los valores no tienen elementos.
                return double.NaN;
            }

            // Verificar si los valores solo tienen un elemento.
            if (values.Count == 1)
            {
                // Los valores solo tienen un elemento.
                // Retornar el elemento como la mediana.
                return values[0];
            }

            // Ordenar los valores.
            values.Sort();

            // Verificar si la cantidad de valores es múltiplo de 2.
            if (values.Count % 2 == 0)
            {
                // La cantidad de valores si es múltiplo de 2.
                // Retornar la mediana del conjunto de valores.
                return (values[(values.Count / 2) - 1] + values[values.Count / 2]) / 2;
            }
            else
            {
                // La cantidad de valores no es múltiplo de 2.
                // Retornar la mediana del conjunto de valores.
                return values[values.Count / 2];
            }
        }

        private void ButtonCorrect_Click(object sender, EventArgs e)
        {
            // Verificar si el nuevo valor es válido.
            if (!double.TryParse(TextBoxNewValue.Text, out double outlierNewValue))
            {
                // El nuevo valor es inválido.
                // Desplegar mensaje de error.
                MessageBox.Show("El nuevo valor es inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar si existen posibles "Outliers".
            if (possibleOutliersIndices.Count != 0)
            {
                // Existen posibles "Outliers".
                // Corregir valor en la "DataTable".
                dataSet.Rows[possibleOutliersIndices[0]][attributeIndex] = outlierNewValue.ToString();

                // Corregir valor en el "DataFile".
                dataSetDataFile.Data[possibleOutliersIndices[0]][attributeIndex] = outlierNewValue.ToString();

                // Eliminar índice.
                possibleOutliersIndices.RemoveAt(0);
            }
            else
            {
                // No existen posibles "Outliers".
                // Corregir valor en la "DataTable".
                dataSet.Rows[outliersIndices[0]][attributeIndex] = outlierNewValue.ToString();

                // Corregir valor en el "DataFile".
                dataSetDataFile.Data[outliersIndices[0]][attributeIndex] = outlierNewValue.ToString();

                // Eliminar índice.
                outliersIndices.RemoveAt(0);
            }

            // Asignar "true" a la variable que indica si se realizaron cambios al conjunto de datos.
            ChangesMade = true;

            // Actualizar las herramientas.
            UpdateTools();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
