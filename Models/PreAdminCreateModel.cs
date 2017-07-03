using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication_Test.Models
{
    public class PreAdminCreateModel
    {
        //public  PreAdminCreateModel()
        //{
        //    this.list = new List<ProjectInfo>();
        //}
        public List<ProjectInfo> list { get; set; }
        public ProjectInfo ProjectInfo { get; set; }
    }
    public class ProjectInfo
    {
        public string PjName { get; set; }
        public string PjNum { get; set; }
        public string Xdd { get; set; }
        public string Xddw { get; set; }
    }
}