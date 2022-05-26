using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.IO;

public class CommonFunctions
{
    public CommonFunctions()
    {

    }

    public static string encrypt(string encryptString)
    {
        string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                encryptString = Convert.ToBase64String(ms.ToArray());
            }
        }
        return encryptString;
    }
    public static string Decrypt(string cipherText)
    {
        string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        cipherText = cipherText.Replace(" ", "+");
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }
    public static bool IsNumeric(String DataType)
    {
        switch (DataType)
        {
            case "System.Int64":
                return true;
            case "System.Int32":
                return true;
            case "System.Int16":
                return true;
            case "Byte":
                return true;
            case "System.Decimal":
                return true;
            default:
                return false;
        }
    }

    public static bool IsString(String DataType)
    {
        switch (DataType)
        {
            case "System.Char":
                return true;
            case "System.String":
                return true;
            case "System.Guid":
                return true;
            default:
                return false;
        }
    }

    public static bool IsDate(String DataType)
    {
        switch (DataType)
        {
            case "System.DateTime":
                return true;
            default:
                return false;
        }
    }

    public static string ValidateStringValue(string sValue)
    {
        if (sValue == string.Empty)
        {
            return string.Empty;
        }
        int StartIndex = 0;
        int EndIndex = sValue.Length - 1;

        if (sValue.IndexOf('%') != -1)
        {
            if (sValue.IndexOf('%') != StartIndex && sValue.IndexOf('%') != EndIndex)
            {
                sValue = sValue.Remove(sValue.IndexOf('%'), 1);
            }
        }
        if (sValue.IndexOf('*') != -1)
        {
            if (sValue.IndexOf('*') != StartIndex && sValue.IndexOf('*') != EndIndex)
            {
                sValue = sValue.Remove(sValue.IndexOf('*'), 1);
            }
        }
        if (sValue.IndexOf('[') != -1)
        {
            sValue = sValue.Remove(sValue.IndexOf('['), 1);
        }

        if (sValue.IndexOf('\'') != -1)
        {
            sValue = sValue.Replace("\'", "''");
        }

        return sValue;
    }

    public static void FillOperatorDropDownList(DropDownList ddlOperator, Boolean IsBetween)
    {
        ddlOperator.Items.Add(new ListItem("Contains", "Contains"));
        ddlOperator.Items.Add(new ListItem("Equal To", "EqualTo"));
        ddlOperator.Items.Add(new ListItem("Not Equal To", "NotEqualTo"));
        ddlOperator.Items.Add(new ListItem("Greater Than", "GreaterThan"));
        ddlOperator.Items.Add(new ListItem("Less Than", "LessThan"));
        ddlOperator.Items.Add(new ListItem("Greater Than Or EqualTo", "GreaterThanOrEqualTo"));
        ddlOperator.Items.Add(new ListItem("Less Than Or EqualTo", "LessThanOrEqualTo"));
        ddlOperator.Items.Add(new ListItem("In", "In"));
        if (IsBetween)
        {
            ddlOperator.Items.Add(new ListItem("Between", "Between"));
        }
        ddlOperator.Items.Add(new ListItem("Null", "Null"));

    }

    public static string BuildCondition(string Field, string Condition, string FieldValue)
    {
        string sCondition = "";

        #region old code
        //try
        //{
        //    object obj = Convert.ChangeType(Field, Type.GetType(GetFieldDataType(Field)));
        //}
        //catch
        //{
        //    sCondition = "[" + Field + "] = NULL ";
        //    return sCondition;
        //}
        #endregion

        string sValue = ValidateStringValue(FieldValue);

        switch (Condition)
        {
            case "Contains":
                sCondition = " [" + Field + "] " + " LIKE '%" + sValue + "%' ";
                //if (CommonFunctions.IsString(GetFieldDataType(Field)))
                //{
                //    sCondition = " [" + Field + "] " + " LIKE '%" + sValue + "%' ";
                //}
                //else
                //{
                //    sCondition = "[" + Field + "] " + " IS NULL ";
                //}
                break;
            case "EqualTo":
                sCondition = "[" + Field + "] " + " = '" + sValue + "' ";
                break;
            case "NotEqualTo":
                sCondition = "[" + Field + "] " + " <> '" + sValue + "' ";
                break;
            case "GreaterThan":
                sCondition = "[" + Field + "] " + " > '" + sValue + "' ";
                break;
            case "LessThan":
                sCondition = "[" + Field + "] " + " < '" + sValue + "' ";
                break;
            case "GreaterThanOrEqualTo":
                sCondition = "[" + Field + "] " + " >= '" + sValue + "' ";
                break;
            case "LessThanOrEqualTo":
                sCondition = "[" + Field + "] " + " <= '" + sValue + "' ";
                break;
            case "Null":
                sCondition = "[" + Field + "] " + " IS NULL ";
                //sCondition = "NOT [" + Field + "]  >= '" + sValue + "' AND " + " NOT [" + Field + "]  >= '" + 50 + "' ";
                break;
            case "In":
                sCondition = "[" + Field + "] IN (" + sValue + ") ";
                break;
            default: return String.Empty;
        }

        return sCondition;
    }

    public static string BuildCondition(bool IsNot, string Field, string Condition, string FieldValue, string ToValue)
    {
        string sCondition = "";

        #region FieldDataType And Value Data Validation
        //try
        //{
        //    //object obj1 = Convert.ChangeType(FieldValue, Type.GetType(GetFieldDataType(Field)));
        //    object obj1 = Convert.ChangeType(FieldValue, Type.GetType(FieldDataType));
        //    object obj2;
        //    if (ToValue != String.Empty)
        //    {
        //        //obj2 = Convert.ChangeType(ToValue, Type.GetType(GetFieldDataType(Field)));
        //        obj2 = Convert.ChangeType(ToValue, Type.GetType(FieldDataType));
        //    }
        //}
        //catch
        //{
        //    sCondition = String.Empty;
        //    return sCondition;
        //}

        #endregion

        string sValue = ValidateStringValue(FieldValue);
        if (ToValue != String.Empty)
        {
            ToValue = ValidateStringValue(ToValue);
        }


        if (Condition != "Between")
        {
            if (IsNot)
            {
                sCondition += " NOT ";
            }
        }

        switch (Condition)
        {
            case "Contains":
                // if (!CommonFunctions.IsString(FieldDataType))
                // {
                sCondition += "[" + Field + "] " + " LIKE '%" + FieldValue + "%' ";
                // }
                // else
                //{
                //   sCondition = String.Empty;
                // }
                break;
            case "EqualTo":
                sCondition += "[" + Field + "] " + " = '" + FieldValue + "' ";
                break;
            case "NotEqualTo":
                sCondition += "[" + Field + "] " + " <> '" + FieldValue + "' ";
                break;
            case "GreaterThan":
                sCondition += "[" + Field + "] " + " > '" + FieldValue + "' ";
                break;
            case "LessThan":
                sCondition += "[" + Field + "] " + " < '" + FieldValue + "' ";
                break;
            case "GreaterThanOrEqualTo":
                sCondition += "[" + Field + "] " + " >= '" + FieldValue + "' ";
                break;
            case "LessThanOrEqualTo":
                sCondition += "[" + Field + "] " + " <= '" + FieldValue + "' ";
                break;
            case "Null":
                sCondition += "[" + Field + "] " + " IS NULL ";
                break;
            case "Between":
                if (IsNot)
                {
                    //sCondition = " [" + Field + "] >= '" + FieldValue + "' AND " + " NOT [" + Field + "] <= '" + ToValue + "' ";
                    sCondition = " NOT ( [" + Field + "] >= '" + FieldValue + "' AND " + " [" + Field + "] <= '" + ToValue + "' ) ";
                }
                else
                {
                    sCondition = "[" + Field + "] >= '" + FieldValue + "' AND " + "[" + Field + "] <= '" + ToValue + "' ";
                }
                break;
            case "In":
                sCondition = "[" + Field + "] IN (" + FieldValue + ") ";
                break;
            default: return String.Empty;
        }

        return sCondition;
    }

    public static void SendEmail(MailMessage mm)
    {
        mm.Subject = DateTime.Now.ToString("dd-MM-yy hh:mm:ss") + " - " + mm.Subject;
        SmtpClient sc = new SmtpClient("mail.gujaratit.in");
        sc.Credentials = new NetworkCredential("mail@gujaratit.in", "copypower1");
        sc.Send(mm);

    }

    #region Function For Paging In List Page

    public static void BindPageList(Int32 TotalPages, Int32 TotalRecords, Int32 CurrentPage, Int32 PageDisplaySize, Int32 DisplayIndex, Repeater rp, HtmlGenericControl liPrevious, LinkButton lbtnPrevious, HtmlGenericControl liFirstPage, LinkButton lbtnFirstPage, HtmlGenericControl liNext, LinkButton lbtnNext, HtmlGenericControl liLastPage, LinkButton lbtnLastPage)
    {
        if (TotalRecords == 0 && TotalPages == 0)
        {
            liPrevious.Attributes["class"] = "paginate_button previous disabled";
            lbtnPrevious.Enabled = false;
            liFirstPage.Attributes["class"] = "paginate_button previous disabled";
            lbtnFirstPage.Enabled = false;
            liNext.Attributes["class"] = "paginate_button next disabled";
            lbtnNext.Enabled = false;
            liLastPage.Attributes["class"] = "paginate_button next disabled";
            lbtnLastPage.Enabled = false;
            return;
        }

        if (CurrentPage == 1)
        {
            liPrevious.Attributes["class"] = "paginate_button previous disabled";
            lbtnPrevious.Enabled = false;
            liFirstPage.Attributes["class"] = "paginate_button previous disabled";
            lbtnFirstPage.Enabled = false;
        }
        else
        {
            liPrevious.Attributes["class"] = "paginate_button previous";
            lbtnPrevious.Enabled = true;
            liFirstPage.Attributes["class"] = "paginate_button previous";
            lbtnFirstPage.Enabled = true;

        }
        if (CurrentPage == TotalPages)
        {
            liNext.Attributes["class"] = "paginate_button next disabled";
            lbtnNext.Enabled = false;
            liLastPage.Attributes["class"] = "paginate_button next disabled";
            lbtnLastPage.Enabled = false;
        }
        else
        {
            liNext.Attributes["class"] = "paginate_button next";
            lbtnNext.Enabled = true;
            liLastPage.Attributes["class"] = "paginate_button next";
            lbtnLastPage.Enabled = true;
        }

        if (TotalPages <= PageDisplaySize)
        {
            BindPage(1, TotalPages, rp);
        }
        else if (TotalPages > PageDisplaySize)
        {
            if (CurrentPage <= DisplayIndex)
            {
                BindPage(1, PageDisplaySize, rp);
            }
            else
            {
                int Suffix = PageDisplaySize - DisplayIndex;

                int Prefix = PageDisplaySize - Suffix - 1;

                if ((CurrentPage + Suffix) >= TotalPages)
                {
                    BindPage(CurrentPage - Prefix, TotalPages, rp);
                }
                else
                {
                    BindPage(CurrentPage - Prefix, CurrentPage + Suffix, rp);
                }
            }
        }
    }

    public static void BindPage(int FirstPage, int LastPage, Repeater rp)
    {
        DataTable dtPageNo = new DataTable();
        dtPageNo.Columns.Add("PageNo");
        for (int i = FirstPage; i <= LastPage; i++)
        {
            DataRow drPageNo = dtPageNo.NewRow();
            drPageNo["PageNo"] = i.ToString();
            dtPageNo.Rows.Add(drPageNo);
        }
        rp.DataSource = dtPageNo;
        rp.DataBind();
    }

    public static void GetDropDownPageSize(DropDownList ddl)
    {
        List<ListItem> pageSize = new List<ListItem>();
        pageSize.Add(new ListItem("All", "0"));
        pageSize.Add(new ListItem("5", "5"));
        pageSize.Add(new ListItem("10", "10"));
        pageSize.Add(new ListItem("20", "20"));
        pageSize.Add(new ListItem("50", "50"));
        pageSize.Add(new ListItem("100", "100"));
        pageSize.Add(new ListItem("500", "500"));

        foreach (ListItem li in pageSize)
        {
            ddl.Items.Add(li);
        }
    }

    #endregion Function For Paging In List Page

    #region Custom Developer Function

    public static void BindEmptyRepeater(Repeater rp)
    {
        rp.DataSource = null;
        rp.DataBind();
    }

    #endregion Custom Developer Function
}
