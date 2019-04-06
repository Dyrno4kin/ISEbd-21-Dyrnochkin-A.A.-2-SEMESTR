namespace FishShopView
{
    partial class FormCustomerOrders
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
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.labelDataPikerFrom = new System.Windows.Forms.Label();
            this.labelDataPickerTo = new System.Windows.Forms.Label();
            this.buttonMake = new System.Windows.Forms.Button();
            this.buttonToPdf = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            this.reportViewer.LocalReport.ReportEmbeddedResource = "FishShopView.Report1.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(12, 50);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(993, 536);
            this.reportViewer.TabIndex = 0;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(33, 12);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFrom.TabIndex = 1;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(288, 12);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerTo.TabIndex = 2;
            // 
            // labelDataPikerFrom
            // 
            this.labelDataPikerFrom.AutoSize = true;
            this.labelDataPikerFrom.Location = new System.Drawing.Point(12, 17);
            this.labelDataPikerFrom.Name = "labelDataPikerFrom";
            this.labelDataPikerFrom.Size = new System.Drawing.Size(15, 15);
            this.labelDataPikerFrom.TabIndex = 3;
            this.labelDataPikerFrom.Text = "C";
            // 
            // labelDataPickerTo
            // 
            this.labelDataPickerTo.AutoSize = true;
            this.labelDataPickerTo.Location = new System.Drawing.Point(249, 17);
            this.labelDataPickerTo.Name = "labelDataPickerTo";
            this.labelDataPickerTo.Size = new System.Drawing.Size(21, 15);
            this.labelDataPickerTo.TabIndex = 4;
            this.labelDataPickerTo.Text = "по";
            // 
            // buttonMake
            // 
            this.buttonMake.Location = new System.Drawing.Point(544, 12);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(131, 24);
            this.buttonMake.TabIndex = 5;
            this.buttonMake.Text = "Сформировать";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.buttonMake_Click);
            // 
            // buttonToPdf
            // 
            this.buttonToPdf.Location = new System.Drawing.Point(930, 13);
            this.buttonToPdf.Name = "buttonToPdf";
            this.buttonToPdf.Size = new System.Drawing.Size(75, 23);
            this.buttonToPdf.TabIndex = 7;
            this.buttonToPdf.Text = "В PDF";
            this.buttonToPdf.UseVisualStyleBackColor = true;
            this.buttonToPdf.Click += new System.EventHandler(this.buttonToPdf_Click);
            // 
            // FormCustomerOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 598);
            this.Controls.Add(this.buttonToPdf);
            this.Controls.Add(this.buttonMake);
            this.Controls.Add(this.labelDataPickerTo);
            this.Controls.Add(this.labelDataPikerFrom);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.reportViewer);
            this.Name = "FormCustomerOrders";
            this.Text = "Заказы клиентов";
            this.Load += new System.EventHandler(this.FormCustomerOrders_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label labelDataPikerFrom;
        private System.Windows.Forms.Label labelDataPickerTo;
        private System.Windows.Forms.Button buttonMake;
        private System.Windows.Forms.Button buttonToPdf;
    }
}