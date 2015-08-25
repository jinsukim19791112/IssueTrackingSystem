using app.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace app.DL.User
{
    public class UserDataAccess
    {

        private readonly int dbTimeout = 1000;

        public List<UserModel> GetUsers()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create("JIRA");
            List<UserModel> modelList = new List<UserModel>();
            using (DbCommand cmd = db.GetStoredProcCommand("[dbo].[GetUsers]"))
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
                        UserModel model = new UserModel();
                        model.Id = (int)dt.Rows[i]["Id"];
                        model.Name = dt.Rows[i]["Name"].ToString();
                        model.Email = dt.Rows[i]["Email"].ToString();
                        model.Mobile = dt.Rows[i]["Mobile"].ToString();
                        model.Org = dt.Rows[i]["Org"].ToString();
                        model.Dept = dt.Rows[i]["Dept"].ToString();
                        model.Status = (int)dt.Rows[i]["Status"];
                        modelList.Add(model);
                    }
                }
            }

            return modelList;
        }
    }
}