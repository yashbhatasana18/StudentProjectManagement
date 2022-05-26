using DProject.DAL;
using System.Data;
using System.Data.SqlTypes;

namespace DProject.BAL
{
    public class MST_StudentBAL : MST_StudentBALBase
    {
        #region GetStudent For AutoComplete Extender

        public DataTable GetStudent(SqlString Student, SqlString LoginType, SqlInt32 LoginID, SqlInt32 InstituteID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID)
        {
            MST_StudentDAL dalMST_Student = new MST_StudentDAL();
            return dalMST_Student.GetStudent(Student, LoginType, LoginID, InstituteID, DepartmentID, AcademicYearID);
        }

        #endregion GetStudent For AutoComplete Extender

        #region StudentByProject
        public DataTable SelectComboBoxByProject(SqlInt32 InstituteID, SqlInt32 DepartmentID)
        {
            MST_StudentDAL dalMST_StudentByProject = new MST_StudentDAL();
            return dalMST_StudentByProject.SelectComboBoxByProject(InstituteID, DepartmentID);
        }
        #endregion StudentByProject

        #region StudentProject
        public DataTable SelectComboBoxProject(SqlInt32 ProjectID)
        {
            MST_StudentDAL dalMST_StudentByProject = new MST_StudentDAL();
            return dalMST_StudentByProject.SelectComboBoxProject(ProjectID);
        }
        #endregion StudentProject

        #region StudentByFaculty
        public DataTable SelectComboBoxByFacultyID(SqlInt32 FacultyID)
        {
            MST_StudentDAL dalMST_StudentByProject = new MST_StudentDAL();
            return dalMST_StudentByProject.SelectComboBoxByFacultyID(FacultyID);
        }
        #endregion StudentByFaculty

        #region StudentByInstitute
        public DataTable SelectComboBoxByInstituteID(SqlInt32 InstituteID)
        {
            MST_StudentDAL dalMST_StudentByInstitute = new MST_StudentDAL();
            return dalMST_StudentByInstitute.SelectComboBoxByInstituteID(InstituteID);
        }
        #endregion StudentByFaculty

        #region ComboBoxByMeetingID

        public DataTable SelectComboBoxByMeetingID(SqlInt32 ProjectID)
        {
            MST_StudentDAL dalMST_Student = new MST_StudentDAL();
            return dalMST_Student.SelectComboBox(ProjectID);
        }

        #endregion ComboBoxByMeetingID

        //#region ComboBoxByStudentID

        //public DataTable SelectComboBoxByStudentID(SqlInt32 InstituteID, SqlString LoginType, SqlInt32 LoginID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID)
        //{
        //    MST_StudentDAL dalMST_Student = new MST_StudentDAL();
        //    return dalMST_Student.SelectComboBoxByStudentID(InstituteID, LoginType, LoginID, DepartmentID, AcademicYearID);
        //}

        //#endregion ComboBoxByStudentID
    }

}