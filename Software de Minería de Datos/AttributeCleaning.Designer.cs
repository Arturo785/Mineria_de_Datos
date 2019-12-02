namespace Software_de_Minería_de_Datos
{
    partial class AttributeCleaning
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GroupBoxFillMissingValues = new System.Windows.Forms.GroupBox();
            this.ButtonFillMissingValues = new System.Windows.Forms.Button();
            this.RadioButtonMode = new System.Windows.Forms.RadioButton();
            this.RadioButtonMedian = new System.Windows.Forms.RadioButton();
            this.RadioButtonMean = new System.Windows.Forms.RadioButton();
            this.LabelSuggestionValue = new System.Windows.Forms.Label();
            this.LabelSuggestion = new System.Windows.Forms.Label();
            this.GroupBoxDetectionAndCorrectionOfOutliers = new System.Windows.Forms.GroupBox();
            this.ButtonCorrectOutliers = new System.Windows.Forms.Button();
            this.LabelNumberOfOutliersValue = new System.Windows.Forms.Label();
            this.LabelNumbreOfOutliers = new System.Windows.Forms.Label();
            this.CheckBoxShowOutliers = new System.Windows.Forms.CheckBox();
            this.GroupBoxFindAndReplace = new System.Windows.Forms.GroupBox();
            this.ButtonReplaceEverything = new System.Windows.Forms.Button();
            this.TextBoxSearch = new System.Windows.Forms.TextBox();
            this.LabelSearch = new System.Windows.Forms.Label();
            this.TextBoxReplaceWith = new System.Windows.Forms.TextBox();
            this.LabelReplaceWith = new System.Windows.Forms.Label();
            this.GroupBoxDetectionOfTypographicalErrors = new System.Windows.Forms.GroupBox();
            this.ButtonCorrectErrors = new System.Windows.Forms.Button();
            this.CheckBoxShowErrors = new System.Windows.Forms.CheckBox();
            this.LabelNumberOfErrorsValue = new System.Windows.Forms.Label();
            this.LabelNumberOfErrors = new System.Windows.Forms.Label();
            this.GroupBoxDataTransformation = new System.Windows.Forms.GroupBox();
            this.GroupBoxAttributes = new System.Windows.Forms.GroupBox();
            this.ListBoxAttributes = new System.Windows.Forms.ListBox();
            this.LabelAttributeTypeValue = new System.Windows.Forms.Label();
            this.LabelAttributeType = new System.Windows.Forms.Label();
            this.DataGridViewAttribute = new System.Windows.Forms.DataGridView();
            this.GroupBoxMinMax = new System.Windows.Forms.GroupBox();
            this.LabelMinimum = new System.Windows.Forms.Label();
            this.TextBoxMinimum = new System.Windows.Forms.TextBox();
            this.TextBoxMaximum = new System.Windows.Forms.TextBox();
            this.LabelMaximum = new System.Windows.Forms.Label();
            this.TextBoxNewMaximum = new System.Windows.Forms.TextBox();
            this.LabelNewMaximum = new System.Windows.Forms.Label();
            this.TextBoxNewMinimum = new System.Windows.Forms.TextBox();
            this.LabelNewMinimum = new System.Windows.Forms.Label();
            this.ButtonNormalize = new System.Windows.Forms.Button();
            this.RadioButtonMinMax = new System.Windows.Forms.RadioButton();
            this.RadioButtonZScoreStandardDeviation = new System.Windows.Forms.RadioButton();
            this.RadioButtonZScoreMeanAbsoluteDeviation = new System.Windows.Forms.RadioButton();
            this.GroupBoxFillMissingValues.SuspendLayout();
            this.GroupBoxDetectionAndCorrectionOfOutliers.SuspendLayout();
            this.GroupBoxFindAndReplace.SuspendLayout();
            this.GroupBoxDetectionOfTypographicalErrors.SuspendLayout();
            this.GroupBoxDataTransformation.SuspendLayout();
            this.GroupBoxAttributes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewAttribute)).BeginInit();
            this.GroupBoxMinMax.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBoxFillMissingValues
            // 
            this.GroupBoxFillMissingValues.Controls.Add(this.ButtonFillMissingValues);
            this.GroupBoxFillMissingValues.Controls.Add(this.RadioButtonMode);
            this.GroupBoxFillMissingValues.Controls.Add(this.RadioButtonMedian);
            this.GroupBoxFillMissingValues.Controls.Add(this.RadioButtonMean);
            this.GroupBoxFillMissingValues.Controls.Add(this.LabelSuggestionValue);
            this.GroupBoxFillMissingValues.Controls.Add(this.LabelSuggestion);
            this.GroupBoxFillMissingValues.Location = new System.Drawing.Point(218, 13);
            this.GroupBoxFillMissingValues.Name = "GroupBoxFillMissingValues";
            this.GroupBoxFillMissingValues.Size = new System.Drawing.Size(200, 104);
            this.GroupBoxFillMissingValues.TabIndex = 0;
            this.GroupBoxFillMissingValues.TabStop = false;
            this.GroupBoxFillMissingValues.Text = "Llenar Valores Faltantes";
            // 
            // ButtonFillMissingValues
            // 
            this.ButtonFillMissingValues.Location = new System.Drawing.Point(7, 74);
            this.ButtonFillMissingValues.Name = "ButtonFillMissingValues";
            this.ButtonFillMissingValues.Size = new System.Drawing.Size(187, 23);
            this.ButtonFillMissingValues.TabIndex = 12;
            this.ButtonFillMissingValues.Text = "Llenar Valores Faltantes";
            this.ButtonFillMissingValues.UseVisualStyleBackColor = true;
            this.ButtonFillMissingValues.Click += new System.EventHandler(this.ButtonFillMissingValues_Click);
            // 
            // RadioButtonMode
            // 
            this.RadioButtonMode.AutoSize = true;
            this.RadioButtonMode.Location = new System.Drawing.Point(138, 50);
            this.RadioButtonMode.Name = "RadioButtonMode";
            this.RadioButtonMode.Size = new System.Drawing.Size(52, 17);
            this.RadioButtonMode.TabIndex = 11;
            this.RadioButtonMode.Text = "Moda";
            this.RadioButtonMode.UseVisualStyleBackColor = true;
            // 
            // RadioButtonMedian
            // 
            this.RadioButtonMedian.AutoSize = true;
            this.RadioButtonMedian.Location = new System.Drawing.Point(66, 50);
            this.RadioButtonMedian.Name = "RadioButtonMedian";
            this.RadioButtonMedian.Size = new System.Drawing.Size(66, 17);
            this.RadioButtonMedian.TabIndex = 10;
            this.RadioButtonMedian.Text = "Mediana";
            this.RadioButtonMedian.UseVisualStyleBackColor = true;
            // 
            // RadioButtonMean
            // 
            this.RadioButtonMean.AutoSize = true;
            this.RadioButtonMean.Checked = true;
            this.RadioButtonMean.Location = new System.Drawing.Point(6, 50);
            this.RadioButtonMean.Name = "RadioButtonMean";
            this.RadioButtonMean.Size = new System.Drawing.Size(54, 17);
            this.RadioButtonMean.TabIndex = 9;
            this.RadioButtonMean.TabStop = true;
            this.RadioButtonMean.Text = "Media";
            this.RadioButtonMean.UseVisualStyleBackColor = true;
            // 
            // LabelSuggestionValue
            // 
            this.LabelSuggestionValue.AutoSize = true;
            this.LabelSuggestionValue.Location = new System.Drawing.Point(65, 25);
            this.LabelSuggestionValue.Name = "LabelSuggestionValue";
            this.LabelSuggestionValue.Size = new System.Drawing.Size(27, 13);
            this.LabelSuggestionValue.TabIndex = 8;
            this.LabelSuggestionValue.Text = "N/A";
            // 
            // LabelSuggestion
            // 
            this.LabelSuggestion.AutoSize = true;
            this.LabelSuggestion.Location = new System.Drawing.Point(6, 25);
            this.LabelSuggestion.Name = "LabelSuggestion";
            this.LabelSuggestion.Size = new System.Drawing.Size(64, 13);
            this.LabelSuggestion.TabIndex = 7;
            this.LabelSuggestion.Text = "Sugerencia:";
            // 
            // GroupBoxDetectionAndCorrectionOfOutliers
            // 
            this.GroupBoxDetectionAndCorrectionOfOutliers.Controls.Add(this.ButtonCorrectOutliers);
            this.GroupBoxDetectionAndCorrectionOfOutliers.Controls.Add(this.LabelNumberOfOutliersValue);
            this.GroupBoxDetectionAndCorrectionOfOutliers.Controls.Add(this.LabelNumbreOfOutliers);
            this.GroupBoxDetectionAndCorrectionOfOutliers.Controls.Add(this.CheckBoxShowOutliers);
            this.GroupBoxDetectionAndCorrectionOfOutliers.Location = new System.Drawing.Point(218, 123);
            this.GroupBoxDetectionAndCorrectionOfOutliers.Name = "GroupBoxDetectionAndCorrectionOfOutliers";
            this.GroupBoxDetectionAndCorrectionOfOutliers.Size = new System.Drawing.Size(200, 104);
            this.GroupBoxDetectionAndCorrectionOfOutliers.TabIndex = 1;
            this.GroupBoxDetectionAndCorrectionOfOutliers.TabStop = false;
            this.GroupBoxDetectionAndCorrectionOfOutliers.Text = "Detección y Corrección de Outliers";
            // 
            // ButtonCorrectOutliers
            // 
            this.ButtonCorrectOutliers.Location = new System.Drawing.Point(6, 74);
            this.ButtonCorrectOutliers.Name = "ButtonCorrectOutliers";
            this.ButtonCorrectOutliers.Size = new System.Drawing.Size(188, 23);
            this.ButtonCorrectOutliers.TabIndex = 7;
            this.ButtonCorrectOutliers.Text = "Corregir Outliers";
            this.ButtonCorrectOutliers.UseVisualStyleBackColor = true;
            this.ButtonCorrectOutliers.Click += new System.EventHandler(this.ButtonCorrectOutliers_Click);
            // 
            // LabelNumberOfOutliersValue
            // 
            this.LabelNumberOfOutliersValue.AutoSize = true;
            this.LabelNumberOfOutliersValue.Location = new System.Drawing.Point(101, 25);
            this.LabelNumberOfOutliersValue.Name = "LabelNumberOfOutliersValue";
            this.LabelNumberOfOutliersValue.Size = new System.Drawing.Size(27, 13);
            this.LabelNumberOfOutliersValue.TabIndex = 13;
            this.LabelNumberOfOutliersValue.Text = "N/A";
            // 
            // LabelNumbreOfOutliers
            // 
            this.LabelNumbreOfOutliers.AutoSize = true;
            this.LabelNumbreOfOutliers.Location = new System.Drawing.Point(6, 25);
            this.LabelNumbreOfOutliers.Name = "LabelNumbreOfOutliers";
            this.LabelNumbreOfOutliers.Size = new System.Drawing.Size(100, 13);
            this.LabelNumbreOfOutliers.TabIndex = 1;
            this.LabelNumbreOfOutliers.Text = "Número de Outliers:";
            // 
            // CheckBoxShowOutliers
            // 
            this.CheckBoxShowOutliers.AutoSize = true;
            this.CheckBoxShowOutliers.Location = new System.Drawing.Point(6, 51);
            this.CheckBoxShowOutliers.Name = "CheckBoxShowOutliers";
            this.CheckBoxShowOutliers.Size = new System.Drawing.Size(99, 17);
            this.CheckBoxShowOutliers.TabIndex = 0;
            this.CheckBoxShowOutliers.Text = "Mostrar Outliers";
            this.CheckBoxShowOutliers.UseVisualStyleBackColor = true;
            this.CheckBoxShowOutliers.CheckedChanged += new System.EventHandler(this.CheckBoxShowOutliers_CheckedChanged);
            // 
            // GroupBoxFindAndReplace
            // 
            this.GroupBoxFindAndReplace.Controls.Add(this.ButtonReplaceEverything);
            this.GroupBoxFindAndReplace.Controls.Add(this.TextBoxSearch);
            this.GroupBoxFindAndReplace.Controls.Add(this.LabelSearch);
            this.GroupBoxFindAndReplace.Controls.Add(this.TextBoxReplaceWith);
            this.GroupBoxFindAndReplace.Controls.Add(this.LabelReplaceWith);
            this.GroupBoxFindAndReplace.Location = new System.Drawing.Point(218, 233);
            this.GroupBoxFindAndReplace.Name = "GroupBoxFindAndReplace";
            this.GroupBoxFindAndReplace.Size = new System.Drawing.Size(200, 138);
            this.GroupBoxFindAndReplace.TabIndex = 2;
            this.GroupBoxFindAndReplace.TabStop = false;
            this.GroupBoxFindAndReplace.Text = "Buscar y Reemplazar";
            // 
            // ButtonReplaceEverything
            // 
            this.ButtonReplaceEverything.Location = new System.Drawing.Point(6, 111);
            this.ButtonReplaceEverything.Name = "ButtonReplaceEverything";
            this.ButtonReplaceEverything.Size = new System.Drawing.Size(188, 23);
            this.ButtonReplaceEverything.TabIndex = 4;
            this.ButtonReplaceEverything.Text = "Reemplazar Todo";
            this.ButtonReplaceEverything.UseVisualStyleBackColor = true;
            this.ButtonReplaceEverything.Click += new System.EventHandler(this.ButtonReplaceEverything_Click);
            // 
            // TextBoxSearch
            // 
            this.TextBoxSearch.Location = new System.Drawing.Point(6, 37);
            this.TextBoxSearch.Name = "TextBoxSearch";
            this.TextBoxSearch.Size = new System.Drawing.Size(188, 20);
            this.TextBoxSearch.TabIndex = 1;
            // 
            // LabelSearch
            // 
            this.LabelSearch.AutoSize = true;
            this.LabelSearch.Location = new System.Drawing.Point(6, 21);
            this.LabelSearch.Name = "LabelSearch";
            this.LabelSearch.Size = new System.Drawing.Size(43, 13);
            this.LabelSearch.TabIndex = 0;
            this.LabelSearch.Text = "Buscar:";
            // 
            // TextBoxReplaceWith
            // 
            this.TextBoxReplaceWith.Location = new System.Drawing.Point(6, 85);
            this.TextBoxReplaceWith.Name = "TextBoxReplaceWith";
            this.TextBoxReplaceWith.Size = new System.Drawing.Size(188, 20);
            this.TextBoxReplaceWith.TabIndex = 3;
            // 
            // LabelReplaceWith
            // 
            this.LabelReplaceWith.AutoSize = true;
            this.LabelReplaceWith.Location = new System.Drawing.Point(6, 69);
            this.LabelReplaceWith.Name = "LabelReplaceWith";
            this.LabelReplaceWith.Size = new System.Drawing.Size(87, 13);
            this.LabelReplaceWith.TabIndex = 2;
            this.LabelReplaceWith.Text = "Reemplazar con:";
            // 
            // GroupBoxDetectionOfTypographicalErrors
            // 
            this.GroupBoxDetectionOfTypographicalErrors.Controls.Add(this.ButtonCorrectErrors);
            this.GroupBoxDetectionOfTypographicalErrors.Controls.Add(this.CheckBoxShowErrors);
            this.GroupBoxDetectionOfTypographicalErrors.Controls.Add(this.LabelNumberOfErrorsValue);
            this.GroupBoxDetectionOfTypographicalErrors.Controls.Add(this.LabelNumberOfErrors);
            this.GroupBoxDetectionOfTypographicalErrors.Location = new System.Drawing.Point(218, 377);
            this.GroupBoxDetectionOfTypographicalErrors.Name = "GroupBoxDetectionOfTypographicalErrors";
            this.GroupBoxDetectionOfTypographicalErrors.Size = new System.Drawing.Size(200, 107);
            this.GroupBoxDetectionOfTypographicalErrors.TabIndex = 3;
            this.GroupBoxDetectionOfTypographicalErrors.TabStop = false;
            this.GroupBoxDetectionOfTypographicalErrors.Text = "Detección de Errores Tipográficos";
            // 
            // ButtonCorrectErrors
            // 
            this.ButtonCorrectErrors.Location = new System.Drawing.Point(6, 73);
            this.ButtonCorrectErrors.Name = "ButtonCorrectErrors";
            this.ButtonCorrectErrors.Size = new System.Drawing.Size(188, 23);
            this.ButtonCorrectErrors.TabIndex = 16;
            this.ButtonCorrectErrors.Text = "Corregir Errores";
            this.ButtonCorrectErrors.UseVisualStyleBackColor = true;
            this.ButtonCorrectErrors.Click += new System.EventHandler(this.ButtonCorrectErrors_Click);
            // 
            // CheckBoxShowErrors
            // 
            this.CheckBoxShowErrors.AutoSize = true;
            this.CheckBoxShowErrors.Location = new System.Drawing.Point(6, 50);
            this.CheckBoxShowErrors.Name = "CheckBoxShowErrors";
            this.CheckBoxShowErrors.Size = new System.Drawing.Size(97, 17);
            this.CheckBoxShowErrors.TabIndex = 14;
            this.CheckBoxShowErrors.Text = "Mostrar Errores";
            this.CheckBoxShowErrors.UseVisualStyleBackColor = true;
            this.CheckBoxShowErrors.CheckedChanged += new System.EventHandler(this.CheckBoxShowErrors_CheckedChanged);
            // 
            // LabelNumberOfErrorsValue
            // 
            this.LabelNumberOfErrorsValue.AutoSize = true;
            this.LabelNumberOfErrorsValue.Location = new System.Drawing.Point(101, 25);
            this.LabelNumberOfErrorsValue.Name = "LabelNumberOfErrorsValue";
            this.LabelNumberOfErrorsValue.Size = new System.Drawing.Size(27, 13);
            this.LabelNumberOfErrorsValue.TabIndex = 15;
            this.LabelNumberOfErrorsValue.Text = "N/A";
            // 
            // LabelNumberOfErrors
            // 
            this.LabelNumberOfErrors.AutoSize = true;
            this.LabelNumberOfErrors.Location = new System.Drawing.Point(6, 25);
            this.LabelNumberOfErrors.Name = "LabelNumberOfErrors";
            this.LabelNumberOfErrors.Size = new System.Drawing.Size(98, 13);
            this.LabelNumberOfErrors.TabIndex = 14;
            this.LabelNumberOfErrors.Text = "Número de Errores:";
            // 
            // GroupBoxDataTransformation
            // 
            this.GroupBoxDataTransformation.Controls.Add(this.RadioButtonZScoreMeanAbsoluteDeviation);
            this.GroupBoxDataTransformation.Controls.Add(this.ButtonNormalize);
            this.GroupBoxDataTransformation.Controls.Add(this.RadioButtonZScoreStandardDeviation);
            this.GroupBoxDataTransformation.Controls.Add(this.RadioButtonMinMax);
            this.GroupBoxDataTransformation.Controls.Add(this.GroupBoxMinMax);
            this.GroupBoxDataTransformation.Location = new System.Drawing.Point(424, 14);
            this.GroupBoxDataTransformation.Name = "GroupBoxDataTransformation";
            this.GroupBoxDataTransformation.Size = new System.Drawing.Size(209, 337);
            this.GroupBoxDataTransformation.TabIndex = 4;
            this.GroupBoxDataTransformation.TabStop = false;
            this.GroupBoxDataTransformation.Text = "Transformación de Datos";
            // 
            // GroupBoxAttributes
            // 
            this.GroupBoxAttributes.Controls.Add(this.ListBoxAttributes);
            this.GroupBoxAttributes.Controls.Add(this.LabelAttributeTypeValue);
            this.GroupBoxAttributes.Controls.Add(this.LabelAttributeType);
            this.GroupBoxAttributes.Location = new System.Drawing.Point(12, 12);
            this.GroupBoxAttributes.Name = "GroupBoxAttributes";
            this.GroupBoxAttributes.Size = new System.Drawing.Size(200, 472);
            this.GroupBoxAttributes.TabIndex = 6;
            this.GroupBoxAttributes.TabStop = false;
            this.GroupBoxAttributes.Text = "Atributos";
            // 
            // ListBoxAttributes
            // 
            this.ListBoxAttributes.FormattingEnabled = true;
            this.ListBoxAttributes.Location = new System.Drawing.Point(6, 54);
            this.ListBoxAttributes.Name = "ListBoxAttributes";
            this.ListBoxAttributes.Size = new System.Drawing.Size(188, 407);
            this.ListBoxAttributes.TabIndex = 6;
            this.ListBoxAttributes.SelectedIndexChanged += new System.EventHandler(this.ListBoxAttributes_SelectedIndexChanged);
            // 
            // LabelAttributeTypeValue
            // 
            this.LabelAttributeTypeValue.AutoSize = true;
            this.LabelAttributeTypeValue.Location = new System.Drawing.Point(32, 25);
            this.LabelAttributeTypeValue.Name = "LabelAttributeTypeValue";
            this.LabelAttributeTypeValue.Size = new System.Drawing.Size(27, 13);
            this.LabelAttributeTypeValue.TabIndex = 5;
            this.LabelAttributeTypeValue.Text = "N/A";
            // 
            // LabelAttributeType
            // 
            this.LabelAttributeType.AutoSize = true;
            this.LabelAttributeType.Location = new System.Drawing.Point(6, 25);
            this.LabelAttributeType.Name = "LabelAttributeType";
            this.LabelAttributeType.Size = new System.Drawing.Size(31, 13);
            this.LabelAttributeType.TabIndex = 4;
            this.LabelAttributeType.Text = "Tipo:";
            // 
            // DataGridViewAttribute
            // 
            this.DataGridViewAttribute.AllowUserToAddRows = false;
            this.DataGridViewAttribute.AllowUserToDeleteRows = false;
            this.DataGridViewAttribute.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewAttribute.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridViewAttribute.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewAttribute.Location = new System.Drawing.Point(639, 12);
            this.DataGridViewAttribute.Name = "DataGridViewAttribute";
            this.DataGridViewAttribute.ReadOnly = true;
            this.DataGridViewAttribute.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DataGridViewAttribute.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DataGridViewAttribute.Size = new System.Drawing.Size(253, 472);
            this.DataGridViewAttribute.TabIndex = 7;
            this.DataGridViewAttribute.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DataGridViewAttribute_ColumnAdded);
            // 
            // GroupBoxMinMax
            // 
            this.GroupBoxMinMax.Controls.Add(this.TextBoxNewMaximum);
            this.GroupBoxMinMax.Controls.Add(this.LabelNewMaximum);
            this.GroupBoxMinMax.Controls.Add(this.TextBoxNewMinimum);
            this.GroupBoxMinMax.Controls.Add(this.LabelNewMinimum);
            this.GroupBoxMinMax.Controls.Add(this.TextBoxMaximum);
            this.GroupBoxMinMax.Controls.Add(this.LabelMaximum);
            this.GroupBoxMinMax.Controls.Add(this.TextBoxMinimum);
            this.GroupBoxMinMax.Controls.Add(this.LabelMinimum);
            this.GroupBoxMinMax.Location = new System.Drawing.Point(6, 95);
            this.GroupBoxMinMax.Name = "GroupBoxMinMax";
            this.GroupBoxMinMax.Size = new System.Drawing.Size(197, 206);
            this.GroupBoxMinMax.TabIndex = 0;
            this.GroupBoxMinMax.TabStop = false;
            this.GroupBoxMinMax.Text = "Min-Max";
            // 
            // LabelMinimum
            // 
            this.LabelMinimum.AutoSize = true;
            this.LabelMinimum.Location = new System.Drawing.Point(6, 29);
            this.LabelMinimum.Name = "LabelMinimum";
            this.LabelMinimum.Size = new System.Drawing.Size(45, 13);
            this.LabelMinimum.TabIndex = 1;
            this.LabelMinimum.Text = "Mínimo:";
            // 
            // TextBoxMinimum
            // 
            this.TextBoxMinimum.Location = new System.Drawing.Point(6, 45);
            this.TextBoxMinimum.Name = "TextBoxMinimum";
            this.TextBoxMinimum.Size = new System.Drawing.Size(185, 20);
            this.TextBoxMinimum.TabIndex = 2;
            // 
            // TextBoxMaximum
            // 
            this.TextBoxMaximum.Location = new System.Drawing.Point(6, 84);
            this.TextBoxMaximum.Name = "TextBoxMaximum";
            this.TextBoxMaximum.Size = new System.Drawing.Size(185, 20);
            this.TextBoxMaximum.TabIndex = 4;
            // 
            // LabelMaximum
            // 
            this.LabelMaximum.AutoSize = true;
            this.LabelMaximum.Location = new System.Drawing.Point(6, 68);
            this.LabelMaximum.Name = "LabelMaximum";
            this.LabelMaximum.Size = new System.Drawing.Size(46, 13);
            this.LabelMaximum.TabIndex = 3;
            this.LabelMaximum.Text = "Máximo:";
            // 
            // TextBoxNewMaximum
            // 
            this.TextBoxNewMaximum.Location = new System.Drawing.Point(6, 178);
            this.TextBoxNewMaximum.Name = "TextBoxNewMaximum";
            this.TextBoxNewMaximum.Size = new System.Drawing.Size(185, 20);
            this.TextBoxNewMaximum.TabIndex = 8;
            // 
            // LabelNewMaximum
            // 
            this.LabelNewMaximum.AutoSize = true;
            this.LabelNewMaximum.Location = new System.Drawing.Point(6, 162);
            this.LabelNewMaximum.Name = "LabelNewMaximum";
            this.LabelNewMaximum.Size = new System.Drawing.Size(81, 13);
            this.LabelNewMaximum.TabIndex = 7;
            this.LabelNewMaximum.Text = "Nuevo Máximo:";
            // 
            // TextBoxNewMinimum
            // 
            this.TextBoxNewMinimum.Location = new System.Drawing.Point(6, 139);
            this.TextBoxNewMinimum.Name = "TextBoxNewMinimum";
            this.TextBoxNewMinimum.Size = new System.Drawing.Size(185, 20);
            this.TextBoxNewMinimum.TabIndex = 6;
            // 
            // LabelNewMinimum
            // 
            this.LabelNewMinimum.AutoSize = true;
            this.LabelNewMinimum.Location = new System.Drawing.Point(6, 123);
            this.LabelNewMinimum.Name = "LabelNewMinimum";
            this.LabelNewMinimum.Size = new System.Drawing.Size(80, 13);
            this.LabelNewMinimum.TabIndex = 5;
            this.LabelNewMinimum.Text = "Nuevo Mínimo:";
            // 
            // ButtonNormalize
            // 
            this.ButtonNormalize.Location = new System.Drawing.Point(6, 307);
            this.ButtonNormalize.Name = "ButtonNormalize";
            this.ButtonNormalize.Size = new System.Drawing.Size(197, 23);
            this.ButtonNormalize.TabIndex = 9;
            this.ButtonNormalize.Text = "Normalizar";
            this.ButtonNormalize.UseVisualStyleBackColor = true;
            this.ButtonNormalize.Click += new System.EventHandler(this.ButtonNormalize_Click);
            // 
            // RadioButtonMinMax
            // 
            this.RadioButtonMinMax.AutoSize = true;
            this.RadioButtonMinMax.Location = new System.Drawing.Point(6, 70);
            this.RadioButtonMinMax.Name = "RadioButtonMinMax";
            this.RadioButtonMinMax.Size = new System.Drawing.Size(65, 17);
            this.RadioButtonMinMax.TabIndex = 9;
            this.RadioButtonMinMax.TabStop = true;
            this.RadioButtonMinMax.Text = "Min-Max";
            this.RadioButtonMinMax.UseVisualStyleBackColor = true;
            this.RadioButtonMinMax.CheckedChanged += new System.EventHandler(this.RadioButtonMinMax_CheckedChanged);
            // 
            // RadioButtonZScoreStandardDeviation
            // 
            this.RadioButtonZScoreStandardDeviation.AutoSize = true;
            this.RadioButtonZScoreStandardDeviation.Location = new System.Drawing.Point(6, 24);
            this.RadioButtonZScoreStandardDeviation.Name = "RadioButtonZScoreStandardDeviation";
            this.RadioButtonZScoreStandardDeviation.Size = new System.Drawing.Size(170, 17);
            this.RadioButtonZScoreStandardDeviation.TabIndex = 0;
            this.RadioButtonZScoreStandardDeviation.TabStop = true;
            this.RadioButtonZScoreStandardDeviation.Text = "Z-Score (Desviación Estándar)";
            this.RadioButtonZScoreStandardDeviation.UseVisualStyleBackColor = true;
            // 
            // RadioButtonZScoreMeanAbsoluteDeviation
            // 
            this.RadioButtonZScoreMeanAbsoluteDeviation.AutoSize = true;
            this.RadioButtonZScoreMeanAbsoluteDeviation.Location = new System.Drawing.Point(6, 47);
            this.RadioButtonZScoreMeanAbsoluteDeviation.Name = "RadioButtonZScoreMeanAbsoluteDeviation";
            this.RadioButtonZScoreMeanAbsoluteDeviation.Size = new System.Drawing.Size(201, 17);
            this.RadioButtonZScoreMeanAbsoluteDeviation.TabIndex = 1;
            this.RadioButtonZScoreMeanAbsoluteDeviation.TabStop = true;
            this.RadioButtonZScoreMeanAbsoluteDeviation.Text = "Z-Score (Desviación Media Absoluta)";
            this.RadioButtonZScoreMeanAbsoluteDeviation.UseVisualStyleBackColor = true;
            // 
            // AttributeCleaning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 496);
            this.Controls.Add(this.DataGridViewAttribute);
            this.Controls.Add(this.GroupBoxFindAndReplace);
            this.Controls.Add(this.GroupBoxAttributes);
            this.Controls.Add(this.GroupBoxDataTransformation);
            this.Controls.Add(this.GroupBoxDetectionOfTypographicalErrors);
            this.Controls.Add(this.GroupBoxDetectionAndCorrectionOfOutliers);
            this.Controls.Add(this.GroupBoxFillMissingValues);
            this.Name = "AttributeCleaning";
            this.Text = "Limpieza de Atributos";
            this.GroupBoxFillMissingValues.ResumeLayout(false);
            this.GroupBoxFillMissingValues.PerformLayout();
            this.GroupBoxDetectionAndCorrectionOfOutliers.ResumeLayout(false);
            this.GroupBoxDetectionAndCorrectionOfOutliers.PerformLayout();
            this.GroupBoxFindAndReplace.ResumeLayout(false);
            this.GroupBoxFindAndReplace.PerformLayout();
            this.GroupBoxDetectionOfTypographicalErrors.ResumeLayout(false);
            this.GroupBoxDetectionOfTypographicalErrors.PerformLayout();
            this.GroupBoxDataTransformation.ResumeLayout(false);
            this.GroupBoxDataTransformation.PerformLayout();
            this.GroupBoxAttributes.ResumeLayout(false);
            this.GroupBoxAttributes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewAttribute)).EndInit();
            this.GroupBoxMinMax.ResumeLayout(false);
            this.GroupBoxMinMax.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxFillMissingValues;
        private System.Windows.Forms.GroupBox GroupBoxDetectionAndCorrectionOfOutliers;
        private System.Windows.Forms.GroupBox GroupBoxFindAndReplace;
        private System.Windows.Forms.GroupBox GroupBoxDetectionOfTypographicalErrors;
        private System.Windows.Forms.GroupBox GroupBoxDataTransformation;
        private System.Windows.Forms.GroupBox GroupBoxAttributes;
        private System.Windows.Forms.Label LabelAttributeTypeValue;
        private System.Windows.Forms.Label LabelAttributeType;
        private System.Windows.Forms.Label LabelSuggestion;
        private System.Windows.Forms.ListBox ListBoxAttributes;
        private System.Windows.Forms.Button ButtonFillMissingValues;
        private System.Windows.Forms.RadioButton RadioButtonMode;
        private System.Windows.Forms.RadioButton RadioButtonMedian;
        private System.Windows.Forms.RadioButton RadioButtonMean;
        private System.Windows.Forms.Label LabelSuggestionValue;
        private System.Windows.Forms.Button ButtonCorrectOutliers;
        private System.Windows.Forms.Label LabelNumberOfOutliersValue;
        private System.Windows.Forms.Label LabelNumbreOfOutliers;
        private System.Windows.Forms.CheckBox CheckBoxShowOutliers;
        private System.Windows.Forms.TextBox TextBoxSearch;
        private System.Windows.Forms.Label LabelSearch;
        private System.Windows.Forms.Label LabelReplaceWith;
        private System.Windows.Forms.TextBox TextBoxReplaceWith;
        private System.Windows.Forms.Button ButtonReplaceEverything;
        private System.Windows.Forms.DataGridView DataGridViewAttribute;
        private System.Windows.Forms.Button ButtonCorrectErrors;
        private System.Windows.Forms.CheckBox CheckBoxShowErrors;
        private System.Windows.Forms.Label LabelNumberOfErrorsValue;
        private System.Windows.Forms.Label LabelNumberOfErrors;
        private System.Windows.Forms.RadioButton RadioButtonZScoreMeanAbsoluteDeviation;
        private System.Windows.Forms.RadioButton RadioButtonZScoreStandardDeviation;
        private System.Windows.Forms.Button ButtonNormalize;
        private System.Windows.Forms.GroupBox GroupBoxMinMax;
        private System.Windows.Forms.RadioButton RadioButtonMinMax;
        private System.Windows.Forms.TextBox TextBoxNewMaximum;
        private System.Windows.Forms.Label LabelNewMaximum;
        private System.Windows.Forms.TextBox TextBoxNewMinimum;
        private System.Windows.Forms.Label LabelNewMinimum;
        private System.Windows.Forms.TextBox TextBoxMaximum;
        private System.Windows.Forms.Label LabelMaximum;
        private System.Windows.Forms.TextBox TextBoxMinimum;
        private System.Windows.Forms.Label LabelMinimum;
    }
}