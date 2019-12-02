namespace Software_de_Minería_de_Datos
{
    partial class AddInstances
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
            this.NumericUpDownNumberOfInstances = new System.Windows.Forms.NumericUpDown();
            this.LabelNumberOfInstances = new System.Windows.Forms.Label();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.TextBoxDefaultValue = new System.Windows.Forms.TextBox();
            this.LabelDefaultValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownNumberOfInstances)).BeginInit();
            this.SuspendLayout();
            // 
            // NumericUpDownNumberOfInstances
            // 
            this.NumericUpDownNumberOfInstances.Location = new System.Drawing.Point(12, 25);
            this.NumericUpDownNumberOfInstances.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownNumberOfInstances.Name = "NumericUpDownNumberOfInstances";
            this.NumericUpDownNumberOfInstances.Size = new System.Drawing.Size(237, 20);
            this.NumericUpDownNumberOfInstances.TabIndex = 0;
            this.NumericUpDownNumberOfInstances.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LabelNumberOfInstances
            // 
            this.LabelNumberOfInstances.AutoSize = true;
            this.LabelNumberOfInstances.Location = new System.Drawing.Point(12, 9);
            this.LabelNumberOfInstances.Name = "LabelNumberOfInstances";
            this.LabelNumberOfInstances.Size = new System.Drawing.Size(113, 13);
            this.LabelNumberOfInstances.TabIndex = 1;
            this.LabelNumberOfInstances.Text = "Número de Instancias:";
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(174, 99);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 17;
            this.ButtonCancel.Text = "Cancelar";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(93, 99);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(75, 23);
            this.ButtonAdd.TabIndex = 16;
            this.ButtonAdd.Text = "Agregar";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // TextBoxDefaultValue
            // 
            this.TextBoxDefaultValue.Location = new System.Drawing.Point(12, 73);
            this.TextBoxDefaultValue.Name = "TextBoxDefaultValue";
            this.TextBoxDefaultValue.Size = new System.Drawing.Size(237, 20);
            this.TextBoxDefaultValue.TabIndex = 19;
            // 
            // LabelDefaultValue
            // 
            this.LabelDefaultValue.AutoSize = true;
            this.LabelDefaultValue.Location = new System.Drawing.Point(9, 57);
            this.LabelDefaultValue.Name = "LabelDefaultValue";
            this.LabelDefaultValue.Size = new System.Drawing.Size(94, 13);
            this.LabelDefaultValue.TabIndex = 18;
            this.LabelDefaultValue.Text = "Valor Por Defecto:";
            // 
            // AddInstances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 132);
            this.ControlBox = false;
            this.Controls.Add(this.TextBoxDefaultValue);
            this.Controls.Add(this.LabelDefaultValue);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.LabelNumberOfInstances);
            this.Controls.Add(this.NumericUpDownNumberOfInstances);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddInstances";
            this.Text = "Agregar Instancias";
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownNumberOfInstances)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NumericUpDownNumberOfInstances;
        private System.Windows.Forms.Label LabelNumberOfInstances;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.TextBox TextBoxDefaultValue;
        private System.Windows.Forms.Label LabelDefaultValue;
    }
}