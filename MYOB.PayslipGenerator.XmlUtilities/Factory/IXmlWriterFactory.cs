using MYOB.PayslipGenerator.Utilities;
namespace MYOB.PayslipGenerator.XmlUtilities
{
    /// <summary>
    /// Xml Writer Factory contract
    /// </summary>
    /// <typeparam name="T">any class of type T</typeparam>
    public interface IXmlWriterFactory<T> where T : class
    {
        /// <summary>
        /// Get a writer
        /// </summary>
        /// <param name="xmlType">xml type</param>
        /// <returns>writer factory</returns>
        IWriterFactory<T> GetWriter(XmlType xmlType);
    }
}
