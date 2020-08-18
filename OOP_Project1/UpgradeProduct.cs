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
    public partial class UpgradeProduct : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\salman\Downloads\203_208_207\203_208_207\OOP_Project1\OOP_Project1\OMS.mdf;Integrated Security = True;");
        public UpgradeProduct()
        {
            InitializeComponent();
        }
        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Hide();
        }

        private void customerInformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CustomerInfo custInfo = new CustomerInfo();
            custInfo.Show();
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
            UpgradeCustomer upgrade = new UpgradeCustomer();
            upgrade.Show();
            this.Hide();
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
            MessageBox.Show("You're already in This Window");
        }
        private void btnUpgradeProduct_Click(object sender, EventArgs e)
        {
            try
            {
                Connection comm = new Connection();
                comm.UpgradeProduct(Convert.ToInt16(txtProductId.Text),txtProductName.Text, Convert.ToDouble(txtProductPrice.Text), Convert.ToInt32(txtProductStock.Text));
                MessageBox.Show("Product has been Updated");
            }
            catch
            {
                MessageBox.Show(" Enter all fields... ");
            }
            txtProductId.Clear();
            txtProductName.Clear();
            txtProductPrice.Clear();
            txtProductStock.Clear();
        }
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                Connection1 conClass = new Connection1();
                SqlCommand comm = new SqlCommand("delete * from Product where Customer_Name = '" + listBox1.SelectedItem + "'", conn);

                conClass.deleteProduct(txtProductName.Text, Convert.ToDouble(txtProductPrice.Text), Convert.ToInt32(txtProductPrice.Text));
                MessageBox.Show(" Customer have been Removed..");

                txtProductName.Clear();
                txtProductPrice.Clear();
                txtProductStock.Clear();
            }
            catch
            {
                MessageBox.Show("Please First Refresh the List. or click the list option.");
            }
        }
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog= office; Integrated Security=True");

            //SqlDataAdapter adpt = new SqlDataAdapter("select * from Customer where Customer_Name = '" + listBox1.SelectedValue + "'", conn);
            //SqlCommandBuilder build = new SqlCommandBuilder(adpt);
            //adpt.Fill(ds, "Customer");

            conn.Open();
            SqlCommand comm1 = new SqlCommand("select * from Product where Product_Name = '" + listBox1.SelectedItem + "'", conn);
            SqlDataReader reader;
            reader = comm1.ExecuteReader();

            while (reader.Read())
            {
                txtProductId.Text = reader["PrdId"].ToString();
                txtProductName.Text = reader["Product_Name"].ToString();
                txtProductPrice.Text = reader["Price"].ToString();
                txtProductStock.Text = reader["Stock"].ToString();
            }
            conn.Close();
        }
        private void UpgradeProduct_Load(object sender, EventArgs e)
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
        private void RefreshGrid_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Show();
                string s = "select * from Product";
                SqlDataAdapter ad = new SqlDataAdapter(s, conn);
                //arsalan
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

        private void newOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewOrder Order = new NewOrder();
            Order.Show();
            this.Hide();
        }
    }
}
