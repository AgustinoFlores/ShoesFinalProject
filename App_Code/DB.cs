using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.SessionState;

namespace ShoesProject
{
    public class DB
    {
        SqlConnection myconn;
        SqlCommand myCmd;
        SqlDataAdapter myAdapter;
        String dbLocation;
        //constructor
        public DB()
        {
            myconn = new SqlConnection();
            //Used to connect to the Database regardless of the machine it is on, will always connect to the Database located in the databases folder
            dbLocation = HttpRuntime.AppDomainAppPath + "databases\\Shoes_DB.mdf";
            myconn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"" + dbLocation + "\";Integrated Security=True;Connect Timeout=30";
            myconn.Open();
        }

        public String getPath()
        {
            return dbLocation;
        }

        public DataTable getUsers()
        {
            myCmd = new SqlCommand();
            myCmd.Connection = myconn;
            myCmd.CommandText = "Select * from Users";

            myAdapter = new SqlDataAdapter();
            myAdapter.SelectCommand = myCmd;
            DataTable myDT = new DataTable();

            myAdapter.Fill(myDT);

            return myDT;
        }

        public string login(String username, String password)
        {
            myCmd = new SqlCommand();
            myCmd.Connection = myconn;
            myCmd.CommandText = "Select * from Users WHERE username = @username AND password = @pword";
            myCmd.Parameters.Add("@username", SqlDbType.VarChar);
            myCmd.Parameters["@username"].Value = username;
            myCmd.Parameters.Add("@pword", SqlDbType.VarChar);
            myCmd.Parameters["@pword"].Value = password;

            myAdapter = new SqlDataAdapter();
            myAdapter.SelectCommand = myCmd;
            DataTable tab = new DataTable();

            myAdapter.Fill(tab);

            //If the row count is greater than 0 then the username and password combo was found, return the id! If not found say not found
            return (tab.Rows.Count > 0) ? tab.Rows[0]["userid"].ToString() : "not found";
        }

        public Dictionary<string, string> getData(String id)
        {
            Dictionary<string, string> info = new Dictionary<string, string>();

            myCmd = new SqlCommand();
            myCmd.Connection = myconn;
            myCmd.CommandText = "Select * from Products WHERE product_id = @id";
            myCmd.Parameters.Add("@id", SqlDbType.Int);
            myCmd.Parameters["@id"].Value = int.Parse(id);

            myAdapter = new SqlDataAdapter();
            myAdapter.SelectCommand = myCmd;
            DataTable tab = new DataTable();
            myAdapter.Fill(tab);

            info.Add("name", tab.Rows[0]["product_name"].ToString());
            info.Add("image", tab.Rows[0]["image"].ToString());
            info.Add("description", tab.Rows[0]["description"].ToString());

            return info;
        }

        public Boolean addToCart(string productID)
        {
            HttpSessionState session = HttpContext.Current.Session;
            myCmd = new SqlCommand();
            myCmd.Connection = myconn;
            myCmd.CommandText = @"IF EXISTS(SELECT * FROM Cart WHERE userid = @userid AND product_id = @product)
                        UPDATE Cart 
                        SET quantity = quantity + 1
                        WHERE product_id = @product AND userid = @userid
                    ELSE
                        INSERT INTO Cart(userid, product_id, quantity) VALUES(@userid, @product, 1);";
            myCmd.Parameters.AddWithValue("@userid", session["LoggedUser"]);
            myCmd.Parameters.AddWithValue("@product", productID);

            try
            {
                myCmd.ExecuteReader();
            }catch(Exception e)
            {
                return false;
            }
            

            return true;
        }

        public Boolean removeFromCart(string cart_id)
        {
            myCmd = new SqlCommand();
            myCmd.Connection = myconn;
            myCmd.CommandText = "DELETE FROM Cart WHERE cart_id = @cartid";
            myCmd.Parameters.AddWithValue("@cartid", cart_id);

            try
            {
                myCmd.ExecuteReader();
            } catch(Exception e)
            {
                return false;
            }

            return true;
        }
    }
}