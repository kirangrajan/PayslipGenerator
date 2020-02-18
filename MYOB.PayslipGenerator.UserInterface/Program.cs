using Microsoft.Practices.Unity;
using System;
using System.Windows.Forms;

namespace MYOB.PayslipGenerator.UserInterface
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                
                var bootstrapper = new Bootstrapper();
                IUnityContainer container = bootstrapper.Run();

                Application.Run(container.Resolve<PayslipGenerator>());
            }
            catch (Exception ex)
            {
                /// Single point of exception logging
                Logger.WriteLog(ex);
            }
        }
    }
}
