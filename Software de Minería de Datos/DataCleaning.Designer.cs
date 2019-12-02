namespace Software_de_Minería_de_Datos
{
    partial class DataCleaning
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
            this.TabControlDataCleaning = new System.Windows.Forms.TabControl();
            this.TabPageAttributeCleaning = new System.Windows.Forms.TabPage();
            this.TabPageDataSampling = new System.Windows.Forms.TabPage();
            this.TabControlDataCleaning.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControlDataCleaning
            // 
            this.TabControlDataCleaning.Controls.Add(this.TabPageAttributeCleaning);
            this.TabControlDataCleaning.Controls.Add(this.TabPageDataSampling);
            this.TabControlDataCleaning.Location = new System.Drawing.Point(12, 12);
            this.TabControlDataCleaning.Name = "TabControlDataCleaning";
            this.TabControlDataCleaning.SelectedIndex = 0;
            this.TabControlDataCleaning.Size = new System.Drawing.Size(920, 527);
            this.TabControlDataCleaning.TabIndex = 1;
            // 
            // TabPageAttributeCleaning
            // 
            this.TabPageAttributeCleaning.Location = new System.Drawing.Point(4, 22);
            this.TabPageAttributeCleaning.Name = "TabPageAttributeCleaning";
            this.TabPageAttributeCleaning.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageAttributeCleaning.Size = new System.Drawing.Size(912, 501);
            this.TabPageAttributeCleaning.TabIndex = 0;
            this.TabPageAttributeCleaning.Text = "Limpieza de Atributos";
            this.TabPageAttributeCleaning.UseVisualStyleBackColor = true;
            // 
            // TabPageDataSampling
            // 
            this.TabPageDataSampling.Location = new System.Drawing.Point(4, 22);
            this.TabPageDataSampling.Name = "TabPageDataSampling";
            this.TabPageDataSampling.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageDataSampling.Size = new System.Drawing.Size(912, 501);
            this.TabPageDataSampling.TabIndex = 1;
            this.TabPageDataSampling.Text = "Muestreo de Datos";
            this.TabPageDataSampling.UseVisualStyleBackColor = true;
            // 
            // DataCleaning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 551);
            this.Controls.Add(this.TabControlDataCleaning);
            this.Name = "DataCleaning";
            this.Text = "Limpieza de Datos";
            this.TabControlDataCleaning.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControlDataCleaning;
        private System.Windows.Forms.TabPage TabPageAttributeCleaning;
        private System.Windows.Forms.TabPage TabPageDataSampling;
    }
}