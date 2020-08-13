using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Project1
{
    public partial class OrdersReport : Form
    {
        public OrdersReport()
        {
            InitializeComponent();
        }

        private void OrdersReport_Load(object sender, EventArgs e)
        {
            refreshReport();
            this.reportViewer1.RefreshReport();
            IsMdiContainer = true;
            // TODO: This line of code loads data into the 'OMSDataSet10.OrderDateTime' table. You can move, or remove it, as needed.
            this.OrderDateTimeTableAdapter.Fill(this.OMSDataSet10.OrderDateTime);
            // TODO: This line of code loads data into the 'OMSDataSet11.OverAllAmount' table. You can move, or remove it, as needed.
            this.OverAllAmountTableAdapter.Fill(this.OMSDataSet11.OverAllAmount);
            // TODO: This line of code loads data into the 'OMSDataSet8.OrderDetails' table. You can move, or remove it, as needed.
            this.OrderDetailsTableAdapter.Fill(this.OMSDataSet8.OrderDetails);
            // TODO: This line of code loads data into the 'OMSDataSet7.CustName' table. You can move, or remove it, as needed.
            this.CustNameTableAdapter.Fill(this.OMSDataSet7.CustName);
            // TODO: This line of code loads data into the 'OMSDataSet6.ProdName' table. You can move, or remove it, as needed.
            this.ProdNameTableAdapter.Fill(this.OMSDataSet6.ProdName);
            // TODO: This line of code loads data into the 'OMSDataSet6.ProdName' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'OMSDataSet5.ProdName' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'OMSDataSet3.OverAllAmount' table. You can move, or remove it, as needed.
            //this.OverAllAmountTableAdapter.Fill(this.OMSDataSet3.OverAllAmount);
            // TODO: This line of code loads data into the 'OMSDataSet3.OverAllAmount' table. You can move, or remove it, as needed.
            //this.OverAllAmountTableAdapter.Fill(this.OMSDataSet3.OverAllAmount);
            // TODO: This line of code loads data into the 'OMSDataSet4.AllOrdersView' table. You can move, or remove it, as needed.
            this.prodIDTableAdapter.Fill(this.OMSDataSet3.prodID);
            this.reportViewer1.RefreshReport();
        }
        public void refreshReport()
        {
            
            this.reportViewer1.RefreshReport();
        }
    }
}
