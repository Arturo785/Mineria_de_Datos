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
    public partial class DataEntry : Form
    {
        // Enum con las posiciones de las columnas adicionales ("Eliminar Instancia", "Instancia" y "DataTable").
        enum ColumnIndex { DeleteInstanceButton, Instance, DataTable }

        // Enum con los indices del filtro del SaveFileDialog ("CSV" y "DATA")
        public enum SaveFileDialogFilter { CSV = 1, DATA }

        // Variables publicas.
        public bool ChangesMade { get; set; }

        // Variables.
        DataTable dataSet;
        public DataFile DataSetDataFile { get; set; }
        BindingSource bindingDataSet;
        int numberOfMissingValues;

        public DataEntry(DataTable newDataSet)
        {
            InitializeComponent();

            // Asignar DataTable global a DataTable local.
            dataSet = newDataSet;

            // Filtrar los archivos que se pueden leer y escribir (*.csv y *.data).
            OpenFileDialogDataSet.Filter = "Archivos de Minería (*.csv, *.data)|*.csv;*.data;";
            SaveFileDialogDataSet.Filter = "Archivo CSV (*.csv)|*.csv|Archivo DATA (*.data)|*.data";

            // Inicializar la BindingSource.
            bindingDataSet = new BindingSource();

            // Inicializar la variable que determina si se realizó un cambio sin guardar.
            ChangesMade = false;
        }

        public void UpdateContent()
        {
            // Verificar si el conjunto de datos tiene datos.
            if (dataSet.Rows.Count != 0)
            {
                // El conjunto de datos si tiene datos.
                // Verificar el tipo del archivo.
                if (DataSetDataFile != null)
                {
                    // Archivo CSV.
                    // Encontrar valores faltantes y valores fuera del dominio para colorear las celdas.
                    FindMissingAndOutOfDomainValues();
                }
                else
                {
                    // Archivo DATA.
                    // Encontrar valores faltantes para colorear las celdas.
                    FindMissingValues();
                }
            }
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Se verifica si se realizó un cambio sin guardar.
            if (ChangesMade)
            {
                DialogResult saveChangesMade = MessageBox.Show("¿Desea guardar los cambios realizados en \"" + Path.GetFileName(OpenFileDialogDataSet.FileName) + "\"?", "Software de Minería de Datos", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                switch (saveChangesMade)
                {
                    case DialogResult.Yes:
                        SaveFile();
                        break;

                    case DialogResult.Cancel:
                        return;
                }
            }

            if (OpenFileDialogDataSet.ShowDialog() == DialogResult.OK)
            {
                LoadFile();
            }
        }

        private void LoadFile()
        {
            string fileExtension = Path.GetExtension(OpenFileDialogDataSet.FileName);

            // Se limpia el archivo DATA.
            DataSetDataFile = null;

            // Se limpia la DataTable local.
            dataSet.Columns.Clear();
            dataSet.Rows.Clear();

            // Se limpia el DataGridView.
            DataGridViewDataSet.Columns.Clear();
            DataGridViewDataSet.DataSource = null;

            // Se resetea la variable Bool.
            ChangesMade = false;

            // Se verifica el tipo del archivo a leer.
            if (fileExtension == ".csv")
            {
                // Leer el archivo CSV.
                ReadCSVFile();
            }
            else
            {
                // Leer el archivo DATA.
                ReadDATAFile();
            }

            // Cargar en el DataGridView el contenido del archivo leido con la BindingSource.
            bindingDataSet.DataSource = dataSet;
            DataGridViewDataSet.DataSource = bindingDataSet;

            // Agregar al DataGridView las columnas con el número de instancia y con el botón de eliminar.
            DataGridViewButtonColumn ColumnDeleteInstanceButton = new DataGridViewButtonColumn()
            {
                Name = "Eliminar Instancia",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true
            };

            DataGridViewColumn ColumnInstance = new DataGridViewColumn()
            {
                HeaderText = "Instancia",
                ReadOnly = true,
                CellTemplate = new DataGridViewTextBoxCell()
            };

            DataGridViewDataSet.Columns.Insert((int)ColumnIndex.DeleteInstanceButton, ColumnDeleteInstanceButton);
            DataGridViewDataSet.Columns.Insert((int)ColumnIndex.Instance, ColumnInstance);

            // Colocar el numero de instancia en la columna de "Instancia" del DataGridView
            FillInstanceColumn();

            // Obtener y mostrar la información del conjunto de datos.
            LabelDatasetNameValue.Text = Path.GetFileNameWithoutExtension(OpenFileDialogDataSet.FileName);
            LabelDataSetInstanceQuantityValue.Text = dataSet.Rows.Count.ToString();
            LabelDataSetAttributeQuantityValue.Text = dataSet.Columns.Count.ToString();

            // Encontrar valores faltantes y valores fuera del dominio para colorear las celdas.
            if (DataSetDataFile != null)
            {
                FindMissingAndOutOfDomainValues();
            }
            else
            {
                FindMissingValues();
            }
        }

        private void ReadCSVFile()
        {
            StreamReader csvFileContent = new StreamReader(OpenFileDialogDataSet.FileName);
            string csvFileLine = csvFileContent.ReadLine();
            string[] csvFileLineValues = csvFileLine.Split(',');

            // Insertar atributos en la DataTable.
            foreach (string lineValue in csvFileLineValues)
            {
                dataSet.Columns.Add(lineValue);
            }

            // Insertar instancias en la DataTable.
            while (!csvFileContent.EndOfStream)
            {
                csvFileLine = csvFileContent.ReadLine();
                csvFileLineValues = csvFileLine.Split(',');

                dataSet.Rows.Add(csvFileLineValues);
            }
        }

        private void ReadDATAFile()
        {
            // Leer archivo DATA y crear objeto.
            DataSetDataFile = new DataFile(OpenFileDialogDataSet.FileName);

            // Insertar atributos en la DataTable.
            foreach (DataFileAttribute dataSetAttribute in DataSetDataFile.Attributes)
            {
                dataSet.Columns.Add(dataSetAttribute.Name);
            }

            // Insertar instancias en la DataTable.
            string[] dataSetRow;

            for (int i = 0; i < DataSetDataFile.Data.Count; i++)
            {
                dataSetRow = DataSetDataFile.Data[i].ToArray();

                // Reemplazar valores faltantes con el símbolo especificado.
                for (int j = 0; j < dataSetRow.Length; j++)
                {
                    if (dataSetRow[j] == "")
                    {
                        dataSetRow[j] = DataSetDataFile.MissingValue;
                    }
                }

                dataSet.Rows.Add(dataSetRow);
            }
        }

        private void FillInstanceColumn()
        {
            int i = 0;
            while (i < dataSet.Rows.Count)
            {
                DataGridViewDataSet.Rows[i].Cells[(int)ColumnIndex.Instance].Value = ++i;
            }
        }

        private void FindMissingValues()
        {
            numberOfMissingValues = 0;

            // Buscar valores faltantes y colorear su celda.
            for (int i = 0; i < dataSet.Rows.Count; i++)
            {
                for (int j = 0; j < dataSet.Columns.Count; j++)
                {
                    if (dataSet.Rows[i][j].ToString() ==  "")
                    {
                        DataGridViewDataSet.Rows[i].Cells[j + (int)ColumnIndex.DataTable].Style.BackColor = Color.Red;

                        numberOfMissingValues++;
                    }
                    else
                    {
                        DataGridViewDataSet.Rows[i].Cells[j + (int)ColumnIndex.DataTable].Style.BackColor = Color.White;
                    }
                }
            }

            // Mostrar número de valores faltantes con su proporción respecto al total de valores.
            SetLabelDataSetMissingValuesValue();
        }

        private void FindMissingAndOutOfDomainValues()
        {
            string value;

            numberOfMissingValues = 0;

            // Buscar valores faltantes y fuera del dominio; y colorear su celda.
            for (int i = 0; i < dataSet.Rows.Count; i++)
            {
                for (int j = 0; j < dataSet.Columns.Count; j++)
                {
                    value = dataSet.Rows[i][j].ToString();

                    if (!DataSetDataFile.Attributes[j].Domain.IsMatch(value))
                    {
                        if (value == DataSetDataFile.MissingValue || value == "")
                        {
                            DataGridViewDataSet.Rows[i].Cells[j + (int)ColumnIndex.DataTable].Style.BackColor = Color.Red;

                            numberOfMissingValues++;
                        }
                        else
                        {
                            DataGridViewDataSet.Rows[i].Cells[j + (int)ColumnIndex.DataTable].Style.BackColor = Color.Gold;
                        }
                    }
                    else
                    {
                        DataGridViewDataSet.Rows[i].Cells[j + (int)ColumnIndex.DataTable].Style.BackColor = Color.White;
                    }
                }
            }

            // Mostrar número de valores faltantes con su proporción respecto al total de valores.
            SetLabelDataSetMissingValuesValue();
        }

        private void SetLabelDataSetMissingValuesValue()
        {
            // Actualizar el Label de valores faltantes.
            LabelDataSetMissingValuesValue.Text = numberOfMissingValues + " (" + (numberOfMissingValues * 100) / (dataSet.Columns.Count * dataSet.Rows.Count) + "% del total)";
        }

        private void DataGridViewDataSet_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            // Fijar que toda nueva columna no pueda ser ordenada.
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void SaveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenFileDialogDataSet.FileName == "Data Mining File")
            {
                MessageBox.Show("No se ha cargado ningún conjunto de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFile();
        }

        public void SaveFile()
        {
            if (DataSetDataFile != null)
            {
                File.WriteAllText(OpenFileDialogDataSet.FileName, DataSetDataFile.Save());
            }
            else
            {
                File.WriteAllText(OpenFileDialogDataSet.FileName, SaveFileAsCSV());
            }

            ChangesMade = false;
        }

        private string SaveFileAsCSV()
        {
            string CSVFile = "";
            int i;

            for (i = 0; i < dataSet.Columns.Count - 1; i++)
            {
                CSVFile += dataSet.Columns[i].Caption + ",";
            }

            CSVFile += dataSet.Columns[i] + "\n";

            foreach (DataRow instance in dataSet.Rows)
            {
                for (i = 0; i < dataSet.Columns.Count - 1; i++)
                {
                    CSVFile += instance[i].ToString() + ",";
                }

                CSVFile += instance[i].ToString() + "\n";
            }

            return CSVFile;
        } 

        private void SaveFileAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenFileDialogDataSet.FileName == "Data Mining File")
            {
                MessageBox.Show("No se ha cargado ningún conjunto de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialogDataSet.FileName = Path.GetFileNameWithoutExtension(OpenFileDialogDataSet.FileName);

            if (SaveFileDialogDataSet.ShowDialog() == DialogResult.OK)
            {
                switch (SaveFileDialogDataSet.FilterIndex)
                {
                    case (int)SaveFileDialogFilter.CSV:
                        File.WriteAllText(SaveFileDialogDataSet.FileName, SaveFileAsCSV());
                        break;

                    case (int)SaveFileDialogFilter.DATA:

                        using (SaveFileAsDATA saveFileAsDATAForm = new SaveFileAsDATA(dataSet, DataSetDataFile))
                        {
                            if (saveFileAsDATAForm.ShowDialog() == DialogResult.OK)
                            {
                                File.WriteAllText(SaveFileDialogDataSet.FileName, saveFileAsDATAForm.DataSetDataFile.Save());
                            }
                            else
                            {
                                return;
                            }
                        }

                        break;
                }

                // Hacer el cambio al nuevo archivo.
                OpenFileDialogDataSet.FileName = SaveFileDialogDataSet.FileName;
                LoadFile();
            }
        }

        private void AddAttributeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenFileDialogDataSet.FileName == "Data Mining File")
            {
                MessageBox.Show("No se ha cargado ningún conjunto de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear un Form "AddAttribute" para agregar el atributo. Se envía la DataTable y el DataFile que determina si es el archivo es de tipo DATA o CSV.
            using (AddAttribute addAttributeForm = new AddAttribute(dataSet, DataSetDataFile))
            {
                if (addAttributeForm.ShowDialog() == DialogResult.OK)
                {
                    // Sumar 1 al Label con el número de atributos.
                    LabelDataSetAttributeQuantityValue.Text = (Convert.ToInt32(LabelDataSetAttributeQuantityValue.Text) + 1).ToString();

                    // Verificar que haya instancias en el conjunto de datos.
                    if (dataSet.Rows.Count != 0)
                    {
                        if (DataSetDataFile != null)
                        {
                            FindMissingAndOutOfDomainValues();
                        }
                        else
                        {
                            FindMissingValues();
                        }

                        FillInstanceColumn();
                    }

                    // Se agregó un atributo, por lo tanto, la variable bool pasa a ser verdadera.
                    ChangesMade = true;
                }
            }
        }

        private void EditAttributeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenFileDialogDataSet.FileName == "Data Mining File")
            {
                MessageBox.Show("No se ha cargado ningún conjunto de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataSet.Columns.Count == 0)
            {
                MessageBox.Show("No hay atributos en el conjunto de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear un Form "EditAttribute" para editar los atributos. Se envía la DataTable y el DataFile que determina si es el archivo es de tipo DATA o CSV.
            using (EditAttribute editAttributeForm = new EditAttribute(dataSet, DataSetDataFile))
            {
                if (editAttributeForm.ShowDialog() == DialogResult.OK)
                {
                    // Verificar que haya instancias en el conjunto de datos.
                    if (dataSet.Rows.Count != 0)
                    {
                        if (DataSetDataFile != null)
                        {
                            FindMissingAndOutOfDomainValues();
                        }
                        else
                        {
                            FindMissingValues();
                        }

                        FillInstanceColumn();
                    }

                    // Se editó un atributo, por lo tanto, la variable bool pasa a ser verdadera.
                    ChangesMade = true;
                }
            }
        }

        private void DeleteAttributeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenFileDialogDataSet.FileName == "Data Mining File")
            {
                MessageBox.Show("No se ha cargado ningún conjunto de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataSet.Columns.Count == 0)
            {
                MessageBox.Show("No hay atributos en el conjunto de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear un Form "DeleteAttribute" para eliminar los atributos. Se envía la DataTable y el DataFile que determina si es el archivo es de tipo DATA o CSV.
            using (DeleteAttribute deleteAttributeForm = new DeleteAttribute(dataSet, DataSetDataFile))
            {
                if (deleteAttributeForm.ShowDialog() == DialogResult.OK)
                {
                    if (dataSet.Columns.Count == 0)
                    {
                        LabelDataSetAttributeQuantityValue.Text = "0";
                        LabelDataSetInstanceQuantityValue.Text = "0";
                        LabelDataSetMissingValuesValue.Text = "0 (0 % del total)";
                    }
                    else
                    {
                        // Restar 1 al Label con el número de atributos.
                        LabelDataSetAttributeQuantityValue.Text = (Convert.ToInt32(LabelDataSetAttributeQuantityValue.Text) - 1).ToString();

                        // Verificar que haya instancias en el conjunto de datos.
                        if (dataSet.Rows.Count != 0)
                        {
                            if (DataSetDataFile != null)
                            {
                                FindMissingAndOutOfDomainValues();
                            }
                            else
                            {
                                FindMissingValues();
                            }

                            FillInstanceColumn();
                        }
                    }

                    // Se eliminó un atributo, por lo tanto, la variable bool pasa a ser verdadera.
                    ChangesMade = true;
                }
            }
        }

        private void AttributeInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenFileDialogDataSet.FileName == "Data Mining File")
            {
                MessageBox.Show("No se ha cargado ningún conjunto de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataSet.Columns.Count == 0)
            {
                MessageBox.Show("No hay atributos en el conjunto de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (AttributeInformation attributeInformationForm = new AttributeInformation(dataSet, DataSetDataFile))
            {
                attributeInformationForm.ShowDialog();
            }
        }

        private void AddInstanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenFileDialogDataSet.FileName == "Data Mining File")
            {
                MessageBox.Show("No se ha cargado ningún conjunto de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataSet.Columns.Count == 0)
            {
                MessageBox.Show("No hay atributos en el conjunto de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear un Form "AddInstances" para agregar instancias. Se envía la DataTable y el DataFile que determina si es el archivo es de tipo DATA o CSV.
            using (AddInstances addInstancesForm = new AddInstances(dataSet, DataSetDataFile))
            {
                if (addInstancesForm.ShowDialog() == DialogResult.OK)
                {
                    // Sumar al Label el número de instancias nuevas.
                    LabelDataSetInstanceQuantityValue.Text = (Convert.ToInt32(LabelDataSetInstanceQuantityValue.Text) + addInstancesForm.NumberOfInstancesAdded).ToString();

                    if (DataSetDataFile != null)
                    {
                        FindMissingAndOutOfDomainValues();
                    }
                    else
                    {
                        FindMissingValues();
                    }

                    FillInstanceColumn();

                    // Se agregó una instancia, por lo tanto, la variable bool pasa a ser verdadera.
                    ChangesMade = true;
                }
            }
        }

        private void DataGridViewDataSet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < (int)ColumnIndex.DataTable)
            {
                return;
            }

            DataGridViewCell modifiedCell = DataGridViewDataSet.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (DataSetDataFile != null)
            {
                if (modifiedCell.Style.BackColor == Color.Red)
                {
                    if (DataSetDataFile.Attributes[e.ColumnIndex - (int)ColumnIndex.DataTable].Domain.IsMatch(modifiedCell.Value.ToString()))
                    {
                        modifiedCell.Style.BackColor = Color.White;

                        numberOfMissingValues--;
                        SetLabelDataSetMissingValuesValue();

                        DataSetDataFile.Data[e.RowIndex][e.ColumnIndex - (int)ColumnIndex.DataTable] = DataGridViewDataSet[e.ColumnIndex, e.RowIndex].Value.ToString();
                    }
                    else
                    {
                        if (modifiedCell.Value.ToString() != DataSetDataFile.MissingValue && modifiedCell.Value.ToString() != "")
                        {
                            modifiedCell.Style.BackColor = Color.Gold;

                            numberOfMissingValues--;
                            SetLabelDataSetMissingValuesValue();

                            DataSetDataFile.Data[e.RowIndex][e.ColumnIndex - (int)ColumnIndex.DataTable] = DataGridViewDataSet[e.ColumnIndex, e.RowIndex].Value.ToString();
                        }
                    }
                }
                else if (modifiedCell.Style.BackColor == Color.Gold)
                {
                    if (DataSetDataFile.Attributes[e.ColumnIndex - (int)ColumnIndex.DataTable].Domain.IsMatch(modifiedCell.Value.ToString()))
                    {
                        modifiedCell.Style.BackColor = Color.White;

                        DataSetDataFile.Data[e.RowIndex][e.ColumnIndex - (int)ColumnIndex.DataTable] = DataGridViewDataSet[e.ColumnIndex, e.RowIndex].Value.ToString();
                    }
                    else
                    {
                        if (modifiedCell.Value.ToString() == DataSetDataFile.MissingValue || modifiedCell.Value.ToString() == "")
                        {
                            modifiedCell.Style.BackColor = Color.Red;

                            numberOfMissingValues++;
                            SetLabelDataSetMissingValuesValue();

                            DataSetDataFile.Data[e.RowIndex][e.ColumnIndex - (int)ColumnIndex.DataTable] = "";
                        }
                        else
                        {
                            DataSetDataFile.Data[e.RowIndex][e.ColumnIndex - (int)ColumnIndex.DataTable] = DataGridViewDataSet[e.ColumnIndex, e.RowIndex].Value.ToString();
                        }
                    }
                }
                else
                {
                    if (!DataSetDataFile.Attributes[e.ColumnIndex - (int)ColumnIndex.DataTable].Domain.IsMatch(modifiedCell.Value.ToString()))
                    {
                        if (modifiedCell.Value.ToString() == DataSetDataFile.MissingValue || modifiedCell.Value.ToString() == "")
                        {
                            modifiedCell.Style.BackColor = Color.Red;

                            numberOfMissingValues++;
                            SetLabelDataSetMissingValuesValue();

                            DataSetDataFile.Data[e.RowIndex][e.ColumnIndex - (int)ColumnIndex.DataTable] = "";
                        }
                        else
                        {
                            modifiedCell.Style.BackColor = Color.Gold;

                            DataSetDataFile.Data[e.RowIndex][e.ColumnIndex - (int)ColumnIndex.DataTable] = DataGridViewDataSet[e.ColumnIndex, e.RowIndex].Value.ToString();
                        }
                    }
                    else
                    {
                        DataSetDataFile.Data[e.RowIndex][e.ColumnIndex - (int)ColumnIndex.DataTable] = DataGridViewDataSet[e.ColumnIndex, e.RowIndex].Value.ToString();
                    }
                }
            }
            else
            {
                if (modifiedCell.Style.BackColor == Color.Red)
                {
                    if (modifiedCell.Value.ToString() != "")
                    {
                        modifiedCell.Style.BackColor = Color.White;

                        numberOfMissingValues--;
                        SetLabelDataSetMissingValuesValue();
                    }
                }
                else
                {
                    if (modifiedCell.Value.ToString() == "")
                    {
                        modifiedCell.Style.BackColor = Color.Red;

                        numberOfMissingValues++;
                        SetLabelDataSetMissingValuesValue();
                    }
                }
            }

            // Se realizaron cambios en la DataTable, por lo tanto, la variable bool pasa a ser verdadera.
            ChangesMade = true;
        }

        private void DataGridViewDataSet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                // Eliminar instancia de la DataTable.
                dataSet.Rows.RemoveAt(e.RowIndex);

                LabelDataSetInstanceQuantityValue.Text = dataSet.Rows.Count.ToString();

                if (dataSet.Rows.Count == 0)
                {
                    LabelDataSetInstanceQuantityValue.Text = "0";
                    LabelDataSetMissingValuesValue.Text = "0 (0 % del total)";

                    if (DataSetDataFile != null)
                    {
                        DataSetDataFile.Data.Clear();
                    }
                }
                else
                {
                    FillInstanceColumn();

                    if (DataSetDataFile != null)
                    {
                        DataSetDataFile.Data.RemoveAt(e.RowIndex);

                        FindMissingAndOutOfDomainValues();
                    }
                    else
                    {
                        FindMissingValues();
                    }
                }

                // Se eliminó una instancia, por lo tanto, la variable bool pasa a ser verdadera.
                ChangesMade = true;
            }
        }
    }
}
