namespace Software_de_Minería_de_Datos
{
    partial class DeleteAttribute
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
            this.LabelAttributes = new System.Windows.Forms.Label();
            this.ListBoxAttributes = new System.Windows.Forms.ListBox();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelAttributes
            // 
            this.LabelAttributes.AutoSize = true;
            this.LabelAttributes.Location = new System.Drawing.Point(12, 9);
            this.LabelAttributes.Name = "LabelAttributes";
            this.LabelAttributes.Size = new System.Drawing.Size(51, 13);
            this.LabelAttributes.TabIndex = 3;
            this.LabelAttributes.Text = "Atributos:";
            // 
            // ListBoxAttributes
            // 
            this.ListBoxAttributes.FormattingEnabled = true;
            this.ListBoxAttributes.Location = new System.Drawing.Point(12, 25);
            this.ListBoxAttributes.Name = "ListBoxAttributes";
            this.ListBoxAttributes.Size = new System.Drawing.Size(156, 186);
            this.ListBoxAttributes.TabIndex = 2;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(93, 217);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 4;
            this.ButtonCancel.Text = "Cancelar";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Location = new System.Drawing.Point(12, 217);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(75, 23);
            this.ButtonDelete.TabIndex = 5;
            this.ButtonDelete.Text = "Eliminar";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // DeleteAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(181, 253);
            this.ControlBox = false;
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.LabelAttributes);
            this.Controls.Add(this.ListBoxAttributes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DeleteAttribute";
            this.Text = "Eliminar Atributo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelAttributes;
        private System.Windows.Forms.ListBox ListBoxAttributes;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonDelete;
    }
}