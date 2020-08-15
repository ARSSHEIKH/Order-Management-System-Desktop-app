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

namespace OOP_Project1
{
    public partial class ProductInfo : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\salman\Downloads\203_208_207\203_208_207\OOP_Project1\OOP_Project1\OMS.mdf;Integrated Security = True;");
        public ProductInfo()
        {
            InitializeComponent();
        }

        private void ProductInfo_Load(object sender, EventArgs e)
        {
            dataGridView1.Show();
            string s = "select * from Product";
            SqlDataAdapter ad = new SqlDataAdapter(s, conn);

            conn.Open();
            DataTable ProdTable = new DataTable();
            ad.Fill(ProdTable);
            dataGridView1.DataSource = ProdTable;
            conn.Close();
        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main frmMain = new Main();
            frmMain.Show();
            this.Hide();
        }

        private void customerInformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CustomerInfo CustInfo = new CustomerInfo();
            CustInfo.Show();
            this.Hide();
        }

        private void addCustomerNewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddCustomer Add = new AddCustomer();
            Add.Show();
            this.Hide();
        }

        private void updateCustomerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UpgradeCustomer Upgrade = new UpgradeCustomer();
            Upgrade.Show();
            this.Hide();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You're already in This Window");
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AddProduct Add = new AddProduct();
            Add.Show();
            this.Hide();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            UpgradeProduct Upgrade = new UpgradeProduct();
            Upgrade.Show();
            this.Hide();
        }

        private void newOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewOrder Order = new NewOrder();
            Order.Show();
            this.Hide();
        }
    }
}
