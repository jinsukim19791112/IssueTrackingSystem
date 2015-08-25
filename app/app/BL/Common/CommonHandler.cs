using app.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace app.BL.Common
{
    public static class CommonHandler
    {
        public static StatusMessage GetStatusMessage(int statusCode)
        {
            StatusMessage statusMessage = new StatusMessage();
            if (statusCode == 1)
            {
                statusMessage.Code = "200";
                statusMessage.Message = "Transaction completed!";
            }
            else
            {
                statusMessage.Code = "500";
                statusMessage.Message = "DB Error";
            }

            return statusMessage;
        }
    }

    public class StatusMessage
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}