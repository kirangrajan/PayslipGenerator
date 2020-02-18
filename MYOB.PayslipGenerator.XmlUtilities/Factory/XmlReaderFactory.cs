using MYOB.PayslipGenerator.Utilities;

namespace MYOB.PayslipGenerator.XmlUtilities
{
    /// <summary>
    /// Xml Reader Factory
    /// </summary>
    /// <typeparam name="T">any class of type T</typeparam>
    public class XmlReaderFactory<T> : IXmlReaderFactory<T> where T : class
    {
        private readonly string _filename;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileName">file name</param>
        public XmlReaderFactory(string fileName)
        {
            this._filename = fileName;
        }

        /// <summary>
        /// Get a reader
        /// </summary>
        /// <param name="xmlType">xml type</param>
        /// <returns>reader factory</returns>
        public IReaderFactory<T> GetReader(XmlType xmlType)
        {
            switch (xmlType)
            {
                case XmlType.Employee:
                default:
                    return new EmployeeXmlReader<T>(this._filename);

            }
        }
    }
}
