﻿namespace Software_de_Minería_de_Datos
{
    partial class MachineLearningAlgorithms
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
            this.GroupBoxAlgorithms = new System.Windows.Forms.GroupBox();
            this.ComboBoxAlgorithms = new System.Windows.Forms.ComboBox();
            this.GroupBoxValidationMethodologies = new System.Windows.Forms.GroupBox();
            this.GroupBoxKFoldCrossValidation = new System.Windows.Forms.GroupBox();
            this.NumericUpDownKFoldCrossValidationKValue = new System.Windows.Forms.NumericUpDown();
            this.LabelKFoldCrossValidationKValue = new System.Windows.Forms.Label();
            this.GroupBoxHoldOut = new System.Windows.Forms.GroupBox();
            this.NumericUpDownPercentageTrainingSet = new System.Windows.Forms.NumericUpDown();
            this.LabelPercentageTrainingSet = new System.Windows.Forms.Label();
            this.RadioButtonKFoldCrossValidation = new System.Windows.Forms.RadioButton();
            this.RadioButtonHoldOut = new System.Windows.Forms.RadioButton();
            this.GroupBoxClassAttribute = new System.Windows.Forms.GroupBox();
            this.LabelTypeValue = new System.Windows.Forms.Label();
            this.LabelType = new System.Windows.Forms.Label();
            this.ComboBoxClassAttribute = new System.Windows.Forms.ComboBox();
            this.PanelMachineLearningAlgorithm = new System.Windows.Forms.Panel();
            this.ButtonTrainAlgorithm = new System.Windows.Forms.Button();
            this.GroupBoxEvaluation = new System.Windows.Forms.GroupBox();
            this.GroupBoxRegression = new System.Windows.Forms.GroupBox();
            this.LabelMeanSquaredErrorValue = new System.Windows.Forms.Label();
            this.LabelMeanSquaredError = new System.Windows.Forms.Label();
            this.GroupBoxClassification = new System.Windows.Forms.GroupBox();
            this.LabelAccuracyValue = new System.Windows.Forms.Label();
            this.LabelAccuracy = new System.Windows.Forms.Label();
            this.GroupBoxKMeansAndKNearestNeighbors = new System.Windows.Forms.GroupBox();
            this.NumericUpDownKMeansAndKNearestNeighborsKValue = new System.Windows.Forms.NumericUpDown();
            this.LabelKMeansAndKNearestNeighborsKValue = new System.Windows.Forms.Label();
            this.GroupBoxAlgorithms.SuspendLayout();
            this.GroupBoxValidationMethodologies.SuspendLayout();
            this.GroupBoxKFoldCrossValidation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownKFoldCrossValidationKValue)).BeginInit();
            this.GroupBoxHoldOut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownPercentageTrainingSet)).BeginInit();
            this.GroupBoxClassAttribute.SuspendLayout();
            this.GroupBoxEvaluation.SuspendLayout();
            this.GroupBoxRegression.SuspendLayout();
            this.GroupBoxClassification.SuspendLayout();
            this.GroupBoxKMeansAndKNearestNeighbors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownKMeansAndKNearestNeighborsKValue)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBoxAlgorithms
            // 
            this.GroupBoxAlgorithms.Controls.Add(this.ComboBoxAlgorithms);
            this.GroupBoxAlgorithms.Location = new System.Drawing.Point(12, 78);
            this.GroupBoxAlgorithms.Name = "GroupBoxAlgorithms";
            this.GroupBoxAlgorithms.Size = new System.Drawing.Size(237, 51);
            this.GroupBoxAlgorithms.TabIndex = 0;
            this.GroupBoxAlgorithms.TabStop = false;
            this.GroupBoxAlgorithms.Text = "Algoritmos";
            // 
            // ComboBoxAlgorithms
            // 
            this.ComboBoxAlgorithms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxAlgorithms.FormattingEnabled = true;
            this.ComboBoxAlgorithms.Items.AddRange(new object[] {
            "Zero-R",
            "One-R",
            "Naive-Bayes",
            "K-Means",
            "K-Nearest Neighbors"});
            this.ComboBoxAlgorithms.Location = new System.Drawing.Point(6, 19);
            this.ComboBoxAlgorithms.Name = "ComboBoxAlgorithms";
            this.ComboBoxAlgorithms.Size = new System.Drawing.Size(225, 21);
            this.ComboBoxAlgorithms.TabIndex = 1;
            this.ComboBoxAlgorithms.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAlgorithms_SelectedIndexChanged);
            // 
            // GroupBoxValidationMethodologies
            // 
            this.GroupBoxValidationMethodologies.Controls.Add(this.GroupBoxKFoldCrossValidation);
            this.GroupBoxValidationMethodologies.Controls.Add(this.GroupBoxHoldOut);
            this.GroupBoxValidationMethodologies.Controls.Add(this.RadioButtonKFoldCrossValidation);
            this.GroupBoxValidationMethodologies.Controls.Add(this.RadioButtonHoldOut);
            this.GroupBoxValidationMethodologies.Location = new System.Drawing.Point(12, 201);
            this.GroupBoxValidationMethodologies.Name = "GroupBoxValidationMethodologies";
            this.GroupBoxValidationMethodologies.Size = new System.Drawing.Size(237, 198);
            this.GroupBoxValidationMethodologies.TabIndex = 1;
            this.GroupBoxValidationMethodologies.TabStop = false;
            this.GroupBoxValidationMethodologies.Text = "Metodologías de Validación";
            // 
            // GroupBoxKFoldCrossValidation
            // 
            this.GroupBoxKFoldCrossValidation.Controls.Add(this.NumericUpDownKFoldCrossValidationKValue);
            this.GroupBoxKFoldCrossValidation.Controls.Add(this.LabelKFoldCrossValidationKValue);
            this.GroupBoxKFoldCrossValidation.Location = new System.Drawing.Point(6, 133);
            this.GroupBoxKFoldCrossValidation.Name = "GroupBoxKFoldCrossValidation";
            this.GroupBoxKFoldCrossValidation.Size = new System.Drawing.Size(225, 59);
            this.GroupBoxKFoldCrossValidation.TabIndex = 2;
            this.GroupBoxKFoldCrossValidation.TabStop = false;
            this.GroupBoxKFoldCrossValidation.Text = "K-Fold Cross Validation";
            // 
            // NumericUpDownKFoldCrossValidationKValue
            // 
            this.NumericUpDownKFoldCrossValidationKValue.Location = new System.Drawing.Point(6, 32);
            this.NumericUpDownKFoldCrossValidationKValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownKFoldCrossValidationKValue.Name = "NumericUpDownKFoldCrossValidationKValue";
            this.NumericUpDownKFoldCrossValidationKValue.Size = new System.Drawing.Size(213, 20);
            this.NumericUpDownKFoldCrossValidationKValue.TabIndex = 3;
            this.NumericUpDownKFoldCrossValidationKValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LabelKFoldCrossValidationKValue
            // 
            this.LabelKFoldCrossValidationKValue.AutoSize = true;
            this.LabelKFoldCrossValidationKValue.Location = new System.Drawing.Point(6, 16);
            this.LabelKFoldCrossValidationKValue.Name = "LabelKFoldCrossValidationKValue";
            this.LabelKFoldCrossValidationKValue.Size = new System.Drawing.Size(59, 13);
            this.LabelKFoldCrossValidationKValue.TabIndex = 2;
            this.LabelKFoldCrossValidationKValue.Text = "Valor de K:";
            // 
            // GroupBoxHoldOut
            // 
            this.GroupBoxHoldOut.Controls.Add(this.NumericUpDownPercentageTrainingSet);
            this.GroupBoxHoldOut.Controls.Add(this.LabelPercentageTrainingSet);
            this.GroupBoxHoldOut.Location = new System.Drawing.Point(6, 43);
            this.GroupBoxHoldOut.Name = "GroupBoxHoldOut";
            this.GroupBoxHoldOut.Size = new System.Drawing.Size(225, 61);
            this.GroupBoxHoldOut.TabIndex = 2;
            this.GroupBoxHoldOut.TabStop = false;
            this.GroupBoxHoldOut.Text = "Hold-Out";
            // 
            // NumericUpDownPercentageTrainingSet
            // 
            this.NumericUpDownPercentageTrainingSet.Location = new System.Drawing.Point(6, 35);
            this.NumericUpDownPercentageTrainingSet.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownPercentageTrainingSet.Name = "NumericUpDownPercentageTrainingSet";
            this.NumericUpDownPercentageTrainingSet.Size = new System.Drawing.Size(213, 20);
            this.NumericUpDownPercentageTrainingSet.TabIndex = 3;
            this.NumericUpDownPercentageTrainingSet.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LabelPercentageTrainingSet
            // 
            this.LabelPercentageTrainingSet.AutoSize = true;
            this.LabelPercentageTrainingSet.Location = new System.Drawing.Point(6, 16);
            this.LabelPercentageTrainingSet.Name = "LabelPercentageTrainingSet";
            this.LabelPercentageTrainingSet.Size = new System.Drawing.Size(198, 13);
            this.LabelPercentageTrainingSet.TabIndex = 2;
            this.LabelPercentageTrainingSet.Text = "Porcentaje (Conjunto de Entrenamiento):";
            // 
            // RadioButtonKFoldCrossValidation
            // 
            this.RadioButtonKFoldCrossValidation.AutoSize = true;
            this.RadioButtonKFoldCrossValidation.Location = new System.Drawing.Point(6, 110);
            this.RadioButtonKFoldCrossValidation.Name = "RadioButtonKFoldCrossValidation";
            this.RadioButtonKFoldCrossValidation.Size = new System.Drawing.Size(133, 17);
            this.RadioButtonKFoldCrossValidation.TabIndex = 3;
            this.RadioButtonKFoldCrossValidation.TabStop = true;
            this.RadioButtonKFoldCrossValidation.Text = "K-Fold Cross Validation";
            this.RadioButtonKFoldCrossValidation.UseVisualStyleBackColor = true;
            // 
            // RadioButtonHoldOut
            // 
            this.RadioButtonHoldOut.AutoSize = true;
            this.RadioButtonHoldOut.Checked = true;
            this.RadioButtonHoldOut.Location = new System.Drawing.Point(6, 20);
            this.RadioButtonHoldOut.Name = "RadioButtonHoldOut";
            this.RadioButtonHoldOut.Size = new System.Drawing.Size(67, 17);
            this.RadioButtonHoldOut.TabIndex = 2;
            this.RadioButtonHoldOut.TabStop = true;
            this.RadioButtonHoldOut.Text = "Hold-Out";
            this.RadioButtonHoldOut.UseVisualStyleBackColor = true;
            // 
            // GroupBoxClassAttribute
            // 
            this.GroupBoxClassAttribute.Controls.Add(this.LabelTypeValue);
            this.GroupBoxClassAttribute.Controls.Add(this.LabelType);
            this.GroupBoxClassAttribute.Controls.Add(this.ComboBoxClassAttribute);
            this.GroupBoxClassAttribute.Location = new System.Drawing.Point(12, 12);
            this.GroupBoxClassAttribute.Name = "GroupBoxClassAttribute";
            this.GroupBoxClassAttribute.Size = new System.Drawing.Size(237, 60);
            this.GroupBoxClassAttribute.TabIndex = 2;
            this.GroupBoxClassAttribute.TabStop = false;
            this.GroupBoxClassAttribute.Text = "Atributo Clase";
            // 
            // LabelTypeValue
            // 
            this.LabelTypeValue.AutoSize = true;
            this.LabelTypeValue.Location = new System.Drawing.Point(32, 16);
            this.LabelTypeValue.Name = "LabelTypeValue";
            this.LabelTypeValue.Size = new System.Drawing.Size(27, 13);
            this.LabelTypeValue.TabIndex = 5;
            this.LabelTypeValue.Text = "N/A";
            // 
            // LabelType
            // 
            this.LabelType.AutoSize = true;
            this.LabelType.Location = new System.Drawing.Point(6, 16);
            this.LabelType.Name = "LabelType";
            this.LabelType.Size = new System.Drawing.Size(31, 13);
            this.LabelType.TabIndex = 4;
            this.LabelType.Text = "Tipo:";
            // 
            // ComboBoxClassAttribute
            // 
            this.ComboBoxClassAttribute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxClassAttribute.FormattingEnabled = true;
            this.ComboBoxClassAttribute.Location = new System.Drawing.Point(6, 32);
            this.ComboBoxClassAttribute.Name = "ComboBoxClassAttribute";
            this.ComboBoxClassAttribute.Size = new System.Drawing.Size(225, 21);
            this.ComboBoxClassAttribute.TabIndex = 3;
            this.ComboBoxClassAttribute.SelectedIndexChanged += new System.EventHandler(this.ComboBoxClassAttribute_SelectedIndexChanged);
            // 
            // PanelMachineLearningAlgorithm
            // 
            this.PanelMachineLearningAlgorithm.Location = new System.Drawing.Point(255, 12);
            this.PanelMachineLearningAlgorithm.Name = "PanelMachineLearningAlgorithm";
            this.PanelMachineLearningAlgorithm.Size = new System.Drawing.Size(677, 527);
            this.PanelMachineLearningAlgorithm.TabIndex = 3;
            // 
            // ButtonTrainAlgorithm
            // 
            this.ButtonTrainAlgorithm.Location = new System.Drawing.Point(12, 405);
            this.ButtonTrainAlgorithm.Name = "ButtonTrainAlgorithm";
            this.ButtonTrainAlgorithm.Size = new System.Drawing.Size(237, 23);
            this.ButtonTrainAlgorithm.TabIndex = 4;
            this.ButtonTrainAlgorithm.Text = "Entrenar Algoritmo";
            this.ButtonTrainAlgorithm.UseVisualStyleBackColor = true;
            this.ButtonTrainAlgorithm.Click += new System.EventHandler(this.ButtonTrainAlgorithm_Click);
            // 
            // GroupBoxEvaluation
            // 
            this.GroupBoxEvaluation.Controls.Add(this.GroupBoxRegression);
            this.GroupBoxEvaluation.Controls.Add(this.GroupBoxClassification);
            this.GroupBoxEvaluation.Location = new System.Drawing.Point(12, 434);
            this.GroupBoxEvaluation.Name = "GroupBoxEvaluation";
            this.GroupBoxEvaluation.Size = new System.Drawing.Size(237, 105);
            this.GroupBoxEvaluation.TabIndex = 5;
            this.GroupBoxEvaluation.TabStop = false;
            this.GroupBoxEvaluation.Text = "Evaluación";
            // 
            // GroupBoxRegression
            // 
            this.GroupBoxRegression.Controls.Add(this.LabelMeanSquaredErrorValue);
            this.GroupBoxRegression.Controls.Add(this.LabelMeanSquaredError);
            this.GroupBoxRegression.Location = new System.Drawing.Point(6, 62);
            this.GroupBoxRegression.Name = "GroupBoxRegression";
            this.GroupBoxRegression.Size = new System.Drawing.Size(225, 37);
            this.GroupBoxRegression.TabIndex = 1;
            this.GroupBoxRegression.TabStop = false;
            this.GroupBoxRegression.Text = "Regresión";
            // 
            // LabelMeanSquaredErrorValue
            // 
            this.LabelMeanSquaredErrorValue.AutoSize = true;
            this.LabelMeanSquaredErrorValue.Location = new System.Drawing.Point(120, 16);
            this.LabelMeanSquaredErrorValue.Name = "LabelMeanSquaredErrorValue";
            this.LabelMeanSquaredErrorValue.Size = new System.Drawing.Size(27, 13);
            this.LabelMeanSquaredErrorValue.TabIndex = 8;
            this.LabelMeanSquaredErrorValue.Text = "N/A";
            // 
            // LabelMeanSquaredError
            // 
            this.LabelMeanSquaredError.AutoSize = true;
            this.LabelMeanSquaredError.Location = new System.Drawing.Point(6, 16);
            this.LabelMeanSquaredError.Name = "LabelMeanSquaredError";
            this.LabelMeanSquaredError.Size = new System.Drawing.Size(118, 13);
            this.LabelMeanSquaredError.TabIndex = 0;
            this.LabelMeanSquaredError.Text = "Error Cuadrático Medio:";
            // 
            // GroupBoxClassification
            // 
            this.GroupBoxClassification.Controls.Add(this.LabelAccuracyValue);
            this.GroupBoxClassification.Controls.Add(this.LabelAccuracy);
            this.GroupBoxClassification.Location = new System.Drawing.Point(6, 19);
            this.GroupBoxClassification.Name = "GroupBoxClassification";
            this.GroupBoxClassification.Size = new System.Drawing.Size(225, 37);
            this.GroupBoxClassification.TabIndex = 0;
            this.GroupBoxClassification.TabStop = false;
            this.GroupBoxClassification.Text = "Clasificación";
            // 
            // LabelAccuracyValue
            // 
            this.LabelAccuracyValue.AutoSize = true;
            this.LabelAccuracyValue.Location = new System.Drawing.Point(55, 16);
            this.LabelAccuracyValue.Name = "LabelAccuracyValue";
            this.LabelAccuracyValue.Size = new System.Drawing.Size(27, 13);
            this.LabelAccuracyValue.TabIndex = 3;
            this.LabelAccuracyValue.Text = "N/A";
            // 
            // LabelAccuracy
            // 
            this.LabelAccuracy.AutoSize = true;
            this.LabelAccuracy.Location = new System.Drawing.Point(6, 16);
            this.LabelAccuracy.Name = "LabelAccuracy";
            this.LabelAccuracy.Size = new System.Drawing.Size(54, 13);
            this.LabelAccuracy.TabIndex = 2;
            this.LabelAccuracy.Text = "Exactitud:";
            // 
            // GroupBoxKMeansAndKNearestNeighbors
            // 
            this.GroupBoxKMeansAndKNearestNeighbors.Controls.Add(this.NumericUpDownKMeansAndKNearestNeighborsKValue);
            this.GroupBoxKMeansAndKNearestNeighbors.Controls.Add(this.LabelKMeansAndKNearestNeighborsKValue);
            this.GroupBoxKMeansAndKNearestNeighbors.Location = new System.Drawing.Point(12, 135);
            this.GroupBoxKMeansAndKNearestNeighbors.Name = "GroupBoxKMeansAndKNearestNeighbors";
            this.GroupBoxKMeansAndKNearestNeighbors.Size = new System.Drawing.Size(237, 60);
            this.GroupBoxKMeansAndKNearestNeighbors.TabIndex = 0;
            this.GroupBoxKMeansAndKNearestNeighbors.TabStop = false;
            this.GroupBoxKMeansAndKNearestNeighbors.Text = "K-Means y K-Nearest Neighbors";
            // 
            // NumericUpDownKMeansAndKNearestNeighborsKValue
            // 
            this.NumericUpDownKMeansAndKNearestNeighborsKValue.Location = new System.Drawing.Point(9, 32);
            this.NumericUpDownKMeansAndKNearestNeighborsKValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownKMeansAndKNearestNeighborsKValue.Name = "NumericUpDownKMeansAndKNearestNeighborsKValue";
            this.NumericUpDownKMeansAndKNearestNeighborsKValue.Size = new System.Drawing.Size(222, 20);
            this.NumericUpDownKMeansAndKNearestNeighborsKValue.TabIndex = 5;
            this.NumericUpDownKMeansAndKNearestNeighborsKValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LabelKMeansAndKNearestNeighborsKValue
            // 
            this.LabelKMeansAndKNearestNeighborsKValue.AutoSize = true;
            this.LabelKMeansAndKNearestNeighborsKValue.Location = new System.Drawing.Point(6, 16);
            this.LabelKMeansAndKNearestNeighborsKValue.Name = "LabelKMeansAndKNearestNeighborsKValue";
            this.LabelKMeansAndKNearestNeighborsKValue.Size = new System.Drawing.Size(59, 13);
            this.LabelKMeansAndKNearestNeighborsKValue.TabIndex = 4;
            this.LabelKMeansAndKNearestNeighborsKValue.Text = "Valor de K:";
            // 
            // MachineLearningAlgorithms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 551);
            this.Controls.Add(this.GroupBoxKMeansAndKNearestNeighbors);
            this.Controls.Add(this.GroupBoxEvaluation);
            this.Controls.Add(this.ButtonTrainAlgorithm);
            this.Controls.Add(this.PanelMachineLearningAlgorithm);
            this.Controls.Add(this.GroupBoxClassAttribute);
            this.Controls.Add(this.GroupBoxValidationMethodologies);
            this.Controls.Add(this.GroupBoxAlgorithms);
            this.Name = "MachineLearningAlgorithms";
            this.Text = "Algoritmos de Aprendizaje Automático";
            this.GroupBoxAlgorithms.ResumeLayout(false);
            this.GroupBoxValidationMethodologies.ResumeLayout(false);
            this.GroupBoxValidationMethodologies.PerformLayout();
            this.GroupBoxKFoldCrossValidation.ResumeLayout(false);
            this.GroupBoxKFoldCrossValidation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownKFoldCrossValidationKValue)).EndInit();
            this.GroupBoxHoldOut.ResumeLayout(false);
            this.GroupBoxHoldOut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownPercentageTrainingSet)).EndInit();
            this.GroupBoxClassAttribute.ResumeLayout(false);
            this.GroupBoxClassAttribute.PerformLayout();
            this.GroupBoxEvaluation.ResumeLayout(false);
            this.GroupBoxRegression.ResumeLayout(false);
            this.GroupBoxRegression.PerformLayout();
            this.GroupBoxClassification.ResumeLayout(false);
            this.GroupBoxClassification.PerformLayout();
            this.GroupBoxKMeansAndKNearestNeighbors.ResumeLayout(false);
            this.GroupBoxKMeansAndKNearestNeighbors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownKMeansAndKNearestNeighborsKValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxAlgorithms;
        private System.Windows.Forms.ComboBox ComboBoxAlgorithms;
        private System.Windows.Forms.GroupBox GroupBoxValidationMethodologies;
        private System.Windows.Forms.GroupBox GroupBoxHoldOut;
        private System.Windows.Forms.RadioButton RadioButtonKFoldCrossValidation;
        private System.Windows.Forms.RadioButton RadioButtonHoldOut;
        private System.Windows.Forms.GroupBox GroupBoxKFoldCrossValidation;
        private System.Windows.Forms.NumericUpDown NumericUpDownKFoldCrossValidationKValue;
        private System.Windows.Forms.Label LabelKFoldCrossValidationKValue;
        private System.Windows.Forms.NumericUpDown NumericUpDownPercentageTrainingSet;
        private System.Windows.Forms.Label LabelPercentageTrainingSet;
        private System.Windows.Forms.GroupBox GroupBoxClassAttribute;
        private System.Windows.Forms.ComboBox ComboBoxClassAttribute;
        private System.Windows.Forms.Panel PanelMachineLearningAlgorithm;
        private System.Windows.Forms.Button ButtonTrainAlgorithm;
        private System.Windows.Forms.Label LabelTypeValue;
        private System.Windows.Forms.Label LabelType;
        private System.Windows.Forms.GroupBox GroupBoxEvaluation;
        private System.Windows.Forms.GroupBox GroupBoxRegression;
        private System.Windows.Forms.Label LabelMeanSquaredErrorValue;
        private System.Windows.Forms.Label LabelMeanSquaredError;
        private System.Windows.Forms.GroupBox GroupBoxClassification;
        private System.Windows.Forms.Label LabelAccuracyValue;
        private System.Windows.Forms.Label LabelAccuracy;
        private System.Windows.Forms.GroupBox GroupBoxKMeansAndKNearestNeighbors;
        private System.Windows.Forms.NumericUpDown NumericUpDownKMeansAndKNearestNeighborsKValue;
        private System.Windows.Forms.Label LabelKMeansAndKNearestNeighborsKValue;
    }
}