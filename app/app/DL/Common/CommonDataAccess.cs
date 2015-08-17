using app.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace app.DL
{
    public class CommonDataAccess
    { 
        private readonly int dbTimeout = 1000;

        public Dictionary<int, string> GetConstant(string category)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create("JIRA");
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            using (DbCommand cmd = db.GetStoredProcCommand("[dbo].[GetConstant]"))
            {
                cmd.CommandTimeout = dbTimeout;
                db.AddInParameter(cmd, "@Category", DbType.String, category);
                db.AddOutParameter(cmd, "@Result", DbType.Int32, Int32.MaxValue);
                DataSet ds = db.ExecuteDataSet(cmd);

                // DB returns 1 if there is no error.
                int result = (int)db.GetParameterValue(cmd, "@Result");
                if (result == 1)
                {
                    DataTable dt = ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int key = (int)dt.Rows[i]["Id"];
                        string value = (string)dt.Rows[i]["Name"];
                        dictionary.Add(key, value);
                    }
                }
            }

            return dictionary;
        }
    }
}