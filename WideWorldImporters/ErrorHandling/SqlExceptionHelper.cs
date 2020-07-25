using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

public class SqlExceptionHelper
{
    public const int BadObject = 208;
    public const int PermissionDenied = 229;
    public const int InvalidDatabase = 4064;
    public const int LoginFailed = 18456;
    public const int ForeignKeyViolation = 547;
    public const int UniqueIndexViolation = 2601;


    public static string GetErrorExplanation(SqlException ex)
    {

        string explanation = "There are following errors happened:";

        for (int i = 0; i < ex.Errors.Count; i++)
        {
            int errorNumber = ex.Errors[i].Number;
            
            switch (errorNumber)
            {
                case BadObject: 
                    explanation += "Referenced object does not exist, you might need to include the owner's name in the object name.";
                    break;
                case PermissionDenied:
                    explanation += "User attempts an action, such as executing a stored procedure, or reading or modifying a table, for which the user does not have the appropriate privileges.";
                    break;
                case InvalidDatabase:
                    explanation += "SQL Server login was unable to connect because of a problem with its default database. Either the database itself is invalid or the login lacks CONNECT permission on the database.";
                    break;
                case LoginFailed: 
                    explanation += "When a connection attempt is rejected because of an authentication failure that involves a bad password or user name.";
                    break;
                case ForeignKeyViolation: 
                    explanation += "Cannot insert row due to Foreign Key constraint.";
                    break;
                case UniqueIndexViolation:
                    explanation += "User attempt to put duplicate index values into a column or columns that have a unique index.";
                    break;
                default: break;
            }
            explanation += ex.Errors[i].Message;
        }

        return explanation;
    }

}