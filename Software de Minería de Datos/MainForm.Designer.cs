namespace Software_de_Minería_de_Datos
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabControlStages = new System.Windows.Forms.TabControl();
            this.TabPageDataEntry = new System.Windows.Forms.TabPage();
            this.TabPageStatisticalAnalysis = new System.Windows.Forms.TabPage();
            this.TabPageDataCleaning = new System.Windows.Forms.TabPage();
            this.TabPageMachineLearningAlgorithms = new System.Windows.Forms.TabPage();
            this.TabControlStages.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControlStages
            // 
            this.TabControlStages.Controls.Add(this.TabPageDataEntry);
            this.TabControlStages.Controls.Add(this.TabPageStatisticalAnalysis);
            this.TabControlStages.Controls.Add(this.TabPageDataCleaning);
            this.TabControlStages.Controls.Add(this.TabPageMachineLearningAlgorithms);
            this.TabControlStages.Location = new System.Drawing.Point(13, 13);
            this.TabControlStages.Name = "TabControlStages";
            this.TabControlStages.SelectedIndex = 0;
            this.TabControlStages.Size = new System.Drawing.Size(959, 586);
            this.TabControlStages.TabIndex = 0;
            this.TabControlStages.SelectedIndexChanged += new System.EventHandler(this.TabControlStages_SelectedIndexChanged);
            // 
            // TabPageDataEntry
            // 
            this.TabPageDataEntry.Location = new System.Drawing.Point(4, 22);
            this.TabPageDataEntry.Name = "TabPageDataEntry";
            this.TabPageDataEntry.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageDataEntry.Size = new System.Drawing.Size(951, 560);
            this.TabPageDataEntry.TabIndex = 0;
            this.TabPageDataEntry.Text = "Entrada de Datos";
            this.TabPageDataEntry.UseVisualStyleBackColor = true;
            // 
            // TabPageStatisticalAnalysis
            // 
            this.TabPageStatisticalAnalysis.Location = new System.Drawing.Point(4, 22);
            this.TabPageStatisticalAnalysis.Name = "TabPageStatisticalAnalysis";
            this.TabPageStatisticalAnalysis.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageStatisticalAnalysis.Size = new System.Drawing.Size(951, 560);
            this.TabPageStatisticalAnalysis.TabIndex = 1;
            this.TabPageStatisticalAnalysis.Text = "Análisis Estadístico";
            this.TabPageStatisticalAnalysis.UseVisualStyleBackColor = true;
            // 
            // TabPageDataCleaning
            // 
            this.TabPageDataCleaning.Location = new System.Drawing.Point(4, 22);
            this.TabPageDataCleaning.Name = "TabPageDataCleaning";
            this.TabPageDataCleaning.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageDataCleaning.Size = new System.Drawing.Size(951, 560);
            this.TabPageDataCleaning.TabIndex = 2;
            this.TabPageDataCleaning.Text = "Limpieza de Datos";
            this.TabPageDataCleaning.UseVisualStyleBackColor = true;
            // 
            // TabPageMachineLearningAlgorithms
            // 
            this.TabPageMachineLearningAlgorithms.Location = new System.Drawing.Point(4, 22);
            this.TabPageMachineLearningAlgorithms.Name = "TabPageMachineLearningAlgorithms";
            this.TabPageMachineLearningAlgorithms.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageMachineLearningAlgorithms.Size = new System.Drawing.Size(951, 560);
            this.TabPageMachineLearningAlgorithms.TabIndex = 3;
            this.TabPageMachineLearningAlgorithms.Text = "Algoritmos de Aprendizaje Automático";
            this.TabPageMachineLearningAlgorithms.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.TabControlStages);
            this.Name = "MainForm";
            this.Text = "Software de Minería de Datos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.TabControlStages.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControlStages;
        private System.Windows.Forms.TabPage TabPageDataEntry;
        private System.Windows.Forms.TabPage TabPageStatisticalAnalysis;
        private System.Windows.Forms.TabPage TabPageDataCleaning;
        private System.Windows.Forms.TabPage TabPageMachineLearningAlgorithms;
    }
}

