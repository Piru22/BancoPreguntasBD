using BancoPreguntasIntento25.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BancoPreguntasIntento25.Pages.Estadisticas
{
    public class EstadisticaModel : PageModel
    {
        private readonly BancoPreguntasIntento25Context _context;

        public EstadisticaModel(BancoPreguntasIntento25Context context)
        {
            _context = context;
        }

        public int TotalPreguntas { get; set; }
        public int TotalAsignaturas { get; set; }
        public int TotalUnidades { get; set; }
        public int Incompletas { get; set; }
        public int MedioCompletas { get; set; }
        public int Completas { get; set; }

        public void OnGet()
        {
            var preguntas = _context.ListasPreguntas.ToList();

            TotalPreguntas = preguntas.Count;
            TotalAsignaturas = preguntas.Select(p => p.Asignatura).Distinct().Count();
            TotalUnidades = preguntas.Select(p => p.Unidad).Distinct().Count();

            var agrupadas = preguntas
                .GroupBy(p => p.Asignatura)
                .Select(g => new { Asignatura = g.Key, Cantidad = g.Select(p => p.Unidad).Distinct().Count() })
                .ToList();

            Incompletas = agrupadas.Count(a => a.Cantidad <= 2);
            MedioCompletas = agrupadas.Count(a => a.Cantidad is 3 or 4);
            Completas = agrupadas.Count(a => a.Cantidad >= 5);
        }
    }
}
