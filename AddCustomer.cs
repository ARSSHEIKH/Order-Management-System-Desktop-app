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
    public partial class AddCustomer : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\salman\Downloads\203_208_207\203_208_207\OOP_Project1\OOP_Project1\OMS.mdf;Integrated Security = True;");

        public AddCustomer()
        {
            InitializeComponent();
        }
        private void btnNewCustome_Click(object sender, EventArgs e)
        {
            try
            {
                Connection comm = new Connection();
                comm.AddCustomer(txtCustomerName.Text, txtCustomerContact.Text, txtCustomerEmailAddress.Text, txtCustomerAddress.Text);

                MessageBox.Show("New Customer inserted");
            }
            catch
            {
                MessageBox.Show(" Some went Wrong... ");
            }
            txtCustomerName.Clear();
            txtCustomerContact.Clear();
            txtCustomerEmailAddress.Clear();
            txtCustomerAddress.Clear();
        }
        private void RefreshGrid_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Show();
                string s = "select * from Customer";
                SqlDataAdapter ad = new SqlDataAdapter(s, conn);

                conn.Open();
                DataTable CustTable = new DataTable();
                ad.Fill(CustTable);
                dataGridView1.DataSource = CustTable;
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Something went Wrong.");
            }
        }
        private void AddCustomer_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();

            string s = "select * from Customer";
            conn.Open();
            SqlDataReader reader;
            SqlCommand comm = new SqlCommand(s, conn);
            reader = comm.ExecuteReader();

            while (reader.Read())
            {
                listBox1.Items.Add(reader["Customer_Name"]);
            }
        }       
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                string s = "select * from Customer";
                conn.Open();
                SqlDataReader reader;
                SqlCommand comm = new SqlCommand(s, conn);
                reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    listBox1.Items.Add(reader["Customer_Name"]);
                }
            }
            catch
            {
                MessageBox.Show("Something went Wrong.");
            }
        }

        private void customerInformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CustomerInfo custInfo = new CustomerInfo();
            custInfo.Show();
            this.Hide();
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
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AddProduct Add = new AddProduct();
            Add.Show();
            this.Hide();
        }
        private void addCustomerNewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You're already in This Window");
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


