#region

using System.Web.Mvc;
using Ansur.Aplicacao;

#endregion

namespace UI.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var listaAlunos = new AlunoApp().ListarTodos();
            return View(listaAlunos);
        }
    }
}