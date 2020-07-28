using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OOP_Project1
{
    class Connection
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sync\Desktop\203-231\DataBaseApp\DBS_DesktopApp\OOP_Project1\OMS.mdf;Integrated Security=True;");
        public Boolean AdminLogin(string Username, string Password)
        {
            string s = "select Username, Password from Admin where Username='" + Username + "' and Password='" + Password + "' ";
            SqlDataReader reader;
            SqlCommand comm = new SqlCommand(s, conn);
            conn.Open();
            reader = comm.ExecuteReader();
            return reader.Read();
        }
        public Boolean UserLogin(string Username, string Password)
        {
            string s = "select Username, Password from users where Username='" + Username + "' and Password='" + Password + "' ";
            SqlDataReader reader;
            SqlCommand comm = new SqlCommand(s, conn);
            conn.Open();
            reader = comm.ExecuteReader();
            return reader.Read();
        }
        public void AddCustomer(string CustName, string Contact, string Email, string Address)
        {
            string s = "insert into Customer(Customer_Name, Customer_Contact, Customer_EmailAddress, Customer_Address) values('" + CustName + "','" + Contact + "','" + Email + "','" + Address + "' )";

            SqlCommand com = new SqlCommand(s, conn);
            conn.Open();
            com.ExecuteNonQuery();
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

