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

        // 👇 Se vincula desde la querystring (?Unidad=2)
        [BindProperty(SupportsGet = true)]
        public int? Unidad { get; set; }

        public async Task OnGetAsync()
        {
            var q = _context.ListasPreguntas.AsQueryable();

            if (Unidad.HasValue)
                q = q.Where(p => p.Unidad == Unidad.Value);

            ListaPreguntas = await q
                .OrderBy(p => p.Unidad)
                .ThenBy(p => p.Asignatura)
                .ThenBy(p => p.PreguntaId)
                .ToListAsync();
        }
    }
}
