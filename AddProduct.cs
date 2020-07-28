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
    public partial class AddProduct : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\salman\Downloads\203_208_207\203_208_207\OOP_Project1\OOP_Project1\OMS.mdf;Integrated Security = True;");
        public AddProduct()
        {
            InitializeComponent();
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ProductInfo ProdInfo = new ProductInfo();
            ProdInfo.Show();
            this.Hide();
        }
        private void updateCustomerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UpgradeCustomer upgrade = new UpgradeCustomer();
            upgrade.Show();
            this.Hide();
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
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You're already in This Window");
        }        

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            try
            {
                Connection comm = new Connection();
                comm.AddProduct(txtProductName.Text, Convert.ToDouble(txtProductPrice.Text), Convert.ToInt32(txtProductStock.Text));
                MessageBox.Show("New Product inserted");
            }
            catch
            {
                MessageBox.Show(" You're Giving Some Wrong Input... ");
            }
            txtProductName.Clear();
            txtProductPrice.Clear();
            txtProductStock.Clear();
        }

        private void RefreshGrid_Click(object sender, EventArgs e)
        {
            try
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
            catch
            {
                MessageBox.Show("Something went Wrong.");
            }
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();

            string s = "select * from Product";
            conn.Open();
            SqlDataReader reader;
            SqlCommand comm = new SqlCommand(s, conn);
            reader = comm.ExecuteReader();

            while (reader.Read())
            {
                listBox1.Items.Add(reader["Product_Name"]);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                string s = "select * from Product";
                conn.Open();
                SqlDataReader reader;
                SqlCommand comm = new SqlCommand(s, conn);
                reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    listBox1.Items.Add(reader["Product_Name"]);
                }
            }
            catch
            {
                MessageBox.Show("Something went Wrong.");
            }
        }
        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            ProductInfo ProdInfo = new ProductInfo();
            ProdInfo.Show();
            this.Hide();
        }

        private void customerInformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CustomerInfo CustInfo = new CustomerInfo();
            CustInfo.Show();
            this.Hide();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            UpgradeProduct upgrade = new UpgradeProduct();
            upgrade.Show();
            this.Hide();
        }

        private void newOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewOrder Order = new NewOrder();
            Order.Show();
            this.Hide();
        }

        private void UpdateProdMenuItem4_Click_1(object sender, EventArgs e)
        {
            UpgradeProduct upgrade = new UpgradeProduct();
            upgrade.Show();
            this.Hide();
        }
    }
}
