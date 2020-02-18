using Microsoft.Practices.Unity;
using MYOB.PayslipGenerator.BusinessLogic;
using MYOB.PayslipGenerator.UserInterface.ViewModel;

namespace MYOB.PayslipGenerator.UserInterface
{
    /// <summary>
    /// Unity extension class to register all unity registrations referred in UI layer
    /// </summary>
    public class UIUnityExtension : UnityContainerExtension
    {
        /// <summary>
        /// Initialization code
        /// </summary>
        protected override void Initialize()
        {
            this.Container.RegisterType<IEmployeeService, EmployeeService>();
            this.Container.RegisterType<ITaxCalculatorService, TaxCalculatorService>();
            this.Container.RegisterType<IEmployeeViewModel, EmployeeViewModel>();
        }
    }
}
