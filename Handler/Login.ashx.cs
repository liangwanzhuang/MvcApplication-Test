using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MvcApplication_Test
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.Params["key"]; 
            string status = "2";
            string error = "1";
            StringBuilder json = new StringBuilder();
            json.Append("{");
            json.Append("\"status\":" + "\"" + status + "\",");
            json.Append("\"error\":" + "\"" + error + "\"");
            json.Append("}");

            string returnStr = json.ToString();
            context.Response.Write(returnStr);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}