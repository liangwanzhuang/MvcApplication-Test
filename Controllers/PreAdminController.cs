using MvcApplication.DAL;
using MvcApplication_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MvcApplication_Test.Controllers
{
    public class PreAdminController : Controller
    {
        //
        // GET: /PreAdmin/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(string id)
        {
            return View();
        }
        public ActionResult Create()
        {
            PreAdminCreateModel model = new PreAdminCreateModel();
            return View(model);
        }
        [HttpPost]
        public void InserProject(string  Pname,string PjCity,string MachineNum,string IsNow,string PjXSName,string IsDealer,string Phone,string Other)
        {
            using (var db = new TestTryEntities())
            {
                //数据操作
                //var getGser = db.User.Where(x => x.Name == name || x.Email == email).Take(1).ToList();
                //if (getGser.Count > 0)
                //{
                //}
                ProjectInfo pro = new ProjectInfo()
                {
                    pname=Pname,
                    pjCity=PjCity,
                    machineNum=MachineNum,
                    isNow = Convert.ToInt32(IsNow),
                    pjXSName=PjXSName,
                    isDealer = Convert.ToInt32(IsDealer),
                    phone=Phone,
                    other=Other
                };
                db.ProjectInfo.Add(pro);
                db.SaveChanges();
            }
        }

        [HttpPost]
        public void InserMachineInfo(string jsonstr)
        {
            //use json.net
             JArray o = (JArray)JsonConvert.DeserializeObject(jsonstr);
             IList<JToken> oList = (IList<JToken>)o;
             foreach (JToken jt in oList)
             {
                 JObject jo = jt as JObject;
                 string s = jt[1].ToString();
             }
        }
    }
}
