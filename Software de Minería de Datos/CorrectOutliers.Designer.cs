namespace Software_de_Minería_de_Datos
{
    partial class CorrectOutliers
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
            this.LabelOutlierValue = new System.Windows.Forms.Label();
            this.TextBoxOutlierValue = new System.Windows.Forms.TextBox();
            this.LabelCategory = new System.Windows.Forms.Label();
            this.LabelCategoryValue = new System.Windows.Forms.Label();
            this.TextBoxNewValue = new System.Windows.Forms.TextBox();
            this.LabelNewValue = new System.Windows.Forms.Label();
            this.ButtonCorrect = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelOutlierValue
            // 
            this.LabelOutlierValue.AutoSize = true;
            this.LabelOutlierValue.Location = new System.Drawing.Point(12, 31);
            this.LabelOutlierValue.Name = "LabelOutlierValue";
            this.LabelOutlierValue.Size = new System.Drawing.Size(84, 13);
            this.LabelOutlierValue.TabIndex = 0;
            this.LabelOutlierValue.Text = "Valor del Outlier:";
            // 
            // TextBoxOutlierValue
            // 
            this.TextBoxOutlierValue.Enabled = false;
            this.TextBoxOutlierValue.Location = new System.Drawing.Point(12, 47);
            this.TextBoxOutlierValue.Name = "TextBoxOutlierValue";
            this.TextBoxOutlierValue.Size = new System.Drawing.Size(161, 20);
            this.TextBoxOutlierValue.TabIndex = 1;
            // 
            // LabelCategory
            // 
            this.LabelCategory.AutoSize = true;
            this.LabelCategory.Location = new System.Drawing.Point(12, 9);
            this.LabelCategory.Name = "LabelCategory";
            this.LabelCategory.Size = new System.Drawing.Size(55, 13);
            this.LabelCategory.TabIndex = 2;
            this.LabelCategory.Text = "Categoria:";
            // 
            // LabelCategoryValue
            // 
            this.LabelCategoryValue.AutoSize = true;
            this.LabelCategoryValue.Location = new System.Drawing.Point(62, 9);
            this.LabelCategoryValue.Name = "LabelCategoryValue";
            this.LabelCategoryValue.Size = new System.Drawing.Size(27, 13);
            this.LabelCategoryValue.TabIndex = 3;
            this.LabelCategoryValue.Text = "N/A";
            // 
            // TextBoxNewValue
            // 
            this.TextBoxNewValue.Location = new System.Drawing.Point(12, 95);
            this.TextBoxNewValue.Name = "TextBoxNewValue";
            this.TextBoxNewValue.Size = new System.Drawing.Size(161, 20);
            this.TextBoxNewValue.TabIndex = 5;
            // 
            // LabelNewValue
            // 
            this.LabelNewValue.AutoSize = true;
            this.LabelNewValue.Location = new System.Drawing.Point(12, 79);
            this.LabelNewValue.Name = "LabelNewValue";
            this.LabelNewValue.Size = new System.Drawing.Size(69, 13);
            this.LabelNewValue.TabIndex = 4;
            this.LabelNewValue.Text = "Nuevo Valor:";
            // 
            // ButtonCorrect
            // 
            this.ButtonCorrect.Location = new System.Drawing.Point(11, 130);
            this.ButtonCorrect.Name = "ButtonCorrect";
            this.ButtonCorrect.Size = new System.Drawing.Size(78, 23);
            this.ButtonCorrect.TabIndex = 6;
            this.ButtonCorrect.Text = "Corregir";
            this.ButtonCorrect.UseVisualStyleBackColor = true;
            this.ButtonCorrect.Click += new System.EventHandler(this.ButtonCorrect_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(95, 130);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(78, 23);
            this.ButtonCancel.TabIndex = 9;
            this.ButtonCancel.Text = "Cancelar";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // CorrectOutliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(185, 166);
            this.ControlBox = false;
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonCorrect);
            this.Controls.Add(this.TextBoxNewValue);
            this.Controls.Add(this.LabelNewValue);
            this.Controls.Add(this.LabelCategoryValue);
            this.Controls.Add(this.LabelCategory);
            this.Controls.Add(this.TextBoxOutlierValue);
            this.Controls.Add(this.LabelOutlierValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CorrectOutliers";
            this.Text = "Corregir Outliers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelOutlierValue;
        private System.Windows.Forms.TextBox TextBoxOutlierValue;
        private System.Windows.Forms.Label LabelCategory;
        private System.Windows.Forms.Label LabelCategoryValue;
        private System.Windows.Forms.TextBox TextBoxNewValue;
        private System.Windows.Forms.Label LabelNewValue;
        private System.Windows.Forms.Button ButtonCorrect;
        private System.Windows.Forms.Button ButtonCancel;
    }
}