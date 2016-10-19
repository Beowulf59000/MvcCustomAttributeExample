using MvcCustomAttributeExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCustomAttributeExample.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            return RedirectToAction("Edit", new { id = 1 });
        }


        public ActionResult Edit(Int32 id)
        {
            TestModels test = new TestModels();
            return this.View(test);
        }

        [HttpPost]
        public ActionResult Edit(TestModels test)
        {
            if (ModelState.IsValid)
            {
                return this.RedirectToAction("Index");
            }

            return this.View(test);
        }
    }
}