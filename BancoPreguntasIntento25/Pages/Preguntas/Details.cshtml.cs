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
    public class DetailsModel : PageModel
    {
        private readonly BancoPreguntasIntento25.Data.BancoPreguntasIntento25Context _context;

        public DetailsModel(BancoPreguntasIntento25.Data.BancoPreguntasIntento25Context context)
        {
            _context = context;
        }

        public ListaPreguntas ListaPreguntas { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listapreguntas = await _context.ListasPreguntas.FirstOrDefaultAsync(m => m.PreguntaId == id);
            if (listapreguntas == null)
            {
                return NotFound();
            }
            else
            {
                ListaPreguntas = listapreguntas;
            }
            return Page();
        }
    }
}
