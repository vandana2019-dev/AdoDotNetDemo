using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class GridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=SampleDB;Integrated Security=True");

            // In Part 2, we add try and catch block
            try
            {

                SqlCommand cmd = new SqlCommand("Select * from tblEmployee", connection);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                grdEmployee.DataSource = reader;
                grdEmployee.DataBind();
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            // Another way is closing connection is by using 
            using (SqlConnection connection2 = new SqlConnection("Data Source=localhost;Initial Catalog=SampleDB;Integrated Security=True"))
            {
                SqlCommand cmd2 = new SqlCommand("Select * from tblPerson", connection2);

                connection2.Open();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                grdPerson.DataSource = reader2;
                grdPerson.DataBind();

            }  // as soon as the program comes to this line, it will close the connection

            // Part 3 - reading connection string from web.config
            string connectionString= ConfigurationManager.ConnectionStrings["SampleDBConnectionString"].ConnectionString;
            using (SqlConnection connection3 = new SqlConnection(connectionString))
            {
                SqlCommand cmd3 = new SqlCommand("Select * from tblPerson", connection3);

                connection3.Open();
                SqlDataReader reader = cmd3.ExecuteReader();
                grdEmployeeConfig.DataSource = reader;
                grdEmployeeConfig.DataBind();
            }  // as soon as the program comes to this line, it will close the connection


            // Part 4 - Sql Command in ado.net, using ExecuteReader
            string connectionString4 = ConfigurationManager.ConnectionStrings["SampleDBConnectionString"].ConnectionString;
            using (SqlConnection connection4 = new SqlConnection(connectionString4))
            {
                SqlCommand cmd4 = new SqlCommand("Select * from tblPerson", connection4);

                connection4.Open();
                SqlDataReader reader = cmd4.ExecuteReader();
                grdEmployeeConfig.DataSource = reader;
                grdEmployeeConfig.DataBind();
            }  

            string connectionString5 = ConfigurationManager.ConnectionStrings["SampleDBConnectionString"].ConnectionString;
            using (SqlConnection connection5 = new SqlConnection(connectionString5))
            {
                SqlCommand cmd4 = new SqlCommand("Select * from tblPerson", connection5);

                connection5.Open();
                int totalRows = (int)cmd4.ExecuteScalar();
                Response.Write("Total rows " + totalRows.ToString());
                Response.Write("<br/>");
            }


            string connectionString6 = ConfigurationManager.ConnectionStrings["SampleDBConnectionString"].ConnectionString;
            using (SqlConnection connection5 = new SqlConnection(connectionString6))
            {
                SqlCommand cmd4 = new SqlCommand();
                cmd4.Connection = connection5;
                cmd4.CommandText = "Insert into tblPerson values (6,'Employee6','e@e.com', 2,45)";
                connection5.Open();
                int rowsAffected = (int)cmd4.ExecuteNonQuery();
                Response.Write("Total rows inserted " + rowsAffected.ToString());
                Response.Write("<br/>");
                               
            }

            using (SqlConnection connection5 = new SqlConnection(connectionString6))
            {
                SqlCommand cmd4 = new SqlCommand();
                cmd4.Connection = connection5;
                cmd4.CommandText = "Update tblPerson set Email = 'eupdated@e.com' where Id = 6";
                connection5.Open();
                int rowsUpdated = (int)cmd4.ExecuteNonQuery();
                Response.Write("Total rows updated " + rowsUpdated.ToString());
                Response.Write("<br/>");
            }
        }
    }
}