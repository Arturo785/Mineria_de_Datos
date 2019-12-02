namespace Software_de_Minería_de_Datos
{
    partial class EditAttribute
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
            this.ListBoxAttributes = new System.Windows.Forms.ListBox();
            this.LabelAttributes = new System.Windows.Forms.Label();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonEdit = new System.Windows.Forms.Button();
            this.TextBoxDomain = new System.Windows.Forms.TextBox();
            this.LabelDomain = new System.Windows.Forms.Label();
            this.ComboBoxDataType = new System.Windows.Forms.ComboBox();
            this.LabelDataType = new System.Windows.Forms.Label();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.LabelName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ListBoxAttributes
            // 
            this.ListBoxAttributes.FormattingEnabled = true;
            this.ListBoxAttributes.Location = new System.Drawing.Point(12, 25);
            this.ListBoxAttributes.Name = "ListBoxAttributes";
            this.ListBoxAttributes.Size = new System.Drawing.Size(150, 186);
            this.ListBoxAttributes.TabIndex = 0;
            this.ListBoxAttributes.SelectedIndexChanged += new System.EventHandler(this.ListBoxAttributes_SelectedIndexChanged);
            // 
            // LabelAttributes
            // 
            this.LabelAttributes.AutoSize = true;
            this.LabelAttributes.Location = new System.Drawing.Point(12, 9);
            this.LabelAttributes.Name = "LabelAttributes";
            this.LabelAttributes.Size = new System.Drawing.Size(51, 13);
            this.LabelAttributes.TabIndex = 1;
            this.LabelAttributes.Text = "Atributos:";
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(341, 157);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 15;
            this.ButtonCancel.Text = "Cancelar";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.Location = new System.Drawing.Point(260, 157);
            this.ButtonEdit.Name = "ButtonEdit";
            this.ButtonEdit.Size = new System.Drawing.Size(75, 23);
            this.ButtonEdit.TabIndex = 14;
            this.ButtonEdit.Text = "Editar";
            this.ButtonEdit.UseVisualStyleBackColor = true;
            this.ButtonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // TextBoxDomain
            // 
            this.TextBoxDomain.Location = new System.Drawing.Point(179, 122);
            this.TextBoxDomain.Name = "TextBoxDomain";
            this.TextBoxDomain.Size = new System.Drawing.Size(237, 20);
            this.TextBoxDomain.TabIndex = 13;
            // 
            // LabelDomain
            // 
            this.LabelDomain.AutoSize = true;
            this.LabelDomain.Location = new System.Drawing.Point(176, 106);
            this.LabelDomain.Name = "LabelDomain";
            this.LabelDomain.Size = new System.Drawing.Size(143, 13);
            this.LabelDomain.TabIndex = 12;
            this.LabelDomain.Text = "Dominio (Expresión Regular):";
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
            this.ComboBoxDataType.Location = new System.Drawing.Point(179, 73);
            this.ComboBoxDataType.Name = "ComboBoxDataType";
            this.ComboBoxDataType.Size = new System.Drawing.Size(237, 21);
            this.ComboBoxDataType.TabIndex = 11;
            // 
            // LabelDataType
            // 
            this.LabelDataType.AutoSize = true;
            this.LabelDataType.Location = new System.Drawing.Point(176, 57);
            this.LabelDataType.Name = "LabelDataType";
            this.LabelDataType.Size = new System.Drawing.Size(72, 13);
            this.LabelDataType.TabIndex = 10;
            this.LabelDataType.Text = "Tipo de Dato:";
            // 
            // TextBoxName
            // 
            this.TextBoxName.Location = new System.Drawing.Point(179, 25);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(237, 20);
            this.TextBoxName.TabIndex = 9;
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Location = new System.Drawing.Point(176, 9);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(47, 13);
            this.LabelName.TabIndex = 8;
            this.LabelName.Text = "Nombre:";
            // 
            // EditAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 224);
            this.ControlBox = false;
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonEdit);
            this.Controls.Add(this.TextBoxDomain);
            this.Controls.Add(this.LabelDomain);
            this.Controls.Add(this.ComboBoxDataType);
            this.Controls.Add(this.LabelDataType);
            this.Controls.Add(this.TextBoxName);
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.LabelAttributes);
            this.Controls.Add(this.ListBoxAttributes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EditAttribute";
            this.Text = "Editar Atributo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxAttributes;
        private System.Windows.Forms.Label LabelAttributes;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonEdit;
        private System.Windows.Forms.TextBox TextBoxDomain;
        private System.Windows.Forms.Label LabelDomain;
        private System.Windows.Forms.ComboBox ComboBoxDataType;
        private System.Windows.Forms.Label LabelDataType;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.Label LabelName;
    }
}