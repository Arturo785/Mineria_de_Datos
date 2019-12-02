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
    public partial class CorrectTypographicErrors : Form
    {
        // Variables.
        DataTable dataSet;
        DataFile dataSetDataFile;
        int attributeIndex;
        List<string> attributeValues;
        List<string> inOfDomainValues;
        List<int> outOfDomainValuesIndices;
        int currentoutOfDomainValuesIndex;
        public bool ChangesMade { get; set; }

        public CorrectTypographicErrors(DataTable newDataSet, DataFile newDataSetDataFile, int newAttributeIndex, List<string> newAttributeValues, List<string> newInOfDomainValues, List<int> newOutOfDomainValuesIndices)
        {
            InitializeComponent();

            // Inicializar variables.
            dataSet = newDataSet;
            dataSetDataFile = newDataSetDataFile;
            attributeIndex = newAttributeIndex;
            attributeValues = newAttributeValues;
            inOfDomainValues = newInOfDomainValues;
            outOfDomainValuesIndices = newOutOfDomainValuesIndices;
            currentoutOfDomainValuesIndex = 0;

            // Inicializar las herramientas.
            UpdateTools();
        }

        private void UpdateTools()
        {
            // Mostrar el valor fuera del dominio.
            TextBoxOutOfDomainValue.Text = attributeValues[outOfDomainValuesIndices[currentoutOfDomainValuesIndex]];

            // Sugerir un valor para el valor fuera del dominio.
            TextBoxSuggestion.Text = GetValueSuggestion();
        }

        private string GetValueSuggestion()
        {
            // Lista para almacenar las distancias de Levenshtein de los valores fuera del dominio con los dentro del dominio.
            List<int> levenshteinDistances = new List<int>();

            // Variable para almacenar la mínima distancia de Levenshtein.
            int minimumLevenshteinDistance;

            // Llenar la lista de distancias de Levenshtein.
            foreach (string value in inOfDomainValues)
            {
                levenshteinDistances.Add(GetLevenshteinDistance(attributeValues[outOfDomainValuesIndices[currentoutOfDomainValuesIndex]], value));
            }

            // Asignar la mínima distancia de Levenshtein encontrada.
            minimumLevenshteinDistance = levenshteinDistances.Min();

            // Verificar si la mínima distancia de Levenshtein es menor o igual a la mitad de la longitud del valor fuera del dominio.
            if (minimumLevenshteinDistance <= TextBoxOutOfDomainValue.Text.Length / 2)
            {
                // La mínima distancia de Levenshtein es menor o igual a la mitad de la longitud del valor fuera del dominio.
                // Sugerir el valor dentro del dominio con la mínima distancia de Levenshtein.
                return inOfDomainValues[levenshteinDistances.IndexOf(minimumLevenshteinDistance)];
            }
            else
            {
                // La mínima distancia de Levenshtein es mayor a la mitad de la longitud del valor fuera del dominio.
                // Sugerir el mismo valor fuera del dominio.
                return TextBoxOutOfDomainValue.Text;
            }
        }

        private int GetLevenshteinDistance(string stringOne, string stringTwo)
        {
            // Tabla en la que se realizará el cálculo de la distancia.
            int[,] distance = new int[stringOne.Length + 1, stringTwo.Length + 1];

            // Verificar si la longitud de la primera cadena es 0.
            if (stringOne.Length == 0)
            {
                // La longitud de la primera cadena es 0.
                // Retornar la longitud de la segunda cadena.
                return stringTwo.Length;
            }

            // Verificar si la longitud de la segunda cadena es 0.
            if (stringTwo.Length == 0)
            {
                // La longitud de la segunda cadena es 0.
                // Retornar la longitud de la primera cadena.
                return stringOne.Length;
            }

            // Llenar la primera columna.
            for (int i = 0; i <= stringOne.Length; i++)
            {
                distance[i, 0] = i;
            }

            // Llenar la primera fila.
            for (int j = 0; j <= stringTwo.Length; j++)
            {
                distance[0, j] = j;
            }

            // Llenar el resto de la tabla.
            // Iterar sobre las filas.
            for (int i = 1; i <= stringOne.Length; i++)
            {
                // Iterar sobre las columnas.
                for (int j = 1; j <= stringTwo.Length; j++)
                {
                    // Variable que almacenará el valor que se sumará a (i - 1, j - 1).
                    int comparison;

                    // Verificar si la letra de las cadenas en la casilla es la misma.
                    if (stringOne[i - 1] == stringTwo[j - 1])
                    {
                        // La letra de las cadenas en la casilla es la misma.
                        // El valor que se sumará a (i - 1, j - 1) será 0.
                        comparison = 0;
                    }
                    else
                    {
                        // La letra de las cadenas en la casilla no es la misma.
                        // El valor que se sumará a (i - 1, j - 1) será 1.
                        comparison = 1;
                    }

                    // Obtener el valor mínimo en la tabla entre (i - 1, j), (i, j - 1) y (i - 1, j - 1) y asignarlo a la casilla actual.
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + comparison);
                }
            }

            // Retornar el valor de la casilla en la esquina inferior derecha de la tabla.
            return distance[stringOne.Length, stringTwo.Length];
        }

        private void ButtonCorrect_Click(object sender, EventArgs e)
        {
            // Verificar si el "TextBox" del nuevo valor se encuentra vacío.
            if (TextBoxSuggestion.Text == "")
            {
                // Desplegar mensaje de error.
                MessageBox.Show("El nuevo valor se encuentra vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Corregir valor en la "DataTable".
            dataSet.Rows[outOfDomainValuesIndices[currentoutOfDomainValuesIndex]][attributeIndex] = TextBoxSuggestion.Text;

            // Corregir valor en el "DataFile".
            dataSetDataFile.Data[outOfDomainValuesIndices[currentoutOfDomainValuesIndex]][attributeIndex] = TextBoxSuggestion.Text;

            // Eliminar índice.
            outOfDomainValuesIndices.RemoveAt(currentoutOfDomainValuesIndex);

            // Asignar "true" a la variable que indica si se realizaron cambios al conjunto de datos.
            ChangesMade = true;

            // Verificar si ya no hay valores fuera del dominio por corregir.
            if (outOfDomainValuesIndices.Count == 0 || currentoutOfDomainValuesIndex == outOfDomainValuesIndices.Count)
            {
                // Ya no hay valores fuera del dominio por corregir.
                DialogResult = DialogResult.OK;
            }
            else
            {
                // Hay valores fuera del dominio por corregir.
                // Actualizar las herramientas.
                UpdateTools();
            }
        }

        private void ButtonIgnore_Click(object sender, EventArgs e)
        {
            // Incrementar el índice actual de los valores fuera del dominio.
            currentoutOfDomainValuesIndex++;

            // Verificar si ya no hay valores fuera del dominio por corregir.
            if (currentoutOfDomainValuesIndex == outOfDomainValuesIndices.Count)
            {
                // Ya no hay valores fuera del dominio por corregir.
                // Verificar si se realizaron cambios en el conjunto de datos.
                if (ChangesMade)
                {
                    // Se realizaron cambios en el conjunto de datos.
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    // No se realizaron cambios en el conjunto de datos.
                    DialogResult = DialogResult.Abort;
                }
            }
            else
            {
                // Hay valores fuera del dominio por corregir.
                // Actualizar las herramientas.
                UpdateTools();
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
