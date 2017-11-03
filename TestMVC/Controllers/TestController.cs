using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC.Data;
using TestMVC.Models;

namespace TestMVC.Controllers
{
    public class TestController : Controller
    {

        public PartialViewResult Test()
        {
             var testSvc = new TestService();
            TestModel tm = new TestModel();
            tm.ClickCount = 5;
            tm.ID = 1;
            var model = tm;// testSvc.Get();
            return PartialView(model);
        }

        public int TestCounter()
        {
            var testSvc = new TestService();
            TestModel tm = new TestModel();
            tm.ClickCount = 3;
            tm.ID = 12;
            var model = tm;// testSvc.ClickCounter();

            return model.ClickCount;
        }

        
    }
}
