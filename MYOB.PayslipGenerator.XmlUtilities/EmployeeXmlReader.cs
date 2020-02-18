using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
namespace MYOB.PayslipGenerator.XmlUtilities
{
    /// <summary>
    /// Employee XML reader
    /// </summary>
    /// <typeparam name="T">Employee type</typeparam>
    public class EmployeeXmlReader<T> : IReaderFactory<T> where T : class
    {
        private const string Employees = "Employees";
        private readonly XmlReader _xmlReader;
        private readonly string _filename;
        private IList<dynamic> employeeList;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileName">file name </param>
        public EmployeeXmlReader(string fileName)
        {
            this._filename = fileName;
            this._xmlReader = XmlReader.Create(this._filename);
            this._xmlReader.MoveToContent();
            employeeList = new List<dynamic>();
            this.HasFileBeenRead = false;
        }


        /// <summary>
        /// Indicates if the file has been read
        /// </summary>
        public bool HasFileBeenRead { get; set; }

        /// <summary>
        /// Read  data
        /// </summary>
        /// <typeparam name="T1">any class of Type T1</typeparam>
        /// <returns>a collection of read data</returns>
        public IList<dynamic> Read<T1>()
        {
            if (this._xmlReader == null || this._xmlReader.IsEmptyElement)
            {
                return null;
            }

            var xmlSerializer = new XmlSerializer(typeof(T1));

            var employees = (T1)xmlSerializer.Deserialize(this._xmlReader);

            if (string.Compare(employees.GetType().Name, Employees, true) == 0)
            {
                foreach (var employee in (employees as Employees).Employee)
                    employeeList.Add(employee);
            }

            if (this._xmlReader.EOF)
            {
                this.HasFileBeenRead = true;
            }

            return employeeList;
        }
    }
}
