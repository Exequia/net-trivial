using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace trivial.Controllers
{
    public class WsController : Controller
    {
        // GET: Ws
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ws/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ws/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ws/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Ws/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ws/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Ws/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ws/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Ws/test
        public ActionResult Test()
        {
            return Ok("Test is correct");
        }
    }
}