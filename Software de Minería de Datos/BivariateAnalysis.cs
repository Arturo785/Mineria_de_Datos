using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Software_de_Minería_de_Datos
{
    public partial class BivariateAnalysis : Form
    {
        // Constantes.
        const double invalidPearsonCorrelationCoefficient = double.NegativeInfinity;
        const double invalidChiSquaredTest = double.NegativeInfinity;

        // Variables.
        DataTable dataSet;
        DataFile dataSetDataFile;
        BindingList<string> attributeNumberOneOptions;
        BindingList<string> attributeNumberTwoOptions;

        public BivariateAnalysis(DataTable newDataSet)
        {
            InitializeComponent();

            // Asignar la "DataTable" global al local.
            dataSet = newDataSet;

            // Inicializar las "BindingList" globales.
            attributeNumberOneOptions = new BindingList<string>();
            attributeNumberTwoOptions = new BindingList<string>();

            // Definir las "BindingList" globales como el "DataSource" de los "ComboBox" de los atributos.
            ComboBoxAttributeNumberOne.DataSource = attributeNumberOneOptions;
            ComboBoxAttributeNumberTwo.DataSource = attributeNumberTwoOptions;
        }

        public void UpdateContent(DataFile newDataSetDataFile)
        {
            // Asignar el "DataFile" global al local.
            dataSetDataFile = newDataSetDataFile;

            // Limpiar las opciones de los "ComboBox" de los atributos.
            attributeNumberOneOptions.Clear();
            attributeNumberTwoOptions.Clear();

            // Agregar las opciones a los "ComboBox" de los atributos.
            foreach (DataColumn attribute in dataSet.Columns)
            {
                attributeNumberOneOptions.Add(attribute.Caption);
                attributeNumberTwoOptions.Add(attribute.Caption);
            }

            // Obtener la correlación de los dos atributos seleccionados.
            GetAttributeCorrelation();
        }

        private void ComboBoxAttributeNumberOne_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar si el índice seleccionado es válido.
            if (ComboBoxAttributeNumberOne.SelectedIndex != -1)
            {
                // El índice seleccionado es válido.
                // Obtener la correlación de los dos atributos seleccionados.
                GetAttributeCorrelation();
            }
        }

        private void ComboBoxAttributeNumberTwo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar si el índice seleccionado es válido.
            if (ComboBoxAttributeNumberTwo.SelectedIndex != -1)
            {
                // El índice seleccionado es válido.
                // Obtener la correlación de los dos atributos seleccionados.
                GetAttributeCorrelation();
            }
        }

        private void GetAttributeCorrelation()
        {
            // Limpiar las "Series" existentes en la gráfica.
            ChartAttributes.Series.Clear();

            // Limpiar los titulos existentes en la gráfica.
            ChartAttributes.Titles.Clear();

            // Limpiar las "Labels"
            LabelAttributeNumberOneTypeValue.Text = "N/A";
            LabelAttributeNumberTwoTypeValue.Text = "N/A";
            LabelPearsonCorrelationCoefficientValue.Text = "N/A";
            LabelTschuprowsCoefficientValue.Text = "N/A";
            LabelChiSquaredValue.Text = "N/A";
            
            // Verificar si el conjunto de datos tiene datos.
            if (dataSet.Rows.Count == 0)
            {
                // El conjunto de datos no tiene datos.
                // Desplegar un mensaje de error.
                MessageBox.Show("El conjunto de datos se encuentra vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar el tipo de archivo con el que se esta trabajando.
            if (dataSetDataFile == null)
            {
                // Archivo CSV.
                // Los dos atributos con los que se realizará el analisis.
                DataFileAttribute attributeNumberOne = new DataFileAttribute(ComboBoxAttributeNumberOne.SelectedItem.ToString(), (int)DataFileAttribute.AttributeDataType.Nominal, "");
                DataFileAttribute attributeNumberTwo = new DataFileAttribute(ComboBoxAttributeNumberTwo.SelectedItem.ToString(), (int)DataFileAttribute.AttributeDataType.Nominal, "");

                // Actualizar "Labels" del tipo de los atributos.
                LabelAttributeNumberOneTypeValue.Text = "Categórico";
                LabelAttributeNumberTwoTypeValue.Text = "Categórico";

                // Realizar la prueba Chi-Cuadrada con los dos atributos.
                double chiSquared = GetChiSquared(attributeNumberOne, attributeNumberTwo);

                // Verificar si Chi-Cuadrada no es inválida.
                if (chiSquared != invalidChiSquaredTest)
                {
                    // Chi-Cuadrada es válida.
                    // Asignar a la "Label" el valor de Chi-Cuadrada.
                    LabelChiSquaredValue.Text = chiSquared.ToString();

                    // Calcular y asignar a la "Label" el coeficiente de contingencia de Tschuprow.
                    LabelTschuprowsCoefficientValue.Text = GetTschuprowsCoefficient(chiSquared, attributeNumberOne, attributeNumberTwo).ToString();

                    // Generar gráfica de columnas apiladas de los atributos.
                    GenerateStackedColumnChart(attributeNumberOne, attributeNumberTwo);
                }
                else
                {
                    // Chi-Cuadrada es inválida.
                    // Abortar cálculo.
                    return;
                }
            }
            else
            {
                // Archivo DATA.
                // Los dos atributos con los que se realizará el analisis.
                DataFileAttribute attributeNumberOne = dataSetDataFile.Attributes[ComboBoxAttributeNumberOne.SelectedIndex];
                DataFileAttribute attributeNumberTwo = dataSetDataFile.Attributes[ComboBoxAttributeNumberTwo.SelectedIndex];

                // Verificar el tipo del atributo número 1.
                if (attributeNumberOne.GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                {
                    // Atributo numérico.
                    // Actualizar "Label" del tipo del atributo número 1.
                    LabelAttributeNumberOneTypeValue.Text = "Numérico";

                    // Verificar si el tipo del atributo número 2 es el mismo.
                    if (attributeNumberOne.DataType == attributeNumberTwo.DataType)
                    {
                        // Ambos atributos son numéricos (Numérico vs Numérico).
                        // Actualizar "Label" del tipo del atributo número 2.
                        LabelAttributeNumberTwoTypeValue.Text = "Numérico";

                        // Calcular el coeficiente de correlación de Pearson con los dos atributos.
                        double pearsonCorrelationCoefficient = GetPearsonCorrelationCoefficient(attributeNumberOne, attributeNumberTwo);

                        // Verificar si el coeficiente no es inválido.
                        if (pearsonCorrelationCoefficient != invalidPearsonCorrelationCoefficient)
                        {
                            // El coeficiente es válido.
                            // Asignar a la "Label" el valor del coeficiente.
                            LabelPearsonCorrelationCoefficientValue.Text = pearsonCorrelationCoefficient.ToString();

                            // Generar gráfica de dispersión de los atributos.
                            GenerateScatterPlot(attributeNumberOne, attributeNumberTwo);
                        }
                        else
                        {
                            // El coeficiente es inválido.
                            // Abortar cálculo.
                            return;
                        }
                    }
                    else
                    {
                        // Los atributos son de diferente tipo (Numérico vs Categórico).
                        // Actualizar "Label" del tipo del atributo número 2.
                        LabelAttributeNumberTwoTypeValue.Text = "Categórico";

                        // Desplegar un mensaje de error.
                        MessageBox.Show("Los atributos son de diferentes tipos (Numérico vs Categórico).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Atributo categórico.
                    // Actualizar "Label" del tipo del atributo número 1.
                    LabelAttributeNumberOneTypeValue.Text = "Categórico";

                    // Verificar si el tipo del atributo número 2 no es numérico.
                    if (attributeNumberTwo.GetDataTypeIndex() != DataFileAttribute.AttributeDataType.Numeric)
                    {
                        // Ambos atributos son categóricos (Categórico vs Categórico).
                        // Actualizar "Label" del tipo del atributo número 2.
                        LabelAttributeNumberTwoTypeValue.Text = "Categórico";

                        // Realizar la prueba Chi-Cuadrada con los dos atributos.
                        double chiSquared = GetChiSquared(attributeNumberOne, attributeNumberTwo);

                        // Verificar si Chi-Cuadrada no es inválida.
                        if (chiSquared != invalidChiSquaredTest)
                        {
                            // Chi-Cuadrada es válida.
                            // Asignar a la "Label" el valor de Chi-Cuadrada.
                            LabelChiSquaredValue.Text = chiSquared.ToString();

                            // Variable en la que se almacenará el coeficiente de contingencia Tschuprow.
                            double tschuprowsCoefficient = GetTschuprowsCoefficient(chiSquared, attributeNumberOne, attributeNumberTwo);

                            // Verficiar si el coeficiente de Tschuprow es válido.
                            if (!double.IsNaN(tschuprowsCoefficient))
                            {
                                // El coeficiente de Tschuprows es válido.
                                // Calcular y asignar a la "Label" el coeficiente de contingencia de Tschuprow.
                                LabelTschuprowsCoefficientValue.Text = GetTschuprowsCoefficient(chiSquared, attributeNumberOne, attributeNumberTwo).ToString();

                                // Generar gráfica de columnas apiladas de los atributos.
                                GenerateStackedColumnChart(attributeNumberOne, attributeNumberTwo);
                            }
                        }
                        else
                        {
                            // Chi-Cuadrada es inválida.
                            // Abortar cálculo.
                            return;
                        }
                    }
                    else
                    {
                        // Los atributos son de diferente tipo (Categórico vs Numérico).
                        // Actualizar "Label" del tipo del atributo número 2.
                        LabelAttributeNumberTwoTypeValue.Text = "Numérico";

                        // Desplegar un mensaje de error.
                        MessageBox.Show("Los atributos son de diferentes tipos (Categórico vs Numérico).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private double GetPearsonCorrelationCoefficient(DataFileAttribute attributeNumberOne, DataFileAttribute attributeNumberTwo)
        {
            // Variable para almacenar la sumatoria de la multiplicación de los valores menos la media de cada atributo.
            double attributeMinusMeanProductSummation = 0;

            // Listas para almacenar todos los valores de cada atributo.
            List<double> attributeNumberOneValues = new List<double>();
            List<double> attributeNumberTwoValues = new List<double>();

            // Variables para almacenar la media y la desviación estándar de cada atributo.
            double attributeNumberOneMean, attributeNumberOneStandardDeviation;
            double attributeNumberTwoMean, attributeNumberTwoStandardDeviation;

            // Llenar las listas de todos los valores de cada atributo.
            foreach (DataRow instance in dataSet.Rows)
            {
                // Variables para almacenar el valor de cada atributo en una instancia como "string".
                string attributeNumberOneValue = instance[attributeNumberOne.Name].ToString();
                string attributeNumberTwoValue = instance[attributeNumberTwo.Name].ToString();

                // Convertir los valores del atributo número uno en la instancia a "double".
                try
                {
                    attributeNumberOneValues.Add(Convert.ToDouble(attributeNumberOneValue));
                }
                catch (FormatException)
                {
                    // Verificar que el valor de atributo numero uno no sea un valor faltante.
                    if (attributeNumberOneValue != dataSetDataFile.MissingValue && attributeNumberOneValue != "")
                    {
                        // Desplegar un mensaje de error y retornar el coeficiente inválido.
                        MessageBox.Show("El atributo \"" + attributeNumberOne.Name + "\" tiene valores inválidos (\"" + attributeNumberOneValue + "\").", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return invalidPearsonCorrelationCoefficient;
                    }
                }

                // Convertir los valores del atributo número dos en la instancia a "double".
                try
                {
                    attributeNumberTwoValues.Add(Convert.ToDouble(attributeNumberTwoValue));
                }
                catch (FormatException)
                {
                    // Verificar que el valor de atributo numero dos no sea un valor faltante.
                    if (attributeNumberTwoValue != dataSetDataFile.MissingValue && attributeNumberTwoValue != "")
                    {
                        // Desplegar un mensaje de error y retornar el coeficiente inválido.
                        MessageBox.Show("El atributo \"" + attributeNumberTwo.Name + "\" tiene valores inválidos (\"" + attributeNumberTwoValue + "\").", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return invalidPearsonCorrelationCoefficient;
                    }
                }
            }

            // Verificar que los atributos tengan el mismo número de valores.
            if (attributeNumberOneValues.Count != attributeNumberTwoValues.Count)
            {
                // Desplegar un mensaje de error y retornar el coeficiente inválido.
                MessageBox.Show("Los atributos no tienen el mismo número de valores.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return invalidPearsonCorrelationCoefficient;
            }

            // Verificar si los atributos no tienen valores.
            if(attributeNumberOneValues.Count == 0)
            {
                // Los atributos no tienen valores.
                // Desplegar un mensaje de error y retornar el coeficiente inválido.
                MessageBox.Show("Los atributos no tienen valores.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return invalidPearsonCorrelationCoefficient;
            }

            // Asignar la media y desviacion estándar del atributo número uno.
            attributeNumberOneMean = attributeNumberOneValues.Average();
            attributeNumberOneStandardDeviation = GetStandardDeviation(attributeNumberOneValues);

            // Asignar la media y desviacion estándar del atributo número dos.
            attributeNumberTwoMean = attributeNumberTwoValues.Average();
            attributeNumberTwoStandardDeviation = GetStandardDeviation(attributeNumberTwoValues);

            // Realizar la sumatoria de la multiplicación de los valores menos la media de cada atributo.
            for (int i = 0; i < attributeNumberOneValues.Count; i++)
            {
                attributeMinusMeanProductSummation += (attributeNumberOneValues[i] - attributeNumberOneMean) * (attributeNumberTwoValues[i] - attributeNumberTwoMean);
            }

            // Retornar el coeficiente de correlación de Pearson.
            return attributeMinusMeanProductSummation / (attributeNumberOneValues.Count * attributeNumberOneStandardDeviation * attributeNumberTwoStandardDeviation);
        }

        private double GetStandardDeviation(List<double> values)
        {
            // Variable para almacenar la media del conjunto de valores.
            double mean = values.Average();

            // Retornar la desviación estándar del conjunto de valores.
            return Math.Sqrt(values.Sum(value => Math.Pow(value - mean, 2)) / values.Count);
        }

        private void GenerateScatterPlot(DataFileAttribute attributeNumberOne, DataFileAttribute attributeNumberTwo)
        {
            // Crear nueva "Series" para mostrar los datos en la gráfica de dispersión.
            Series coordinates = ChartAttributes.Series.Add("Valores");
            coordinates.ChartType = SeriesChartType.Point;

            // Agregar nuevo titulo a la gráfica.
            ChartAttributes.Titles.Add(attributeNumberOne.Name + " vs " + attributeNumberTwo.Name);

            // Graficar cada coordenada de los atributos.
            foreach (DataRow instance in dataSet.Rows)
            {
                // Variables para almacenar el valor de cada atributo en una instancia como "string".
                string attributeNumberOneValue = instance[attributeNumberOne.Name].ToString();
                string attributeNumberTwoValue = instance[attributeNumberTwo.Name].ToString();

                // Verificar que el valor de atributo numero uno no sea un valor faltante.
                if (attributeNumberOneValue != dataSetDataFile.MissingValue && attributeNumberOneValue != "")
                {
                    // Verificar que el valor de atributo numero dos no sea un valor faltante.
                    if (attributeNumberTwoValue != dataSetDataFile.MissingValue && attributeNumberTwoValue != "")
                    {
                        // Agregar la coordenada a la gráfica.
                        coordinates.Points.AddXY(Convert.ToDouble(attributeNumberOneValue), Convert.ToDouble(attributeNumberTwoValue));
                    }
                }
            }
        }

        private double GetChiSquared(DataFileAttribute attributeNumberOne, DataFileAttribute attributeNumberTwo)
        {
            // Listas para almacenar todos los valores de cada atributo.
            List<string> attributeNumberOneValues = new List<string>();
            List<string> attributeNumberTwoValues = new List<string>();

            // Diccionarios para los valores posibles de ambos atributos con su respectivo indice en la tabla de contingencia.
            Dictionary<string, int> attributeNumberOneContingencyTableIndices = new Dictionary<string, int>();
            Dictionary<string, int> attributeNumberTwoContingencyTableIndices = new Dictionary<string, int>();

            // Variable para almacenar la sumatoria de Chi-Cuadrada.
            double chiSquaredSummation = 0;

            // Llenar las listas de todos los valores de cada atributo.
            foreach (DataRow instance in dataSet.Rows)
            {
                // Variables para almacenar el valor de cada atributo en una instancia.
                string attributeNumberOneValue = instance[attributeNumberOne.Name].ToString();
                string attributeNumberTwoValue = instance[attributeNumberTwo.Name].ToString();

                // Verificar el tipo de archivo.
                if (dataSetDataFile == null)
                {
                    // Archivo CSV.
                    // Verificar que el valor de atributo numero uno no sea un valor faltante.
                    if (attributeNumberOneValue == "")
                    {
                        // Desplegar un mensaje de error y retornar un valor inválido.
                        MessageBox.Show("El atributo \"" + attributeNumberOne.Name + "\" tiene valores faltantes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return invalidChiSquaredTest;
                    }

                    // Verificar que el valor de atributo numero dos no sea un valor faltante.
                    if (attributeNumberTwoValue == "")
                    {
                        // Desplegar un mensaje de error y retornar un valor inválido.
                        MessageBox.Show("El atributo \"" + attributeNumberTwo.Name + "\" tiene valores faltantes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return invalidChiSquaredTest;
                    }
                }
                else
                {
                    // Archivo DATA.
                    // Verificar que el valor de atributo numero uno no sea un valor faltante.
                    if (attributeNumberOneValue == dataSetDataFile.MissingValue || attributeNumberOneValue == "")
                    {
                        // Desplegar un mensaje de error y retornar un valor inválido.
                        MessageBox.Show("El atributo \"" + attributeNumberOne.Name + "\" tiene valores faltantes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return invalidChiSquaredTest;
                    }

                    // Verificar que el valor de atributo numero dos no sea un valor faltante.
                    if (attributeNumberTwoValue == dataSetDataFile.MissingValue || attributeNumberTwoValue == "")
                    {
                        // Desplegar un mensaje de error y retornar un valor inválido.
                        MessageBox.Show("El atributo \"" + attributeNumberTwo.Name + "\" tiene valores faltantes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return invalidChiSquaredTest;
                    }
                }

                // Agregar a las listas los valores de cada atributo en la instancia.
                attributeNumberOneValues.Add(attributeNumberOneValue);
                attributeNumberTwoValues.Add(attributeNumberTwoValue);
            }

            // Variables para almacenar los valores posibles de ambos atributos.
            var attributeNumberOnePossibleValues = attributeNumberOneValues.GroupBy(possibleValue => possibleValue);
            var attributeNumberTwoPossibleValues = attributeNumberTwoValues.GroupBy(possibleValue => possibleValue);

            // Matriz para crear la tabla de contingencia. Se suma uno para agregar la fila y columna de "Total".
            double[,] contingencyTable = new double[attributeNumberOnePossibleValues.Count() + 1, attributeNumberTwoPossibleValues.Count() + 1];

            // Matriz para las frecuencias esperadas.
            double[,] expectedFrequencies = new double[attributeNumberOnePossibleValues.Count(), attributeNumberTwoPossibleValues.Count()];

            // Llenar el diccionario del atributo número 1.
            for (int i = 0; i < attributeNumberOnePossibleValues.Count(); i++)
            {
                var possibleValue = attributeNumberOnePossibleValues.ElementAt(i);
                attributeNumberOneContingencyTableIndices.Add(possibleValue.Key, i);
            }

            // Llenar el diccionario del atributo número 2.
            for (int i = 0; i < attributeNumberTwoPossibleValues.Count(); i++)
            {
                var possibleValue = attributeNumberTwoPossibleValues.ElementAt(i);
                attributeNumberTwoContingencyTableIndices.Add(possibleValue.Key, i);
            }

            // Llenar la tabla de contingencia.
            foreach (DataRow instance in dataSet.Rows)
            {
                // Variables para almacenar los indices de los valores de ambos atributos.
                int attributeNumberOneContingencyTableIndex = attributeNumberOneContingencyTableIndices[instance[attributeNumberOne.Name].ToString()];
                int attributeNumberTwoContingencyTableIndex = attributeNumberTwoContingencyTableIndices[instance[attributeNumberTwo.Name].ToString()];

                // Sumar una unidad a las ocurrencias de la combinacion de valores de los atributos.
                contingencyTable[attributeNumberOneContingencyTableIndex, attributeNumberTwoContingencyTableIndex]++;
            }

            // Calcular los totales de la última columna de la tabla de contingencia.
            for (int i = 0; i < attributeNumberOnePossibleValues.Count(); i++)
            {
                // Variable para almacenar la sumatoria de los valores de la fila.
                double rowTotal = 0;

                // Realizar la sumatoria de los valores de la fila.
                for (int j = 0; j < attributeNumberTwoPossibleValues.Count(); j++)
                {
                    rowTotal += contingencyTable[i, j];
                }

                // Asignar la sumatoria de los valores de la fila en la columna del total.
                contingencyTable[i, attributeNumberTwoPossibleValues.Count()] = rowTotal;
            }

            // Calcular los totales de la última fila de la tabla de contingencia.
            for (int j = 0; j <= attributeNumberTwoPossibleValues.Count(); j++)
            {
                // Variable para almacenar la sumatoria de los valores de la columna.
                double columnTotal = 0;

                // Realizar la sumatoria de los valores de la columna.
                for (int i = 0; i < attributeNumberOnePossibleValues.Count(); i++)
                {
                    columnTotal += contingencyTable[i, j];
                }

                // Asignar la sumatoria de los valores de la columna en la fila del total.
                contingencyTable[attributeNumberOnePossibleValues.Count(), j] = columnTotal;
            }

            // Calcular las frecuencias esperadas.
            for (int i = 0; i < attributeNumberOnePossibleValues.Count(); i++)
            {
                for (int j = 0; j < attributeNumberTwoPossibleValues.Count(); j++)
                {
                    // Asignar en la matriz de frecuencias esperadas la frecuencia esperada de "i" con "j".
                    expectedFrequencies[i, j] = contingencyTable[i, attributeNumberTwoPossibleValues.Count()] * contingencyTable[attributeNumberOnePossibleValues.Count(), j]
                        / contingencyTable[attributeNumberOnePossibleValues.Count(), attributeNumberTwoPossibleValues.Count()];
                }
            }

            // Realizar la sumatoria de Chi-Cuadrada.
            for (int i = 0; i < attributeNumberOnePossibleValues.Count(); i++)
            {
                for (int j = 0; j < attributeNumberTwoPossibleValues.Count(); j++)
                {
                    // Dividir la resta de la frecuencia observada menos la frecuencia esperada al cuadrado sobre la frecuencia esperada.
                    chiSquaredSummation += Math.Pow(contingencyTable[i, j] - expectedFrequencies[i, j], 2) / expectedFrequencies[i, j];
                }
            }
            
            // Retornar el resultado de la prueba Chi-Cuadrada.
            return chiSquaredSummation;
        }

        private double GetTschuprowsCoefficient(double chiSquared, DataFileAttribute attributeNumberOne, DataFileAttribute attributeNumberTwo)
        {
            // Listas para almacenar todos los valores de cada atributo.
            List<string> attributeNumberOneValues = new List<string>();
            List<string> attributeNumberTwoValues = new List<string>();

            // Llenar las listas de todos los valores de cada atributo.
            foreach (DataRow instance in dataSet.Rows)
            {
                // Agregar a las listas los valores de cada atributo en la instancia.
                attributeNumberOneValues.Add(instance[attributeNumberOne.Name].ToString());
                attributeNumberTwoValues.Add(instance[attributeNumberTwo.Name].ToString());
            }

            // Variables para almacenar los valores posibles de ambos atributos.
            var attributeNumberOnePossibleValues = attributeNumberOneValues.GroupBy(possibleValue => possibleValue);
            var attributeNumberTwoPossibleValues = attributeNumberTwoValues.GroupBy(possibleValue => possibleValue);

            // Retornar el coeficiente de contingencia de Tschuprow.
            return Math.Sqrt(chiSquared / (dataSet.Rows.Count * Math.Sqrt((attributeNumberOnePossibleValues.Count() - 1) * (attributeNumberTwoPossibleValues.Count() - 1))));
        }

        private void GenerateStackedColumnChart(DataFileAttribute attributeNumberOne, DataFileAttribute attributeNumberTwo)
        {
            // Agregar nuevo titulo a la gráfica.
            ChartAttributes.Titles.Add(attributeNumberOne.Name + " vs " + attributeNumberTwo.Name);

            // Listas para almacenar todos los valores de cada atributo.
            List<string> attributeNumberOneValues = new List<string>();
            List<string> attributeNumberTwoValues = new List<string>();

            // Diccionarios para los valores posibles de ambos atributos con su respectivo indice en la tabla de contingencia.
            Dictionary<string, int> attributeNumberOneContingencyTableIndices = new Dictionary<string, int>();
            Dictionary<string, int> attributeNumberTwoContingencyTableIndices = new Dictionary<string, int>();

            // Llenar las listas de todos los valores de cada atributo.
            foreach (DataRow instance in dataSet.Rows)
            {
                // Agregar a las listas los valores de cada atributo en la instancia.
                attributeNumberOneValues.Add(instance[attributeNumberOne.Name].ToString());
                attributeNumberTwoValues.Add(instance[attributeNumberTwo.Name].ToString());
            }

            // Variables para almacenar los valores posibles de ambos atributos.
            var attributeNumberOnePossibleValues = attributeNumberOneValues.GroupBy(possibleValue => possibleValue);
            var attributeNumberTwoPossibleValues = attributeNumberTwoValues.GroupBy(possibleValue => possibleValue);

            // Matriz para crear la tabla de contingencia.
            double[,] contingencyTable = new double[attributeNumberOnePossibleValues.Count(), attributeNumberTwoPossibleValues.Count()];

            // Llenar el diccionario del atributo número uno.
            for (int i = 0; i < attributeNumberOnePossibleValues.Count(); i++)
            {
                var possibleValue = attributeNumberOnePossibleValues.ElementAt(i);
                attributeNumberOneContingencyTableIndices.Add(possibleValue.Key, i);
            }

            // Llenar el diccionario del atributo número dos.
            for (int i = 0; i < attributeNumberTwoPossibleValues.Count(); i++)
            {
                var possibleValue = attributeNumberTwoPossibleValues.ElementAt(i);
                attributeNumberTwoContingencyTableIndices.Add(possibleValue.Key, i);
            }

            // Llenar la tabla de contingencia.
            foreach (DataRow instance in dataSet.Rows)
            {
                // Variables para almacenar los indices de los valores de ambos atributos.
                int attributeNumberOneContingencyTableIndex = attributeNumberOneContingencyTableIndices[instance[attributeNumberOne.Name].ToString()];
                int attributeNumberTwoContingencyTableIndex = attributeNumberTwoContingencyTableIndices[instance[attributeNumberTwo.Name].ToString()];

                // Sumar una unidad a las ocurrencias de la combinacion de valores de los atributos.
                contingencyTable[attributeNumberOneContingencyTableIndex, attributeNumberTwoContingencyTableIndex]++;
            }

            // Crear las "Series" necesarias por columna.
            for (int i = 0; i < attributeNumberTwoPossibleValues.Count(); i++)
            {
                // Obtener el valor posible del atributo número dos.
                var possibleValue = attributeNumberTwoPossibleValues.ElementAt(i);

                // Agregar una "Series" del valor posible del atributo número dos.
                ChartAttributes.Series.Add(possibleValue.Key).ChartType = SeriesChartType.StackedColumn;
            }

            // Crear las columnas para cada valor posible del atributo número uno.
            for (int i = 0; i < attributeNumberOnePossibleValues.Count(); i++)
            {
                // Asignar el valor posible del atributo número uno.
                var attributeNumberOnePossibleValue = attributeNumberOnePossibleValues.ElementAt(i);

                // Apilar las columnas de cada valor posible del atributo número uno con cada valor posible del atributo número dos.
                for (int j = 0; j < attributeNumberTwoPossibleValues.Count(); j++)
                {
                    // Obtener el valor posible del atributo número dos.
                    var attributeNumberTwoPossibleValue = attributeNumberTwoPossibleValues.ElementAt(j);

                    // Agregar la columna.
                    ChartAttributes.Series[attributeNumberTwoPossibleValue.Key].Points.AddXY(attributeNumberOnePossibleValue.Key, contingencyTable[i, j]);
                }
            }
        }
    }
}
