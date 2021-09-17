using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Registration.Models;

namespace Registration.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {

       
        // GET: Employee
        public ActionResult Index()
        {


            using (DbModels dbModels = new DbModels())
            {

                return View(dbModels.Employees.ToList());

            }


        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Employees.Where(x => x.Id == id).FirstOrDefault());
            }

        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                using (DbModels dbModels = new DbModels())
                {
                    dbModels.Employees.Add(employee);
                    dbModels.SaveChanges();


                }


                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Employees.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {

                    dbModel.Entry(employee).State = EntityState.Modified;
                    dbModel.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        } 

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Employees.Where(x => x.Id == id).FirstOrDefault());
            }

        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModels dbModels = new DbModels())

                {
                    Employee employee = dbModels.Employees.Where(x => x.Id == id).FirstOrDefault();
                    dbModels.Employees.Remove(employee);
                    dbModels.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }




        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
    public ActionResult Login(Employee employee)
        {
            DbModels db = new DbModels();

            {
                var row = db.Employees.Where(x => x.Email == employee.Email && x.Password == employee.Password).FirstOrDefault();
               if(row!=null)
                {

                    return RedirectToAction("Index");
                }

                else 
                
                {

                    ViewBag.LoginMsg = ("<script> alert('Somthing went wrong...')</script>");
                    ModelState.Clear();
                
                
                }

                return View();
                    
                    }
        
        
        }
    
   
    
    
    }
}
