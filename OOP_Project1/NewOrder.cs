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
    public partial class NewOrder : Form
    {
        public static string AvailStock;
        public NewOrder()
        {
            InitializeComponent();
        }
        private void NewOrder_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=office;Integrated Security=True");
            string s = "select * from Product";
            SqlDataAdapter ad = new SqlDataAdapter(s, conn);

            conn.Open();
            DataTable ProdTable = new DataTable();
            ad.Fill(ProdTable);
            dataGridView1.DataSource = ProdTable;
            conn.Close();
        }
        private void newOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You're already in This Window");
        }
        private void btnProducts_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=office;Integrated Security=True");
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
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog= office; Integrated Security=True");

            conn.Open();
            SqlCommand comm1 = new SqlCommand("select * from Customer where Customer_Name = '" + listBox1.SelectedItem + "'", conn);
            SqlDataReader reader;
            reader = comm1.ExecuteReader();

            while (reader.Read())
            {
                txtCustomerName.Text = reader["Customer_Name"].ToString();
            }
            conn.Close();
        }
        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
           // ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("Product_Name like '%{0}%'", txtProductName.Text.Trim().Replace("'", "''"));
            
        }
        private void btnCustShow_Click(object sender, EventArgs e)
        {
            try
            {

                string s = "select * from Customer";
                SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog= office; Integrated Security=True");
                conn.Open();
                SqlDataReader reader;
                SqlCommand comm1 = new SqlCommand(s, conn);
                reader = comm1.ExecuteReader();
                while (reader.Read())
                {
                    listBox1.Items.Add(reader["Customer_Name"]);
                }
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Something went Wrong.");
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
  
                int index = e.RowIndex;// get the Row Index
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                txtAmount.Text = selectedRow.Cells[2].Value.ToString();
                txtProductName.Text = selectedRow.Cells[1].Value.ToString();
                txtStock.Text = selectedRow.Cells[3].Value.ToString();
                if (selectedRow.Cells[3] == null)
                {
                    txtStock.Text = "Not Available";
                }
                
                AvailStock = (selectedRow.Cells[3].Value.ToString());            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                
                double items = Convert.ToDouble(txtItems.Text);
                // dataGridView1.Rows[2] = dataGridView1.Rows[2] - 1;
                SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog= office; Integrated Security=True");
                double stock = Convert.ToDouble(txtStock.Text);

                if (Convert.ToDouble(AvailStock) >= items)
                {
                    stock = stock - items;
                    string s = "update Product set Stock = '" + stock + "' where Product_Name = '" + txtProductName.Text + "'";
                    SqlCommand com = new SqlCommand(s, conn);
                    conn.Open();
                    com.ExecuteNonQuery();
                    conn.Close();
                    if (stock == 0)
                    {
                        txtStock.Text = "Not Available";
                        return;
                    }
                    MessageBox.Show("Order Generated");
                    return;
                }
                else
                {
                    MessageBox.Show("Please enter correct No. of Items");
                }
            }
            catch
            {
                MessageBox.Show("Not Available.");
            }
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
            UpgradeProduct Upgrade = new UpgradeProduct();
            Upgrade.Show();
            this.Hide();
        }
    }
}
