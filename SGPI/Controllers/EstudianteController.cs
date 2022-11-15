using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGPI.Controllers
{
    public class EstudianteController : Controller
    {
        SGPDBContext context;

        public EstudianteController(SGPDBContext contexto)
        {
            context = contexto;
        }

      
        public ActionResult MenuEstudiante(int id)
        {
            return View();
        }

       
        public ActionResult Perfil()
        {
            var listaUsuarios = context.Usuarios.ToList();
            var listaprogram = context.Programas.ToList();
            List<string> listaprogramas = new List<string>();
            foreach (var user in listaUsuarios)
            {
                if (user.IdPrograma != null)
                {
                    foreach (var programa in listaprogram)
                    {
                        if (user.IdPrograma == programa.IdPrograma)
                        {
                            listaprogramas.Add(programa.ValPrograma);
                        }
                    }
                }
                else
                {
                    listaprogramas.Add("no programa");
                }

            }
            ViewBag.programa = listaprogramas;
            return View(listaUsuarios);

        }

        [HttpPost]
        public IActionResult Perfil(string documento)
        {
            var listaUsuarios = context.Usuarios.Where(u => u.Documento.Contains(documento)).ToList();
            var listaprogram = context.Programas.ToList();
            List<string> listaprogramas = new List<string>();
            foreach (var user in listaUsuarios)
            {
                if (user.IdPrograma != null)
                {
                    foreach (var programa in listaprogram)
                    {
                        if (user.IdPrograma == programa.IdPrograma)
                        {
                            listaprogramas.Add(programa.ValPrograma);
                        }
                    }
                }
                else
                {
                    listaprogramas.Add("no programa");
                }

            }
            ViewBag.programa = listaprogramas;
            if (listaUsuarios != null)
            {
                return View(listaUsuarios);
            }
            else
            {
                return View();
            }
        }

       
        public ActionResult PagosMatriculas()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult Edit(int id)
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult Delete(int id)
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
