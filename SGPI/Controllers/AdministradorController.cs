    using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGPI.Controllers
{
    public class AdministradorController : Controller
    {
        SGPDBContext context;

        public AdministradorController(SGPDBContext contexto)
        {
            context = contexto;
        }


        public ActionResult MenuAdministrador()
        {
            return View();
        }


        public IActionResult CrearUsuario()
        {
            ViewBag.tipodoc = context.Documentos.ToList();
            ViewBag.programa = context.Programas.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.genero = context.Generos.ToList();
            return View();
        }


        [HttpPost]
        public IActionResult CrearUsuario(Usuario user)
        {
            context.Add(user);
            context.SaveChanges();
            ViewBag.tipodoc = context.Documentos.ToList();
            ViewBag.programa = context.Programas.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.genero = context.Generos.ToList();
            return RedirectToAction("CrearUsuario");
        }

    
        public IActionResult BuscarUsuario()
        {
            var listaUsuarios = context.Usuarios.ToList();
            var listaprogram = context.Programas.ToList();
            List<string> listaprogramas = new List<string>();
            foreach (var user in listaUsuarios)
            {
                if(user.IdPrograma != null)
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
        public IActionResult BuscarUsuario(string documento)
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


        public ActionResult Informes()
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
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.tipodoc = context.Documentos.ToList();
            ViewBag.programa = context.Programas.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.genero = context.Generos.ToList();
            var listaUsuarios = context.Usuarios.Where(u => u.IdUsuario == id).ToList();
            if (listaUsuarios != null)
            {
                return View(listaUsuarios.SingleOrDefault());
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(Usuario user, int id)
        {
            Usuario usuario = user;
            if (usuario == null)
                return ViewBag.mensaje = "Eror al editar usuario";
            else
            {
                user.IdUsuario = id;
                context.Update(user);
                context.SaveChanges();
                ViewBag.tipodoc = context.Documentos.ToList();
                ViewBag.programa = context.Programas.ToList();
                ViewBag.rol = context.Rols.ToList();
                ViewBag.genero = context.Generos.ToList();
            }

            return RedirectToAction("BuscarUsuario");
        }


        public ActionResult Delete(Usuario user, int id)
        {
            Usuario usuario = context.Usuarios.Find(id);
            if (usuario == null)
                return ViewBag.mensaje = "Eror al editar usuario";
            else
            {
                //user.IdUsuario = id;
                context.Remove(usuario);
                context.SaveChanges();
            }

            return RedirectToAction("BuscarUsuario");
        }
    }
}
