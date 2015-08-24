using app.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace app.DL.Project
{
    public class ProjectDataAccess
    {
        private readonly int dbTimeout = 1000;

        public List<ProjectModel> GetProject()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create("JIRA");
            List<ProjectModel> modelList = new List<ProjectModel>();
            using (DbCommand cmd = db.GetStoredProcCommand("[dbo].[GetProject]"))
            {
                cmd.CommandTimeout = dbTimeout;
                db.AddOutParameter(cmd, "@Result", DbType.Int32, Int32.MaxValue);
                DataSet ds = db.ExecuteDataSet(cmd);

                // DB returns 1 if there is no error.
                int result = (int)db.GetParameterValue(cmd, "@Result");
                if (result == 1)
                {
                    DataTable dt = ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ProjectModel model = new ProjectModel();
                        model.Id = (int)dt.Rows[i]["Id"];
                        model.Subject = dt.Rows[i]["Subject"].ToString();
                        model.Status = (int)dt.Rows[i]["Status"];
                        model.ReleasedVersion = dt.Rows[i]["ReleasedVersion"].ToString();
                        model.Description = dt.Rows[i]["Description"].ToString();
                        model.SourceRespository = dt.Rows[i]["SourceRespository"].ToString();
                        model.StartTime = (DateTime)dt.Rows[i]["StartTime"];
                        model.EndTime = (DateTime)dt.Rows[i]["EndTime"];
                        model.UpdatedTimeStamp = (DateTime)dt.Rows[i]["UpdatedTimeStamp"];
                        modelList.Add(model);
                    }
                }
            }

            return modelList;
        }

        public ProjectModel GetProjectWithId(int id)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create("JIRA");
            ProjectModel model = new ProjectModel();
            using (DbCommand cmd = db.GetStoredProcCommand("[dbo].[GetProjectWithId]"))
            {
                cmd.CommandTimeout = dbTimeout;
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.AddOutParameter(cmd, "@Result", DbType.Int32, Int32.MaxValue);
                DataSet ds = db.ExecuteDataSet(cmd);

                // DB returns 1 if there is no error.
                int result = (int)db.GetParameterValue(cmd, "@Result");
                if (result == 1)
                {
                    DataTable dt = ds.Tables[0];
                    model.Id = (int)dt.Rows[0]["Id"];
                    model.Subject = dt.Rows[0]["Subject"].ToString();
                    model.Status = (int)dt.Rows[0]["Status"];
                    model.ReleasedVersion = dt.Rows[0]["ReleasedVersion"].ToString();
                    model.Description = dt.Rows[0]["Description"].ToString();
                    model.SourceRespository = dt.Rows[0]["SourceRespository"].ToString();
                    model.StartTime = (DateTime)dt.Rows[0]["StartTime"];
                    model.EndTime = (DateTime)dt.Rows[0]["EndTime"];
                    model.UpdatedTimeStamp = (DateTime)dt.Rows[0]["UpdatedTimeStamp"];
                }
            }
            return model;
        }

        public int UpsertProject(ProjectModel model)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create("JIRA");
            int result = 0;
            using (DbCommand cmd = db.GetStoredProcCommand("[dbo].[UpsertProject]"))
            {
                cmd.CommandTimeout = dbTimeout;
                db.AddInParameter(cmd, "@Id", DbType.Int32, model.Id);
                db.AddInParameter(cmd, "@Subject", DbType.String, model.Subject);
                db.AddInParameter(cmd, "@Description", DbType.String, model.Description);
                db.AddInParameter(cmd, "@Status", DbType.Int32, model.Status);
                db.AddInParameter(cmd, "@SourceRespository", DbType.String, model.SourceRespository);
                db.AddInParameter(cmd, "@ReleasedVersion", DbType.String, model.ReleasedVersion);
                db.AddInParameter(cmd, "@UpdatedTimeStamp", DbType.DateTime2, model.UpdatedTimeStamp);
                db.AddInParameter(cmd, "@StartTime", DbType.DateTime2, model.StartTime);
                db.AddInParameter(cmd, "@EndTime", DbType.DateTime2, model.EndTime);
                db.AddOutParameter(cmd, "@Result", DbType.Int32, Int32.MaxValue);
                DataSet ds = db.ExecuteDataSet(cmd);

                // DB returns 1 if there is no error.
                result = (int)db.GetParameterValue(cmd, "@Result");                
            }
            return result;
        }

        public int DeleteProject(int id)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create("JIRA");
            int result = 0;
            using (DbCommand cmd = db.GetStoredProcCommand("[dbo].[DeleteProjectWithId]"))
            {
                cmd.CommandTimeout = dbTimeout;
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.AddOutParameter(cmd, "@Result", DbType.Int32, Int32.MaxValue);
                DataSet ds = db.ExecuteDataSet(cmd);

                // DB returns 1 if there is no error.
                result = (int)db.GetParameterValue(cmd, "@Result");
            }
            return result;
        }
    }
}