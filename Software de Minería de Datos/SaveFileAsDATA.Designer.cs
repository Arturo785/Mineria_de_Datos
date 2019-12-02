namespace Software_de_Minería_de_Datos
{
    partial class SaveFileAsDATA
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
            this.TextBoxGeneralInformation = new System.Windows.Forms.TextBox();
            this.GroupBoxDataBaseDescription = new System.Windows.Forms.GroupBox();
            this.TextBoxMissingValue = new System.Windows.Forms.TextBox();
            this.LabelMissingValue = new System.Windows.Forms.Label();
            this.GroupBoxAttributes = new System.Windows.Forms.GroupBox();
            this.DataGridViewAttributes = new System.Windows.Forms.DataGridView();
            this.TextBoxRelation = new System.Windows.Forms.TextBox();
            this.LabelRelation = new System.Windows.Forms.Label();
            this.LabelGeneralInformation = new System.Windows.Forms.Label();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ColumnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDataType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnDomain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBoxDataBaseDescription.SuspendLayout();
            this.GroupBoxAttributes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewAttributes)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBoxGeneralInformation
            // 
            this.TextBoxGeneralInformation.Location = new System.Drawing.Point(15, 25);
            this.TextBoxGeneralInformation.Multiline = true;
            this.TextBoxGeneralInformation.Name = "TextBoxGeneralInformation";
            this.TextBoxGeneralInformation.Size = new System.Drawing.Size(457, 75);
            this.TextBoxGeneralInformation.TabIndex = 0;
            // 
            // GroupBoxDataBaseDescription
            // 
            this.GroupBoxDataBaseDescription.Controls.Add(this.TextBoxMissingValue);
            this.GroupBoxDataBaseDescription.Controls.Add(this.LabelMissingValue);
            this.GroupBoxDataBaseDescription.Controls.Add(this.GroupBoxAttributes);
            this.GroupBoxDataBaseDescription.Controls.Add(this.TextBoxRelation);
            this.GroupBoxDataBaseDescription.Controls.Add(this.LabelRelation);
            this.GroupBoxDataBaseDescription.Location = new System.Drawing.Point(15, 106);
            this.GroupBoxDataBaseDescription.Name = "GroupBoxDataBaseDescription";
            this.GroupBoxDataBaseDescription.Size = new System.Drawing.Size(457, 264);
            this.GroupBoxDataBaseDescription.TabIndex = 1;
            this.GroupBoxDataBaseDescription.TabStop = false;
            this.GroupBoxDataBaseDescription.Text = "Descripción de la Base de Datos";
            // 
            // TextBoxMissingValue
            // 
            this.TextBoxMissingValue.Location = new System.Drawing.Point(9, 236);
            this.TextBoxMissingValue.Name = "TextBoxMissingValue";
            this.TextBoxMissingValue.Size = new System.Drawing.Size(442, 20);
            this.TextBoxMissingValue.TabIndex = 7;
            // 
            // LabelMissingValue
            // 
            this.LabelMissingValue.AutoSize = true;
            this.LabelMissingValue.Location = new System.Drawing.Point(6, 220);
            this.LabelMissingValue.Name = "LabelMissingValue";
            this.LabelMissingValue.Size = new System.Drawing.Size(75, 13);
            this.LabelMissingValue.TabIndex = 6;
            this.LabelMissingValue.Text = "Valor Faltante:";
            // 
            // GroupBoxAttributes
            // 
            this.GroupBoxAttributes.Controls.Add(this.DataGridViewAttributes);
            this.GroupBoxAttributes.Location = new System.Drawing.Point(9, 58);
            this.GroupBoxAttributes.Name = "GroupBoxAttributes";
            this.GroupBoxAttributes.Size = new System.Drawing.Size(442, 159);
            this.GroupBoxAttributes.TabIndex = 5;
            this.GroupBoxAttributes.TabStop = false;
            this.GroupBoxAttributes.Text = "Atributos";
            // 
            // DataGridViewAttributes
            // 
            this.DataGridViewAttributes.AllowUserToAddRows = false;
            this.DataGridViewAttributes.AllowUserToDeleteRows = false;
            this.DataGridViewAttributes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNumber,
            this.ColumnName,
            this.ColumnDataType,
            this.ColumnDomain});
            this.DataGridViewAttributes.Location = new System.Drawing.Point(6, 19);
            this.DataGridViewAttributes.Name = "DataGridViewAttributes";
            this.DataGridViewAttributes.RowHeadersVisible = false;
            this.DataGridViewAttributes.Size = new System.Drawing.Size(430, 134);
            this.DataGridViewAttributes.TabIndex = 0;
            // 
            // TextBoxRelation
            // 
            this.TextBoxRelation.Location = new System.Drawing.Point(9, 32);
            this.TextBoxRelation.Name = "TextBoxRelation";
            this.TextBoxRelation.Size = new System.Drawing.Size(442, 20);
            this.TextBoxRelation.TabIndex = 4;
            // 
            // LabelRelation
            // 
            this.LabelRelation.AutoSize = true;
            this.LabelRelation.Location = new System.Drawing.Point(6, 16);
            this.LabelRelation.Name = "LabelRelation";
            this.LabelRelation.Size = new System.Drawing.Size(52, 13);
            this.LabelRelation.TabIndex = 3;
            this.LabelRelation.Text = "Relación:";
            // 
            // LabelGeneralInformation
            // 
            this.LabelGeneralInformation.AutoSize = true;
            this.LabelGeneralInformation.Location = new System.Drawing.Point(12, 9);
            this.LabelGeneralInformation.Name = "LabelGeneralInformation";
            this.LabelGeneralInformation.Size = new System.Drawing.Size(105, 13);
            this.LabelGeneralInformation.TabIndex = 2;
            this.LabelGeneralInformation.Text = "Información General:";
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(266, 376);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 3;
            this.ButtonSave.Text = "Guardar";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(347, 376);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 4;
            this.ButtonCancel.Text = "Cancelar";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ColumnNumber
            // 
            this.ColumnNumber.HeaderText = "Número";
            this.ColumnNumber.Name = "ColumnNumber";
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Nombre";
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnDataType
            // 
            this.ColumnDataType.HeaderText = "Tipo de Dato";
            this.ColumnDataType.Items.AddRange(new object[] {
            "Nominal",
            "Ordinal",
            "Binario Simétrico",
            "Binario Asimétrico",
            "Numérico"});
            this.ColumnDataType.Name = "ColumnDataType";
            // 
            // ColumnDomain
            // 
            this.ColumnDomain.HeaderText = "Dominio";
            this.ColumnDomain.Name = "ColumnDomain";
            // 
            // SaveFileAsDATA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 411);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.LabelGeneralInformation);
            this.Controls.Add(this.TextBoxGeneralInformation);
            this.Controls.Add(this.GroupBoxDataBaseDescription);
            this.Name = "SaveFileAsDATA";
            this.Text = "Guardar como DATA";
            this.GroupBoxDataBaseDescription.ResumeLayout(false);
            this.GroupBoxDataBaseDescription.PerformLayout();
            this.GroupBoxAttributes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewAttributes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TextBoxGeneralInformation;
        private System.Windows.Forms.GroupBox GroupBoxDataBaseDescription;
        private System.Windows.Forms.GroupBox GroupBoxAttributes;
        private System.Windows.Forms.TextBox TextBoxRelation;
        private System.Windows.Forms.Label LabelRelation;
        private System.Windows.Forms.Label LabelGeneralInformation;
        private System.Windows.Forms.TextBox TextBoxMissingValue;
        private System.Windows.Forms.Label LabelMissingValue;
        private System.Windows.Forms.DataGridView DataGridViewAttributes;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnDataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDomain;
    }
}