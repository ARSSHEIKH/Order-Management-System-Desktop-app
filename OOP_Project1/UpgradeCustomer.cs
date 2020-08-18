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
    public partial class UpgradeCustomer : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\salman\Downloads\203_208_207\203_208_207\OOP_Project1\OOP_Project1\OMS.mdf;Integrated Security = True;");

        public UpgradeCustomer()
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
            MessageBox.Show("You're already in This Window");
        }
        private void btnUpgradeCustome_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DataSet ds = new DataSet();
            //SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog= office; Integrated Security=True");
            //    var adpt = new SqlDataAdapter("select * from Customer where CustId=" + listBox1.SelectedValue, conn);

            //foreach(DataRow dr in ds.Tables["Customer"].Rows)
            //{
            //    dr["Customer_Name"] = txtCustomerName.Text;
            //    dr["Customer_Contact"] = txtCustomerContact.Text;
            //    dr["Customer_EmailAddress"] = txtCustomerEmailAddress.Text;
            //    dr["Customer_Address"] = txtCustomerAddress.Text;

            //}
            //var Builder = new SqlCommandBuilder(adpt);
            //adpt.Update(ds, "Customer");

            try
            {
                Connection1 comm = new Connection1();
                comm.UpgradeCustomer(Convert.ToInt32(txtId.Text), txtCustomerName.Text, txtCustomerContact.Text, txtCustomerEmailAddress.Text, txtCustomerAddress.Text);

                MessageBox.Show("Customer has been Updated");
            }
            catch
            {
                MessageBox.Show(" You are doing somethong wrong ... ");
            }

            txtId.Clear();
            txtCustomerName.Clear();
            txtCustomerContact.Clear();
            txtCustomerEmailAddress.Clear();
            txtCustomerAddress.Clear();
        }
        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                Connection1 conClass = new Connection1();
                SqlCommand comm = new SqlCommand("delete * from Customer where Customer_Name = '" + listBox1.SelectedItem + "'", conn);

                conClass.delete(txtCustomerName.Text, txtCustomerContact.Text, txtCustomerEmailAddress.Text, txtCustomerAddress.Text);
                MessageBox.Show(" Customer have been Removed..");

                txtCustomerName.Clear();
                txtCustomerContact.Clear();
                txtCustomerEmailAddress.Clear();
                txtCustomerAddress.Clear();
            }
            catch
            {
                MessageBox.Show("Please First Refresh the List. or click the list option");
            }
        }
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //DataSet ds = new DataSet();
            //SqlDataAdapter adpt = new SqlDataAdapter("select * from Customer where Customer_Name = '" + listBox1.SelectedValue + "'", conn);
            //SqlCommandBuilder build = new SqlCommandBuilder(adpt);
            //adpt.Fill(ds, "Customer");

            conn.Open();
            SqlCommand comm1 = new SqlCommand("select * from Customer where Customer_Name = '" + listBox1.SelectedItem + "'", conn);
            SqlDataReader reader;
            reader = comm1.ExecuteReader();

            while (reader.Read())
            {
                txtId.Text = reader["CustId"].ToString();
                txtCustomerName.Text = reader["Customer_Name"].ToString();
                txtCustomerContact.Text = reader["Customer_Contact"].ToString();
                txtCustomerEmailAddress.Text = reader["Customer_EmailAddress"].ToString();
                txtCustomerAddress.Text = reader["Customer_Address"].ToString();
            }
            conn.Close();
        }
        private void UpgradeCustomer_Load(object sender, EventArgs e)
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
