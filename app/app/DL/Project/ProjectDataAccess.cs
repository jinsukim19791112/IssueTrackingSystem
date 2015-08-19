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
                        model.Subject = (string)dt.Rows[i]["Subject"];
                        model.Status = (int)dt.Rows[i]["Status"];
                        model.ReleasedVersion = (string)dt.Rows[i]["ReleasedVersion"];
                        model.Description = (string)dt.Rows[i]["Description"];
                        model.SourceRespository = (string)dt.Rows[i]["SourceRespository"];
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
                    model.Subject = (string)dt.Rows[0]["Subject"];
                    model.Status = (int)dt.Rows[0]["Status"];
                    model.ReleasedVersion = (string)dt.Rows[0]["ReleasedVersion"];
                    model.Description = (string)dt.Rows[0]["Description"];
                    model.SourceRespository = (string)dt.Rows[0]["SourceRespository"];
                    model.StartTime = (DateTime)dt.Rows[0]["StartTime"];
                    model.EndTime = (DateTime)dt.Rows[0]["EndTime"];
                    model.UpdatedTimeStamp = (DateTime)dt.Rows[0]["UpdatedTimeStamp"];
                }
            }
            return model;
        }
    }
}