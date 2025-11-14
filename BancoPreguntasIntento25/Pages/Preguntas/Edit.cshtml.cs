using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BancoPreguntasIntento25.Data;
using BancoPreguntasIntento25.Models;

namespace BancoPreguntasIntento25.Pages.Preguntas
{
    public class EditModel : PageModel
    {
        private readonly BancoPreguntasIntento25.Data.BancoPreguntasIntento25Context _context;

        public EditModel(BancoPreguntasIntento25.Data.BancoPreguntasIntento25Context context)
        {
            _context = context;
        }

        [BindProperty]
        public ListaPreguntas ListaPreguntas { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listapreguntas =  await _context.ListaPreguntas.FirstOrDefaultAsync(m => m.PreguntaId == id);
            if (listapreguntas == null)
            {
                return NotFound();
            }
            ListaPreguntas = listapreguntas;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ListaPreguntas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListaPreguntasExists(ListaPreguntas.PreguntaId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ListaPreguntasExists(int id)
        {
            return _context.ListaPreguntas.Any(e => e.PreguntaId == id);
        }
    }
}
