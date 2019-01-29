using System.Net;
using System.Web.Mvc;
using DSTRAINING.WEB.Models;
using DSTRAINING.WEB.Repositories;

namespace DSTRAINING.WEB.Controllers
{
    public class DepartmentController : Controller
    {
        private DepartmentRepository _department;

        public DepartmentController()
        {
            _department = new DepartmentRepository();
        }

        // GET: Department
        public ActionResult Index()
        {
            return View(_department.GetAll());
        }

        // GET: Department/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _department.Get(id ?? 0);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        [HttpGet]
        // GET: Department/Create
        public ActionResult Create()
        {
            var model = new Department();
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _department.Create(department);
                return RedirectToAction("Index");
            }

            return View(department);
        }



        // GET: Department/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _department.Get(id ?? 0);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Department/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _department.Update(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _department.Get(id ?? 0);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = _department.Get(id);
            _department.Delete(department);
            return RedirectToAction("Index");
        }

    }
}
