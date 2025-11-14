using BancoPreguntasIntento25.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BancoPreguntasIntento25.Pages.Preguntas
{
    public class SubunidadesModel : PageModel
    {
        private readonly BancoPreguntasIntento25Context _context;
        public SubunidadesModel(BancoPreguntasIntento25Context context) => _context = context;

        [BindProperty(SupportsGet = true)] public string Asignatura { get; set; } = "";
        [BindProperty(SupportsGet = true)] public int Unidad { get; set; }

        public List<string> SubUnidades { get; set; } = new();

        public void OnGet()
        {
            SubUnidades = _context.ListasPreguntas
                .Where(p => p.Asignatura == Asignatura && p.Unidad == Unidad)
                .Select(p => p.SubUnidad)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Distinct()
                .OrderBy(s => s)
                .ToList();
        }
    }
}