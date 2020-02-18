using System.Collections.Generic;
namespace MYOB.PayslipGenerator.XmlUtilities
{
    /// <summary>
    /// Custom xml reader contract
    /// </summary>
    public interface ICustomXmlReader<T> where T : class
    {
        IList<dynamic> ReadXml<T>();
    }
}
