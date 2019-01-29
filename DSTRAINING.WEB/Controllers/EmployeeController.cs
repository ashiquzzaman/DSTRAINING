using DSTRAINING.WEB.Models;
using DSTRAINING.WEB.Repositories;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DSTRAINING.WEB.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeRepository _employee;
        private DepartmentRepository _department;

        public EmployeeController(EmployeeRepository employee, DepartmentRepository department)
        {
            _employee = employee;
            _department = department;
        }

        //public EmployeeController()
        //{
        //    _employee = new EmployeeRepository();
        //    _department = new DepartmentRepository();
        //}

        // GET: Employee
        public ActionResult Index()
        {


            var test = _employee.All().Include(s => s.Department).Select(s => new
            {
                EmployeeId = s.Id,
                DeptName = s.Department.Name
            });

            var employees = _employee.GetAll();
            return View(employees.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employee.Get(id ?? 0);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(_department.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employee.Create(employee);
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(_department.GetAll(), "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employee.Get(id ?? 0);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(_department.GetAll(), "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employee.Update(employee);
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(_department.GetAll(), "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employee.Get(id ?? 0);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = _employee.Get(id);
            _employee.Delete(employee);
            return RedirectToAction("Index");
        }


    }
}
