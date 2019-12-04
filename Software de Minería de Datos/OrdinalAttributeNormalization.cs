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
    public partial class OrdinalAttributeNormalization : Form
    {
        // Variables.
        IEnumerable<IGrouping<string, string>> ordinalAttributePossibleValues;
        public List<int> OrdinalAttributePossibleValuesNumericalValues { get; set; }
        int ordinalAttributePossibleValuesIndex;

        public OrdinalAttributeNormalization(IEnumerable<IGrouping<string, string>> newOrdinalAttributePossibleValues)
        {
            InitializeComponent();

            // Inicializar las variables.
            ordinalAttributePossibleValues = newOrdinalAttributePossibleValues;
            OrdinalAttributePossibleValuesNumericalValues = new List<int>(new int[ordinalAttributePossibleValues.Count()]);
            ordinalAttributePossibleValuesIndex = 0;

            // Modificar las herramientas.
            NumericUpDownNumericalValue.Maximum = ordinalAttributePossibleValues.Count();

            // Actualizar los valores del atributo.
            UpdateAttributeValue();

            // Deshabilitar el botón de "Anterior".
            ButtonPrevious.Enabled = false;
        }

        private void UpdateAttributeValue()
        {
            // Actualizar el "TextBox" de "Valor del Atributo".
            TextBoxAttributeValue.Text = ordinalAttributePossibleValues.ElementAt(ordinalAttributePossibleValuesIndex).Key;

            // Verificar si el valor numérico es 0.
            if (OrdinalAttributePossibleValuesNumericalValues[ordinalAttributePossibleValuesIndex] == 0)
            {
                // El valor numérico es 0.
                // Actualizar el "NumericUpDown" de "Valor Numérico".
                NumericUpDownNumericalValue.Value = 1;
            }
            else
            {
                // El valor numérico no es 0.
                // Actualizar el "NumericUpDown" de "Valor Numérico".
                NumericUpDownNumericalValue.Value = OrdinalAttributePossibleValuesNumericalValues[ordinalAttributePossibleValuesIndex];
            }
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            // Almacenar el valor numérico del valor del atributo.
            OrdinalAttributePossibleValuesNumericalValues[ordinalAttributePossibleValuesIndex] = (int)NumericUpDownNumericalValue.Value;

            // Verificar si se dio click en "Aceptar".
            if (ButtonNext.Text == "Aceptar")
            {
                // Se dió click en "Aceptar".
                // Asignar un "DialogResult" de "OK" y retornar.
                DialogResult = DialogResult.OK;
                return;
            }

            // Incrementar una unidad el índice de las matrices de confusión.
            ordinalAttributePossibleValuesIndex++;

            // Actualizar el contenido del "DataGridView".
            UpdateAttributeValue();

            // Verificar si el índice es del segundo valor del atributo.
            if (ordinalAttributePossibleValuesIndex == 1)
            {
                // Habilitar botón de "Anterior".
                ButtonPrevious.Enabled = true;
            }

            // Verificar si el índice es de la última matriz.
            if (ordinalAttributePossibleValuesIndex == ordinalAttributePossibleValues.Count() - 1)
            {
                // Cambiar el texto del botón de "Siguiente".
                ButtonNext.Text = "Aceptar";
            }
        }

        private void ButtonPrevious_Click(object sender, EventArgs e)
        {
            // Almacenar el valor numérico del valor del atributo.
            OrdinalAttributePossibleValuesNumericalValues[ordinalAttributePossibleValuesIndex] = (int)NumericUpDownNumericalValue.Value;

            // Decrementar una unidad el índice de las matrices de confusión.
            ordinalAttributePossibleValuesIndex--;

            // Actualizar el contenido del "DataGridView".
            UpdateAttributeValue();

            // Verificar si el índice es de la penúltima matriz.
            if (ordinalAttributePossibleValuesIndex == ordinalAttributePossibleValues.Count() - 2)
            {
                // Cambiar el texto del botón de "Aceptar".
                ButtonNext.Text = "Siguiente";
            }

            // Verificar si el índice es de la primera matriz.
            if (ordinalAttributePossibleValuesIndex == 0)
            {
                // Deshabilitar botón de "Anterior".
                ButtonPrevious.Enabled = false;
            }
        }
    }
}
