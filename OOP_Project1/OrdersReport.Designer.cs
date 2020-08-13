namespace OOP_Project1
{
    partial class OrdersReport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.prodIDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OMSDataSet3 = new OOP_Project1.OMSDataSet3();
            this.ProdNameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OMSDataSet6 = new OOP_Project1.OMSDataSet6();
            this.CustNameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OMSDataSet7 = new OOP_Project1.OMSDataSet7();
            this.OrderDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OMSDataSet8 = new OOP_Project1.OMSDataSet8();
            this.OrderDateTimeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OMSDataSet10 = new OOP_Project1.OMSDataSet10();
            this.OverAllAmountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OMSDataSet11 = new OOP_Project1.OMSDataSet11();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.prodIDTableAdapter = new OOP_Project1.OMSDataSet3TableAdapters.prodIDTableAdapter();
            this.ProdNameTableAdapter = new OOP_Project1.OMSDataSet6TableAdapters.ProdNameTableAdapter();
            this.CustNameTableAdapter = new OOP_Project1.OMSDataSet7TableAdapters.CustNameTableAdapter();
            this.OrderDetailsTableAdapter = new OOP_Project1.OMSDataSet8TableAdapters.OrderDetailsTableAdapter();
            this.OrderDateTimeTableAdapter = new OOP_Project1.OMSDataSet10TableAdapters.OrderDateTimeTableAdapter();
            this.OverAllAmountTableAdapter = new OOP_Project1.OMSDataSet11TableAdapters.OverAllAmountTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.prodIDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OMSDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProdNameBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OMSDataSet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustNameBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OMSDataSet7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OMSDataSet8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDateTimeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OMSDataSet10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverAllAmountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OMSDataSet11)).BeginInit();
            this.SuspendLayout();
            // 
            // prodIDBindingSource
            // 
            this.prodIDBindingSource.DataMember = "prodID";
            this.prodIDBindingSource.DataSource = this.OMSDataSet3;
            // 
            // OMSDataSet3
            // 
            this.OMSDataSet3.DataSetName = "OMSDataSet3";
            this.OMSDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ProdNameBindingSource
            // 
            this.ProdNameBindingSource.DataMember = "ProdName";
            this.ProdNameBindingSource.DataSource = this.OMSDataSet6;
            // 
            // OMSDataSet6
            // 
            this.OMSDataSet6.DataSetName = "OMSDataSet6";
            this.OMSDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CustNameBindingSource
            // 
            this.CustNameBindingSource.DataMember = "CustName";
            this.CustNameBindingSource.DataSource = this.OMSDataSet7;
            // 
            // OMSDataSet7
            // 
            this.OMSDataSet7.DataSetName = "OMSDataSet7";
            this.OMSDataSet7.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // OrderDetailsBindingSource
            // 
            this.OrderDetailsBindingSource.DataMember = "OrderDetails";
            this.OrderDetailsBindingSource.DataSource = this.OMSDataSet8;
            // 
            // OMSDataSet8
            // 
            this.OMSDataSet8.DataSetName = "OMSDataSet8";
            this.OMSDataSet8.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // OrderDateTimeBindingSource
            // 
            this.OrderDateTimeBindingSource.DataMember = "OrderDateTime";
            this.OrderDateTimeBindingSource.DataSource = this.OMSDataSet10;
            // 
            // OMSDataSet10
            // 
            this.OMSDataSet10.DataSetName = "OMSDataSet10";
            this.OMSDataSet10.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // OverAllAmountBindingSource
            // 
            this.OverAllAmountBindingSource.DataMember = "OverAllAmount";
            this.OverAllAmountBindingSource.DataSource = this.OMSDataSet11;
            // 
            // OMSDataSet11
            // 
            this.OMSDataSet11.DataSetName = "OMSDataSet11";
            this.OMSDataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.prodIDBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.ProdNameBindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.CustNameBindingSource;
            reportDataSource4.Name = "DataSet4";
            reportDataSource4.Value = this.OrderDetailsBindingSource;
            reportDataSource5.Name = "DataSet5";
            reportDataSource5.Value = this.OrderDateTimeBindingSource;
            reportDataSource6.Name = "DataSet6";
            reportDataSource6.Value = this.OverAllAmountBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OOP_Project1.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1172, 651);
            this.reportViewer1.TabIndex = 0;
            // 
            // prodIDTableAdapter
            // 
            this.prodIDTableAdapter.ClearBeforeFill = true;
            // 
            // ProdNameTableAdapter
            // 
            this.ProdNameTableAdapter.ClearBeforeFill = true;
            // 
            // CustNameTableAdapter
            // 
            this.CustNameTableAdapter.ClearBeforeFill = true;
            // 
            // OrderDetailsTableAdapter
            // 
            this.OrderDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // OrderDateTimeTableAdapter
            // 
            this.OrderDateTimeTableAdapter.ClearBeforeFill = true;
            // 
            // OverAllAmountTableAdapter
            // 
            this.OverAllAmountTableAdapter.ClearBeforeFill = true;
            // 
            // OrdersReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 651);
            this.Controls.Add(this.reportViewer1);
            this.Name = "OrdersReport";
            this.Text = "OrdersReport";
            this.Load += new System.EventHandler(this.OrdersReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.prodIDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OMSDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProdNameBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OMSDataSet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustNameBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OMSDataSet7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OMSDataSet8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDateTimeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OMSDataSet10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverAllAmountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OMSDataSet11)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource prodIDBindingSource;
        private OMSDataSet3 OMSDataSet3;
        private OMSDataSet3TableAdapters.prodIDTableAdapter prodIDTableAdapter;
        private System.Windows.Forms.BindingSource ProdNameBindingSource;
        private OMSDataSet6 OMSDataSet6;
        private OMSDataSet6TableAdapters.ProdNameTableAdapter ProdNameTableAdapter;
        private System.Windows.Forms.BindingSource CustNameBindingSource;
        private OMSDataSet7 OMSDataSet7;
        private OMSDataSet7TableAdapters.CustNameTableAdapter CustNameTableAdapter;
        private System.Windows.Forms.BindingSource OrderDetailsBindingSource;
        private OMSDataSet8 OMSDataSet8;
        private OMSDataSet8TableAdapters.OrderDetailsTableAdapter OrderDetailsTableAdapter;
        private System.Windows.Forms.BindingSource OrderDateTimeBindingSource;
        private OMSDataSet10 OMSDataSet10;
        private System.Windows.Forms.BindingSource OverAllAmountBindingSource;
        private OMSDataSet11 OMSDataSet11;
        private OMSDataSet10TableAdapters.OrderDateTimeTableAdapter OrderDateTimeTableAdapter;
        private OMSDataSet11TableAdapters.OverAllAmountTableAdapter OverAllAmountTableAdapter;
    }
}