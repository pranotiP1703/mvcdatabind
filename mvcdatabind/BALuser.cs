using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Mvc;
using System.Web.WebPages.Html;
using System.Web.UI.WebControls;
using System.Web.Helpers;


namespace mvcdatabind
{
    public class BALuser
    {

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-U33S9ORF\\;Initial Catalog=MVCsave;Integrated Security=True");


        public void savedata(string name1, string address1, string gender, string country, string state, int city, string phoneno, string email)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spmvc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "DataSave");
            cmd.Parameters.AddWithValue("@name1", name1);
            cmd.Parameters.AddWithValue("@address1", address1);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@country", country);
            cmd.Parameters.AddWithValue("@state", state);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@phoneno", phoneno);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public DataSet getcountry()
        {
            SqlCommand cmd = new SqlCommand("spmvc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Getcountry");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }


        public DataSet getstate(int countryid)
        {
            SqlCommand cmd = new SqlCommand("spmvc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Getstate");
            cmd.Parameters.AddWithValue("@countryid", countryid);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }


        public DataSet getcity(int stateid)
        {
            SqlCommand cmd = new SqlCommand("spmvc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Getcity");
            cmd.Parameters.AddWithValue("@stateid", stateid);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }


        public DataSet displaylist()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spmvc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "displaylist");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }




        public SqlDataReader Edit(int id1, string name1, string address1, string gender, int city, string phno, string email)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spmvc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GetEdit");
            cmd.Parameters.AddWithValue("@id1", id1);
            cmd.Parameters.AddWithValue("@name1", name1);
            cmd.Parameters.AddWithValue("@address1", address1);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@phoneno", phno);
            cmd.Parameters.AddWithValue("@email", email);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

        }

        public void update1(int id1, string name1, string address1, string gender, int city, string phno, string email)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spmvc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "update1");
            cmd.Parameters.AddWithValue("@id1", id1);
            cmd.Parameters.AddWithValue("@name1", name1);
            cmd.Parameters.AddWithValue("@address1", address1);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@phoneno", phno);
            cmd.Parameters.AddWithValue("@email", email);

            cmd.ExecuteNonQuery();
            con.Close();
        }



        public SqlDataReader GetDetail(int id1)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("spmvc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "showdetail");
            cmd.Parameters.AddWithValue("@id1", id1);
            SqlDataReader dr= cmd.ExecuteReader();
            return dr;
            con.Close() ;

        }

        public void deletedata(int id1)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("spmvc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "deletedata");
            cmd.Parameters.AddWithValue("@id1", id1);
            cmd.ExecuteNonQuery();
            con.Close();

        }


    }
}

