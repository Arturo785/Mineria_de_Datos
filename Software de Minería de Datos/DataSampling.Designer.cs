namespace Software_de_Minería_de_Datos
{
    partial class DataSampling
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
            this.GroupBoxSamplingType = new System.Windows.Forms.GroupBox();
            this.RadioButtonWithoutReplacement = new System.Windows.Forms.RadioButton();
            this.RadioButtonWithReplacement = new System.Windows.Forms.RadioButton();
            this.ButtonGenerateSample = new System.Windows.Forms.Button();
            this.ButtonSaveSample = new System.Windows.Forms.Button();
            this.DataGridViewSample = new System.Windows.Forms.DataGridView();
            this.NumericUpDownNumberOfInstances = new System.Windows.Forms.NumericUpDown();
            this.LabelNumberOfInstances = new System.Windows.Forms.Label();
            this.SaveFileDialogSample = new System.Windows.Forms.SaveFileDialog();
            this.GroupBoxSamplingType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewSample)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownNumberOfInstances)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBoxSamplingType
            // 
            this.GroupBoxSamplingType.Controls.Add(this.RadioButtonWithoutReplacement);
            this.GroupBoxSamplingType.Controls.Add(this.RadioButtonWithReplacement);
            this.GroupBoxSamplingType.Location = new System.Drawing.Point(12, 12);
            this.GroupBoxSamplingType.Name = "GroupBoxSamplingType";
            this.GroupBoxSamplingType.Size = new System.Drawing.Size(109, 69);
            this.GroupBoxSamplingType.TabIndex = 0;
            this.GroupBoxSamplingType.TabStop = false;
            this.GroupBoxSamplingType.Text = "Tipo de Muestreo";
            // 
            // RadioButtonWithoutReplacement
            // 
            this.RadioButtonWithoutReplacement.AutoSize = true;
            this.RadioButtonWithoutReplacement.Checked = true;
            this.RadioButtonWithoutReplacement.Location = new System.Drawing.Point(6, 18);
            this.RadioButtonWithoutReplacement.Name = "RadioButtonWithoutReplacement";
            this.RadioButtonWithoutReplacement.Size = new System.Drawing.Size(96, 17);
            this.RadioButtonWithoutReplacement.TabIndex = 1;
            this.RadioButtonWithoutReplacement.TabStop = true;
            this.RadioButtonWithoutReplacement.Text = "Sin Reemplazo";
            this.RadioButtonWithoutReplacement.UseVisualStyleBackColor = true;
            // 
            // RadioButtonWithReplacement
            // 
            this.RadioButtonWithReplacement.AutoSize = true;
            this.RadioButtonWithReplacement.Location = new System.Drawing.Point(6, 41);
            this.RadioButtonWithReplacement.Name = "RadioButtonWithReplacement";
            this.RadioButtonWithReplacement.Size = new System.Drawing.Size(100, 17);
            this.RadioButtonWithReplacement.TabIndex = 0;
            this.RadioButtonWithReplacement.Text = "Con Reemplazo";
            this.RadioButtonWithReplacement.UseVisualStyleBackColor = true;
            // 
            // ButtonGenerateSample
            // 
            this.ButtonGenerateSample.Location = new System.Drawing.Point(127, 53);
            this.ButtonGenerateSample.Name = "ButtonGenerateSample";
            this.ButtonGenerateSample.Size = new System.Drawing.Size(110, 28);
            this.ButtonGenerateSample.TabIndex = 1;
            this.ButtonGenerateSample.Text = "Generar Muestra";
            this.ButtonGenerateSample.UseVisualStyleBackColor = true;
            this.ButtonGenerateSample.Click += new System.EventHandler(this.ButtonGenerateSample_Click);
            // 
            // ButtonSaveSample
            // 
            this.ButtonSaveSample.Location = new System.Drawing.Point(243, 53);
            this.ButtonSaveSample.Name = "ButtonSaveSample";
            this.ButtonSaveSample.Size = new System.Drawing.Size(110, 28);
            this.ButtonSaveSample.TabIndex = 2;
            this.ButtonSaveSample.Text = "Guardar Muestra";
            this.ButtonSaveSample.UseVisualStyleBackColor = true;
            this.ButtonSaveSample.Click += new System.EventHandler(this.ButtonSaveSample_Click);
            // 
            // DataGridViewSample
            // 
            this.DataGridViewSample.AllowUserToAddRows = false;
            this.DataGridViewSample.AllowUserToDeleteRows = false;
            this.DataGridViewSample.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewSample.Location = new System.Drawing.Point(12, 87);
            this.DataGridViewSample.Name = "DataGridViewSample";
            this.DataGridViewSample.ReadOnly = true;
            this.DataGridViewSample.RowHeadersVisible = false;
            this.DataGridViewSample.Size = new System.Drawing.Size(880, 397);
            this.DataGridViewSample.TabIndex = 3;
            this.DataGridViewSample.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DataGridViewSample_ColumnAdded);
            // 
            // NumericUpDownNumberOfInstances
            // 
            this.NumericUpDownNumberOfInstances.Location = new System.Drawing.Point(127, 27);
            this.NumericUpDownNumberOfInstances.Name = "NumericUpDownNumberOfInstances";
            this.NumericUpDownNumberOfInstances.Size = new System.Drawing.Size(226, 20);
            this.NumericUpDownNumberOfInstances.TabIndex = 4;
            // 
            // LabelNumberOfInstances
            // 
            this.LabelNumberOfInstances.AutoSize = true;
            this.LabelNumberOfInstances.Location = new System.Drawing.Point(127, 12);
            this.LabelNumberOfInstances.Name = "LabelNumberOfInstances";
            this.LabelNumberOfInstances.Size = new System.Drawing.Size(113, 13);
            this.LabelNumberOfInstances.TabIndex = 5;
            this.LabelNumberOfInstances.Text = "Número de Instancias:";
            // 
            // DataSampling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 496);
            this.Controls.Add(this.LabelNumberOfInstances);
            this.Controls.Add(this.NumericUpDownNumberOfInstances);
            this.Controls.Add(this.DataGridViewSample);
            this.Controls.Add(this.ButtonSaveSample);
            this.Controls.Add(this.ButtonGenerateSample);
            this.Controls.Add(this.GroupBoxSamplingType);
            this.Name = "DataSampling";
            this.Text = "Muestreo de Datos";
            this.GroupBoxSamplingType.ResumeLayout(false);
            this.GroupBoxSamplingType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewSample)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownNumberOfInstances)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxSamplingType;
        private System.Windows.Forms.RadioButton RadioButtonWithoutReplacement;
        private System.Windows.Forms.RadioButton RadioButtonWithReplacement;
        private System.Windows.Forms.Button ButtonGenerateSample;
        private System.Windows.Forms.Button ButtonSaveSample;
        private System.Windows.Forms.DataGridView DataGridViewSample;
        private System.Windows.Forms.NumericUpDown NumericUpDownNumberOfInstances;
        private System.Windows.Forms.Label LabelNumberOfInstances;
        private System.Windows.Forms.SaveFileDialog SaveFileDialogSample;
    }
}