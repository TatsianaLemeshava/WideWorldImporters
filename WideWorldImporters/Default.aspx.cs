using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace WideWorldImporters
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Text = "We will test the connection to the database.";
                try
                {
                    SqlConnection connection = DataAccess.Connection.GetDBConnection();
                    connection.Close();
                    Label1.Text = "We successfully tested connection to the database";
                }
                catch (SqlException ex)
                {
                    Label1.Text = SqlExceptionHelper.GetErrorExplanation(ex);
                }

            }
        }
    }
}