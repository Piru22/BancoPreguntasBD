using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BancoPreguntasIntento25.Data;
using BancoPreguntasIntento25.Models;

namespace BancoPreguntasIntento25.Pages.Preguntas
{
    public class IndexModel : PageModel
    {
        private readonly BancoPreguntasIntento25Context _context;

        public IndexModel(BancoPreguntasIntento25Context context)
        {
            _context = context;
        }

        public IList<ListaPreguntas> ListaPreguntas { get; set; } = default!;

        // Diccionario: asignatura -> número de unidades distintas
        public Dictionary<string, int> UnidadesPorAsignatura { get; set; } = new();

        // 👇 Se vincula desde la querystring (?Unidad=2)
        [BindProperty(SupportsGet = true)]
        public int? Unidad { get; set; }

        public async Task OnGetAsync()
        {
            var q = _context.ListaPreguntas.AsQueryable();

            if (Unidad.HasValue)
                q = q.Where(p => p.Unidad == Unidad.Value);

            ListaPreguntas = await q
                .OrderBy(p => p.Unidad)
                .ThenBy(p => p.Asignatura)
                .ThenBy(p => p.PreguntaId)
                .ToListAsync();

            // Agrupamos por asignatura y contamos unidades distintas
            UnidadesPorAsignatura = ListaPreguntas
                .GroupBy(p => (p.Asignatura ?? string.Empty).Trim())
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(p => p.Unidad).Distinct().Count()
                );
        }
    }
}
