using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm_Part7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Part 8, Sql DataReader
            //Read the connection string from Web.Config file
            string connectionString = ConfigurationManager.ConnectionStrings["SampleDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from tblEmployees_Adonet", con);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable table = new DataTable();
                table.Columns.Add("ID");
                table.Columns.Add("Name");
                table.Columns.Add("Gender");
                //table.Columns.Add("Salary");

                while (reader.Read())
                {
                    DataRow dataRow = table.NewRow();
                    dataRow["ID"] = reader["EmployeeId"];
                    dataRow["Name"] = reader["Name"];
                    dataRow["Gender"] = reader["Gender"];
                    //dataRow["Salary"] = reader["Salary"];

                    table.Rows.Add(dataRow);
                }

                //GridView1.DataSource = reader;
                //GridView1.DataBind();

                // Bind the Grid Datasource to a table
                GridView1.DataSource = table;
                GridView1.DataBind();
            }

            // Part 9 Using NextResult
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from tblProductInventory; select * from tblProductCategories", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    ProductsGridView.DataSource = reader;
                    ProductsGridView.DataBind();

                    // Here we can see only the first result set tblProductInventory is bound to the Grid View
                    //CategoriesGridView.DataSource = reader;
                    //CategoriesGridView.DataBind();

                    // Fetches the next result, tblProductCategories is bound to the CategoriesGridView
                    while (reader.NextResult())
                    {
                        CategoriesGridView.DataSource = reader;
                        CategoriesGridView.DataBind();
                    }
                }
            }

            // Part 10 SqlDataAdapter
         
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create an instance of SqlDataAdapter. Spcify the command and the connection
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from tblProductInventory", connection);
                // Create an instance of DataSet, which is an in-memory datastore for storing tables
                DataSet dataset = new DataSet();
                // Call the Fill() methods, which automatically opens the connection, executes the command 
                // and fills the dataset with data, and finally closes the connection.
                dataAdapter.Fill(dataset);

                gridViewProduct.DataSource = dataset;
                gridViewProduct.DataBind();
            }


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create an instance of SqlDataAdapter, specifying the stored procedure
                // and the connection object to use
                SqlDataAdapter dataAdapter = new SqlDataAdapter("spGetProductInventoryById", connection);
                // Specify the command type is an SP
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                // Associate the parameter with the stored procedure
                dataAdapter.SelectCommand.Parameters.AddWithValue("@ProductId", 1);
                DataSet dataset = new DataSet();
                dataAdapter.Fill(dataset);

                gridViewProductsp.DataSource = dataset;
                gridViewProductsp.DataBind();
            }


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("spGetProductAndCategoriesData", connection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet dataset = new DataSet();
                dataAdapter.Fill(dataset);


                // Here both the GridView Controls show the Same Data
                //GridViewProducts.DataSource = dataset;
                //GridViewProducts.DataBind();

                //GridViewCategories.DataSource = dataset;
                //GridViewCategories.DataBind();


                // First Option to bind the Data

                //GridViewProducts.DataSource = dataset.Tables[0];
                //GridViewProducts.DataBind();

                //GridViewCategories.DataSource = dataset.Tables[1];
                //GridViewCategories.DataBind();

                // Second Option to bind the Data, by setting the table names
                dataset.Tables[0].TableName = "Products";
                dataset.Tables[1].TableName = "Categories";

                GridViewProducts.DataSource = dataset.Tables["Products"];
                GridViewProducts.DataBind();

                GridViewCategories.DataSource = dataset.Tables["Categories"];
                GridViewCategories.DataBind();
            }


            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Part 7, execute a stored procedure with output parameter
            //Read the connection string from Web.Config file
            string connectionString = ConfigurationManager.ConnectionStrings["SampleDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //Create the SqlCommand object
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                //Specify that the SqlCommand is a stored procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd.Parameters.AddWithValue("@Name", txtEmployeeName.Text);
                cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                cmd.Parameters.AddWithValue("@Salary", txtSalary.Text);

                //Add the output parameter to the command object
                SqlParameter outPutParameter = new SqlParameter();
                outPutParameter.ParameterName = "@EmployeeId";
                outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                outPutParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outPutParameter);

                //Open the connection and execute the query
                con.Open();
                cmd.ExecuteNonQuery();

                //Retrieve the value of the output parameter
                string EmployeeId = outPutParameter.Value.ToString();
                lblMessage.Text = "Employee Id = " + EmployeeId;
            }


        }

        protected void btnLoadData_Click(object sender, EventArgs e)
        {
            // Part 12 - Cache Dataset
            if (Cache["Data"] == null)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["SampleDBConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Create an instance of SqlDataAdapter. Spcify the command and the connection
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from tblProductInventory", connection);
                    // Create an instance of DataSet, which is an in-memory datastore for storing tables
                    DataSet dataset = new DataSet();
                    // Call the Fill() methods, which automatically opens the connection, executes the command 
                    // and fills the dataset with data, and finally closes the connection.
                    dataAdapter.Fill(dataset);

                    Cache["Data"] = dataset;

                    gridViewProductsCache.DataSource = dataset;
                    gridViewProductsCache.DataBind();

                }
                lblMessageCache.Text = "Data Loaded";
            }
            else
            {
                gridViewProductsCache.DataSource = (DataSet)Cache["Data"];
                gridViewProductsCache.DataBind();

                lblMessageCache.Text = "Data Loaded from cache";
            }

        }

        protected void btnClearData_Click(object sender, EventArgs e)
        {
            if (Cache["Data"] != null)
            {
                Cache.Remove("Data");
                lblMessageCache.Text = "The Dataset is removed from the cache";
            }
            else
            {
                lblMessageCache.Text = "There is nothing in the cache to be removed";
            }
        }
    }
}