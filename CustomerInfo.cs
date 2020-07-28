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
    public partial class CustomerInfo : Form
    {
        public CustomerInfo()
        {
            InitializeComponent();
        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
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
        private void customerInformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You're already in This Window");
        }
        private void CustomerInfo_Load(object sender, EventArgs e)
        {
            dataGridView1.Show();
            SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\salman\Downloads\203_208_207\203_208_207\OOP_Project1\OOP_Project1\OMS.mdf;Integrated Security = True;");
            string s = "select * from Customer";
            SqlDataAdapter ad = new SqlDataAdapter(s, conn);

            conn.Open();
            DataTable CustTable = new DataTable();
            ad.Fill(CustTable);
            dataGridView1.DataSource = CustTable;
            conn.Close();
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ProductInfo ProdInfo = new ProductInfo();
            ProdInfo.Show();
            this.Hide();
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
