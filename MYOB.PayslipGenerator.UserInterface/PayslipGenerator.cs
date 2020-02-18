using System.Windows.Forms;
using MYOB.PayslipGenerator.XmlUtilities;
using System;
using MYOB.PayslipGenerator.UserInterface.ViewModel;
using MYOB.PayslipGenerator.DomainModel;
using System.Collections.Generic;
using MYOB.PayslipGenerator.Utilities;

namespace MYOB.PayslipGenerator.UserInterface
{
    /// <summary>
    /// Pay slip generator form
    /// </summary>
    public partial class PayslipGenerator : Form
    {
        private readonly IEmployeeViewModel _employeeViewModel;

        private string _souceFilePath;
        private string _targetFilePath;

        /// <summary>
        /// Constructor method
        /// </summary>
        public PayslipGenerator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="employeeViewModel">employeeViewModel being injected</param>

        public PayslipGenerator(IEmployeeViewModel employeeViewModel)
        {
            this._employeeViewModel = employeeViewModel;
            InitializeComponent();
        }

        private void btnFilePickerSource_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "xml file|*.xml";
                var result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    txtSourceFile.Text = this._souceFilePath = dialog.FileName.GetFilePath();
                }
            }
        }

        private void btnFilePickerTarget_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    txtTargetFile.Text = this._targetFilePath = System.IO.Path.Combine(dialog.SelectedPath, "Payslip.xml").RenameIfFileExists();
                }
            }
        }

        private void btnGeneratePayslip_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this._targetFilePath) || string.IsNullOrEmpty(this._souceFilePath))
                {
                    lblError.Text = "Source and Target file path to be set..";
                    return;
                }

                var employeesFromFile = this._employeeViewModel.ReadEmployeesFromFile(this._souceFilePath);

                var calculatedTaxForSelectedEmployees = this._employeeViewModel.CalculateTaxForEmployees(employeesFromFile, Constants.TaxYear);

                var result = this._employeeViewModel.GeneratePaySlipForEmployees(calculatedTaxForSelectedEmployees, this._targetFilePath);

                if (result)
                {
                    lblError.Text = string.Format("Payslip generated successfully..Payslip file at {0}", this._targetFilePath);
                }
                else
                {
                    lblError.Text = "Payslip generation failed";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                throw;
            }
        }
    }
}