using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DProject
{
    public class DataBaseConfig
    {
        public static string myConnectionString = ConfigurationManager.ConnectionStrings["DProjectConnectionString"].ConnectionString.ToString();

        public string GetErrorMessage(int Error)
        {
            return "";
        }

        public string Error547 = "This record cannot be inserted or deleted.\n Violation of foreignkey";
        public string Error547Delete = "This record cannot be inserted or deleted.\n Violation of foreignkey";
        public string Error2627 = "Duplicate value cannot be inserted.\nViolation of uniqueness.";
        public string Error2601 = "Duplicate value cannot be inserted.\nViolation of uniqueness.";
        public string SQLDataExceptionMessage(SqlException sqlex)
        {
            switch (sqlex.Number)
            {
                case 17:
                    //     SQL Server does not exist or access denied. 
                    return "SQL Server does not exist or access denied.";
                //case 4060:
                //    // Invalid Database  
                //    return "Invalid Database";
                case 18456:
                    // Login Failed 
                    return "Login Failed ";
                case 547:
                    // ForeignKey Violation 
                    return Error547;
                case 2627:
                    // Unique Index/Constriant Violation 
                    return Error2627;
                case 2601:
                    // Unique Index/Constriant Violation 
                    return Error2601;
                default:
                    // throw a general DAL Exception 
                    return sqlex.Message;
            }
        }

        public Boolean SQLDataExceptionHandler(SqlException sqlex)
        {
            #region Log DataBase Error in File
            //DirectoryInfo di = new DirectoryInfo("ErrorFiles");
            //if (!di.Exists)
            //    di.Create();
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine("DateTime=" + DateTime.Now.ToString());
            ////sb.AppendLine("UserID=" + 1.ToString());
            //sb.AppendLine("Message=" + sqlex.Message.ToString());
            //sb.AppendLine("Number=" + sqlex.Number.ToString());
            //if (sqlex.Procedure != null)
            //    sb.AppendLine("Procedure=" + sqlex.Procedure.ToString());
            //if (sqlex.Server != null)
            //    sb.AppendLine("Server=" + sqlex.Server.ToString());
            //sb.AppendLine("ErrorCode=" + sqlex.ErrorCode.ToString());
            //sb.AppendLine("LineNumber=" + sqlex.LineNumber.ToString());
            //sb.AppendLine("State=" + sqlex.State.ToString());
            //if (sqlex.TargetSite != null)
            //    sb.AppendLine("TargetSite=" + sqlex.TargetSite.ToString());
            //sb.AppendLine("Class=" + sqlex.Class.ToString());
            //if (sqlex.Source != null)
            //    sb.AppendLine("Source=" + sqlex.Source.ToString());
            //if (sqlex.StackTrace != null)
            //    sb.AppendLine("StackTrace=" + sqlex.StackTrace.ToString());
            //if (sqlex.InnerException != null)
            //{
            //    sb.AppendLine("Inner Exception");
            //    sb.AppendLine("Message=" + sqlex.InnerException.Message.ToString());
            //    sb.AppendLine("Source=" + sqlex.InnerException.Source.ToString());
            //    sb.AppendLine("");
            //}
            //foreach (SqlError sqlerror in sqlex.Errors)
            //{
            //    sb.AppendLine("Message=" + sqlerror.Message.ToString());
            //    sb.AppendLine("Number=" + sqlerror.Number.ToString());
            //    if (sqlex.Procedure != null)
            //        sb.AppendLine("Procedure=" + sqlex.Procedure.ToString());
            //    if (sqlex.Server != null)
            //        sb.AppendLine("Server=" + sqlex.Server.ToString());
            //    sb.AppendLine("ErrorCode=" + sqlex.ErrorCode.ToString());
            //    sb.AppendLine("LineNumber=" + sqlex.LineNumber.ToString());
            //    sb.AppendLine("State=" + sqlex.State.ToString());
            //    if (sqlex.TargetSite != null)
            //        sb.AppendLine("TargetSite=" + sqlex.TargetSite.ToString());
            //    sb.AppendLine("Class=" + sqlex.Class.ToString());
            //    if (sqlex.Source != null)
            //        sb.AppendLine("Source=" + sqlex.Source.ToString());
            //    if (sqlex.StackTrace != null)
            //        sb.AppendLine("StackTrace=" + sqlex.StackTrace.ToString());
            //}
            //StreamWriter sw;
            //sw = File.CreateText("ErrorFiles\\" + DateTime.Now.ToString("yyMMdd_HHmmss") + ".txt");
            //sw.Write(sb.ToString());
            //sw.Close();
            #endregion Log DataBase Error in File

            //return false;
            return true;

        }

        public string ExceptionMessage(Exception ex)
        {
            return "";
        }
        public Boolean ExceptionHandler(Exception ex)
        {
            return true;
        }

        public DataBaseConfig()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}