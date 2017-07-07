using MvcApplication.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

namespace MvcApplication_Test
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            //string email = context.Request.Form["emal"];
            string name = context.Request.Form["name"];
            string pass = context.Request.Form["pass"];
            string status = "1";
            string error = "null";
            //var students = null; 
            try
            {
                using (var db = new TestTryEntities())
                {
                    var user = db.User.Where(x => x.Name == name && x.Password == pass).Take(1).ToList();
                    if (user.Count == 0)
                    {
                        status = "0";
                        error = " 未找到给用户！";
                    }
                };
            }
            catch (Exception e)
            {

                status = "0";
                error = e.ToString();
            }
        
            StringBuilder json = new StringBuilder();
            json.Append("[");
            json.Append("{");
            json.Append("\"status\":" + "\"" + status + "\",");
            json.Append("\"error\":" + "\"" + error + "\"");
            json.Append("}");
            json.Append("]");
            //CreateXmlFile createXml = new CreateXmlFile();
            //createXml.CreateXml();
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