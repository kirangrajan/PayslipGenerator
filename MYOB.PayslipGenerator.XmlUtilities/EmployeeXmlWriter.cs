using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
namespace MYOB.PayslipGenerator.XmlUtilities
{
    /// <summary>
    /// Employee Xml Writer
    /// </summary>
    /// <typeparam name="T">Class of Type T</typeparam>
    public class EmployeeXmlWriter<T> : IWriterFactory<T> where T : class
    {
        private readonly string _filename;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileName">file name </param>
        public EmployeeXmlWriter(string fileName)
        {
            this._filename = fileName;
        }

        /// <summary>
        /// Write data
        /// </summary>
        /// <param name="data">data to be written</param>
        /// <returns>true/false</returns>
        public bool Write(T data)
        {
            var result = false;
            var xmlSerializer = new XmlSerializer(typeof(T));

            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = ("\t"),
                OmitXmlDeclaration = true
            };

            var xmlNamespace = new XmlSerializerNamespaces();
            xmlNamespace.Add(string.Empty, string.Empty);

            using (var xmlWriter = XmlWriter.Create(this._filename, settings))
            {
                xmlSerializer.Serialize(xmlWriter, data, xmlNamespace);
                xmlWriter.Flush();
            }

            result = true;

            return result;
        }
    }
}
