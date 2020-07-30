using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OOP_Project1
{
    class Connection1
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sync\Desktop\203-231\DataBaseApp\DBS_DesktopApp\OOP_Project1\OMS.mdf;Integrated Security=True;");
        public Boolean AdminLogin(string Username, string Password)
        {
            string s = "select * from Admins where Admname='" + Username + "' and passwd='" + Password + "' ";
            SqlDataReader reader;
            SqlCommand comm = new SqlCommand(s, conn);
            conn.Open();
            reader = comm.ExecuteReader();
            return reader.Read();
        }
        public Boolean UserLogin(string Username, string Password)
        {
            string s = "select Username, passwd from users where Username='" + Username + "' and passwd='" + Password + "' ";
            SqlDataReader reader;
            SqlCommand comm = new SqlCommand(s, conn);
            conn.Open();
            reader = comm.ExecuteReader();
            return reader.Read();
        }
        public void AddCustomer(string CustName, long Contact, string Email, string Address, string nic, DateTime dob)
        {
            string s = "insert into Customer(cust_name, contact_no, email, cust_address, nic_no, dob, date_purch, date_from) values('" + CustName + "'," + Contact + ",'" + Email + "','" + Address + "','" + nic + "'," + dob.ToOADate() + ", getdate(), getdate())";

            SqlCommand com = new SqlCommand(s, conn);
            SqlCommand comm2 = new SqlCommand
                       (
                       "DECLARE @dob  DATETIME; " +
                           "SET @dob= '" + dob + "' " +
                           "UPDATE Customer set " +
                           "age = DATEDIFF(hour,@dob,GETDATE())/8766.0 " +
                       "where " +
                       "nic_no = '" + nic + "'"
                       , conn);
            conn.Open();
            com.ExecuteNonQuery();
            comm2.ExecuteNonQuery();
            conn.Close();
        }
        public void UpgradeCustomer(int id, string CustName, string Contact, string Email, string Address)
        {
            string s = "update Customer set Customer_Name='" + CustName + "' ,Customer_Contact='" + Contact + "', Customer_Address='" + Email + "', Customer_EmailAddress='" + Address + "' where CustId = '"+id+"'";
            SqlCommand comm = new SqlCommand(s, conn);
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }
        public void delete(string CustName, string Contact, string Email, string Address)
        {
            string s = "delete from Customer where Customer_Name='" + CustName + "'";
            SqlCommand com = new SqlCommand(s, conn);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }
        public void AddProduct(string ProdName, double Price, int Stock)
        {
            string s = "insert into Product(Product_Name, Price, Stock) values('" + ProdName + "','" + Price + "','" + Stock + "')";

            SqlCommand com = new SqlCommand(s, conn);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }
        public void UpgradeProduct(int id, string ProdName, double Price, int Stock)
        {
            string s = "update Product set Product_Name = '" + ProdName + "', Price = '" + Price + "', Stock='" + Stock +  "' where PrdId = '" + id + "'";
            SqlCommand com = new SqlCommand(s, conn);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }
        public void deleteProduct(string ProdName, double Price, int Stock)
        {

            string s = "delete from Product where Product_Name='" + ProdName + "'";
            SqlCommand com = new SqlCommand(s, conn);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }
    }
}

