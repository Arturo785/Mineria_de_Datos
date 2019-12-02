using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Software_de_Minería_de_Datos
{
    public class DataFile
    {
        public string GeneralInformation { get; set; }
        public string Relation { get; set; }
        public List<DataFileAttribute> Attributes { get; set; }
        public string MissingValue { get; set; }
        public List<List<string>> Data { get; set; }

        public DataFile(string fileName)
        {
            StreamReader dataFileContent = new StreamReader(fileName);
            string dataFileLine;

            Attributes = new List<DataFileAttribute>();
            Data = new List<List<string>>();

            while (!dataFileContent.EndOfStream)
            {
                dataFileLine = dataFileContent.ReadLine();

                // Verificar si la linea es un comentario.
                if (dataFileLine.StartsWith("%%"))
                {
                    dataFileLine = dataFileLine.Remove(0, 3);

                    GeneralInformation += dataFileLine;
                }
                // Verificar si la linea es información sobre el conjunto de datos.
                else if (dataFileLine.StartsWith("@"))
                {
                    dataFileLine = dataFileLine.Remove(0, 1);

                    if (dataFileLine.StartsWith("relation"))
                    {
                        dataFileLine = dataFileLine.Remove(0, dataFileLine.IndexOf(' ') + 1);

                        Relation = dataFileLine;
                    }
                    else if (dataFileLine.StartsWith("attribute"))
                    {
                        string attributeName, attributeDataType, attributeDomain;

                        dataFileLine = dataFileLine.Remove(0, dataFileLine.IndexOf(' ') + 1);

                        attributeName = dataFileLine.Substring(0, dataFileLine.IndexOf(' '));
                        dataFileLine = dataFileLine.Remove(0, dataFileLine.IndexOf(' ') + 1);

                        attributeDataType = dataFileLine.Substring(0, dataFileLine.IndexOf(' '));
                        dataFileLine = dataFileLine.Remove(0, dataFileLine.IndexOf(' ') + 1);

                        attributeDomain = dataFileLine;

                        Attributes.Add(new DataFileAttribute(attributeName, attributeDataType, attributeDomain));
                    }
                    else if (dataFileLine.StartsWith("missingValue"))
                    {
                        dataFileLine = dataFileLine.Remove(0, dataFileLine.IndexOf(' ') + 1);

                        MissingValue = dataFileLine;
                    }
                    else if (dataFileLine.StartsWith("data"))
                    {
                        while (!dataFileContent.EndOfStream)
                        {
                            dataFileLine = dataFileContent.ReadLine();

                            Data.Add(dataFileLine.Split(',').ToList());
                        }
                    }
                    else
                    {
                        // Archivo mal escrito.
                    }
                }
                else
                {
                    // Archivo mal escrito.
                }
            }
        }

        public DataFile(string newGeneralInformation, string newRelation, List<DataFileAttribute> newAttributes, string newMissingValue, DataTable newData)
        {
            List<string> instance;

            GeneralInformation = newGeneralInformation;
            Relation = newRelation;
            Attributes = newAttributes;
            MissingValue = newMissingValue;
            Data = new List<List<string>>();

            for (int i = 0; i < newData.Rows.Count; i++)
            {
                instance = new List<string>();

                for (int j = 0; j < newData.Columns.Count; j++)
                {
                    if (newData.Rows[i][j].ToString() != MissingValue)
                    {
                        instance.Add(newData.Rows[i][j].ToString());
                    }
                    else
                    {
                        instance.Add("");
                    }
                }

                Data.Add(instance);
            }
        }

        public string Save()
        {
            string DATAFile = "";
            string generalInformationChunk = GeneralInformation;

            while (generalInformationChunk.Length > 70)
            {
                DATAFile += "%% " + generalInformationChunk.Substring(0, 70) + "\n";

                generalInformationChunk = generalInformationChunk.Remove(0, 70);
            }

            DATAFile += "%% " + generalInformationChunk + "\n";

            DATAFile += "@relation " + Relation + "\n";

            foreach (DataFileAttribute attribute in Attributes)
            {
                DATAFile += "@attribute " + attribute.Name + " " + attribute.DataType + " " + attribute.Domain.ToString() + "\n";
            }

            DATAFile += "@missingValue " + MissingValue + "\n";

            DATAFile += "@data\n";

            foreach (List<string> instance in Data)
            {
                for (int i = 0; i < instance.Count - 1; i++)
                {
                    DATAFile += instance[i] + ",";
                }

                DATAFile += instance[instance.Count - 1] + "\n";
            }

            return DATAFile.Remove(DATAFile.Length - 1);
        }
    }
}
