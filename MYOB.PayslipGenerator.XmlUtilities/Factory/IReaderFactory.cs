using System.Collections.Generic;

namespace MYOB.PayslipGenerator.XmlUtilities
{
    /// <summary>
    /// Reader Factory contract
    /// </summary>
    /// <typeparam name="T">any calss of Type T</typeparam>
    public interface IReaderFactory<T> where T : class
    {
        /// <summary>
        /// Read  data
        /// </summary>
        /// <typeparam name="T1">any class of Type T1</typeparam>
        /// <returns>a collection of read data</returns>
        IList<dynamic> Read<T1>();

        /// <summary>
        /// Indicates if the file has been read
        /// </summary>
        bool HasFileBeenRead { get; set; }
    }
}
