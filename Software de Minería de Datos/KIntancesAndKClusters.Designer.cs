namespace Software_de_Minería_de_Datos
{
    partial class KInstancesAndClusters
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
            this.DataGridViewKInstance = new System.Windows.Forms.DataGridView();
            this.DataGridViewKCluster = new System.Windows.Forms.DataGridView();
            this.ButtonNext = new System.Windows.Forms.Button();
            this.ButtonPrevious = new System.Windows.Forms.Button();
            this.LabelInstance = new System.Windows.Forms.Label();
            this.LabelCluster = new System.Windows.Forms.Label();
            this.LabelKValue = new System.Windows.Forms.Label();
            this.LabelK = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewKInstance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewKCluster)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewKInstance
            // 
            this.DataGridViewKInstance.AllowUserToAddRows = false;
            this.DataGridViewKInstance.AllowUserToDeleteRows = false;
            this.DataGridViewKInstance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewKInstance.Location = new System.Drawing.Point(12, 32);
            this.DataGridViewKInstance.Name = "DataGridViewKInstance";
            this.DataGridViewKInstance.ReadOnly = true;
            this.DataGridViewKInstance.RowHeadersVisible = false;
            this.DataGridViewKInstance.Size = new System.Drawing.Size(665, 65);
            this.DataGridViewKInstance.TabIndex = 0;
            // 
            // DataGridViewKCluster
            // 
            this.DataGridViewKCluster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewKCluster.Location = new System.Drawing.Point(12, 123);
            this.DataGridViewKCluster.Name = "DataGridViewKCluster";
            this.DataGridViewKCluster.RowHeadersVisible = false;
            this.DataGridViewKCluster.Size = new System.Drawing.Size(665, 374);
            this.DataGridViewKCluster.TabIndex = 1;
            // 
            // ButtonNext
            // 
            this.ButtonNext.Location = new System.Drawing.Point(527, 503);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(150, 23);
            this.ButtonNext.TabIndex = 2;
            this.ButtonNext.Text = "Siguiente";
            this.ButtonNext.UseVisualStyleBackColor = true;
            this.ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // ButtonPrevious
            // 
            this.ButtonPrevious.Location = new System.Drawing.Point(371, 503);
            this.ButtonPrevious.Name = "ButtonPrevious";
            this.ButtonPrevious.Size = new System.Drawing.Size(150, 23);
            this.ButtonPrevious.TabIndex = 3;
            this.ButtonPrevious.Text = "Anterior";
            this.ButtonPrevious.UseVisualStyleBackColor = true;
            this.ButtonPrevious.Click += new System.EventHandler(this.ButtonPrevious_Click);
            // 
            // LabelInstance
            // 
            this.LabelInstance.AutoSize = true;
            this.LabelInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInstance.Location = new System.Drawing.Point(12, 9);
            this.LabelInstance.Name = "LabelInstance";
            this.LabelInstance.Size = new System.Drawing.Size(74, 20);
            this.LabelInstance.TabIndex = 4;
            this.LabelInstance.Text = "Instancia";
            // 
            // LabelCluster
            // 
            this.LabelCluster.AutoSize = true;
            this.LabelCluster.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCluster.Location = new System.Drawing.Point(12, 100);
            this.LabelCluster.Name = "LabelCluster";
            this.LabelCluster.Size = new System.Drawing.Size(59, 20);
            this.LabelCluster.TabIndex = 5;
            this.LabelCluster.Text = "Clúster";
            // 
            // LabelKValue
            // 
            this.LabelKValue.AutoSize = true;
            this.LabelKValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelKValue.Location = new System.Drawing.Point(642, 9);
            this.LabelKValue.Name = "LabelKValue";
            this.LabelKValue.Size = new System.Drawing.Size(35, 20);
            this.LabelKValue.TabIndex = 8;
            this.LabelKValue.Text = "N/A";
            // 
            // LabelK
            // 
            this.LabelK.AutoSize = true;
            this.LabelK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelK.Location = new System.Drawing.Point(615, 9);
            this.LabelK.Name = "LabelK";
            this.LabelK.Size = new System.Drawing.Size(32, 20);
            this.LabelK.TabIndex = 7;
            this.LabelK.Text = "K =";
            // 
            // KInstancesAndClustersInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 538);
            this.Controls.Add(this.LabelKValue);
            this.Controls.Add(this.LabelK);
            this.Controls.Add(this.LabelCluster);
            this.Controls.Add(this.LabelInstance);
            this.Controls.Add(this.ButtonPrevious);
            this.Controls.Add(this.ButtonNext);
            this.Controls.Add(this.DataGridViewKCluster);
            this.Controls.Add(this.DataGridViewKInstance);
            this.Name = "KInstancesAndClustersInformation";
            this.Text = "Información de K-Instancias y K-Clústeres";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewKInstance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewKCluster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewKInstance;
        private System.Windows.Forms.DataGridView DataGridViewKCluster;
        private System.Windows.Forms.Button ButtonNext;
        private System.Windows.Forms.Button ButtonPrevious;
        private System.Windows.Forms.Label LabelInstance;
        private System.Windows.Forms.Label LabelCluster;
        private System.Windows.Forms.Label LabelKValue;
        private System.Windows.Forms.Label LabelK;
    }
}