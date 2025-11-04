using BancoPreguntasIntento25.Data;
using BancoPreguntasIntento25.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BancoPreguntasIntento25.Pages.Preguntas
{
    public class VerRespuestasModel : PageModel
    {
        private readonly BancoPreguntasIntento25Context _context;
        public VerRespuestasModel(BancoPreguntasIntento25Context context) => _context = context;

        [BindProperty(SupportsGet = true)] public string? Asignatura { get; set; }
        [BindProperty(SupportsGet = true)] public int? Unidad { get; set; }
        [BindProperty(SupportsGet = true)] public string? Sub { get; set; }

        public List<ListaPreguntas> Preguntas { get; set; } = new();

        public void OnGet()
        {
            var q = _context.ListaPreguntas.AsQueryable();

            if (!string.IsNullOrWhiteSpace(Asignatura))
                q = q.Where(p => p.Asignatura == Asignatura);

            if (Unidad.HasValue)
                q = q.Where(p => p.Unidad == Unidad.Value);

            if (!string.IsNullOrWhiteSpace(Sub))
                q = q.Where(p => p.SubUnidad == Sub);

            Preguntas = q
                .OrderBy(p => p.Asignatura)
                .ThenBy(p => p.Unidad)
                .ThenBy(p => p.SubUnidad)
                .ThenBy(p => p.PreguntaId)
                .ToList();
        }
    }
}
