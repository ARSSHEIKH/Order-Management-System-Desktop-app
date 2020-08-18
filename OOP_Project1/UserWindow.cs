using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Specialized;
using System.Windows.Forms;
namespace OOP_Project1
{
    public partial class UserWindow : Form
    {
        int count;
        int ind1;

        string[] selectedItemsFromGrid_NewOrder = new string[100];
        string[] SelectedProdNames = new string[10];
        public static string username;
        public static string strRadioBtn1, strRadioBtn2;
        public static bool strRadioBtn_Check1, strRadioBtn_Check2;
        string date = getDate();
        string time = getTime();
        bool SuperUser_Active = false;
        int checkedprevius = 0;
        int m = 0;
        GetValuesforOrder obj1 = new GetValuesforOrder();
        GetCustomerDetails obj2Cust = new GetCustomerDetails();
        GetProductsDetails obj3Prod = new GetProductsDetails();
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sync\Desktop\203-231\DataBaseApp\DBS_DesktopApp\OOP_Project1\OMS.mdf;Integrated Security=True;");

        public UserWindow()
        {
            InitializeComponent();
            panAddCust.Hide();
            panelCustDetails.Hide();
            ListBoxRefresh();
            //custRefreshGrid();

            Login log = new Login();
            if (strRadioBtn_Check1 == true)
            {
                strRadioBtn_Check1 = false;
                lblUser.Text = strRadioBtn1 + " " + username;
                panel3.Visible = false;
                panel1.Visible = true;
                panelOrder.Visible = true;
                btnUpdateCust.Visible = btnDeleteAllCust.Visible = btnDeleteCustomer.Visible = false;
                lnkAddCustomerFromSuper.Visible = lnkEditCustomer.Visible = false;
                panelProduct.Visible = panelAddNewProduct.Visible = panelEditProduct.Visible = false;
                panelCustDetails.Location = new Point(26, 60);
                panAddCust.Location = new Point(26, 90);
            }
            else if (strRadioBtn_Check2 == true)
            {
                SuperUser_Active = true;
                strRadioBtn_Check2 = false;
                panel3.Visible = true;
                panel1.Visible = false;
                panelOrder.Visible = false;
                lnkAddCustomerFromSuper.Visible = lnkEditCustomer.Visible = true;
                lblUser.Text = strRadioBtn2 + " " + username;
                panelProduct.Visible = panelAddNewProduct.Visible = panelEditProduct.Visible = true;
                btnUpdateCust.Visible = btnDeleteAllCust.Visible = btnDeleteCustomer.Visible = true;
            }
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserWindow));
            this.lblUser = new System.Windows.Forms.Label();
            this.LnkOrderNow = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnkUpdatesfromLocalUser = new System.Windows.Forms.Label();
            this.LnkOrdHistory_From_Local = new System.Windows.Forms.Label();
            this.lblAddCust = new System.Windows.Forms.Label();
            this.lblCustDetails = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lnkUpdates = new System.Windows.Forms.Label();
            this.lnkOrderHistory_from_Super = new System.Windows.Forms.Label();
            this.lnkCustomers = new System.Windows.Forms.Label();
            this.lnkProducts = new System.Windows.Forms.Label();
            this.lnkGenerateOrd = new System.Windows.Forms.Label();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.databaseDataSet = new OOP_Project1.DatabaseDataSet();
            this.databaseDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.customerBindingSource6 = new System.Windows.Forms.BindingSource(this.components);
            this.customerBindingSource8 = new System.Windows.Forms.BindingSource(this.components);
            this.customerBindingSource5 = new System.Windows.Forms.BindingSource(this.components);
            this.customerBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.LinkLogOut = new System.Windows.Forms.Label();
            this.customerBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.customerBindingSource7 = new System.Windows.Forms.BindingSource(this.components);
            this.lnkAddCustomerFromSuper = new System.Windows.Forms.Label();
            this.lnkEditCustomer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelCustomers = new System.Windows.Forms.Panel();
            this.panelCustDetails = new System.Windows.Forms.Panel();
            this.datagridviewCustInfo = new System.Windows.Forms.DataGridView();
            this.btnDeleteAllCust = new System.Windows.Forms.Button();
            this.btnDeleteCustomer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdateCust = new System.Windows.Forms.Button();
            this.panAddCust = new System.Windows.Forms.Panel();
            this.dateTimePickerDOB = new System.Windows.Forms.DateTimePicker();
            this.txtNic = new System.Windows.Forms.TextBox();
            this.lblNic = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnNewCustome = new System.Windows.Forms.Button();
            this.txtCustomerAddress = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtCustomerContact = new System.Windows.Forms.TextBox();
            this.txtCustomerEmailAddress = new System.Windows.Forms.TextBox();
            this.lblCustName = new System.Windows.Forms.Label();
            this.lblCont = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.panelNewOrder = new System.Windows.Forms.Panel();
            this.dataGridViewEditOrder = new System.Windows.Forms.DataGridView();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.btnDeleteProdFromOrder = new System.Windows.Forms.Button();
            this.BtnUpdateOrder = new System.Windows.Forms.Button();
            this.btnConfirmOrder = new System.Windows.Forms.Button();
            this.lblOverAllAmount = new System.Windows.Forms.Label();
            this.lblTotalAmountPerProd = new System.Windows.Forms.Label();
            this.comboBox_SelectedItemsList = new System.Windows.Forms.ComboBox();
            this.searchProd = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTypesOfProducts = new System.Windows.Forms.Label();
            this.listBoxNewOrdr_ProdTypes = new System.Windows.Forms.ListBox();
            this.productBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.oMSDataSet12 = new OOP_Project1.OMSDataSet12();
            this.lblHeaderLabel = new System.Windows.Forms.Label();
            this.lblSelectedItems = new System.Windows.Forms.Label();
            this.txtTotalItems = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantityPerProd = new System.Windows.Forms.TextBox();
            this.lblPriceUnit = new System.Windows.Forms.Label();
            this.lbProdName = new System.Windows.Forms.Label();
            this.lblCustNameOrd = new System.Windows.Forms.Label();
            this.txtCustName_For_Order = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtPriceUnit = new System.Windows.Forms.TextBox();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.lblProdDetails = new System.Windows.Forms.Label();
            this.dataGridViewNewOrd = new System.Windows.Forms.DataGridView();
            this.listboxNewOrder = new System.Windows.Forms.ListBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lnkNewOrder = new System.Windows.Forms.Label();
            this.linkEditOrder = new System.Windows.Forms.Label();
            this.panelOrder = new System.Windows.Forms.Panel();
            this.panelOrderHistory = new System.Windows.Forms.Panel();
            this.txtSearchBoxFromOrdHistory = new System.Windows.Forms.TextBox();
            this.dataGridViewOrderHistory = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.panelEditProduct = new System.Windows.Forms.Panel();
            this.dataGridViewEditProduct = new System.Windows.Forms.DataGridView();
            this.btnDeleteAllProducts_fromSuper = new System.Windows.Forms.Button();
            this.btnDeleteProduct_from_Products_Super = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.lnkAddProduct = new System.Windows.Forms.Label();
            this.lnkEditProduct = new System.Windows.Forms.Label();
            this.lblProducts = new System.Windows.Forms.Label();
            this.panelAddNewProduct = new System.Windows.Forms.Panel();
            this.dataGridViewAddNewProd = new System.Windows.Forms.DataGridView();
            this.lblProdId = new System.Windows.Forms.Label();
            this.dateTimePickerAddProd = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtPurchasingPrice = new System.Windows.Forms.TextBox();
            this.txtSupplyBy = new System.Windows.Forms.TextBox();
            this.txtTotalStockPurch = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnAddNewProduct = new System.Windows.Forms.Button();
            this.txtProdPrice = new System.Windows.Forms.TextBox();
            this.txtProdType = new System.Windows.Forms.TextBox();
            this.txtBrandName = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtProdName_Adding = new System.Windows.Forms.TextBox();
            this.panelProduct = new System.Windows.Forms.Panel();
            this.lnkProductUpdates = new System.Windows.Forms.Label();
            this.lnkCustomerUpdates = new System.Windows.Forms.Label();
            this.lnkOrdersUpdates = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridViewUpdates = new System.Windows.Forms.DataGridView();
            this.panelUpdate = new System.Windows.Forms.Panel();
            this.lblUpdatesInstructionDynamic = new System.Windows.Forms.Label();
            this.lblUpdateDynamic = new System.Windows.Forms.Label();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productTableAdapter1 = new OOP_Project1.OMSDataSet12TableAdapters.ProductTableAdapter();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource7)).BeginInit();
            this.panelCustomers.SuspendLayout();
            this.panelCustDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewCustInfo)).BeginInit();
            this.panAddCust.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelNewOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEditOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oMSDataSet12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNewOrd)).BeginInit();
            this.panelOrder.SuspendLayout();
            this.panelOrderHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderHistory)).BeginInit();
            this.panelEditProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEditProduct)).BeginInit();
            this.panelAddNewProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddNewProd)).BeginInit();
            this.panelProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUpdates)).BeginInit();
            this.panelUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.DimGray;
            this.lblUser.Location = new System.Drawing.Point(318, 9);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(108, 37);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "USER";
            // 
            // LnkOrderNow
            // 
            this.LnkOrderNow.AutoSize = true;
            this.LnkOrderNow.BackColor = System.Drawing.Color.DarkGreen;
            this.LnkOrderNow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LnkOrderNow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LnkOrderNow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LnkOrderNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnkOrderNow.ForeColor = System.Drawing.Color.Silver;
            this.LnkOrderNow.Location = new System.Drawing.Point(-9, 393);
            this.LnkOrderNow.Name = "LnkOrderNow";
            this.LnkOrderNow.Padding = new System.Windows.Forms.Padding(60, 10, 60, 10);
            this.LnkOrderNow.Size = new System.Drawing.Size(297, 47);
            this.LnkOrderNow.TabIndex = 1;
            this.LnkOrderNow.Text = "Generate Order";
            this.LnkOrderNow.Click += new System.EventHandler(this.label1_Click);
            this.LnkOrderNow.MouseLeave += new System.EventHandler(this.LnkOrderNow_MouseLeave);
            this.LnkOrderNow.MouseHover += new System.EventHandler(this.label1_hover);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lnkUpdatesfromLocalUser);
            this.panel1.Controls.Add(this.LnkOrdHistory_From_Local);
            this.panel1.Controls.Add(this.lblAddCust);
            this.panel1.Controls.Add(this.lblCustDetails);
            this.panel1.Controls.Add(this.LnkOrderNow);
            this.panel1.Location = new System.Drawing.Point(0, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 660);
            this.panel1.TabIndex = 0;
            this.panel1.Visible = false;
            // 
            // lnkUpdatesfromLocalUser
            // 
            this.lnkUpdatesfromLocalUser.AutoSize = true;
            this.lnkUpdatesfromLocalUser.BackColor = System.Drawing.Color.Transparent;
            this.lnkUpdatesfromLocalUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkUpdatesfromLocalUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkUpdatesfromLocalUser.ForeColor = System.Drawing.Color.Silver;
            this.lnkUpdatesfromLocalUser.Location = new System.Drawing.Point(27, 62);
            this.lnkUpdatesfromLocalUser.Name = "lnkUpdatesfromLocalUser";
            this.lnkUpdatesfromLocalUser.Padding = new System.Windows.Forms.Padding(10);
            this.lnkUpdatesfromLocalUser.Size = new System.Drawing.Size(97, 40);
            this.lnkUpdatesfromLocalUser.TabIndex = 6;
            this.lnkUpdatesfromLocalUser.Text = "Updates";
            this.lnkUpdatesfromLocalUser.Click += new System.EventHandler(this.lnkUpdatesfromLocalUser_Click);
            this.lnkUpdatesfromLocalUser.MouseLeave += new System.EventHandler(this.lnkUpdatesfromLocalUser_MouseLeave);
            this.lnkUpdatesfromLocalUser.MouseHover += new System.EventHandler(this.lnkUpdatesfromLocalUser_MouseHover);
            // 
            // LnkOrdHistory_From_Local
            // 
            this.LnkOrdHistory_From_Local.AutoSize = true;
            this.LnkOrdHistory_From_Local.BackColor = System.Drawing.Color.Transparent;
            this.LnkOrdHistory_From_Local.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LnkOrdHistory_From_Local.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnkOrdHistory_From_Local.ForeColor = System.Drawing.Color.Silver;
            this.LnkOrdHistory_From_Local.Location = new System.Drawing.Point(21, 256);
            this.LnkOrdHistory_From_Local.Name = "LnkOrdHistory_From_Local";
            this.LnkOrdHistory_From_Local.Padding = new System.Windows.Forms.Padding(10);
            this.LnkOrdHistory_From_Local.Size = new System.Drawing.Size(144, 40);
            this.LnkOrdHistory_From_Local.TabIndex = 4;
            this.LnkOrdHistory_From_Local.Text = "Orders History";
            this.LnkOrdHistory_From_Local.Click += new System.EventHandler(this.LnkOrdHistory_From_Local_Click);
            this.LnkOrdHistory_From_Local.MouseLeave += new System.EventHandler(this.LnkOrdHistory_From_Local_MouseLeave);
            this.LnkOrdHistory_From_Local.MouseHover += new System.EventHandler(this.LnkOrdHistory_From_Local_MouseHover);
            // 
            // lblAddCust
            // 
            this.lblAddCust.AutoSize = true;
            this.lblAddCust.BackColor = System.Drawing.Color.Transparent;
            this.lblAddCust.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAddCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddCust.ForeColor = System.Drawing.Color.Silver;
            this.lblAddCust.Location = new System.Drawing.Point(21, 127);
            this.lblAddCust.Name = "lblAddCust";
            this.lblAddCust.Padding = new System.Windows.Forms.Padding(10);
            this.lblAddCust.Size = new System.Drawing.Size(182, 40);
            this.lblAddCust.TabIndex = 3;
            this.lblAddCust.Text = "Add New Customer";
            this.lblAddCust.Click += new System.EventHandler(this.lblAddCust_Click);
            this.lblAddCust.MouseLeave += new System.EventHandler(this.lblAddCust_MouseLeave);
            this.lblAddCust.MouseHover += new System.EventHandler(this.lblAddCust_MouseHover);
            // 
            // lblCustDetails
            // 
            this.lblCustDetails.AutoSize = true;
            this.lblCustDetails.BackColor = System.Drawing.Color.Transparent;
            this.lblCustDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCustDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustDetails.ForeColor = System.Drawing.Color.Silver;
            this.lblCustDetails.Location = new System.Drawing.Point(21, 189);
            this.lblCustDetails.Name = "lblCustDetails";
            this.lblCustDetails.Padding = new System.Windows.Forms.Padding(10);
            this.lblCustDetails.Size = new System.Drawing.Size(167, 40);
            this.lblCustDetails.TabIndex = 2;
            this.lblCustDetails.Text = "Customer Details";
            this.lblCustDetails.Click += new System.EventHandler(this.lblCustDetails_Click);
            this.lblCustDetails.MouseLeave += new System.EventHandler(this.lblCustDetails_MouseLeave);
            this.lblCustDetails.MouseHover += new System.EventHandler(this.lblCustDetails_MouseHover);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Controls.Add(this.lnkUpdates);
            this.panel3.Controls.Add(this.lnkOrderHistory_from_Super);
            this.panel3.Controls.Add(this.lnkCustomers);
            this.panel3.Controls.Add(this.lnkProducts);
            this.panel3.Controls.Add(this.lnkGenerateOrd);
            this.panel3.Location = new System.Drawing.Point(3, 78);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(276, 676);
            this.panel3.TabIndex = 5;
            this.panel3.Visible = false;
            // 
            // lnkUpdates
            // 
            this.lnkUpdates.AutoSize = true;
            this.lnkUpdates.BackColor = System.Drawing.Color.Transparent;
            this.lnkUpdates.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkUpdates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkUpdates.ForeColor = System.Drawing.Color.Silver;
            this.lnkUpdates.Location = new System.Drawing.Point(21, 64);
            this.lnkUpdates.Name = "lnkUpdates";
            this.lnkUpdates.Padding = new System.Windows.Forms.Padding(10);
            this.lnkUpdates.Size = new System.Drawing.Size(97, 40);
            this.lnkUpdates.TabIndex = 5;
            this.lnkUpdates.Text = "Updates";
            this.lnkUpdates.Click += new System.EventHandler(this.lnkUpdates_Click);
            this.lnkUpdates.MouseLeave += new System.EventHandler(this.lnkUpdates_MouseLeave);
            this.lnkUpdates.MouseHover += new System.EventHandler(this.lnkUpdates_MouseHover);
            // 
            // lnkOrderHistory_from_Super
            // 
            this.lnkOrderHistory_from_Super.AutoSize = true;
            this.lnkOrderHistory_from_Super.BackColor = System.Drawing.Color.Transparent;
            this.lnkOrderHistory_from_Super.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkOrderHistory_from_Super.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkOrderHistory_from_Super.ForeColor = System.Drawing.Color.Silver;
            this.lnkOrderHistory_from_Super.Location = new System.Drawing.Point(21, 256);
            this.lnkOrderHistory_from_Super.Name = "lnkOrderHistory_from_Super";
            this.lnkOrderHistory_from_Super.Padding = new System.Windows.Forms.Padding(10);
            this.lnkOrderHistory_from_Super.Size = new System.Drawing.Size(144, 40);
            this.lnkOrderHistory_from_Super.TabIndex = 4;
            this.lnkOrderHistory_from_Super.Text = "Orders History";
            this.lnkOrderHistory_from_Super.Click += new System.EventHandler(this.lnkOrderHistory_from_Super_Click);
            this.lnkOrderHistory_from_Super.MouseLeave += new System.EventHandler(this.lnkOrderHistory_from_Super_MouseLeave);
            this.lnkOrderHistory_from_Super.MouseHover += new System.EventHandler(this.lnkOrderHistory_from_Super_MouseHover);
            // 
            // lnkCustomers
            // 
            this.lnkCustomers.AutoSize = true;
            this.lnkCustomers.BackColor = System.Drawing.Color.Transparent;
            this.lnkCustomers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCustomers.ForeColor = System.Drawing.Color.Silver;
            this.lnkCustomers.Location = new System.Drawing.Point(21, 127);
            this.lnkCustomers.Name = "lnkCustomers";
            this.lnkCustomers.Padding = new System.Windows.Forms.Padding(10);
            this.lnkCustomers.Size = new System.Drawing.Size(115, 40);
            this.lnkCustomers.TabIndex = 3;
            this.lnkCustomers.Text = "Customers";
            this.lnkCustomers.Click += new System.EventHandler(this.lnkCustomers_Click);
            this.lnkCustomers.MouseLeave += new System.EventHandler(this.lnkCustomers_MouseLeave);
            this.lnkCustomers.MouseHover += new System.EventHandler(this.lnkCustomers_MouseHover);
            // 
            // lnkProducts
            // 
            this.lnkProducts.AutoSize = true;
            this.lnkProducts.BackColor = System.Drawing.Color.Transparent;
            this.lnkProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkProducts.ForeColor = System.Drawing.Color.Silver;
            this.lnkProducts.Location = new System.Drawing.Point(21, 189);
            this.lnkProducts.Name = "lnkProducts";
            this.lnkProducts.Padding = new System.Windows.Forms.Padding(10);
            this.lnkProducts.Size = new System.Drawing.Size(100, 40);
            this.lnkProducts.TabIndex = 2;
            this.lnkProducts.Text = "Products";
            this.lnkProducts.Click += new System.EventHandler(this.lnkProducts_Click);
            this.lnkProducts.MouseLeave += new System.EventHandler(this.lnkProducts_MouseLeave);
            this.lnkProducts.MouseHover += new System.EventHandler(this.lnkProducts_MouseHover);
            // 
            // lnkGenerateOrd
            // 
            this.lnkGenerateOrd.AutoSize = true;
            this.lnkGenerateOrd.BackColor = System.Drawing.Color.DarkGreen;
            this.lnkGenerateOrd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lnkGenerateOrd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkGenerateOrd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lnkGenerateOrd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkGenerateOrd.ForeColor = System.Drawing.Color.Silver;
            this.lnkGenerateOrd.Location = new System.Drawing.Point(-9, 393);
            this.lnkGenerateOrd.Name = "lnkGenerateOrd";
            this.lnkGenerateOrd.Padding = new System.Windows.Forms.Padding(60, 10, 60, 10);
            this.lnkGenerateOrd.Size = new System.Drawing.Size(297, 47);
            this.lnkGenerateOrd.TabIndex = 1;
            this.lnkGenerateOrd.Text = "Generate Order";
            this.lnkGenerateOrd.Click += new System.EventHandler(this.lnkGenerateOrd_Click);
            this.lnkGenerateOrd.MouseLeave += new System.EventHandler(this.lnkGenerateOrd_MouseLeave);
            this.lnkGenerateOrd.MouseHover += new System.EventHandler(this.lnkGenerateOrd_MouseHover);
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataMember = "Customer";
            // 
            // customerBindingSource2
            // 
            this.customerBindingSource2.DataMember = "Customer";
            // 
            // databaseDataSet
            // 
            this.databaseDataSet.DataSetName = "DatabaseDataSet";
            this.databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // databaseDataSetBindingSource
            // 
            this.databaseDataSetBindingSource.DataSource = this.databaseDataSet;
            this.databaseDataSetBindingSource.Position = 0;
            // 
            // customerBindingSource6
            // 
            this.customerBindingSource6.DataMember = "Customer";
            // 
            // customerBindingSource8
            // 
            this.customerBindingSource8.DataMember = "Customer";
            // 
            // customerBindingSource5
            // 
            this.customerBindingSource5.DataMember = "Customer";
            // 
            // customerBindingSource3
            // 
            this.customerBindingSource3.DataMember = "Customer";
            // 
            // LinkLogOut
            // 
            this.LinkLogOut.AutoSize = true;
            this.LinkLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LinkLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkLogOut.ForeColor = System.Drawing.Color.DimGray;
            this.LinkLogOut.Location = new System.Drawing.Point(18, 38);
            this.LinkLogOut.Name = "LinkLogOut";
            this.LinkLogOut.Size = new System.Drawing.Size(84, 24);
            this.LinkLogOut.TabIndex = 5;
            this.LinkLogOut.Text = "Log Out";
            this.LinkLogOut.Click += new System.EventHandler(this.btnLogut1_Click);
            this.LinkLogOut.MouseLeave += new System.EventHandler(this.LinkLogOut_MouseLeave);
            this.LinkLogOut.MouseHover += new System.EventHandler(this.LinkLogOut_MouseHover);
            // 
            // customerBindingSource4
            // 
            this.customerBindingSource4.DataMember = "Customer";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // customerBindingSource7
            // 
            this.customerBindingSource7.DataMember = "Customer";
            // 
            // lnkAddCustomerFromSuper
            // 
            this.lnkAddCustomerFromSuper.AutoSize = true;
            this.lnkAddCustomerFromSuper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lnkAddCustomerFromSuper.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lnkAddCustomerFromSuper.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkAddCustomerFromSuper.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAddCustomerFromSuper.ForeColor = System.Drawing.Color.Azure;
            this.lnkAddCustomerFromSuper.Location = new System.Drawing.Point(43, 46);
            this.lnkAddCustomerFromSuper.Name = "lnkAddCustomerFromSuper";
            this.lnkAddCustomerFromSuper.Padding = new System.Windows.Forms.Padding(20);
            this.lnkAddCustomerFromSuper.Size = new System.Drawing.Size(307, 73);
            this.lnkAddCustomerFromSuper.TabIndex = 67;
            this.lnkAddCustomerFromSuper.Text = "Add New Customer";
            this.lnkAddCustomerFromSuper.Visible = false;
            this.lnkAddCustomerFromSuper.Click += new System.EventHandler(this.lnkAddCustomerFromSuper_Click);
            this.lnkAddCustomerFromSuper.MouseLeave += new System.EventHandler(this.lnkAddCustomerFromSuper_MouseLeave);
            this.lnkAddCustomerFromSuper.MouseHover += new System.EventHandler(this.lnkAddCustomerFromSuper_MouseHover);
            // 
            // lnkEditCustomer
            // 
            this.lnkEditCustomer.AutoSize = true;
            this.lnkEditCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lnkEditCustomer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lnkEditCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkEditCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkEditCustomer.ForeColor = System.Drawing.Color.Azure;
            this.lnkEditCustomer.Location = new System.Drawing.Point(525, 46);
            this.lnkEditCustomer.Name = "lnkEditCustomer";
            this.lnkEditCustomer.Padding = new System.Windows.Forms.Padding(20);
            this.lnkEditCustomer.Size = new System.Drawing.Size(241, 73);
            this.lnkEditCustomer.TabIndex = 68;
            this.lnkEditCustomer.Text = "Edit Customer";
            this.lnkEditCustomer.Visible = false;
            this.lnkEditCustomer.Click += new System.EventHandler(this.lnkEditCustomer_Click);
            this.lnkEditCustomer.MouseLeave += new System.EventHandler(this.lnkEditCustomer_MouseLeave);
            this.lnkEditCustomer.MouseHover += new System.EventHandler(this.lnkEditCustomer_MouseHover);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(383, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 29);
            this.label4.TabIndex = 64;
            this.label4.Text = "Customers";
            // 
            // panelCustomers
            // 
            this.panelCustomers.Controls.Add(this.label4);
            this.panelCustomers.Controls.Add(this.lnkEditCustomer);
            this.panelCustomers.Controls.Add(this.lnkAddCustomerFromSuper);
            this.panelCustomers.Controls.Add(this.panelCustDetails);
            this.panelCustomers.Controls.Add(this.panAddCust);
            this.panelCustomers.Location = new System.Drawing.Point(282, 107);
            this.panelCustomers.Name = "panelCustomers";
            this.panelCustomers.Size = new System.Drawing.Size(944, 622);
            this.panelCustomers.TabIndex = 7;
            this.panelCustomers.Visible = false;
            // 
            // panelCustDetails
            // 
            this.panelCustDetails.AllowDrop = true;
            this.panelCustDetails.AutoScroll = true;
            this.panelCustDetails.Controls.Add(this.datagridviewCustInfo);
            this.panelCustDetails.Controls.Add(this.btnDeleteAllCust);
            this.panelCustDetails.Controls.Add(this.btnDeleteCustomer);
            this.panelCustDetails.Controls.Add(this.label1);
            this.panelCustDetails.Controls.Add(this.btnUpdateCust);
            this.panelCustDetails.Location = new System.Drawing.Point(12, 131);
            this.panelCustDetails.Name = "panelCustDetails";
            this.panelCustDetails.Size = new System.Drawing.Size(948, 617);
            this.panelCustDetails.TabIndex = 0;
            this.panelCustDetails.Visible = false;
            // 
            // datagridviewCustInfo
            // 
            this.datagridviewCustInfo.BackgroundColor = System.Drawing.Color.White;
            this.datagridviewCustInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridviewCustInfo.GridColor = System.Drawing.Color.White;
            this.datagridviewCustInfo.Location = new System.Drawing.Point(11, 54);
            this.datagridviewCustInfo.Name = "datagridviewCustInfo";
            this.datagridviewCustInfo.Size = new System.Drawing.Size(919, 359);
            this.datagridviewCustInfo.TabIndex = 0;
            // 
            // btnDeleteAllCust
            // 
            this.btnDeleteAllCust.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDeleteAllCust.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAllCust.ForeColor = System.Drawing.Color.White;
            this.btnDeleteAllCust.Location = new System.Drawing.Point(480, 423);
            this.btnDeleteAllCust.Name = "btnDeleteAllCust";
            this.btnDeleteAllCust.Size = new System.Drawing.Size(111, 35);
            this.btnDeleteAllCust.TabIndex = 101;
            this.btnDeleteAllCust.Text = "Delete All";
            this.btnDeleteAllCust.UseVisualStyleBackColor = false;
            this.btnDeleteAllCust.Visible = false;
            this.btnDeleteAllCust.Click += new System.EventHandler(this.btnDeleteAllCust_Click);
            this.btnDeleteAllCust.MouseLeave += new System.EventHandler(this.btnDeleteAllCust_MouseLeave);
            this.btnDeleteAllCust.MouseHover += new System.EventHandler(this.btnDeleteAllCust_MouseHover);
            // 
            // btnDeleteCustomer
            // 
            this.btnDeleteCustomer.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDeleteCustomer.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCustomer.ForeColor = System.Drawing.Color.White;
            this.btnDeleteCustomer.Location = new System.Drawing.Point(356, 423);
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.Size = new System.Drawing.Size(104, 35);
            this.btnDeleteCustomer.TabIndex = 100;
            this.btnDeleteCustomer.Text = "Delete";
            this.btnDeleteCustomer.UseVisualStyleBackColor = false;
            this.btnDeleteCustomer.Visible = false;
            this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
            this.btnDeleteCustomer.MouseLeave += new System.EventHandler(this.btnDeleteCustomer_MouseLeave);
            this.btnDeleteCustomer.MouseHover += new System.EventHandler(this.btnDeleteCustomer_MouseHover);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(365, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 29);
            this.label1.TabIndex = 63;
            this.label1.Text = "CUSTOMER DETAILS";
            // 
            // btnUpdateCust
            // 
            this.btnUpdateCust.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdateCust.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateCust.ForeColor = System.Drawing.Color.White;
            this.btnUpdateCust.Location = new System.Drawing.Point(225, 423);
            this.btnUpdateCust.Name = "btnUpdateCust";
            this.btnUpdateCust.Size = new System.Drawing.Size(111, 35);
            this.btnUpdateCust.TabIndex = 99;
            this.btnUpdateCust.Text = "Update";
            this.btnUpdateCust.UseVisualStyleBackColor = false;
            this.btnUpdateCust.Visible = false;
            this.btnUpdateCust.Click += new System.EventHandler(this.btnUpdateCust_Click);
            this.btnUpdateCust.MouseLeave += new System.EventHandler(this.btnUpdateCust_MouseLeave);
            this.btnUpdateCust.MouseHover += new System.EventHandler(this.btnUpdateCust_MouseHover);
            // 
            // panAddCust
            // 
            this.panAddCust.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panAddCust.Controls.Add(this.dateTimePickerDOB);
            this.panAddCust.Controls.Add(this.txtNic);
            this.panAddCust.Controls.Add(this.lblNic);
            this.panAddCust.Controls.Add(this.label2);
            this.panAddCust.Controls.Add(this.listBox1);
            this.panAddCust.Controls.Add(this.btnRefresh);
            this.panAddCust.Controls.Add(this.label5);
            this.panAddCust.Controls.Add(this.btnNewCustome);
            this.panAddCust.Controls.Add(this.txtCustomerAddress);
            this.panAddCust.Controls.Add(this.dataGridView1);
            this.panAddCust.Controls.Add(this.txtCustomerContact);
            this.panAddCust.Controls.Add(this.txtCustomerEmailAddress);
            this.panAddCust.Controls.Add(this.lblCustName);
            this.panAddCust.Controls.Add(this.lblCont);
            this.panAddCust.Controls.Add(this.lblEmail);
            this.panAddCust.Controls.Add(this.lblAddress);
            this.panAddCust.Controls.Add(this.txtCustomerName);
            this.panAddCust.Location = new System.Drawing.Point(26, 119);
            this.panAddCust.Name = "panAddCust";
            this.panAddCust.Size = new System.Drawing.Size(964, 595);
            this.panAddCust.TabIndex = 3;
            this.panAddCust.Visible = false;
            // 
            // dateTimePickerDOB
            // 
            this.dateTimePickerDOB.Location = new System.Drawing.Point(276, 208);
            this.dateTimePickerDOB.Name = "dateTimePickerDOB";
            this.dateTimePickerDOB.Size = new System.Drawing.Size(245, 20);
            this.dateTimePickerDOB.TabIndex = 68;
            // 
            // txtNic
            // 
            this.txtNic.Location = new System.Drawing.Point(276, 179);
            this.txtNic.Name = "txtNic";
            this.txtNic.Size = new System.Drawing.Size(247, 20);
            this.txtNic.TabIndex = 67;
            // 
            // lblNic
            // 
            this.lblNic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNic.AutoSize = true;
            this.lblNic.BackColor = System.Drawing.Color.Transparent;
            this.lblNic.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblNic.Location = new System.Drawing.Point(56, 178);
            this.lblNic.Name = "lblNic";
            this.lblNic.Size = new System.Drawing.Size(137, 18);
            this.lblNic.TabIndex = 66;
            this.lblNic.Text = "National ID No.";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(55, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 18);
            this.label2.TabIndex = 65;
            this.label2.Text = "Date of Birth";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(702, 50);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(174, 225);
            this.listBox1.TabIndex = 64;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(879, 53);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(29, 33);
            this.btnRefresh.TabIndex = 63;
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(270, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(232, 29);
            this.label5.TabIndex = 62;
            this.label5.Text = "ADD NEW CUSTOMER";
            // 
            // btnNewCustome
            // 
            this.btnNewCustome.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnNewCustome.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCustome.ForeColor = System.Drawing.Color.White;
            this.btnNewCustome.Location = new System.Drawing.Point(57, 241);
            this.btnNewCustome.Name = "btnNewCustome";
            this.btnNewCustome.Size = new System.Drawing.Size(461, 42);
            this.btnNewCustome.TabIndex = 59;
            this.btnNewCustome.Text = "SUBMIT";
            this.btnNewCustome.UseVisualStyleBackColor = false;
            this.btnNewCustome.Click += new System.EventHandler(this.btnNewCustome_Click_1);
            this.btnNewCustome.MouseLeave += new System.EventHandler(this.btnNewCustome_MouseLeave);
            this.btnNewCustome.MouseHover += new System.EventHandler(this.btnNewCustome_MouseHover);
            // 
            // txtCustomerAddress
            // 
            this.txtCustomerAddress.Location = new System.Drawing.Point(274, 148);
            this.txtCustomerAddress.Name = "txtCustomerAddress";
            this.txtCustomerAddress.Size = new System.Drawing.Size(245, 20);
            this.txtCustomerAddress.TabIndex = 58;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.InfoText;
            this.dataGridView1.Location = new System.Drawing.Point(1, 287);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(910, 195);
            this.dataGridView1.TabIndex = 57;
            // 
            // txtCustomerContact
            // 
            this.txtCustomerContact.Location = new System.Drawing.Point(274, 87);
            this.txtCustomerContact.Name = "txtCustomerContact";
            this.txtCustomerContact.Size = new System.Drawing.Size(245, 20);
            this.txtCustomerContact.TabIndex = 56;
            this.txtCustomerContact.Text = "+923";
            // 
            // txtCustomerEmailAddress
            // 
            this.txtCustomerEmailAddress.Location = new System.Drawing.Point(274, 118);
            this.txtCustomerEmailAddress.Name = "txtCustomerEmailAddress";
            this.txtCustomerEmailAddress.Size = new System.Drawing.Size(247, 20);
            this.txtCustomerEmailAddress.TabIndex = 55;
            // 
            // lblCustName
            // 
            this.lblCustName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustName.AutoSize = true;
            this.lblCustName.BackColor = System.Drawing.Color.Transparent;
            this.lblCustName.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCustName.Location = new System.Drawing.Point(58, 59);
            this.lblCustName.Name = "lblCustName";
            this.lblCustName.Size = new System.Drawing.Size(140, 18);
            this.lblCustName.TabIndex = 53;
            this.lblCustName.Text = "Customer Name";
            // 
            // lblCont
            // 
            this.lblCont.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCont.AutoSize = true;
            this.lblCont.BackColor = System.Drawing.Color.Transparent;
            this.lblCont.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCont.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCont.Location = new System.Drawing.Point(58, 91);
            this.lblCont.Name = "lblCont";
            this.lblCont.Size = new System.Drawing.Size(100, 18);
            this.lblCont.TabIndex = 52;
            this.lblCont.Text = "Contact No";
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblEmail.Location = new System.Drawing.Point(56, 122);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(128, 18);
            this.lblEmail.TabIndex = 51;
            this.lblEmail.Text = "Email Address";
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAddress.AutoSize = true;
            this.lblAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblAddress.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblAddress.Location = new System.Drawing.Point(55, 151);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(75, 18);
            this.lblAddress.TabIndex = 50;
            this.lblAddress.Text = "Address";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(274, 59);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(245, 20);
            this.txtCustomerName.TabIndex = 54;
            // 
            // panelNewOrder
            // 
            this.panelNewOrder.Controls.Add(this.dataGridViewEditOrder);
            this.panelNewOrder.Controls.Add(this.btnDeleteOrder);
            this.panelNewOrder.Controls.Add(this.btnDeleteProdFromOrder);
            this.panelNewOrder.Controls.Add(this.BtnUpdateOrder);
            this.panelNewOrder.Controls.Add(this.btnConfirmOrder);
            this.panelNewOrder.Controls.Add(this.lblOverAllAmount);
            this.panelNewOrder.Controls.Add(this.lblTotalAmountPerProd);
            this.panelNewOrder.Controls.Add(this.comboBox_SelectedItemsList);
            this.panelNewOrder.Controls.Add(this.searchProd);
            this.panelNewOrder.Controls.Add(this.button1);
            this.panelNewOrder.Controls.Add(this.lblTypesOfProducts);
            this.panelNewOrder.Controls.Add(this.listBoxNewOrdr_ProdTypes);
            this.panelNewOrder.Controls.Add(this.lblHeaderLabel);
            this.panelNewOrder.Controls.Add(this.lblSelectedItems);
            this.panelNewOrder.Controls.Add(this.txtTotalItems);
            this.panelNewOrder.Controls.Add(this.lblQuantity);
            this.panelNewOrder.Controls.Add(this.txtQuantityPerProd);
            this.panelNewOrder.Controls.Add(this.lblPriceUnit);
            this.panelNewOrder.Controls.Add(this.lbProdName);
            this.panelNewOrder.Controls.Add(this.lblCustNameOrd);
            this.panelNewOrder.Controls.Add(this.txtCustName_For_Order);
            this.panelNewOrder.Controls.Add(this.txtProductName);
            this.panelNewOrder.Controls.Add(this.txtPriceUnit);
            this.panelNewOrder.Controls.Add(this.btnAddToList);
            this.panelNewOrder.Controls.Add(this.lblProdDetails);
            this.panelNewOrder.Controls.Add(this.dataGridViewNewOrd);
            this.panelNewOrder.Controls.Add(this.listboxNewOrder);
            this.panelNewOrder.Controls.Add(this.lblCustomerName);
            this.panelNewOrder.Location = new System.Drawing.Point(31, 150);
            this.panelNewOrder.Name = "panelNewOrder";
            this.panelNewOrder.Size = new System.Drawing.Size(886, 509);
            this.panelNewOrder.TabIndex = 67;
            // 
            // dataGridViewEditOrder
            // 
            this.dataGridViewEditOrder.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataGridViewEditOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEditOrder.Location = new System.Drawing.Point(7, 95);
            this.dataGridViewEditOrder.Name = "dataGridViewEditOrder";
            this.dataGridViewEditOrder.Size = new System.Drawing.Size(866, 228);
            this.dataGridViewEditOrder.TabIndex = 94;
            this.dataGridViewEditOrder.Visible = false;
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDeleteOrder.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteOrder.ForeColor = System.Drawing.Color.White;
            this.btnDeleteOrder.Location = new System.Drawing.Point(716, 363);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(125, 31);
            this.btnDeleteOrder.TabIndex = 98;
            this.btnDeleteOrder.Text = "Delete Order";
            this.btnDeleteOrder.UseVisualStyleBackColor = false;
            this.btnDeleteOrder.Visible = false;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            this.btnDeleteOrder.MouseLeave += new System.EventHandler(this.btnDeleteOrder_MouseLeave);
            this.btnDeleteOrder.MouseHover += new System.EventHandler(this.btnDeleteOrder_MouseHover);
            // 
            // btnDeleteProdFromOrder
            // 
            this.btnDeleteProdFromOrder.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDeleteProdFromOrder.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteProdFromOrder.ForeColor = System.Drawing.Color.White;
            this.btnDeleteProdFromOrder.Location = new System.Drawing.Point(537, 363);
            this.btnDeleteProdFromOrder.Name = "btnDeleteProdFromOrder";
            this.btnDeleteProdFromOrder.Size = new System.Drawing.Size(173, 31);
            this.btnDeleteProdFromOrder.TabIndex = 97;
            this.btnDeleteProdFromOrder.Text = "Delete Product";
            this.btnDeleteProdFromOrder.UseVisualStyleBackColor = false;
            this.btnDeleteProdFromOrder.Visible = false;
            this.btnDeleteProdFromOrder.Click += new System.EventHandler(this.btnDeleteProdFromOrder_Click);
            this.btnDeleteProdFromOrder.MouseLeave += new System.EventHandler(this.btnDeleteProdFromOrder_MouseLeave);
            this.btnDeleteProdFromOrder.MouseHover += new System.EventHandler(this.btnDeleteProdFromOrder_MouseHover);
            // 
            // BtnUpdateOrder
            // 
            this.BtnUpdateOrder.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnUpdateOrder.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUpdateOrder.ForeColor = System.Drawing.Color.White;
            this.BtnUpdateOrder.Location = new System.Drawing.Point(406, 363);
            this.BtnUpdateOrder.Name = "BtnUpdateOrder";
            this.BtnUpdateOrder.Size = new System.Drawing.Size(125, 31);
            this.BtnUpdateOrder.TabIndex = 96;
            this.BtnUpdateOrder.Text = "Update";
            this.BtnUpdateOrder.UseVisualStyleBackColor = false;
            this.BtnUpdateOrder.Visible = false;
            this.BtnUpdateOrder.Click += new System.EventHandler(this.BtnUpdateOrder_Click);
            this.BtnUpdateOrder.MouseLeave += new System.EventHandler(this.BtnUpdateOrder_MouseLeave);
            this.BtnUpdateOrder.MouseHover += new System.EventHandler(this.BtnUpdateOrder_MouseHover);
            // 
            // btnConfirmOrder
            // 
            this.btnConfirmOrder.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnConfirmOrder.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmOrder.ForeColor = System.Drawing.Color.White;
            this.btnConfirmOrder.Location = new System.Drawing.Point(704, 58);
            this.btnConfirmOrder.Name = "btnConfirmOrder";
            this.btnConfirmOrder.Size = new System.Drawing.Size(158, 31);
            this.btnConfirmOrder.TabIndex = 99;
            this.btnConfirmOrder.Text = "Confirm Order";
            this.btnConfirmOrder.UseVisualStyleBackColor = false;
            this.btnConfirmOrder.Visible = false;
            this.btnConfirmOrder.Click += new System.EventHandler(this.btnConfirmOrder_Click);
            this.btnConfirmOrder.MouseLeave += new System.EventHandler(this.btnConfirmOrder_MouseLeave);
            this.btnConfirmOrder.MouseHover += new System.EventHandler(this.btnConfirmOrder_MouseHover);
            // 
            // lblOverAllAmount
            // 
            this.lblOverAllAmount.AutoSize = true;
            this.lblOverAllAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblOverAllAmount.Font = new System.Drawing.Font("Calibri", 32F, System.Drawing.FontStyle.Bold);
            this.lblOverAllAmount.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblOverAllAmount.Location = new System.Drawing.Point(19, 370);
            this.lblOverAllAmount.Name = "lblOverAllAmount";
            this.lblOverAllAmount.Size = new System.Drawing.Size(322, 53);
            this.lblOverAllAmount.TabIndex = 95;
            this.lblOverAllAmount.Text = "Over All Amount";
            this.lblOverAllAmount.Visible = false;
            // 
            // lblTotalAmountPerProd
            // 
            this.lblTotalAmountPerProd.AutoSize = true;
            this.lblTotalAmountPerProd.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalAmountPerProd.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmountPerProd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTotalAmountPerProd.Location = new System.Drawing.Point(28, 254);
            this.lblTotalAmountPerProd.Name = "lblTotalAmountPerProd";
            this.lblTotalAmountPerProd.Size = new System.Drawing.Size(0, 17);
            this.lblTotalAmountPerProd.TabIndex = 93;
            this.lblTotalAmountPerProd.Visible = false;
            // 
            // comboBox_SelectedItemsList
            // 
            this.comboBox_SelectedItemsList.FormattingEnabled = true;
            this.comboBox_SelectedItemsList.Location = new System.Drawing.Point(540, 329);
            this.comboBox_SelectedItemsList.Name = "comboBox_SelectedItemsList";
            this.comboBox_SelectedItemsList.Size = new System.Drawing.Size(121, 21);
            this.comboBox_SelectedItemsList.TabIndex = 91;
            this.comboBox_SelectedItemsList.Tag = "";
            this.comboBox_SelectedItemsList.Text = "Selected Items";
            // 
            // searchProd
            // 
            this.searchProd.Location = new System.Drawing.Point(196, 329);
            this.searchProd.Name = "searchProd";
            this.searchProd.Size = new System.Drawing.Size(186, 20);
            this.searchProd.TabIndex = 90;
            this.searchProd.Text = "Seacrh Brand ...";
            this.searchProd.TextChanged += new System.EventHandler(this.SearchProd_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(25, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(379, 39);
            this.button1.TabIndex = 89;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.button1.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // lblTypesOfProducts
            // 
            this.lblTypesOfProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTypesOfProducts.AutoSize = true;
            this.lblTypesOfProducts.BackColor = System.Drawing.Color.Transparent;
            this.lblTypesOfProducts.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypesOfProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTypesOfProducts.Location = new System.Drawing.Point(467, 107);
            this.lblTypesOfProducts.Name = "lblTypesOfProducts";
            this.lblTypesOfProducts.Size = new System.Drawing.Size(131, 19);
            this.lblTypesOfProducts.TabIndex = 88;
            this.lblTypesOfProducts.Text = "Types of Products";
            // 
            // listBoxNewOrdr_ProdTypes
            // 
            this.listBoxNewOrdr_ProdTypes.DataSource = this.productBindingSource1;
            this.listBoxNewOrdr_ProdTypes.DisplayMember = "prod_type";
            this.listBoxNewOrdr_ProdTypes.FormattingEnabled = true;
            this.listBoxNewOrdr_ProdTypes.Location = new System.Drawing.Point(460, 135);
            this.listBoxNewOrdr_ProdTypes.Name = "listBoxNewOrdr_ProdTypes";
            this.listBoxNewOrdr_ProdTypes.Size = new System.Drawing.Size(186, 160);
            this.listBoxNewOrdr_ProdTypes.TabIndex = 87;
            this.listBoxNewOrdr_ProdTypes.ValueMember = "prod_id";
            this.listBoxNewOrdr_ProdTypes.Click += new System.EventHandler(this.ListBoxNewOrdr_ProdTypes_Click);
            // 
            // productBindingSource1
            // 
            this.productBindingSource1.DataMember = "Product";
            this.productBindingSource1.DataSource = this.oMSDataSet12;
            // 
            // oMSDataSet12
            // 
            this.oMSDataSet12.DataSetName = "OMSDataSet12";
            this.oMSDataSet12.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblHeaderLabel
            // 
            this.lblHeaderLabel.AutoSize = true;
            this.lblHeaderLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderLabel.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblHeaderLabel.Location = new System.Drawing.Point(367, 21);
            this.lblHeaderLabel.Name = "lblHeaderLabel";
            this.lblHeaderLabel.Size = new System.Drawing.Size(160, 26);
            this.lblHeaderLabel.TabIndex = 86;
            this.lblHeaderLabel.Text = "NEW ORDER";
            // 
            // lblSelectedItems
            // 
            this.lblSelectedItems.AutoSize = true;
            this.lblSelectedItems.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectedItems.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblSelectedItems.Location = new System.Drawing.Point(28, 109);
            this.lblSelectedItems.Name = "lblSelectedItems";
            this.lblSelectedItems.Size = new System.Drawing.Size(174, 18);
            this.lblSelectedItems.TabIndex = 85;
            this.lblSelectedItems.Text = "No. of Selected Item";
            // 
            // txtTotalItems
            // 
            this.txtTotalItems.Location = new System.Drawing.Point(218, 109);
            this.txtTotalItems.Name = "txtTotalItems";
            this.txtTotalItems.Size = new System.Drawing.Size(186, 20);
            this.txtTotalItems.TabIndex = 84;
            this.txtTotalItems.Text = "0";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.BackColor = System.Drawing.Color.Transparent;
            this.lblQuantity.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblQuantity.Location = new System.Drawing.Point(28, 224);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(82, 18);
            this.lblQuantity.TabIndex = 81;
            this.lblQuantity.Text = "Quantity";
            // 
            // txtQuantityPerProd
            // 
            this.txtQuantityPerProd.Location = new System.Drawing.Point(218, 224);
            this.txtQuantityPerProd.Name = "txtQuantityPerProd";
            this.txtQuantityPerProd.Size = new System.Drawing.Size(186, 20);
            this.txtQuantityPerProd.TabIndex = 80;
            this.txtQuantityPerProd.Text = "00";
            // 
            // lblPriceUnit
            // 
            this.lblPriceUnit.AutoSize = true;
            this.lblPriceUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblPriceUnit.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblPriceUnit.Location = new System.Drawing.Point(28, 186);
            this.lblPriceUnit.Name = "lblPriceUnit";
            this.lblPriceUnit.Size = new System.Drawing.Size(88, 18);
            this.lblPriceUnit.TabIndex = 79;
            this.lblPriceUnit.Text = "PriceUnit";
            // 
            // lbProdName
            // 
            this.lbProdName.AutoSize = true;
            this.lbProdName.BackColor = System.Drawing.Color.Transparent;
            this.lbProdName.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProdName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbProdName.Location = new System.Drawing.Point(28, 151);
            this.lbProdName.Name = "lbProdName";
            this.lbProdName.Size = new System.Drawing.Size(135, 18);
            this.lbProdName.TabIndex = 78;
            this.lbProdName.Text = "Products Name";
            // 
            // lblCustNameOrd
            // 
            this.lblCustNameOrd.AutoSize = true;
            this.lblCustNameOrd.BackColor = System.Drawing.Color.Transparent;
            this.lblCustNameOrd.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustNameOrd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCustNameOrd.Location = new System.Drawing.Point(28, 68);
            this.lblCustNameOrd.Name = "lblCustNameOrd";
            this.lblCustNameOrd.Size = new System.Drawing.Size(140, 18);
            this.lblCustNameOrd.TabIndex = 77;
            this.lblCustNameOrd.Text = "Customer Name";
            // 
            // txtCustName_For_Order
            // 
            this.txtCustName_For_Order.Location = new System.Drawing.Point(218, 73);
            this.txtCustName_For_Order.Name = "txtCustName_For_Order";
            this.txtCustName_For_Order.Size = new System.Drawing.Size(186, 20);
            this.txtCustName_For_Order.TabIndex = 76;
            this.txtCustName_For_Order.Text = "Choose Customer From ListBox";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(218, 148);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(186, 20);
            this.txtProductName.TabIndex = 75;
            // 
            // txtPriceUnit
            // 
            this.txtPriceUnit.Location = new System.Drawing.Point(218, 186);
            this.txtPriceUnit.Name = "txtPriceUnit";
            this.txtPriceUnit.Size = new System.Drawing.Size(186, 20);
            this.txtPriceUnit.TabIndex = 74;
            // 
            // btnAddToList
            // 
            this.btnAddToList.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddToList.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToList.ForeColor = System.Drawing.Color.White;
            this.btnAddToList.Location = new System.Drawing.Point(677, 327);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(186, 26);
            this.btnAddToList.TabIndex = 73;
            this.btnAddToList.Text = "Add To List";
            this.btnAddToList.UseVisualStyleBackColor = false;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            this.btnAddToList.MouseLeave += new System.EventHandler(this.btnAddToList_MouseLeave);
            this.btnAddToList.MouseHover += new System.EventHandler(this.btnAddToList_MouseHover);
            // 
            // lblProdDetails
            // 
            this.lblProdDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProdDetails.AutoSize = true;
            this.lblProdDetails.BackColor = System.Drawing.Color.Transparent;
            this.lblProdDetails.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblProdDetails.Location = new System.Drawing.Point(2, 326);
            this.lblProdDetails.Name = "lblProdDetails";
            this.lblProdDetails.Size = new System.Drawing.Size(154, 23);
            this.lblProdDetails.TabIndex = 72;
            this.lblProdDetails.Text = "PRODUCT DETAILS";
            // 
            // dataGridViewNewOrd
            // 
            this.dataGridViewNewOrd.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataGridViewNewOrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNewOrd.Location = new System.Drawing.Point(9, 352);
            this.dataGridViewNewOrd.Name = "dataGridViewNewOrd";
            this.dataGridViewNewOrd.Size = new System.Drawing.Size(859, 150);
            this.dataGridViewNewOrd.TabIndex = 71;
            this.dataGridViewNewOrd.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewNewOrd_CellContentClick);
            // 
            // listboxNewOrder
            // 
            this.listboxNewOrder.DataSource = this.customerBindingSource8;
            this.listboxNewOrder.DisplayMember = "cust_name";
            this.listboxNewOrder.FormattingEnabled = true;
            this.listboxNewOrder.Location = new System.Drawing.Point(687, 135);
            this.listboxNewOrder.Name = "listboxNewOrder";
            this.listboxNewOrder.Size = new System.Drawing.Size(186, 160);
            this.listboxNewOrder.TabIndex = 70;
            this.listboxNewOrder.ValueMember = "Id";
            this.listboxNewOrder.Click += new System.EventHandler(this.ListboxNewOrder_Click);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomerName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCustomerName.Location = new System.Drawing.Point(683, 102);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(140, 19);
            this.lblCustomerName.TabIndex = 69;
            this.lblCustomerName.Text = "CUSTOMERS NAME";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(393, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 29);
            this.label3.TabIndex = 63;
            this.label3.Text = "GENERATE ORDER";
            // 
            // lnkNewOrder
            // 
            this.lnkNewOrder.AutoSize = true;
            this.lnkNewOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lnkNewOrder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lnkNewOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkNewOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkNewOrder.ForeColor = System.Drawing.Color.Azure;
            this.lnkNewOrder.Location = new System.Drawing.Point(78, 77);
            this.lnkNewOrder.Name = "lnkNewOrder";
            this.lnkNewOrder.Padding = new System.Windows.Forms.Padding(60, 20, 60, 20);
            this.lnkNewOrder.Size = new System.Drawing.Size(372, 73);
            this.lnkNewOrder.TabIndex = 64;
            this.lnkNewOrder.Text = "Create New Order";
            this.lnkNewOrder.Click += new System.EventHandler(this.LnkNewOrder_Click);
            this.lnkNewOrder.MouseLeave += new System.EventHandler(this.linkNewOrder_MouseLeave);
            this.lnkNewOrder.MouseHover += new System.EventHandler(this.linkNewOrder_MouseHover);
            // 
            // linkEditOrder
            // 
            this.linkEditOrder.AutoSize = true;
            this.linkEditOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.linkEditOrder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkEditOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkEditOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkEditOrder.ForeColor = System.Drawing.Color.Azure;
            this.linkEditOrder.Location = new System.Drawing.Point(546, 75);
            this.linkEditOrder.Name = "linkEditOrder";
            this.linkEditOrder.Padding = new System.Windows.Forms.Padding(60, 20, 60, 20);
            this.linkEditOrder.Size = new System.Drawing.Size(269, 73);
            this.linkEditOrder.TabIndex = 65;
            this.linkEditOrder.Text = "Edit Order";
            this.linkEditOrder.Click += new System.EventHandler(this.linkEditOrder_Click);
            this.linkEditOrder.MouseLeave += new System.EventHandler(this.linkEditOrder_MouseLeave);
            this.linkEditOrder.MouseHover += new System.EventHandler(this.linkEditOrder_MouseHover);
            // 
            // panelOrder
            // 
            this.panelOrder.Controls.Add(this.linkEditOrder);
            this.panelOrder.Controls.Add(this.lnkNewOrder);
            this.panelOrder.Controls.Add(this.label3);
            this.panelOrder.Controls.Add(this.panelNewOrder);
            this.panelOrder.Location = new System.Drawing.Point(293, 62);
            this.panelOrder.Name = "panelOrder";
            this.panelOrder.Size = new System.Drawing.Size(963, 675);
            this.panelOrder.TabIndex = 6;
            this.panelOrder.Visible = false;
            // 
            // panelOrderHistory
            // 
            this.panelOrderHistory.Controls.Add(this.txtSearchBoxFromOrdHistory);
            this.panelOrderHistory.Controls.Add(this.dataGridViewOrderHistory);
            this.panelOrderHistory.Controls.Add(this.label6);
            this.panelOrderHistory.Location = new System.Drawing.Point(282, 89);
            this.panelOrderHistory.Name = "panelOrderHistory";
            this.panelOrderHistory.Size = new System.Drawing.Size(975, 621);
            this.panelOrderHistory.TabIndex = 71;
            this.panelOrderHistory.Visible = false;
            // 
            // txtSearchBoxFromOrdHistory
            // 
            this.txtSearchBoxFromOrdHistory.Location = new System.Drawing.Point(31, 98);
            this.txtSearchBoxFromOrdHistory.Name = "txtSearchBoxFromOrdHistory";
            this.txtSearchBoxFromOrdHistory.Size = new System.Drawing.Size(279, 20);
            this.txtSearchBoxFromOrdHistory.TabIndex = 96;
            this.txtSearchBoxFromOrdHistory.Text = "Search ...";
            this.txtSearchBoxFromOrdHistory.TextChanged += new System.EventHandler(this.txtSearchBoxFromOrdHistory_TextChanged);
            // 
            // dataGridViewOrderHistory
            // 
            this.dataGridViewOrderHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderHistory.Location = new System.Drawing.Point(26, 125);
            this.dataGridViewOrderHistory.Name = "dataGridViewOrderHistory";
            this.dataGridViewOrderHistory.ShowCellToolTips = false;
            this.dataGridViewOrderHistory.Size = new System.Drawing.Size(921, 477);
            this.dataGridViewOrderHistory.TabIndex = 95;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(405, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 29);
            this.label6.TabIndex = 64;
            this.label6.Text = "Orders History";
            // 
            // panelEditProduct
            // 
            this.panelEditProduct.AllowDrop = true;
            this.panelEditProduct.AutoScroll = true;
            this.panelEditProduct.Controls.Add(this.dataGridViewEditProduct);
            this.panelEditProduct.Controls.Add(this.btnDeleteAllProducts_fromSuper);
            this.panelEditProduct.Controls.Add(this.btnDeleteProduct_from_Products_Super);
            this.panelEditProduct.Controls.Add(this.label14);
            this.panelEditProduct.Controls.Add(this.btnUpdateProduct);
            this.panelEditProduct.Location = new System.Drawing.Point(11, 177);
            this.panelEditProduct.Name = "panelEditProduct";
            this.panelEditProduct.Size = new System.Drawing.Size(971, 563);
            this.panelEditProduct.TabIndex = 73;
            this.panelEditProduct.Visible = false;
            // 
            // dataGridViewEditProduct
            // 
            this.dataGridViewEditProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEditProduct.Location = new System.Drawing.Point(15, 78);
            this.dataGridViewEditProduct.Name = "dataGridViewEditProduct";
            this.dataGridViewEditProduct.Size = new System.Drawing.Size(950, 341);
            this.dataGridViewEditProduct.TabIndex = 74;
            // 
            // btnDeleteAllProducts_fromSuper
            // 
            this.btnDeleteAllProducts_fromSuper.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDeleteAllProducts_fromSuper.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAllProducts_fromSuper.ForeColor = System.Drawing.Color.White;
            this.btnDeleteAllProducts_fromSuper.Location = new System.Drawing.Point(485, 428);
            this.btnDeleteAllProducts_fromSuper.Name = "btnDeleteAllProducts_fromSuper";
            this.btnDeleteAllProducts_fromSuper.Size = new System.Drawing.Size(162, 35);
            this.btnDeleteAllProducts_fromSuper.TabIndex = 101;
            this.btnDeleteAllProducts_fromSuper.Text = "Delete All Products";
            this.btnDeleteAllProducts_fromSuper.UseVisualStyleBackColor = false;
            this.btnDeleteAllProducts_fromSuper.Click += new System.EventHandler(this.btnDeleteAllProducts_fromSuper_Click);
            this.btnDeleteAllProducts_fromSuper.MouseLeave += new System.EventHandler(this.btnDeleteAllProducts_fromSuper_MouseLeave);
            this.btnDeleteAllProducts_fromSuper.MouseHover += new System.EventHandler(this.btnDeleteAllProducts_fromSuper_MouseHover);
            // 
            // btnDeleteProduct_from_Products_Super
            // 
            this.btnDeleteProduct_from_Products_Super.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDeleteProduct_from_Products_Super.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteProduct_from_Products_Super.ForeColor = System.Drawing.Color.White;
            this.btnDeleteProduct_from_Products_Super.Location = new System.Drawing.Point(346, 429);
            this.btnDeleteProduct_from_Products_Super.Name = "btnDeleteProduct_from_Products_Super";
            this.btnDeleteProduct_from_Products_Super.Size = new System.Drawing.Size(131, 35);
            this.btnDeleteProduct_from_Products_Super.TabIndex = 100;
            this.btnDeleteProduct_from_Products_Super.Text = "Delete Product";
            this.btnDeleteProduct_from_Products_Super.UseVisualStyleBackColor = false;
            this.btnDeleteProduct_from_Products_Super.Click += new System.EventHandler(this.btnDeleteProduct_from_Products_Super_Click);
            this.btnDeleteProduct_from_Products_Super.MouseLeave += new System.EventHandler(this.btnDeleteProduct_from_Products_Super_MouseLeave);
            this.btnDeleteProduct_from_Products_Super.MouseHover += new System.EventHandler(this.btnDeleteProduct_from_Products_Super_MouseHover);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(360, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(207, 29);
            this.label14.TabIndex = 63;
            this.label14.Text = "PRODUCTS DETAILS";
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdateProduct.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateProduct.ForeColor = System.Drawing.Color.White;
            this.btnUpdateProduct.Location = new System.Drawing.Point(202, 429);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(138, 35);
            this.btnUpdateProduct.TabIndex = 99;
            this.btnUpdateProduct.Text = "Update Product";
            this.btnUpdateProduct.UseVisualStyleBackColor = false;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            this.btnUpdateProduct.MouseLeave += new System.EventHandler(this.btnUpdateProduct_MouseLeave);
            this.btnUpdateProduct.MouseHover += new System.EventHandler(this.btnUpdateProduct_MouseHover);
            // 
            // lnkAddProduct
            // 
            this.lnkAddProduct.AutoSize = true;
            this.lnkAddProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lnkAddProduct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lnkAddProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkAddProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAddProduct.ForeColor = System.Drawing.Color.Azure;
            this.lnkAddProduct.Location = new System.Drawing.Point(43, 29);
            this.lnkAddProduct.Name = "lnkAddProduct";
            this.lnkAddProduct.Padding = new System.Windows.Forms.Padding(60, 20, 60, 20);
            this.lnkAddProduct.Size = new System.Drawing.Size(362, 73);
            this.lnkAddProduct.TabIndex = 67;
            this.lnkAddProduct.Text = "Add New Product";
            this.lnkAddProduct.Click += new System.EventHandler(this.lnkAddProduct_Click);
            this.lnkAddProduct.MouseLeave += new System.EventHandler(this.lnkAddProduct_MouseLeave);
            this.lnkAddProduct.MouseHover += new System.EventHandler(this.lnkAddProduct_MouseHover);
            // 
            // lnkEditProduct
            // 
            this.lnkEditProduct.AutoSize = true;
            this.lnkEditProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lnkEditProduct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lnkEditProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkEditProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkEditProduct.ForeColor = System.Drawing.Color.Azure;
            this.lnkEditProduct.Location = new System.Drawing.Point(542, 29);
            this.lnkEditProduct.Name = "lnkEditProduct";
            this.lnkEditProduct.Padding = new System.Windows.Forms.Padding(60, 20, 60, 20);
            this.lnkEditProduct.Size = new System.Drawing.Size(296, 73);
            this.lnkEditProduct.TabIndex = 68;
            this.lnkEditProduct.Text = "Edit Product";
            this.lnkEditProduct.Click += new System.EventHandler(this.lnkEditProduct_Click);
            this.lnkEditProduct.MouseLeave += new System.EventHandler(this.lnkEditProduct_MouseLeave);
            this.lnkEditProduct.MouseHover += new System.EventHandler(this.lnkEditProduct_MouseHover);
            // 
            // lblProducts
            // 
            this.lblProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProducts.AutoSize = true;
            this.lblProducts.BackColor = System.Drawing.Color.Transparent;
            this.lblProducts.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblProducts.Location = new System.Drawing.Point(421, 0);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(102, 29);
            this.lblProducts.TabIndex = 64;
            this.lblProducts.Text = "Products";
            // 
            // panelAddNewProduct
            // 
            this.panelAddNewProduct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelAddNewProduct.Controls.Add(this.dataGridViewAddNewProd);
            this.panelAddNewProduct.Controls.Add(this.lblProdId);
            this.panelAddNewProduct.Controls.Add(this.dateTimePickerAddProd);
            this.panelAddNewProduct.Controls.Add(this.label22);
            this.panelAddNewProduct.Controls.Add(this.label23);
            this.panelAddNewProduct.Controls.Add(this.txtPurchasingPrice);
            this.panelAddNewProduct.Controls.Add(this.txtSupplyBy);
            this.panelAddNewProduct.Controls.Add(this.txtTotalStockPurch);
            this.panelAddNewProduct.Controls.Add(this.label15);
            this.panelAddNewProduct.Controls.Add(this.label16);
            this.panelAddNewProduct.Controls.Add(this.label17);
            this.panelAddNewProduct.Controls.Add(this.btnAddNewProduct);
            this.panelAddNewProduct.Controls.Add(this.txtProdPrice);
            this.panelAddNewProduct.Controls.Add(this.txtProdType);
            this.panelAddNewProduct.Controls.Add(this.txtBrandName);
            this.panelAddNewProduct.Controls.Add(this.label18);
            this.panelAddNewProduct.Controls.Add(this.label19);
            this.panelAddNewProduct.Controls.Add(this.label20);
            this.panelAddNewProduct.Controls.Add(this.label21);
            this.panelAddNewProduct.Controls.Add(this.txtProdName_Adding);
            this.panelAddNewProduct.Location = new System.Drawing.Point(21, 103);
            this.panelAddNewProduct.Name = "panelAddNewProduct";
            this.panelAddNewProduct.Size = new System.Drawing.Size(975, 558);
            this.panelAddNewProduct.TabIndex = 102;
            this.panelAddNewProduct.Visible = false;
            // 
            // dataGridViewAddNewProd
            // 
            this.dataGridViewAddNewProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAddNewProd.Location = new System.Drawing.Point(11, 366);
            this.dataGridViewAddNewProd.Name = "dataGridViewAddNewProd";
            this.dataGridViewAddNewProd.Size = new System.Drawing.Size(923, 162);
            this.dataGridViewAddNewProd.TabIndex = 75;
            // 
            // lblProdId
            // 
            this.lblProdId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProdId.AutoSize = true;
            this.lblProdId.BackColor = System.Drawing.Color.Transparent;
            this.lblProdId.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblProdId.Location = new System.Drawing.Point(49, 25);
            this.lblProdId.Name = "lblProdId";
            this.lblProdId.Size = new System.Drawing.Size(98, 18);
            this.lblProdId.TabIndex = 74;
            this.lblProdId.Text = "Product Id";
            // 
            // dateTimePickerAddProd
            // 
            this.dateTimePickerAddProd.Location = new System.Drawing.Point(268, 284);
            this.dateTimePickerAddProd.Name = "dateTimePickerAddProd";
            this.dateTimePickerAddProd.Size = new System.Drawing.Size(240, 20);
            this.dateTimePickerAddProd.TabIndex = 73;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label22.Location = new System.Drawing.Point(46, 251);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(149, 18);
            this.label22.TabIndex = 72;
            this.label22.Text = "Purchasing Price";
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label23.Location = new System.Drawing.Point(45, 282);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(147, 18);
            this.label23.TabIndex = 71;
            this.label23.Text = "Date of Purchase";
            // 
            // txtPurchasingPrice
            // 
            this.txtPurchasingPrice.Location = new System.Drawing.Point(269, 253);
            this.txtPurchasingPrice.Name = "txtPurchasingPrice";
            this.txtPurchasingPrice.Size = new System.Drawing.Size(247, 20);
            this.txtPurchasingPrice.TabIndex = 69;
            // 
            // txtSupplyBy
            // 
            this.txtSupplyBy.Location = new System.Drawing.Point(269, 217);
            this.txtSupplyBy.Name = "txtSupplyBy";
            this.txtSupplyBy.Size = new System.Drawing.Size(247, 20);
            this.txtSupplyBy.TabIndex = 68;
            // 
            // txtTotalStockPurch
            // 
            this.txtTotalStockPurch.Location = new System.Drawing.Point(270, 184);
            this.txtTotalStockPurch.Name = "txtTotalStockPurch";
            this.txtTotalStockPurch.Size = new System.Drawing.Size(247, 20);
            this.txtTotalStockPurch.TabIndex = 67;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label15.Location = new System.Drawing.Point(47, 183);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(135, 18);
            this.label15.TabIndex = 66;
            this.label15.Text = "Stock Purchase";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label16.Location = new System.Drawing.Point(46, 218);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 18);
            this.label16.TabIndex = 65;
            this.label16.Text = "Supply By";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label17.Location = new System.Drawing.Point(341, 5);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(217, 29);
            this.label17.TabIndex = 62;
            this.label17.Text = "ADD NEW PRODUCT";
            // 
            // btnAddNewProduct
            // 
            this.btnAddNewProduct.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddNewProduct.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewProduct.ForeColor = System.Drawing.Color.White;
            this.btnAddNewProduct.Location = new System.Drawing.Point(49, 312);
            this.btnAddNewProduct.Name = "btnAddNewProduct";
            this.btnAddNewProduct.Size = new System.Drawing.Size(461, 41);
            this.btnAddNewProduct.TabIndex = 59;
            this.btnAddNewProduct.Text = "SUBMIT";
            this.btnAddNewProduct.UseVisualStyleBackColor = false;
            this.btnAddNewProduct.Click += new System.EventHandler(this.btnAddNewProduct_Click);
            this.btnAddNewProduct.MouseLeave += new System.EventHandler(this.btnAddNewProduct_MouseLeave);
            this.btnAddNewProduct.MouseHover += new System.EventHandler(this.btnAddNewProduct_MouseHover);
            // 
            // txtProdPrice
            // 
            this.txtProdPrice.Location = new System.Drawing.Point(270, 150);
            this.txtProdPrice.Name = "txtProdPrice";
            this.txtProdPrice.Size = new System.Drawing.Size(245, 20);
            this.txtProdPrice.TabIndex = 58;
            // 
            // txtProdType
            // 
            this.txtProdType.Location = new System.Drawing.Point(270, 84);
            this.txtProdType.Name = "txtProdType";
            this.txtProdType.Size = new System.Drawing.Size(245, 20);
            this.txtProdType.TabIndex = 56;
            // 
            // txtBrandName
            // 
            this.txtBrandName.Location = new System.Drawing.Point(268, 117);
            this.txtBrandName.Name = "txtBrandName";
            this.txtBrandName.Size = new System.Drawing.Size(247, 20);
            this.txtBrandName.TabIndex = 55;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label18.Location = new System.Drawing.Point(46, 54);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(127, 18);
            this.label18.TabIndex = 53;
            this.label18.Text = "Product Name";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label19.Location = new System.Drawing.Point(45, 83);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(120, 18);
            this.label19.TabIndex = 52;
            this.label19.Text = "Product Type";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label20.Location = new System.Drawing.Point(47, 116);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(111, 18);
            this.label20.TabIndex = 51;
            this.label20.Text = "Brand Name";
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label21.Location = new System.Drawing.Point(46, 151);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(122, 18);
            this.label21.TabIndex = 50;
            this.label21.Text = "Product Price";
            // 
            // txtProdName_Adding
            // 
            this.txtProdName_Adding.Location = new System.Drawing.Point(270, 55);
            this.txtProdName_Adding.Name = "txtProdName_Adding";
            this.txtProdName_Adding.Size = new System.Drawing.Size(245, 20);
            this.txtProdName_Adding.TabIndex = 54;
            // 
            // panelProduct
            // 
            this.panelProduct.Controls.Add(this.lblProducts);
            this.panelProduct.Controls.Add(this.lnkEditProduct);
            this.panelProduct.Controls.Add(this.lnkAddProduct);
            this.panelProduct.Controls.Add(this.panelAddNewProduct);
            this.panelProduct.Controls.Add(this.panelEditProduct);
            this.panelProduct.Location = new System.Drawing.Point(297, 49);
            this.panelProduct.Name = "panelProduct";
            this.panelProduct.Size = new System.Drawing.Size(969, 678);
            this.panelProduct.TabIndex = 70;
            // 
            // lnkProductUpdates
            // 
            this.lnkProductUpdates.AutoSize = true;
            this.lnkProductUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lnkProductUpdates.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lnkProductUpdates.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkProductUpdates.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkProductUpdates.ForeColor = System.Drawing.Color.Azure;
            this.lnkProductUpdates.Location = new System.Drawing.Point(16, 46);
            this.lnkProductUpdates.Name = "lnkProductUpdates";
            this.lnkProductUpdates.Padding = new System.Windows.Forms.Padding(20);
            this.lnkProductUpdates.Size = new System.Drawing.Size(274, 73);
            this.lnkProductUpdates.TabIndex = 67;
            this.lnkProductUpdates.Text = "Product Updates";
            this.lnkProductUpdates.Click += new System.EventHandler(this.lnkProductUpdates_Click);
            this.lnkProductUpdates.MouseLeave += new System.EventHandler(this.lnkProductUpdates_MouseLeave);
            this.lnkProductUpdates.MouseHover += new System.EventHandler(this.lnkProductUpdates_MouseHover);
            // 
            // lnkCustomerUpdates
            // 
            this.lnkCustomerUpdates.AutoSize = true;
            this.lnkCustomerUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lnkCustomerUpdates.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lnkCustomerUpdates.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkCustomerUpdates.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCustomerUpdates.ForeColor = System.Drawing.Color.Azure;
            this.lnkCustomerUpdates.Location = new System.Drawing.Point(301, 46);
            this.lnkCustomerUpdates.Name = "lnkCustomerUpdates";
            this.lnkCustomerUpdates.Padding = new System.Windows.Forms.Padding(20);
            this.lnkCustomerUpdates.Size = new System.Drawing.Size(299, 73);
            this.lnkCustomerUpdates.TabIndex = 68;
            this.lnkCustomerUpdates.Text = "Customer Updates";
            this.lnkCustomerUpdates.Click += new System.EventHandler(this.lnkCustomerUpdates_Click);
            this.lnkCustomerUpdates.MouseLeave += new System.EventHandler(this.lnkCustomerUpdates_MouseLeave);
            this.lnkCustomerUpdates.MouseHover += new System.EventHandler(this.lnkCustomerUpdates_MouseHover);
            // 
            // lnkOrdersUpdates
            // 
            this.lnkOrdersUpdates.AutoSize = true;
            this.lnkOrdersUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lnkOrdersUpdates.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lnkOrdersUpdates.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkOrdersUpdates.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkOrdersUpdates.ForeColor = System.Drawing.Color.Azure;
            this.lnkOrdersUpdates.Location = new System.Drawing.Point(620, 46);
            this.lnkOrdersUpdates.Name = "lnkOrdersUpdates";
            this.lnkOrdersUpdates.Padding = new System.Windows.Forms.Padding(20);
            this.lnkOrdersUpdates.Size = new System.Drawing.Size(262, 73);
            this.lnkOrdersUpdates.TabIndex = 69;
            this.lnkOrdersUpdates.Text = "Orders Updates";
            this.lnkOrdersUpdates.Click += new System.EventHandler(this.lnkOrdersUpdates_Click);
            this.lnkOrdersUpdates.MouseLeave += new System.EventHandler(this.lnkOrdersUpdates_MouseLeave);
            this.lnkOrdersUpdates.MouseHover += new System.EventHandler(this.lnkOrdersUpdates_MouseHover);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(383, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 29);
            this.label10.TabIndex = 64;
            this.label10.Text = "Updates";
            // 
            // dataGridViewUpdates
            // 
            this.dataGridViewUpdates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUpdates.Location = new System.Drawing.Point(16, 189);
            this.dataGridViewUpdates.Name = "dataGridViewUpdates";
            this.dataGridViewUpdates.Size = new System.Drawing.Size(850, 265);
            this.dataGridViewUpdates.TabIndex = 70;
            // 
            // panelUpdate
            // 
            this.panelUpdate.Controls.Add(this.lblUpdatesInstructionDynamic);
            this.panelUpdate.Controls.Add(this.lblUpdateDynamic);
            this.panelUpdate.Controls.Add(this.dataGridViewUpdates);
            this.panelUpdate.Controls.Add(this.label10);
            this.panelUpdate.Controls.Add(this.lnkOrdersUpdates);
            this.panelUpdate.Controls.Add(this.lnkCustomerUpdates);
            this.panelUpdate.Controls.Add(this.lnkProductUpdates);
            this.panelUpdate.Location = new System.Drawing.Point(325, 116);
            this.panelUpdate.Name = "panelUpdate";
            this.panelUpdate.Size = new System.Drawing.Size(904, 482);
            this.panelUpdate.TabIndex = 72;
            this.panelUpdate.Visible = false;
            // 
            // lblUpdatesInstructionDynamic
            // 
            this.lblUpdatesInstructionDynamic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUpdatesInstructionDynamic.AutoSize = true;
            this.lblUpdatesInstructionDynamic.BackColor = System.Drawing.Color.Transparent;
            this.lblUpdatesInstructionDynamic.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdatesInstructionDynamic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUpdatesInstructionDynamic.Location = new System.Drawing.Point(19, 159);
            this.lblUpdatesInstructionDynamic.Name = "lblUpdatesInstructionDynamic";
            this.lblUpdatesInstructionDynamic.Size = new System.Drawing.Size(299, 19);
            this.lblUpdatesInstructionDynamic.TabIndex = 72;
            this.lblUpdatesInstructionDynamic.Text = "This will show only updates of last 3 Hours";
            // 
            // lblUpdateDynamic
            // 
            this.lblUpdateDynamic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUpdateDynamic.AutoSize = true;
            this.lblUpdateDynamic.BackColor = System.Drawing.Color.Transparent;
            this.lblUpdateDynamic.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateDynamic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUpdateDynamic.Location = new System.Drawing.Point(366, 130);
            this.lblUpdateDynamic.Name = "lblUpdateDynamic";
            this.lblUpdateDynamic.Size = new System.Drawing.Size(171, 29);
            this.lblUpdateDynamic.TabIndex = 71;
            this.lblUpdateDynamic.Text = "Orders Updates";
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            // 
            // productTableAdapter1
            // 
            this.productTableAdapter1.ClearBeforeFill = true;
            // 
            // UserWindow
            // 
            this.ClientSize = new System.Drawing.Size(1269, 749);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.LinkLogOut);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelCustomers);
            this.Controls.Add(this.panelProduct);
            this.Controls.Add(this.panelOrder);
            this.Controls.Add(this.panelOrderHistory);
            this.Controls.Add(this.panelUpdate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.UserWindow_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource7)).EndInit();
            this.panelCustomers.ResumeLayout(false);
            this.panelCustomers.PerformLayout();
            this.panelCustDetails.ResumeLayout(false);
            this.panelCustDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewCustInfo)).EndInit();
            this.panAddCust.ResumeLayout(false);
            this.panAddCust.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelNewOrder.ResumeLayout(false);
            this.panelNewOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEditOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oMSDataSet12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNewOrd)).EndInit();
            this.panelOrder.ResumeLayout(false);
            this.panelOrder.PerformLayout();
            this.panelOrderHistory.ResumeLayout(false);
            this.panelOrderHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderHistory)).EndInit();
            this.panelEditProduct.ResumeLayout(false);
            this.panelEditProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEditProduct)).EndInit();
            this.panelAddNewProduct.ResumeLayout(false);
            this.panelAddNewProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddNewProd)).EndInit();
            this.panelProduct.ResumeLayout(false);
            this.panelProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUpdates)).EndInit();
            this.panelUpdate.ResumeLayout(false);
            this.panelUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            //NewOrder order = new NewOrder();
            //Login lg = new Login();
            //lg.Hide();
            //order.Show();
            panelCustDetails.Visible = false;
            panAddCust.Visible = false;
            panelOrderHistory.Visible = false;
            panelUpdate.Visible = false;
            panelOrder.Visible = true;
            // panelOrder.Show();
            //panelOrder.BringToFront();
        }

        private void label1_hover(object sender, EventArgs e)
        {
            LnkOrderNow.BackColor = Color.ForestGreen;
            LnkOrderNow.ForeColor = Color.White;
        }
        private void LnkOrderNow_MouseLeave(object sender, EventArgs e)
        {
            LnkOrderNow.BackColor = Color.DarkGreen;
            LnkOrderNow.ForeColor = Color.Silver;
        }
        private void lblAddCust_MouseHover(object sender, EventArgs e)
        {
            lblAddCust.ForeColor = Color.Snow;
        }

        private void lblAddCust_MouseLeave(object sender, EventArgs e)
        {
            lblAddCust.ForeColor = Color.Silver;
        }

        private void lblCustDetails_MouseHover(object sender, EventArgs e)
        {
            lblCustDetails.ForeColor = Color.Snow;
        }

        private void lblCustDetails_MouseLeave(object sender, EventArgs e)
        {
            lblCustDetails.ForeColor = Color.Silver;
        }

        private void lblAddCust_Click(object sender, EventArgs e)
        {
            panelCustDetails.Visible = false;
            panelOrder.Visible = false;
            panelOrderHistory.Visible = false;
            panelUpdate.Visible = false;
            panelCustomers.Visible = true;
            panAddCust.Visible = true;
            custRefreshGrid();
            //panelCustDetails.Show();
            //panAddCust.Show();
            //panAddCust.BringToFront();
        }
        private void UserWindow_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'oMSDataSet12.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter1.Fill(this.oMSDataSet12.Product);
            // TODO: This line of code loads data into the 'databaseDataSet10.Product' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'databaseDataSet9.Customer' table. You can move, or remove it, as needed.
            OrdersListbox_girdVw_List1("cust_name");
            OrdersListbox_girdVw_List2("prod_type");

            SqlDataAdapter ad = new SqlDataAdapter("select prod_id as ID, prod_type as 'Product Type', prod_name as 'Product Name', brand, prod_price as 'Price', available_stock as 'Available Stock'  from Product", conn);
            conn.Open();
            DataTable ProdTable = new DataTable();
            ad.Fill(ProdTable);
            dataGridViewNewOrd.DataSource = ProdTable;
            conn.Close();

       }
        private void lblCustDetails_Click(object sender, EventArgs e)
        {
            panelOrder.Visible = false;
            panAddCust.Visible = false;
            panelOrderHistory.Visible = false;
            panelUpdate.Visible = false;
            //panAddCust.SendToBack();
            //panAddCust.Hide();
            //panelCustDetails.BringToFront();
            panelCustomers.Visible = true;
            panelCustDetails.Visible = true;
            custRefreshGrid();
        }

        public static string getTime()
        {
            return DateTime.Now.ToString("hh:mm:ss tt");
        }
        public static string getDate()
        {
            return DateTime.Now.ToString("MM-dd-yyyy");
        }
        public void custRefreshGrid()
        {

                //string s = "select * from Customer";
                //var ds = new DataSet();

                //SqlDataAdapter ad = new SqlDataAdapter(s, conn);

                //conn.Open();
                //DataTable CustTable = new DataTable();
                //ad.Fill(ds, "Customer");
                //dataGridView1.DataSource = ds.Tables["Customer"];
                //datagridviewCustInfo.DataSource = ds.Tables["Customer"];
                //conn.Close();
                DataTable ProdTable = new DataTable();
                DataTable prodTable1 = new DataTable();

            var ad = new SqlDataAdapter
                    (
                        "SELECT " +
                            "id as 'ID', " +
                            "cust_name as 'Customer Name', " +
                            "contact_no as 'Contact No.', " +
                            "email as 'Email Address', " +
                            "nic_no as 'CNIC', " +
                            "cust_address as 'Address', " +
                            "date_from as 'First Purchase on' , " +
                            "date_purch as 'Last Purchase', " +
                            "DOB " +
                         "FROM Customer"
                        , conn
                    );
            var ad2 = new SqlDataAdapter
                    (
                        "SELECT " +
                            "id as 'ID', " +
                            "cust_name as 'Customer Name', " +
                            "contact_no as 'Contact No.', " +
                            "email as 'Email Address', " +
                            "age as 'Age', " +
                            "cust_address as 'Address', " +
                            "nic_no as 'CNIC', " +
                            "date_from as 'First Purchase on' , " +
                            "date_purch as 'Last Purchase', " +
                            "DOB " +
                         "FROM Customer"
                        , conn
                    );
            conn.Open();
                ad.Fill(ProdTable);
                ad2.Fill(prodTable1);
                datagridviewCustInfo.DataSource = ProdTable;
                dataGridView1.DataSource = prodTable1;
                conn.Close();

        }
        public void prodRefreshGrid()
        {
            try
            {
                var ad = new SqlDataAdapter
                    (
                        "SELECT " +
                            "prod_id as ID, " +
                            "prod_type as 'Product Type', " +
                            "prod_name as 'Product Name', " +
                            "brand as Brand, " +
                            "prod_price as " +
                            "'Price', " +
                            "available_stock as 'Available Stock' , " +
                            "date_of_purchase as 'Supply Date', " +
                            "purchasing_price as 'Purchasing Price', " +
                            "total_stock_purch as 'Purchasing Stock', " +
                            "supply_by as 'Supply By', " +
                            "datetime_of_AddingProd as 'Date of Add' " +
                        "FROM Product", 
                      conn);
                conn.Open();
                DataTable ProdTable = new DataTable();
                ad.Fill(ProdTable);
                dataGridViewEditProduct.DataSource = ProdTable;
                dataGridViewAddNewProd.DataSource = ProdTable;
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Something went Wrong.");
            }
        }
        public void ListBoxRefresh()
        {

            listBox1.Items.Clear();
            listBox1.Refresh();
            listBox1.ResetText();
            listBox1.Text = "";
            try
            {
                string s = "select cust_name from Customer";
                conn.Open();
                SqlDataReader reader;
                SqlCommand comm = new SqlCommand(s, conn);
                reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    listBox1.Items.Add(reader["cust_name"]);
                }
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Please Restart the Application");
                // MessageBox.Show("It is a Problem of your DataBase");
            }
        }

        private void LinkLogOut_MouseHover(object sender, EventArgs e)
        {
            LinkLogOut.ForeColor = Color.Red;
        }

        private void LinkLogOut_MouseLeave(object sender, EventArgs e)
        {
            LinkLogOut.ForeColor = Color.DimGray;
        }

        private void LinkLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }
        private void btnNewCustome_Click_1(object sender, EventArgs e)
        {
            string dob1;
            dob1 = dateTimePickerDOB.Value.ToShortDateString();
            Connection1 conn = new Connection1();
            conn.AddCustomer(txtCustomerName.Text, Convert.ToInt64(txtCustomerContact.Text), txtCustomerEmailAddress.Text, txtCustomerAddress.Text, txtNic.Text, dateTimePickerDOB.Value);
            MessageBox.Show("New Customer inserted");
            ListBoxRefresh();
            custRefreshGrid();
        }
        private void LnkNewOrder_Click(object sender, EventArgs e)
        {
            lblOverAllAmount.Visible = false;
            linkEditOrder.ForeColor = Color.Azure;
            linkEditOrder.BackColor = Color.FromArgb(40, 40, 40);
            lnkNewOrder.ForeColor = Color.Silver;
            lnkNewOrder.BackColor = Color.SteelBlue;
            panelNewOrder.Visible = true;
            lblHeaderLabel.Text = "New Order";
            dataGridViewNewOrd.Visible = true;
            dataGridViewEditOrder.Visible = false;
            listboxNewOrder.Visible = true;
            listBoxNewOrdr_ProdTypes.Visible = true;
            comboBox_SelectedItemsList.Visible = true;
            lblCustomerName.Visible = true;
            lblTypesOfProducts.Visible = true;
            btnAddToList.Visible = true;
            lblTypesOfProducts.Visible = true;
            lblTotalAmountPerProd.Visible = true;
            lblSelectedItems.Visible = true;
            lblQuantity.Visible = true;
            lblPriceUnit.Visible = true;
            txtCustName_For_Order.Visible = true;
            txtCustomerAddress.Visible = true;
            txtCustomerContact.Visible = true;
            txtCustomerEmailAddress.Visible = true;
            txtCustomerName.Visible = true;
            lblProdDetails.Visible = true;
            txtTotalItems.Visible = true;
            searchProd.Location = new Point(196, 329);
            BtnUpdateOrder.Visible = false;
            btnDeleteOrder.Visible = false;
            btnDeleteProdFromOrder.Visible = false;
            lblCustNameOrd.Text = "Customer Name";
            btnConfirmOrder.Visible = false;

            ORMDataContext db = new ORMDataContext();
            var customers = from c in db.Customers
                            select c;
            var products = (from prd in db.Products
                            select new
                            {
                                prd.prod_id,
                                prd.prod_type,
                                prd.prod_name,
                                prd.brand,
                                prd.prod_price,
                                prd.available_stock
                            });
            dataGridViewNewOrd.DataSource = products.ToList();
            listboxNewOrder.DataSource = customers;
            listboxNewOrder.DisplayMember = "cust_name";
            listboxNewOrder.ValueMember = "Id";
        }
        private void linkEditOrder_Click(object sender, EventArgs e)
        {
            lnkNewOrder.ForeColor = Color.Azure;
            lnkNewOrder.BackColor = Color.FromArgb(40, 40, 40);
            linkEditOrder.ForeColor = Color.Silver;
            linkEditOrder.BackColor = Color.SteelBlue;
            lblHeaderLabel.Text = "Order Details";
            panelNewOrder.Visible = true;
            dataGridViewNewOrd.Visible = false;
            dataGridViewEditOrder.Visible = true;
            listboxNewOrder.Visible = false;
            listBoxNewOrdr_ProdTypes.Visible = false;
            comboBox_SelectedItemsList.Visible = false;
            lblCustomerName.Visible = false;
            lblTypesOfProducts.Visible = false;
            lblOverAllAmount.Visible = true;
            btnAddToList.Visible = false;
            lblTypesOfProducts.Visible = false;
            lblTotalAmountPerProd.Visible = false;
            lblSelectedItems.Visible = false;
            lblQuantity.Visible = false;
            lblPriceUnit.Visible = false;
            txtCustName_For_Order.Visible = false;
            txtCustomerAddress.Visible = false;
            txtCustomerContact.Visible = false;
            txtCustomerEmailAddress.Visible = false;
            txtCustomerName.Visible = false;
            lblProdDetails.Visible = false;
            txtTotalItems.Visible = false;
            searchProd.Location = new Point(389, 78);
            BtnUpdateOrder.Visible = true;
            btnDeleteOrder.Visible = true;
            btnDeleteProdFromOrder.Visible = true;
            lblCustNameOrd.Text = txtCustName_For_Order.Text;
            btnConfirmOrder.Visible = true;
            int count2 = 0, count4 = 0;

            for (int i = 0; i < 10; i++)
            {
                if (SelectedProdNames[i] == null)
                {
                    count2++;count4++;
                }
            }

            count4 = CreateViewForConfirmingOrder(count4);


            //for (int i = 0; i < 10 - count2; i++)
            //{
            //    var rowindex = dataGridViewEditOrder.Rows.Add();
            //    dataGridViewEditOrder.Rows[rowindex].Cells[i].Value = obj3Prod.prodId[i];
            //    dataGridViewEditOrder[0, i].Value = obj3Prod.prodId[i];
            //    dataGridViewEditOrder[1, i].Value = obj3Prod.prodTyoe[i];
            //    dataGridViewEditOrder[2, i].Value = obj3Prod.prodName[i];
            //    dataGridViewEditOrder[3, i].Value = obj3Prod.prodPrice[i];
            //    dataGridViewEditOrder[4, i].Value = obj3Prod.brandName[i];
            //    dataGridViewEditOrder[5, i].Value = obj3Prod.availableStock[i];
            //}

            //string s = "declare @Amount float; set @Amount = (select total_stock_purch*prod_price FROM Product); declare @OverAllAmount float; set @OverAllAmount = @Amount; select  @OverAllAmount as 'Over All Amount';";
            string s1 = "SELECT SUM (" + Convert.ToInt32(txtQuantityPerProd.Text) + " * prod_price) AS OverAllAmount FROM Product";
            string str = "";
            SqlDataReader reader;
            SqlCommand comm = new SqlCommand(s1, conn);
            conn.Open();
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                str = (reader["OverAllAmount"]).ToString();
            }
            lblOverAllAmount.Text = "Rs: " + str;
            conn.Close();

            for (int i = 0; i < 10; i++)
            {
                if (ind1 > i)
                {
                    if (obj3Prod.availableStock[i] > 0)
                    {
                        if (Convert.ToInt32(dataGridViewEditOrder[7, i].Value) > obj3Prod.availableStock[i])
                        {
                            MessageBox.Show("The Quantity of "
                               + dataGridViewEditOrder[3, i].Value.ToString() +
                               "is Higher than Available Stock! \r Please Update as less Quantity " +
+
                                Convert.ToInt32(dataGridViewEditOrder[7, i].Value) + ">" + obj3Prod.availableStock[i]
                                );
                            dataGridViewEditOrder[7, i].Value = obj3Prod.availableStock[i].ToString();
                            obj1.ProdId[i] = Convert.ToInt32(dataGridViewEditOrder[2, i].Value);
                            obj1.ProdName[i] = dataGridViewEditOrder[3, i].Value.ToString();
                            obj1.ProdPrice[i] = Convert.ToInt32(dataGridViewEditOrder[6, i].Value);
                            obj1.ProdQuantity[i] = obj3Prod.prodQuantity[i] = obj3Prod.availableStock[i];
                        }
                        else if (Convert.ToInt32(dataGridViewEditOrder[7, i].Value) <= obj3Prod.availableStock[i] && Convert.ToInt32(dataGridViewEditOrder[7, i].Value) > 0)
                        {
                            obj2Cust.custId[i] = Convert.ToInt32(dataGridViewEditOrder[0, i].Value);
                            obj2Cust.custName[i] = dataGridViewEditOrder[1, i].Value.ToString();
                            obj1.ProdId[i] = Convert.ToInt32(dataGridViewEditOrder[2, i].Value);
                            obj1.ProdName[i] = dataGridViewEditOrder[3, i].Value.ToString();
                            obj1.ProdPrice[i] = Convert.ToInt32(dataGridViewEditOrder[6, i].Value);
                            obj1.ProdQuantity[i] = obj3Prod.availableStock[i];
                        }
                        else if (Convert.ToInt32(dataGridViewEditOrder[7, i].Value) == 0)
                        {
                            MessageBox.Show("Please Add Quantity");
                        }
                    }
                    
                    else
                    {
                        MessageBox.Show("The Product " + dataGridViewEditOrder[3, i].Value.ToString() + " is Short");
                        obj2Cust.custId[i] = Convert.ToInt32(dataGridViewEditOrder[0, i].Value);
                        obj2Cust.custName[i] = dataGridViewEditOrder[1, i].Value.ToString();
                        obj1.ProdId[i] = Convert.ToInt32(dataGridViewEditOrder[2, i].Value);
                        obj1.ProdName[i] = dataGridViewEditOrder[3, i].Value.ToString();
                        obj1.ProdPrice[i] = Convert.ToInt32(dataGridViewEditOrder[6, i].Value);
                        obj1.ProdQuantity[i] = obj3Prod.prodQuantity[i] = obj3Prod.availableStock[i];
                        dataGridViewEditOrder[7, i].Value = obj3Prod.availableStock[i].ToString();
                        dataGridViewEditOrder[8, i].Value = "0";
                        dataGridViewEditOrder[9, i].Value = "0";
                    }
                }
                else if (ind1 <= i)
                {
                    if(count2>0)
                        count2 = CreateViewForConfirmingOrder(count2);
                    dataGridViewEditOrder[0, i].Value = "Total Amount";
                    dataGridViewEditOrder[1, i].Value = "=";
                    int count3 = 0;
                    while (i > 0)
                    {
                        if (i > 0 && dataGridViewEditOrder[9, i].Value != null)
                        {
                            dataGridViewEditOrder[4, count3 + i].Value = Convert.ToInt64(dataGridViewEditOrder[4, count3 + i].Value) + Convert.ToInt64(dataGridViewEditOrder[9, i - 1].Value);
                            lblOverAllAmount.Text = "Rs: " + dataGridViewEditOrder[4, count3 + i].Value.ToString();
                            i--;
                            count3++;
                        }
                        else if (dataGridViewEditOrder[9, i].Value == null)
                        {
                            dataGridViewEditOrder[4, i].Value = 0 + Convert.ToInt64(dataGridViewEditOrder[9, i - 1].Value);
                            lblOverAllAmount.Text = "Rs: " + dataGridViewEditOrder[4, i].Value.ToString();
                            i--;
                            count3++;
                        }
                        else { return; }
                    }
                    dataGridViewEditOrder.Rows[count3 - 1 + i + 1].DefaultCellStyle.BackColor = Color.Beige;
                    return;
                }
            }
        }
        public int CreateViewForConfirmingOrder(int count2)
        {
            var comm1 = new SqlCommand("TRUNCATE TABLE ConfirmOrder;", conn);
            conn.Open();
            comm1.ExecuteNonQuery();
            conn.Close();
            string[] SelectedProdNames2 = new string[10 - count2];            
            for (int i = 0; i < 10 - count2; i++)
            {
                if (SelectedProdNames[i] != null)
                {
                    checkedprevius++;
                    SelectedProdNames2[i] = SelectedProdNames[i];

                    var comm3 = new SqlCommand(
                                                "INSERT INTO ConfirmOrder " +
                                                "(prod_id, cust_id, prod_Quantity) values " +
                                                "(" + obj3Prod.prodId[i] + ","
                                                    + listboxNewOrder.SelectedValue + ", "
                                                    + obj3Prod.prodQuantity[i] + " )",
                                                conn);
                    conn.Open();
                    comm3.ExecuteNonQuery();
                    conn.Close();
                }
            }
            
            var commDropView = new SqlCommand("DROP VIEW Orders_of_Product", conn);
            //return;
            var commCreateView = new SqlCommand
                               (
                                 "CREATE VIEW Orders_of_Product AS" +
                                " SELECT " +
                                           " co.cust_Id as 'Customer ID', " +
                                           " c.cust_name as 'Customer Name', " +
                                           " co.prod_Id as 'Product Id', " +
                                           " p.prod_name as 'Product Name'," +
                                           " p.prod_type as 'Product Type', " +
                                           " p.brand as 'Brand', " +
                                           " p.prod_price as 'Rate Per Prod', " +
                                           " co.prod_Quantity as 'Product Quantity' ," +
                                           " p.available_stock as 'Available Stock' ," +
                                           " co.prod_Quantity * p.prod_price as 'Amount' " +
                                " FROM ConfirmOrder co " +
                                           " left outer join Product p on co.prod_Id = p.prod_id " +
                                           " inner join Customer c on co.cust_id = c.Id "
                               , conn);

            var ad = new SqlDataAdapter("SELECT * FROM Orders_of_Product ", conn);
            conn.Open();
            commDropView.ExecuteNonQuery();
            commCreateView.ExecuteNonQuery();
            DataTable ProdTable = new DataTable();
            ad.Fill(ProdTable);
            dataGridViewEditOrder.DataSource = ProdTable;
            conn.Close();
            count2 = 0;
            return count2;
        }
        public void AddAvailableQuanity_for_SelectedProd(int ind)
        {
            obj3Prod.availableStock[ind] = Convert.ToInt32(dataGridViewNewOrd[5, ind].Value);
        }
        private void linkEditOrder_MouseHover(object sender, EventArgs e)
        {
            linkEditOrder.ForeColor = Color.Azure;
            linkEditOrder.BackColor = Color.FromArgb(64, 64, 64);
        }
        private void linkEditOrder_MouseLeave(object sender, EventArgs e)
        {
            linkEditOrder.ForeColor = Color.Azure;
            linkEditOrder.BackColor = Color.FromArgb(40, 40, 40);
        }
        private void linkNewOrder_MouseHover(object sender, EventArgs e)
        {
            lnkNewOrder.ForeColor = Color.Azure;
            lnkNewOrder.BackColor = Color.FromArgb(64, 64, 64);
        }
        private void linkNewOrder_MouseLeave(object sender, EventArgs e)
        {
            lnkNewOrder.ForeColor = Color.Azure;
            lnkNewOrder.BackColor = Color.FromArgb(40, 40, 40);
        }
        private void listboxNewOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCustomerName.Text = listboxNewOrder.SelectedItem.ToString();
        }
        public void OrdersListbox_girdVw_List1(string selectedforCustomer)
        {
            ORMDataContext db = new ORMDataContext();
            var customers = from c in db.Customers
                            select c;
            var products = from prd in db.Products
                           select prd;
            //count
            //for customers
            // dataGridViewNewOrd.DataSource = products.ToList();
            listboxNewOrder.DataSource = customers;
            listboxNewOrder.DisplayMember = selectedforCustomer;
            listboxNewOrder.ValueMember = "Id";
            // for Products
        }
        public void OrdersListbox_girdVw_List2(string selectedforProduct)
        {
            ORMDataContext db = new ORMDataContext();
            var product_type = from p in db.Products select p;
            listBoxNewOrdr_ProdTypes.DataSource = product_type;
            listBoxNewOrdr_ProdTypes.DisplayMember = selectedforProduct;
            listBoxNewOrdr_ProdTypes.ValueMember = "prod_id";
        }
        private void ListboxNewOrder_Click(object sender, EventArgs e)
        {
            ORMDataContext db = new ORMDataContext();
            int sv = Convert.ToInt32(listboxNewOrder.SelectedValue);
            // var selectedCust = from c in db.Customers where c.Id == sv select c;
            //or
            var selectedCust = db.Customers.First(c => c.Id == sv);
            txtCustName_For_Order.Text = selectedCust.cust_name;
        }
        private void ListBoxNewOrdr_ProdTypes_Click(object sender, EventArgs e)
        {
            ORMDataContext db = new ORMDataContext();
            int sv = Convert.ToInt32(listBoxNewOrdr_ProdTypes.SelectedValue);
            var selectedProdType = from p in db.Products where p.prod_id == sv select p;

            var ad = new SqlDataAdapter("SELECT prod_id as ID, prod_type as 'Product Type', prod_name as 'Product Name', brand, prod_price as 'Price', available_stock as 'Available Stock' FROM Product where prod_id = " + sv + "", conn);
            conn.Open();
            DataTable ProdTable = new DataTable();
            ad.Fill(ProdTable);
            dataGridViewNewOrd.DataSource = ProdTable;
            conn.Close();
        }
        private void btnAddToList_Click(object sender, EventArgs e)
        {
            count = dataGridViewNewOrd.SelectedCells.Count;

            if (txtCustName_For_Order.Text == "Choose Customer From ListBox" || txtCustName_For_Order.Text == null)
            {
                MessageBox.Show("Please Select Custumer!");
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    txtTotalItems.Text = (Convert.ToInt16(txtTotalItems.Text) + 1).ToString();
                    DataGridViewCell cell = dataGridViewNewOrd.SelectedCells[0] as DataGridViewCell;
                    if (ind1 == 0 || cell.Value.ToString() != selectedItemsFromGrid_NewOrder[ind1 - 1])
                    {
                        selectedItemsFromGrid_NewOrder[ind1] = cell.Value.ToString();
                        comboBox_SelectedItemsList.Items.Add(selectedItemsFromGrid_NewOrder[ind1]);
                        SelectedProdNames[ind1] = cell.Value.ToString();
                        obj3Prod.prodId[ind1] = Convert.ToInt32(dataGridViewNewOrd[0, cell.RowIndex].Value);
                        obj3Prod.prodQuantity[ind1] = Convert.ToInt32(txtQuantityPerProd.Text);
                        obj3Prod.availableStock[ind1] = Convert.ToInt32(dataGridViewNewOrd[5, cell.RowIndex].Value);
                        AddAvailableQuanity_for_SelectedProd(cell.RowIndex);
                        ind1++;
                        MessageBox.Show("Product Added Successfully");
                    }
                    else if (cell.Value.ToString() == selectedItemsFromGrid_NewOrder[ind1 - 1])
                    {
                        selectedItemsFromGrid_NewOrder[ind1 - 1] = cell.Value.ToString();
                        obj3Prod.prodId[ind1 - 1] = obj3Prod.prodId[ind1];
                        SelectedProdNames[ind1 - 1] = cell.Value.ToString();
                        obj3Prod.prodQuantity[ind1 - 1] = Convert.ToInt32(txtQuantityPerProd.Text);
                        obj3Prod.availableStock[ind1 - 1] = obj3Prod.availableStock[ind1];
                        //obj3Prod.prodQuantity[ind1 - 1] = Convert.ToInt32(txtQuantityPerProd.Text);
                    }
                    //var ad = new SqlDataAdapter ("SELECT * FROM Product where prod_name = '" + cell.Value.ToString() + "'", conn);
                    //conn.Open();
                    //DataTable ProdTable = new DataTable();
                    //ad.Fill(ProdTable);
                    //dataGridViewEditOrder.DataSource = ProdTable;
                    //conn.Close();
                    //dataGridViewEditOrder.DataSource = comboBox_SelectedItemsList.MouseWheel.ToString();
                }
            }
        }
         private void dataGridViewNewOrd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;// get the Row Index
                DataGridViewRow selectedRow = dataGridViewNewOrd.Rows[index];
                txtProductName.Text = selectedRow.Cells[2].Value.ToString();
                txtPriceUnit.Text = selectedRow.Cells[4].Value.ToString();
                //  txtQuantityPerProd.Text = selectedRow.Cells[3].Value.ToString();
                if (selectedRow.Cells[5] == null)
                {
                    txtQuantityPerProd.Text = "Not Available";
                }
            }
            catch
            {
                MessageBox.Show("There is few Products, Please reset it");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            lblTotalAmountPerProd.Visible = true;
            try
            {
                lblTotalAmountPerProd.Text = "Total Amount of this Product: " + (Convert.ToDecimal(txtPriceUnit.Text) * Convert.ToDecimal(txtQuantityPerProd.Text)).ToString();
            }
            catch
            {
                MessageBox.Show("Please fill all Fields");
                return;
            }
            if (txtCustName_For_Order.Text == "Choose Customer From ListBox" || txtCustName_For_Order.Text == null)
            {
                MessageBox.Show("Please Select Custumer!");
            }
            else
            {
                txtTotalItems.Text = (Convert.ToInt16(txtTotalItems.Text) + 1).ToString();
                DataGridViewCell cell = dataGridViewNewOrd.SelectedCells[0] as DataGridViewCell;
                
                if (ind1 == 0 || cell.Value.ToString() != selectedItemsFromGrid_NewOrder[ind1 - 1])
                {
                    selectedItemsFromGrid_NewOrder[ind1] = cell.Value.ToString();
                    comboBox_SelectedItemsList.Items.Add(selectedItemsFromGrid_NewOrder[ind1]);
                    SelectedProdNames[ind1] = cell.Value.ToString();
                    obj3Prod.prodId[ind1] = Convert.ToInt32(dataGridViewNewOrd[0, cell.RowIndex].Value);
                    obj3Prod.prodQuantity[ind1] = Convert.ToInt32(txtQuantityPerProd.Text);
                    obj3Prod.availableStock[ind1] = Convert.ToInt32(dataGridViewNewOrd[5, cell.RowIndex].Value);
                    AddAvailableQuanity_for_SelectedProd(cell.RowIndex);
                    ind1++;
                    MessageBox.Show("Product Added Successfully");
                }
                else if (cell.Value.ToString() == selectedItemsFromGrid_NewOrder[ind1 - 1])
                {
                    selectedItemsFromGrid_NewOrder[ind1 - 1] = cell.Value.ToString();
                    obj3Prod.prodId[ind1 - 1] = obj3Prod.prodId[ind1];
                    SelectedProdNames[ind1 - 1] = cell.Value.ToString();
                    obj3Prod.prodQuantity[ind1-1] = Convert.ToInt32(txtQuantityPerProd.Text);
                    obj3Prod.availableStock[ind1 - 1] = obj3Prod.availableStock[ind1];
                    MessageBox.Show("Product Updated Successfully");
                }
            }

        }
        private void BtnUpdateOrder_Click(object sender, EventArgs e)
        {
            int count2 = 0;
            count2 = dataGridViewEditOrder.Rows.Count;

            for (int i = 0; i < count2; i++)
            {
                if (ind1 > i)
                {
                    obj1.ProdId[i] = Convert.ToInt32(dataGridViewEditOrder[2, i].Value);
                    obj1.ProdName[i] = dataGridViewEditOrder[3, i].Value.ToString();
                    obj1.ProdPrice[i] = Convert.ToInt32(dataGridViewEditOrder[6, i].Value);
                    obj1.ProdQuantity[i] = Convert.ToInt32(dataGridViewEditOrder[7, i].Value);
                    dataGridViewEditOrder[9, i].Value = obj1.ProdQuantity[i] * obj1.ProdPrice[i];

                    SqlCommand comm = new SqlCommand
                        (
                             "UPDATE ConfirmOrder SET " +
                                 "prod_Quantity = " + obj1.ProdQuantity[i] + " " +
                             "WHERE " +
                                 "prod_id = " + obj1.ProdId[i]

                              , conn
                        );

                    conn.Open();
                    try
                    {
                        comm.ExecuteNonQuery();
                    }
                    catch { }
                    conn.Close();
                }
                else if (ind1 <= i)
                {
                    dataGridViewEditOrder[0, i].Value = "Total Amount";
                    dataGridViewEditOrder[1, i].Value = "=";
                    int count3 = 0;
                    while (i > 0)
                    {
                        if (i > 0 && dataGridViewEditOrder[9, i].Value != null)
                        {
                            dataGridViewEditOrder[4, count3 + i].Value = Convert.ToInt64(dataGridViewEditOrder[4, count3 + i].Value) + Convert.ToInt64(dataGridViewEditOrder[9, i - 1].Value);
                            lblOverAllAmount.Text = "Rs: " + dataGridViewEditOrder[4, count3 + i].Value.ToString();
                            i--;
                            count3++;
                        }
                        else if (dataGridViewEditOrder[9, i].Value == null)
                        {
                            dataGridViewEditOrder[4, i].Value = 0 + Convert.ToInt64(dataGridViewEditOrder[9, i - 1].Value);
                            lblOverAllAmount.Text = "Rs: " + dataGridViewEditOrder[4, i].Value.ToString();
                            i--;
                            count3++;
                        }
                        else { return; }
                    }
                    dataGridViewEditOrder.Rows[count3 - 1 + i + 1].DefaultCellStyle.BackColor = Color.Beige;
                    return;
                }
            }
        }
        private void btnDeleteProdFromOrder_Click(object sender, EventArgs e)
        {
            int count1, count2, count3, rowInd = 0;
            count2 = dataGridViewEditOrder.SelectedRows.Count;
            count1 = dataGridViewEditOrder.SelectedCells.Count;
            count3 = datagridviewCustInfo.Rows.Count;
            ind1--;

            txtTotalItems.Text = (Convert.ToInt16(txtTotalItems.Text) + count1).ToString();
            string[] selectedProductToDelete = new string[count1];

            for (int i = 0; i < count1; i++)
            {
                DataGridViewCell cell = dataGridViewEditOrder.SelectedCells[i] as DataGridViewCell;
                selectedProductToDelete[i] = cell.Value.ToString();
                rowInd = Convert.ToInt32(cell.RowIndex.ToString());
                selectedProductToDelete[i] = dataGridViewEditOrder[3, rowInd].Value.ToString();
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    try
                    {
                        if (selectedProductToDelete[i] == obj1.ProdName[j])
                        {
                            obj1.ProdId[j] = 0;
                            obj1.ProdName[j] = null;
                            obj1.ProdPrice[j] = 0;
                            obj1.ProdQuantity[j] = 0;
                            obj3Prod.prodId[j] = obj3Prod.prodQuantity[j] = obj3Prod.prodPrice[j] = obj3Prod.availableStock[j] = 0;
                            obj3Prod.prodName[j] = obj3Prod.prodTyoe[j]=obj3Prod.brandName[j] = null;
                            
                            SelectedProdNames[j] = null;

                            for (int k = 0; k < 10; k++)
                            {
                                try
                                {   obj3Prod.prodId[k] = obj3Prod.prodId[k+1];
                                    obj3Prod.prodQuantity[k] = obj3Prod.prodQuantity[k + 1];
                                    obj3Prod.prodName[k] = obj3Prod.prodName[k + 1];
                                    obj3Prod.prodPrice[k] = obj3Prod.prodPrice[k + 1];
                                    obj3Prod.availableStock[k] = obj3Prod.availableStock[k + 1];
                                    obj3Prod.prodTyoe[k] = obj3Prod.prodTyoe[k + 1];
                                    SelectedProdNames[k] = SelectedProdNames[k + 1];
                                    obj3Prod.brandName[k] = obj3Prod.brandName[k + 1];
                                }
                                catch { }
                                if (SelectedProdNames[k] != null)
                                {
                                    count2++;
                                }
                            }
                        }
                        else if (obj1.ProdName[j] == null)
                        { }
                    }
                    catch { }
                }
            }
            CreateViewForConfirmingOrder(count2);
            try
            {
                for (int i = 0; i < count3; i++)
                {
                    if (dataGridViewEditOrder[0, rowInd + 1].Value.ToString() != "Total Amount")
                    {
                        dataGridViewEditOrder[0, rowInd].Value = dataGridViewEditOrder[0, rowInd + 1].Value.ToString();
                        dataGridViewEditOrder[2, rowInd].Value = dataGridViewEditOrder[2, rowInd + 1].Value.ToString();
                        dataGridViewEditOrder[4, rowInd].Value = dataGridViewEditOrder[4, rowInd + 1].Value.ToString();
                        dataGridViewEditOrder[5, rowInd].Value = dataGridViewEditOrder[5, rowInd + 1].Value.ToString();
                        dataGridViewEditOrder[6, rowInd].Value = dataGridViewEditOrder[6, rowInd + 1].Value.ToString();
                    }
                    else
                    {
                        dataGridViewEditOrder[0, rowInd].Value = 0;
                        dataGridViewEditOrder[1, rowInd].Value = null;
                        dataGridViewEditOrder[2, rowInd].Value = null;
                        dataGridViewEditOrder[3, rowInd].Value = null;
                        dataGridViewEditOrder[4, rowInd].Value = 0;
                        dataGridViewEditOrder[5, rowInd].Value = 0;
                        dataGridViewEditOrder[6, rowInd].Value = 0;

                    }
                }
            }
            catch { }
        }
        private void lnkCustomers_Click(object sender, EventArgs e)
        {
            panelProduct.Visible = false;
            panelCustomers.Visible = true;
            panelUpdate.Visible = false;
            panelOrderHistory.Visible = false;
            panelOrder.Visible = false;
            panelCustDetails.Visible = true;
            panelCustDetails.BringToFront();
            custRefreshGrid();
        }
        private void lnkProducts_Click(object sender, EventArgs e)
        {
            panelCustomers.Visible = false;
            panelProduct.Visible = true;
            panelUpdate.Visible = false;
            panelOrderHistory.Visible = false;
            panelOrder.Visible = false;
            prodRefreshGrid();
        }
        private void lnkUpdates_Click(object sender, EventArgs e)
        {
            panelCustomers.Visible = false;
            panelProduct.Visible = false;
            panelOrderHistory.Visible = false;
            panelOrder.Visible = false;
            panelUpdate.Visible = true;

            Refresh_datagridUpdates();
        }
        private void lnkOrderHistory_from_Super_Click(object sender, EventArgs e)
        {
            panelCustomers.Visible = false;
            panelProduct.Visible = false;
            panelUpdate.Visible = false;
            panelOrder.Visible = false;
            panelOrderHistory.Visible = true;
            panelOrderHistory_Refresh();
        }
        public void panelOrderHistory_Refresh()
        {
            SqlDataAdapter ad1 = new SqlDataAdapter
                ("SELECT " +
                            "pur.order_id as 'Order Id', " +
                            "ord.ID, " +
                            "c.cust_name as 'Customer Name', " +
                            "pur.prod_Id as 'Product Id', " +
                            "p.prod_name as 'Product Name', " +
                            "pur.OrderQuantity as 'Ordered Quantity', " +
                            "pur.TotalAmount as 'Total Amount', " +
                            "ord.OrderDateTime as 'Order DateTime'" +
                 " FROM " +
                            "purchase1 pur inner join _order ord on pur.order_id = ord.OrderID " +
                            "left outer join Customer c on ord.ID = c.Id " +
                            "inner join Product p on pur.prod_Id = p.prod_id " +
                            "ORDER BY OrderID DESC ", conn
                );
            DataTable prodtable1 = new DataTable();
            conn.Open();
            ad1.Fill(prodtable1);
            dataGridViewOrderHistory.DataSource = prodtable1;
            conn.Close();
        }
        private void lnkGenerateOrd_Click(object sender, EventArgs e)
        {
            panelCustomers.Visible = false;
            panelProduct.Visible = false;
            panelUpdate.Visible = false;
            panelOrderHistory.Visible = false;
            prodRefreshGrid();
            listboxNewOrder.Refresh();
            ListBoxRefresh();
            panelOrder.Visible = true;
        }
        private void lnkAddCustomerFromSuper_Click(object sender, EventArgs e)
        {
            panelProduct.Visible = false;
            panelUpdate.Visible = false;
            panelOrderHistory.Visible = false;
            panelOrder.Visible = false;
            panelCustomers.Visible = true;
            panelCustDetails.Visible = false;
            panAddCust.Visible = true;
            panAddCust.BringToFront();
            panelCustDetails.SendToBack();
            custRefreshGrid();
            ListBoxRefresh();
        }
        private void lnkEditCustomer_Click(object sender, EventArgs e)
        {
            panelProduct.Visible = false;
            panelUpdate.Visible = false;
            panelOrderHistory.Visible = false;
            panelOrder.Visible = false;
            panelCustomers.Visible = true;
            panAddCust.Visible = false;
            panelCustDetails.Visible = true;
            panAddCust.SendToBack();
            panelCustomers.BringToFront();
            custRefreshGrid();
        }
        private void btnUpdateCust_Click(object sender, EventArgs e)
        {
            int count1 = 0;
            count = datagridviewCustInfo.Rows.Count;
            int count2 = datagridviewCustInfo.SelectedCells.Count;
            DataGridViewCell cell = datagridviewCustInfo.SelectedCells[0] as DataGridViewCell;
            int rowInd = cell.RowIndex;
            SqlCommand comm1 = new SqlCommand();
            SqlCommand comm2 = new SqlCommand();

            for (int i = 0; i < count2; i++)
            {
                try
                {
                    obj2Cust.custId[i] = Convert.ToInt32(datagridviewCustInfo[0, rowInd].Value);
                    obj2Cust.custName[i] = datagridviewCustInfo[1, rowInd].Value.ToString();
                    try
                    {
                        comm1 = new SqlCommand
                            (
                                "UPDATE Customer SET " +
                                    "cust_name = '" + datagridviewCustInfo[1, rowInd].Value.ToString() + "', " +
                                    "contact_no = '" + datagridviewCustInfo[2, rowInd].Value.ToString() + "', " +
                                    "email = '" + datagridviewCustInfo[3, rowInd].Value.ToString() + "', " +
                                    "cust_address = '" + datagridviewCustInfo[4, rowInd].Value.ToString() + "', " +
                                    "nic_no = '" + datagridviewCustInfo[5, rowInd].Value.ToString() + "', " +
                                    "date_from= '" + Convert.ToDateTime(datagridviewCustInfo[6, rowInd].Value).ToString("yyyy-MM-dd HH:mm:ss").Replace('/', '-') + "', " +
                                    "date_purch = '" + Convert.ToDateTime(datagridviewCustInfo[7, rowInd].Value).ToString("yyyy-MM-dd HH:mm:ss").Replace('/', '-') + "', " +
                                    "dob = '" + Convert.ToDateTime(datagridviewCustInfo[8, rowInd].Value).ToString("yyyy-MM-dd HH:mm:ss").Replace('/', '-') + "' " +
                                "WHERE " +
                                     "Id = " + Convert.ToInt32(datagridviewCustInfo[0, rowInd].Value)
                            , conn);
                        comm2 = new SqlCommand
                            (
                            "DECLARE @dob  DATETIME; " +
                                "SET @dob='" + Convert.ToDateTime(datagridviewCustInfo[8, rowInd].Value).ToString("yyyy-MM-dd HH:mm:ss").Replace('/', '-') + "' " +
                             "UPDATE Customer set " +
                                "age = DATEDIFF(hour,@dob,GETDATE())/8766.0 " +
                            "where " +
                                "Id = " + Convert.ToInt32(datagridviewCustInfo[0, rowInd].Value)
                            , conn);
                    }
                    catch
                    {
                        MessageBox.Show("Please Fill All Dates");
                        return;
                    }

                        conn.Open();
                        comm1.ExecuteNonQuery();
                        comm2.ExecuteNonQuery();
                        MessageBox.Show("Customer " + datagridviewCustInfo[1, rowInd].Value.ToString() + " Update Successfuly");
                        conn.Close();
                }
                catch
                {
                    conn.Close();
                    MessageBox.Show("Please Select any cell \r Customer not Updated");
                }
            }
        }
        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            int count1, count2, count3, rowInd = 0;
            count2 = datagridviewCustInfo.SelectedRows.Count;
            count1 = datagridviewCustInfo.SelectedCells.Count;
            count3 = datagridviewCustInfo.Rows.Count;
            //int[] rowInd = new int[count1];
            int[] selectedCustomerToDelete = new int[count1];
            for (int i = 0; i < count3 - 1; i++)
            {
                obj2Cust.custId[i] = Convert.ToInt32(datagridviewCustInfo[0, i].Value.ToString());
                obj2Cust.custName[i] = datagridviewCustInfo[1, i].Value.ToString();
            }
            for (int i = 0; i < count1; i++)
            {
                DataGridViewCell cell = datagridviewCustInfo.SelectedCells[i] as DataGridViewCell;
                //selectedCustomerToDelete[i] = cell.Value.ToString();
                rowInd = Convert.ToInt32(cell.RowIndex.ToString());
                selectedCustomerToDelete[i] = Convert.ToInt32(datagridviewCustInfo[0, rowInd].Value);
                var comm1 = new SqlCommand("DELETE FROM _Order WHERE  id = " + Convert.ToInt32(selectedCustomerToDelete[i]), conn);
                var comm2 = new SqlCommand("DELETE FROM CUSTOMER WHERE  id = " + Convert.ToInt32(selectedCustomerToDelete[i]), conn);
                conn.Open();
                comm1.ExecuteNonQuery();
                comm2.ExecuteNonQuery();
                conn.Close();
            }
            for (int i = 0; i < count1; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    try
                    {
                        if (selectedCustomerToDelete[i] == obj2Cust.custId[j])
                        {
                            obj2Cust.custId[j] = 0;
                            obj2Cust.custName[j] = null;
                        }
                        else if (obj2Cust.custName[j] == null)
                        {

                        }
                    }
                    catch { }
                }
            }
            ListBoxRefresh();
            custRefreshGrid();
        }

        #region ToReplaceGrid
        //    try
        //    {
        //        for (int i = 0; i < count3; i++)
        //        {
        //            if (dataGridViewEditOrder[0, rowInd + 1].Value.ToString() != null)
        //            {
        //                datagridviewCustInfo[0, rowInd].Value = datagridviewCustInfo[0, rowInd + 1].Value.ToString();
        //                datagridviewCustInfo[1, rowInd].Value = datagridviewCustInfo[1, rowInd + 1].Value.ToString();
        //                datagridviewCustInfo[2, rowInd].Value = datagridviewCustInfo[2, rowInd + 1].Value.ToString();
        //                datagridviewCustInfo[3, rowInd].Value = datagridviewCustInfo[3, rowInd + 1].Value.ToString();
        //                datagridviewCustInfo[4, rowInd].Value = datagridviewCustInfo[4, rowInd + 1].Value.ToString();
        //                datagridviewCustInfo[5, rowInd].Value = datagridviewCustInfo[5, rowInd + 1].Value.ToString();
        //                datagridviewCustInfo[6, rowInd].Value = datagridviewCustInfo[6, rowInd + 1].Value.ToString();
        //                datagridviewCustInfo[7, rowInd].Value = datagridviewCustInfo[7, rowInd + 1].Value.ToString();
        //            }

        //            else
        //            {
        //                dataGridViewEditOrder[0, rowInd].Value = 0;
        //                dataGridViewEditOrder[1, rowInd].Value = null;
        //                dataGridViewEditOrder[2, rowInd].Value = null;
        //                dataGridViewEditOrder[3, rowInd].Value = null;
        //                dataGridViewEditOrder[4, rowInd].Value = 0;
        //                dataGridViewEditOrder[5, rowInd].Value = 0;
        //                dataGridViewEditOrder[6, rowInd].Value = 0;

        //            }
        //        }
        //    }
        //    catch {
        //        //conn.Open();
        //        ////var comm = new SqlCommand("DELETE FROM CUSTOMER WHERE  cust_name = '"++"'", conn);
        //        //conn.Close();
        //        dataGridViewEditOrder[0, rowInd].Value = 0;
        //        dataGridViewEditOrder[1, rowInd].Value = null;
        //        dataGridViewEditOrder[2, rowInd].Value = null;
        //        dataGridViewEditOrder[3, rowInd].Value = null;
        //        dataGridViewEditOrder[4, rowInd].Value = 0;
        //        dataGridViewEditOrder[5, rowInd].Value = 0;
        //        dataGridViewEditOrder[6, rowInd].Value = 0;
        //    }
        //}
        #endregion
        private void btnDeleteAllCust_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want to Delete All?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                obj2Cust = new GetCustomerDetails();
                UserWindow usrWin = new UserWindow();
                usrWin.ResetText();
                usrWin.Refresh();

                var comm3 = new SqlCommand("TRUNCATE TABLE purchase1", conn);
                var comm1 = new SqlCommand("TRUNCATE TABLE CUSTOMER", conn);
                var comm2 = new SqlCommand("TRUNCATE TABLE _order", conn);

               
                    conn.Open();
                    try
                    {
                        comm1.ExecuteNonQuery();
                    }
                    catch
                    {
                        comm3.ExecuteNonQuery();
                        comm2.ExecuteNonQuery();
                        comm1.ExecuteNonQuery();
                    }
                    conn.Close();
                    custRefreshGrid();
                conn.Close(); 
            }
            else
            {
                return;
            }
        }
        private void lnkEditProduct_Click(object sender, EventArgs e)
        {
            panelProduct.Visible = true;
            panelAddNewProduct.Visible = false;
            panelEditProduct.Visible = true;
            panelOrder.Visible = panelCustomers.Visible = panelUpdate.Visible = panelOrderHistory.Visible = false;
            var ad = new SqlDataAdapter("SELECT prod_id as ID, prod_type as 'Product Type', prod_name as 'Product Name', brand, prod_price as 'Price', available_stock as 'Available Stock' , date_of_purchase as 'Supply Date', purchasing_price as 'Purchasing Price', total_stock_purch as 'Purchasing Stock', supply_by as 'Supply By', datetime_of_AddingProd 'Date of Add' FROM Product", conn);
            conn.Open();
            DataTable ProdTable = new DataTable();
            ad.Fill(ProdTable);
            dataGridViewEditProduct.DataSource = ProdTable;
            conn.Close();
        }
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            int count1 = 0, rowInd = 0, count2 = 0; 
            string str1 ="";
            count1 = dataGridViewEditProduct.Rows.Count;
            count2 = dataGridViewEditProduct.SelectedCells.Count;
            for (int i = 0; i < count2; i++)
            {
                try
                {
                    DataGridViewCell cell = dataGridViewEditProduct.SelectedCells[i] as DataGridViewCell;
                    rowInd = cell.RowIndex;

                    try
                    {
                        obj3Prod.prodId[i] = Convert.ToInt32(dataGridViewEditProduct[0, rowInd].Value);
                        obj3Prod.prodTyoe[i] = dataGridViewEditProduct[1, rowInd].Value.ToString();
                        obj3Prod.prodName[i] = dataGridViewEditProduct[2, rowInd].Value.ToString();
                        obj3Prod.brandName[i] = dataGridViewEditProduct[3, rowInd].Value.ToString();
                        obj3Prod.prodPrice[i] = Convert.ToInt32(dataGridViewEditProduct[4, rowInd].Value);
                        obj3Prod.availableStock[i] = Convert.ToInt32(dataGridViewEditProduct[5, rowInd].Value);
                        obj3Prod.purchasingDate[i] = Convert.ToDateTime(dataGridViewEditProduct[6, rowInd].Value);
                        obj3Prod.purchaseingPrice[i] = Convert.ToInt32(dataGridViewEditProduct[7, rowInd].Value);
                        obj3Prod.total_Stock_purch[i] = Convert.ToInt32(dataGridViewEditProduct[8, rowInd].Value);
                        obj3Prod.supplyBy[i] = dataGridViewEditProduct[9, i].Value.ToString();
                        obj3Prod.AddingDate[i] = Convert.ToDateTime(dataGridViewEditProduct[10, rowInd].Value);
                        str1 = obj3Prod.purchasingDate[i].ToString();
                    }
                    catch
                    {
                        return;
                    }
                }
                catch
                {
                    try
                    {
                        obj3Prod.prodId[i] = Convert.ToInt32(dataGridViewEditProduct[0, i].Value);
                        obj3Prod.prodTyoe[i] = dataGridViewEditProduct[1, i].Value.ToString();
                        obj3Prod.prodName[i] = dataGridViewEditProduct[2, i].Value.ToString();
                        obj3Prod.brandName[i] = dataGridViewEditProduct[3, i].Value.ToString();
                        obj3Prod.prodPrice[i] = Convert.ToInt32(dataGridViewEditProduct[4, i].Value);
                        obj3Prod.availableStock[i] = Convert.ToInt32(dataGridViewEditProduct[5, i].Value);
                        obj3Prod.purchasingDate[i] = Convert.ToDateTime(dataGridViewEditProduct[6, i].Value);
                        obj3Prod.purchaseingPrice[i] = Convert.ToInt32(dataGridViewEditProduct[7, i].Value);
                        obj3Prod.total_Stock_purch[i] = Convert.ToInt32(dataGridViewEditProduct[8, i].Value);
                        obj3Prod.supplyBy[i] = dataGridViewEditProduct[9, i].Value.ToString();
                        obj3Prod.AddingDate[i] = Convert.ToDateTime(dataGridViewEditProduct[10, i].Value);
                    }
                    catch
                    {
                        MessageBox.Show("Please Fill All Column");
                        return;
                    }
                }
                var comm1 = new SqlCommand
                    (
                    "update Product set " +
                        "prod_name='" + obj3Prod.prodName[i] + "' ," +
                        "prod_type = '" + obj3Prod.prodTyoe[i] + "', " +
                        "prod_price = " + obj3Prod.prodPrice[i] + ", " +
                        "datetime_of_AddingProd ='" + obj3Prod.AddingDate[i].ToString("yyyy-MM-dd HH:mm:ss").Replace('/', '-') + "', " +
                        "date_of_purchase= '" + obj3Prod.purchasingDate[i].ToString("yyyy-MM-dd HH:mm:ss").Replace('/', '-') + "', " +
                        "purchasing_price =" + obj3Prod.purchaseingPrice[i] + ", " +
                        "supply_by='" + obj3Prod.supplyBy[i] + "', " +
                        "available_stock = " + obj3Prod.availableStock[i] + ", " +
                        "total_stock_purch = " + obj3Prod.total_Stock_purch[i] + " " +
                    "where prod_id = " + obj3Prod.prodId[i], conn);
                try
                {
                    conn.Open();
                    comm1.ExecuteNonQuery();
                    conn.Close();
                    if (count2 == 1)
                    {
                        MessageBox.Show("Product Updated Successfully");
                        break;
                    }
                }
                catch
                {
                       SqlCommand comm2=new SqlCommand(
                           "update Product set " +
                                "prod_name='" + obj3Prod.prodName[i] + "' ," +
                                "prod_type = '" + obj3Prod.prodTyoe[i] + "', " +
                                "prod_price = " + obj3Prod.prodPrice[i] + ", " +
                                "purchasing_price =" + obj3Prod.purchaseingPrice[i] + ", " +
                                "supply_by='" + obj3Prod.supplyBy[i] + "', " +
                                "available_stock = " + obj3Prod.availableStock[i] + ", " +
                                "total_stock_purch = " + obj3Prod.total_Stock_purch[i] + ", " +
                                "datetime_of_AddingProd ='" + obj3Prod.AddingDate[i].ToString("yyyy-MM-dd HH:mm:ss").Replace('/', '-') + "', " +
                                "date_of_purchase= '" + obj3Prod.purchasingDate[i].ToString("yyyy-MM-dd HH:mm:ss").Replace('/', '-') + "' " +
                            "where prod_id = " + obj3Prod.prodId[i], 
                           conn);
                    comm2.ExecuteNonQuery();
                }
                conn.Close();
                prodRefreshGrid();
            }
            MessageBox.Show("All Product Updated Successfully");
        }
        private void btnDeleteProduct_from_Products_Super_Click(object sender, EventArgs e)
        {
            int count1, count2, count3, rowInd = 0, prodId;
            count2 = dataGridViewEditProduct.SelectedRows.Count;
            count1 = dataGridViewEditProduct.SelectedCells.Count;
            count3 = dataGridViewEditProduct.Rows.Count;
            //int[] rowInd = new int[count1];
            string[] selectedProductoDelete = new string[count1];

            for (int i = 0; i < count1; i++)
            {
                DataGridViewCell cell = dataGridViewEditProduct.SelectedCells[i] as DataGridViewCell;
                selectedProductoDelete[i] = cell.Value.ToString();
                rowInd = Convert.ToInt32(cell.RowIndex.ToString());
                prodId = Convert.ToInt32(dataGridViewEditProduct[0, rowInd].Value);
                //selectedCustomerToDelete[i] = dataGridViewEditProduct[2, rowInd].Value.ToString();
                conn.Open();
                //var comm1 = new SqlCommand("DELETE FROM Purchase1 WHERE prod_id=" + prodId + "", conn);
                var comm2 = new SqlCommand("DELETE FROM PRODUCT WHERE prod_id="+ prodId , conn);
                //comm1.ExecuteNonQuery();
                comm2.ExecuteNonQuery();
                conn.Close();
            }
            prodRefreshGrid();
        }
        private void btnDeleteAllProducts_fromSuper_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want to Delete All?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                obj3Prod = new GetProductsDetails();
                UserWindow usrWin = new UserWindow();
                usrWin.ResetText();
                usrWin.Refresh();
         
                var comm2 = new SqlCommand("UPDATE Product SET available_stock = 0", conn);
                conn.Open();
                comm2.ExecuteNonQuery();
                conn.Close();
                prodRefreshGrid();             
            }
            else
            {
                return;
            }

        }
        private void lnkAddProduct_Click(object sender, EventArgs e)
        {
            panelProduct.Visible = true;
            panelEditProduct.Visible = false;
            panelAddNewProduct.Visible = true;
            prodRefreshGrid();
            //ProdListBox();
            int count1 = 0;
            count1 = dataGridViewAddNewProd.Rows.Count;
            int []selectedProdId = new int[count1];
            for (int i = 0; i < count1-1; i++) 
            {
                selectedProdId[i] = Convert.ToInt32(dataGridViewAddNewProd[0, i].Value);
            }
            lblProdId.Text = (Convert.ToInt32(selectedProdId[count1-2]+1)).ToString();
        }
        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {            
            var comm1 = new SqlCommand(
                "insert into Product " +
                "(prod_id, prod_type, prod_name, brand, prod_price, total_stock_purch, supply_by, purchasing_price, date_of_purchase, datetime_of_AddingProd)" +
                "values" +
                "(" +lblProdId.Text+","+
                "'" + txtProdType.Text + "'," +
                "'" + txtProdName_Adding.Text + "'," +
                "'" + txtBrandName.Text + "'," 
                 + txtProdPrice.Text + "," 
                 + txtTotalStockPurch.Text + "," + 
                "'" + txtSupplyBy.Text + "'," 
                 +  txtPurchasingPrice.Text + ", '" 
                 + dateTimePickerAddProd.Value.ToShortDateString() + "', " +
                " getdate() )",
                conn
                );
            var comm2 = new SqlCommand("UPDATE PRODUCT SET available_stock = "+ txtTotalStockPurch.Text + "where prod_id = " + lblProdId.Text, conn);
            conn.Open();
            try
            {
                comm1.ExecuteNonQuery();
                comm2.ExecuteNonQuery();
                conn.Close();
                lblProdId.Text = txtProdName_Adding.Text = txtBrandName.Text = txtProdType.Text = txtProdPrice.Text = txtTotalStockPurch.Text = txtSupplyBy.Text = txtTotalStockPurch.Text = "";
                dateTimePickerAddProd.ResetText();
                dateTimePickerAddProd.Refresh();
            }
            catch
            {
                MessageBox.Show("Please Fill All Fields");
                conn.Close();
            }
            prodRefreshGrid();
            //ProdListBox();

            MessageBox.Show("Product Added Successfully");

        }
        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            obj1 = new GetValuesforOrder();
            obj3Prod = new GetProductsDetails();
            obj3Prod.availableStock = new int[100];
            obj3Prod.prodId = new int[100];
            obj3Prod.prodName = new string[100];
            obj3Prod.brandName = new string[100];
            obj3Prod.availableStock = new int[100];
            obj3Prod.prodPrice = new int[100];
            obj3Prod.prodTyoe = new string[100];
            obj3Prod.prodQuantity = new int[100];
            obj1.NoOfItems = new int();
            obj1.OverAllAmount = new float();
            obj1.ProdId = new int[10];
            obj1.ProdName = new string[10];
            obj1.ProdPrice = obj1.ProdQuantity = new int[10];
            obj2Cust.custId = new int[100];
            obj2Cust.custName = new string[100];
            txtProdPrice.Text = txtProductName.Text = txtPriceUnit.Text = txtQuantityPerProd.Text = "0";
            SelectedProdNames = new string[10];
            selectedItemsFromGrid_NewOrder = new string[100];
            comboBox_SelectedItemsList.Items.Clear();
            lblCustName.Text = "Customer Name: ";
            txtCustName_For_Order.Text = "Choose Customer from ListBox";
            txtQuantityPerProd.Text = txtProductName.Text = txtPriceUnit.Text = lblTotalAmountPerProd.Text = "";
            txtTotalItems.Text = "0";
            dataGridViewEditOrder.DataSource = "";
            count = 0;
            ind1 = 0;
            selectedItemsFromGrid_NewOrder = new string[100];
            SelectedProdNames = new string[10];
            UserWindow usrWin = new UserWindow();
            usrWin.ResetText();
            usrWin.Refresh();
            obj1 = new GetValuesforOrder();
            MessageBox.Show("Order Deleted Successfully");

        }
        private void txtSearchBoxFromOrdHistory_TextChanged(object sender, EventArgs e)
        {
            if (searchProd.Text != "" || searchProd.Text != "Search ...")
            {
                string s = sender.ToString();
                dataGridViewOrderHistory.DataSource = "";
                string charSearching = txtSearchBoxFromOrdHistory.Text;
                SqlDataAdapter ad1, ad2 = new SqlDataAdapter();
                try
                {
                     ad1 = new SqlDataAdapter
                        ("SELECT " +
                                "pur.order_id as 'Order Id', " +
                                "ord.ID, " +
                                "c.cust_name as 'Customer Name', " +
                                "pur.prod_Id as 'Product Id', " +
                                "p.prod_name as 'Product Name', " +
                                "pur.OrderQuantity as 'Ordered Quantity', " +
                                "pur.TotalAmount as 'Total Amount', " +
                                "ord.OrderDateTime as 'Order DateTime'" +
                        " FROM " +
                                "purchase1 pur inner join _order ord on pur.order_id = ord.OrderID " +
                                "left outer join Customer c on ord.ID = c.Id " +
                                "inner join Product p on pur.prod_Id = p.prod_id " +
                                "WHERE ord.OrderID like '%" + Convert.ToInt32(charSearching) + "%' " +
                                "ORDER BY OrderID DESC ", conn
                                );

                    conn.Open();
                    DataTable ProdTable = new DataTable();
                    ad1.Fill(ProdTable);
                    dataGridViewOrderHistory.DataSource = ProdTable;
                    conn.Close();
                }
                catch
                {
                     ad2 = new SqlDataAdapter
                        ("SELECT " +
                               "pur.order_id as 'Order Id', " +
                               "ord.ID, " +
                               "c.cust_name as 'Customer Name', " +
                               "pur.prod_Id as 'Product Id', " +
                               "p.prod_name as 'Product Name', " +
                               "pur.OrderQuantity as 'Ordered Quantity', " +
                               "pur.TotalAmount as 'Total Amount', " +
                               "ord.OrderDateTime as 'Order DateTime'" +
                       " FROM " +
                               "purchase1 pur inner join _order ord on pur.order_id = ord.OrderID " +
                               "left outer join Customer c on ord.ID = c.Id " +
                               "inner join Product p on pur.prod_Id = p.prod_id " +
                               "WHERE c.cust_name like '%" + charSearching + "%' " +
                               "ORDER BY OrderID DESC ", conn
                               );

                    conn.Open();
                    DataTable ProdTable = new DataTable();
                    ad2.Fill(ProdTable);

                    dataGridViewOrderHistory.DataSource = ProdTable;
                    conn.Close();
                }
            }
        }
        private void btnConfirmOrder_Click(object sender, EventArgs e)
        {
            DateTime datetime_now = DateTime.Now;
            var comm = new SqlCommand("AddNewOrder", conn);

            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("OrderDateTime", datetime_now);
            comm.Parameters.AddWithValue("ID", listboxNewOrder.SelectedValue);
            comm.Parameters.Add("OrderID", SqlDbType.Int).Direction = ParameterDirection.Output;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int newOrdId = (int)comm.Parameters["OrderID"].Value;
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    if (dataGridViewEditOrder[2, i].Value != null)
                    {
                        SqlCommand comm2 = new SqlCommand("INSERT INTO purchase1 VALUES (" + newOrdId + "," + dataGridViewEditOrder[2, i].Value + ", " + dataGridViewEditOrder[7, i].Value + ", " + dataGridViewEditOrder[9, i].Value + ")", conn);
                        SqlCommand comm3 = new SqlCommand
                            (
                            "update Product set " +
                                        "available_stock = " + obj3Prod.prodQuantity[i] + 
                               " where " +
                                         "prod_id = '"+ dataGridViewEditOrder[2, i].Value + "'"
                            , conn);
                        conn.Open();
                        comm2.ExecuteNonQuery();
                        comm3.ExecuteNonQuery();
                        conn.Close();
                    }
                    else
                    {
                        MessageBox.Show("Order has been Created Succesfully");
                        obj1 = new GetValuesforOrder();
                        obj3Prod = new GetProductsDetails();
                        obj3Prod.availableStock = new int[100];
                        obj3Prod.prodId = new int[100];
                        obj3Prod.prodName = new string[100];
                        obj3Prod.brandName = new string[100];
                        obj3Prod.availableStock = new int[100];
                        obj3Prod.prodPrice = new int[100];
                        obj3Prod.prodTyoe = new string[100];
                        obj3Prod.prodQuantity = new int[100];
                        obj1.NoOfItems = new int();
                        obj1.OverAllAmount = new float();
                        obj1.ProdId = new int[10];
                        obj1.ProdName = new string[10];
                        obj1.ProdPrice = obj1.ProdQuantity = new int[10];
                        obj2Cust.custId = new int[100];
                        obj2Cust.custName = new string[100];
                        lblCustName.Text = "Customer Name: ";
                        txtCustName_For_Order.Text = "Choose Customer";
                        txtPriceUnit.Text = "0";
                        txtProdPrice.Text = txtProductName.Text = txtPriceUnit.Text = txtQuantityPerProd.Text = "0";
                        comboBox_SelectedItemsList.Items.Clear();
                        SelectedProdNames = new string[10];
                        selectedItemsFromGrid_NewOrder = new string[100];
                        dataGridViewEditOrder.DataSource = "";
                        count = 0;
                        ind1 = 0;
                        #region Query For creating Reports of Order Using View
                        // -->> For Reports Of Order
                        SqlCommand commView = new SqlCommand
                            (
                            "DROP VIEW prodID; " +
                            "DROP VIEW ProdName; " +
                            "DROP VIEW CustName; " +
                            "DROP VIEW OrderDetails; " +
                            "DROP VIEW OverAllAmount; "
                            , conn);

                        SqlCommand commView1 = new SqlCommand
                            ("CREATE VIEW prodID " +
                                    "AS " +
                                        "SELECT " +
                                            "pr.prod_id " +
                                        "FROM " +
                                            "purchase1 pr " +
                                        "WHERE " +
                                            "order_id = " + newOrdId + ""
                            , conn);

                        SqlCommand commView2 = new SqlCommand
                            ("CREATE VIEW ProdName " +
                                    "AS " +
                                    "SELECT " +
                                            "prod_name AS 'ProductName' " +
                                        "FROM " +
                                            "Product p " +
                                        "WHERE " +
                                            "p.prod_id IN (SELECT * FROM prodID)"
                            , conn);

                        SqlCommand commView3 = new SqlCommand
                            ("CREATE VIEW CustName " +
                                "AS " +
                                "SELECT " +
                                    "cust_name as 'CustomerName' " +
                                "FROM " +
                                    "Customer " +
                                "WHERE Id = (SELECT o.ID FROM _Order o WHERE o.OrderID = " + newOrdId + ")"
                            , conn);

                        SqlCommand commView4 = new SqlCommand
                                ("CREATE VIEW OrderDetails " +
                                    "AS " +
                                    "SELECT " +
                                        "p.order_id, p.OrderQuantity, p.TotalAmount " +
                                    "FROM " +
                                        "purchase1 p " +
                                    "WHERE p.order_id = " + newOrdId + " "
                                , conn);

                        SqlCommand commView5 = new SqlCommand
                               ("CREATE VIEW OverAllAmount " +
                                   "AS " +
                                   "SELECT " +
                                       "SUM(TotalAmount) AS 'Over_All_Amount'" +
                                   "FROM " +
                                       "purchase1 " +
                                   "WHERE order_id = " + newOrdId + " "
                               , conn);

                        conn.Open();
                        commView.ExecuteNonQuery();
                        commView1.ExecuteNonQuery();
                        commView2.ExecuteNonQuery();
                        commView3.ExecuteNonQuery();
                        commView4.ExecuteNonQuery();
                        commView5.ExecuteNonQuery();
                        conn.Close();
                        #endregion
                    }

                }
                catch
                {
                    break;
                }
 
            }
            OrdersReport report = new OrdersReport();
            report.Refresh();
            report.refreshReport();
            report.refreshReport();
            report.refreshReport();
            report.refreshReport();
            report.IsMdiContainer = true;
            report.Show();

            //report.Report();     
            try
            {
                report.refreshReport();
                report.refreshReport();
                report.refreshReport();
                report.MdiParent = OrdersReport.ActiveForm;
                report.refreshReport();
                report.refreshReport();
                report.refreshReport();
            }
            catch
            {
                try
                {
                    report.refreshReport();
                    report.refreshReport();
                    report.MdiParent = UserWindow.ActiveForm;
                    report.refreshReport();
                    report.refreshReport();
                    report.refreshReport();

                }
                catch { return; }
            }
            report.Show();

        }

        //private void searchProd_KeyPress(object sender, KeyPressEventArgs e)
        //{c
        //    if (searchProd.Text != "" || searchProd.Text != "Search ...")
        //    {

        //        dataGridViewNewOrd.DataSource = "";
        //        string charSearching = searchProd.Text;
        //        var ad = new SqlDataAdapter("SELECT prod_id as ID, prod_type as 'Product Type', prod_name as 'Product Name', brand, prod_price as 'Price', available_stock as 'Available Stock' FROM Product where brand like '%" + charSearching + "%' or prod_name like '%" + charSearching + "%' or prod_type like '%" + charSearching + "%';", conn);
        //        conn.Open();
        //        DataTable ProdTable = new DataTable();
        //        ad.Fill(ProdTable);
        //        dataGridViewNewOrd.DataSource = ProdTable;
        //        conn.Close();
        //        m++;
        //    }
        //}
        #region ListBoxRefresh  
        //public void ProdListBox()
        //{
        //    string s = "select prod_name from Product";
        //    conn.Open();
        //    SqlDataReader reader;
        //    SqlCommand comm = new SqlCommand(s, conn);
        //    reader = comm.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        listBoxAddNewProd.Items.Add(reader["prod_name"]);
        //    }
        //    conn.Close();

        //}
        #endregion

        private void lnkOrdersUpdates_Click(object sender, EventArgs e)
        {
            lblUpdateDynamic.Text = "Orders Updates";
            lblUpdatesInstructionDynamic.Text = "This will show only updates of last 3 Hours";
            Refresh_OrderUpdates();
        }
        private void SearchProd_TextChanged(object sender, EventArgs e)
        {
            if (searchProd.Text != "" || searchProd.Text != "Search ...")
            {
                string s = sender.ToString();
                dataGridViewNewOrd.DataSource = "";
                string charSearching = searchProd.Text;
                var adforLocal = new SqlDataAdapter     //    To Display Few Details of Products to LocalUser
                                (
                                    "SELECT " +
                                        "prod_id as ID, " +
                                        "prod_type AS 'Product Type', " +
                                        "prod_name AS 'Product Name', " +
                                        "brand AS 'Brand', " +
                                        "prod_price AS 'Price', " +
                                        "available_stock AS 'Available Stock' " +
                                    "FROM Product " +
                                    "WHERE " +
                                        "brand like '%" + charSearching + "%' " +
                                    "or " +
                                        "prod_name like '%" + charSearching + "%' " +
                                    "or " +
                                        "prod_type like '%" + charSearching + "%';", 
                               conn);

                var adforSearchView = new SqlDataAdapter
                        ("SELECT * FROM Orders_of_Product WHERE [Product Name] like '%"+ charSearching + "%' or [Product Id] like '%"+ charSearching +"% '", conn);

                DataTable ProdTable1 = new DataTable();
                DataTable ProdTable2 = new DataTable();

                conn.Open();
                adforLocal.Fill(ProdTable1);
                adforSearchView.Fill(ProdTable2);
                dataGridViewNewOrd.DataSource = ProdTable1;
                dataGridViewEditOrder.DataSource = ProdTable2;
                conn.Close();
            }
        }
        public void Refresh_datagridUpdates()
        {
            Refresh_OrderUpdates();
        }
        public void Refresh_OrderUpdates()
        {
            SqlDataAdapter ad1 = new SqlDataAdapter
                (
                "SELECT " +
                    "pur.order_id, " +
                    "ord.ID, c.cust_name, " +
                    "pur.prod_Id,p.prod_name, " +
                    "pur.OrderQuantity, " +
                    "pur.TotalAmount, " +
                    "ord.OrderDateTime " +
                "FROM " +
                    "_Order ord inner join purchase1 pur on pur.order_id = ord.OrderID " +
                    "left outer join Customer c on ord.ID = c.Id " +
                    "inner join Product p on pur.prod_Id = p.prod_id " +
                    "WHERE OrderDateTime >= DATEADD(hh, -3, GETDATE()) " +
                    "ORDER BY OrderID DESC"
                    , conn
                );
            DataTable prodTable1 = new DataTable();
            ad1.Fill(prodTable1);
            dataGridViewUpdates.DataSource = prodTable1;
        }
        private void lnkProductUpdates_Click(object sender, EventArgs e)
        {
            lblUpdateDynamic.Text = "Product Updates";
            lblUpdatesInstructionDynamic.Text = "This will show only updates of last 24 Hours";
            Refresh_ProductsUpdates();
        }
        private void lnkCustomerUpdates_Click(object sender, EventArgs e)
        {
            lblUpdateDynamic.Text = "Customer Updates";
            lblUpdatesInstructionDynamic.Text = "This will show only updates of last 24 Hours";
            Refresh_CustomerUpdates();
        }
        private void btnConfirmOrder_MouseHover(object sender, EventArgs e)
        {
            btnConfirmOrder.BackColor = Color.SteelBlue;
        }
        private void btnConfirmOrder_MouseLeave(object sender, EventArgs e)
        {
            btnConfirmOrder.BackColor = Color.DodgerBlue;
        }
        private void btnAddToList_MouseHover(object sender, EventArgs e)
        {
            btnAddToList.BackColor = Color.SteelBlue;
        }
        private void btnAddToList_MouseLeave(object sender, EventArgs e)
        {
            btnAddToList.BackColor = Color.DodgerBlue;
        }
        private void btnDeleteOrder_MouseHover(object sender, EventArgs e)
        {
            btnDeleteOrder.BackColor = Color.SteelBlue;
        }
        private void btnDeleteOrder_MouseLeave(object sender, EventArgs e)
        {
            btnDeleteOrder.BackColor = Color.DodgerBlue;
        }
        private void btnDeleteProdFromOrder_MouseHover(object sender, EventArgs e)
        {
            btnDeleteProdFromOrder.BackColor = Color.SteelBlue;
        }
        private void btnDeleteProdFromOrder_MouseLeave(object sender, EventArgs e)
        {
            btnDeleteProdFromOrder.BackColor = Color.DodgerBlue;
        }
        private void BtnUpdateOrder_MouseHover(object sender, EventArgs e)
        {
            BtnUpdateOrder.BackColor = Color.SteelBlue;
        }
        private void BtnUpdateOrder_MouseLeave(object sender, EventArgs e)
        {
            BtnUpdateOrder.BackColor = Color.DodgerBlue;
        }
        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.SteelBlue;
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.DodgerBlue;
        }
        private void lnkEditCustomer_MouseHover(object sender, EventArgs e)
        {
            lnkEditCustomer.ForeColor = Color.Azure;
            lnkEditCustomer.BackColor = Color.FromArgb(64, 64, 64);
        }
        private void lnkEditCustomer_MouseLeave(object sender, EventArgs e)
        {
            lnkEditCustomer.ForeColor = Color.Azure;
            lnkEditCustomer.BackColor = Color.FromArgb(40, 40, 40);
        }
        private void lnkAddCustomerFromSuper_MouseHover(object sender, EventArgs e)
        {
            lnkAddCustomerFromSuper.ForeColor = Color.Azure;
            lnkAddCustomerFromSuper.BackColor = Color.FromArgb(64, 64, 64);
        }
        private void lnkAddCustomerFromSuper_MouseLeave(object sender, EventArgs e)
        {
            lnkAddCustomerFromSuper.ForeColor = Color.Azure;
            lnkAddCustomerFromSuper.BackColor = Color.FromArgb(40, 40, 40);
        }
        private void btnDeleteAllCust_MouseHover(object sender, EventArgs e)
        {
            btnUpdateCust.BackColor = Color.SteelBlue;
        }
        private void btnDeleteAllCust_MouseLeave(object sender, EventArgs e)
        {
            btnUpdateCust.BackColor = Color.DodgerBlue;
        }
        private void btnDeleteCustomer_MouseHover(object sender, EventArgs e)
        {
            btnUpdateCust.BackColor = Color.SteelBlue;      
        }
        private void btnDeleteCustomer_MouseLeave(object sender, EventArgs e)
        {
            btnUpdateCust.BackColor = Color.DodgerBlue;
        }
        private void btnUpdateCust_MouseHover(object sender, EventArgs e)
        {
            btnUpdateCust.BackColor = Color.SteelBlue;
        }
        private void btnUpdateCust_MouseLeave(object sender, EventArgs e)
        {
            btnUpdateCust.BackColor = Color.DodgerBlue;
        }
        private void lnkProductUpdates_MouseHover(object sender, EventArgs e)
        {
            lnkProductUpdates.ForeColor = Color.Azure;
            lnkProductUpdates.BackColor = Color.FromArgb(64, 64, 64);
        }
        private void lnkProductUpdates_MouseLeave(object sender, EventArgs e)
        {
            lnkProductUpdates.ForeColor = Color.Azure;
            lnkProductUpdates.BackColor = Color.FromArgb(40, 40, 40);
        }
        private void lnkCustomerUpdates_MouseHover(object sender, EventArgs e)
        {
            lnkCustomerUpdates.ForeColor = Color.Azure;
            lnkCustomerUpdates.BackColor = Color.FromArgb(64, 64, 64);
        }
        private void lnkCustomerUpdates_MouseLeave(object sender, EventArgs e)
        {
            lnkCustomerUpdates.ForeColor = Color.Azure;
            lnkCustomerUpdates.BackColor = Color.FromArgb(40, 40, 40);
        }
        private void lnkOrdersUpdates_MouseHover(object sender, EventArgs e)
        {
            lnkOrdersUpdates.ForeColor = Color.Azure;
            lnkOrdersUpdates.BackColor = Color.FromArgb(64, 64, 64);
        }
        private void lnkOrdersUpdates_MouseLeave(object sender, EventArgs e)
        {
            lnkOrdersUpdates.ForeColor = Color.Azure;
            lnkOrdersUpdates.BackColor = Color.FromArgb(40, 40, 40);
        }
        private void lnkAddProduct_MouseHover(object sender, EventArgs e)
        {
            lnkAddProduct.ForeColor = Color.Azure;
            lnkAddProduct.BackColor = Color.FromArgb(64, 64, 64);
        }
        private void lnkAddProduct_MouseLeave(object sender, EventArgs e)
        {
            lnkAddProduct.ForeColor = Color.Azure;
            lnkAddProduct.BackColor = Color.FromArgb(40, 40, 40);
        }
        private void lnkEditProduct_MouseHover(object sender, EventArgs e)
        {
            lnkEditProduct.ForeColor = Color.Azure;
            lnkEditProduct.BackColor = Color.FromArgb(64, 64, 64);
        }
        private void lnkEditProduct_MouseLeave(object sender, EventArgs e)
        {
            lnkEditProduct.ForeColor = Color.Azure;
            lnkEditProduct.BackColor = Color.FromArgb(40, 40, 40);
        }
        private void btnDeleteAllProducts_fromSuper_MouseHover(object sender, EventArgs e)
        {
            btnDeleteAllProducts_fromSuper.BackColor = Color.SteelBlue;
        }
        private void btnDeleteAllProducts_fromSuper_MouseLeave(object sender, EventArgs e)
        {
            btnDeleteAllProducts_fromSuper.BackColor = Color.DodgerBlue;
        }
        private void btnDeleteProduct_from_Products_Super_MouseHover(object sender, EventArgs e)
        {
            btnDeleteProduct_from_Products_Super.BackColor = Color.SteelBlue;
        }
        private void btnDeleteProduct_from_Products_Super_MouseLeave(object sender, EventArgs e)
        {
            btnDeleteProduct_from_Products_Super.BackColor = Color.DodgerBlue;
        }
        private void btnUpdateProduct_MouseHover(object sender, EventArgs e)
        {
            btnUpdateProduct.BackColor = Color.SteelBlue;
        }
        private void btnUpdateProduct_MouseLeave(object sender, EventArgs e)
        {
            btnUpdateProduct.BackColor = Color.DodgerBlue;
        }
        private void btnAddNewProduct_MouseHover(object sender, EventArgs e)
        {
            btnAddNewProduct.BackColor = Color.SteelBlue;
        }
        private void btnAddNewProduct_MouseLeave(object sender, EventArgs e)
        {
            btnAddNewProduct.BackColor = Color.DodgerBlue;
        }
        private void btnNewCustome_MouseHover(object sender, EventArgs e)
        {
            btnNewCustome.BackColor = Color.SteelBlue;
        }
        private void btnNewCustome_MouseLeave(object sender, EventArgs e)
        {
            btnNewCustome.BackColor = Color.DodgerBlue;
        }
        private void LnkOrdHistory_From_Local_Click(object sender, EventArgs e)
        {
            panelUpdate.Visible = false;
            panelCustomers.Visible = false;
            panAddCust.Visible = false;
            panelCustDetails.Visible = false;
            panelOrder.Visible = false;
            panelOrderHistory.Visible = true;
            panelOrderHistory_Refresh();
        }
        private void lnkUpdatesfromLocalUser_Click(object sender, EventArgs e)
        {
            panelOrderHistory.Visible = false;
            panelCustomers.Visible = false;
            panAddCust.Visible = false;
            panelCustDetails.Visible = false;
            panelOrder.Visible = false;
            panelUpdate.Visible = true;
        }
        private void lnkGenerateOrd_MouseHover(object sender, EventArgs e)
        {
            lnkGenerateOrd.BackColor = Color.ForestGreen;
            lnkGenerateOrd.ForeColor = Color.White;
        }
        private void lnkGenerateOrd_MouseLeave(object sender, EventArgs e)
        {
            lnkGenerateOrd.BackColor = Color.DarkGreen;
            lnkGenerateOrd.ForeColor = Color.Silver;
        }
        private void lnkUpdatesfromLocalUser_MouseHover(object sender, EventArgs e)
        {
            lnkUpdatesfromLocalUser.ForeColor = Color.Snow;
        }
        private void lnkUpdatesfromLocalUser_MouseLeave(object sender, EventArgs e)
        {
            lnkUpdatesfromLocalUser.ForeColor = Color.Silver;
        }
        private void LnkOrdHistory_From_Local_MouseHover(object sender, EventArgs e)
        {
            LnkOrdHistory_From_Local.ForeColor = Color.Snow;
        }
        private void LnkOrdHistory_From_Local_MouseLeave(object sender, EventArgs e)
        {
            LnkOrdHistory_From_Local.ForeColor = Color.Silver;
        }
        private void lnkUpdates_MouseHover(object sender, EventArgs e)
        {
            lnkUpdates.ForeColor = Color.Snow;
        }
        private void lnkUpdates_MouseLeave(object sender, EventArgs e)
        {
            lnkUpdates.ForeColor = Color.Silver;
        }
        private void lnkCustomers_MouseHover(object sender, EventArgs e)
        {
            lnkCustomers.ForeColor = Color.Snow;
        }
        private void lnkCustomers_MouseLeave(object sender, EventArgs e)
        {
            lnkCustomers.ForeColor = Color.Silver;
        }
        private void lnkProducts_MouseHover(object sender, EventArgs e)
        {
            lnkProducts.ForeColor = Color.Snow;
        }
        private void lnkProducts_MouseLeave(object sender, EventArgs e)
        {
            lnkProducts.ForeColor = Color.Silver;
        }
        private void lnkOrderHistory_from_Super_MouseHover(object sender, EventArgs e)
        {
            lnkOrderHistory_from_Super.ForeColor = Color.Snow;
        }
        private void lnkOrderHistory_from_Super_MouseLeave(object sender, EventArgs e)
        {
            lnkOrderHistory_from_Super.ForeColor = Color.Silver;
        }
        private void btnLogut1_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.Visible = true;
        }
        public void Refresh_CustomerUpdates()
        {
            SqlDataAdapter ad1 = new SqlDataAdapter
                (
                "SELECT * from Customer " +
                "WHERE " +
                "date_from > CONVERT(date, getdate()) AND date_from < getdate() " +
                "ORDER BY Id DESC"
                  , conn
                );
            DataTable prodTable1 = new DataTable();
            ad1.Fill(prodTable1);
            dataGridViewUpdates.DataSource = prodTable1;
        }
        public void Refresh_ProductsUpdates()
        {
            SqlDataAdapter ad1 = new SqlDataAdapter
                (
                "SELECT * FROM Product " +
                        "where datetime_of_AddingProd > CONVERT (date,getdate()) AND datetime_of_AddingProd < getdate() " +
                        "ORDER BY prod_id DESC "
                  , conn
                );
            SqlDataAdapter ad2 = new SqlDataAdapter
                (
                "SELECT " +
                    "prod_id as 'Product Id', " +
                    "prod_type as 'Product type', " +
                    "prod_name as 'Product Name', " +
                    "brand as Brand, " +
                    "prod_price as Price, " +
                    "available_stock as 'Available Stock' " +
                "FROM Product " +
                "where " +
                    "datetime_of_AddingProd > CONVERT (date,getdate()) AND datetime_of_AddingProd < getdate() " +
                "ORDER BY " +
                    "prod_id DESC "
                  , conn
                );
            DataTable prodTable1 = new DataTable();
            if (SuperUser_Active == true)
            {
                ad1.Fill(prodTable1);
                dataGridViewUpdates.DataSource = prodTable1;
            }
            else
            {
                ad2.Fill(prodTable1);
                dataGridViewUpdates.DataSource = prodTable1;
            }

        }
    }
    public class GetValuesforOrder
    {
        public string[] ProdName = new string[10];
        public int[] ProdId = new int[10];
        public int[] ProdQuantity = new int[10];
        public int NoOfItems;
        public int[] ProdPrice = new int[10];
        public float OverAllAmount;
    }
    public class GetCustomerDetails
    {
        public int[] custId = new int[100];
        public string[] custName = new string[100];

    }
    public class GetProductsDetails
    {
        public int[] prodId = new int[100];
        public string[] prodTyoe = new string[100];
        public string[] prodName = new string[100];
        public string[] brandName = new string[100];
        public int[] prodPrice = new int[100];
        public int[] prodQuantity = new int[100];
        public int[] total_Stock_purch = new int[100];
        public int[] availableStock = new int[100];
        public int[] purchaseingPrice = new int[100];
        public string[] supplyBy = new string[100];
        public DateTime[] purchasingDate = new DateTime[100];
        public DateTime[] AddingDate = new DateTime[100];

    }
}
