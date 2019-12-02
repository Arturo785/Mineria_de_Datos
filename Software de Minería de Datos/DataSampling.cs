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
    public partial class DataSampling : Form
    {
        // Variables.
        DataTable dataSet;
        DataTable dataSetSample;
        DataFile dataSetDataFile;

        public DataSampling(DataTable newDataSet)
        {
            InitializeComponent();

            // Inicializar la "DataTable".
            dataSet = newDataSet;

            // Filtrar los archivos que se pueden escribir (*.csv y *.data).
            SaveFileDialogSample.Filter = "Archivo CSV (*.csv)|*.csv|Archivo DATA (*.data)|*.data";
        }

        public void UpdateContent(DataFile newDataSetDataFile)
        {
            // Verificar si el conjunto de datos tiene instancias.
            if (dataSet.Rows.Count == 0)
            {
                // El conjunto de datos no tiene instancias.
                // Definir el valor máximo del "NumericUpDown" del número de instancias como 0.
                NumericUpDownNumberOfInstances.Maximum = 0;
            }
            else
            {
                // El conjunto de datos tiene instancias.
                // Asignar el "DataFile".
                dataSetDataFile = newDataSetDataFile;

                // Definir el valor máximo del "NumericUpDown" del número de instancias como N-1.
                NumericUpDownNumberOfInstances.Maximum = dataSet.Rows.Count - 1;
            }

            // Verificar si la muestra no es nula.
            if (dataSetSample != null)
            {
                // La muestra no es nula.
                // Limpiar la muestra.
                dataSetSample.Rows.Clear();
                dataSetSample.Columns.Clear();
            }

            // Bloquear el botón de "Guardar Muestra".
            ButtonSaveSample.Enabled = false;
        }

        private void ButtonGenerateSample_Click(object sender, EventArgs e)
        {
            // Verificar si el número de instancias es menor o igual que 0.
            if (NumericUpDownNumberOfInstances.Value <= 0)
            {
                // El número de instancias es menor o igual que 0.
                // Desplegar mensaje de error y regresar.
                MessageBox.Show("El número de instancias debe ser mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Copiar la "DataTable"
            DataTable dataSetCopy = dataSet.Copy();

            // Clonar la estructura de la "DataTable".
            dataSetSample = dataSet.Clone();

            // Crear un generador de números aleatorios.
            Random numberGenerator = new Random();

            // Verificar el tipo de muestreo a realizar.
            if (RadioButtonWithoutReplacement.Checked)
            {
                // Muestreo sin reemplazo.
                // Construir la muestra.
                for (int i = 0; i < NumericUpDownNumberOfInstances.Value; i++)
                {
                    // Asignar el índice de la instancia aleatoria.
                    int instanceIndex = numberGenerator.Next(dataSetCopy.Rows.Count);

                    // Agregar la instancia a la muestra.
                    dataSetSample.Rows.Add(dataSetCopy.Rows[instanceIndex].ItemArray);

                    // Eliminar la instancia del conjunto de datos.
                    dataSetCopy.Rows.RemoveAt(instanceIndex);
                }
            }
            else
            {
                // Muestreo con reemplazo.
                // Construir la muestra.
                for (int i = 0; i < NumericUpDownNumberOfInstances.Value; i++)
                {
                    // Asignar el índice de la instancia aleatoria.
                    int instanceIndex = numberGenerator.Next(dataSetCopy.Rows.Count);

                    // Agregar la instancia a la muestra.
                    dataSetSample.Rows.Add(dataSetCopy.Rows[instanceIndex].ItemArray);
                }
            }

            // Definir la muestra como el "DataSource" del "DataGridView".
            DataGridViewSample.DataSource = dataSetSample;

            // Activar el botón de "Guardar Muestra".
            ButtonSaveSample.Enabled = true;
        }

        private void ButtonSaveSample_Click(object sender, EventArgs e)
        {
            // Definir el nombre del archivo por defecto como "Muestra".
            SaveFileDialogSample.FileName = "Muestra";

            // Mostrar el "SaveFileDialog" para guardar la muestra.
            if (SaveFileDialogSample.ShowDialog() == DialogResult.OK)
            {
                // Se seleccionó un tipo y se dio clic en "Aceptar".
                // Decidir que acciones realizar en base al tipo del archivo seleccionado.
                switch ((DataEntry.SaveFileDialogFilter)SaveFileDialogSample.FilterIndex)
                {
                    case DataEntry.SaveFileDialogFilter.CSV:
                        
                        // Archivo CSV.
                        // Guardar la muestra como archivo CSV.
                        File.WriteAllText(SaveFileDialogSample.FileName, SaveFileAsCSV());

                        break;

                    case DataEntry.SaveFileDialogFilter.DATA:

                        // Archivo DATA.
                        // Crear un nuevo "DataFile" utilizando el "DataFile" actual pero con los datos de la muestra.
                        DataFile dataSetSampleDataFile = new DataFile(dataSetDataFile.GeneralInformation, dataSetDataFile.Relation, dataSetDataFile.Attributes, dataSetDataFile.MissingValue, dataSetSample);

                        // Llenar los campos del archivo DATA.
                        using (SaveFileAsDATA saveFileAsDATAForm = new SaveFileAsDATA(dataSet, dataSetSampleDataFile))
                        {
                            // Mostrar el "Form" con los atributos del archivo DATA.
                            if (saveFileAsDATAForm.ShowDialog() == DialogResult.OK)
                            {
                                // Guardar la muestra como archivo DATA.
                                File.WriteAllText(SaveFileDialogSample.FileName, saveFileAsDATAForm.DataSetDataFile.Save());
                            }
                            else
                            {
                                // En caso de cancelar el guardado, retornar.
                                return;
                            }
                        }

                        break;
                }
            }
        }

        private string SaveFileAsCSV()
        {
            // Variables para generar el archivo CSV.
            string CSVFile = "";
            int i;

            // Obtener los nombres de los atributos.
            for (i = 0; i < dataSetSample.Columns.Count - 1; i++)
            {
                // Almacenar en la cadena del archivo CSV el nombre del atributo seguido de una ','.
                CSVFile += dataSetSample.Columns[i].Caption + ",";
            }

            // Terminar la línea con los nombres de los atributos con un '\n'.
            CSVFile += dataSetSample.Columns[i] + "\n";
            
            // Obtener los las instancias.
            foreach (DataRow instance in dataSetSample.Rows)
            {
                // Obtener los valores de los atributos de cada instancia.
                for (i = 0; i < dataSetSample.Columns.Count - 1; i++)
                {
                    // Almacenar en la cadena del archivo CSV el valor del atributo seguido de una ','.
                    CSVFile += instance[i].ToString() + ",";
                }

                // Terminar la línea con los valores de una instancia con un '\n'.
                CSVFile += instance[i].ToString() + "\n";
            }
            
            // Retornar la cadena del archivo CSV.
            return CSVFile;
        }

        private void DataGridViewSample_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            // Evitar que las columnas agregadas puedan ordenarse.
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}
