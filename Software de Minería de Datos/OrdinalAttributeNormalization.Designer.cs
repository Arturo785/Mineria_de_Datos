namespace Software_de_Minería_de_Datos
{
    partial class OrdinalAttributeNormalization
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
            this.ButtonNext = new System.Windows.Forms.Button();
            this.LabelNumericalValue = new System.Windows.Forms.Label();
            this.TextBoxAttributeValue = new System.Windows.Forms.TextBox();
            this.LabelAttributeValue = new System.Windows.Forms.Label();
            this.NumericUpDownNumericalValue = new System.Windows.Forms.NumericUpDown();
            this.ButtonPrevious = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownNumericalValue)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonNext
            // 
            this.ButtonNext.Location = new System.Drawing.Point(114, 108);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(83, 23);
            this.ButtonNext.TabIndex = 14;
            this.ButtonNext.Text = "Siguiente";
            this.ButtonNext.UseVisualStyleBackColor = true;
            this.ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // LabelNumericalValue
            // 
            this.LabelNumericalValue.AutoSize = true;
            this.LabelNumericalValue.Location = new System.Drawing.Point(12, 57);
            this.LabelNumericalValue.Name = "LabelNumericalValue";
            this.LabelNumericalValue.Size = new System.Drawing.Size(82, 13);
            this.LabelNumericalValue.TabIndex = 12;
            this.LabelNumericalValue.Text = "Valor Numérico:";
            // 
            // TextBoxAttributeValue
            // 
            this.TextBoxAttributeValue.Enabled = false;
            this.TextBoxAttributeValue.Location = new System.Drawing.Point(12, 25);
            this.TextBoxAttributeValue.Name = "TextBoxAttributeValue";
            this.TextBoxAttributeValue.Size = new System.Drawing.Size(185, 20);
            this.TextBoxAttributeValue.TabIndex = 11;
            // 
            // LabelAttributeValue
            // 
            this.LabelAttributeValue.AutoSize = true;
            this.LabelAttributeValue.Location = new System.Drawing.Point(12, 9);
            this.LabelAttributeValue.Name = "LabelAttributeValue";
            this.LabelAttributeValue.Size = new System.Drawing.Size(87, 13);
            this.LabelAttributeValue.TabIndex = 10;
            this.LabelAttributeValue.Text = "Valor del Atributo";
            // 
            // NumericUpDownNumericalValue
            // 
            this.NumericUpDownNumericalValue.Location = new System.Drawing.Point(12, 73);
            this.NumericUpDownNumericalValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownNumericalValue.Name = "NumericUpDownNumericalValue";
            this.NumericUpDownNumericalValue.Size = new System.Drawing.Size(185, 20);
            this.NumericUpDownNumericalValue.TabIndex = 16;
            this.NumericUpDownNumericalValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ButtonPrevious
            // 
            this.ButtonPrevious.Location = new System.Drawing.Point(12, 108);
            this.ButtonPrevious.Name = "ButtonPrevious";
            this.ButtonPrevious.Size = new System.Drawing.Size(83, 23);
            this.ButtonPrevious.TabIndex = 17;
            this.ButtonPrevious.Text = "Anterior";
            this.ButtonPrevious.UseVisualStyleBackColor = true;
            this.ButtonPrevious.Click += new System.EventHandler(this.ButtonPrevious_Click);
            // 
            // OrdinalAttributeNormalization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 143);
            this.ControlBox = false;
            this.Controls.Add(this.ButtonPrevious);
            this.Controls.Add(this.NumericUpDownNumericalValue);
            this.Controls.Add(this.ButtonNext);
            this.Controls.Add(this.LabelNumericalValue);
            this.Controls.Add(this.TextBoxAttributeValue);
            this.Controls.Add(this.LabelAttributeValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "OrdinalAttributeNormalization";
            this.Text = "Normalización de Atributo Ordinal";
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownNumericalValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ButtonNext;
        private System.Windows.Forms.Label LabelNumericalValue;
        private System.Windows.Forms.TextBox TextBoxAttributeValue;
        private System.Windows.Forms.Label LabelAttributeValue;
        private System.Windows.Forms.NumericUpDown NumericUpDownNumericalValue;
        private System.Windows.Forms.Button ButtonPrevious;
    }
}