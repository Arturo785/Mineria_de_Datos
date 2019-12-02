using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Software_de_Minería_de_Datos
{
    public partial class UnivariateAnalysis : Form
    {
        DataTable dataSet;
        DataFile dataSetDataFile;
        BindingList<string> attributes;

        public UnivariateAnalysis(DataTable newDataSet)
        {
            InitializeComponent();

            dataSet = newDataSet;

            attributes = new BindingList<string>();

            ListBoxAttributes.DataSource = attributes;
        }

        public void UpdateContent(DataFile newDataSetDataFile)
        {
            dataSetDataFile = newDataSetDataFile;

            attributes.Clear();

            foreach (DataColumn attribute in dataSet.Columns)
            {
                attributes.Add(attribute.Caption);
            }

            if (attributes.Count != 0)
            {
                GetAttributeStatistics();
            }
        }

        private void ListBoxAttributes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (attributes.Count != 0)
            {
                GetAttributeStatistics();
            }
        }

        private void GetAttributeStatistics()
        {
            if (dataSetDataFile == null)
            {
                List<string> attributeValues = new List<string>();
                string attributeValue;

                foreach (DataRow instance in dataSet.Rows)
                {
                    attributeValue = instance[ListBoxAttributes.SelectedIndex].ToString();

                    if (attributeValue != "")
                    {
                        attributeValues.Add(attributeValue);
                    }
                }

                if (attributeValues.Count == 0)
                {
                    ChartAttribute.Series.Clear();
                    ChartAttribute.Titles.Clear();

                    ChartAttribute.Titles.Add(ListBoxAttributes.SelectedItem.ToString());

                    UpdateValueLabels("N/A", "N/A", "N/A", "N/A");

                    MessageBox.Show("El atributo \"" + ListBoxAttributes.SelectedItem.ToString() + "\" no tiene valores.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    UpdateValueLabels("N/A", "N/A", GetMode(attributeValues), "N/A");

                    GraphCategoricalAttribute(attributeValues);
                }
            }
            else
            {
                if (dataSetDataFile.Attributes[ListBoxAttributes.SelectedIndex].GetDataTypeIndex() == DataFileAttribute.AttributeDataType.Numeric)
                {
                    List<double> attributeValues = new List<double>();
                    string attributeValue;

                    foreach (DataRow instance in dataSet.Rows)
                    {
                        attributeValue = instance[ListBoxAttributes.SelectedIndex].ToString();

                        try
                        {
                            attributeValues.Add(Convert.ToDouble(attributeValue));
                        }
                        catch (FormatException)
                        {
                            if (attributeValue != dataSetDataFile.MissingValue && attributeValue != "")
                            {
                                ChartAttribute.Series.Clear();
                                ChartAttribute.Titles.Clear();

                                ChartAttribute.Titles.Add(ListBoxAttributes.SelectedItem.ToString());

                                UpdateValueLabels("N/A", "N/A", "N/A", "N/A");

                                MessageBox.Show("El atributo \"" + ListBoxAttributes.SelectedItem.ToString() + "\" tiene valores inválidos (\"" + attributeValue + "\").", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    if (attributeValues.Count == 0)
                    {
                        ChartAttribute.Series.Clear();
                        ChartAttribute.Titles.Clear();

                        ChartAttribute.Titles.Add(ListBoxAttributes.SelectedItem.ToString());

                        UpdateValueLabels("N/A", "N/A", "N/A", "N/A");

                        MessageBox.Show("El atributo \"" + ListBoxAttributes.SelectedItem.ToString() + "\" no tiene valores.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        attributeValues.Sort();

                        UpdateValueLabels(GetMean(attributeValues).ToString(), GetMedian(attributeValues).ToString(), GetMode(attributeValues).ToString(), GetStandardDeviation(attributeValues).ToString());

                        if (GetStandardDeviation(attributeValues) == 0)
                        {
                            ChartAttribute.Series.Clear();
                            ChartAttribute.Titles.Clear();

                            ChartAttribute.Titles.Add(ListBoxAttributes.SelectedItem.ToString());

                            MessageBox.Show("El atributo \"" + ListBoxAttributes.SelectedItem.ToString() + "\" no puede ser graficado porque su desviación estándar es 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        GraphNumericAttributes(attributeValues);
                    }
                }
                else
                {
                    List<string> attributeValues = new List<string>();
                    string attributeValue;

                    foreach (DataRow instance in dataSet.Rows)
                    {
                        attributeValue = instance[ListBoxAttributes.SelectedIndex].ToString();

                        if (attributeValue != dataSetDataFile.MissingValue && attributeValue != "")
                        {
                            attributeValues.Add(attributeValue);
                        }
                    }

                    if (attributeValues.Count == 0)
                    {
                        ChartAttribute.Series.Clear();
                        ChartAttribute.Titles.Clear();

                        ChartAttribute.Titles.Add(ListBoxAttributes.SelectedItem.ToString());

                        UpdateValueLabels("N/A", "N/A", "N/A", "N/A");

                        MessageBox.Show("El atributo \"" + ListBoxAttributes.SelectedItem.ToString() + "\" no tiene valores.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        UpdateValueLabels("N/A", "N/A", GetMode(attributeValues), "N/A");

                        GraphCategoricalAttribute(attributeValues);
                    }
                }
            }
        }

        private double GetMean(List<double> attributeValues)
        {
            return attributeValues.Average();
        }

        private double GetMedian(List<double> attributeValues)
        {
            if (attributeValues.Count % 2 == 0)
            {
                return (attributeValues[(attributeValues.Count / 2) - 1] + attributeValues[attributeValues.Count / 2]) / 2;
            }
            else
            {
                return attributeValues[attributeValues.Count / 2];
            }
        }

        private double GetMode(List<double> attributeValues)
        {
            return Convert.ToDouble(attributeValues.GroupBy(value => value).OrderByDescending(group => group.Count()).First().Key.ToString());
        }

        private string GetMode(List<string> attributeValues)
        {
            return attributeValues.GroupBy(value => value).OrderByDescending(group => group.Count()).First().Key.ToString();
        }

        private double GetStandardDeviation(List<double> attributeValues)
        {
            double mean = attributeValues.Average();

            return Math.Sqrt(attributeValues.Sum(value => Math.Pow(value - mean, 2)) / attributeValues.Count);
        }

        private void UpdateValueLabels(string newLabelMeanValue, string newLabelMedianValue, string newLabelModeValue, string newLabelStandardDeviationValue)
        {
            LabelMeanValue.Text = newLabelMeanValue;
            LabelMedianValue.Text = newLabelMedianValue;
            LabelModeValue.Text = newLabelModeValue;
            LabelStandardDeviationValue.Text = newLabelStandardDeviationValue;
        }

        private void GraphCategoricalAttribute(List<string> attributeValues)
        {
            ChartAttribute.Series.Clear();
            ChartAttribute.Titles.Clear();

            List<string> chartSeries = new List<string>();
            List<int> chartSeriesPoints = new List<int>();

            var attributeGroups = attributeValues.GroupBy(i => i);

            foreach (var group in attributeGroups)
            {
                var groupKey = group.Key;
                var groupTotal = group.Count();

                chartSeries.Add(groupKey);
                chartSeriesPoints.Add(groupTotal);
            }

            ChartAttribute.Titles.Add(ListBoxAttributes.SelectedItem.ToString());

            for (int i = 0; i < chartSeries.Count; i++)
            {
                Series newSeries = ChartAttribute.Series.Add(chartSeries[i]);
                newSeries.ChartType = SeriesChartType.Column;
                newSeries.Points.Add(chartSeriesPoints[i]);
            }
        }

        private void GraphNumericAttributes(List<double> attributeValues)
        {
            ChartAttribute.Series.Clear();
            ChartAttribute.Titles.Clear();

            ChartAttribute.Titles.Add(ListBoxAttributes.SelectedItem.ToString());

            double minimum, firstQuartile, median, mean, thirdQuartile, maximum;

            median = GetMedian(attributeValues);

            mean = GetMean(attributeValues);

            firstQuartile = GetMedian(attributeValues.GetRange(0, attributeValues.Count / 2));

            if (attributeValues.Count % 2 == 0)
            {
                thirdQuartile = GetMedian(attributeValues.GetRange(attributeValues.Count / 2, attributeValues.Count / 2));
            }
            else
            {
                thirdQuartile = GetMedian(attributeValues.GetRange((attributeValues.Count / 2) + 1, attributeValues.Count / 2));
            }

            minimum = firstQuartile - ((thirdQuartile - firstQuartile) * 1.5);
            maximum = thirdQuartile + ((thirdQuartile - firstQuartile) * 1.5);

            Series attributeBoxPlot = ChartAttribute.Series.Add("Distribución");
            attributeBoxPlot.ChartType = SeriesChartType.BoxPlot;
            attributeBoxPlot.BorderWidth = 2;
            attributeBoxPlot.Points.AddXY(1, minimum, maximum, firstQuartile, thirdQuartile, median, mean);

            Series attributePoints = ChartAttribute.Series.Add("Valores");
            attributePoints.ChartType = SeriesChartType.Point;
            attributePoints.CustomProperties = "IsXAxisQuantitative=True";

            for (int i = 0; i < attributeValues.Count; i++)
            {
                attributePoints.Points.AddXY(1, attributeValues[i]);
            }
        }
    }
}
