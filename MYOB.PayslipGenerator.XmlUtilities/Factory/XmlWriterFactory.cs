using MYOB.PayslipGenerator.Utilities;
namespace MYOB.PayslipGenerator.XmlUtilities
{
    /// <summary>
    /// Xml Writer Factory
    /// </summary>
    /// <typeparam name="T">class of type T</typeparam>
    public class XmlWriterFactory<T> : IXmlWriterFactory<T> where T : class
    {
        private readonly string _filename;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileName">file name</param>
        public XmlWriterFactory(string fileName)
        {
            this._filename = fileName;
        }

        /// <summary>
        /// Get a writer
        /// </summary>
        /// <param name="xmlType">xml type</param>
        /// <returns>writer factory</returns>
        public IWriterFactory<T> GetWriter(XmlType xmlType)
        {
            switch (xmlType)
            {
                case XmlType.Employee:
                default:
                    return new EmployeeXmlWriter<T>(this._filename);
            }
        }
    }
}
