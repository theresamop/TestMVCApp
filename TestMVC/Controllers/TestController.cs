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
            var model =  testSvc.Get();
            return PartialView(model);
        }

        public int TestCounter()
        {
            var testSvc = new TestService();
            TestModel tm = new TestModel();
            var model = testSvc.ClickCounter();

            return model.ClickCount;
        }

        
    }
}
