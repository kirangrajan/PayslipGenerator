using Microsoft.Practices.Unity;
using MYOB.PayslipGenerator.BusinessLogic;

namespace MYOB.PayslipGenerator.UserInterface
{
    /// <summary>
    /// Boot strapper file, used to initilizing dependencies
    /// </summary>
    public class Bootstrapper
    {
        private readonly IUnityContainer _container;

        public Bootstrapper()
        {
            this._container = new UnityContainer();
        }

        /// <summary>
        /// Execute unity registrations
        /// </summary>
        /// <returns></returns>
        public IUnityContainer Run()
        {
            this._container.AddNewExtension<UIUnityExtension>();
            this._container.AddNewExtension<BusinessLogicUnityExtension>();

            return this._container;
        }
    }
}
