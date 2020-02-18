using Microsoft.Practices.Unity;
using MYOB.PayslipGenerator.Repository;

namespace MYOB.PayslipGenerator.BusinessLogic
{
    /// <summary>
    /// Class for all unity registrations in business logic layer
    /// </summary>
    public class BusinessLogicUnityExtension: UnityContainerExtension
    {
        protected override void Initialize()
        {
            this.Container.RegisterType<ITaxSlabRepository, TaxSlabRepository>();
            this.Container.RegisterType<IIncomeTaxCalculationRepository, IncomeTaxCalculationRepository>();
            this.Container.AddNewExtension<RepositoryUnityExtension>();
        }
    }
}
