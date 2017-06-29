using MvcApplication.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MvcApplication_Test.Handler
{
    /// <summary>
    /// SignUp 的摘要说明
    /// </summary>
    public class SignUp : IHttpHandler
    {
        
        public void ProcessRequest(HttpContext context)
        {
            //string action = context.Request.Params["key"];
            string email = context.Request.Form["emal"];
            string name = context.Request.Form["name"];
            string pass = context.Request.Form["pass"];

            string status = "1";
            string error = "null";
            try
            {
                using (var db = new TestTryEntities())
                {
                    //数据操作
                    var getGser = db.Student.Where(x => x.Name == name || x.Email == email).Take(1).ToList();
                    if (getGser.Count > 0)
                    {
                        status = "0";
                        error = "该用户名或邮箱已存在，请重试";
                    }
                    Student user = new Student()
                    {
                        Name = pass,
                        Email = email,
                        Password = pass
                    };
                    db.Student.Add(user);
                    db.SaveChanges();
                    //var user = (from v in db.Student
                    //            where v.Name == "51aspx"
                    //            select v).Single();
                    //user.Password = "123456";
                    //db.SaveChanges();
                }
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
           //TestTryEntities Db = new TestTryEntities();
           // int total = Db.Student.Count();
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