using System;
namespace MYOB.PayslipGenerator.DomainModel
{
    /// <summary>
    /// Base entity class
    /// </summary>
    public class BaseEntity
    {
        public int Id { get; set; }

        public string Createdby { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
