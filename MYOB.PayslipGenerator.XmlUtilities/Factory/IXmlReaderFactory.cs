using MYOB.PayslipGenerator.Utilities;

namespace MYOB.PayslipGenerator.XmlUtilities
{
    /// <summary>
    /// Xml Reader Factory Contract
    /// </summary>
    /// <typeparam name="T">any class of type T</typeparam>
    public interface IXmlReaderFactory<T> where T : class
    {
        /// <summary>
        /// Get a reader
        /// </summary>
        /// <param name="xmlType">xml type</param>
        /// <returns>reader factory</returns>
        IReaderFactory<T> GetReader(XmlType xmlType);
    }
}
