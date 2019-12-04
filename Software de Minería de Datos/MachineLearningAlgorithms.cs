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

        // Constantes.
        const int maximumIterationsWithoutChanges = 10;

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

                // Fijar el límite de K en "K-Fold Cross Validation".
                NumericUpDownKFoldCrossValidationKValue.Maximum = dataSet.Rows.Count;

                // Habilitar las herramientas.
                ComboBoxAlgorithms.SelectedIndex = 0;
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
            GroupBoxClassAttribute.Enabled = false;

            // Deshabilitar el "GroupBox" de "Algoritmos".
            GroupBoxAlgorithms.Enabled = false;

            // Deshabilitar el "GroupBox" de "Metodologías de Validación".
            GroupBoxValidationMethodologies.Enabled = false;

            // Deshabilitar el "GroupBox" de "K-Means y K-Nearest Neighbors".
            GroupBoxKMeansAndKNearestNeighbors.Enabled = false;

            // Deshabilitar el botón de "Entrenar Algoritmo".
            ButtonTrainAlgorithm.Enabled = false;
        }

        private void SoftDisableTools()
        {
            // Deshabilitar el "GroupBox" de "Metodologías de Validación".
            GroupBoxValidationMethodologies.Enabled = false;

            // Deshabilitar el "GroupBox" y "RadioButton" de "Hold-Out".
            GroupBoxHoldOut.Enabled = false;
            RadioButtonHoldOut.Enabled = false;

            // Deshabilitar el "GroupBox" y "RadioButton" de "K-Fold Cross Validation".
            GroupBoxKFoldCrossValidation.Enabled = false;
            RadioButtonKFoldCrossValidation.Enabled = false;

            // Deshabilitar el "GroupBox" de "K-Means y K-Nearest Neighbors".
            GroupBoxKMeansAndKNearestNeighbors.Enabled = false;
        }

        private void EnableTools()
        {
            // Habilitar el "GroupBox" de "Atributo Clase".
            GroupBoxClassAttribute.Enabled = true;

            // Habilitar el "GroupBox" de "Algoritmos".
            GroupBoxAlgorithms.Enabled = true;

            // Habilitar el "GroupBox" de "Metodologías de Validación".
            GroupBoxValidationMethodologies.Enabled = true;

            // Deshabilitar el "GroupBox" de "K-Means y K-Nearest Neighbors".
            GroupBoxKMeansAndKNearestNeighbors.Enabled = true;

            // Habilitar el botón de "Entrenar Algoritmo".
            ButtonTrainAlgorithm.Enabled = true;
        }

        private void ComboBoxAlgorithms_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar si el índice es válido.
            if (ComboBoxAlgorithms.SelectedIndex != -1)
            {
                // El índice es válido.
                // Deshabilitar algunas herramientas.
                SoftDisableTools();

                // Habilitar las herramientas dependiendo del algoritmo.
                switch ((Algorithms)ComboBoxAlgorithms.SelectedIndex)
                {
                    case Algorithms.ZeroR:
                    case Algorithms.OneR:
                    case Algorithms.NaiveBayes:

                        // Habilitar el "GroupBox" de "Metodologías de Validación".
                        GroupBoxValidationMethodologies.Enabled = true;

                        // Habilitar el "GroupBox" y "RadioButton" de "Hold-Out".
                        GroupBoxHoldOut.Enabled = true;
                        RadioButtonHoldOut.Enabled = true;

                        // Habilitar el "GroupBox" y "RadioButton" de "K-Fold Cross Validation".
                        GroupBoxKFoldCrossValidation.Enabled = true;
                        RadioButtonKFoldCrossValidation.Enabled = true;

                        break;

                    case Algorithms.KMeans:

                        // Habilitar el "GroupBox" de "K-Means y K-Nearest Neighbors".
                        GroupBoxKMeansAndKNearestNeighbors.Enabled = true;

                        break;

                    case Algorithms.KNearestNeighbors:

                        // Habilitar el "GroupBox" de "K-Means y K-Nearest Neighbors".
                        GroupBoxKMeansAndKNearestNeighbors.Enabled = true;

                        // Habilitar el "GroupBox" de "Metodologías de Validación".
                        GroupBoxValidationMethodologies.Enabled = true;

                        // Habilitar el "GroupBox" y "RadioButton" de "Hold-Out".
                        GroupBoxHoldOut.Enabled = true;
                        RadioButtonHoldOut.Enabled = true;
                        RadioButtonHoldOut.Checked = true;

                        break;
                }
            }
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
                    /*******************************************************/
                    /****COMENTAR SI SI SE PUEDE CON ATRIBUTOS NUMÉRICOS****/
                    /*******************************************************/
                    // Verificar si el archivo es de tipo DATA.
                    if (dataSetDataFile != null)
                    {
                        // El archivo es de tipo DATA.
                        // Verificar si atributo es numérico.
                        if (dataSetDataFile.Attributes[ComboBoxClassAttribute.SelectedIndex].GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                        {
                            // El atributo es numérico.
                            // Desplegar mensaje de error y abortar.
                            MessageBox.Show("El atributo clase debe ser categórico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Verificar el tipo de metodología a utilizar.
                    if (RadioButtonHoldOut.Checked)
                    {
                        // Hold-Out.
                        // Obtener los conjuntos.
                        List<DataTable> zeroRHoldOutSets = HoldOut();

                        // Verificar que los conjuntos se hayan obtenido correctamente.
                        if (zeroRHoldOutSets == null)
                        {
                            // Los conjuntos no se obtuvieron correctamente.
                            // Abortar.
                            return;
                        }

                        // Restaurar las herramientas y variables necesarias al generar un modelo.
                        SoftResetToolsAndVariables();

                        // Obtener la matriz de confusión con los conjuntos.
                        List<DataTable> zeroRConfusionMatrix = new List<DataTable>() { ZeroR(zeroRHoldOutSets[0], zeroRHoldOutSets[1]) };

                        // Inicializar Form "ConfusionMatrices".
                        ConfusionMatrices zeroRConfusionMatricesForm = new ConfusionMatrices(zeroRConfusionMatrix)
                        {
                            TopLevel = false,
                            Visible = true,
                            FormBorderStyle = FormBorderStyle.None,
                            Dock = DockStyle.Fill
                        };

                        // Agregar Form "ConfusionMatrices" al panel.
                        PanelMachineLearningAlgorithm.Controls.Add(zeroRConfusionMatricesForm);

                        /*******************************************************/
                        /****COMENTAR SI SI SE PUEDE CON ATRIBUTOS NUMÉRICOS****/
                        /*******************************************************/
                        // Obtener exactitud.
                        LabelAccuracyValue.Text = zeroRConfusionMatricesForm.ConfusionMatricesAccuracy[0].ToString();

                        /********************************************************/
                        /***DESCOMENTAR SI SI SE PUEDE CON ATRIBUTOS NUMÉRICOS***/
                        /********************************************************/
                        //// Verificar el tipo del archivo.
                        //if (dataSetDataFile == null)
                        //{
                        //    // Archivo CSV.
                        //    // Obtener exactitud.
                        //    LabelAccuracyValue.Text = zeroRConfusionMatricesForm.ConfusionMatricesAccuracy[0].ToString();
                        //}
                        //else
                        //{
                        //    // Archivo DATA.
                        //    // Verificar el tipo del atributo clase.
                        //    if (classAttribute.GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                        //    {
                        //        // El atributo es numérico.
                        //        // Obtener el error cuadrático medio.
                        //        LabelMeanSquaredErrorValue.Text = GetAverageMeanSquaredError(zeroRConfusionMatrix, new List<DataTable>() { zeroRHoldOutSets[1] }).ToString();
                        //    }
                        //    else
                        //    {
                        //        // El atributo es categórico.
                        //        // Obtener exactitud.
                        //        LabelAccuracyValue.Text = zeroRConfusionMatricesForm.ConfusionMatricesAccuracy[0].ToString();
                        //    }
                        //}
                    }
                    else
                    {
                        // K-Fold Cross Validation.
                        // Obtener los conjuntos.
                        List<DataTable> zeroRKFoldSets = KFoldCrossValidation();

                        // Restaurar las herramientas y variables necesarias al generar un modelo.
                        SoftResetToolsAndVariables();

                        // Lista para almacenar la matriz de confusión de cada "K".
                        List<DataTable> zeroRConfusionMatrices = new List<DataTable>();

                        // Lista para almacenar los conjuntos unidos.
                        List<DataTable> zeroRMergedKFoldSets = new List<DataTable>();

                        // Obtener la matriz de confusión de cada "K".
                        foreach (DataTable kSet in zeroRKFoldSets)
                        {
                            zeroRMergedKFoldSets.Add(MergeSets(zeroRKFoldSets, kSet));
                            zeroRConfusionMatrices.Add(ZeroR(kSet, zeroRMergedKFoldSets[zeroRMergedKFoldSets.Count - 1]));
                        }

                        // Inicializar Form "ConfusionMatrices".
                        ConfusionMatrices zeroRConfusionMatricesForm = new ConfusionMatrices(zeroRConfusionMatrices)
                        {
                            TopLevel = false,
                            Visible = true,
                            FormBorderStyle = FormBorderStyle.None,
                            Dock = DockStyle.Fill
                        };

                        // Agregar Form "ConfusionMatrices" al panel.
                        PanelMachineLearningAlgorithm.Controls.Add(zeroRConfusionMatricesForm);

                        /*******************************************************/
                        /****COMENTAR SI SI SE PUEDE CON ATRIBUTOS NUMÉRICOS****/
                        /*******************************************************/
                        // Obtener exactitud.
                        LabelAccuracyValue.Text = zeroRConfusionMatricesForm.ConfusionMatricesAccuracy.Average().ToString();

                        /********************************************************/
                        /***DESCOMENTAR SI SI SE PUEDE CON ATRIBUTOS NUMÉRICOS***/
                        /********************************************************/
                        //// Verificar el tipo del archivo.
                        //if (dataSetDataFile == null)
                        //{
                        //    // Archivo CSV.
                        //    // Obtener exactitud.
                        //    LabelAccuracyValue.Text = zeroRConfusionMatricesForm.ConfusionMatricesAccuracy.Average().ToString();
                        //}
                        //else
                        //{
                        //    // Archivo DATA.
                        //    // Verificar el tipo del atributo clase.
                        //    if (classAttribute.GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                        //    {
                        //        // El atributo es numérico.
                        //        // Obtener el error cuadrático medio.
                        //        LabelMeanSquaredErrorValue.Text = GetAverageMeanSquaredError(zeroRConfusionMatrices, zeroRMergedKFoldSets).ToString();
                        //    }
                        //    else
                        //    {
                        //        // El atributo es categórico.
                        //        // Obtener exactitud.
                        //        LabelAccuracyValue.Text = zeroRConfusionMatricesForm.ConfusionMatricesAccuracy.Average().ToString();
                        //    }
                        //}
                    }

                    break;

                case Algorithms.OneR:

                    // Algoritmo One-R.
                    /*******************************************************/
                    /****COMENTAR SI SI SE PUEDE CON ATRIBUTOS NUMÉRICOS****/
                    /*******************************************************/
                    // Verificar si el archivo es de tipo DATA.
                    if (dataSetDataFile != null)
                    {
                        // El archivo es de tipo DATA.
                        // Verificar si atributo es numérico.
                        if (dataSetDataFile.Attributes[ComboBoxClassAttribute.SelectedIndex].GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                        {
                            // El atributo es numérico.
                            // Desplegar mensaje de error y abortar.
                            MessageBox.Show("El atributo clase debe ser categórico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Verificar el tipo de metodología a utilizar.
                    if (RadioButtonHoldOut.Checked)
                    {
                        // Hold-Out.
                        // Obtener los conjuntos.
                        List<DataTable> oneRHoldOutSets = HoldOut();

                        // Verificar que los conjuntos se hayan obtenido correctamente.
                        if (oneRHoldOutSets == null)
                        {
                            // Los conjuntos no se obtuvieron correctamente.
                            return;
                        }

                        // Restaurar las herramientas y variables necesarias al generar un modelo.
                        SoftResetToolsAndVariables();

                        // Obtener la matriz de confusión con los conjuntos.
                        List<DataTable> confusionMatrix = new List<DataTable>() { OneR(oneRHoldOutSets[0], oneRHoldOutSets[1]) };

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

                        /*******************************************************/
                        /****COMENTAR SI SI SE PUEDE CON ATRIBUTOS NUMÉRICOS****/
                        /*******************************************************/
                        // Obtener exactitud.
                        LabelAccuracyValue.Text = confusionMatricesForm.ConfusionMatricesAccuracy[0].ToString();

                        /********************************************************/
                        /***DESCOMENTAR SI SI SE PUEDE CON ATRIBUTOS NUMÉRICOS***/
                        /********************************************************/
                        //// Verificar el tipo del archivo.
                        //if (dataSetDataFile == null)
                        //{
                        //    // Archivo CSV.
                        //    // Obtener exactitud.
                        //    LabelAccuracyValue.Text = confusionMatricesForm.ConfusionMatricesAccuracy[0].ToString();
                        //}
                        //else
                        //{
                        //    // Archivo DATA.
                        //    // Verificar el tipo del atributo clase.
                        //    if (classAttribute.GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                        //    {
                        //        // El atributo es numérico.
                        //        // Obtener el error cuadrático medio.
                        //        LabelMeanSquaredErrorValue.Text = GetAverageMeanSquaredError(confusionMatrix, new List<DataTable>() { oneRHoldOutSets[1] }).ToString();
                        //    }
                        //    else
                        //    {
                        //        // El atributo es categórico.
                        //        // Obtener exactitud.
                        //        LabelAccuracyValue.Text = confusionMatricesForm.ConfusionMatricesAccuracy[0].ToString();
                        //    }
                        //}
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

                        /*******************************************************/
                        /****COMENTAR SI SI SE PUEDE CON ATRIBUTOS NUMÉRICOS****/
                        /*******************************************************/
                        // Obtener exactitud.
                        LabelAccuracyValue.Text = confusionMatricesForm.ConfusionMatricesAccuracy.Average().ToString();

                        /********************************************************/
                        /***DESCOMENTAR SI SI SE PUEDE CON ATRIBUTOS NUMÉRICOS***/
                        /********************************************************/
                        //// Verificar el tipo del archivo.
                        //if (dataSetDataFile == null)
                        //{
                        //    // Archivo CSV.
                        //    // Obtener exactitud.
                        //    LabelAccuracyValue.Text = confusionMatricesForm.ConfusionMatricesAccuracy.Average().ToString();
                        //}
                        //else
                        //{
                        //    // Archivo DATA.
                        //    // Verificar el tipo del atributo clase.
                        //    if (classAttribute.GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                        //    {
                        //        // El atributo es numérico.
                        //        // Obtener el error cuadrático medio.
                        //        LabelMeanSquaredErrorValue.Text = GetAverageMeanSquaredError(confusionMatrices, mergedKFoldSets).ToString();
                        //    }
                        //    else
                        //    {
                        //        // El atributo es categórico.
                        //        // Obtener exactitud.
                        //        LabelAccuracyValue.Text = confusionMatricesForm.ConfusionMatricesAccuracy.Average().ToString();
                        //    }
                        //}
                    }

                    break;

                case Algorithms.NaiveBayes:

                    // Algoritmo Naïve Bayes.
                    /*******************************************************/
                    /****COMENTAR SI SI SE PUEDE CON ATRIBUTOS NUMÉRICOS****/
                    /*******************************************************/
                    // Verificar si el archivo es de tipo DATA.
                    if (dataSetDataFile != null)
                    {
                        // El archivo es de tipo DATA.
                        // Verificar si atributo es numérico.
                        if (dataSetDataFile.Attributes[ComboBoxClassAttribute.SelectedIndex].GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                        {
                            // El atributo es numérico.
                            // Desplegar mensaje de error y abortar.
                            MessageBox.Show("El atributo clase debe ser categórico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Verificar el tipo de metodología a utilizar.
                    if (RadioButtonHoldOut.Checked)
                    {
                        // Hold-Out.
                        // Obtener los conjuntos.
                        List<DataTable> naiveBayesHoldOutSets = HoldOut();

                        // Verificar que los conjuntos se hayan obtenido correctamente.
                        if (naiveBayesHoldOutSets == null)
                        {
                            // Los conjuntos no se obtuvieron correctamente.
                            return;
                        }

                        // Restaurar las herramientas y variables necesarias al generar un modelo.
                        SoftResetToolsAndVariables();

                        // Obtener la matriz de confusión con los conjuntos.
                        List<DataTable> confusionMatrix = new List<DataTable>() { NaiveBayes(naiveBayesHoldOutSets[0], naiveBayesHoldOutSets[1]) };

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

                        /*******************************************************/
                        /****COMENTAR SI SI SE PUEDE CON ATRIBUTOS NUMÉRICOS****/
                        /*******************************************************/
                        // Obtener exactitud.
                        LabelAccuracyValue.Text = confusionMatricesForm.ConfusionMatricesAccuracy[0].ToString();

                        /********************************************************/
                        /***DESCOMENTAR SI SI SE PUEDE CON ATRIBUTOS NUMÉRICOS***/
                        /********************************************************/
                        //// Verificar el tipo del archivo.
                        //if (dataSetDataFile == null)
                        //{
                        //    // Archivo CSV.
                        //    // Obtener exactitud.
                        //    LabelAccuracyValue.Text = confusionMatricesForm.ConfusionMatricesAccuracy[0].ToString();
                        //}
                        //else
                        //{
                        //    // Archivo DATA.
                        //    // Verificar el tipo del atributo clase.
                        //    if (classAttribute.GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                        //    {
                        //        // El atributo es numérico.
                        //        // Obtener el error cuadrático medio.
                        //        LabelMeanSquaredErrorValue.Text = GetAverageMeanSquaredError(confusionMatrix, new List<DataTable>() { naiveBayesHoldOutSets[1] }).ToString();
                        //    }
                        //    else
                        //    {
                        //        // El atributo es categórico.
                        //        // Obtener exactitud.
                        //        LabelAccuracyValue.Text = confusionMatricesForm.ConfusionMatricesAccuracy[0].ToString();
                        //    }
                        //}
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
                            confusionMatrices.Add(NaiveBayes(kSet, mergedKFoldSets[mergedKFoldSets.Count - 1]));
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

                        /*******************************************************/
                        /****COMENTAR SI SI SE PUEDE CON ATRIBUTOS NUMÉRICOS****/
                        /*******************************************************/
                        // Obtener exactitud.
                        LabelAccuracyValue.Text = confusionMatricesForm.ConfusionMatricesAccuracy.Average().ToString();

                        /********************************************************/
                        /***DESCOMENTAR SI SI SE PUEDE CON ATRIBUTOS NUMÉRICOS***/
                        /********************************************************/
                        //// Verificar el tipo del archivo.
                        //if (dataSetDataFile == null)
                        //{
                        //    // Archivo CSV.
                        //    // Obtener exactitud.
                        //    LabelAccuracyValue.Text = confusionMatricesForm.ConfusionMatricesAccuracy.Average().ToString();
                        //}
                        //else
                        //{
                        //    // Archivo DATA.
                        //    // Verificar el tipo del atributo clase.
                        //    if (classAttribute.GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                        //    {
                        //        // El atributo es numérico.
                        //        // Obtener el error cuadrático medio.
                        //        LabelMeanSquaredErrorValue.Text = GetAverageMeanSquaredError(confusionMatrices, mergedKFoldSets).ToString();
                        //    }
                        //    else
                        //    {
                        //        // El atributo es categórico.
                        //        // Obtener exactitud.
                        //        LabelAccuracyValue.Text = confusionMatricesForm.ConfusionMatricesAccuracy.Average().ToString();
                        //    }
                        //}
                    }

                    break;

                case Algorithms.KMeans:

                    // Algoritmo K-Means.
                    // Verificar si el archivo es de tipo CSV.
                    if (dataSetDataFile == null)
                    {
                        // El archivo es de tipo CSV.
                        // Desplegar mensaje de error y abortar.
                        MessageBox.Show("El conjunto de datos no tiene atributos numéricos u ordinales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Restaurar las herramientas y variables necesarias al generar un modelo.
                    SoftResetToolsAndVariables();

                    // Inicializar Form "KIntancesAndKClustersInformation".
                    KInstancesAndClusters kInstancesAndClustersForm = new KInstancesAndClusters(KMeans())
                    {
                        TopLevel = false,
                        Visible = true,
                        FormBorderStyle = FormBorderStyle.None,
                        Dock = DockStyle.Fill
                    };

                    // Agregar Form "KIntancesAndKClustersInformation" al panel.
                    PanelMachineLearningAlgorithm.Controls.Add(kInstancesAndClustersForm);

                    break;

                case Algorithms.KNearestNeighbors:

                    // Algoritmo K-Nearest Neighbors.
                    // Verificar si el archivo es de tipo CSV.
                    if (dataSetDataFile == null)
                    {
                        // El archivo es de tipo CSV.
                        // Desplegar mensaje de error y abortar.
                        MessageBox.Show("El conjunto de datos no tiene atributos numéricos u ordinales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

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

                    // Inicializar Form "KIntancesAndKClustersInformation".
                    InstancesAndKNearestNeighbors instancesAndKNearestNeighborsForm = new InstancesAndKNearestNeighbors(dataSetDataFile, ComboBoxClassAttribute.SelectedIndex, KNearestNeighbors(holdOutSets[0], holdOutSets[1]))
                    {
                        TopLevel = false,
                        Visible = true,
                        FormBorderStyle = FormBorderStyle.None,
                        Dock = DockStyle.Fill
                    };

                    // Agregar Form "KIntancesAndKClustersInformation" al panel.
                    PanelMachineLearningAlgorithm.Controls.Add(instancesAndKNearestNeighborsForm);

                    // Verificar el tipo del archivo.
                    if (dataSetDataFile == null)
                    {
                        // Archivo CSV.
                        // Obtener los parámetros para calcular la exactitud promedio.
                        double correctlyClassifiedInstances = instancesAndKNearestNeighborsForm.ClassifiedKInstancesAccuracy.Sum();
                        double numberOfInstances = instancesAndKNearestNeighborsForm.ClassifiedKInstancesAccuracy.Count;

                        // Obtener la exactitud promedio.
                        LabelAccuracyValue.Text = (correctlyClassifiedInstances / numberOfInstances).ToString();
                    }
                    else
                    {
                        // Archivo DATA.
                        // Verificar el tipo del atributo clase.
                        if (classAttribute.GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                        {
                            // El atributo es numérico.
                            double meanSquaredErrorSummation = instancesAndKNearestNeighborsForm.ClassifiedKInstancesMeanSquaredError.Sum();
                            double numberOfInstances = instancesAndKNearestNeighborsForm.ClassifiedKInstancesMeanSquaredError.Count;

                            // Obtener el error cuadrático medio.
                            LabelMeanSquaredErrorValue.Text = (meanSquaredErrorSummation / numberOfInstances).ToString();
                        }
                        else
                        {
                            // El atributo es categórico.
                            // Obtener los parámetros para calcular la exactitud promedio.
                            double correctlyClassifiedInstances = instancesAndKNearestNeighborsForm.ClassifiedKInstancesAccuracy.Sum();
                            double numberOfInstances = instancesAndKNearestNeighborsForm.ClassifiedKInstancesAccuracy.Count;

                            // Obtener la exactitud promedio.
                            LabelAccuracyValue.Text = (correctlyClassifiedInstances / numberOfInstances).ToString();
                        }
                    }

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

        private DataTable NaiveBayes(DataTable trainingSet, DataTable testingSet)
        {
            // Variables.
            DataTable confusionMatrix = new DataTable();
            double[,] confusionMatrixValues;
            List<double[,]> frequencyTables = new List<double[,]>();
            List<double[,]> probabilityTables = new List<double[,]>();
            List<int[,]> numericalFrequencyTablesRowIndices = new List<int[,]>();
            List<Dictionary<string, int>> attributeTablesDictionaries = new List<Dictionary<string, int>>();
            List<string> modelPredictions = new List<string>();
            List<string> objectiveValues = new List<string>();

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

            // Crear una tabla de frecuencia y de probabilidad por cada atributo.
            for (int i = 0; i < trainingSet.Columns.Count; i++)
            {
                // Obtener el atributo actual.
                DataColumn attribute = trainingSet.Columns[i];

                // Obtener los posibles valores del atributo actual.
                var attributePossibleValues = GetAttributePossibleValues(attribute);

                // Crear los diccionarios para el atributo actual.
                Dictionary<string, int> frequencyTableDictionary = new Dictionary<string, int>();
                Dictionary<int, string> frequencyTableReverseDictionary = new Dictionary<int, string>();

                // Llenar los diccionarios.
                for (int j = 0; j < attributePossibleValues.Count(); j++)
                {
                    // Obtener un posible valor del atributo actual.
                    var possibleValue = attributePossibleValues.ElementAt(j);

                    // Insertar las entradas en los diccionarios.
                    frequencyTableDictionary.Add(possibleValue.Key, j);
                    frequencyTableReverseDictionary.Add(j, possibleValue.Key);
                }

                // Insertar el diccionario del atributo en la lista.
                attributeTablesDictionaries.Add(frequencyTableDictionary);

                // Verificar si el atributo actual es el atributo clase.
                if (attribute == trainingSet.Columns[ComboBoxClassAttribute.SelectedIndex])
                {
                    // El atributo actual es el atributo clase.
                    // Crear la tabla de frecuencia y de probabilidad para el atributo clase.
                    frequencyTables.Add(new double[1, classAttributePossibleValues.Count()]);
                    probabilityTables.Add(new double[1, classAttributePossibleValues.Count()]);
                    numericalFrequencyTablesRowIndices.Add(new int[0, 0]);
                }
                else
                {
                    // El atributo actual no es el atributo clase.
                    // Verificar el tipo del archivo.
                    if (dataSetDataFile == null)
                    {
                        // Archivo CSV.
                        // Crear la tabla de frecuencia y de probabilidad para el atributo actual.
                        frequencyTables.Add(new double[attributePossibleValues.Count(), classAttributePossibleValues.Count()]);
                        probabilityTables.Add(new double[attributePossibleValues.Count(), classAttributePossibleValues.Count()]);
                        numericalFrequencyTablesRowIndices.Add(new int[0, 0]);
                    }
                    else
                    {
                        // Archivo DATA.
                        // Verificar el tipo del atributo.
                        if (dataSetDataFile.Attributes[i].GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                        {
                            // Atributo numérico.
                            // Crear la tabla de frecuencia y de probabilidad para el atributo actual.
                            frequencyTables.Add(new double[trainingSet.Rows.Count, classAttributePossibleValues.Count()]);
                            probabilityTables.Add(new double[2, classAttributePossibleValues.Count()]);
                            numericalFrequencyTablesRowIndices.Add(new int[1, classAttributePossibleValues.Count()]);
                        }
                        else
                        {
                            // Atributo categórico.
                            // Crear la tabla de frecuencia y de probabilidad para el atributo actual.
                            frequencyTables.Add(new double[attributePossibleValues.Count(), classAttributePossibleValues.Count()]);
                            probabilityTables.Add(new double[attributePossibleValues.Count(), classAttributePossibleValues.Count()]);
                            numericalFrequencyTablesRowIndices.Add(new int[0, 0]);
                        }
                    }
                }
            }

            // Llenar las tablas de frecuencia y de probabilidad.
            foreach (DataRow instance in trainingSet.Rows)
            {
                // Recorrer todos los atributos en la instancia actual.
                for (int i = 0; i < trainingSet.Columns.Count; i++)
                {
                    // Verificar si el atributo actual no es el atributo clase.
                    if (i == ComboBoxClassAttribute.SelectedIndex)
                    {
                        // El atributo actual es el atributo clase.
                        // Obtener el índice.
                        int column = attributeTablesDictionaries[ComboBoxClassAttribute.SelectedIndex][instance[ComboBoxClassAttribute.SelectedIndex].ToString()];
                        
                        // Agregar una unidad a la casilla de la tabla de frecuencia.
                        frequencyTables[i][0, column]++;
                    }
                    else
                    {
                        // El atributo actual no es el atributo clase.
                        // Verificar el tipo de archivo.
                        if (dataSetDataFile == null)
                        {
                            // Archivo CSV.
                            // Obtener los índices.
                            int row = attributeTablesDictionaries[i][instance[i].ToString()];
                            int column = attributeTablesDictionaries[ComboBoxClassAttribute.SelectedIndex][instance[ComboBoxClassAttribute.SelectedIndex].ToString()];

                            // Agregar una unidad a la casilla de la tabla de frecuencia.
                            frequencyTables[i][row, column]++;
                        }
                        else
                        {
                            // Archivo DATA.
                            // Verificar el tipo del atributo.
                            if (dataSetDataFile.Attributes[i].GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                            {
                                // Atributo numérico.
                                // Obtener los índices.
                                int column = attributeTablesDictionaries[ComboBoxClassAttribute.SelectedIndex][instance[ComboBoxClassAttribute.SelectedIndex].ToString()];
                                int row = numericalFrequencyTablesRowIndices[i][0, column]++;

                                // Agregar una unidad a la casilla de la tabla de frecuencia.
                                frequencyTables[i][row, column] = Convert.ToDouble(instance[i]);
                            }
                            else
                            {
                                // Atributo categórico.
                                // Obtener los índices.
                                int row = attributeTablesDictionaries[i][instance[i].ToString()];
                                int column = attributeTablesDictionaries[ComboBoxClassAttribute.SelectedIndex][instance[ComboBoxClassAttribute.SelectedIndex].ToString()];

                                // Agregar una unidad a la casilla de la tabla de frecuencia.
                                frequencyTables[i][row, column]++;
                            }
                        }
                    }
                }
            }

            // Agregar una unidad a todas las tablas de frecuencia.
            for (int i = 0; i < frequencyTables.Count; i++)
            {
                // Verificar si el índice no es del atributo clase.
                if (i != ComboBoxClassAttribute.SelectedIndex)
                {
                    // El índice no es del atributo clase.
                    // Verificar el tipo del archivo.
                    if (dataSetDataFile == null)
                    {
                        // Archivo CSV.
                        // Obtener la tabla de frecuencia.
                        double[,] frequencyTable = frequencyTables[i];

                        // Iterar sobre las filas.
                        for (int j = 0; j < frequencyTable.GetLength(0); j++)
                        {
                            // Iterar sobre las columnas.
                            for (int k = 0; k < frequencyTable.GetLength(1); k++)
                            {
                                // Sumar una unidad a la casilla.
                                frequencyTable[j, k]++;
                            }
                        }
                    }
                    else
                    {
                        // Verificar si el atributo no es numérico.
                        if (dataSetDataFile.Attributes[i].GetDataTypeIndex() != DataFileAttribute.AttributeDataType.Numeric)
                        {
                            // El atributo no es numérico.
                            // Obtener la tabla de frecuencia.
                            double[,] frequencyTable = frequencyTables[i];

                            // Iterar sobre las filas.
                            for (int j = 0; j < frequencyTable.GetLength(0); j++)
                            {
                                // Iterar sobre las columnas.
                                for (int k = 0; k < frequencyTable.GetLength(1); k++)
                                {
                                    // Sumar una unidad a la casilla.
                                    frequencyTable[j, k]++;
                                }
                            }
                        }
                    }
                }
            }

            // Calcular las probabilidades de cada valor de cada atributo con respecto a la clase.
            for (int i = 0; i < probabilityTables.Count; i++)
            {
                // Obtener la tabla de frecuencia y de probabilidad actual.
                double[,] frequencyTable = frequencyTables[i];
                double[,] probabilityTable = probabilityTables[i];

                // Verificar si la tabla de probabilidad actual pertenece al atributo clase.
                if (i == ComboBoxClassAttribute.SelectedIndex)
                {
                    // La tabla de probabilidad actual pertenece al atributo clase.
                    // Dividir cada columna sobre el número de instancias del conjunto de entrenamiento.
                    for (int j = 0; j < probabilityTable.GetLength(1); j++)
                    {
                        probabilityTable[0, j] = frequencyTable[0, j] / trainingSet.Rows.Count;
                    }
                }
                else
                {
                    // La tabla de probabilidad actual no pertenece al atributo clase.
                    // Verificar el tipo de archivo.
                    if (dataSetDataFile == null)
                    {
                        // Archivo CSV.
                        // Iterar sobre las columnas de la tabla.
                        for (int k = 0; k < probabilityTable.GetLength(1); k++)
                        {
                            // Iterar sobre las filas de la tabla.
                            for (int j = 0; j < probabilityTable.GetLength(0); j++)
                            {
                                // Dividir cada columna sobre el número de instancias para la misma columna en el atributo clase.
                                probabilityTable[j, k] = frequencyTable[j, k] / GetColumnSummation(frequencyTable, k);
                            }
                        }
                    }
                    else
                    {
                        // Archivo DATA.
                        // Verificar el tipo del atributo.
                        if (dataSetDataFile.Attributes[i].GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                        {
                            // Atributo numérico.
                            // Iterar sobre las columnas de la tabla.
                            for (int k = 0; k < frequencyTable.GetLength(1); k++)
                            {
                                // Lista para almacenar los valores del atributo en cada valor de la clase.
                                List<double> attributeClassValues = new List<double>();

                                // Iterar sobre las filas de la tabla.
                                for (int j = 0; j < numericalFrequencyTablesRowIndices[i][0, k]; j++)
                                {
                                    // Agregar el valor del atributo a la lista.
                                    attributeClassValues.Add(frequencyTable[j, k]);
                                }

                                // Obtener la media y la desviación estándar de los valores.
                                probabilityTable[0, k] = attributeClassValues.Count == 0 ? 0 : attributeClassValues.Average();
                                probabilityTable[1, k] = GetStandardDeviation(attributeClassValues);
                            }
                        }
                        else
                        {
                            // Atributo categórico.
                            // Iterar sobre las columnas de la tabla.
                            for (int k = 0; k < probabilityTable.GetLength(1); k++)
                            {
                                // Iterar sobre las filas de la tabla.
                                for (int j = 0; j < probabilityTable.GetLength(0); j++)
                                {
                                    // Dividir cada columna sobre el número de instancias para la misma columna en el atributo clase.
                                    probabilityTable[j, k] = frequencyTable[j, k] / GetColumnSummation(frequencyTable, k);
                                }
                            }
                        }
                    }
                }
            }

            // Predecir la clase para cada instancia en el conjunto de prueba.
            foreach (DataRow instance in testingSet.Rows)
            {
                // Lista para almacenar la probabilidad de las clases.
                List<double> classProbabilities = new List<double>();

                // Obtener la probabilidad de cada clase.
                foreach (var possibleValue in classAttributePossibleValues)
                {
                    // Variable para calcular la probabilidad.
                    double classProbability = 1;

                    // Obtener la probabilidad de cada valor de cada atributo en la instancia actual.
                    for (int i = 0; i < testingSet.Columns.Count; i++)
                    {
                        // Verificar si el atributo actual es el atributo clase.
                        if (i == ComboBoxClassAttribute.SelectedIndex)
                        {
                            // El atributo actual es el atributo clase.
                            // Obtener la probabilidad del valor del atributo con la clase actual.
                            classProbability *= probabilityTables[i][0, attributeTablesDictionaries[i][possibleValue.Key]];
                        }
                        else
                        {
                            // El atributo actual no es el atributo clase.
                            // Verificar el tipo del archivo.
                            if (dataSetDataFile == null)
                            {
                                // Archivo CSV.
                                // Obtener los índices de la probabilidad del valor del atributo con la clase actual.
                                int row = attributeTablesDictionaries[i][instance[i].ToString()];
                                int column = attributeTablesDictionaries[ComboBoxClassAttribute.SelectedIndex][possibleValue.Key];

                                // // Obtener la probabilidad del valor del atributo con la clase actual.
                                classProbability *= probabilityTables[i][row, column];
                            }
                            else
                            {
                                // Archivo DATA.
                                // Verificar el tipo del atributo.
                                if (dataSetDataFile.Attributes[i].GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                                {
                                    // Atributo numérico.
                                    // Obtener el índice de la clase actual.
                                    int column = attributeTablesDictionaries[ComboBoxClassAttribute.SelectedIndex][possibleValue.Key];

                                    // Obtener la media y la desviación estandar de la tabla de probabilidad del atributo.
                                    double mean = probabilityTables[i][0, column];
                                    double standardDeviation = probabilityTables[i][1, column]; ;

                                    // Obtener la probabilidad del valor del atributo con la clase actual.
                                    classProbability *= GetDensityFunction(Convert.ToDouble(instance[i]), mean, standardDeviation);
                                }
                                else
                                {
                                    // Atributo categórico.
                                    // Obtener los índices de la probabilidad del valor del atributo con la clase actual.
                                    int row = attributeTablesDictionaries[i][instance[i].ToString()];
                                    int column = attributeTablesDictionaries[ComboBoxClassAttribute.SelectedIndex][possibleValue.Key];

                                    // Obtener la probabilidad del valor del atributo con la clase actual.
                                    classProbability *= probabilityTables[i][row, column];
                                }
                            }
                        }
                    }

                    // Agregar la probabilida de la clase con la instancia a la lista.
                    classProbabilities.Add(classProbability);
                }

                // Agregar a lista el valor objetivo de la clase en la instancia.
                objectiveValues.Add(instance[ComboBoxClassAttribute.SelectedIndex].ToString());

                // Agregar a lista de predicciones la clase predicha por el modelo.
                modelPredictions.Add(classAttributePossibleValues.ElementAt(classProbabilities.IndexOf(classProbabilities.Max())).Key);
            }

            // Construir la matriz de confusión.
            for (int i = 0; i < objectiveValues.Count; i++)
            {
                // Obtener los índices de la matriz de confusión.
                int row = attributeTablesDictionaries[ComboBoxClassAttribute.SelectedIndex][modelPredictions[i]];
                int column = attributeTablesDictionaries[ComboBoxClassAttribute.SelectedIndex][objectiveValues[i]];

                // Sumar una unidad en la casilla [modelo, objetivo].
                confusionMatrixValues[row, column]++;
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

        private double GetColumnSummation(double[,] table, int column)
        {
            // Variable para almacenar la sumatoria.
            double summation = 0;

            // Iterar sobre las filas en la misma columna.
            for (int i = 0; i < table.GetLength(0); i++)
            {
                summation += table[i, column];
            }

            // Retornar la sumatoria.
            return summation;
        }

        private double GetStandardDeviation(List<double> values)
        {
            // Variables.
            double mean = values.Count == 0 ? 0 : values.Average();
            double standardDeviation = Math.Sqrt(values.Sum(value => Math.Pow(value - mean, 2)) / values.Count);

            // Verificar si la desviación estándar es válida.
            if (double.IsNaN(standardDeviation))
            {
                // La desviación estándar es inválida.
                // Retornar 0.
                return 0;
            }
            else
            {
                // La desviación estándar es válida.
                // Retornar la desviación estándar del conjunto de valores.
                return standardDeviation;
            }
        }

        private double GetDensityFunction(double x, double mean, double standardDeviation)
        {
            // Retornar la función de densidad.
            return 1 / (Math.Sqrt(2 * Math.PI) * standardDeviation) * Math.Pow(Math.E, - (Math.Pow(x - mean, 2) / (2 * Math.Pow(standardDeviation, 2))));
        }

        private List<List<DataTable>> KMeans()
        {
            // Variables.
            List<DataTable> kInstances = new List<DataTable>();
            List<DataTable> kClusters = new List<DataTable>();
            Random numberGenerator = new Random();
            List<int> numericalAttributesIndices = new List<int>();
            List<int> ordinalAttributesIndices = new List<int>();
            List<List<double>> numericalAttributesValues = new List<List<double>>();
            List<List<double>> ordinalAttributesValues = new List<List<double>>();
            List<List<int>> kClustersIndices = new List<List<int>>();
            int iterationsWithoutChanges = 0;

            // Obtener los índices de los atributos numéricos u ordinales.
            for (int i = 0; i < dataSet.Columns.Count; i++)
            {
                // Obtener el atributo actual.
                DataFileAttribute attribute = dataSetDataFile.Attributes[i];

                // Verificar si el atributo es numérico.
                if (attribute.GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                {
                    // El atributo es numérico.
                    // Agregar el índice del atributo a la lista.
                    numericalAttributesIndices.Add(i);
                }
                else
                {
                    // El atributo no es numérico.
                    // Verificar si el atributo es ordinal.
                    if (attribute.GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Ordinal)
                    {
                        // El atributo es ordinal.
                        // Agregar el índice del atributo a la lista.
                        ordinalAttributesIndices.Add(i);
                    }
                }
            }

            // Verificar si no hay atributos numéricos u ordinales.
            if (numericalAttributesIndices.Count == 0 && ordinalAttributesIndices.Count == 0)
            {
                // No hay atributos numéricos u ordinales.
                MessageBox.Show("El conjunto de datos no tiene atributos numéricos u ordinales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            // Obtener los valores de los atributos numéricos.
            foreach (int index in numericalAttributesIndices)
            {
                // Lista para almacenar los valores del atributo.
                List<double> attributeValues = new List<double>();

                // Recorrer todas las instancias del conjunto de datos.
                foreach (DataRow instance in dataSet.Rows)
                {
                    // Verificar que el valor sea numérico.
                    if (double.TryParse(instance[index].ToString(), out double parsedValue))
                    {
                        // El valor es numérico.
                        // Agregar el valor a lista.
                        attributeValues.Add(parsedValue);
                    }
                    else
                    {
                        // El valor no es numérico.
                        // Desplegar mensaje de error y abortar.
                        MessageBox.Show("El atributo \"" + dataSet.Columns[index].Caption + "\" tiene valores inválidos (\"" + instance[index] + "\").", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }

                // Agregar los valores del atributo a la lista.
                numericalAttributesValues.Add(attributeValues);
            }

            // Obtener los valores de los atributos ordinales.
            foreach (int index in ordinalAttributesIndices)
            {
                // Obtener los posibles valores para el atributo ordinal.
                var ordinalAttributePossibleValues = GetAttributePossibleValues(dataSet.Columns[index]);

                // Utilizar un "Form" para obtener el valor numérico de cada atributo.
                using (OrdinalAttributeNormalization ordinalAttributeNormalizationForm = new OrdinalAttributeNormalization(ordinalAttributePossibleValues))
                {
                    // Mostrar el "Form".
                    if (ordinalAttributeNormalizationForm.ShowDialog() == DialogResult.OK)
                    {
                        // Crear un diccionario para el atributo ordinal.
                        Dictionary<string, double> ordinalAttributeDictionary = new Dictionary<string, double>();

                        // Lista para almacenar los valores del atributo.
                        List<double> attributeValues = new List<double>();

                        // Obtener la lista de los valores numéricos del atributo.
                        List<int> numericalValues = ordinalAttributeNormalizationForm.OrdinalAttributePossibleValuesNumericalValues;

                        // Normalizar los valores del atributo ordinal e insertarlos en el diccionario.
                        for (int i = 0; i < ordinalAttributePossibleValues.Count(); i++)
                        {
                            ordinalAttributeDictionary.Add(ordinalAttributePossibleValues.ElementAt(i).Key, GetNumericalValueNormalization(numericalValues[i], numericalValues.Count));
                        }

                        // Normalizar el conjunto de datos.
                        foreach (DataRow instance in dataSet.Rows)
                        {
                            attributeValues.Add(ordinalAttributeDictionary[instance[index].ToString()]);
                        }

                        // Agregar los valores del atributo a la lista.
                        ordinalAttributesValues.Add(attributeValues);
                    }
                }
            }

            // Crear las K instancias.
            for (int i = 0; i < NumericUpDownKMeansAndKNearestNeighborsKValue.Value; i++)
            {
                // Crear una "DataTable" para la instancia K.
                DataTable kInstance = dataSet.Clone();

                // Crear una fila para la instancia.
                DataRow kInstanceValues = kInstance.NewRow();

                // Generar un valor aleatorio para cada atributo numérico.
                for (int j = 0; j < numericalAttributesIndices.Count; j++)
                {
                    List<double> attributeValues = numericalAttributesValues[j];

                    kInstanceValues[numericalAttributesIndices[j]] = GenerateRandomDouble(numberGenerator, attributeValues.Min(), attributeValues.Max());
                }

                // Generar un valor aleatorio para cada atributo ordinal.
                for (int j = 0; j < ordinalAttributesIndices.Count; j++)
                {
                    List<double> attributeValues = ordinalAttributesValues[j];

                    kInstanceValues[ordinalAttributesIndices[j]] = GenerateRandomDouble(numberGenerator, attributeValues.Min(), attributeValues.Max());
                }

                // Insertar el arreglo de valores en la "DataTable".
                kInstance.Rows.Add(kInstanceValues);

                // Agregar la "DataTable" a la lista.
                kInstances.Add(kInstance);

                // Agregar una "DataTable" a la lista de clústeres.
                kClusters.Add(dataSet.Clone());

                // Agregar una lista a la lita de listas índices.
                kClustersIndices.Add(new List<int>());
            }

            // Construir los clústeres hasta que no haya cambios en ellos 10 veces seguidas.
            do
            {
                // Variable para determinar si se realizó un cambio en los clústeres.
                bool changesMade = false;

                // Lista para almacenar las posibles instancias asignadas a los clústeres.
                List<List<int>> possibleKClustersIndices = new List<List<int>>();

                // Llenar la lista de posibles instancias.
                for (int i = 0; i < kClustersIndices.Count; i++)
                {
                    possibleKClustersIndices.Add(new List<int>());
                }

                // Recorrer todas las instancias del conjunto de datos.
                for (int i = 0; i < dataSet.Rows.Count; i++)
                {
                    // Lista para almacenar las distancias entre la instancia y las instancias K.
                    List<double> euclideanDistances = new List<double>();

                    // Calcular las distancias.
                    foreach (DataTable kInstance in kInstances)
                    {
                        // Crear nueva instancia con los valores.
                        DataRow dataSetInstance = dataSet.NewRow();

                        // Llenar los valores de los atributos numéricos en la instancia.
                        for (int j = 0; j < numericalAttributesIndices.Count; j++)
                        {
                            // Obtener el índice del atributo numérico.
                            int attributeIndex = numericalAttributesIndices[j];

                            // Copiar el valor del atributo.
                            dataSetInstance[attributeIndex] = numericalAttributesValues[j][i];
                        }

                        // Llenar los valores de los atributos ordinales en la instancia.
                        for (int j = 0; j < ordinalAttributesIndices.Count; j++)
                        {
                            // Obtener el índice del atributo numérico.
                            int attributeIndex = ordinalAttributesIndices[j];

                            // Copiar el valor del atributo.
                            dataSetInstance[attributeIndex] = ordinalAttributesValues[j][i];
                        }

                        // Agregar a la lista la distancia euclidiana entre la instancia actual y la instancia K.
                        euclideanDistances.Add(GetEuclideanDistance(dataSetInstance, kInstance.Rows[0], numericalAttributesIndices, ordinalAttributesIndices));
                    }

                    // Agregar el índice de la instancia actual a la lista de índices de la instancia K más cercano.
                    possibleKClustersIndices[euclideanDistances.IndexOf(euclideanDistances.Min())].Add(i);
                }

                // Verificar si los índices de los clústeres son iguales a los posibles índices de los clústeres.
                for (int i = 0; i < kClustersIndices.Count; i++)
                {
                    // Verificar si el numero de indices del clúster es diferente.
                    if (kClustersIndices[i].Count != possibleKClustersIndices[i].Count)
                    {
                        // El numero de indices por clúster es diferente.
                        // Actualizar la variable bool y romper el ciclo.
                        changesMade = true;
                        break;
                    }

                    // Recorrer los índices del clúster.
                    for (int j = 0; j < kClustersIndices[i].Count; j++)
                    {
                        // Verificar si los índices del clúster son diferentes.
                        if (kClustersIndices[i][j] != possibleKClustersIndices[i][j])
                        {
                            // Los índices son diferentes.
                            // Actualizar la variable bool y romper el ciclo.
                            changesMade = true;
                            break;
                        }
                    }
                    
                    // Verificar si se realizaron cambios en los clústeres.
                    if (changesMade)
                    {
                        // Se realizaron cambios.
                        // Romper el ciclo.
                        break;
                    }
                }

                // Verificar si hubo cambios en los clústeres.
                if (changesMade)
                {
                    // Los índices de los clústeres son diferentes.
                    kClustersIndices = possibleKClustersIndices;

                    // Calcular nuevamente las instancias K.
                    for (int i = 0; i < kClustersIndices.Count; i++)
                    {
                        // Lista para almacenar los índices de los clústeres.
                        List<int> instanceIndices = kClustersIndices[i];

                        // Realizar la sumatoria en cada atributo numérico.
                        for (int j = 0; j < numericalAttributesIndices.Count; j++)
                        {
                            // Obtener el índice del atributo.
                            int attributeIndex = numericalAttributesIndices[j];

                            // Variable para realizar la sumatoria.
                            double summation = 0;

                            // Recorrer todas las instancias del clúster.
                            for (int k = 0; k < instanceIndices.Count; k++)
                            {
                                summation += Convert.ToDouble(numericalAttributesValues[j][instanceIndices[k]]);
                            }

                            // Verificar si el promedio puede ser calculado.
                            if (summation != 0)
                            {
                                // Calcular el promedio y asignarlo.
                                kInstances[i].Rows[0][attributeIndex] = summation / instanceIndices.Count;
                            }
                        }

                        // Realizar la sumatoria en cada atributo ordinal.
                        for (int j = 0; j < ordinalAttributesIndices.Count; j++)
                        {
                            // Obtener el índice del atributo.
                            int attributeIndex = ordinalAttributesIndices[j];

                            // Variable para realizar la sumatoria.
                            double summation = 0;

                            // Recorrer todas las instancias del clúster.
                            for (int k = 0; k < instanceIndices.Count; k++)
                            {
                                summation += Convert.ToDouble(ordinalAttributesValues[j][instanceIndices[k]]);
                            }

                            // Verificar si el promedio puede ser calculado.
                            if (summation != 0)
                            {
                                // Calcular el promedio y asignarlo.
                                kInstances[i].Rows[0][attributeIndex] = summation / instanceIndices.Count;
                            }
                        }
                    }

                    // Asignar 0 a la variable que determina el numero de iteraciones sin cambios.
                    iterationsWithoutChanges = 0;
                }
                else
                {
                    // Los índices de los clústeres son iguales.
                    iterationsWithoutChanges++;
                }
            }
            while (iterationsWithoutChanges < maximumIterationsWithoutChanges);

            // Asignar las instancias más cercanas a los puntos.
            for (int i = 0; i < kClustersIndices.Count; i++)
            {
                // Lista para almacenar los índices del clúster.
                List<int> instanceIndices = kClustersIndices[i];

                // Agregar las instancias en los índices al clúster.
                for (int j = 0; j < instanceIndices.Count; j++)
                {
                    kClusters[i].Rows.Add(dataSet.Rows[instanceIndices[j]].ItemArray);
                }
            }

            // Retornar las instancias K y los clústeres.
            return new List<List<DataTable>>() { kInstances, kClusters };
        }

        private double GetNumericalValueNormalization(int numericalValue, int numberOfNumericalValues)
        {
            // Retornar el valor numérico normalizado.
            return ((double)numericalValue - 1) / ((double)numberOfNumericalValues - 1);
        }

        private double GenerateRandomDouble(Random numberGenerator, double minimumValue, double maximumValue)
        {
            // Retornar un "double" aleatorio.
            return minimumValue + (numberGenerator.NextDouble() * (maximumValue - minimumValue));
        }

        private double GetEuclideanDistance(DataRow instanceOne, DataRow instanceTwo, List<int> numericalAttributesIndices, List<int> ordinalAttributesIndices)
        {
            // Variable para almacenar la sumatoria.
            double summation = 0;

            // Realizar la sumatoria en los atributos numéricos.
            foreach (int index in numericalAttributesIndices)
            {
                summation += Math.Pow(Convert.ToDouble(instanceOne[index].ToString()) - Convert.ToDouble(instanceTwo[index].ToString()), 2);
            }

            // Realizar la sumatoria en los atributos ordinales.
            foreach (int index in ordinalAttributesIndices)
            {
                summation += Math.Pow(Convert.ToDouble(instanceOne[index].ToString()) - Convert.ToDouble(instanceTwo[index].ToString()), 2);
            }

            // Retornar la distancia euclidana.
            return Math.Sqrt(summation);
        }

        private List<List<DataTable>> KNearestNeighbors(DataTable neighborSet, DataTable testingSet)
        {
            // Variables.
            List<DataTable> testingSetNearestNeighbors = new List<DataTable>();
            List<DataTable> testingSetInstances = new List<DataTable>();
            List<int> numericalAttributesIndices = new List<int>();
            List<int> ordinalAttributesIndices = new List<int>();
            List<List<double>> neighborSetNumericalAttributesValues = new List<List<double>>();
            List<List<double>> neighborSetOrdinalAttributesValues = new List<List<double>>();
            List<List<double>> testingSetNumericalAttributesValues = new List<List<double>>();
            List<List<double>> testingSetOrdinalAttributesValues = new List<List<double>>();

            // Obtener los índices de los atributos numéricos u ordinales del conjunto de datos.
            for (int i = 0; i < dataSet.Columns.Count; i++)
            {
                // Verificar si el atributo es numérico.
                if (dataSetDataFile.Attributes[i].GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                {
                    // El atributo es numérico.
                    // Agregar el índice del atributo a la lista.
                    numericalAttributesIndices.Add(i);
                }
                else
                {
                    // El atributo no es numérico.
                    // Verificar si el atributo es ordinal.
                    if (dataSetDataFile.Attributes[i].GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Ordinal)
                    {
                        // El atributo es ordinal.
                        // Agregar el índice del atributo a la lista.
                        ordinalAttributesIndices.Add(i);
                    }
                }
            }

            // Verificar si no hay atributos numéricos u ordinales.
            if (numericalAttributesIndices.Count == 0 && ordinalAttributesIndices.Count == 0)
            {
                // No hay atributos numéricos u ordinales.
                MessageBox.Show("El conjunto de datos no tiene atributos numéricos u ordinales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            // Obtener los valores de los atributos numéricos para el conjunto de vecinos y el de prueba.
            foreach (int index in numericalAttributesIndices)
            {
                // Variables.
                List<double> neighborSetAttributeValues = new List<double>();
                List<double> testingSetAttributeValues = new List<double>();

                // Recorrer todas las instancias del conjunto de vecinos.
                foreach (DataRow instance in neighborSet.Rows)
                {
                    // Verificar que el valor sea numérico.
                    if (double.TryParse(instance[index].ToString(), out double parsedValue))
                    {
                        // El valor es numérico.
                        // Agregar el valor a lista.
                        neighborSetAttributeValues.Add(parsedValue);
                    }
                    else
                    {
                        // El valor no es numérico.
                        // Desplegar mensaje de error y abortar.
                        MessageBox.Show("El atributo \"" + neighborSet.Columns[index].Caption + "\" tiene valores inválidos (\"" + instance[index] + "\").", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }

                // Recorrer todas las instancias del conjunto de prueba.
                foreach (DataRow instance in testingSet.Rows)
                {
                    // Verificar que el valor sea numérico.
                    if (double.TryParse(instance[index].ToString(), out double parsedValue))
                    {
                        // El valor es numérico.
                        // Agregar el valor a lista.
                        testingSetAttributeValues.Add(parsedValue);
                    }
                    else
                    {
                        // El valor no es numérico.
                        // Desplegar mensaje de error y abortar.
                        MessageBox.Show("El atributo \"" + testingSet.Columns[index].Caption + "\" tiene valores inválidos (\"" + instance[index] + "\").", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }

                // Agregar los valores del atributo a las listas.
                neighborSetNumericalAttributesValues.Add(neighborSetAttributeValues);
                testingSetNumericalAttributesValues.Add(testingSetAttributeValues);
            }

            // Obtener los valores de los atributos ordinales para el conjunto de vecinos y el de prueba.
            foreach (int index in ordinalAttributesIndices)
            {
                // Obtener los posibles valores para el atributo ordinal.
                var ordinalAttributePossibleValues = GetAttributePossibleValues(dataSet.Columns[index]);

                // Utilizar un "Form" para obtener el valor numérico de cada valor posible.
                using (OrdinalAttributeNormalization ordinalAttributeNormalizationForm = new OrdinalAttributeNormalization(ordinalAttributePossibleValues))
                {
                    // Mostrar el "Form".
                    if (ordinalAttributeNormalizationForm.ShowDialog() == DialogResult.OK)
                    {
                        // Crear un diccionario para el atributo ordinal.
                        Dictionary<string, double> ordinalAttributeDictionary = new Dictionary<string, double>();

                        // Listas para almacenar los valores del atributo.
                        List<double> neighborSetAttributeValues = new List<double>();
                        List<double> testingSetAttributeValues = new List<double>();

                        // Obtener la lista de los valores numéricos del atributo.
                        List<int> numericalValues = ordinalAttributeNormalizationForm.OrdinalAttributePossibleValuesNumericalValues;

                        // Normalizar los valores del atributo ordinal e insertarlos en el diccionario.
                        for (int i = 0; i < ordinalAttributePossibleValues.Count(); i++)
                        {
                            ordinalAttributeDictionary.Add(ordinalAttributePossibleValues.ElementAt(i).Key, GetNumericalValueNormalization(numericalValues[i], numericalValues.Count));
                        }

                        // Normalizar el conjunto de vecinos.
                        foreach (DataRow instance in neighborSet.Rows)
                        {
                            neighborSetAttributeValues.Add(ordinalAttributeDictionary[instance[index].ToString()]);
                        }

                        // Normalizar el conjunto de prueba.
                        foreach (DataRow instance in testingSet.Rows)
                        {
                            testingSetAttributeValues.Add(ordinalAttributeDictionary[instance[index].ToString()]);
                        }

                        // Agregar los valores del atributo a las listas.
                        neighborSetOrdinalAttributesValues.Add(neighborSetAttributeValues);
                        testingSetOrdinalAttributesValues.Add(testingSetAttributeValues);
                    }
                }
            }

            // Encontrar los K vecinos más cercanos en cada instancia del conjunto de prueba.
            for (int i = 0; i < testingSet.Rows.Count; i++)
            {
                // Lista para almacenar la distancia con cada instancia del conjunto de entrenamiento.
                List<List<double>> euclideanDistancesAndIndices = new List<List<double>>();

                // Crear nueva instancia del conjunto de prueba con los valores normalizados.
                DataRow testingSetInstance = testingSet.NewRow();

                // Llenar los valores de los atributos numéricos en la instancia.
                for (int j = 0; j < numericalAttributesIndices.Count; j++)
                {
                    testingSetInstance[numericalAttributesIndices[j]] = testingSetNumericalAttributesValues[j][i];
                }

                // Llenar los valores de los atributos ordinales en la instancia.
                for (int j = 0; j < ordinalAttributesIndices.Count; j++)
                {
                    testingSetInstance[ordinalAttributesIndices[j]] = testingSetOrdinalAttributesValues[j][i];
                }

                // Obtener la distancia euclidiana en cada instancia del conjunto de entrenamiento.
                for (int j = 0; j < neighborSet.Rows.Count; j++)
                {
                    // Lista para almacenar la distancia con el índice.
                    List<double> euclideanDistanceAndIndex = new List<double>();

                    // Crear nueva instancia del conjunto de vecinos con los valores normalizados.
                    DataRow neighborSetInstance = neighborSet.NewRow();

                    // Llenar los valores de los atributos numéricos en la instancia.
                    for (int k = 0; k < numericalAttributesIndices.Count; k++)
                    {
                        neighborSetInstance[numericalAttributesIndices[k]] = neighborSetNumericalAttributesValues[k][j];
                    }

                    // Llenar los valores de los atributos ordinales en la instancia.
                    for (int k = 0; k < ordinalAttributesIndices.Count; k++)
                    {
                        neighborSetInstance[ordinalAttributesIndices[k]] = neighborSetOrdinalAttributesValues[k][j];
                    }

                    // Asignar la distancia entre la instancia de prueba y la de vecinos y el índice.
                    euclideanDistanceAndIndex.Add(GetEuclideanDistance(testingSetInstance, neighborSetInstance, numericalAttributesIndices, ordinalAttributesIndices));
                    euclideanDistanceAndIndex.Add(j);

                    // Agregar la distancia y el índice a la lista.
                    euclideanDistancesAndIndices.Add(euclideanDistanceAndIndex);
                }

                // Ordenar la lista de menor a mayor distancia.
                euclideanDistancesAndIndices = euclideanDistancesAndIndices.OrderBy(euclideanDistanceAndIndex => euclideanDistanceAndIndex[0]).ToList();

                // Crear "DataTable" para insertar las instancias de los vecinos mas cercanos.
                DataTable testingSetInstanceNearestNeighbor = testingSet.Clone();

                // Encontrar los K vecinos más cercanos.
                for (int j = 0; j < NumericUpDownKMeansAndKNearestNeighborsKValue.Value; j++)
                {
                    // Verificar si aún quedan vecinos disponibles.
                    if (j == neighborSet.Rows.Count)
                    {
                        // Ya no hay vecinos disponibles.
                        // Romper el ciclo.
                        break;
                    }

                    // Asignar el vecino.
                    testingSetInstanceNearestNeighbor.Rows.Add(neighborSet.Rows[(int)euclideanDistancesAndIndices[j][1]].ItemArray);
                }

                // Agregar "DataTable" a la lista.
                testingSetNearestNeighbors.Add(testingSetInstanceNearestNeighbor);
            }

            // Crear lista de "DataTables" para el conjunto de prueba.
            foreach (DataRow instance in testingSet.Rows)
            {
                // "DataTable" para la instancia del conjunto de prueba.
                DataTable testingSetInstance = testingSet.Clone();

                // Agregar la instancia del conjunto de prueba.
                testingSetInstance.Rows.Add(instance.ItemArray);

                // Agregar la "DataTable" a la lista.
                testingSetInstances.Add(testingSetInstance);
            }
            
            // Retornar las instancias con sus vecinos más cercanos.
            return new List<List<DataTable>>() { testingSetInstances, testingSetNearestNeighbors };
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
            int kSetInstanceNumber = (int)Math.Round(dataSet.Rows.Count / (double)NumericUpDownKFoldCrossValidationKValue.Value);
            int lastKSetInstanceNumber = dataSet.Rows.Count - (kSetInstanceNumber * (int)NumericUpDownKFoldCrossValidationKValue.Value) + kSetInstanceNumber;

            // Obtener los conjuntos.
            for (int i = 0; i < NumericUpDownKFoldCrossValidationKValue.Value - 1; i++)
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
                lastKSet.Rows.Add(dataSet.Rows[kSetInstanceNumber * ((int)NumericUpDownKFoldCrossValidationKValue.Value - 1) + i].ItemArray);
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
            // "DataTable" para combinar las "DataTables".
            DataTable mergedSet = sets[0].Clone();

            // Combinar cada "DataTable".
            foreach (DataTable set in sets)
            {
                // Verificar si la "DataTable" no es la excepción.
                if (set != exception)
                {
                    // No es la excepción.
                    // Combinar la "DataTable" con la combinación existente.
                    mergedSet.Merge(set);
                }
            }

            // Retornar la combinacion de "DataTables".
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
