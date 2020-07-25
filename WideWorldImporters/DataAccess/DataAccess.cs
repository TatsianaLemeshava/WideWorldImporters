using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


namespace WideWorldImporters.DataAccess
{
    [Serializable]
    public class DataAccess
    {
        public static DataSet GetStockItems()
        {
            SqlConnection connection = Connection.GetDBConnection();

            try
            {
                SqlCommand command = new SqlCommand("spGetStockItems", connection);
                command.CommandType = CommandType.StoredProcedure;
                DataSet dSet = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dSet);

                return dSet;
            }
            catch (SqlException ex)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }


        public static DataSet GetParentsByChild(string ChildFN, string ChildLN)
        {
            SqlConnection connection = Connection.GetDBConnection();

            try
            {
                SqlCommand command = new SqlCommand("spGetParentsByChild", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ChildFN", ChildFN);
                command.Parameters.AddWithValue("@ChildLN", ChildLN);
                DataSet dSet = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dSet);

                return dSet;
            }
            catch (SqlException ex)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }


        public static DataSet GetChild(string ChildFN, string ChildLN)
        {
            SqlConnection connection = Connection.GetDBConnection();

            try
            {
                SqlCommand command = new SqlCommand("spGetChild", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ChildFN", ChildFN);
                command.Parameters.AddWithValue("@ChildLN", ChildLN);
                DataSet dSet = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dSet);

                return dSet;
            }
            catch (SqlException ex)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        public static DataSet GetParentByFNLN(string ParentFN, string ParentLN)
        {
            SqlConnection connection = Connection.GetDBConnection();

            try
            {
                SqlCommand command = new SqlCommand("spGetParentByFNLN", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ParentFN", ParentFN);
                command.Parameters.AddWithValue("@ParentLN", ParentLN);
                DataSet dSet = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dSet);

                return dSet;
            }
            catch (SqlException ex)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public static DataSet GetAllChildrenParents(SqlConnection connection)
        {

            try
            {
                SqlCommand command = new SqlCommand("spGetAllChildrenParents", connection);
                command.CommandType = CommandType.StoredProcedure;
                DataSet dSet = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dSet);

                return dSet;
            }
            catch (SqlException ex)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public static DataSet GetAllParents()
        {
            SqlConnection connection = Connection.GetDBConnection();

            try
            {
                SqlCommand command = new SqlCommand("spGetAllParents", connection);
                command.CommandType = CommandType.StoredProcedure;
                DataSet dSet = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dSet);

                if (dSet.Tables.Count == 0)
                {
                    EmptyTableException ex = new EmptyTableException("Exception on page GetParentsChildrens. ");
                    throw ex;
                }

                return dSet;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public static DataSet GetAllChildren()
        {
            SqlConnection connection = Connection.GetDBConnection();
            try
            {
                SqlCommand command = new SqlCommand("spGetAllChildren", connection);
                command.CommandType = CommandType.StoredProcedure;
                DataSet dSet = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dSet);

                return dSet;
            }
            catch (SqlException ex)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        public static void UpdateParent(string ParentFN, string ParentLN, string newParentFN, string newParentLN, string newParentDoB)
        {
            SqlConnection connection = Connection.GetDBConnection();

            try
            {
                SqlCommand command = new SqlCommand("spUpdateParent", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ParentFN", ParentFN);
                command.Parameters.AddWithValue("@ParentLN", ParentLN);
                command.Parameters.AddWithValue("@newParentFN", newParentFN);
                command.Parameters.AddWithValue("@newParentLN", newParentLN);
                command.Parameters.AddWithValue("@newParentDoB", newParentDoB);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }


        public static void SetParentsChildrenPersons(string ParentFN, string ParentLN, string ParentDoB, string ChildFN, string ChildLN, string ChildDoB)
        {
            SqlConnection connection = Connection.GetDBConnection();

            try
            {
                SqlCommand command = new SqlCommand("spSetParentsChildrenPersons", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ParentFN", ParentFN);
                command.Parameters.AddWithValue("@ParentLN", ParentLN);
                command.Parameters.AddWithValue("@ParentDoB", ParentDoB);
                command.Parameters.AddWithValue("@ChildFN", ChildFN);
                command.Parameters.AddWithValue("@ChildLN", ChildLN);
                command.Parameters.AddWithValue("@ChildDoB", ChildDoB);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}