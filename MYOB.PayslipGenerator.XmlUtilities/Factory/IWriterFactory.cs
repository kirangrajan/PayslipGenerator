using System.Collections.Generic;
namespace MYOB.PayslipGenerator.XmlUtilities
{
    /// <summary>
    /// Factory calss to write data to some location
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IWriterFactory<T> where T : class
    {
        /// <summary>
        /// Write data
        /// </summary>
        /// <param name="data">data to be written</param>
        /// <returns>true/false</returns>
        bool Write(T data);
    }
}
