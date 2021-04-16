using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;

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
    }
}