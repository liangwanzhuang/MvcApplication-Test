using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication_Test.Models
{
    public class PreAdminCreateModel
    {
        public string PjName { get; set; }
        public string MchineNum { get; set; }
        public string pjCity { get; set; }
        public string IsNow { get; set; }
        public string PjXSName { get; set; }
        public string IsDealer { get; set; }
        public string Phone { get; set; }
        public string Other { get; set; }

        public List<ProjectInfo> List { get; set; }

        public class ProjectInfo
        {
            public string PjName { get; set; }
            public string PjNum { get; set; }
            public string Xdd { get; set; }
            public string Xddw { get; set; }
        }
    }
}