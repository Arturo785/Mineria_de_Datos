namespace Software_de_Minería_de_Datos
{
    partial class AddAttribute
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
            this.LabelName = new System.Windows.Forms.Label();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.LabelDataType = new System.Windows.Forms.Label();
            this.ComboBoxDataType = new System.Windows.Forms.ComboBox();
            this.LabelDomain = new System.Windows.Forms.Label();
            this.TextBoxDomain = new System.Windows.Forms.TextBox();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.TextBoxDefaultValue = new System.Windows.Forms.TextBox();
            this.LabelDefaultValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Location = new System.Drawing.Point(12, 9);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(47, 13);
            this.LabelName.TabIndex = 0;
            this.LabelName.Text = "Nombre:";
            // 
            // TextBoxName
            // 
            this.TextBoxName.Location = new System.Drawing.Point(15, 25);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(237, 20);
            this.TextBoxName.TabIndex = 1;
            // 
            // LabelDataType
            // 
            this.LabelDataType.AutoSize = true;
            this.LabelDataType.Location = new System.Drawing.Point(12, 57);
            this.LabelDataType.Name = "LabelDataType";
            this.LabelDataType.Size = new System.Drawing.Size(72, 13);
            this.LabelDataType.TabIndex = 2;
            this.LabelDataType.Text = "Tipo de Dato:";
            // 
            // ComboBoxDataType
            // 
            this.ComboBoxDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxDataType.FormattingEnabled = true;
            this.ComboBoxDataType.Items.AddRange(new object[] {
            "Nominal",
            "Ordinal",
            "Binario Simétrico",
            "Binario Asimétrico",
            "Numérico"});
            this.ComboBoxDataType.Location = new System.Drawing.Point(15, 73);
            this.ComboBoxDataType.Name = "ComboBoxDataType";
            this.ComboBoxDataType.Size = new System.Drawing.Size(237, 21);
            this.ComboBoxDataType.TabIndex = 3;
            // 
            // LabelDomain
            // 
            this.LabelDomain.AutoSize = true;
            this.LabelDomain.Location = new System.Drawing.Point(12, 106);
            this.LabelDomain.Name = "LabelDomain";
            this.LabelDomain.Size = new System.Drawing.Size(143, 13);
            this.LabelDomain.TabIndex = 4;
            this.LabelDomain.Text = "Dominio (Expresión Regular):";
            // 
            // TextBoxDomain
            // 
            this.TextBoxDomain.Location = new System.Drawing.Point(15, 122);
            this.TextBoxDomain.Name = "TextBoxDomain";
            this.TextBoxDomain.Size = new System.Drawing.Size(237, 20);
            this.TextBoxDomain.TabIndex = 5;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(96, 196);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(75, 23);
            this.ButtonAdd.TabIndex = 6;
            this.ButtonAdd.Text = "Agregar";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(177, 196);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 7;
            this.ButtonCancel.Text = "Cancelar";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // TextBoxDefaultValue
            // 
            this.TextBoxDefaultValue.Location = new System.Drawing.Point(15, 170);
            this.TextBoxDefaultValue.Name = "TextBoxDefaultValue";
            this.TextBoxDefaultValue.Size = new System.Drawing.Size(237, 20);
            this.TextBoxDefaultValue.TabIndex = 9;
            // 
            // LabelDefaultValue
            // 
            this.LabelDefaultValue.AutoSize = true;
            this.LabelDefaultValue.Location = new System.Drawing.Point(12, 154);
            this.LabelDefaultValue.Name = "LabelDefaultValue";
            this.LabelDefaultValue.Size = new System.Drawing.Size(94, 13);
            this.LabelDefaultValue.TabIndex = 8;
            this.LabelDefaultValue.Text = "Valor Por Defecto:";
            // 
            // AddAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 230);
            this.ControlBox = false;
            this.Controls.Add(this.TextBoxDefaultValue);
            this.Controls.Add(this.LabelDefaultValue);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.TextBoxDomain);
            this.Controls.Add(this.LabelDomain);
            this.Controls.Add(this.ComboBoxDataType);
            this.Controls.Add(this.LabelDataType);
            this.Controls.Add(this.TextBoxName);
            this.Controls.Add(this.LabelName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddAttribute";
            this.Text = "Agregar Atributo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.Label LabelDataType;
        private System.Windows.Forms.ComboBox ComboBoxDataType;
        private System.Windows.Forms.Label LabelDomain;
        private System.Windows.Forms.TextBox TextBoxDomain;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.TextBox TextBoxDefaultValue;
        private System.Windows.Forms.Label LabelDefaultValue;
    }
}