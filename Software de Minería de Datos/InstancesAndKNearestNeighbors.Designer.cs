namespace Software_de_Minería_de_Datos
{
    partial class InstancesAndKNearestNeighbors
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
            this.LabelNearestNeighbors = new System.Windows.Forms.Label();
            this.LabelOriginalInstance = new System.Windows.Forms.Label();
            this.ButtonPrevious = new System.Windows.Forms.Button();
            this.ButtonNext = new System.Windows.Forms.Button();
            this.DataGridViewNearestNeighbors = new System.Windows.Forms.DataGridView();
            this.DataGridViewOriginalInstance = new System.Windows.Forms.DataGridView();
            this.LabelClassifiedInstance = new System.Windows.Forms.Label();
            this.DataGridViewClassifiedInstance = new System.Windows.Forms.DataGridView();
            this.GroupBoxEvaluation = new System.Windows.Forms.GroupBox();
            this.GroupBoxRegression = new System.Windows.Forms.GroupBox();
            this.LabelMeanSquaredErrorValue = new System.Windows.Forms.Label();
            this.LabelMeanSquaredError = new System.Windows.Forms.Label();
            this.GroupBoxClassification = new System.Windows.Forms.GroupBox();
            this.LabelAccuracyValue = new System.Windows.Forms.Label();
            this.LabelAccuracy = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewNearestNeighbors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewOriginalInstance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewClassifiedInstance)).BeginInit();
            this.GroupBoxEvaluation.SuspendLayout();
            this.GroupBoxRegression.SuspendLayout();
            this.GroupBoxClassification.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelNearestNeighbors
            // 
            this.LabelNearestNeighbors.AutoSize = true;
            this.LabelNearestNeighbors.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNearestNeighbors.Location = new System.Drawing.Point(12, 270);
            this.LabelNearestNeighbors.Name = "LabelNearestNeighbors";
            this.LabelNearestNeighbors.Size = new System.Drawing.Size(141, 20);
            this.LabelNearestNeighbors.TabIndex = 14;
            this.LabelNearestNeighbors.Text = "Nearest Neighbors";
            // 
            // LabelOriginalInstance
            // 
            this.LabelOriginalInstance.AutoSize = true;
            this.LabelOriginalInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelOriginalInstance.Location = new System.Drawing.Point(12, 88);
            this.LabelOriginalInstance.Name = "LabelOriginalInstance";
            this.LabelOriginalInstance.Size = new System.Drawing.Size(131, 20);
            this.LabelOriginalInstance.TabIndex = 13;
            this.LabelOriginalInstance.Text = "Instancia Original";
            // 
            // ButtonPrevious
            // 
            this.ButtonPrevious.Location = new System.Drawing.Point(371, 505);
            this.ButtonPrevious.Name = "ButtonPrevious";
            this.ButtonPrevious.Size = new System.Drawing.Size(150, 23);
            this.ButtonPrevious.TabIndex = 12;
            this.ButtonPrevious.Text = "Anterior";
            this.ButtonPrevious.UseVisualStyleBackColor = true;
            this.ButtonPrevious.Click += new System.EventHandler(this.ButtonPrevious_Click);
            // 
            // ButtonNext
            // 
            this.ButtonNext.Location = new System.Drawing.Point(527, 505);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(150, 23);
            this.ButtonNext.TabIndex = 11;
            this.ButtonNext.Text = "Siguiente";
            this.ButtonNext.UseVisualStyleBackColor = true;
            this.ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // DataGridViewNearestNeighbors
            // 
            this.DataGridViewNearestNeighbors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewNearestNeighbors.Location = new System.Drawing.Point(12, 293);
            this.DataGridViewNearestNeighbors.Name = "DataGridViewNearestNeighbors";
            this.DataGridViewNearestNeighbors.RowHeadersVisible = false;
            this.DataGridViewNearestNeighbors.Size = new System.Drawing.Size(665, 206);
            this.DataGridViewNearestNeighbors.TabIndex = 10;
            // 
            // DataGridViewOriginalInstance
            // 
            this.DataGridViewOriginalInstance.AllowUserToAddRows = false;
            this.DataGridViewOriginalInstance.AllowUserToDeleteRows = false;
            this.DataGridViewOriginalInstance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewOriginalInstance.Location = new System.Drawing.Point(12, 111);
            this.DataGridViewOriginalInstance.Name = "DataGridViewOriginalInstance";
            this.DataGridViewOriginalInstance.ReadOnly = true;
            this.DataGridViewOriginalInstance.RowHeadersVisible = false;
            this.DataGridViewOriginalInstance.Size = new System.Drawing.Size(665, 65);
            this.DataGridViewOriginalInstance.TabIndex = 9;
            // 
            // LabelClassifiedInstance
            // 
            this.LabelClassifiedInstance.AutoSize = true;
            this.LabelClassifiedInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelClassifiedInstance.Location = new System.Drawing.Point(12, 179);
            this.LabelClassifiedInstance.Name = "LabelClassifiedInstance";
            this.LabelClassifiedInstance.Size = new System.Drawing.Size(155, 20);
            this.LabelClassifiedInstance.TabIndex = 18;
            this.LabelClassifiedInstance.Text = "Instancia Clasificada";
            // 
            // DataGridViewClassifiedInstance
            // 
            this.DataGridViewClassifiedInstance.AllowUserToAddRows = false;
            this.DataGridViewClassifiedInstance.AllowUserToDeleteRows = false;
            this.DataGridViewClassifiedInstance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewClassifiedInstance.Location = new System.Drawing.Point(12, 202);
            this.DataGridViewClassifiedInstance.Name = "DataGridViewClassifiedInstance";
            this.DataGridViewClassifiedInstance.ReadOnly = true;
            this.DataGridViewClassifiedInstance.RowHeadersVisible = false;
            this.DataGridViewClassifiedInstance.Size = new System.Drawing.Size(665, 65);
            this.DataGridViewClassifiedInstance.TabIndex = 17;
            // 
            // GroupBoxEvaluation
            // 
            this.GroupBoxEvaluation.Controls.Add(this.GroupBoxRegression);
            this.GroupBoxEvaluation.Controls.Add(this.GroupBoxClassification);
            this.GroupBoxEvaluation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxEvaluation.Location = new System.Drawing.Point(12, 12);
            this.GroupBoxEvaluation.Name = "GroupBoxEvaluation";
            this.GroupBoxEvaluation.Size = new System.Drawing.Size(665, 73);
            this.GroupBoxEvaluation.TabIndex = 21;
            this.GroupBoxEvaluation.TabStop = false;
            this.GroupBoxEvaluation.Text = "Evaluación";
            // 
            // GroupBoxRegression
            // 
            this.GroupBoxRegression.Controls.Add(this.LabelMeanSquaredErrorValue);
            this.GroupBoxRegression.Controls.Add(this.LabelMeanSquaredError);
            this.GroupBoxRegression.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxRegression.Location = new System.Drawing.Point(344, 25);
            this.GroupBoxRegression.Name = "GroupBoxRegression";
            this.GroupBoxRegression.Size = new System.Drawing.Size(315, 42);
            this.GroupBoxRegression.TabIndex = 1;
            this.GroupBoxRegression.TabStop = false;
            this.GroupBoxRegression.Text = "Regresión";
            // 
            // LabelMeanSquaredErrorValue
            // 
            this.LabelMeanSquaredErrorValue.AutoSize = true;
            this.LabelMeanSquaredErrorValue.Location = new System.Drawing.Point(149, 18);
            this.LabelMeanSquaredErrorValue.Name = "LabelMeanSquaredErrorValue";
            this.LabelMeanSquaredErrorValue.Size = new System.Drawing.Size(31, 16);
            this.LabelMeanSquaredErrorValue.TabIndex = 8;
            this.LabelMeanSquaredErrorValue.Text = "N/A";
            // 
            // LabelMeanSquaredError
            // 
            this.LabelMeanSquaredError.AutoSize = true;
            this.LabelMeanSquaredError.Location = new System.Drawing.Point(6, 18);
            this.LabelMeanSquaredError.Name = "LabelMeanSquaredError";
            this.LabelMeanSquaredError.Size = new System.Drawing.Size(149, 16);
            this.LabelMeanSquaredError.TabIndex = 0;
            this.LabelMeanSquaredError.Text = "Error Cuadrático Medio:";
            // 
            // GroupBoxClassification
            // 
            this.GroupBoxClassification.Controls.Add(this.LabelAccuracyValue);
            this.GroupBoxClassification.Controls.Add(this.LabelAccuracy);
            this.GroupBoxClassification.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxClassification.Location = new System.Drawing.Point(6, 25);
            this.GroupBoxClassification.Name = "GroupBoxClassification";
            this.GroupBoxClassification.Size = new System.Drawing.Size(315, 42);
            this.GroupBoxClassification.TabIndex = 0;
            this.GroupBoxClassification.TabStop = false;
            this.GroupBoxClassification.Text = "Clasificación";
            // 
            // LabelAccuracyValue
            // 
            this.LabelAccuracyValue.AutoSize = true;
            this.LabelAccuracyValue.Location = new System.Drawing.Point(65, 18);
            this.LabelAccuracyValue.Name = "LabelAccuracyValue";
            this.LabelAccuracyValue.Size = new System.Drawing.Size(31, 16);
            this.LabelAccuracyValue.TabIndex = 3;
            this.LabelAccuracyValue.Text = "N/A";
            // 
            // LabelAccuracy
            // 
            this.LabelAccuracy.AutoSize = true;
            this.LabelAccuracy.Location = new System.Drawing.Point(6, 18);
            this.LabelAccuracy.Name = "LabelAccuracy";
            this.LabelAccuracy.Size = new System.Drawing.Size(65, 16);
            this.LabelAccuracy.TabIndex = 2;
            this.LabelAccuracy.Text = "Exactitud:";
            // 
            // InstancesAndKNearestNeighbors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 538);
            this.Controls.Add(this.GroupBoxEvaluation);
            this.Controls.Add(this.LabelClassifiedInstance);
            this.Controls.Add(this.DataGridViewClassifiedInstance);
            this.Controls.Add(this.LabelNearestNeighbors);
            this.Controls.Add(this.LabelOriginalInstance);
            this.Controls.Add(this.ButtonPrevious);
            this.Controls.Add(this.ButtonNext);
            this.Controls.Add(this.DataGridViewNearestNeighbors);
            this.Controls.Add(this.DataGridViewOriginalInstance);
            this.Name = "InstancesAndKNearestNeighbors";
            this.Text = "Instancias y K-Nearest Neighbors";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewNearestNeighbors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewOriginalInstance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewClassifiedInstance)).EndInit();
            this.GroupBoxEvaluation.ResumeLayout(false);
            this.GroupBoxRegression.ResumeLayout(false);
            this.GroupBoxRegression.PerformLayout();
            this.GroupBoxClassification.ResumeLayout(false);
            this.GroupBoxClassification.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LabelNearestNeighbors;
        private System.Windows.Forms.Label LabelOriginalInstance;
        private System.Windows.Forms.Button ButtonPrevious;
        private System.Windows.Forms.Button ButtonNext;
        private System.Windows.Forms.DataGridView DataGridViewNearestNeighbors;
        private System.Windows.Forms.DataGridView DataGridViewOriginalInstance;
        private System.Windows.Forms.Label LabelClassifiedInstance;
        private System.Windows.Forms.DataGridView DataGridViewClassifiedInstance;
        private System.Windows.Forms.GroupBox GroupBoxEvaluation;
        private System.Windows.Forms.GroupBox GroupBoxRegression;
        private System.Windows.Forms.Label LabelMeanSquaredErrorValue;
        private System.Windows.Forms.Label LabelMeanSquaredError;
        private System.Windows.Forms.GroupBox GroupBoxClassification;
        private System.Windows.Forms.Label LabelAccuracyValue;
        private System.Windows.Forms.Label LabelAccuracy;
    }
}