namespace Software_de_Minería_de_Datos
{
    partial class BivariateAnalysis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.GroupBoxAttributes = new System.Windows.Forms.GroupBox();
            this.GroupBoxAttributeNumberTwo = new System.Windows.Forms.GroupBox();
            this.LabelAttributeNumberTwoTypeValue = new System.Windows.Forms.Label();
            this.LabelAttributeNumberTwo = new System.Windows.Forms.Label();
            this.ComboBoxAttributeNumberTwo = new System.Windows.Forms.ComboBox();
            this.LabelAttributeNumberTwoType = new System.Windows.Forms.Label();
            this.GroupBoxAttributeNumberOne = new System.Windows.Forms.GroupBox();
            this.LabelAttributeNumberOne = new System.Windows.Forms.Label();
            this.LabelAttributeNumberOneTypeValue = new System.Windows.Forms.Label();
            this.ComboBoxAttributeNumberOne = new System.Windows.Forms.ComboBox();
            this.LabelAttributeNumberOneType = new System.Windows.Forms.Label();
            this.GroupBoxPearsonCorrelation = new System.Windows.Forms.GroupBox();
            this.LabelPearsonCorrelationCoefficientValue = new System.Windows.Forms.Label();
            this.LabelPearsonCorrelationCoefficient = new System.Windows.Forms.Label();
            this.GroupBoxChiSquaredTest = new System.Windows.Forms.GroupBox();
            this.LabelTschuprowsCoefficientValue = new System.Windows.Forms.Label();
            this.LabelChiSquaredValue = new System.Windows.Forms.Label();
            this.LabelTschuprowsCoefficient = new System.Windows.Forms.Label();
            this.LabelChiSquared = new System.Windows.Forms.Label();
            this.ChartAttributes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.GroupBoxAttributes.SuspendLayout();
            this.GroupBoxAttributeNumberTwo.SuspendLayout();
            this.GroupBoxAttributeNumberOne.SuspendLayout();
            this.GroupBoxPearsonCorrelation.SuspendLayout();
            this.GroupBoxChiSquaredTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartAttributes)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBoxAttributes
            // 
            this.GroupBoxAttributes.Controls.Add(this.GroupBoxAttributeNumberTwo);
            this.GroupBoxAttributes.Controls.Add(this.GroupBoxAttributeNumberOne);
            this.GroupBoxAttributes.Location = new System.Drawing.Point(12, 12);
            this.GroupBoxAttributes.Name = "GroupBoxAttributes";
            this.GroupBoxAttributes.Size = new System.Drawing.Size(250, 249);
            this.GroupBoxAttributes.TabIndex = 1;
            this.GroupBoxAttributes.TabStop = false;
            this.GroupBoxAttributes.Text = "Atributos";
            // 
            // GroupBoxAttributeNumberTwo
            // 
            this.GroupBoxAttributeNumberTwo.Controls.Add(this.LabelAttributeNumberTwoTypeValue);
            this.GroupBoxAttributeNumberTwo.Controls.Add(this.LabelAttributeNumberTwo);
            this.GroupBoxAttributeNumberTwo.Controls.Add(this.ComboBoxAttributeNumberTwo);
            this.GroupBoxAttributeNumberTwo.Controls.Add(this.LabelAttributeNumberTwoType);
            this.GroupBoxAttributeNumberTwo.Location = new System.Drawing.Point(6, 144);
            this.GroupBoxAttributeNumberTwo.Name = "GroupBoxAttributeNumberTwo";
            this.GroupBoxAttributeNumberTwo.Size = new System.Drawing.Size(238, 99);
            this.GroupBoxAttributeNumberTwo.TabIndex = 6;
            this.GroupBoxAttributeNumberTwo.TabStop = false;
            this.GroupBoxAttributeNumberTwo.Text = "Atributo #2 (Eje Y)";
            // 
            // LabelAttributeNumberTwoTypeValue
            // 
            this.LabelAttributeNumberTwoTypeValue.AutoSize = true;
            this.LabelAttributeNumberTwoTypeValue.Location = new System.Drawing.Point(32, 25);
            this.LabelAttributeNumberTwoTypeValue.Name = "LabelAttributeNumberTwoTypeValue";
            this.LabelAttributeNumberTwoTypeValue.Size = new System.Drawing.Size(27, 13);
            this.LabelAttributeNumberTwoTypeValue.TabIndex = 5;
            this.LabelAttributeNumberTwoTypeValue.Text = "N/A";
            // 
            // LabelAttributeNumberTwo
            // 
            this.LabelAttributeNumberTwo.AutoSize = true;
            this.LabelAttributeNumberTwo.Location = new System.Drawing.Point(6, 48);
            this.LabelAttributeNumberTwo.Name = "LabelAttributeNumberTwo";
            this.LabelAttributeNumberTwo.Size = new System.Drawing.Size(46, 13);
            this.LabelAttributeNumberTwo.TabIndex = 7;
            this.LabelAttributeNumberTwo.Text = "Atributo:";
            // 
            // ComboBoxAttributeNumberTwo
            // 
            this.ComboBoxAttributeNumberTwo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxAttributeNumberTwo.FormattingEnabled = true;
            this.ComboBoxAttributeNumberTwo.Location = new System.Drawing.Point(6, 64);
            this.ComboBoxAttributeNumberTwo.Name = "ComboBoxAttributeNumberTwo";
            this.ComboBoxAttributeNumberTwo.Size = new System.Drawing.Size(226, 21);
            this.ComboBoxAttributeNumberTwo.TabIndex = 0;
            this.ComboBoxAttributeNumberTwo.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAttributeNumberTwo_SelectedIndexChanged);
            // 
            // LabelAttributeNumberTwoType
            // 
            this.LabelAttributeNumberTwoType.AutoSize = true;
            this.LabelAttributeNumberTwoType.Location = new System.Drawing.Point(6, 25);
            this.LabelAttributeNumberTwoType.Name = "LabelAttributeNumberTwoType";
            this.LabelAttributeNumberTwoType.Size = new System.Drawing.Size(31, 13);
            this.LabelAttributeNumberTwoType.TabIndex = 4;
            this.LabelAttributeNumberTwoType.Text = "Tipo:";
            // 
            // GroupBoxAttributeNumberOne
            // 
            this.GroupBoxAttributeNumberOne.Controls.Add(this.LabelAttributeNumberOne);
            this.GroupBoxAttributeNumberOne.Controls.Add(this.LabelAttributeNumberOneTypeValue);
            this.GroupBoxAttributeNumberOne.Controls.Add(this.ComboBoxAttributeNumberOne);
            this.GroupBoxAttributeNumberOne.Controls.Add(this.LabelAttributeNumberOneType);
            this.GroupBoxAttributeNumberOne.Location = new System.Drawing.Point(6, 28);
            this.GroupBoxAttributeNumberOne.Name = "GroupBoxAttributeNumberOne";
            this.GroupBoxAttributeNumberOne.Size = new System.Drawing.Size(238, 99);
            this.GroupBoxAttributeNumberOne.TabIndex = 5;
            this.GroupBoxAttributeNumberOne.TabStop = false;
            this.GroupBoxAttributeNumberOne.Text = "Atributo #1 (Eje X)";
            // 
            // LabelAttributeNumberOne
            // 
            this.LabelAttributeNumberOne.AutoSize = true;
            this.LabelAttributeNumberOne.Location = new System.Drawing.Point(6, 48);
            this.LabelAttributeNumberOne.Name = "LabelAttributeNumberOne";
            this.LabelAttributeNumberOne.Size = new System.Drawing.Size(46, 13);
            this.LabelAttributeNumberOne.TabIndex = 6;
            this.LabelAttributeNumberOne.Text = "Atributo:";
            // 
            // LabelAttributeNumberOneTypeValue
            // 
            this.LabelAttributeNumberOneTypeValue.AutoSize = true;
            this.LabelAttributeNumberOneTypeValue.Location = new System.Drawing.Point(32, 25);
            this.LabelAttributeNumberOneTypeValue.Name = "LabelAttributeNumberOneTypeValue";
            this.LabelAttributeNumberOneTypeValue.Size = new System.Drawing.Size(27, 13);
            this.LabelAttributeNumberOneTypeValue.TabIndex = 5;
            this.LabelAttributeNumberOneTypeValue.Text = "N/A";
            // 
            // ComboBoxAttributeNumberOne
            // 
            this.ComboBoxAttributeNumberOne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxAttributeNumberOne.FormattingEnabled = true;
            this.ComboBoxAttributeNumberOne.Location = new System.Drawing.Point(6, 64);
            this.ComboBoxAttributeNumberOne.Name = "ComboBoxAttributeNumberOne";
            this.ComboBoxAttributeNumberOne.Size = new System.Drawing.Size(226, 21);
            this.ComboBoxAttributeNumberOne.TabIndex = 0;
            this.ComboBoxAttributeNumberOne.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAttributeNumberOne_SelectedIndexChanged);
            // 
            // LabelAttributeNumberOneType
            // 
            this.LabelAttributeNumberOneType.AutoSize = true;
            this.LabelAttributeNumberOneType.Location = new System.Drawing.Point(6, 25);
            this.LabelAttributeNumberOneType.Name = "LabelAttributeNumberOneType";
            this.LabelAttributeNumberOneType.Size = new System.Drawing.Size(31, 13);
            this.LabelAttributeNumberOneType.TabIndex = 4;
            this.LabelAttributeNumberOneType.Text = "Tipo:";
            // 
            // GroupBoxPearsonCorrelation
            // 
            this.GroupBoxPearsonCorrelation.Controls.Add(this.LabelPearsonCorrelationCoefficientValue);
            this.GroupBoxPearsonCorrelation.Controls.Add(this.LabelPearsonCorrelationCoefficient);
            this.GroupBoxPearsonCorrelation.Location = new System.Drawing.Point(12, 267);
            this.GroupBoxPearsonCorrelation.Name = "GroupBoxPearsonCorrelation";
            this.GroupBoxPearsonCorrelation.Size = new System.Drawing.Size(250, 56);
            this.GroupBoxPearsonCorrelation.TabIndex = 2;
            this.GroupBoxPearsonCorrelation.TabStop = false;
            this.GroupBoxPearsonCorrelation.Text = "Correlación de Pearson";
            // 
            // LabelPearsonCorrelationCoefficientValue
            // 
            this.LabelPearsonCorrelationCoefficientValue.AutoSize = true;
            this.LabelPearsonCorrelationCoefficientValue.Location = new System.Drawing.Point(64, 25);
            this.LabelPearsonCorrelationCoefficientValue.Name = "LabelPearsonCorrelationCoefficientValue";
            this.LabelPearsonCorrelationCoefficientValue.Size = new System.Drawing.Size(27, 13);
            this.LabelPearsonCorrelationCoefficientValue.TabIndex = 5;
            this.LabelPearsonCorrelationCoefficientValue.Text = "N/A";
            // 
            // LabelPearsonCorrelationCoefficient
            // 
            this.LabelPearsonCorrelationCoefficient.AutoSize = true;
            this.LabelPearsonCorrelationCoefficient.Location = new System.Drawing.Point(6, 25);
            this.LabelPearsonCorrelationCoefficient.Name = "LabelPearsonCorrelationCoefficient";
            this.LabelPearsonCorrelationCoefficient.Size = new System.Drawing.Size(63, 13);
            this.LabelPearsonCorrelationCoefficient.TabIndex = 4;
            this.LabelPearsonCorrelationCoefficient.Text = "Coeficiente:";
            // 
            // GroupBoxChiSquaredTest
            // 
            this.GroupBoxChiSquaredTest.Controls.Add(this.LabelTschuprowsCoefficientValue);
            this.GroupBoxChiSquaredTest.Controls.Add(this.LabelChiSquaredValue);
            this.GroupBoxChiSquaredTest.Controls.Add(this.LabelTschuprowsCoefficient);
            this.GroupBoxChiSquaredTest.Controls.Add(this.LabelChiSquared);
            this.GroupBoxChiSquaredTest.Location = new System.Drawing.Point(12, 329);
            this.GroupBoxChiSquaredTest.Name = "GroupBoxChiSquaredTest";
            this.GroupBoxChiSquaredTest.Size = new System.Drawing.Size(250, 78);
            this.GroupBoxChiSquaredTest.TabIndex = 3;
            this.GroupBoxChiSquaredTest.TabStop = false;
            this.GroupBoxChiSquaredTest.Text = "Prueba Chi-Cuadrada";
            // 
            // LabelTschuprowsCoefficientValue
            // 
            this.LabelTschuprowsCoefficientValue.AutoSize = true;
            this.LabelTschuprowsCoefficientValue.Location = new System.Drawing.Point(135, 47);
            this.LabelTschuprowsCoefficientValue.Name = "LabelTschuprowsCoefficientValue";
            this.LabelTschuprowsCoefficientValue.Size = new System.Drawing.Size(27, 13);
            this.LabelTschuprowsCoefficientValue.TabIndex = 7;
            this.LabelTschuprowsCoefficientValue.Text = "N/A";
            // 
            // LabelChiSquaredValue
            // 
            this.LabelChiSquaredValue.AutoSize = true;
            this.LabelChiSquaredValue.Location = new System.Drawing.Point(75, 25);
            this.LabelChiSquaredValue.Name = "LabelChiSquaredValue";
            this.LabelChiSquaredValue.Size = new System.Drawing.Size(27, 13);
            this.LabelChiSquaredValue.TabIndex = 6;
            this.LabelChiSquaredValue.Text = "N/A";
            // 
            // LabelTschuprowsCoefficient
            // 
            this.LabelTschuprowsCoefficient.AutoSize = true;
            this.LabelTschuprowsCoefficient.Location = new System.Drawing.Point(6, 47);
            this.LabelTschuprowsCoefficient.Name = "LabelTschuprowsCoefficient";
            this.LabelTschuprowsCoefficient.Size = new System.Drawing.Size(134, 13);
            this.LabelTschuprowsCoefficient.TabIndex = 4;
            this.LabelTschuprowsCoefficient.Text = "Coeficiente de Tschuprow:";
            // 
            // LabelChiSquared
            // 
            this.LabelChiSquared.AutoSize = true;
            this.LabelChiSquared.Location = new System.Drawing.Point(6, 25);
            this.LabelChiSquared.Name = "LabelChiSquared";
            this.LabelChiSquared.Size = new System.Drawing.Size(74, 13);
            this.LabelChiSquared.TabIndex = 0;
            this.LabelChiSquared.Text = "Chi-Cuadrada:";
            // 
            // ChartAttributes
            // 
            chartArea2.Name = "ChartArea1";
            this.ChartAttributes.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ChartAttributes.Legends.Add(legend2);
            this.ChartAttributes.Location = new System.Drawing.Point(268, 12);
            this.ChartAttributes.Name = "ChartAttributes";
            this.ChartAttributes.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.ChartAttributes.Size = new System.Drawing.Size(624, 472);
            this.ChartAttributes.TabIndex = 4;
            this.ChartAttributes.Text = "Atributo";
            // 
            // BivariateAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 496);
            this.Controls.Add(this.ChartAttributes);
            this.Controls.Add(this.GroupBoxChiSquaredTest);
            this.Controls.Add(this.GroupBoxPearsonCorrelation);
            this.Controls.Add(this.GroupBoxAttributes);
            this.Name = "BivariateAnalysis";
            this.Text = "Análisis Bivariable";
            this.GroupBoxAttributes.ResumeLayout(false);
            this.GroupBoxAttributeNumberTwo.ResumeLayout(false);
            this.GroupBoxAttributeNumberTwo.PerformLayout();
            this.GroupBoxAttributeNumberOne.ResumeLayout(false);
            this.GroupBoxAttributeNumberOne.PerformLayout();
            this.GroupBoxPearsonCorrelation.ResumeLayout(false);
            this.GroupBoxPearsonCorrelation.PerformLayout();
            this.GroupBoxChiSquaredTest.ResumeLayout(false);
            this.GroupBoxChiSquaredTest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartAttributes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxAttributes;
        private System.Windows.Forms.GroupBox GroupBoxAttributeNumberTwo;
        private System.Windows.Forms.Label LabelAttributeNumberTwoTypeValue;
        private System.Windows.Forms.Label LabelAttributeNumberTwoType;
        private System.Windows.Forms.ComboBox ComboBoxAttributeNumberTwo;
        private System.Windows.Forms.GroupBox GroupBoxAttributeNumberOne;
        private System.Windows.Forms.Label LabelAttributeNumberOneTypeValue;
        private System.Windows.Forms.Label LabelAttributeNumberOneType;
        private System.Windows.Forms.ComboBox ComboBoxAttributeNumberOne;
        private System.Windows.Forms.Label LabelAttributeNumberTwo;
        private System.Windows.Forms.Label LabelAttributeNumberOne;
        private System.Windows.Forms.GroupBox GroupBoxPearsonCorrelation;
        private System.Windows.Forms.Label LabelPearsonCorrelationCoefficientValue;
        private System.Windows.Forms.Label LabelPearsonCorrelationCoefficient;
        private System.Windows.Forms.GroupBox GroupBoxChiSquaredTest;
        private System.Windows.Forms.Label LabelTschuprowsCoefficient;
        private System.Windows.Forms.Label LabelChiSquared;
        private System.Windows.Forms.Label LabelTschuprowsCoefficientValue;
        private System.Windows.Forms.Label LabelChiSquaredValue;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartAttributes;
    }
}