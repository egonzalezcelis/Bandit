using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using empleados.Models;
using empleados.Util;

namespace empleados.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        [AllowAnonymous]
        public ActionResult List()
        {
           

            return View();
        }

        [AllowAnonymous]
        public ActionResult FindEmployee()
        {
            var nombres = this.Request.QueryString["nombres"];
            var apellidos = this.Request.QueryString["apellidos"];
            var cedula = this.Request.QueryString["cedula"];
            var telefono = this.Request.QueryString["telefono"];

             using (var db = new employeeEntities())
            {
                var query = (from st in db.empleado
                            where ((st.nombres.Contains(nombres) || nombres=="")
                            && (st.apellidos.Contains(apellidos) || apellidos == "")
                            && (st.cedula.Equals(cedula) || cedula == "")
                            && (st.telefono.Contains(telefono) || telefono == ""))
                            select st).ToList();
                var employess = query;
                var jsonObject = new
                {
                    data = employess
                };

                return Json(jsonObject, JsonRequestBehavior.AllowGet);
            }
            

        }

        [AllowAnonymous]
        public ActionResult getEmployeeById()
        {
            var id = Int32.Parse(this.Request.QueryString["id"]);

            using (var db = new employeeEntities())
            {
                var query = (from st in db.empleado
                             where st.id.Equals(id)
                             select st).ToList();
                var employess = query;
                return Json(employess, JsonRequestBehavior.AllowGet);
            }


        }

        [AllowAnonymous]
        public ActionResult RegisterEmployee(RegisterEmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var modelErrors = ModelState.AllErrors(); 
                return Json(modelErrors);
            }

            using (var db = new employeeEntities())
            {
                var row = db.Set<empleado>();
                var emp = new empleado();
                emp.nombres = model.nombres;
                emp.apellidos = model.apellidos;
                emp.cedula = model.cedula;
                emp.telefono = model.telefono;
                if (model.id.Equals(0)){
                    row.Add(emp);
                    db.SaveChanges();
                }
                else
                {
                    emp.id = model.id;
                    var cemp = db.empleado.Find(emp.id);
                    if (cemp != null)
                    {   db.Entry(cemp).CurrentValues.SetValues(emp);
                        db.SaveChanges();
                    }    
                }
            }


            return Json(new {});
        }
    }
}