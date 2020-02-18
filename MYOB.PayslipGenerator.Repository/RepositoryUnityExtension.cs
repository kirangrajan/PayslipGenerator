using Microsoft.Practices.Unity;
namespace MYOB.PayslipGenerator.Repository
{
    /// <summary>
    /// Repository Unity Extension
    /// </summary>
    public class RepositoryUnityExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            this.Container.RegisterType<ITaxSlabRepository, TaxSlabRepository>();
        }
    }
}
