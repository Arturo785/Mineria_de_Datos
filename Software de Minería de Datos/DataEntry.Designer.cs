namespace Software_de_Minería_de_Datos
{
    partial class DataEntry
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
            this.OpenFileDialogDataSet = new System.Windows.Forms.OpenFileDialog();
            this.MenuStripDataEntry = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AttributesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddAttributeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.EditAttributeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.DeleteAttributeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.AttributeInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InstancesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddInstanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataGridViewDataSet = new System.Windows.Forms.DataGridView();
            this.GroupBoxDataSet = new System.Windows.Forms.GroupBox();
            this.LabelDataSetMissingValuesValue = new System.Windows.Forms.Label();
            this.LabelDataSetAttributeQuantityValue = new System.Windows.Forms.Label();
            this.LabelDataSetInstanceQuantityValue = new System.Windows.Forms.Label();
            this.LabelDatasetNameValue = new System.Windows.Forms.Label();
            this.LabelDatasetMissingValues = new System.Windows.Forms.Label();
            this.LabelDatasetAttributeQuantity = new System.Windows.Forms.Label();
            this.LabelDataSetInstanceQuantity = new System.Windows.Forms.Label();
            this.LabelDataSetName = new System.Windows.Forms.Label();
            this.SaveFileDialogDataSet = new System.Windows.Forms.SaveFileDialog();
            this.LabelGeneralInformation = new System.Windows.Forms.Label();
            this.LabelRelation = new System.Windows.Forms.Label();
            this.LabelRelationValue = new System.Windows.Forms.Label();
            this.TextBoxGeneralInformation = new System.Windows.Forms.TextBox();
            this.MenuStripDataEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewDataSet)).BeginInit();
            this.GroupBoxDataSet.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenFileDialogDataSet
            // 
            this.OpenFileDialogDataSet.FileName = "Data Mining File";
            // 
            // MenuStripDataEntry
            // 
            this.MenuStripDataEntry.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.AttributesToolStripMenuItem,
            this.InstancesToolStripMenuItem});
            this.MenuStripDataEntry.Location = new System.Drawing.Point(0, 0);
            this.MenuStripDataEntry.Name = "MenuStripDataEntry";
            this.MenuStripDataEntry.Size = new System.Drawing.Size(944, 24);
            this.MenuStripDataEntry.TabIndex = 1;
            this.MenuStripDataEntry.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadFileToolStripMenuItem,
            this.toolStripSeparator1,
            this.SaveFileToolStripMenuItem,
            this.SaveFileAsToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.FileToolStripMenuItem.Text = "Archivo";
            // 
            // LoadFileToolStripMenuItem
            // 
            this.LoadFileToolStripMenuItem.Name = "LoadFileToolStripMenuItem";
            this.LoadFileToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.LoadFileToolStripMenuItem.Text = "Cargar";
            this.LoadFileToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // SaveFileToolStripMenuItem
            // 
            this.SaveFileToolStripMenuItem.Name = "SaveFileToolStripMenuItem";
            this.SaveFileToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.SaveFileToolStripMenuItem.Text = "Guardar";
            this.SaveFileToolStripMenuItem.Click += new System.EventHandler(this.SaveFileToolStripMenuItem_Click);
            // 
            // SaveFileAsToolStripMenuItem
            // 
            this.SaveFileAsToolStripMenuItem.Name = "SaveFileAsToolStripMenuItem";
            this.SaveFileAsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.SaveFileAsToolStripMenuItem.Text = "Guardar como...";
            this.SaveFileAsToolStripMenuItem.Click += new System.EventHandler(this.SaveFileAsToolStripMenuItem_Click);
            // 
            // AttributesToolStripMenuItem
            // 
            this.AttributesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddAttributeToolStripMenuItem,
            this.toolStripSeparator3,
            this.EditAttributeToolStripMenuItem,
            this.toolStripSeparator4,
            this.DeleteAttributeToolStripMenuItem,
            this.toolStripSeparator5,
            this.AttributeInformationToolStripMenuItem});
            this.AttributesToolStripMenuItem.Name = "AttributesToolStripMenuItem";
            this.AttributesToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.AttributesToolStripMenuItem.Text = "Atributos";
            // 
            // AddAttributeToolStripMenuItem
            // 
            this.AddAttributeToolStripMenuItem.Name = "AddAttributeToolStripMenuItem";
            this.AddAttributeToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.AddAttributeToolStripMenuItem.Text = "Agregar";
            this.AddAttributeToolStripMenuItem.Click += new System.EventHandler(this.AddAttributeToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(136, 6);
            // 
            // EditAttributeToolStripMenuItem
            // 
            this.EditAttributeToolStripMenuItem.Name = "EditAttributeToolStripMenuItem";
            this.EditAttributeToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.EditAttributeToolStripMenuItem.Text = "Editar";
            this.EditAttributeToolStripMenuItem.Click += new System.EventHandler(this.EditAttributeToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(136, 6);
            // 
            // DeleteAttributeToolStripMenuItem
            // 
            this.DeleteAttributeToolStripMenuItem.Name = "DeleteAttributeToolStripMenuItem";
            this.DeleteAttributeToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.DeleteAttributeToolStripMenuItem.Text = "Eliminar";
            this.DeleteAttributeToolStripMenuItem.Click += new System.EventHandler(this.DeleteAttributeToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(136, 6);
            // 
            // AttributeInformationToolStripMenuItem
            // 
            this.AttributeInformationToolStripMenuItem.Name = "AttributeInformationToolStripMenuItem";
            this.AttributeInformationToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.AttributeInformationToolStripMenuItem.Text = "Información";
            this.AttributeInformationToolStripMenuItem.Click += new System.EventHandler(this.AttributeInformationToolStripMenuItem_Click);
            // 
            // InstancesToolStripMenuItem
            // 
            this.InstancesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddInstanceToolStripMenuItem});
            this.InstancesToolStripMenuItem.Name = "InstancesToolStripMenuItem";
            this.InstancesToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.InstancesToolStripMenuItem.Text = "Instancias";
            // 
            // AddInstanceToolStripMenuItem
            // 
            this.AddInstanceToolStripMenuItem.Name = "AddInstanceToolStripMenuItem";
            this.AddInstanceToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.AddInstanceToolStripMenuItem.Text = "Agregar";
            this.AddInstanceToolStripMenuItem.Click += new System.EventHandler(this.AddInstanceToolStripMenuItem_Click);
            // 
            // DataGridViewDataSet
            // 
            this.DataGridViewDataSet.AllowUserToAddRows = false;
            this.DataGridViewDataSet.AllowUserToDeleteRows = false;
            this.DataGridViewDataSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewDataSet.Location = new System.Drawing.Point(12, 149);
            this.DataGridViewDataSet.Name = "DataGridViewDataSet";
            this.DataGridViewDataSet.RowHeadersVisible = false;
            this.DataGridViewDataSet.Size = new System.Drawing.Size(920, 390);
            this.DataGridViewDataSet.TabIndex = 2;
            this.DataGridViewDataSet.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewDataSet_CellContentClick);
            this.DataGridViewDataSet.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewDataSet_CellValueChanged);
            this.DataGridViewDataSet.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DataGridViewDataSet_ColumnAdded);
            // 
            // GroupBoxDataSet
            // 
            this.GroupBoxDataSet.Controls.Add(this.TextBoxGeneralInformation);
            this.GroupBoxDataSet.Controls.Add(this.LabelRelationValue);
            this.GroupBoxDataSet.Controls.Add(this.LabelRelation);
            this.GroupBoxDataSet.Controls.Add(this.LabelGeneralInformation);
            this.GroupBoxDataSet.Controls.Add(this.LabelDataSetMissingValuesValue);
            this.GroupBoxDataSet.Controls.Add(this.LabelDataSetAttributeQuantityValue);
            this.GroupBoxDataSet.Controls.Add(this.LabelDataSetInstanceQuantityValue);
            this.GroupBoxDataSet.Controls.Add(this.LabelDatasetNameValue);
            this.GroupBoxDataSet.Controls.Add(this.LabelDatasetMissingValues);
            this.GroupBoxDataSet.Controls.Add(this.LabelDatasetAttributeQuantity);
            this.GroupBoxDataSet.Controls.Add(this.LabelDataSetInstanceQuantity);
            this.GroupBoxDataSet.Controls.Add(this.LabelDataSetName);
            this.GroupBoxDataSet.Location = new System.Drawing.Point(12, 27);
            this.GroupBoxDataSet.Name = "GroupBoxDataSet";
            this.GroupBoxDataSet.Size = new System.Drawing.Size(920, 116);
            this.GroupBoxDataSet.TabIndex = 3;
            this.GroupBoxDataSet.TabStop = false;
            this.GroupBoxDataSet.Text = "Conjunto de Datos";
            // 
            // LabelDataSetMissingValuesValue
            // 
            this.LabelDataSetMissingValuesValue.AutoSize = true;
            this.LabelDataSetMissingValuesValue.Location = new System.Drawing.Point(93, 90);
            this.LabelDataSetMissingValuesValue.Name = "LabelDataSetMissingValuesValue";
            this.LabelDataSetMissingValuesValue.Size = new System.Drawing.Size(27, 13);
            this.LabelDataSetMissingValuesValue.TabIndex = 7;
            this.LabelDataSetMissingValuesValue.Text = "N/A";
            // 
            // LabelDataSetAttributeQuantityValue
            // 
            this.LabelDataSetAttributeQuantityValue.AutoSize = true;
            this.LabelDataSetAttributeQuantityValue.Location = new System.Drawing.Point(113, 72);
            this.LabelDataSetAttributeQuantityValue.Name = "LabelDataSetAttributeQuantityValue";
            this.LabelDataSetAttributeQuantityValue.Size = new System.Drawing.Size(27, 13);
            this.LabelDataSetAttributeQuantityValue.TabIndex = 6;
            this.LabelDataSetAttributeQuantityValue.Text = "N/A";
            // 
            // LabelDataSetInstanceQuantityValue
            // 
            this.LabelDataSetInstanceQuantityValue.AutoSize = true;
            this.LabelDataSetInstanceQuantityValue.Location = new System.Drawing.Point(120, 55);
            this.LabelDataSetInstanceQuantityValue.Name = "LabelDataSetInstanceQuantityValue";
            this.LabelDataSetInstanceQuantityValue.Size = new System.Drawing.Size(27, 13);
            this.LabelDataSetInstanceQuantityValue.TabIndex = 5;
            this.LabelDataSetInstanceQuantityValue.Text = "N/A";
            // 
            // LabelDatasetNameValue
            // 
            this.LabelDatasetNameValue.AutoSize = true;
            this.LabelDatasetNameValue.Location = new System.Drawing.Point(49, 20);
            this.LabelDatasetNameValue.Name = "LabelDatasetNameValue";
            this.LabelDatasetNameValue.Size = new System.Drawing.Size(27, 13);
            this.LabelDatasetNameValue.TabIndex = 4;
            this.LabelDatasetNameValue.Text = "N/A";
            // 
            // LabelDatasetMissingValues
            // 
            this.LabelDatasetMissingValues.AutoSize = true;
            this.LabelDatasetMissingValues.Location = new System.Drawing.Point(7, 90);
            this.LabelDatasetMissingValues.Name = "LabelDatasetMissingValues";
            this.LabelDatasetMissingValues.Size = new System.Drawing.Size(91, 13);
            this.LabelDatasetMissingValues.TabIndex = 3;
            this.LabelDatasetMissingValues.Text = "Valores Faltantes:";
            // 
            // LabelDatasetAttributeQuantity
            // 
            this.LabelDatasetAttributeQuantity.AutoSize = true;
            this.LabelDatasetAttributeQuantity.Location = new System.Drawing.Point(7, 72);
            this.LabelDatasetAttributeQuantity.Name = "LabelDatasetAttributeQuantity";
            this.LabelDatasetAttributeQuantity.Size = new System.Drawing.Size(111, 13);
            this.LabelDatasetAttributeQuantity.TabIndex = 2;
            this.LabelDatasetAttributeQuantity.Text = "Cantidad de Atributos:";
            // 
            // LabelDataSetInstanceQuantity
            // 
            this.LabelDataSetInstanceQuantity.AutoSize = true;
            this.LabelDataSetInstanceQuantity.Location = new System.Drawing.Point(7, 55);
            this.LabelDataSetInstanceQuantity.Name = "LabelDataSetInstanceQuantity";
            this.LabelDataSetInstanceQuantity.Size = new System.Drawing.Size(118, 13);
            this.LabelDataSetInstanceQuantity.TabIndex = 1;
            this.LabelDataSetInstanceQuantity.Text = "Cantidad de Instancias:";
            // 
            // LabelDataSetName
            // 
            this.LabelDataSetName.AutoSize = true;
            this.LabelDataSetName.Location = new System.Drawing.Point(7, 20);
            this.LabelDataSetName.Name = "LabelDataSetName";
            this.LabelDataSetName.Size = new System.Drawing.Size(47, 13);
            this.LabelDataSetName.TabIndex = 0;
            this.LabelDataSetName.Text = "Nombre:";
            // 
            // LabelGeneralInformation
            // 
            this.LabelGeneralInformation.AutoSize = true;
            this.LabelGeneralInformation.Location = new System.Drawing.Point(296, 20);
            this.LabelGeneralInformation.Name = "LabelGeneralInformation";
            this.LabelGeneralInformation.Size = new System.Drawing.Size(105, 13);
            this.LabelGeneralInformation.TabIndex = 8;
            this.LabelGeneralInformation.Text = "Información General:";
            // 
            // LabelRelation
            // 
            this.LabelRelation.AutoSize = true;
            this.LabelRelation.Location = new System.Drawing.Point(7, 37);
            this.LabelRelation.Name = "LabelRelation";
            this.LabelRelation.Size = new System.Drawing.Size(52, 13);
            this.LabelRelation.TabIndex = 10;
            this.LabelRelation.Text = "Relación:";
            // 
            // LabelRelationValue
            // 
            this.LabelRelationValue.AutoSize = true;
            this.LabelRelationValue.Location = new System.Drawing.Point(54, 37);
            this.LabelRelationValue.Name = "LabelRelationValue";
            this.LabelRelationValue.Size = new System.Drawing.Size(27, 13);
            this.LabelRelationValue.TabIndex = 13;
            this.LabelRelationValue.Text = "N/A";
            // 
            // TextBoxGeneralInformation
            // 
            this.TextBoxGeneralInformation.Enabled = false;
            this.TextBoxGeneralInformation.Location = new System.Drawing.Point(407, 17);
            this.TextBoxGeneralInformation.Multiline = true;
            this.TextBoxGeneralInformation.Name = "TextBoxGeneralInformation";
            this.TextBoxGeneralInformation.Size = new System.Drawing.Size(507, 86);
            this.TextBoxGeneralInformation.TabIndex = 14;
            // 
            // DataEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 551);
            this.Controls.Add(this.GroupBoxDataSet);
            this.Controls.Add(this.DataGridViewDataSet);
            this.Controls.Add(this.MenuStripDataEntry);
            this.MainMenuStrip = this.MenuStripDataEntry;
            this.Name = "DataEntry";
            this.Text = "Entrada de Datos";
            this.MenuStripDataEntry.ResumeLayout(false);
            this.MenuStripDataEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewDataSet)).EndInit();
            this.GroupBoxDataSet.ResumeLayout(false);
            this.GroupBoxDataSet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MenuStripDataEntry;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem SaveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveFileAsToolStripMenuItem;
        private System.Windows.Forms.DataGridView DataGridViewDataSet;
        private System.Windows.Forms.GroupBox GroupBoxDataSet;
        private System.Windows.Forms.Label LabelDatasetAttributeQuantity;
        private System.Windows.Forms.Label LabelDataSetInstanceQuantity;
        private System.Windows.Forms.Label LabelDataSetName;
        private System.Windows.Forms.Label LabelDatasetMissingValues;
        private System.Windows.Forms.Label LabelDatasetNameValue;
        private System.Windows.Forms.Label LabelDataSetMissingValuesValue;
        private System.Windows.Forms.Label LabelDataSetAttributeQuantityValue;
        private System.Windows.Forms.Label LabelDataSetInstanceQuantityValue;
        private System.Windows.Forms.ToolStripMenuItem AttributesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddAttributeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem EditAttributeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem DeleteAttributeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InstancesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddInstanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem AttributeInformationToolStripMenuItem;
        public System.Windows.Forms.OpenFileDialog OpenFileDialogDataSet;
        private System.Windows.Forms.SaveFileDialog SaveFileDialogDataSet;
        private System.Windows.Forms.Label LabelGeneralInformation;
        private System.Windows.Forms.Label LabelRelation;
        private System.Windows.Forms.Label LabelRelationValue;
        private System.Windows.Forms.TextBox TextBoxGeneralInformation;
    }
}