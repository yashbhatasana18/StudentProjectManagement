using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Data;
using DProject.BAL;
using Microsoft.Reporting.WebForms;
using System.Web.Services;

public partial class AdminPanel_LOCRPT_Meeting_RPT_MET_StudentWiseMeeting : System.Web.UI.Page
{
    #region Private Variables

    private DataTable dtStudentWiseMeeting;

    public static DataTable dtMST_Student = new DataTable();

    public static Int32 StudentID;

    private dsProject objdsProject = new dsProject();

    private String LoginType;
    private Int32 LoginID;
    private Int32 InstituteID;
    private Int32 DepartmentID;
    private Int32 AcademicYearID;

    #endregion Private Variables

    #region AutocompleteExtender

    [System.Web.Script.Services.ScriptMethod()]
    [WebMethod(EnableSession = true)]

    public static List<string> GetStudent(string prefixText)
    {
        AdminPanel_LOCRPT_Meeting_RPT_MET_StudentWiseMeeting frm = new AdminPanel_LOCRPT_Meeting_RPT_MET_StudentWiseMeeting();
        
        frm = frm.GetVariable();


        
        MST_StudentBAL balMST_Student = new MST_StudentBAL();
        
        dtMST_Student = balMST_Student.GetStudent(prefixText,frm.LoginType,frm.LoginID,frm.InstituteID,frm.DepartmentID,frm.AcademicYearID);
        
        List<string> Students = new List<string>();

        for (int i = 0; i < dtMST_Student.Rows.Count; i++)
        {
            Students.Add(dtMST_Student.Rows[i][1].ToString());
        }
        return Students;
    }

    #endregion AutocompleteExtender
    private AdminPanel_LOCRPT_Meeting_RPT_MET_StudentWiseMeeting GetVariable()
    {
        AdminPanel_LOCRPT_Meeting_RPT_MET_StudentWiseMeeting frm = new AdminPanel_LOCRPT_Meeting_RPT_MET_StudentWiseMeeting();
        frm.LoginType = Session["UserCatagory"].ToString();
        frm.LoginID = Convert.ToInt32(Session["LoginID"]);
        frm.InstituteID = Convert.ToInt32(Session["InstituteID"]);
        frm.DepartmentID = Convert.ToInt32(Session["DepartmentID"]);
        frm.AcademicYearID = Convert.ToInt32(Session["AcademicYearID"]);

        return frm;
    }
    #region Page Load Event

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        txtStudent.Focus();
        if (!Page.IsPostBack)
        {
            FillDropDownList();
            CheckStudent();
            ShowReport();
        }
    }

    #endregion Page Load Event

    #region Fill DropDownList

    protected void FillDropDownList()
    {
        //CommonFillMethods.FillDropDownListStudentIDForReport(ddlStudentID, Convert.ToString(Session["UserCatagory"]), Convert.ToInt32(Session["LoginID"]), Convert.ToInt32(Session["DepartmentID"]), Convert.ToInt32(Session["InstituteID"]), Convert.ToInt32(Session["AcademicYearID"]));
    }

    #endregion Fill DropDownList

    #region ShowReport

    protected void ShowReport()
    {
        MET_MeetingMasterBAL balMET_Meeting = new MET_MeetingMasterBAL();

        dtStudentWiseMeeting = balMET_Meeting.SelectAllStudentWiseMeeting(Convert.ToString(Session["UserCatagory"]), Convert.ToInt32(Session["LoginID"]), Convert.ToInt32(Session["InstituteID"]), Convert.ToInt32(Session["DepartmentID"]), Convert.ToInt32(Session["AcademicYearID"]), StudentID);
        FillDataSet();
    }

    #endregion ShowReport

    #region FillDataSet

    protected void FillDataSet()
    {
        foreach (DataRow dr in dtStudentWiseMeeting.Rows)
        {
            dsProject.dtStudentWiseMeetingRow drStudentWiseMeeting = objdsProject.dtStudentWiseMeeting.NewdtStudentWiseMeetingRow();

            if (!dr["MeetingID"].Equals(System.DBNull.Value))
                drStudentWiseMeeting.MeetingID = Convert.ToInt32(dr["MeetingID"]);

            if (!dr["ProjectTitle"].Equals(System.DBNull.Value))
                drStudentWiseMeeting.ProjectTitle = Convert.ToString(dr["ProjectTitle"]);

            if (!dr["MeetingDate"].Equals(System.DBNull.Value))
                drStudentWiseMeeting.MeetingDate = Convert.ToDateTime(dr["MeetingDate"]);

            if (!dr["NextMeetingDate"].Equals(System.DBNull.Value))
                drStudentWiseMeeting.NextMeetingDate = Convert.ToDateTime(dr["NextMeetingDate"]);

            if (!dr["WorkDone"].Equals(System.DBNull.Value))
                drStudentWiseMeeting.WorkDone = Convert.ToString(dr["WorkDone"]);

            if (!dr["WorkAssigned"].Equals(System.DBNull.Value))
                drStudentWiseMeeting.WorkAssigned = Convert.ToString(dr["WorkAssigned"]);

            if (!dr["StudentName"].Equals(System.DBNull.Value))
                drStudentWiseMeeting.StudentName = Convert.ToString(dr["StudentName"]);

            if (!dr["EnrollmentNo"].Equals(System.DBNull.Value))
                drStudentWiseMeeting.EnrollmentNo = Convert.ToString(dr["EnrollmentNo"]);

            objdsProject.dtStudentWiseMeeting.Rows.Add(drStudentWiseMeeting);
        }

        SetReportParameters();
        this.rvStudentWiseMeeting.LocalReport.DataSources.Clear();
        this.rvStudentWiseMeeting.LocalReport.DataSources.Add(new ReportDataSource("dtStudentWiseMeeting", (DataTable)objdsProject.dtStudentWiseMeeting));
        this.rvStudentWiseMeeting.LocalReport.Refresh();
    }

    #endregion FillDataSet

    #region SetReportParameters

    private void SetReportParameters()
    {
        this.rvStudentWiseMeeting.LocalReport.EnableExternalImages = true;
        String ReportTitle = "Project Wise Meeting";
        String Department = Session["DepartmentName"].ToString();
        String Semester = "8";
        String AcademicYear = Session["AcademicYearName"].ToString();

        ReportParameter rptReportTitle = new ReportParameter("ReportTitle", ReportTitle);
        ReportParameter rptDepartment = new ReportParameter("Department", Department);
        ReportParameter rptSemester = new ReportParameter("Semester", Semester);
        ReportParameter rptAcademicYear = new ReportParameter("AcademicYear", AcademicYear);

        this.rvStudentWiseMeeting.LocalReport.SetParameters(new ReportParameter[] { rptReportTitle, rptDepartment, rptSemester, rptAcademicYear });
    }

    #endregion SetReportParameters

    #region ddlStudent Selected Index Changed

    protected void ddlStudentID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowReport();
    }

    #endregion ddlStudent Selected Index Changed

    protected void txtStudent_TextChanged(object sender, EventArgs e)
    {
        CheckStudent();
        ShowReport();
    }
    protected void CheckStudent()
    {
        StudentID = -99;
        if (txtStudent.Text != String.Empty)
        {
            if (dtMST_Student.Rows.Count > 0)
            {
                foreach (DataRow dr in dtMST_Student.Rows)
                {
                    if (txtStudent.Text == dr["StuEnroll"].ToString())
                    {
                        StudentID = Convert.ToInt32(dr["StudentID"]);
                        lblMessage.Text = "";
                        break;
                    }
                    else
                    {
                        StudentID = -98;
                        lblMessage.Text = "Student Does Not Exist.";
                    }
                }
            }
            else
            {
                StudentID = -98;
                lblMessage.Text = "Student Does Not Exist";
            }
        }
    }
}