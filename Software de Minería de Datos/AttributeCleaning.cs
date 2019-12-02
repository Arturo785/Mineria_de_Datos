using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Software_de_Minería_de_Datos
{
    public partial class AttributeCleaning : Form
    {
        // Variables.
        DataTable dataSet;
        DataFile dataSetDataFile;
        BindingList<string> attributeOptions;
        public bool ChangesMade { get; set; }

        // Variables generales para todas las opciones.
        DataFileAttribute attribute;
        DataTable attributeData;
        List<string> categoricalAttributeValues;
        List<double> numericalAttributeValues;
        double mean;
        double median;

        // Variables para "Llenar Valores Faltantes".
        List<int> missingValuesIndices;
        string categoricalMode;
        double numericalMode;

        // Variables para la "Detección y Corrección de Outliers".
        List<int> possibleOutliersIndices;
        List<int> outliersIndices;
        Color possibleOutlierColour = Color.Orange;
        Color outlierColour = Color.Red;

        // Variables para la "Detección de Errores Tipográficos".
        List<string> inOfDomainValues;
        List<int> outOfDomainValuesIndices;
        Color outOfDomainColour = Color.Red;

        // Variables para la "Transformación de Datos".
        List<int> numericalValuesIndices;

        public AttributeCleaning(DataTable newDataSet)
        {
            InitializeComponent();
            
            // Asignar la "DataTable" global a la local.
            dataSet = newDataSet;

            // Inicializar las variables.
            attributeOptions = new BindingList<string>();
            ChangesMade = false;

            // Inicializar las variables generales para todas las opciones.
            attributeData = new DataTable();
            categoricalAttributeValues = new List<string>();
            numericalAttributeValues = new List<double>();

            // Inicializar las variables para "Llenar Valores Faltantes".
            missingValuesIndices = new List<int>();

            // Inicializar las variables para la "Detección y Corrección de Outliers".
            possibleOutliersIndices = new List<int>();
            outliersIndices = new List<int>();

            // Inicializar las variables para la "Detección de Errores Tipográficos".
            inOfDomainValues = new List<string>();
            outOfDomainValuesIndices = new List<int>();

            // Inicializar variables para la "Transformación de Datos".
            numericalValuesIndices = new List<int>();

            // Definir la "BindingList" global como el "DataSource" del "ListBox" de los atributos.
            ListBoxAttributes.DataSource = attributeOptions;
        }

        public void UpdateContent(DataFile newDataSetDataFile)
        {
            // Asignar el "DataFile" global al local.
            dataSetDataFile = newDataSetDataFile;

            // Limpiar las opciones del "ListBox" de los atributos.
            attributeOptions.Clear();

            // Agregar las opciones a los "ComboBox" de los atributos.
            foreach (DataColumn attribute in dataSet.Columns)
            {
                attributeOptions.Add(attribute.Caption);
            }

            // Obtener la información del atributo seleccionado.
            GetAttributeInformation();
        }

        private void ListBoxAttributes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar si el índice del "ListBox" es válido.
            if (ListBoxAttributes.SelectedIndex != -1)
            {
                // El índice es válido.
                // Obtener la información del atributo seleccionado.
                GetAttributeInformation();
            }
        }

        private void GetAttributeInformation()
        {
            // Limpiar las variables generales para todas las opciones.
            ClearGeneralToolsAndVariables();

            // Limpiar las herramientas y variables de "Llenar Valores Faltantes".
            ClearMissingValuesToolsAndVariables();

            // Limpiar las herramientas y variables de "Detección y Corrección de Outliers".
            ClearOutlierToolsAndVariables();

            // Limpiar las herramientas y variables de "Buscar y Reemplazar".
            ClearSearchAndReplaceToolsAndVariables();

            // Limpiar las herramientas y variables de "Detección de Errores Tipográficos".
            ClearTypographicErrorsToolsAndVariables();

            //Limpiar las herramientas y variables de "Transformación de Datos".
            ClearDataTransformationToolsAndValues();

            // Verificar si el conjunto de datos no tiene datos.
            if (dataSet.Rows.Count == 0)
            {
                // El conjunto de datos no tiene datos.
                // Abortar la obtención de la información.
                return;
            }

            // Verificar el tipo del archivo.
            if (dataSetDataFile == null)
            {
                // Archivo CSV.
                // Actualizar la "Label" del tipo del atributo.
                LabelAttributeTypeValue.Text = "Categórico";

                // Llenar la lista de los valores del atributo.
                foreach (DataRow instance in dataSet.Rows)
                {
                    // Agregar el valor de la fila actual a la lista de los valores.
                    categoricalAttributeValues.Add(instance[ListBoxAttributes.SelectedIndex].ToString());
                }
            }
            else
            {
                // Archivo DATA.
                // Asignar el atributo seleccionado.
                attribute = dataSetDataFile.Attributes[ListBoxAttributes.SelectedIndex];

                // Verificar si el atributo seleccionado es numérico,
                if (attribute.GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                {
                    // Atributo numérico.
                    // Actualizar la "Label" del tipo del atributo.
                    LabelAttributeTypeValue.Text = "Numérico";

                    // Llenar la lista de los valores del atributo.
                    foreach (DataRow instance in dataSet.Rows)
                    {
                        // Asignar el valor del atributo en la instancia actual.
                        string value = instance[ListBoxAttributes.SelectedIndex].ToString();

                        // Verificar que el valor sea numérico.
                        if (double.TryParse(value, out double parsedValue))
                        {
                            // Agregar el valor de la fila actual a la lista de los valores numéricos.
                            numericalAttributeValues.Add(parsedValue);
                        }

                        // Verificar si el valor de la fila actual es un valor faltante.
                        if (value == dataSetDataFile.MissingValue)
                        {
                            // El valor de la fila actual si es un valor faltante.
                            // Agregar a la lista una cadena en blanco.
                            categoricalAttributeValues.Add("");
                        }
                        else
                        {
                            // El valor de la fila actual no es un valor faltante.
                            // Agregar el valor de la fila actual a la lista de los valores.
                            categoricalAttributeValues.Add(value);
                        }
                    }
                }
                else
                {
                    // Atributo categórico.
                    // Actualizar la "Label" del tipo del atributo.
                    LabelAttributeTypeValue.Text = "Categórico";

                    // Llenar la lista de los valores del atributo.
                    foreach (DataRow instance in dataSet.Rows)
                    {
                        // Asignar el valor del atributo en la instancia actual.
                        string value = instance[ListBoxAttributes.SelectedIndex].ToString();
                        
                        // Verificar si el valor de la fila actual es un valor faltante.
                        if (value == dataSetDataFile.MissingValue)
                        {
                            // El valor de la fila actual si es un valor faltante.
                            // Agregar a la lista una cadena en blanco.
                            categoricalAttributeValues.Add("");
                        }
                        else
                        {
                            // El valor de la fila actual no es un valor faltante.
                            // Agregar el valor de la fila actual a la lista de los valores.
                            categoricalAttributeValues.Add(value);
                        }
                    }
                }
            }

            // "DataGridView" del atributo seleccionado.
            GetDataGridViewInformation();

            // "GroupBox" de "Llenar Valores Faltantes".
            GetMissingValuesInformation();

            // "GroupBox" de "Detección y Corección de Outliers".
            GetOutlierInformation();

            // "GroupBox" de "Buscar y Reemplazar".
            GetSearchAndReplaceInformation();

            // "GroupBox" de "Detección de Errores Tipográficos".
            GetTypographicErrorsInformation();

            // "GroupBox" de "Transformación de Datos".
            GetDataTransformationInformation();
        }

        private void ClearGeneralToolsAndVariables()
        {
            // Limpiar la "Label" del tipo del atributo.
            LabelAttributeTypeValue.Text = "N/A";

            // Limpiar el atributo seleccionado.
            attribute = null;

            // Limpiar la "DataTable" con los datos del atributo.
            attributeData.Rows.Clear();
            attributeData.Columns.Clear();

            // Limpiar las variables generales.
            categoricalAttributeValues.Clear();
            numericalAttributeValues.Clear();
            mean = 0;
            median = 0;
        }

        private void GetDataGridViewInformation()
        {
            // Agregar a la "DataTable" una columna con el nombre del atributo seleccionado.
            attributeData.Columns.Add(ListBoxAttributes.SelectedItem.ToString());

            // Agregar a la "DataTable" los datos del atributo seleccionado.
            foreach (string value in categoricalAttributeValues)
            {
                attributeData.Rows.Add(value);
            }

            // Asignar al "DataSource" del "DataGridView" la "DataTable".
            DataGridViewAttribute.DataSource = attributeData;
        }

        private void DataGridViewAttribute_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            // Bloquear el ordenamiento de la columna nueva del "DataGridView".
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void GetMissingValuesInformation()
        {
            // Verificar si el archivo es de tipo DATA.
            if (dataSetDataFile != null)
            {
                // El archivo es de tipo DATA.
                // Verificar si el atributo es numérico.
                if (attribute.GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                {
                    // El atributo es numérico.
                    // Verificar que los valores del atributo tengan por lo menos un valor numérico.
                    if (numericalAttributeValues.Count == 0)
                    {
                        // Los valores del atributo no tienen por lo menos un valor numérico.
                        // Abortar la obtención de la información.
                        return;
                    }

                    // Calcular la mediana de los valores del atributo.
                    median = GetMedian(numericalAttributeValues);
                }
            }

            // Encontrar los índices con valores faltantes de la lista con los valores del atributo.
            missingValuesIndices = Enumerable.Range(0, categoricalAttributeValues.Count).Where(value => categoricalAttributeValues[value] == "").ToList();

            // Verificar si no existen valores faltantes.
            if (missingValuesIndices.Count == 0)
            {
                // No existen valores faltantes.
                // Abortar.
                return;
            }

            // Verificar si todos los valores del atributo son valores faltantes.
            if (missingValuesIndices.Count == categoricalAttributeValues.Count)
            {
                // Todos los valores del atributo son valores faltantes.
                // Abortar.
                return;
            }

            // Verificar el tipo del archivo.
            if (dataSetDataFile == null)
            {
                // Archivo CSV.
                // Asignar la moda de los valores del atributo.
                categoricalMode = GetMode(categoricalAttributeValues.Where(value => value != "").ToList());

                // Sugerir que se utilice la "Moda" para llenar los valores faltantes.
                LabelSuggestionValue.Text = "Moda";

                // Activar el "RadioButton" de "Moda".
                RadioButtonMode.Checked = true;
                RadioButtonMode.Enabled = true;
            }
            else
            {
                // Archivo DATA.
                // Verificar el tipo del atributo.
                if (attribute.GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                {
                    // El atributo es numérico.
                    // Asignar la media y moda de los valores del atributo.
                    mean = numericalAttributeValues.Average();
                    numericalMode = GetMode(numericalAttributeValues);

                    // Verificar si los valores del atributo se encuentran sesgados.
                    if (mean == median)
                    {
                        // Los valores no se encuentran sesgados.
                        // Sugerir que se utilice la "Mediana" para llenar los valores faltantes.
                        LabelSuggestionValue.Text = "Mediana";
                        RadioButtonMedian.Checked = true;
                    }
                    else
                    {
                        // Los valores si se encuentran sesgados.
                        // Sugerir que se utilice la "Media" para llenar los valores faltantes.
                        LabelSuggestionValue.Text = "Media";
                        RadioButtonMean.Checked = true;
                    }

                    // Activar los "RadioButton" de "Media", "Mediana" y "Moda".
                    RadioButtonMean.Enabled = true;
                    RadioButtonMedian.Enabled = true;
                    RadioButtonMode.Enabled = true;
                }
                else
                {
                    // El atributo es categórico.
                    // Asignar la moda de los valores del atributo.
                    categoricalMode = GetMode(categoricalAttributeValues.Where(value => value != "" && value != dataSetDataFile.MissingValue).ToList());

                    // Sugerir que se utilice la "Moda" para llenar los valores faltantes.
                    LabelSuggestionValue.Text = "Moda";

                    // Activar el "RadioButton" de "Moda".
                    RadioButtonMode.Checked = true;
                    RadioButtonMode.Enabled = true;
                }
            }

            // Activar el "Button" de "Llenar Valores Faltantes"
            ButtonFillMissingValues.Enabled = true;
        }

        private void ClearMissingValuesToolsAndVariables()
        {
            // Limpiar la "Label" de "Sugerencia:".
            LabelSuggestionValue.Text = "N/A";

            // Bloquear los "RadioButton" de "Media", "Mediana" y "Moda".
            RadioButtonMean.Enabled = false;
            RadioButtonMedian.Enabled = false;
            RadioButtonMode.Enabled = false;

            // Bloquear el "Button" de "Llenar Valores Faltantes".
            ButtonFillMissingValues.Enabled = false;

            // Limpiar las variables para "Llenar Valores Faltantes".
            missingValuesIndices.Clear();
            categoricalMode = "";
            numericalMode = 0;
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

        private double GetMode(List<double> values)
        {
            // Retornar la moda del conjunto de valores.
            return values.GroupBy(value => value).OrderByDescending(group => group.Count()).First().Key;
        }

        private string GetMode(List<string> values)
        {
            // Retornar la moda del conjunto de valores.
            return values.GroupBy(value => value).OrderByDescending(group => group.Count()).First().Key;
        }

        private void ButtonFillMissingValues_Click(object sender, EventArgs e)
        {
            // Verificar el tipo del archivo.
            if (dataSetDataFile == null)
            {
                // Archivo CSV.
                // Llenar los valores faltantes ayuda de la lista de índices.
                for (int i = 0; i < missingValuesIndices.Count; i++)
                {
                    // Verificar si se seleccionó la "Media", "Mediana" o "Moda".
                    if (RadioButtonMean.Checked)
                    {
                        // Se seleccionó la "Media".
                        // Llenar el valor faltante en el índice especificado.
                        dataSet.Rows[missingValuesIndices[i]][ListBoxAttributes.SelectedIndex] = mean;
                    }
                    else if (RadioButtonMedian.Checked)
                    {
                        // Se seleccionó la "Mediana".                    
                        // Llenar el valor faltante en el índice especificado.
                        dataSet.Rows[missingValuesIndices[i]][ListBoxAttributes.SelectedIndex] = median;
                    }
                    else
                    {
                        // Se seleccionó la "Moda".
                        // Llenar el valor faltante en el índice especificado.
                        dataSet.Rows[missingValuesIndices[i]][ListBoxAttributes.SelectedIndex] = categoricalMode;
                    }
                }
            }
            else
            {
                // Archivo DATA.
                // Llenar los valores faltantes ayuda de la lista de índices.
                for (int i = 0; i < missingValuesIndices.Count; i++)
                {
                    // Verificar si se seleccionó la "Media", "Mediana" o "Moda".
                    if (RadioButtonMean.Checked)
                    {
                        // Se seleccionó la "Media".
                        // Llenar el valor faltante en el índice especificado.
                        dataSet.Rows[missingValuesIndices[i]][ListBoxAttributes.SelectedIndex] = mean;

                        // Realizar el cambio en el archivo DATA.
                        dataSetDataFile.Data[missingValuesIndices[i]][ListBoxAttributes.SelectedIndex] = mean.ToString();
                    }
                    else if (RadioButtonMedian.Checked)
                    {
                        // Se seleccionó la "Mediana".                    
                        // Llenar el valor faltante en el índice especificado.
                        dataSet.Rows[missingValuesIndices[i]][ListBoxAttributes.SelectedIndex] = median;

                        // Realizar el cambio en el archivo DATA.
                        dataSetDataFile.Data[missingValuesIndices[i]][ListBoxAttributes.SelectedIndex] = median.ToString();
                    }
                    else
                    {
                        // Se seleccionó la "Moda".
                        // Verificar si el atributo es numérico.
                        if (attribute.GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                        {
                            // El atributo es numérico.
                            // Llenar el valor faltante en el índice especificado.
                            dataSet.Rows[missingValuesIndices[i]][ListBoxAttributes.SelectedIndex] = numericalMode;

                            // Realizar el cambio en el archivo DATA.
                            dataSetDataFile.Data[missingValuesIndices[i]][ListBoxAttributes.SelectedIndex] = numericalMode.ToString();
                        }
                        else
                        {
                            // El atributo es categórico.
                            // Llenar el valor faltante en el índice especificado.
                            dataSet.Rows[missingValuesIndices[i]][ListBoxAttributes.SelectedIndex] = categoricalMode;

                            // Realizar el cambio en el archivo DATA.
                            dataSetDataFile.Data[missingValuesIndices[i]][ListBoxAttributes.SelectedIndex] = categoricalMode;
                        }
                    }
                }
            }

            // Asignar "true" a la variable que indica si se realizaron cambios al conjunto de datos.
            ChangesMade = true;

            // Recargar la información del atributo.
            GetAttributeInformation();
        }

        private void GetOutlierInformation()
        {
            // Verificar si el archivo es de tipo CSV.
            if (dataSetDataFile == null)
            {
                // El archivo es de tipo CSV.
                // Abortar.
                return;
            }

            // Verificar si el atributo es categórico.
            if (attribute.GetDataTypeIndex() != DataFileAttribute.AttributeDataType.Numeric)
            {
                // El atributo es categórico.
                // Abortar.
                return;
            }

            // Variables que almacenarán el valor del primer y tercer cuartil; y la distancia intercuartil.
            double firstQuartile, thirdQuartile, interquartileRange;

            // Calcular el valor del primer y tercer cuartil.
            firstQuartile = GetMedian(numericalAttributeValues.Where(value => value < median).ToList());
            thirdQuartile = GetMedian(numericalAttributeValues.Where(value => value > median).ToList());

            // Verificar que los cuartiles fueron calculados correctamente.
            if (double.IsNaN(firstQuartile) || double.IsNaN(thirdQuartile))
            {
                // Los cuartiles no fueron calculados correctamente.
                // Abortar.
                return;
            }

            // Calcular la distancia intercuartil.
            interquartileRange = thirdQuartile - firstQuartile;

            // Encontrar los índices de outliers.
            for (int i = 0; i < categoricalAttributeValues.Count(); i++)
            {
                // Asignar el valor del atributo.
                string value = categoricalAttributeValues[i];

                // Verificar si el valor es numérico.
                if (double.TryParse(value, out double parsedValue))
                {
                    // El valor si es numérico.
                    // Verificar si el valor es un posible "Outlier".
                    if (parsedValue < firstQuartile - (interquartileRange * 1.5))
                    {
                        // El valor es un posible "Outlier" respecto al primer cuartil.
                        // Verificar si el valor es un "Outlier".
                        if (parsedValue < firstQuartile - (interquartileRange * 3))
                        {
                            // El valor si es un "Outlier".
                            // Agregar el indice del valor a la lista de "Outliers".
                            outliersIndices.Add(i);
                        }
                        else
                        {
                            // El valor no es un "Outlier".
                            // Agregar el indice del valor a la lista de posibles "Outliers".
                            possibleOutliersIndices.Add(i);
                        }
                    }
                    else
                    {
                        // Verificar si el valor es un posible "Outlier".
                        if (parsedValue > thirdQuartile + (interquartileRange * 1.5))
                        {
                            // El valor es un posible "Outlier" respecto al tercer cuartil.
                            // Verificar si el valor es un "Outlier".
                            if (parsedValue > thirdQuartile + (interquartileRange * 3))
                            {
                                // El valor si es un "Outlier".
                                // Agregar el indice del valor a la lista de "Outliers".
                                outliersIndices.Add(i);
                            }
                            else
                            {
                                // El valor no es un "Outlier".
                                // Agregar el indice del valor a la lista de posibles "Outliers".
                                possibleOutliersIndices.Add(i);
                            }
                        }
                    }
                }
            }

            // Verificar si se encontraron "Outliers".
            if (possibleOutliersIndices.Count == 0 && outliersIndices.Count == 0)
            {
                // No se encontraron outliers.
                // Abortar.
                return;
            }

            // Actualizar el valor del "Label" del valor del "Número de Outliers".
            LabelNumberOfOutliersValue.Text = (possibleOutliersIndices.Count + outliersIndices.Count).ToString();

            // Activar el "CheckBox" de "Mostrar Outliers".
            CheckBoxShowOutliers.Enabled = true;

            // Activar el botón de "Corregir Outliers".
            ButtonCorrectOutliers.Enabled = true;
        }

        private void ClearOutlierToolsAndVariables()
        {
            // Limpiar la "Label" del número de outliers.
            LabelNumberOfOutliersValue.Text = "N/A";

            // Limpiar el "CheckBox" que muestra los outliers.
            CheckBoxShowOutliers.Checked = false;
            CheckBoxShowOutliers.Enabled = false;

            // Bloquear el "Button" de "Corregir Outliers".
            ButtonCorrectOutliers.Enabled = false;

            // Limpiar las variables para la "Detección y Corrección de Outliers".
            possibleOutliersIndices.Clear();
            outliersIndices.Clear();
        }

        private void CheckBoxShowOutliers_CheckedChanged(object sender, EventArgs e)
        {
            // Verificar si ya se cargó un atributo.
            if (attributeData.Rows.Count == 0)
            {
                // Aun no se carga un atributo.
                // Abortar.
                return;
            }

            // Verificar el estado actual del "CheckBox".
            if (CheckBoxShowOutliers.Checked)
            {
                // El "CheckBox" se encuentra "Checked".
                // Colorear las celdas del "DataGridView" con la lista de índices de posibles "Outliers".
                for (int i = 0; i < possibleOutliersIndices.Count; i++)
                {
                    DataGridViewAttribute.Rows[possibleOutliersIndices[i]].Cells[0].Style.BackColor = possibleOutlierColour;
                }

                // Colorear las celdas del "DataGridView" con la lista de índices de "Outliers".
                for (int i = 0; i < outliersIndices.Count; i++)
                {
                    DataGridViewAttribute.Rows[outliersIndices[i]].Cells[0].Style.BackColor = outlierColour;
                }
            }
            else
            {
                // El "CheckBox" no se encuentra "Checked".
                // Limpiar las celdas del "DataGridView" con la lista de índices de posibles "Outliers".
                for (int i = 0; i < possibleOutliersIndices.Count; i++)
                {
                    DataGridViewAttribute.Rows[possibleOutliersIndices[i]].Cells[0].Style.BackColor = Color.White;
                }

                // Limpiar las celdas del "DataGridView" con la lista de índices de "Outliers".
                for (int i = 0; i < outliersIndices.Count; i++)
                {
                    DataGridViewAttribute.Rows[outliersIndices[i]].Cells[0].Style.BackColor = Color.White;
                }
            }
        }

        private void ButtonCorrectOutliers_Click(object sender, EventArgs e)
        {
            // Utilizar un "Form" de tipo "CorrectOutliers".
            using (CorrectOutliers correctOutliersform = new CorrectOutliers(dataSet, dataSetDataFile, ListBoxAttributes.SelectedIndex,categoricalAttributeValues, possibleOutliersIndices, outliersIndices))
            {
                // Mostar el "Form".
                if(correctOutliersform.ShowDialog() == DialogResult.OK)
                {
                    // Asignar "true" a la variable que indica si se realizaron cambios al conjunto de datos.
                    ChangesMade = true;

                    // Recargar la información del atributo.
                    GetAttributeInformation();
                    
                    // Desplegar mensaje de éxito.
                    MessageBox.Show("Se han corregido todos los outliers.", "Corregir Outliers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Verificar si se corrigió algún "Outlier".
                    if (correctOutliersform.ChangesMade)
                    {
                        // Se corrigió algún "Outlier".
                        // Asignar "true" a la variable que indica si se realizaron cambios al conjunto de datos.
                        ChangesMade = true;

                        // Recargar la información del atributo.
                        GetAttributeInformation();
                    }
                }
            }
        }

        private void GetSearchAndReplaceInformation()
        {
            // Activar la "TextBox" de buscar.
            TextBoxSearch.Enabled = true;

            // Activar la "TextBox" de reemplazar.
            TextBoxReplaceWith.Enabled = true;

            // Activar el botón de "Reemplazar Todo".
            ButtonReplaceEverything.Enabled = true;
        }

        private void ClearSearchAndReplaceToolsAndVariables()
        {
            // Limpiar la "TextBox" de buscar.
            TextBoxSearch.Text = "";
            TextBoxSearch.Enabled = false;

            // Limpiar la "TextBox" de reemplazar.
            TextBoxReplaceWith.Text = "";
            TextBoxReplaceWith.Enabled = false;

            // Bloquear el "Button" de "Reemplazar Todo".
            ButtonReplaceEverything.Enabled = false;
        }

        private void ButtonReplaceEverything_Click(object sender, EventArgs e)
        {
            // Verificar si el "TextBox" de "Buscar" se encuentra vacío.
            if (TextBoxSearch.Text == "")
            {
                // El "TextBox" de "Buscar" se encuentra vacío.
                // Desplegar mensaje de error.
                MessageBox.Show("El campo de \"Buscar\" se encuentra vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Buscar todas las ocurrencias de la cadena en los valores del atributo.
            List<int> searchIndices = Enumerable.Range(0, categoricalAttributeValues.Count).Where(value => categoricalAttributeValues[value] == TextBoxSearch.Text).ToList();

            // Verificar si se encontró por lo menos una ocurrencia de la cadena.
            if (searchIndices.Count == 0)
            {
                // No se encontró ninguna ocurrencia de la cadena.
                // Desplegar mensaje de error.
                MessageBox.Show("No se encontró \"" + TextBoxSearch.Text + "\" en el conjunto de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar el tipo de archivo.
            if (dataSetDataFile == null)
            {
                // Archivo CSV.
                // Reemplazar la cadena en los valores del atributo.
                for (int i = 0; i < searchIndices.Count; i++)
                {
                    // Reemplazar la cadena en la "DataTable".
                    dataSet.Rows[searchIndices[i]][ListBoxAttributes.SelectedIndex] = TextBoxReplaceWith.Text;
                }
            }
            else
            {
                // Archivo DATA.
                // Reemplazar la cadena en los valores del atributo.
                for (int i = 0; i < searchIndices.Count; i++)
                {
                    // Reemplazar la cadena en la "DataTable" y en el "DataFile".
                    dataSet.Rows[searchIndices[i]][ListBoxAttributes.SelectedIndex] = TextBoxReplaceWith.Text;
                    dataSetDataFile.Data[searchIndices[i]][ListBoxAttributes.SelectedIndex] = TextBoxReplaceWith.Text;
                }
            }

            // Asignar "true" a la variable que indica si se realizaron cambios al conjunto de datos.
            ChangesMade = true;

            // Recargar la información del atributo.
            GetAttributeInformation();

            // Desplegar mensaje de éxito.
            MessageBox.Show("Se reemplazaron " + searchIndices.Count + " valores en el conjunto de datos.", "Buscar y Reemplazar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GetTypographicErrorsInformation()
        {
            // Verificar si el archivo es de tipo CSV.
            if (dataSetDataFile == null)
            {
                // El archivo es de tipo CSV.
                // Abortar
                return;
            }

            // Verificar si el atributo es numérico.
            if (attribute.GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
            {
                // El atributo es numérico.
                // Abortar.
                return;
            }

            // Obtener lista de valores dentro y fuera del dominio
            for (int i = 0; i < categoricalAttributeValues.Count; i++)
            {
                // Asignar el valor del atributo a una variable.
                string value = categoricalAttributeValues[i];

                // Verificar si el valor se encuentra dentro del cominio.
                if (attribute.Domain.IsMatch(value))
                {
                    // El valor se encuentra dentro del dominio.
                    // Verificar si ya se encontró el mismo valor previamente.
                    if (!inOfDomainValues.Contains(value))
                    {
                        // Él valor no ha sido encontrado.
                        // Agregar el valor a la lista de valores dentro del dominio.
                        inOfDomainValues.Add(value);
                    }
                }
                else
                {
                    if (value != "" && value != dataSetDataFile.MissingValue)
                    {
                        outOfDomainValuesIndices.Add(i);
                    }
                }
            }

            // Verificar si se encontraron valores dentro o fuera del dominio.
            if (inOfDomainValues.Count == 0 || outOfDomainValuesIndices.Count == 0)
            {
                // No hay valores dentro o fuera del dominio.
                // Abortar.
                return;
            }

            // Actualizar el valor del "Label" del valor del "Número de Errores".
            LabelNumberOfErrorsValue.Text = outOfDomainValuesIndices.Count.ToString();

            // Activar el "CheckBox" de "Mostrar Errores".
            CheckBoxShowErrors.Enabled = true;

            // Activar el botón de "Corregir Errores".
            ButtonCorrectErrors.Enabled = true;
        }

        private void ClearTypographicErrorsToolsAndVariables()
        {
            // Limpiar la "Label" del número de errores.
            LabelNumberOfErrorsValue.Text = "N/A";

            // Limpiar el "CheckBox" que muestra los errores.
            CheckBoxShowErrors.Checked = false;
            CheckBoxShowErrors.Enabled = false;

            // Bloquear el "Button" de "Corregir Errores".
            ButtonCorrectErrors.Enabled = false;

            // Limpiar las variables para la "Detección de Errores Tipográficos".
            inOfDomainValues.Clear();
            outOfDomainValuesIndices.Clear();
        }

        private void CheckBoxShowErrors_CheckedChanged(object sender, EventArgs e)
        {
            // Verificar si ya se cargó un atributo.
            if (attributeData.Rows.Count == 0)
            {
                // Aun no se carga un atributo.
                // Abortar.
                return;
            }

            // Verificar el estado actual del "CheckBox".
            if (CheckBoxShowErrors.Checked)
            {
                // El "CheckBox" se encuentra "Checked".
                // Colorear las celdas del "DataGridView" con la lista de índices de valores fuera del dominio.
                for (int i = 0; i < outOfDomainValuesIndices.Count; i++)
                {
                    DataGridViewAttribute.Rows[outOfDomainValuesIndices[i]].Cells[0].Style.BackColor = outOfDomainColour;
                }
            }
            else
            {
                // El "CheckBox" no se encuentra "Checked".
                // Limpiar las celdas del "DataGridView" con la lista de índices de valores fuera del dominio.
                for (int i = 0; i < outOfDomainValuesIndices.Count; i++)
                {
                    DataGridViewAttribute.Rows[outOfDomainValuesIndices[i]].Cells[0].Style.BackColor = Color.White;
                }
            }
        }

        private void ButtonCorrectErrors_Click(object sender, EventArgs e)
        {
            // Utilizar un "Form" de tipo "CorrectTypographicErrors".
            using (CorrectTypographicErrors correctErrorsform = new CorrectTypographicErrors(dataSet, dataSetDataFile, ListBoxAttributes.SelectedIndex, categoricalAttributeValues, inOfDomainValues, outOfDomainValuesIndices))
            {
                // Mostar el "Form".
                if (correctErrorsform.ShowDialog() == DialogResult.OK)
                {
                    // Asignar "true" a la variable que indica si se realizaron cambios al conjunto de datos.
                    ChangesMade = true;

                    // Recargar la información del atributo.
                    GetAttributeInformation();

                    // Desplegar mensaje de éxito.
                    MessageBox.Show("Se han revisado todos los errores tipográficos.", "Corregir Errores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Verificar si se corrigió algún error tipográfico.
                    if (correctErrorsform.ChangesMade)
                    {
                        // Se corrigió algún "Outlier".
                        // Asignar "true" a la variable que indica si se realizaron cambios al conjunto de datos.
                        ChangesMade = true;

                        // Recargar la información del atributo.
                        GetAttributeInformation();
                    }
                }
            }
        }

        private void GetDataTransformationInformation()
        {
            // Verificar si el archivo es de tipo CSV.
            if (dataSetDataFile == null)
            {
                // El archivo es de tipo CSV.
                // Abortar
                return;
            }

            // Verificar si el atributo no es numérico.
            if (attribute.GetDataTypeIndex() != DataFileAttribute.AttributeDataType.Numeric)
            {
                // El atributo es categórico.
                // Abortar.
                return;
            }

            // Verificar si el atributo tiene valores numéricos.
            if (numericalAttributeValues.Count == 0)
            {
                // El atributo no tiene valores numéricos.
                // Abortar.
                return;
            }

            // Habilitar los "RadioButton" de "Min-Max", "Z-Score (Desviación Estándar)" y "Z-Score (Desviación Media Absoluta)".
            RadioButtonZScoreStandardDeviation.Enabled = true;
            RadioButtonZScoreMeanAbsoluteDeviation.Enabled = true;
            RadioButtonMinMax.Enabled = true;

            // Habilitar el "Button" de "Normalizar".
            ButtonNormalize.Enabled = true;
        }

        private void ClearDataTransformationToolsAndValues()
        {
            // Hacer "Check" en el "RadioButton" de "Z-Score (Desviación Estándar)".
            RadioButtonZScoreStandardDeviation.Checked = true;

            // Bloquear los "RadioButton" de "Min-Max", "Z-Score (Desviación Estándar)" y "Z-Score (Desviación Media Absoluta)".
            RadioButtonZScoreStandardDeviation.Enabled = false;
            RadioButtonZScoreMeanAbsoluteDeviation.Enabled = false;
            RadioButtonMinMax.Enabled = false;

            // Limpiar el "TextBox" de "Mínimo".
            TextBoxMinimum.Text = "";
            TextBoxMinimum.Enabled = false;

            // Limpiar el "TextBox" de "Máximo".
            TextBoxMaximum.Text = "";
            TextBoxMaximum.Enabled = false;

            // Limpiar el "TextBox" de "Nuevo Mínimo".
            TextBoxNewMinimum.Text = "";
            TextBoxNewMinimum.Enabled = false;

            // Limpiar el "TextBox" de "Nuevo Máximo".
            TextBoxNewMaximum.Text = "";
            TextBoxNewMaximum.Enabled = false;

            // Bloquear el "Button" de "Normalizar".
            ButtonNormalize.Enabled = false;

            // Limpiar las variables para la "Transformación de Datos".
            numericalValuesIndices.Clear();
        }

        private void RadioButtonMinMax_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonMinMax.Checked)
            {
                // Habilitar los "TextBox" de "Min-Max"
                TextBoxMinimum.Enabled = true;
                TextBoxMaximum.Enabled = true;
                TextBoxNewMinimum.Enabled = true;
                TextBoxNewMaximum.Enabled = true;
            }
            else
            {
                // Deshabilitar los "TextBox" de "Min-Max"
                TextBoxMinimum.Enabled = false;
                TextBoxMaximum.Enabled = false;
                TextBoxNewMinimum.Enabled = false;
                TextBoxNewMaximum.Enabled = false;
            }
        }

        private void ButtonNormalize_Click(object sender, EventArgs e)
        {
            // Verificar el tipo de normalización a realizar.
            if (RadioButtonZScoreStandardDeviation.Checked)
            {
                // Normalización Z-Score con desviación estándar.
                // Encontrar los índices de los valores numéricos.
                for (int i = 0; i < categoricalAttributeValues.Count; i++)
                {
                    // Asignar el valor actual del atributo.
                    string value = categoricalAttributeValues[i];

                    // Verificar si el valor es numérico.
                    if (double.TryParse(value, out double parsedValue))
                    {
                        // El valor es numérico.
                        // Agregar el índice a la lista de índices.
                        numericalValuesIndices.Add(i);
                    }
                }

                // Calcular la desviación estándar de los valores del atributo.
                double standardDeviation = GetStandardDeviation(numericalAttributeValues);

                // Verificar que la desviación estándar no sea 0.
                if (standardDeviation == 0)
                {
                    // La desviación estándar es 0.
                    // Desplegar mensaje de error.
                    MessageBox.Show("El atributo tiene una desviación estándar igual a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Normalizar los valores del atributo.
                for (int i = 0; i < numericalValuesIndices.Count; i++)
                {
                    // Convertir el valor del atributo a una variable de tipo "Double".
                    double.TryParse(categoricalAttributeValues[numericalValuesIndices[i]], out double value);

                    // Normalizar el valor actual.
                    string normalizedValue = ZScoreNormalization(value, standardDeviation).ToString();

                    // Realizar los cambios en la "DataTable"
                    dataSet.Rows[numericalValuesIndices[i]][ListBoxAttributes.SelectedIndex] = normalizedValue;

                    // Realizar los cambios en el "DataFile".
                    dataSetDataFile.Data[numericalValuesIndices[i]][ListBoxAttributes.SelectedIndex] = normalizedValue;
                }
            }
            else if (RadioButtonZScoreMeanAbsoluteDeviation.Checked)
            {
                // Normalización Z-Score con desviación media absoluta.
                // Encontrar los índices de los valores numéricos.
                for (int i = 0; i < categoricalAttributeValues.Count; i++)
                {
                    string value = categoricalAttributeValues[i];

                    if (double.TryParse(value, out double parsedValue))
                    {
                        numericalValuesIndices.Add(i);
                    }
                }

                // Calcular la desviación media absoluta de los valores del atributo.
                double meanAbsoluteDeviation = GetMeanAbsoluteDeviation(numericalAttributeValues);

                // Verificar que la desviación media absoluta no sea 0.
                if (meanAbsoluteDeviation == 0)
                {
                    // La desviación media absoluta es 0.
                    // Desplegar mensaje de error.
                    MessageBox.Show("El atributo tiene una desviación media absoluta igual a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Normalizar los valores del atributo.
                for (int i = 0; i < numericalValuesIndices.Count; i++)
                {
                    // Convertir el valor del atributo a una variable de tipo "Double".
                    double.TryParse(categoricalAttributeValues[numericalValuesIndices[i]], out double value);

                    // Normalizar el valor actual.
                    string normalizedValue = ZScoreNormalization(value, meanAbsoluteDeviation).ToString();

                    // Realizar los cambios en la "DataTable"
                    dataSet.Rows[numericalValuesIndices[i]][ListBoxAttributes.SelectedIndex] = normalizedValue;

                    // Realizar los cambios en el "DataFile".
                    dataSetDataFile.Data[numericalValuesIndices[i]][ListBoxAttributes.SelectedIndex] = normalizedValue;
                }
            }
            else
            {
                // Normalización Min-Max.
                // Verificar que el mínimo sea válido.
                if (!double.TryParse(TextBoxMinimum.Text, out double minimum))
                {
                    // Desplegar mensaje de error.
                    MessageBox.Show("El valor de \"mínimo\" es inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verificar que el máximo sea válido.
                if (!double.TryParse(TextBoxMaximum.Text, out double maximum))
                {
                    // Desplegar mensaje de error.
                    MessageBox.Show("El valor de \"máximo\" es inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verificar que el máximo sea mayor que el mínimo.
                if (maximum <= minimum)
                {
                    // El máximo es menor o igual que el mínimo.
                    // Desplegar mensaje de error.
                    MessageBox.Show("El valor de \"máximo\" es es menor o igual que \"mínimo\".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verificar que el nuevo mínimo sea válido.
                if (!double.TryParse(TextBoxNewMinimum.Text, out double newMinimum))
                {
                    // Desplegar mensaje de error.
                    MessageBox.Show("El valor de \"nuevo mínimo\" es inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verificar que el máximo sea válido.
                if (!double.TryParse(TextBoxNewMaximum.Text, out double newMaximum))
                {
                    // Desplegar mensaje de error.
                    MessageBox.Show("El valor de \"nuevo máximo\" es inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verificar que el nuevo máximo sea mayor que el nuevo mínimo.
                if (newMaximum <= newMinimum)
                {
                    // El nuevo máximo es menor o igual que el nuevo mínimo.
                    // Desplegar mensaje de error.
                    MessageBox.Show("El valor de \"nuevo máximo\" es es menor o igual que \"nuevo mínimo\".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Encontrar los índices de los valores numéricos.
                for (int i = 0; i < categoricalAttributeValues.Count; i++)
                {
                    string value = categoricalAttributeValues[i];

                    if (double.TryParse(value, out double parsedValue))
                    {
                        numericalValuesIndices.Add(i);
                    }
                }

                // Normalizar los valores del atributo.
                for (int i = 0; i < numericalValuesIndices.Count; i++)
                {
                    // Convertir el valor del atributo a una variable de tipo "Double".
                    double.TryParse(categoricalAttributeValues[numericalValuesIndices[i]], out double value);

                    // Normalizar el valor actual.
                    string normalizedValue = MinMaxNormalization(value, minimum, maximum, newMinimum, newMaximum).ToString();

                    // Realizar los cambios en la "DataTable"
                    dataSet.Rows[numericalValuesIndices[i]][ListBoxAttributes.SelectedIndex] = normalizedValue;

                    // Realizar los cambios en el "DataFile".
                    dataSetDataFile.Data[numericalValuesIndices[i]][ListBoxAttributes.SelectedIndex] = normalizedValue;
                }
            }

            // Asignar "true" a la variable que indica si se realizaron cambios al conjunto de datos.
            ChangesMade = true;

            // Recargar la información del atributo.
            GetAttributeInformation();
        }

        private double GetStandardDeviation(List<double> values)
        {
            // Retornar la desviación estándar del conjunto de valores.
            return Math.Sqrt(values.Sum(value => Math.Pow(value - mean, 2)) / values.Count);
        }

        private double ZScoreNormalization(double value, double deviation)
        {
            // Retornar el valor normalizado con Z-Score con la desviación estándar.
            return (value - mean) / deviation;
        }

        private double GetMeanAbsoluteDeviation(List<double> values)
        {
            // Variable para almacenar la sumatoria de los valores.
            double summation = 0;

            // Realizar la sumatoria de los valores menos la media.
            for (int i = 0; i < values.Count; i++)
            {
                summation += Math.Abs(values[i] - mean);
            }

            // Retornar la desviación media absoluta del conjunto de valores.
            return summation / values.Count;
        }

        private double MinMaxNormalization(double value, double minimum, double maximum, double newMinimum, double newMaximum)
        {
            // Retornar el valor normalizado con Min-Max.
            return (value - minimum) / (maximum - minimum) * (newMaximum - newMinimum) + newMinimum;
        }
    }
}