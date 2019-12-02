namespace Software_de_Minería_de_Datos
{
    partial class StatisticalAnalysis
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
            this.TabControlStatisticalAnalysis = new System.Windows.Forms.TabControl();
            this.TabPageUnivariableAnalysis = new System.Windows.Forms.TabPage();
            this.TabPageBivariateAnalysis = new System.Windows.Forms.TabPage();
            this.TabControlStatisticalAnalysis.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControlStatisticalAnalysis
            // 
            this.TabControlStatisticalAnalysis.Controls.Add(this.TabPageUnivariableAnalysis);
            this.TabControlStatisticalAnalysis.Controls.Add(this.TabPageBivariateAnalysis);
            this.TabControlStatisticalAnalysis.Location = new System.Drawing.Point(12, 12);
            this.TabControlStatisticalAnalysis.Name = "TabControlStatisticalAnalysis";
            this.TabControlStatisticalAnalysis.SelectedIndex = 0;
            this.TabControlStatisticalAnalysis.Size = new System.Drawing.Size(920, 527);
            this.TabControlStatisticalAnalysis.TabIndex = 0;
            this.TabControlStatisticalAnalysis.SelectedIndexChanged += new System.EventHandler(this.TabControlStatisticalAnalysis_SelectedIndexChanged);
            // 
            // TabPageUnivariableAnalysis
            // 
            this.TabPageUnivariableAnalysis.Location = new System.Drawing.Point(4, 22);
            this.TabPageUnivariableAnalysis.Name = "TabPageUnivariableAnalysis";
            this.TabPageUnivariableAnalysis.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageUnivariableAnalysis.Size = new System.Drawing.Size(912, 501);
            this.TabPageUnivariableAnalysis.TabIndex = 0;
            this.TabPageUnivariableAnalysis.Text = "Análisis Univariable";
            this.TabPageUnivariableAnalysis.UseVisualStyleBackColor = true;
            // 
            // TabPageBivariateAnalysis
            // 
            this.TabPageBivariateAnalysis.Location = new System.Drawing.Point(4, 22);
            this.TabPageBivariateAnalysis.Name = "TabPageBivariateAnalysis";
            this.TabPageBivariateAnalysis.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageBivariateAnalysis.Size = new System.Drawing.Size(912, 501);
            this.TabPageBivariateAnalysis.TabIndex = 1;
            this.TabPageBivariateAnalysis.Text = "Análisis Bivariable";
            this.TabPageBivariateAnalysis.UseVisualStyleBackColor = true;
            // 
            // StatisticalAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 551);
            this.Controls.Add(this.TabControlStatisticalAnalysis);
            this.Name = "StatisticalAnalysis";
            this.Text = "Análisis Estadístico";
            this.TabControlStatisticalAnalysis.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControlStatisticalAnalysis;
        private System.Windows.Forms.TabPage TabPageUnivariableAnalysis;
        private System.Windows.Forms.TabPage TabPageBivariateAnalysis;
    }
}