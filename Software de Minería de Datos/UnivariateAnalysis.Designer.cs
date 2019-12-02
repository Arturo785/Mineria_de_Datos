namespace Software_de_Minería_de_Datos
{
    partial class UnivariateAnalysis
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.GroupBoxAttributes = new System.Windows.Forms.GroupBox();
            this.ListBoxAttributes = new System.Windows.Forms.ListBox();
            this.ChartAttribute = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.GroupBoxStatistics = new System.Windows.Forms.GroupBox();
            this.LabelStandardDeviationValue = new System.Windows.Forms.Label();
            this.LabelModeValue = new System.Windows.Forms.Label();
            this.LabelMedianValue = new System.Windows.Forms.Label();
            this.LabelMeanValue = new System.Windows.Forms.Label();
            this.LabelStandardDeviation = new System.Windows.Forms.Label();
            this.LabelMode = new System.Windows.Forms.Label();
            this.LabelMedian = new System.Windows.Forms.Label();
            this.LabelMean = new System.Windows.Forms.Label();
            this.GroupBoxAttributes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartAttribute)).BeginInit();
            this.GroupBoxStatistics.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBoxAttributes
            // 
            this.GroupBoxAttributes.Controls.Add(this.ListBoxAttributes);
            this.GroupBoxAttributes.Location = new System.Drawing.Point(12, 12);
            this.GroupBoxAttributes.Name = "GroupBoxAttributes";
            this.GroupBoxAttributes.Size = new System.Drawing.Size(215, 371);
            this.GroupBoxAttributes.TabIndex = 0;
            this.GroupBoxAttributes.TabStop = false;
            this.GroupBoxAttributes.Text = "Atributos";
            // 
            // ListBoxAttributes
            // 
            this.ListBoxAttributes.FormattingEnabled = true;
            this.ListBoxAttributes.Location = new System.Drawing.Point(6, 19);
            this.ListBoxAttributes.Name = "ListBoxAttributes";
            this.ListBoxAttributes.Size = new System.Drawing.Size(203, 342);
            this.ListBoxAttributes.TabIndex = 1;
            this.ListBoxAttributes.SelectedIndexChanged += new System.EventHandler(this.ListBoxAttributes_SelectedIndexChanged);
            // 
            // ChartAttribute
            // 
            chartArea1.Name = "ChartArea1";
            this.ChartAttribute.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChartAttribute.Legends.Add(legend1);
            this.ChartAttribute.Location = new System.Drawing.Point(233, 12);
            this.ChartAttribute.Name = "ChartAttribute";
            this.ChartAttribute.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.ChartAttribute.Size = new System.Drawing.Size(659, 472);
            this.ChartAttribute.TabIndex = 1;
            this.ChartAttribute.Text = "Atributo";
            // 
            // GroupBoxStatistics
            // 
            this.GroupBoxStatistics.Controls.Add(this.LabelStandardDeviationValue);
            this.GroupBoxStatistics.Controls.Add(this.LabelModeValue);
            this.GroupBoxStatistics.Controls.Add(this.LabelMedianValue);
            this.GroupBoxStatistics.Controls.Add(this.LabelMeanValue);
            this.GroupBoxStatistics.Controls.Add(this.LabelStandardDeviation);
            this.GroupBoxStatistics.Controls.Add(this.LabelMode);
            this.GroupBoxStatistics.Controls.Add(this.LabelMedian);
            this.GroupBoxStatistics.Controls.Add(this.LabelMean);
            this.GroupBoxStatistics.Location = new System.Drawing.Point(12, 382);
            this.GroupBoxStatistics.Name = "GroupBoxStatistics";
            this.GroupBoxStatistics.Size = new System.Drawing.Size(215, 102);
            this.GroupBoxStatistics.TabIndex = 2;
            this.GroupBoxStatistics.TabStop = false;
            this.GroupBoxStatistics.Text = "Estadística";
            // 
            // LabelStandardDeviationValue
            // 
            this.LabelStandardDeviationValue.AutoSize = true;
            this.LabelStandardDeviationValue.Location = new System.Drawing.Point(109, 82);
            this.LabelStandardDeviationValue.Name = "LabelStandardDeviationValue";
            this.LabelStandardDeviationValue.Size = new System.Drawing.Size(27, 13);
            this.LabelStandardDeviationValue.TabIndex = 7;
            this.LabelStandardDeviationValue.Text = "N/A";
            // 
            // LabelModeValue
            // 
            this.LabelModeValue.AutoSize = true;
            this.LabelModeValue.Location = new System.Drawing.Point(38, 60);
            this.LabelModeValue.Name = "LabelModeValue";
            this.LabelModeValue.Size = new System.Drawing.Size(27, 13);
            this.LabelModeValue.TabIndex = 6;
            this.LabelModeValue.Text = "N/A";
            // 
            // LabelMedianValue
            // 
            this.LabelMedianValue.AutoSize = true;
            this.LabelMedianValue.Location = new System.Drawing.Point(52, 38);
            this.LabelMedianValue.Name = "LabelMedianValue";
            this.LabelMedianValue.Size = new System.Drawing.Size(27, 13);
            this.LabelMedianValue.TabIndex = 5;
            this.LabelMedianValue.Text = "N/A";
            // 
            // LabelMeanValue
            // 
            this.LabelMeanValue.AutoSize = true;
            this.LabelMeanValue.Location = new System.Drawing.Point(40, 16);
            this.LabelMeanValue.Name = "LabelMeanValue";
            this.LabelMeanValue.Size = new System.Drawing.Size(27, 13);
            this.LabelMeanValue.TabIndex = 4;
            this.LabelMeanValue.Text = "N/A";
            // 
            // LabelStandardDeviation
            // 
            this.LabelStandardDeviation.AutoSize = true;
            this.LabelStandardDeviation.Location = new System.Drawing.Point(6, 82);
            this.LabelStandardDeviation.Name = "LabelStandardDeviation";
            this.LabelStandardDeviation.Size = new System.Drawing.Size(108, 13);
            this.LabelStandardDeviation.TabIndex = 3;
            this.LabelStandardDeviation.Text = "Desviación Estándar:";
            // 
            // LabelMode
            // 
            this.LabelMode.AutoSize = true;
            this.LabelMode.Location = new System.Drawing.Point(6, 60);
            this.LabelMode.Name = "LabelMode";
            this.LabelMode.Size = new System.Drawing.Size(37, 13);
            this.LabelMode.TabIndex = 2;
            this.LabelMode.Text = "Moda:";
            // 
            // LabelMedian
            // 
            this.LabelMedian.AutoSize = true;
            this.LabelMedian.Location = new System.Drawing.Point(6, 38);
            this.LabelMedian.Name = "LabelMedian";
            this.LabelMedian.Size = new System.Drawing.Size(51, 13);
            this.LabelMedian.TabIndex = 1;
            this.LabelMedian.Text = "Mediana:";
            // 
            // LabelMean
            // 
            this.LabelMean.AutoSize = true;
            this.LabelMean.Location = new System.Drawing.Point(6, 16);
            this.LabelMean.Name = "LabelMean";
            this.LabelMean.Size = new System.Drawing.Size(39, 13);
            this.LabelMean.TabIndex = 0;
            this.LabelMean.Text = "Media:";
            // 
            // UnivariateAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 496);
            this.Controls.Add(this.GroupBoxStatistics);
            this.Controls.Add(this.ChartAttribute);
            this.Controls.Add(this.GroupBoxAttributes);
            this.Name = "UnivariateAnalysis";
            this.Text = "Análisis Univariable";
            this.GroupBoxAttributes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChartAttribute)).EndInit();
            this.GroupBoxStatistics.ResumeLayout(false);
            this.GroupBoxStatistics.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxAttributes;
        private System.Windows.Forms.ListBox ListBoxAttributes;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartAttribute;
        private System.Windows.Forms.GroupBox GroupBoxStatistics;
        private System.Windows.Forms.Label LabelStandardDeviationValue;
        private System.Windows.Forms.Label LabelModeValue;
        private System.Windows.Forms.Label LabelMedianValue;
        private System.Windows.Forms.Label LabelMeanValue;
        private System.Windows.Forms.Label LabelStandardDeviation;
        private System.Windows.Forms.Label LabelMode;
        private System.Windows.Forms.Label LabelMedian;
        private System.Windows.Forms.Label LabelMean;
    }
}