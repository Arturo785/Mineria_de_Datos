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
    public partial class KInstancesAndClustersInformation : Form
    {
        // Variables.
        List<List<DataTable>> kInstancesAndClusters;
        int kInstancesAndClustersIndex;

        public KInstancesAndClustersInformation(List<List<DataTable>> newKInstancesAndClusters)
        {
            InitializeComponent();

            // Inicializar las variables.
            kInstancesAndClusters = newKInstancesAndClusters;
            kInstancesAndClustersIndex = 0;

            // Actualizar el "DataGridView" de la instancia.
            UpdateKInstanceDataGridView();

            // Actualizar el "DataGridView" del clúster.
            UpdateKClusterDataGridView();

            // Deshabilitar el botón de "Anterior".
            ButtonPrevious.Enabled = false;

            // Verificar si solo hay una instancia y clúster.
            if (kInstancesAndClusters[0].Count == 1)
            {
                // Solo hay una instancia y clúster.
                // Deshabilitar el botón de "Siguiente".
                ButtonNext.Enabled = false;
            }
        }

        private void UpdateKInstanceDataGridView()
        {
            // Actualizar el "DataSource" del "DataGridView".
            DataGridViewKInstance.DataSource = null;
            DataGridViewKInstance.DataSource = kInstancesAndClusters[0][kInstancesAndClustersIndex];

            // Asignar un valor al label de "K".
            LabelKValue.Text = (kInstancesAndClustersIndex + 1).ToString();
        }

        private void UpdateKClusterDataGridView()
        {
            // Actualizar el "DataSource" del "DataGridView".
            DataGridViewKCluster.DataSource = null;
            DataGridViewKCluster.DataSource = kInstancesAndClusters[1][kInstancesAndClustersIndex];
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            // Incrementar una unidad el índice de las instancias y clústeres.
            kInstancesAndClustersIndex++;

            // Actualizar el "DataGridView" de la instancia.
            UpdateKInstanceDataGridView();

            // Actualizar el "DataGridView" del clúster.
            UpdateKClusterDataGridView();

            // Verificar si el índice es de la segunda instancia y clúster.
            if (kInstancesAndClustersIndex == 1)
            {
                // Habilitar botón de "Anterior".
                ButtonPrevious.Enabled = true;
            }

            // Verificar si el índice es de la última instancia y clúster.
            if (kInstancesAndClustersIndex == kInstancesAndClusters[0].Count - 1)
            {
                // Deshabilitar botón de "Siguiente".
                ButtonNext.Enabled = false;
            }
        }

        private void ButtonPrevious_Click(object sender, EventArgs e)
        {
            // Decrementar una unidad el índice de las instancias y clústeres.
            kInstancesAndClustersIndex--;

            // Actualizar el "DataGridView" de la instancia.
            UpdateKInstanceDataGridView();

            // Actualizar el "DataGridView" del clúster.
            UpdateKClusterDataGridView();

            // Verificar si el índice es de la penúltima instancia y clústere.
            if (kInstancesAndClustersIndex == kInstancesAndClusters[0].Count - 2)
            {
                // Habilitar botón de "Siguiente".
                ButtonNext.Enabled = true;
            }

            // Verificar si el índice es de la primera instancia y clústere.
            if (kInstancesAndClustersIndex == 0)
            {
                // Deshabilitar botón de "Anterior".
                ButtonPrevious.Enabled = false;
            }
        }
    }
}
