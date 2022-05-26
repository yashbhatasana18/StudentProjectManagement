using DProject.BAL;
using DProject.DAL;
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;
namespace DProject
{
    public class CommonFillMethods
    {
        public CommonFillMethods()
        {
        }
        public static void FillDate(DropDownList ddlDate, DropDownList ddlMonth, DropDownList ddlYear)
        {
            #region FillDate
            ddlMonth.DataSource = Enumerable.Range(1, 12).Select(a => new
            {
                MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(a),
                MonthNumber = a
            });
            ddlMonth.DataBind();
            ddlYear.DataSource = Enumerable.Range(DateTime.Now.Year - 99, 101).Reverse();
            ddlYear.DataBind();

            ddlDate.DataSource = Enumerable.Range(1, 31);
            ddlDate.DataBind();
            //DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(ddlMonth.SelectedValue))
            ddlYear.Items.Insert(0, new ListItem("Year", "-99"));
            ddlMonth.Items.Insert(0, new ListItem("Month", "-99"));
            ddlDate.Items.Insert(0, new ListItem("Date", "-99"));
            #endregion
        }

        public static void FillDropDownListDepartmentID(DropDownList ddl, SqlInt32 InstituteID)
        {
            MST_DepartmentBAL balMST_Department = new MST_DepartmentBAL();
            ddl.DataSource = balMST_Department.SelectComboBox(InstituteID);
            ddl.DataValueField = "DepartmentID";
            ddl.DataTextField = "DepartmentCode";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(" Select Department ", "-99"));
        }
        public static void FillDropDownListInstDepartment(DropDownList ddl, SqlInt32 InstituteID)
        {
            MST_DepartmentBAL balMST_Department = new MST_DepartmentBAL();
            ddl.DataSource = balMST_Department.SelectInsComboBox(InstituteID);
            ddl.DataValueField = "DepartmentID";
            ddl.DataTextField = "DepartmentCode";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(" Select Department ", "-99"));
        }
        public static void FillDropDownListUserCatagoryID(DropDownList ddl)
        {
            SEC_UserCatagoryBAL balSEC_UserCatagory = new SEC_UserCatagoryBAL();
            ddl.DataSource = balSEC_UserCatagory.SelectComboBox();
            ddl.DataValueField = "UserCatagoryID";
            ddl.DataTextField = "UserCatagory";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(" Select User Catagory ", "-99"));
        }
        public static void FillDropDownListInstituteID(DropDownList ddl)
        {
            MST_InstituteBAL balMST_Institute = new MST_InstituteBAL();
            ddl.DataSource = balMST_Institute.SelectComboBox();
            ddl.DataValueField = "InstituteID";
            ddl.DataTextField = "InstituteName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(" Select Institute ", "-99"));
        }
        public static void FillDropDownListAcademicYearID(DropDownList ddl)
        {
            MST_AcademicYearBAL balMST_AcademicYear = new MST_AcademicYearBAL();
            ddl.DataSource = balMST_AcademicYear.SelectComboBox();
            ddl.DataValueField = "AcademicYearID";
            ddl.DataTextField = "AcademicYearName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(" Select Academic Year", "-99"));
        }
        public static void FillDropDownListAcademicYearIDMaster(DropDownList ddl)
        {
            MST_AcademicYearBAL balMST_AcademicYear = new MST_AcademicYearBAL();
            ddl.DataSource = balMST_AcademicYear.SelectComboBox();
            ddl.DataValueField = "AcademicYearID";
            ddl.DataTextField = "AcademicYearName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(" Select AcademicYear ", "-99"));
        }
        public static void FillDropDownListCityID(DropDownList ddl)
        {
            MST_CityBAL balMST_City = new MST_CityBAL();
            ddl.DataSource = balMST_City.SelectComboBox();
            ddl.DataValueField = "CityID";
            ddl.DataTextField = "CityName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(" Select City ", "-99"));
        }
        public static void FillDropDownListDocumentTypeID(DropDownList ddl, SqlString LoginType, SqlInt32 LoginID, SqlInt32 InstituteID, SqlInt32 DepartmentID)
        {
            DOC_DocumentTypeBAL balDOC_DocumentType = new DOC_DocumentTypeBAL();
            ddl.DataSource = balDOC_DocumentType.SelectComboBox(LoginType, LoginID, InstituteID, DepartmentID);
            ddl.DataValueField = "DocumentTypeID";
            ddl.DataTextField = "DocumentTypeName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(" Select Document Type ", "-99"));
        }
        //public static void FillDropDownListStudentID(DropDownList ddl, SqlInt32 InstituteID, SqlString LoginType, SqlInt32 LoginID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID)
        //{
        //    MST_StudentBAL balMST_Student = new MST_StudentBAL();
        //    ddl.DataSource = balMST_Student.SelectComboBoxByStudentID(InstituteID, LoginType, LoginID, DepartmentID, AcademicYearID);
        //    ddl.DataValueField = "StudentID";
        //    ddl.DataTextField = "StudentName";
        //    ddl.DataBind();
        //    ddl.Items.Insert(0, new ListItem(" Select Student ", "-99"));
        //}

        public static void FillDropDownListTechnologyID(DropDownList ddl)
        {
            PRJ_TechnologyBAL balPRJ_Technology = new PRJ_TechnologyBAL();
            ddl.DataSource = balPRJ_Technology.SelectComboBox();
            ddl.DataValueField = "TechnologyID";
            ddl.DataTextField = "TechnologyName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(" Select Technology ", "-99"));
        }
        public static void FillDropDownListGuideID(DropDownList ddl)
        {
            PRJ_GuideBAL balPRJ_Guide = new PRJ_GuideBAL();
            ddl.DataSource = balPRJ_Guide.SelectComboBox();
            ddl.DataValueField = "GuideID";
            ddl.DataTextField = "GuideName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(" Select Guide ", "-99"));
        }
        public static void FillDropDownListStudentIDByProjectID(DropDownList ddl, SqlInt32 InstituteID, SqlInt32 DepartmentID)
        {
            MST_StudentBAL balMST_Student = new MST_StudentBAL();
            ddl.DataSource = balMST_Student.SelectComboBoxByProject(InstituteID, DepartmentID);
            ddl.DataValueField = "StudentID";
            ddl.DataTextField = "StudentName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(" Select One ", "-99"));
        }

        public static void FillDropDownListStudentIDProjectID(DropDownList ddl, SqlInt32 ProjectID)
        {
            MST_StudentBAL balMST_Student = new MST_StudentBAL();
            ddl.DataSource = balMST_Student.SelectComboBoxProject(ProjectID);
            ddl.DataValueField = "StudentID";
            ddl.DataTextField = "StudentName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(" Select One ", "-99"));
        }

        public static void FillDropDownListStatusID(DropDownList ddl)
        {
            MST_StatusBAL balMST_Status = new MST_StatusBAL();
            ddl.DataSource = balMST_Status.SelectComboBox();
            ddl.DataValueField = "StatusID";
            ddl.DataTextField = "StatusName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(" Select Status ", "-99"));
        }

        public static void FillDropDownListFacultyID(DropDownList ddl, SqlInt32 InstituteID)
        {
            MST_FacultyBAL balMST_Faculty = new MST_FacultyBAL();
            ddl.DataSource = balMST_Faculty.SelectComboBox(InstituteID);
            ddl.DataValueField = "FacultyID";
            ddl.DataTextField = "FacultyName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(" Select Faculty ", "-99"));
        }

        public static void FillDropDownListProjectID(DropDownList ddl, SqlInt32 InstituteID, SqlString LoginType, SqlInt32 LoginID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID)
        {
            PRJ_ProjectBAL balPRJ_Project = new PRJ_ProjectBAL();
            ddl.DataSource = balPRJ_Project.SelectComboBox(InstituteID, LoginType, LoginID, DepartmentID, AcademicYearID);
            ddl.DataValueField = "ProjectID";
            ddl.DataTextField = "Project";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(" Select One ", "-99"));
        }

        public static void FillDropDownListStudentID(DropDownList ddl)
        {
            MST_StudentBAL balMST_Student = new MST_StudentBAL();
            ddl.DataSource = balMST_Student.SelectComboBox();
            ddl.DataValueField = "StudentID";
            ddl.DataTextField = "StudentName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(" Select One ", "-99"));
        }
        public static void FillDropDownListStudentIDForReport(DropDownList ddl, SqlString LoginType, SqlInt32 LoginID, SqlInt32 DepartmentID, SqlInt32 InstituteID, SqlInt32 AcademicYearID)
        {
            MST_StudentDAL dalMST_Student = new MST_StudentDAL();
            ddl.DataSource = dalMST_Student.SelectComboBoxForReport(LoginType, LoginID, DepartmentID, InstituteID, AcademicYearID);
            ddl.DataValueField = "StudentID";
            ddl.DataTextField = "StudentName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(" Select All ", "-99"));
        }
        //public static void FillDropDownListCompanyID(DropDownList ddl,SqlInt32 InstituteID)
        //{
        //    CMP_CompanyBAL balCMP_Company = new CMP_CompanyBAL();
        //    ddl.DataSource = balCMP_Company.SelectComboBox(InstituteID);
        //    ddl.DataValueField = "CompanyID";
        //    ddl.DataTextField = "CompanyName";
        //    ddl.DataBind();
        //    ddl.Items.Insert(0, new ListItem(" Select One ", "-99"));
        //}
        //public static void FillDropDownListCompanyGuideID(DropDownList ddl)
        //{
        //    CMP_CompanyGuideBAL balCMP_CompanyGuide = new CMP_CompanyGuideBAL();
        //    ddl.DataSource = balCMP_CompanyGuide.SelectComboBox();
        //    ddl.DataValueField = "CompanyGuideID";
        //    ddl.DataTextField = "CompanyGuideName";
        //    ddl.DataBind();
        //    ddl.Items.Insert(0, new ListItem(" Select One ", "-99"));
        //}
        //public static void FillDropDownListCMPCompanyGuideID(DropDownList ddl, SqlInt32 CompanyID)
        //{
        //    CMP_CompanyGuideBAL balCMP_CompanyGuide = new CMP_CompanyGuideBAL();

        //    ddl.DataSource = balCMP_CompanyGuide.SelectCMPComboBox(CompanyID);
        //    ddl.DataValueField = "CompanyGuideID";
        //    ddl.DataTextField = "CompanyGuideName";
        //    ddl.DataBind();
        //    ddl.Items.Insert(0, new ListItem(" Select One ", "-99"));
        //}
        //public static void FillDropDownListIndustrialEstateId(DropDownList ddl)
        //{
        //    CMP_IndustrialEstateBAL balCMP_IndustrialEstate = new CMP_IndustrialEstateBAL();
        //    ddl.DataSource = balCMP_IndustrialEstate.SelectComboBox();
        //    ddl.DataValueField = "IndustrialEstateId";
        //    ddl.DataTextField = "IndustrialEstateName";
        //    ddl.DataBind();
        //    ddl.Items.Insert(0, new ListItem(" Select One ", "-99"));
        //}

        //public static void FillDropDownListMeetingID(DropDownList ddl,SqlInt32 InstituteID,SqlString LoginType,SqlInt32 LoginID,SqlInt32 DepartmentID,SqlInt32 AcademicYearID)
        //{
        //    MET_MeetingBAL balMET_Meeting = new MET_MeetingBAL();
        //    ddl.DataSource = balMET_Meeting.SelectComboBox(InstituteID,LoginType,LoginID,DepartmentID,AcademicYearID);
        //    ddl.DataValueField = "MeetingID";
        //    ddl.DataTextField = "MeetingDate";
        //    ddl.DataBind();
        //    ddl.Items.Insert(0, new ListItem(" Select One ", "-99"));
        //}

        //public static void FillDropDownListDepartmentCoordinator(DropDownList ddl, SqlInt32 InstituteID)
        //{
        //    INS_DepartmentCoordinatorBAL balINS_DepartmentCoordinator = new INS_DepartmentCoordinatorBAL();
        //    ddl.DataSource = balINS_DepartmentCoordinator.SelectComboBox(InstituteID);
        //    ddl.DataValueField = "DepartmentCoordinatorID";
        //    ddl.DataTextField = "FacultyName";
        //    ddl.DataBind();
        //    ddl.Items.Insert(0, new ListItem(" Select One ", "-99"));
        //}
        //public static void FillDropDownEnroll(DropDownList ddl)
        //{
        //    SqlDatabase sqlDB = new SqlDatabase(ConfigurationManager.ConnectionStrings["DIDPConnectionString"].ConnectionString);
        //    DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_StudentEnroll_SelectComboBox");
        //    DataTable dtMST_StudentEnroll = new DataTable("PR_MST_StudentEnroll_SelectComboBox");
        //    DataBaseHelper DBH = new DataBaseHelper();
        //    DBH.LoadDataTable(sqlDB, dbCMD, dtMST_StudentEnroll);
        //    ddl.DataSource = dtMST_StudentEnroll;
        //    ddl.DataValueField = "StudentID";
        //    ddl.DataTextField = "EnrollmentNo";
        //    ddl.DataBind();
        //    ddl.Items.Insert(0, new ListItem(" Select One ", "-99"));
        //}


        //public static void FillDropDownListStudentIDByInstituteID(DropDownList ddl,SqlInt32 InstituteID)
        //{
        //    MST_StudentBAL balMST_Student = new MST_StudentBAL();
        //    ddl.DataSource = balMST_Student.SelectComboBoxByInstituteID(InstituteID);
        //    ddl.DataValueField = "StudentID";
        //    ddl.DataTextField = "StudentName";
        //    ddl.DataBind();
        //    ddl.Items.Insert(0, new ListItem(" Select One ", "-99"));
        //}
        //public static void FillDropDownListStudentIDByMeetingID(DropDownList ddl,SqlInt32 ProjectID)
        //{
        //    MST_StudentBAL balMST_Student = new MST_StudentBAL();
        //    ddl.DataSource = balMST_Student.SelectComboBoxByMeetingID(ProjectID);
        //    ddl.DataValueField = "StudentID";
        //    ddl.DataTextField = "StudentName";
        //    ddl.DataBind();
        //    ddl.Items.Insert(0, new ListItem(" Select One ", "-99"));
        //}

        //public static void FillDropDownListStudentIDByFacultyID(DropDownList ddl,SqlInt32 FacultyID)
        //{
        //    MST_StudentBAL balMST_Student = new MST_StudentBAL();
        //    ddl.DataSource = balMST_Student.SelectComboBoxByFacultyID(FacultyID);
        //    ddl.DataValueField = "StudentID";
        //    ddl.DataTextField = "StudentName";
        //    ddl.DataBind();
        //    ddl.Items.Insert(0, new ListItem(" Select One ", "-99"));
        //}
    }
}
