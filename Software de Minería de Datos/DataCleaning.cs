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
    public partial class DataCleaning : Form
    {
        // Variables.
        DataTable dataSet;
        public AttributeCleaning AttributeCleaningForm { get; set; }
        DataSampling dataSamplingForm;

        public DataCleaning(DataTable newDataSet)
        {
            InitializeComponent();

            // Asignar la "DataTable" global a la local.
            dataSet = newDataSet;

            // Inicializar Form "AttributeCleaning".
            AttributeCleaningForm = new AttributeCleaning(dataSet)
            {
                TopLevel = false,
                Visible = true,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            // Agregar Form "AttributeCleaning" en Tab Page "TabPageAttributeCleaning".
            TabPageAttributeCleaning.Controls.Add(AttributeCleaningForm);

            // Inicializar Form "DataSampling".
            dataSamplingForm= new DataSampling(dataSet)
            {
                TopLevel = false,
                Visible = true,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            // Agregar Form "DataSampling" en Tab Page "TabPageDataSampling".
            TabPageDataSampling.Controls.Add(dataSamplingForm);
        }

        public void UpdateContent(DataFile newDataSetDataFile)
        {
            // Actualizar el contenido del "Form" de "Limpieza de Atributos".
            AttributeCleaningForm.UpdateContent(newDataSetDataFile);

            // Actualizar el contenido del "Form" de "Muestreo de Datos".
            dataSamplingForm.UpdateContent(newDataSetDataFile);
        }
    }
}
