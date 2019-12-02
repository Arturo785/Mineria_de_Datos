namespace Software_de_Minería_de_Datos
{
    partial class CorrectTypographicErrors
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
            this.LabelOutOfDomainValue = new System.Windows.Forms.Label();
            this.TextBoxOutOfDomainValue = new System.Windows.Forms.TextBox();
            this.LabelSuggestion = new System.Windows.Forms.Label();
            this.TextBoxSuggestion = new System.Windows.Forms.TextBox();
            this.ButtonCorrect = new System.Windows.Forms.Button();
            this.ButtonIgnore = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelOutOfDomainValue
            // 
            this.LabelOutOfDomainValue.AutoSize = true;
            this.LabelOutOfDomainValue.Location = new System.Drawing.Point(12, 9);
            this.LabelOutOfDomainValue.Name = "LabelOutOfDomainValue";
            this.LabelOutOfDomainValue.Size = new System.Drawing.Size(122, 13);
            this.LabelOutOfDomainValue.TabIndex = 0;
            this.LabelOutOfDomainValue.Text = "Valor Fuera del Dominio:";
            // 
            // TextBoxOutOfDomainValue
            // 
            this.TextBoxOutOfDomainValue.Enabled = false;
            this.TextBoxOutOfDomainValue.Location = new System.Drawing.Point(12, 25);
            this.TextBoxOutOfDomainValue.Name = "TextBoxOutOfDomainValue";
            this.TextBoxOutOfDomainValue.Size = new System.Drawing.Size(156, 20);
            this.TextBoxOutOfDomainValue.TabIndex = 1;
            // 
            // LabelSuggestion
            // 
            this.LabelSuggestion.AutoSize = true;
            this.LabelSuggestion.Location = new System.Drawing.Point(12, 57);
            this.LabelSuggestion.Name = "LabelSuggestion";
            this.LabelSuggestion.Size = new System.Drawing.Size(64, 13);
            this.LabelSuggestion.TabIndex = 2;
            this.LabelSuggestion.Text = "Sugerencia:";
            // 
            // TextBoxSuggestion
            // 
            this.TextBoxSuggestion.Location = new System.Drawing.Point(12, 73);
            this.TextBoxSuggestion.Name = "TextBoxSuggestion";
            this.TextBoxSuggestion.Size = new System.Drawing.Size(156, 20);
            this.TextBoxSuggestion.TabIndex = 3;
            // 
            // ButtonCorrect
            // 
            this.ButtonCorrect.Location = new System.Drawing.Point(12, 108);
            this.ButtonCorrect.Name = "ButtonCorrect";
            this.ButtonCorrect.Size = new System.Drawing.Size(75, 23);
            this.ButtonCorrect.TabIndex = 4;
            this.ButtonCorrect.Text = "Corregir";
            this.ButtonCorrect.UseVisualStyleBackColor = true;
            this.ButtonCorrect.Click += new System.EventHandler(this.ButtonCorrect_Click);
            // 
            // ButtonIgnore
            // 
            this.ButtonIgnore.Location = new System.Drawing.Point(93, 108);
            this.ButtonIgnore.Name = "ButtonIgnore";
            this.ButtonIgnore.Size = new System.Drawing.Size(75, 23);
            this.ButtonIgnore.TabIndex = 5;
            this.ButtonIgnore.Text = "Omitir";
            this.ButtonIgnore.UseVisualStyleBackColor = true;
            this.ButtonIgnore.Click += new System.EventHandler(this.ButtonIgnore_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(12, 137);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(156, 23);
            this.ButtonCancel.TabIndex = 6;
            this.ButtonCancel.Text = "Cancelar";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // CorrectTypographicErrors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 171);
            this.ControlBox = false;
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonIgnore);
            this.Controls.Add(this.ButtonCorrect);
            this.Controls.Add(this.TextBoxSuggestion);
            this.Controls.Add(this.LabelSuggestion);
            this.Controls.Add(this.TextBoxOutOfDomainValue);
            this.Controls.Add(this.LabelOutOfDomainValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CorrectTypographicErrors";
            this.Text = "Corregir Errores";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelOutOfDomainValue;
        private System.Windows.Forms.TextBox TextBoxOutOfDomainValue;
        private System.Windows.Forms.Label LabelSuggestion;
        private System.Windows.Forms.TextBox TextBoxSuggestion;
        private System.Windows.Forms.Button ButtonCorrect;
        private System.Windows.Forms.Button ButtonIgnore;
        private System.Windows.Forms.Button ButtonCancel;
    }
}