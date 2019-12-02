using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Software_de_Minería_de_Datos
{
    public class DataFileAttribute
    {
        // Enum con los tipos de dato válidos.
        public enum AttributeDataType { Nominal, Ordinal, SymmetricBinary, AsymmetricBinary, Numeric };

        // Variables.
        public string Name { get; set; }
        public string DataType { get; set; }
        public Regex Domain { get; set; }

        public DataFileAttribute(string newName, string newDataType, string newDomain)
        {
            Name = newName;
            DataType = newDataType;
            Domain = new Regex(newDomain);
        }

        public DataFileAttribute(string newName, int newDataType, string newDomain)
        {
            Name = newName;

            switch ((AttributeDataType)newDataType)
            {
                case AttributeDataType.Nominal:
                    DataType = "nominal";
                    break;

                case AttributeDataType.Ordinal:
                    DataType = "ordinal";
                    break;

                case AttributeDataType.SymmetricBinary:
                    DataType = "symmetric_binary";
                    break;

                case AttributeDataType.AsymmetricBinary:
                    DataType = "asymmetric_binary";
                    break;

                case AttributeDataType.Numeric:
                    DataType = "numeric";
                    break;
            }

            Domain = new Regex(newDomain);
        }

        public AttributeDataType GetDataTypeIndex()
        {
            if (DataType == "nominal")
            {
                return AttributeDataType.Nominal;
            }
            else if (DataType == "ordinal")
            {
                return AttributeDataType.Ordinal;
            }
            else if (DataType == "symmetric_binary")
            {
                return AttributeDataType.SymmetricBinary;
            }
            else if (DataType == "asymmetric_binary")
            {
                return AttributeDataType.AsymmetricBinary;
            }
            else
            {
                return AttributeDataType.Numeric;
            }
        }

        public void Edit(string newName, int newDataType, string newDomain)
        {
            Name = newName;

            switch ((AttributeDataType)newDataType)
            {
                case AttributeDataType.Nominal:
                    DataType = "nominal";
                    break;

                case AttributeDataType.Ordinal:
                    DataType = "ordinal";
                    break;

                case AttributeDataType.SymmetricBinary:
                    DataType = "symmetric_binary";
                    break;

                case AttributeDataType.AsymmetricBinary:
                    DataType = "asymmetric_binary";
                    break;

                case AttributeDataType.Numeric:
                    DataType = "numeric";
                    break;
            }

            Domain = new Regex(newDomain);
        }
    }
}
