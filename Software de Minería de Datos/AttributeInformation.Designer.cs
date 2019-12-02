namespace Software_de_Minería_de_Datos
{
    partial class AttributeInformation
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
            this.ButtonClose = new System.Windows.Forms.Button();
            this.LabelDataType = new System.Windows.Forms.Label();
            this.LabelName = new System.Windows.Forms.Label();
            this.LabelAttributes = new System.Windows.Forms.Label();
            this.ListBoxAttributes = new System.Windows.Forms.ListBox();
            this.GroupBoxInformation = new System.Windows.Forms.GroupBox();
            this.LabelOutOfDomainValuesValue = new System.Windows.Forms.Label();
            this.LabelMissingValuesValue = new System.Windows.Forms.Label();
            this.LabelDataTypeValue = new System.Windows.Forms.Label();
            this.LabelNameValue = new System.Windows.Forms.Label();
            this.LabelOutOfDomainValues = new System.Windows.Forms.Label();
            this.LabelMissingValues = new System.Windows.Forms.Label();
            this.LabelDomainValue = new System.Windows.Forms.Label();
            this.LabelDomain = new System.Windows.Forms.Label();
            this.GroupBoxInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonClose
            // 
            this.ButtonClose.Location = new System.Drawing.Point(341, 149);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(75, 23);
            this.ButtonClose.TabIndex = 25;
            this.ButtonClose.Text = "Cerrar";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // LabelDataType
            // 
            this.LabelDataType.AutoSize = true;
            this.LabelDataType.Location = new System.Drawing.Point(6, 43);
            this.LabelDataType.Name = "LabelDataType";
            this.LabelDataType.Size = new System.Drawing.Size(72, 13);
            this.LabelDataType.TabIndex = 20;
            this.LabelDataType.Text = "Tipo de Dato:";
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Location = new System.Drawing.Point(6, 21);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(47, 13);
            this.LabelName.TabIndex = 18;
            this.LabelName.Text = "Nombre:";
            // 
            // LabelAttributes
            // 
            this.LabelAttributes.AutoSize = true;
            this.LabelAttributes.Location = new System.Drawing.Point(12, 9);
            this.LabelAttributes.Name = "LabelAttributes";
            this.LabelAttributes.Size = new System.Drawing.Size(51, 13);
            this.LabelAttributes.TabIndex = 17;
            this.LabelAttributes.Text = "Atributos:";
            // 
            // ListBoxAttributes
            // 
            this.ListBoxAttributes.FormattingEnabled = true;
            this.ListBoxAttributes.Location = new System.Drawing.Point(12, 25);
            this.ListBoxAttributes.Name = "ListBoxAttributes";
            this.ListBoxAttributes.Size = new System.Drawing.Size(150, 186);
            this.ListBoxAttributes.TabIndex = 16;
            this.ListBoxAttributes.SelectedIndexChanged += new System.EventHandler(this.ListBoxAttributes_SelectedIndexChanged);
            // 
            // GroupBoxInformation
            // 
            this.GroupBoxInformation.Controls.Add(this.LabelDomainValue);
            this.GroupBoxInformation.Controls.Add(this.LabelOutOfDomainValuesValue);
            this.GroupBoxInformation.Controls.Add(this.LabelMissingValuesValue);
            this.GroupBoxInformation.Controls.Add(this.LabelDomain);
            this.GroupBoxInformation.Controls.Add(this.LabelDataTypeValue);
            this.GroupBoxInformation.Controls.Add(this.LabelNameValue);
            this.GroupBoxInformation.Controls.Add(this.LabelOutOfDomainValues);
            this.GroupBoxInformation.Controls.Add(this.LabelMissingValues);
            this.GroupBoxInformation.Controls.Add(this.LabelName);
            this.GroupBoxInformation.Controls.Add(this.LabelDataType);
            this.GroupBoxInformation.Location = new System.Drawing.Point(168, 12);
            this.GroupBoxInformation.Name = "GroupBoxInformation";
            this.GroupBoxInformation.Size = new System.Drawing.Size(248, 131);
            this.GroupBoxInformation.TabIndex = 26;
            this.GroupBoxInformation.TabStop = false;
            this.GroupBoxInformation.Text = "Información";
            // 
            // LabelOutOfDomainValuesValue
            // 
            this.LabelOutOfDomainValuesValue.AutoSize = true;
            this.LabelOutOfDomainValuesValue.Location = new System.Drawing.Point(134, 109);
            this.LabelOutOfDomainValuesValue.Name = "LabelOutOfDomainValuesValue";
            this.LabelOutOfDomainValuesValue.Size = new System.Drawing.Size(27, 13);
            this.LabelOutOfDomainValuesValue.TabIndex = 31;
            this.LabelOutOfDomainValuesValue.Text = "N/A";
            // 
            // LabelMissingValuesValue
            // 
            this.LabelMissingValuesValue.AutoSize = true;
            this.LabelMissingValuesValue.Location = new System.Drawing.Point(92, 65);
            this.LabelMissingValuesValue.Name = "LabelMissingValuesValue";
            this.LabelMissingValuesValue.Size = new System.Drawing.Size(27, 13);
            this.LabelMissingValuesValue.TabIndex = 30;
            this.LabelMissingValuesValue.Text = "N/A";
            // 
            // LabelDataTypeValue
            // 
            this.LabelDataTypeValue.AutoSize = true;
            this.LabelDataTypeValue.Location = new System.Drawing.Point(73, 43);
            this.LabelDataTypeValue.Name = "LabelDataTypeValue";
            this.LabelDataTypeValue.Size = new System.Drawing.Size(27, 13);
            this.LabelDataTypeValue.TabIndex = 29;
            this.LabelDataTypeValue.Text = "N/A";
            // 
            // LabelNameValue
            // 
            this.LabelNameValue.AutoSize = true;
            this.LabelNameValue.Location = new System.Drawing.Point(48, 21);
            this.LabelNameValue.Name = "LabelNameValue";
            this.LabelNameValue.Size = new System.Drawing.Size(27, 13);
            this.LabelNameValue.TabIndex = 28;
            this.LabelNameValue.Text = "N/A";
            // 
            // LabelOutOfDomainValues
            // 
            this.LabelOutOfDomainValues.AutoSize = true;
            this.LabelOutOfDomainValues.Location = new System.Drawing.Point(6, 109);
            this.LabelOutOfDomainValues.Name = "LabelOutOfDomainValues";
            this.LabelOutOfDomainValues.Size = new System.Drawing.Size(133, 13);
            this.LabelOutOfDomainValues.TabIndex = 27;
            this.LabelOutOfDomainValues.Text = "Valores Fuera del Dominio:";
            // 
            // LabelMissingValues
            // 
            this.LabelMissingValues.AutoSize = true;
            this.LabelMissingValues.Location = new System.Drawing.Point(6, 65);
            this.LabelMissingValues.Name = "LabelMissingValues";
            this.LabelMissingValues.Size = new System.Drawing.Size(91, 13);
            this.LabelMissingValues.TabIndex = 27;
            this.LabelMissingValues.Text = "Valores Faltantes:";
            // 
            // LabelDomainValue
            // 
            this.LabelDomainValue.AutoSize = true;
            this.LabelDomainValue.Location = new System.Drawing.Point(49, 87);
            this.LabelDomainValue.Name = "LabelDomainValue";
            this.LabelDomainValue.Size = new System.Drawing.Size(27, 13);
            this.LabelDomainValue.TabIndex = 33;
            this.LabelDomainValue.Text = "N/A";
            // 
            // LabelDomain
            // 
            this.LabelDomain.AutoSize = true;
            this.LabelDomain.Location = new System.Drawing.Point(6, 87);
            this.LabelDomain.Name = "LabelDomain";
            this.LabelDomain.Size = new System.Drawing.Size(48, 13);
            this.LabelDomain.TabIndex = 32;
            this.LabelDomain.Text = "Dominio:";
            // 
            // AttributeInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 224);
            this.ControlBox = false;
            this.Controls.Add(this.GroupBoxInformation);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.LabelAttributes);
            this.Controls.Add(this.ListBoxAttributes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AttributeInformation";
            this.Text = "Información de los Atributos";
            this.GroupBoxInformation.ResumeLayout(false);
            this.GroupBoxInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.Label LabelDataType;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.Label LabelAttributes;
        private System.Windows.Forms.ListBox ListBoxAttributes;
        private System.Windows.Forms.GroupBox GroupBoxInformation;
        private System.Windows.Forms.Label LabelOutOfDomainValuesValue;
        private System.Windows.Forms.Label LabelMissingValuesValue;
        private System.Windows.Forms.Label LabelDataTypeValue;
        private System.Windows.Forms.Label LabelNameValue;
        private System.Windows.Forms.Label LabelOutOfDomainValues;
        private System.Windows.Forms.Label LabelMissingValues;
        private System.Windows.Forms.Label LabelDomainValue;
        private System.Windows.Forms.Label LabelDomain;
    }
}