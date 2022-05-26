using DProject.DAL;
using System;
using System.Data;
using System.Data.SqlTypes;

namespace DProject.BAL
{
    public class PRJ_ProjectBAL : PRJ_ProjectBALBase
    {
        #region Select Report Project List

        public DataTable SelectAllReport(SqlString LoginType, SqlInt32 LoginID, SqlInt32 InstituteID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID, SqlInt32 TechnologyID, SqlInt32 FacultyID)
        {
            PRJ_ProjectDAL dalPRJ_Project = new PRJ_ProjectDAL();
            return dalPRJ_Project.SelectAllReport(LoginType, LoginID, InstituteID, DepartmentID, AcademicYearID, TechnologyID, FacultyID);
        }

        #endregion Select Report Project List

        #region Select Report Project Complete Status

        public DataTable SelectProjectCompletionStatus()
        {
            PRJ_ProjectDAL dalPRJ_Project = new PRJ_ProjectDAL();
            return dalPRJ_Project.SelectProjectCompletionStatus();
        }

        #endregion Select Report Project Complete Status

        #region Select Report Project List By ProjectType

        public DataTable SelectProjectStatementListByProjectType(SqlString LoginType, SqlInt32 LoginID, SqlInt32 InstituteID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID, SqlString ProjectType)
        {
            PRJ_ProjectDAL dalPRJ_Project = new PRJ_ProjectDAL();
            return dalPRJ_Project.SelectProjectStatementListByProjectType(LoginType, LoginID, InstituteID, DepartmentID, AcademicYearID, ProjectType);
        }

        #endregion Select Report Project List By ProjectType

        #region Select Report Project List By Technology

        public DataTable SelectProjectStatementListByTechnology(String UserCatagory, Int32 InstituteID, Int32 DepartmentID, Int32 TechnologyID)
        {
            PRJ_ProjectDAL dalPRJ_Project = new PRJ_ProjectDAL();
            return dalPRJ_Project.SelectProjectStatementListByTechnology(UserCatagory, InstituteID, DepartmentID, TechnologyID);
        }

        #endregion Select Report Project List By Technology

        #region Select Report Project Marks List
        public DataTable SelectProjectMarksList()
        {
            PRJ_ProjectDAL dalPRJ_Project = new PRJ_ProjectDAL();
            return dalPRJ_Project.SelectProjectMarksList();
        }
        #endregion Select Report Project Marks List

        #region Select Report Project Not Entered

        public DataTable SelectProjectNotEntered(Int32 InstituteID, Int32 DepartmentID)
        {
            PRJ_ProjectDAL dalPRJ_Project = new PRJ_ProjectDAL();
            return dalPRJ_Project.SelectProjectNotEntered(InstituteID, DepartmentID);
        }

        #endregion Select Report Project Not Entered

        #region Select Project Statement

        public DataTable SelectProjectStatement(SqlInt32 ProjectID)
        {
            PRJ_ProjectDAL dalPRJ_Project = new PRJ_ProjectDAL();
            return dalPRJ_Project.SelectProjectStatement(ProjectID);
        }

        #endregion Select Project Statement

        #region Select Project Statement List

        public DataTable SelectProjectStatementList(String UserCatagory, Int32 LoginID, Int32 InstituteID, Int32 DepartmentID, Int32 TechnologyID)
        {
            PRJ_ProjectDAL dalPRJ_Project = new PRJ_ProjectDAL();
            return dalPRJ_Project.SelectProjectStatementList(UserCatagory, LoginID, InstituteID, DepartmentID, TechnologyID);
        }

        #endregion Select Project Statement List

        #region Select Project Statement List By Guide

        public DataTable SelectProjectStatementListByGuide(SqlString LoginType, SqlInt32 LoginID, SqlInt32 InstituteID, SqlInt32 DepartmentID, SqlInt32 AcademicYearID, Int32 GuideID)
        {
            PRJ_ProjectDAL dalPRJ_Project = new PRJ_ProjectDAL();
            return dalPRJ_Project.SelectProjectStatementListByGuide(LoginType, LoginID, InstituteID, DepartmentID, AcademicYearID, GuideID);
        }

        #endregion Select Project Statement List By Guide
    }

}