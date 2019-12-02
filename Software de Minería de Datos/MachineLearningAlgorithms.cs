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
    public partial class MachineLearningAlgorithms : Form
    {
        // Enum con los algoritmos.
        enum Algorithms { ZeroR, OneR, NaiveBayes, KMeans, KNearestNeighbors }

        // Variables.
        DataTable dataSet;
        DataFile dataSetDataFile;
        BindingList<string> attributes;
        DataFileAttribute classAttribute;
        
        public MachineLearningAlgorithms(DataTable newDataSet)
        {
            InitializeComponent();

            // Inicializar las variables.
            dataSet = newDataSet;
            attributes = new BindingList<string>();

            // Inicializar la "DataSource" del "ComboBox" del atributo clase.
            ComboBoxClassAttribute.DataSource = attributes;

            // Modificar el "ComboBox" de "Algoritmos".
            ComboBoxAlgorithms.SelectedIndex = 0;
        }

        public void UpdateContent(DataFile newDataSetDataFile)
        {
            // Restaurar las variables y herramientas.
            ResetToolsAndVariables();

            // Verificar si el conjunto de datos está vacío.
            if (dataSet.Rows.Count == 0)
            {
                // El conjunto de datos está vacío.
                // Deshabilitar las herramientas.
                DisableTools();
            }
            else
            {
                // El conjunto de datos tiene instancias.
                // Inicializar el "DataFile".
                dataSetDataFile = newDataSetDataFile;

                // Verificar el tipo de archivo.
                if (dataSetDataFile == null)
                {
                    // Archivo CSV.
                    // Verificar si el conjunto de datos tiene valores faltantes.
                    foreach (DataRow instance in dataSet.Rows)
                    {
                        foreach (DataColumn attribute in dataSet.Columns)
                        {
                            // Verificar si los atributos en las instancias tienen valores faltantes.
                            if (instance[attribute].ToString() == "")
                            {
                                // Hay un valor faltante.
                                // Deshabilitar las herramientas.
                                DisableTools();

                                // Desplegar mensaje de error y abortar.
                                MessageBox.Show("El conjunto de datos tiene valores faltantes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }
                else
                {
                    // Archivo DATA.
                    // Verificar si el conjunto de datos tiene valores faltantes.
                    foreach (DataRow instance in dataSet.Rows)
                    {
                        foreach (DataColumn attribute in dataSet.Columns)
                        {
                            // Verificar si los atributos en las instancias tienen valores faltantes.
                            if (instance[attribute].ToString() == "" || instance[attribute].ToString() == dataSetDataFile.MissingValue)
                            {
                                // Hay un valor faltante.
                                // Deshabilitar las herramientas.
                                DisableTools();

                                // Desplegar mensaje de error y abortar.
                                MessageBox.Show("El conjunto de datos tiene valores faltantes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }

                // Llenar el "ComboBox" del "Atributo Clase".
                foreach (DataColumn attribute in dataSet.Columns)
                {
                    attributes.Add(attribute.Caption);
                }

                // Actualizar el atributo clase.
                UpdateClassAttribute();

                // Habilitar las herramientas.
                EnableTools();
            }
        }

        private void ResetToolsAndVariables()
        {
            // Restaurar el "GroupBox" de "Atributo Clase".
            LabelTypeValue.Text = "N/A";
            attributes.Clear();

            // Restaurar las herramientas y variables necesarias al generar un modelo.
            SoftResetToolsAndVariables();
        }

        private void SoftResetToolsAndVariables()
        {
            // Restaurar el "GroupBox" de "Evaluación".
            // Clasificacion.
            LabelAccuracyValue.Text = "N/A";
            // Regresión.
            LabelMeanSquaredErrorValue.Text = "N/A";

            // Restaurar el panel.
            PanelMachineLearningAlgorithm.Controls.Clear();
        }

        private void DisableTools()
        {
            // Deshabilitar el "GroupBox" de "Atributo Clase".
            ComboBoxClassAttribute.Enabled = false;

            // Deshabilitar el "GroupBox" de "Algoritmos".
            ComboBoxAlgorithms.Enabled = false;

            // Deshabilitar el "GroupBox" de "Atributo Clase".
            // Hold-Out.
            RadioButtonHoldOut.Enabled = false;
            NumericUpDownPercentageTrainingSet.Enabled = false;
            // K-Fold Cross Validation.
            RadioButtonKFoldCrossValidation.Enabled = false;
            NumericUpDownKValue.Enabled = false;

            // Deshabilitar el botón de "Entrenar Algoritmo".
            ButtonTrainAlgorithm.Enabled = false;
        }

        private void EnableTools()
        {
            // Habilitar el "GroupBox" de "Atributo Clase".
            ComboBoxClassAttribute.Enabled = true;

            // Habilitar el "GroupBox" de "Algoritmos".
            ComboBoxAlgorithms.Enabled = true;

            // Habilitar el "GroupBox" de "Atributo Clase".
            // Hold-Out.
            RadioButtonHoldOut.Enabled = true;
            NumericUpDownPercentageTrainingSet.Enabled = true;
            // K-Fold Cross Validation.
            RadioButtonKFoldCrossValidation.Enabled = true;
            NumericUpDownKValue.Enabled = true;
            NumericUpDownKValue.Maximum = dataSet.Rows.Count;

            // Habilitar el botón de "Entrenar Algoritmo".
            ButtonTrainAlgorithm.Enabled = true;
        }

        private void ComboBoxClassAttribute_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar si el índice es válido.
            if (ComboBoxClassAttribute.SelectedIndex != -1)
            {
                // El índice es válido.
                // Actualizar el atributo clase.
                UpdateClassAttribute();
            }
        }

        private void UpdateClassAttribute()
        {
            // Verificar el tipo del archivo.
            if (dataSetDataFile == null)
            {
                // Archivo CSV.
                // Actualizar la "Label" del "Tipo".
                LabelTypeValue.Text = "Categórico";
            }
            else
            {
                // Archivo DATA.
                // Asignar el atributo clase seleccionado.
                classAttribute = dataSetDataFile.Attributes[ComboBoxClassAttribute.SelectedIndex];

                // Verificar el tipo del atributo.
                if (classAttribute.GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                {
                    // El atributo es numérico.
                    // Actualizar la "Label" del "Tipo".
                    LabelTypeValue.Text = "Numérico";
                }
                else
                {
                    // El atributo es categórico.
                    // Actualizar la "Label" del "Tipo".
                    LabelTypeValue.Text = "Categórico";
                }
            }
        }

        private void ButtonTrainAlgorithm_Click(object sender, EventArgs e)
        {
            // Realizar lo debido dependiendo del algoritmo seleccionado.
            switch ((Algorithms)ComboBoxAlgorithms.SelectedIndex)
            {
                case Algorithms.ZeroR:

                    // Algoritmo ZeroR.
                    // Verificar el tipo de metodología a utilizar.
                    if (RadioButtonHoldOut.Checked)
                    {
                        // Hold-Out.
                        // Obtener los conjuntos.
                        List<DataTable> holdOutSets = HoldOut();

                        // Verificar que los conjuntos se hayan obtenido correctamente.
                        if (holdOutSets == null)
                        {
                            // Los conjuntos no se obtuvieron correctamente.
                            return;
                        }

                        // Restaurar las herramientas y variables necesarias al generar un modelo.
                        SoftResetToolsAndVariables();

                        // Obtener la matriz de confusión con los conjuntos.
                        List<DataTable> confusionMatrix = new List<DataTable>() { ZeroR(holdOutSets[0], holdOutSets[1]) };

                        // Inicializar Form "ConfusionMatrices".
                        ConfusionMatrices confusionMatricesForm = new ConfusionMatrices(confusionMatrix)
                        {
                            TopLevel = false,
                            Visible = true,
                            FormBorderStyle = FormBorderStyle.None,
                            Dock = DockStyle.Fill
                        };

                        // Agregar Form "ConfusionMatrices" al panel.
                        PanelMachineLearningAlgorithm.Controls.Add(confusionMatricesForm);

                        // Verificar el tipo del atributo clase.
                        if (classAttribute.GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                        {
                            // El atributo es numérico.
                            // Obtener el error cuadrático medio.
                            LabelMeanSquaredErrorValue.Text = GetAverageMeanSquaredError(confusionMatrix, new List<DataTable>() { holdOutSets[1] }).ToString(); 
                        }
                        else
                        {
                            // El atributo es categórico.
                            // Obtener exactitud.
                            LabelAccuracyValue.Text = confusionMatricesForm.ConfusionMatricesAccuracy[0].ToString();
                        }
                    }
                    else
                    {
                        // K-Fold Cross Validation.
                        // Obtener los conjuntos.
                        List<DataTable> kFoldSets = KFoldCrossValidation();

                        // Restaurar las herramientas y variables necesarias al generar un modelo.
                        SoftResetToolsAndVariables();

                        // Lista para almacenar la matriz de confusión de cada "K".
                        List<DataTable> confusionMatrices = new List<DataTable>();

                        // Lista para almacenar los conjuntos unidos.
                        List<DataTable> mergedKFoldSets = new List<DataTable>();

                        // Obtener la matriz de confusión de cada "K".
                        foreach (DataTable kSet in kFoldSets)
                        {
                            mergedKFoldSets.Add(MergeSets(kFoldSets, kSet));
                            confusionMatrices.Add(ZeroR(kSet, mergedKFoldSets[mergedKFoldSets.Count - 1]));
                        }

                        // Inicializar Form "ConfusionMatrices".
                        ConfusionMatrices confusionMatricesForm = new ConfusionMatrices(confusionMatrices)
                        {
                            TopLevel = false,
                            Visible = true,
                            FormBorderStyle = FormBorderStyle.None,
                            Dock = DockStyle.Fill
                        };

                        // Agregar Form "ConfusionMatrices" al panel.
                        PanelMachineLearningAlgorithm.Controls.Add(confusionMatricesForm);

                        // Verificar el tipo del atributo clase.
                        if (classAttribute.GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                        {
                            // El atributo es numérico.
                            // Obtener el error cuadrático medio.
                            LabelMeanSquaredErrorValue.Text = GetAverageMeanSquaredError(confusionMatrices, mergedKFoldSets).ToString();
                        }
                        else
                        {
                            // El atributo es categórico.
                            // Obtener exactitud.
                            LabelAccuracyValue.Text = confusionMatricesForm.ConfusionMatricesAccuracy.Average().ToString();
                        }
                    }

                    break;

                case Algorithms.OneR:

                    // Algoritmo One-R.
                    // Verificar el tipo de metodología a utilizar.
                    if (RadioButtonHoldOut.Checked)
                    {
                        // Hold-Out.
                        // Obtener los conjuntos.
                        List<DataTable> holdOutSets = HoldOut();

                        // Verificar que los conjuntos se hayan obtenido correctamente.
                        if (holdOutSets == null)
                        {
                            // Los conjuntos no se obtuvieron correctamente.
                            return;
                        }

                        // Restaurar las herramientas y variables necesarias al generar un modelo.
                        SoftResetToolsAndVariables();

                        // Obtener la matriz de confusión con los conjuntos.
                        List<DataTable> confusionMatrix = new List<DataTable>() { OneR(holdOutSets[0], holdOutSets[1]) };

                        // Inicializar Form "ConfusionMatrices".
                        ConfusionMatrices confusionMatricesForm = new ConfusionMatrices(confusionMatrix)
                        {
                            TopLevel = false,
                            Visible = true,
                            FormBorderStyle = FormBorderStyle.None,
                            Dock = DockStyle.Fill
                        };

                        // Agregar Form "ConfusionMatrices" al panel.
                        PanelMachineLearningAlgorithm.Controls.Add(confusionMatricesForm);

                        // Verificar el tipo del atributo clase.
                        if (classAttribute.GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                        {
                            // El atributo es numérico.
                            // Obtener el error cuadrático medio.
                            LabelMeanSquaredErrorValue.Text = GetAverageMeanSquaredError(confusionMatrix, new List<DataTable>() { holdOutSets[1] }).ToString();
                        }
                        else
                        {
                            // El atributo es categórico.
                            // Obtener exactitud.
                            LabelAccuracyValue.Text = confusionMatricesForm.ConfusionMatricesAccuracy[0].ToString();
                        }
                    }
                    else
                    {
                        // K-Fold Cross Validation.
                        // Obtener los conjuntos.
                        List<DataTable> kFoldSets = KFoldCrossValidation();

                        // Restaurar las herramientas y variables necesarias al generar un modelo.
                        SoftResetToolsAndVariables();

                        // Lista para almacenar la matriz de confusión de cada "K".
                        List<DataTable> confusionMatrices = new List<DataTable>();

                        // Lista para almacenar los conjuntos unidos.
                        List<DataTable> mergedKFoldSets = new List<DataTable>();

                        // Obtener la matriz de confusión de cada "K".
                        foreach (DataTable kSet in kFoldSets)
                        {
                            mergedKFoldSets.Add(MergeSets(kFoldSets, kSet));
                            confusionMatrices.Add(OneR(kSet, mergedKFoldSets[mergedKFoldSets.Count - 1]));
                        }

                        // Inicializar Form "ConfusionMatrices".
                        ConfusionMatrices confusionMatricesForm = new ConfusionMatrices(confusionMatrices)
                        {
                            TopLevel = false,
                            Visible = true,
                            FormBorderStyle = FormBorderStyle.None,
                            Dock = DockStyle.Fill
                        };

                        // Agregar Form "ConfusionMatrices" al panel.
                        PanelMachineLearningAlgorithm.Controls.Add(confusionMatricesForm);

                        // Verificar el tipo del atributo clase.
                        if (classAttribute.GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                        {
                            // El atributo es numérico.
                            // Obtener el error cuadrático medio.
                            LabelMeanSquaredErrorValue.Text = GetAverageMeanSquaredError(confusionMatrices, mergedKFoldSets).ToString();
                        }
                        else
                        {
                            // El atributo es categórico.
                            // Obtener exactitud.
                            LabelAccuracyValue.Text = confusionMatricesForm.ConfusionMatricesAccuracy.Average().ToString();
                        }
                    }

                    break;

                case Algorithms.NaiveBayes:
                    break;

                case Algorithms.KMeans:
                    break;

                case Algorithms.KNearestNeighbors:
                    break;
            }
        }

        private DataTable ZeroR(DataTable trainingSet, DataTable testingSet)
        {
            // Variables.
            DataTable confusionMatrix = new DataTable();
            List<string> dataSetValues = new List<string>();
            List<string> trainingSetValues = new List<string>();
            Dictionary<string, int> confusionMatrixIndices = new Dictionary<string, int>();
            double[,] confusionMatrixValues;
            string classAttributeMode;

            // Llenar la lista con los valores del atributo clase.
            foreach (DataRow instance in dataSet.Rows)
            {
                dataSetValues.Add(instance[ComboBoxClassAttribute.SelectedIndex].ToString());
            }

            // Llenar la lista con los valores del atributo clase en el conjunto de entrenamiento.
            foreach (DataRow instance in trainingSet.Rows)
            {
                trainingSetValues.Add(instance[ComboBoxClassAttribute.SelectedIndex].ToString());
            }

            // Variable para almacenar los posibles valores para el atributo clase.
            var classAttributePossibleValues = dataSetValues.GroupBy(value => value);

            // Inicializar la matriz de confusión.
            confusionMatrixValues = new double[classAttributePossibleValues.Count(), classAttributePossibleValues.Count()];

            // Inicializar la "DataTable" con la matriz de confusión y el diccionario.
            for (int i = 0; i < classAttributePossibleValues.Count(); i++)
            {
                // Obtener los valores posibles.
                var possibleValue = classAttributePossibleValues.ElementAt(i);

                // Agregar a la matriz una columna y fila.
                confusionMatrix.Columns.Add(possibleValue.Key);
                confusionMatrix.Rows.Add();

                // Agregar al diccionario una entrada con el posible valor y su índice en la matriz de confusión.
                confusionMatrixIndices.Add(possibleValue.Key, i);
            }

            // Obtener la moda del atributo clase.
            classAttributeMode = trainingSetValues.GroupBy(value => value).OrderByDescending(group => group.Count()).First().Key;

            // Construir la matriz de confusión.
            foreach (DataRow instance in testingSet.Rows)
            {
                // Sumar una unidad en la casilla [modelo, objetivo].
                confusionMatrixValues[confusionMatrixIndices[classAttributeMode], confusionMatrixIndices[instance[ComboBoxClassAttribute.SelectedIndex].ToString()]]++;
            }

            // Llenar la "DataTable" con la matriz de confusión.
            for (int i = 0; i < confusionMatrix.Rows.Count; i++)
            {
                for (int j = 0; j < confusionMatrix.Columns.Count; j++)
                {
                    confusionMatrix.Rows[i][j] = confusionMatrixValues[i, j].ToString();
                }
            }

            // Retornar la matriz de confusión.
            return confusionMatrix;
        }

        private DataTable OneR(DataTable trainingSet, DataTable testingSet)
        {
            // Variables.
            DataTable confusionMatrix = new DataTable();
            double[,] confusionMatrixValues;
            List<int[,]> frequencyTables = new List<int[,]>();
            List<Dictionary<string, int>> frequencyTablesDictionaries = new List<Dictionary<string, int>>();
            List<Dictionary<int, string>> frequencyTablesReverseDictionaries = new List<Dictionary<int, string>>();
            List<double> frequencyTablesTotalError = new List<double>();
            List<Dictionary<string, string>> attributesRules = new List<Dictionary<string, string>>();
            Dictionary<string, string> lowestTotalErrorAttributeRules;
            int lowestTotalErrorAttributeIndex;

            // Obtener los posibles valores para el atributo clase.
            var classAttributePossibleValues = GetAttributePossibleValues(trainingSet.Columns[ComboBoxClassAttribute.SelectedIndex]);

            // Inicializar la matriz de confusión.
            confusionMatrixValues = new double[classAttributePossibleValues.Count(), classAttributePossibleValues.Count()];

            // Inicializar la "DataTable" con la matriz de confusión.
            for (int i = 0; i < classAttributePossibleValues.Count(); i++)
            {
                // Obtener los valores posibles.
                var possibleValue = classAttributePossibleValues.ElementAt(i);

                // Agregar a la matriz una columna y fila.
                confusionMatrix.Columns.Add(possibleValue.Key);
                confusionMatrix.Rows.Add();
            }

            // Crear una tabla de frecuencia por cada atributo.
            foreach (DataColumn attribute in trainingSet.Columns)
            {
                // Obtener los posibles valores del atributo actual.
                var attributePossibleValues = GetAttributePossibleValues(attribute);

                // Crear los diccionarios para el atributo actual.
                Dictionary<string, int> frequencyTableDictionary = new Dictionary<string, int>();
                Dictionary<int, string> frequencyTableReverseDictionary = new Dictionary<int, string>();

                // Llenar los diccionarios.
                for (int i = 0; i < attributePossibleValues.Count(); i++)
                {
                    // Obtener un posible valor del atributo actual.
                    var possibleValue = attributePossibleValues.ElementAt(i);

                    // Insertar las entradas en los diccionarios.
                    frequencyTableDictionary.Add(possibleValue.Key, i);
                    frequencyTableReverseDictionary.Add(i, possibleValue.Key);
                }

                // Insertar los diccionarios en las listas.
                frequencyTablesDictionaries.Add(frequencyTableDictionary);
                frequencyTablesReverseDictionaries.Add(frequencyTableReverseDictionary);

                // Verificar si el atributo actual no es el atributo clase.
                if (attribute != trainingSet.Columns[ComboBoxClassAttribute.SelectedIndex])
                {
                    // El atributo actual no es el atributo clase.
                    // Crear la tabla de frecuencia para el atributo actual.
                    frequencyTables.Add(new int[attributePossibleValues.Count(), classAttributePossibleValues.Count()]);
                }
                else
                {
                    // El atributo actual es el atributo clase.
                    // Crear una tabla de frecuencia vacía.
                    frequencyTables.Add(new int[0, 0]);
                }
            }

            // Llenar las tablas de frecuencia.
            foreach (DataRow instance in trainingSet.Rows)
            {
                // Recorrer todos los atributos en la instancia actual.
                for (int i = 0; i < trainingSet.Columns.Count; i++)
                {
                    // Verificar si el atributo actual no es el atributo clase.
                    if (i != ComboBoxClassAttribute.SelectedIndex)
                    {
                        // El atributo actual no es el atributo clase.
                        frequencyTables[i][frequencyTablesDictionaries[i][instance[i].ToString()], frequencyTablesDictionaries[ComboBoxClassAttribute.SelectedIndex][instance[ComboBoxClassAttribute.SelectedIndex].ToString()]]++;
                    }
                }
            }

            // Obtener las reglas y el error total de cada atributo.
            for (int i = 0; i < frequencyTables.Count; i++)
            {
                // Verificar si el índice actual no le corresponde al atributo clase.
                if (i != ComboBoxClassAttribute.SelectedIndex)
                {
                    // El índice actual no le corresponde al atributo clase.
                    // Obtener la tabla de frecuancia del atributo actual.
                    int[,] frequencyTable = frequencyTables[i];

                    // Variables.
                    Dictionary<string, string> attributeRules = new Dictionary<string, string>();
                    double totalErrorDividend = 0;
                    double totalErrorDivisor = 0;

                    // Iterar sobre las filas de la tabla de frecuencia.
                    for (int j = 0; j < frequencyTable.GetLength(0); j++)
                    {
                        // Variable para almacenar el índice de la casilla con el mayor valor.
                        int higherValueIndex = 0;

                        // Iterar sobre las columnas de la tabla de frecuencia.
                        for (int k = 0; k < frequencyTable.GetLength(1); k++)
                        {
                            // Verificar si el valor de la casilla actual es mayor al de la celda en el índice de la casilla con el mayor valor.
                            if (frequencyTable[j, k] > frequencyTable[j, higherValueIndex])
                            {
                                // El valor es mayor.
                                // Cambiar el índice de la casilla con el mayor valor.
                                higherValueIndex = k;
                            }

                            // Sumar el valor de la casilla actual al dividendo y al divisor del error total de la tabla de frecuencia.
                            totalErrorDividend += frequencyTable[j, k];
                            totalErrorDivisor += frequencyTable[j, k];
                        }

                        // Crear una regla de la fila con la columna que indica la casilla con el mayor valor.
                        string key = frequencyTablesReverseDictionaries[i][j];
                        string value = frequencyTablesReverseDictionaries[ComboBoxClassAttribute.SelectedIndex][higherValueIndex];

                        attributeRules.Add(key, value);
                        
                        // Restarle al dividendo de la casilla con el mayot valor.
                        totalErrorDividend -= frequencyTable[j, higherValueIndex];
                    }

                    // Agregar la regla a la lista.
                    attributesRules.Add(attributeRules);

                    // Agregar el error total a la lista.
                    frequencyTablesTotalError.Add(totalErrorDividend / totalErrorDivisor);
                }
                else
                {
                    // El índice actual no le corresponde al atributo clase.
                    // Agregar un conjunto de reglas en blanco y un error total de 1.
                    attributesRules.Add(new Dictionary<string, string>());
                    frequencyTablesTotalError.Add(1);
                }
            }

            // Obtener el índice y el conjunto de reglas pertenecientes al atributo con el menor error total.
            lowestTotalErrorAttributeIndex = frequencyTablesTotalError.IndexOf(frequencyTablesTotalError.Min());
            lowestTotalErrorAttributeRules = attributesRules[lowestTotalErrorAttributeIndex];

            // Construir la matriz de confusión.
            foreach (DataRow instance in testingSet.Rows)
            {
                // Sumar una unidad en la casilla [modelo, objetivo].
                int i = frequencyTablesDictionaries[ComboBoxClassAttribute.SelectedIndex][lowestTotalErrorAttributeRules[instance[lowestTotalErrorAttributeIndex].ToString()]];
                int j = frequencyTablesDictionaries[ComboBoxClassAttribute.SelectedIndex][instance[ComboBoxClassAttribute.SelectedIndex].ToString()];

                confusionMatrixValues[i, j]++;
            }

            // Llenar la "DataTable" con la matriz de confusión.
            for (int i = 0; i < confusionMatrix.Rows.Count; i++)
            {
                for (int j = 0; j < confusionMatrix.Columns.Count; j++)
                {
                    confusionMatrix.Rows[i][j] = confusionMatrixValues[i, j].ToString();
                }
            }

            // Retornar la matriz de confusión.
            return confusionMatrix;
        }

        private List<DataTable> HoldOut()
        {
            // "DataTables" para el conjunto de entrenamiento y el de prueba.
            DataTable trainingSet = dataSet.Clone();
            DataTable testingSet = dataSet.Clone();

            // Variables para almacenar el numero de instancias para el conjunto de entrenamiento y el de prueba.
            int trainingSetInstanceNumber = dataSet.Rows.Count * (int)NumericUpDownPercentageTrainingSet.Value / 100;
            int testingSetInstanceNumber = dataSet.Rows.Count - trainingSetInstanceNumber;

            // Verificar si el número de instancias para el conjunto de entrenamiento es menor que 1.
            if (trainingSetInstanceNumber < 1)
            {
                // El número de instancias para el conjunto de entrenamiento es menor que 1.
                // Desplegar mensaje de error y abortar.
                MessageBox.Show("Con un porcentaje del " + NumericUpDownPercentageTrainingSet.Value + "% el conjunto de entrenamiento no tendría instancias.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            // Obtener el conjunto de entrenamiento.
            for (int i = 0; i < trainingSetInstanceNumber; i++)
            {
                trainingSet.Rows.Add(dataSet.Rows[i].ItemArray);
            }

            // Obtener el conjunto de prueba.
            for (int i = 0; i < testingSetInstanceNumber; i++)
            {
                testingSet.Rows.Add(dataSet.Rows[trainingSetInstanceNumber + i].ItemArray);
            }

            // Retornar los conjuntos.
            return new List<DataTable> { trainingSet, testingSet };
        }

        private List<DataTable> KFoldCrossValidation()
        {
            // Lista para almacenar los conjuntos.
            List<DataTable> kSets = new List<DataTable>();

            // Variables para almacenar el número de instancias por conjunto.
            int kSetInstanceNumber = (int)Math.Round(dataSet.Rows.Count / (double)NumericUpDownKValue.Value);
            int lastKSetInstanceNumber = dataSet.Rows.Count - (kSetInstanceNumber * (int)NumericUpDownKValue.Value) + kSetInstanceNumber;

            // Obtener los conjuntos.
            for (int i = 0; i < NumericUpDownKValue.Value - 1; i++)
            {
                // Crear una nueva "DataTable" para un nuevo conjunto.
                DataTable kSet = dataSet.Clone();

                // Obtener el conjunto.
                for (int j = 0; j < kSetInstanceNumber; j++)
                {
                    kSet.Rows.Add(dataSet.Rows[kSetInstanceNumber * i + j].ItemArray);
                }

                // Agregar el conjunto a la lista de conjuntos.
                kSets.Add(kSet);
            }

            // Crear una nueva "DataTable" para el último conjunto.
            DataTable lastKSet = dataSet.Clone();

            // Obtener el último conjunto.
            for (int i = 0; i < lastKSetInstanceNumber; i++)
            {
                lastKSet.Rows.Add(dataSet.Rows[kSetInstanceNumber * ((int)NumericUpDownKValue.Value - 1) + i].ItemArray);
            }

            // Agregar el último conjunto a la lista de conjuntos.
            kSets.Add(lastKSet);

            // Retornar la lista de conjuntos.
            return kSets;
        }

        private double GetAverageMeanSquaredError(List<DataTable> confusionMatrices, List<DataTable> trainingSets)
        {
            // Lista para almacenar el error medio cuadrático de cada matriz de confusión.
            List<double> meanSquaredErrors = new List<double>();

            // Obtener el error medio cuadrático de cada matriz.
            for (int i = 0; i < confusionMatrices.Count; i++)
            {
                // Asignar a una "DataTable" la matriz actual.
                DataTable confusionMatrix = confusionMatrices[i];

                // Variable para almacenar la sumatoria.
                double summation = 0;

                // Iterar sobre las filas de la matriz.
                for (int j = 0; j < confusionMatrix.Rows.Count; j++)
                {
                    // Asignar a un "DataRow" la fila actual.
                    DataRow confusionMatrixRow = confusionMatrix.Rows[j];

                    // Iterar sobre las columnas de la matriz.
                    for (int k = 0; k < confusionMatrix.Columns.Count; k++)
                    {
                        // Convertir el valor en la celda actual a "int".
                        int.TryParse(confusionMatrixRow[k].ToString(), out int confusionMatrixValue);

                        // Realizar la resta del objetivo con el modelo el número de veces especificado en la celda.
                        for (int l = 0; l < confusionMatrixValue; l++)
                        {
                            summation += Math.Pow(Convert.ToDouble(confusionMatrix.Columns[k].Caption) - Convert.ToDouble(confusionMatrix.Columns[j].Caption), 2);
                        }
                    }
                }

                // Agreagar el error cuadratico medio de la matriz actual a la lista.
                meanSquaredErrors.Add(summation / trainingSets[i].Rows.Count);
            }

            // Retornar el promedio del error cuadrático medio de todas las matrices.
            return meanSquaredErrors.Average();
        }

        private DataTable MergeSets(List<DataTable> sets, DataTable exception)
        {
            DataTable mergedSet = sets[0].Clone();

            foreach (DataTable set in sets)
            {
                if (set != exception)
                {
                    mergedSet.Merge(set);
                }
            }

            return mergedSet;
        }

        private IEnumerable<IGrouping<string, string>> GetAttributePossibleValues(DataColumn attribute)
        {
            // Lista para almacenar los valores del atributo.
            List<string> attributeValues = new List<string>();

            // Llenar la lista con los valores del atributo.
            foreach (DataRow instance in dataSet.Rows)
            {
                attributeValues.Add(instance[attribute.Caption].ToString());
            }

            // Retornar los posibles valores para el atributo.
            return attributeValues.GroupBy(value => value);
        }
    }
}
