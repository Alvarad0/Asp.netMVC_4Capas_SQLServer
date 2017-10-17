using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ent_Colegio;
using Ctrol_Colegio;

namespace PresentacionColegio.Controllers
{
    public class RolController : Controller
    {
        RolControl control = new RolControl();
        // GET: Rol
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ObtenerRoles()
        {
            var roles = control.ObtenerTodos();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = roles }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }

        public ActionResult AddRol(Rol rol) {
            var r = rol.Id_Rol > 0 ?
                    control.Actualizar(rol) :
                    control.Insertar(rol);

            if (!r)
            {
                // Podemos validar para mostrar un mensaje personalizado, por ahora el aplicativo se caera por el throw que hay en nuestra capa DAL
                ViewBag.Mensaje = "Ocurrio un error inesperado";
                return Json("Error al realizar la operación", JsonRequestBehavior.AllowGet);
            }
            return Json("Realizado", JsonRequestBehavior.AllowGet);
        }

        public ActionResult ObtenerRol(int id) {
            var rol = new Rol();
            rol = control.Obtener(id);
            return Json(new { data = rol}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EliminarRol(int id) {
            var r = control.Eliminar(id);
            if (!r) {
                return Json("Error al Eliminar ROl", JsonRequestBehavior.AllowGet);
            }
            return Json("Rol Eliminado Correctamente", JsonRequestBehavior.AllowGet);
        }
    }
}