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
    public partial class InstancesAndKNearestNeighbors : Form
    {
        // Variables.
        DataFile dataSetDataFile;
        List<List<DataTable>> kInstancesAndNearestNeighbors;
        List<DataTable> classifiedKInstances;
        public List<double> ClassifiedKInstancesAccuracy { get; set; }
        public List<double> ClassifiedKInstancesMeanSquaredError { get; set; }
        int classAttributeIndex;
        int kInstancesAndNearestNeighborsIndex;

        public InstancesAndKNearestNeighbors(DataFile newDataSetDataFile, int newClassAttributeIndex, List<List<DataTable>> newKInstancesAndNearestNeighbors)
        {
            InitializeComponent();

            // Inicializar las variables.
            dataSetDataFile = newDataSetDataFile;
            kInstancesAndNearestNeighbors = newKInstancesAndNearestNeighbors;
            classifiedKInstances = new List<DataTable>();
            ClassifiedKInstancesAccuracy = new List<double>();
            ClassifiedKInstancesMeanSquaredError = new List<double>();
            classAttributeIndex = newClassAttributeIndex;
            kInstancesAndNearestNeighborsIndex = 0;

            // Procesar las instancias.
            ProcessInstances();

            // Actualizar los "DataGridView".
            UpdateDataGridViews();

            // Deshabilitar el botón de "Anterior".
            ButtonPrevious.Enabled = false;

            // Verificar si solo hay una instancia y clúster.
            if (kInstancesAndNearestNeighbors[0].Count == 1)
            {
                // Solo hay una instancia y clúster.
                // Deshabilitar el botón de "Siguiente".
                ButtonNext.Enabled = false;
            }
        }

        private void ProcessInstances() // COMENTAR.
        {
            // Verificar el tipo del archivo.
            if (dataSetDataFile == null)
            {
                // Archivo CSV.
                // Recorrer todas las instancias.
                for (int i = 0; i < kInstancesAndNearestNeighbors[0].Count; i++)
                {
                    // Variablesl.
                    DataTable classifiedKInstance = kInstancesAndNearestNeighbors[0][i].Copy();
                    List<string> classAttributeValues = new List<string>();

                    // Obtener los valores 
                    foreach (DataRow neighbor in kInstancesAndNearestNeighbors[1][i].Rows)
                    {
                        classAttributeValues.Add(neighbor[classAttributeIndex].ToString());
                    }

                    classifiedKInstance.Rows[0][classAttributeIndex] = classAttributeValues.GroupBy(value => value).OrderByDescending(group => group.Count()).First().Key;

                    classifiedKInstances.Add(classifiedKInstance);

                    ClassifiedKInstancesAccuracy.Add(kInstancesAndNearestNeighbors[0][i].Rows[0][classAttributeIndex] == classifiedKInstance.Rows[0][classAttributeIndex] ? 1 : 0);
                }
            }
            else
            {
                if (dataSetDataFile.Attributes[classAttributeIndex].GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                {
                    for (int i = 0; i < kInstancesAndNearestNeighbors[0].Count; i++)
                    {
                        DataTable classifiedKInstance = kInstancesAndNearestNeighbors[0][i].Copy();
                        List<double> classAttributeValues = new List<double>();

                        foreach (DataRow neighbor in kInstancesAndNearestNeighbors[1][i].Rows)
                        {
                            classAttributeValues.Add(Convert.ToDouble(neighbor[classAttributeIndex]));
                        }

                        classifiedKInstance.Rows[0][classAttributeIndex] = classAttributeValues.Average();

                        classifiedKInstances.Add(classifiedKInstance);

                        ClassifiedKInstancesMeanSquaredError.Add(Math.Pow(Convert.ToDouble(kInstancesAndNearestNeighbors[0][i].Rows[0][classAttributeIndex]) - classAttributeValues.Average(), 2));
                    }
                }
                else
                {
                    for (int i = 0; i < kInstancesAndNearestNeighbors[0].Count; i++)
                    {
                        DataTable classifiedKInstance = kInstancesAndNearestNeighbors[0][i].Copy();
                        List<string> classAttributeValues = new List<string>();

                        foreach (DataRow neighbor in kInstancesAndNearestNeighbors[1][i].Rows)
                        {
                            classAttributeValues.Add(neighbor[classAttributeIndex].ToString());
                        }

                        classifiedKInstance.Rows[0][classAttributeIndex] = classAttributeValues.GroupBy(value => value).OrderByDescending(group => group.Count()).First().Key;

                        classifiedKInstances.Add(classifiedKInstance);

                        ClassifiedKInstancesAccuracy.Add(kInstancesAndNearestNeighbors[0][i].Rows[0][classAttributeIndex].ToString() == classifiedKInstance.Rows[0][classAttributeIndex].ToString() ? 1 : 0);
                    }
                }
            }
        }

        private void UpdateDataGridViews()
        {
            // Actualizar el "GroupBox" de "Evaluación".
            // Verificar el tipo del archivo.
            if (dataSetDataFile == null)
            {
                // Archivo CSV.
                // Obtener la exactitud correspondiente.
                LabelAccuracyValue.Text = ClassifiedKInstancesAccuracy[kInstancesAndNearestNeighborsIndex].ToString();

                // Reestablecer el "Label" de "Error Cuadrático Medio".
                LabelMeanSquaredErrorValue.Text = "N/A";
            }
            else
            {
                // Archivo DATA.
                // Verificar el tipo del atributo clase.
                if (dataSetDataFile.Attributes[classAttributeIndex].GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                {
                    // Atributo numérico.
                    // Obtener el error cuadrático medio correspondiente.
                    LabelMeanSquaredErrorValue.Text = ClassifiedKInstancesMeanSquaredError[kInstancesAndNearestNeighborsIndex].ToString();

                    // Reestablecer el "Label" de "Exactitud".
                    LabelAccuracyValue.Text = "N/A";
                }
                else
                {
                    // Atributo categórico.
                    // Obtener la exactitud correspondiente.
                    LabelAccuracyValue.Text = ClassifiedKInstancesAccuracy[kInstancesAndNearestNeighborsIndex].ToString();

                    // Reestablecer el "Label" de "Error Cuadrático Medio".
                    LabelMeanSquaredErrorValue.Text = "N/A";
                }
            }

            // Actualizar el "DataSource" de "Instancia Original".
            DataGridViewOriginalInstance.DataSource = null;
            DataGridViewOriginalInstance.DataSource = kInstancesAndNearestNeighbors[0][kInstancesAndNearestNeighborsIndex];

            // Actualizar el "DataSource" de "Instancia Clasificada".
            DataGridViewClassifiedInstance.DataSource = null;
            DataGridViewClassifiedInstance.DataSource = classifiedKInstances[kInstancesAndNearestNeighborsIndex];

            // Actualizar el "DataSource" del "Nearest Neighbors".
            DataGridViewNearestNeighbors.DataSource = null;
            DataGridViewNearestNeighbors.DataSource = kInstancesAndNearestNeighbors[1][kInstancesAndNearestNeighborsIndex];
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            // Incrementar una unidad el índice de las instancias y clústeres.
            kInstancesAndNearestNeighborsIndex++;

            // Actualizar los "DataGridView".
            UpdateDataGridViews();

            // Verificar si el índice es de la segunda instancia y clúster.
            if (kInstancesAndNearestNeighborsIndex == 1)
            {
                // Habilitar botón de "Anterior".
                ButtonPrevious.Enabled = true;
            }

            // Verificar si el índice es de la última instancia y clúster.
            if (kInstancesAndNearestNeighborsIndex == kInstancesAndNearestNeighbors[0].Count - 1)
            {
                // Deshabilitar botón de "Siguiente".
                ButtonNext.Enabled = false;
            }
        }

        private void ButtonPrevious_Click(object sender, EventArgs e)
        {
            // Decrementar una unidad el índice de las instancias y clústeres.
            kInstancesAndNearestNeighborsIndex--;

            // Actualizar los "DataGridView".
            UpdateDataGridViews();

            // Verificar si el índice es de la penúltima instancia y clústere.
            if (kInstancesAndNearestNeighborsIndex == kInstancesAndNearestNeighbors[0].Count - 2)
            {
                // Habilitar botón de "Siguiente".
                ButtonNext.Enabled = true;
            }

            // Verificar si el índice es de la primera instancia y clústere.
            if (kInstancesAndNearestNeighborsIndex == 0)
            {
                // Deshabilitar botón de "Anterior".
                ButtonPrevious.Enabled = false;
            }
        }
    }
}
