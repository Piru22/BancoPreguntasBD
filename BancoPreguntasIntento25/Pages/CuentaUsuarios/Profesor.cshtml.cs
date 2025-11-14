using BancoPreguntasIntento25.Data;
using BancoPreguntasIntento25.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BancoPreguntasIntento25.Pages.CuentaUsuarios
{
    public class ProfesorModel : PageModel
    {
        private readonly BancoPreguntasIntento25Context _context;

        public ProfesorModel(BancoPreguntasIntento25Context context)
        {
            _context = context;
        }

        public List<Usuarios> ListaProfesores { get; set; }

        public void OnGet()
        {
            ListaProfesores = _context.Usuario.ToList();
        }
    }
}
