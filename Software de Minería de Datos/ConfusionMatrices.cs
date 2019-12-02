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
    public partial class ConfusionMatrices : Form
    {
        // Variables.
        List<DataTable> confusionMatrices;
        int confusionMatrixIndex;
        public List<double> ConfusionMatricesAccuracy { get; }

        public ConfusionMatrices(List<DataTable> newConfusionMatrices)
        {
            InitializeComponent();

            // Inicializar las variables.
            confusionMatrices = new List<DataTable>();
            foreach (DataTable confusionMatrix in newConfusionMatrices)
            {
                confusionMatrices.Add(confusionMatrix.Copy());
            }
            confusionMatrixIndex = 0;
            ConfusionMatricesAccuracy = new List<double>(new double[confusionMatrices.Count]);

            // Procesar las matrices de confusión.
            ProcessMatrices();

            // Actualizar el contenido del "DataGridView".
            UpdateDataGridView();

            // Deshabilitar el botón de "Anterior".
            ButtonPreviousMatrix.Enabled = false;

            // Verificar si solo hay una matriz de confusión.
            if (confusionMatrices.Count == 1)
            {
                // Solo hay una matriz de confusión.
                // Deshabilitar el botón de "Siguiente".
                ButtonNextMatrix.Enabled = false;
            }
        }

        private void ProcessMatrices()
        {
            // Procesar todas las matrices en la lista.
            while (confusionMatrixIndex < confusionMatrices.Count)
            {
                // Obtener la matriz de confusión en el índice actual.
                DataTable confusionMatrix = confusionMatrices[confusionMatrixIndex];

                // Crear una nueva matriz para almacenar los valores numéricos de la matriz de confusión.
                double[,] numericConfusionMatrix = new double[confusionMatrix.Rows.Count, confusionMatrix.Columns.Count];

                // Obtener los valores numéricos de la matriz.
                for (int i = 0; i < confusionMatrix.Rows.Count; i++)
                {
                    for (int j = 0; j < confusionMatrix.Columns.Count; j++)
                    {
                        numericConfusionMatrix[i, j] = Convert.ToDouble(confusionMatrix.Rows[i][j]);
                    }
                }

                // Obtener longitud de la matriz.
                int numericConfusionMatrixLength = numericConfusionMatrix.GetLength(0);

                // Agregar las columnas adicionales.
                confusionMatrix.Columns.Add("Posibles Valores").SetOrdinal(0);
                confusionMatrix.Columns.Add("Desempeño");

                // Agregar las filas adicionales.
                confusionMatrix.Rows.Add("Desempeño");

                // Llenar la columna de "Posibles Valores".
                for (int i = 0; i < confusionMatrix.Rows.Count; i++)
                {
                    confusionMatrix.Rows[i][0] = confusionMatrix.Columns[i + 1].Caption;
                }

                // Listas para almacenar la sumatoria de todos los valores en todas las filas y columnas.
                List<double> confusionMatrixRowSummations = new List<double>(new double[numericConfusionMatrixLength]);
                List<double> confusionMatrixColumnSummations = new List<double>(new double[numericConfusionMatrixLength]);

                // Realizar la sumatoria de todos los valores en todas las filas y columnas.
                for (int i = 0; i < numericConfusionMatrixLength; i++)
                {
                    for (int j = 0; j < numericConfusionMatrixLength; j++)
                    {
                        confusionMatrixRowSummations[i] += numericConfusionMatrix[i, j];
                        confusionMatrixColumnSummations[j] += numericConfusionMatrix[i, j];
                    }
                }

                // Calcular la sensibilidad o especificidad de cada atributo.
                for (int i = 0; i < numericConfusionMatrixLength; i++)
                {
                    // Verificar si la sumatoria de los valores de la columna es 0.
                    if (confusionMatrixColumnSummations[i] == 0)
                    {
                        // La sumatoria de los valores de la columna es 0.
                        // Asignar una sensibilidad o especificidad de 0.
                        confusionMatrix.Rows[confusionMatrix.Rows.Count - 1][i + 1] = 0;
                    }
                    else
                    {
                        // La sumatoria de los valores de la columna no es 0.
                        // Asignar una sensibilidad o especificidad en base a la fórmula.
                        confusionMatrix.Rows[confusionMatrix.Rows.Count - 1][i + 1] = numericConfusionMatrix[i, i] / confusionMatrixColumnSummations[i];
                    }
                }

                // Calcular los valores predictivos de cada atributo.
                for (int i = 0; i < numericConfusionMatrixLength; i++)
                {
                    // Verificar si la sumatoria de los valores de la fila es 0.
                    if (confusionMatrixRowSummations[i] == 0)
                    {
                        // La sumatoria de los valores de la fila es 0.
                        // Asignar un valor predictivo de 0.
                        confusionMatrix.Rows[i][confusionMatrix.Columns.Count - 1] = 0;
                    }
                    else
                    {
                        // La sumatoria de los valores de la fila no es 0.
                        // Asignar un valor predictivo en base a la fórmula.
                        confusionMatrix.Rows[i][confusionMatrix.Columns.Count - 1] = numericConfusionMatrix[i, i] / confusionMatrixRowSummations[i];
                    }
                }

                // Variable para almacenar la sumatoria de la precisión.
                double accuracy = 0;

                // Realizar la sumatoria de la precisión.
                for (int i = 0; i < numericConfusionMatrixLength; i++)
                {
                    accuracy += numericConfusionMatrix[i, i];
                }

                // Dividir la sumatoria de la precisión sobre la suma de todos los valores en la matriz.
                accuracy /= confusionMatrixRowSummations.Sum();

                // Verificar si la exactitud calculada es válida.
                if (!double.IsNaN(accuracy))
                {
                    // La exactitud calculada es válida.
                    // Colocar la exactitud en la casilla en la esquina inferior derecha del "DataTable".
                    confusionMatrix.Rows[confusionMatrix.Rows.Count - 1][confusionMatrix.Columns.Count - 1] = accuracy;
                }
                else
                {
                    // La exactitud calculada no es válida.
                    confusionMatrix.Rows[confusionMatrix.Rows.Count - 1][confusionMatrix.Columns.Count - 1] = 0;
                }

                // Agregar la precisión de la matriz actual a la lista.
                ConfusionMatricesAccuracy[confusionMatrixIndex] = accuracy;

                // Aumentar una unidad el índice de la matriz de confusión.
                confusionMatrixIndex++;
            }

            // Restaurar el índice de la matriz de confusión.
            confusionMatrixIndex = 0;
        }

        private void UpdateDataGridView()
        {
            // Actualizar el "DataSource" del "DataGridView".
            DataGridViewConfusionMatrix.DataSource = null;
            DataGridViewConfusionMatrix.DataSource = confusionMatrices[confusionMatrixIndex];

            // Asignar un valor al label de "K".
            LabelKValue.Text = (confusionMatrixIndex + 1).ToString();
        }

        private void DataGridViewConfusionMatrix_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            // Deshabilitar el ordenamiento de columnas.
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void ButtonNextMatrix_Click(object sender, EventArgs e)
        {
            // Incrementar una unidad el índice de las matrices de confusión.
            confusionMatrixIndex++;

            // Actualizar el contenido del "DataGridView".
            UpdateDataGridView();

            // Verificar si el índice es de la segunda matriz.
            if (confusionMatrixIndex == 1)
            {
                // Habilitar botón de "Anterior".
                ButtonPreviousMatrix.Enabled = true;
            }

            // Verificar si el índice es de la última matriz.
            if (confusionMatrixIndex == confusionMatrices.Count - 1)
            {
                // Deshabilitar botón de "Siguiente".
                ButtonNextMatrix.Enabled = false;
            }
        }

        private void ButtonPreviousMatrix_Click(object sender, EventArgs e)
        {
            // Decrementar una unidad el índice de las matrices de confusión.
            confusionMatrixIndex--;

            // Actualizar el contenido del "DataGridView".
            UpdateDataGridView();

            // Verificar si el índice es de la penúltima matriz.
            if (confusionMatrixIndex == confusionMatrices.Count - 2)
            {
                // Habilitar botón de "Siguiente".
                ButtonNextMatrix.Enabled = true;
            }

            // Verificar si el índice es de la primera matriz.
            if (confusionMatrixIndex == 0)
            {
                // Deshabilitar botón de "Anterior".
                ButtonPreviousMatrix.Enabled = false;
            }
        }
    }
}
