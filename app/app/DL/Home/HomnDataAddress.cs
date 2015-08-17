using app.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace app.DL.Home
{
    public class HomeDataAccess
    {
        private static int dbTimeout = 1000;

        public List<Constant> GetConstant(string category)
        {
            List<Constant> constantList = new List<Constant>();
            DataSet ds;
            Database db = DatabaseFactory.CreateDatabase("MGPRM");

            using (DbCommand cmd = db.GetStoredProcCommand("[dbo].[GetConstants]"))
            {
                cmd.CommandTimeout = dbTimeout;
                db.AddInParameter(cmd, "@Category", DbType.String, category);
                ds = db.ExecuteDataSet(cmd);
            }
        }

    }
}