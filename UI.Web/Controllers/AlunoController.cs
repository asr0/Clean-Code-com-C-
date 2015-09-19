using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ansur.Aplicacao;

namespace UI.Web.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno
        public ActionResult Listar()
        {
            var listaAlunos = new AlunoApp().ListarTodos();
            return View(listaAlunos);
        }
    }
}