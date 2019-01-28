using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DSTRANING.WEB.Models;

namespace DSTRANING.WEB.Services
{
    public class DepartmentService : IDisposable
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<Department> GetAll()
        {
            return db.Departments.ToList();
        }
        public Department Get(int id)
        {
            return db.Departments.Find(id);
        }
        public Department Create(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
            return department;
        }
        public void Delete(Department department)
        {

            db.Departments.Remove(department);
            db.SaveChanges();
        }
        public int Update(Department department)
        {

            db.Entry(department).State = EntityState.Modified;
            return db.SaveChanges();
        }


        public void Dispose()
        {
            db?.Dispose();
        }
    }
}