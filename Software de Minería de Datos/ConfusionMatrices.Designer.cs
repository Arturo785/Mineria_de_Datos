namespace Software_de_Minería_de_Datos
{
    partial class ConfusionMatrices
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
            this.DataGridViewConfusionMatrix = new System.Windows.Forms.DataGridView();
            this.LabelObjective = new System.Windows.Forms.Label();
            this.LabelModel = new System.Windows.Forms.Label();
            this.ButtonNextMatrix = new System.Windows.Forms.Button();
            this.ButtonPreviousMatrix = new System.Windows.Forms.Button();
            this.LabelK = new System.Windows.Forms.Label();
            this.LabelKValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewConfusionMatrix)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewConfusionMatrix
            // 
            this.DataGridViewConfusionMatrix.AllowUserToAddRows = false;
            this.DataGridViewConfusionMatrix.AllowUserToDeleteRows = false;
            this.DataGridViewConfusionMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewConfusionMatrix.Location = new System.Drawing.Point(79, 32);
            this.DataGridViewConfusionMatrix.Name = "DataGridViewConfusionMatrix";
            this.DataGridViewConfusionMatrix.RowHeadersVisible = false;
            this.DataGridViewConfusionMatrix.Size = new System.Drawing.Size(598, 465);
            this.DataGridViewConfusionMatrix.TabIndex = 0;
            this.DataGridViewConfusionMatrix.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DataGridViewConfusionMatrix_ColumnAdded);
            // 
            // LabelObjective
            // 
            this.LabelObjective.AutoSize = true;
            this.LabelObjective.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelObjective.Location = new System.Drawing.Point(345, 9);
            this.LabelObjective.Name = "LabelObjective";
            this.LabelObjective.Size = new System.Drawing.Size(66, 20);
            this.LabelObjective.TabIndex = 1;
            this.LabelObjective.Text = "Objetivo";
            // 
            // LabelModel
            // 
            this.LabelModel.AutoSize = true;
            this.LabelModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelModel.Location = new System.Drawing.Point(12, 240);
            this.LabelModel.Name = "LabelModel";
            this.LabelModel.Size = new System.Drawing.Size(61, 20);
            this.LabelModel.TabIndex = 2;
            this.LabelModel.Text = "Modelo";
            // 
            // ButtonNextMatrix
            // 
            this.ButtonNextMatrix.Location = new System.Drawing.Point(527, 503);
            this.ButtonNextMatrix.Name = "ButtonNextMatrix";
            this.ButtonNextMatrix.Size = new System.Drawing.Size(150, 23);
            this.ButtonNextMatrix.TabIndex = 3;
            this.ButtonNextMatrix.Text = "Siguiente Matriz";
            this.ButtonNextMatrix.UseVisualStyleBackColor = true;
            this.ButtonNextMatrix.Click += new System.EventHandler(this.ButtonNextMatrix_Click);
            // 
            // ButtonPreviousMatrix
            // 
            this.ButtonPreviousMatrix.Location = new System.Drawing.Point(372, 503);
            this.ButtonPreviousMatrix.Name = "ButtonPreviousMatrix";
            this.ButtonPreviousMatrix.Size = new System.Drawing.Size(149, 23);
            this.ButtonPreviousMatrix.TabIndex = 4;
            this.ButtonPreviousMatrix.Text = "Matriz Anterior";
            this.ButtonPreviousMatrix.UseVisualStyleBackColor = true;
            this.ButtonPreviousMatrix.Click += new System.EventHandler(this.ButtonPreviousMatrix_Click);
            // 
            // LabelK
            // 
            this.LabelK.AutoSize = true;
            this.LabelK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelK.Location = new System.Drawing.Point(12, 9);
            this.LabelK.Name = "LabelK";
            this.LabelK.Size = new System.Drawing.Size(32, 20);
            this.LabelK.TabIndex = 5;
            this.LabelK.Text = "K =";
            // 
            // LabelKValue
            // 
            this.LabelKValue.AutoSize = true;
            this.LabelKValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelKValue.Location = new System.Drawing.Point(39, 9);
            this.LabelKValue.Name = "LabelKValue";
            this.LabelKValue.Size = new System.Drawing.Size(35, 20);
            this.LabelKValue.TabIndex = 6;
            this.LabelKValue.Text = "N/A";
            // 
            // ConfusionMatrices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 538);
            this.Controls.Add(this.LabelKValue);
            this.Controls.Add(this.LabelK);
            this.Controls.Add(this.ButtonPreviousMatrix);
            this.Controls.Add(this.ButtonNextMatrix);
            this.Controls.Add(this.LabelModel);
            this.Controls.Add(this.LabelObjective);
            this.Controls.Add(this.DataGridViewConfusionMatrix);
            this.Name = "ConfusionMatrices";
            this.Text = "Matrices de Confusión";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewConfusionMatrix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewConfusionMatrix;
        private System.Windows.Forms.Label LabelObjective;
        private System.Windows.Forms.Label LabelModel;
        private System.Windows.Forms.Button ButtonNextMatrix;
        private System.Windows.Forms.Button ButtonPreviousMatrix;
        private System.Windows.Forms.Label LabelK;
        private System.Windows.Forms.Label LabelKValue;
    }
}