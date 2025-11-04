using BancoPreguntasIntento25.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BancoPreguntasIntento25.Pages.Preguntas
{
    public class UnidadesModel : PageModel
    {
        private readonly BancoPreguntasIntento25Context _context;
        public UnidadesModel(BancoPreguntasIntento25Context context) => _context = context;

        [BindProperty(SupportsGet = true)] public string Asignatura { get; set; } = "";
        public List<int> Unidades { get; set; } = new();

        public void OnGet()
        {
            Unidades = _context.ListaPreguntas
                .Where(p => p.Asignatura == Asignatura)
                .Select(p => p.Unidad)
                .Distinct()
                .ToList();
        }
    }
}
