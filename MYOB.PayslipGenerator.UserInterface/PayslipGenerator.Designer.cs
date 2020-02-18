namespace MYOB.PayslipGenerator.UserInterface
{
    partial class PayslipGenerator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayslipGenerator));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSourceFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTargetFile = new System.Windows.Forms.TextBox();
            this.btnGeneratePayslip = new System.Windows.Forms.Button();
            this.btnFilePickerSource = new System.Windows.Forms.Button();
            this.btnFilePickerTarget = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(569, 152);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Source File:";
            // 
            // txtSourceFile
            // 
            this.txtSourceFile.Location = new System.Drawing.Point(112, 137);
            this.txtSourceFile.Name = "txtSourceFile";
            this.txtSourceFile.Size = new System.Drawing.Size(443, 20);
            this.txtSourceFile.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Target File:";
            // 
            // txtTargetFile
            // 
            this.txtTargetFile.Location = new System.Drawing.Point(112, 175);
            this.txtTargetFile.Name = "txtTargetFile";
            this.txtTargetFile.Size = new System.Drawing.Size(443, 20);
            this.txtTargetFile.TabIndex = 4;
            // 
            // btnGeneratePayslip
            // 
            this.btnGeneratePayslip.Location = new System.Drawing.Point(432, 207);
            this.btnGeneratePayslip.Name = "btnGeneratePayslip";
            this.btnGeneratePayslip.Size = new System.Drawing.Size(165, 57);
            this.btnGeneratePayslip.TabIndex = 5;
            this.btnGeneratePayslip.Text = "Generate Payslip";
            this.btnGeneratePayslip.UseVisualStyleBackColor = true;
            this.btnGeneratePayslip.Click += new System.EventHandler(this.btnGeneratePayslip_Click);
            // 
            // btnFilePickerSource
            // 
            this.btnFilePickerSource.Location = new System.Drawing.Point(561, 137);
            this.btnFilePickerSource.Name = "btnFilePickerSource";
            this.btnFilePickerSource.Size = new System.Drawing.Size(36, 24);
            this.btnFilePickerSource.TabIndex = 6;
            this.btnFilePickerSource.Text = "...";
            this.btnFilePickerSource.UseVisualStyleBackColor = true;
            this.btnFilePickerSource.Click += new System.EventHandler(this.btnFilePickerSource_Click);
            // 
            // btnFilePickerTarget
            // 
            this.btnFilePickerTarget.Location = new System.Drawing.Point(561, 171);
            this.btnFilePickerTarget.Name = "btnFilePickerTarget";
            this.btnFilePickerTarget.Size = new System.Drawing.Size(36, 24);
            this.btnFilePickerTarget.TabIndex = 7;
            this.btnFilePickerTarget.Text = "...";
            this.btnFilePickerTarget.UseVisualStyleBackColor = true;
            this.btnFilePickerTarget.Click += new System.EventHandler(this.btnFilePickerTarget_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.Location = new System.Drawing.Point(13, 250);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 14);
            this.lblError.TabIndex = 8;
            // 
            // PayslipGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 276);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnFilePickerTarget);
            this.Controls.Add(this.btnFilePickerSource);
            this.Controls.Add(this.btnGeneratePayslip);
            this.Controls.Add(this.txtTargetFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSourceFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PayslipGenerator";
            this.Text = "Payslip Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSourceFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTargetFile;
        private System.Windows.Forms.Button btnGeneratePayslip;
        private System.Windows.Forms.Button btnFilePickerSource;
        private System.Windows.Forms.Button btnFilePickerTarget;
        private System.Windows.Forms.Label lblError;

    }
}

